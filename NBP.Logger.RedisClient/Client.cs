using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NBP.Logger.DTO;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace NBP.Logger.RedisClient
{
    public class Client
    {
        readonly Config RedisClient;

        public Client()
        {
            RedisClient = new Config();
        }

        #region Insert
        public void PublishMore(List<BasicLogger> List)
        {
            foreach (var Logger in List)
            {
                Publish(Logger);
            }
        }

        public void Publish(BasicLogger BasicLogger)
        {
            string val = "";
            if (BasicLogger is MobileLog)
                val = (BasicLogger as MobileLog).MobileNumber;
            if (BasicLogger is UsernameLog)
                val = (BasicLogger as UsernameLog).Username;
            if (BasicLogger is MailLog)
                val = (BasicLogger as MailLog).Mail;

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            bool t = true;
            foreach (var key in keys)
            {
                if (key == MakeHash(BasicLogger.TimeStamp.ToUniversalTime().ToString(), val))
                    t = false;
            }
            if (t)
                RedisClient.Database.StringSet(MakeHash(BasicLogger.TimeStamp.ToUniversalTime().ToString(), val), JsonConvert.SerializeObject(BasicLogger), TimeSpan.FromMinutes(5));
        }

        #endregion

        #region Get
        public BasicLogger GetValue(string key)
        {
            var first = RedisClient.Database.StringGet(key);
            if (first.ToString().Substring(0).Contains("Username"))
                return JsonConvert.DeserializeObject<UsernameLog>(first);
            if (first.ToString().Substring(0).Contains("Email"))
                return JsonConvert.DeserializeObject<MailLog>(first);
            if (first.ToString().Substring(0).Contains("MobileNumber"))
                return JsonConvert.DeserializeObject<MobileLog>(first);

            return null;
        }

        public List<BasicLogger> GetAllValues()
        {
            List<BasicLogger> list = new List<BasicLogger>();

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            foreach (var key in keys)	
            {
                list.Add(GetValue(key));
            }

            return list;
        }

        public List<MailLog> GetAllMails()
        {
            List<MailLog> mails = new List<MailLog>();

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            foreach (var key in keys)
            {
                var first = RedisClient.Database.StringGet(key);
                if (first.ToString().Substring(0).Contains("Mail"))
                    mails.Add(JsonConvert.DeserializeObject<MailLog>(first));
            }

            return mails;
        }

        public List<MobileLog> GetAllMobiles()
        {
            List<MobileLog> mobiles = new List<MobileLog>();

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            foreach (var key in keys)
            {
                var first = RedisClient.Database.StringGet(key);
                if (first.ToString().Substring(0).Contains("MobileNumber"))
                    mobiles.Add(JsonConvert.DeserializeObject<MobileLog>(first));
            }
            return mobiles;
        }

        public List<UsernameLog> GetAllUsernames()
        {
            List<UsernameLog> users = new List<UsernameLog>();

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            foreach (var key in keys)
            {
                var first = RedisClient.Database.StringGet(key);
                if (first.ToString().Substring(0).Contains("Username"))
                    users.Add(JsonConvert.DeserializeObject<UsernameLog>(first));
            }
            return users;
        }


        public List<BasicLogger> GetValues(string lower, string upper)
        {
            List<BasicLogger> list = new List<BasicLogger>();

            var tempList = RedisClient.redis.GetEndPoints().First();
            RedisKey[] keys = RedisClient.redis.GetServer(tempList).Keys().ToArray();

            foreach (var key in keys)
            {
                //if (key.ToString() >= lower && key.ToString() <= upper)
            }

            return null;
        }

        #endregion

        #region Delete
        public int DeleteMailsFromTo(DateTime lower, DateTime upper)
        {
            var mails = GetAllMails();
            int count = 0;
            foreach (var mail in mails)
            {
                if (mail.TimeStamp >= lower && mail.TimeStamp <= upper)
                {
                    if (RedisClient.Database.KeyDelete(MakeHash(mail.TimeStamp.ToUniversalTime().ToString(), mail.Mail)))
                        count++;
                }
            }
            return count;
        }

        public int DeleteMobilesFromTo(DateTime lower, DateTime upper)
        {
            var mobiles = GetAllMobiles();
            int count = 0;
            foreach (var mobile in mobiles)
            {
                if (mobile.TimeStamp >= lower && mobile.TimeStamp <= upper)
                {
                    if (RedisClient.Database.KeyDelete(MakeHash(mobile.TimeStamp.ToUniversalTime().ToString(), mobile.MobileNumber)))
                        count++;
                }
            }
            return count;
        }

        public int DeleteUsernamesFromTo(DateTime lower, DateTime upper)
        {
            var usernames = GetAllUsernames();
            int count = 0;
            foreach (var user in usernames)
            {
                if (user.TimeStamp >= lower && user.TimeStamp <= upper)
                {
                    if (RedisClient.Database.KeyDelete(MakeHash(user.TimeStamp.ToUniversalTime().ToString(), user.Username)))
                        count++;
                }
            }
            return count;
        }

        public void DeleteAllMails()
        {
            var mails = GetAllMails();
            
            foreach (var mail in mails)
            {
                RedisClient.Database.KeyDelete(MakeHash(mail.TimeStamp.ToUniversalTime().ToString(), mail.Mail));
            }
        }

        public void DeleteAllMobiles()
        {
            var mobiles = GetAllMobiles();

            foreach (var mobile in mobiles)
            {
                RedisClient.Database.KeyDelete(MakeHash(mobile.TimeStamp.ToUniversalTime().ToString(), mobile.MobileNumber));
            }
        }

        public void DeleteAllUsernames()
        {
            var users = GetAllUsernames();

            foreach (var user in users)
            {
                RedisClient.Database.KeyDelete(MakeHash(user.TimeStamp.ToUniversalTime().ToString(), user.Username));
            }
        }

        #endregion


        #region Hash
        private string MakeHash(string dateTime, string toHash)
        {
            return "time:" + dateTime + " hash:" + GetStringSha256Hash(toHash);
        }

        internal static string GetStringSha256Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }

        #endregion
    }
}
