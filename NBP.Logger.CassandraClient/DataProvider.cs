using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using NBP.Logger.CassandraClient.Entities;
using NBP.Logger.DTO;

namespace NBP.Logger.CassandraClient
{
    public static class DataProvider
    {
        #region Mail
        public static Mail GetMailByMailID(string MailID)
        {
            ISession session = SessionManager.GetSession();
            Mail mail = new Mail();

            if (session != null)
                return null;

            var ps = session.Prepare("select * from \"Mail\" where \"MailID\" = ?;");
            var st = ps.Bind(MailID);

            var mailData = session.Execute(st).FirstOrDefault();

            if (mailData != null)
            {
                mail.MailID = mailData["MailID"] != null ? mailData["MailID"].ToString() : string.Empty;
                mail.TimeStamp = ((DateTimeOffset) mailData["TimeStamp"]).UtcDateTime;
                mail.Password = mailData["Password"] != null ? mailData["Password"].ToString() : string.Empty;
                mail.Email = mailData["Email"] != null ? mailData["Email"].ToString() : string.Empty;
            }
            return mail;
        }

        public static List<Mail> GetMails(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();
            List<Mail> mails = new List<Mail>();

            if (session == null)
                return null;

            var mailsData = session.Execute("select * from \"Mail\";");

            foreach (var mailData in mailsData)
            {
                if ((DateTimeOffset)mailData["TimeStamp"] >= lower && (DateTimeOffset)mailData["TimeStamp"] <= upper)
                {
                    Mail mail = new Mail();
                    mail.MailID = mailData["MailID"] != null ? mailData["MailID"].ToString() : string.Empty;
                    mail.TimeStamp = ((DateTimeOffset)mailData["TimeStamp"]).UtcDateTime;
                    mail.Password = mailData["Password"] != null ? mailData["Password"].ToString() : string.Empty;
                    mail.Email = mailData["Email"] != null ? mailData["Email"].ToString() : string.Empty;
                    mails.Add(mail);
                }
            }

            return mails;
        }

        public static List<Mail> GetAllMails()
        {
            ISession session = SessionManager.GetSession();
            List<Mail> mails = new List<Mail>();

            if (session == null)
                return null;

            var mailsData = session.Execute("select * from \"Mail\";");

            foreach (var mailData in mailsData)
            {
                Mail mail = new Mail();
                mail.MailID = mailData["MailID"] != null ? mailData["MailID"].ToString() : string.Empty;
                mail.TimeStamp = ((DateTimeOffset)mailData["TimeStamp"]).UtcDateTime;
                mail.Password = mailData["Password"] != null ? mailData["Password"].ToString() : string.Empty;
                mail.Email = mailData["Email"] != null ? mailData["Email"].ToString() : string.Empty;
                mails.Add(mail);
            }

            return mails;
        }

        public static void AddMail(MailLog MailLog)
        {
            ISession session = SessionManager.GetSession();
            Mail mail = new Mail(Guid.NewGuid().ToString(), MailLog);
            LocalDate ld = new LocalDate(mail.TimeStamp.Year, mail.TimeStamp.Month, mail.TimeStamp.Day);
            DateTimeOffset dto = new DateTimeOffset(MailLog.TimeStamp);

            var t = TimeUuid.NewId(MailLog.TimeStamp);

            if (session == null)
                return;

            var ps = session.Prepare("insert into \"Mail\" (\"MailID\", \"TimeStamp\", \"Password\", \"Email\") VALUES (?, ?, ?, ?)");

            var batch = new BatchStatement().Add(ps.Bind(t, ((DateTimeOffset)mail.TimeStamp), mail.Password, mail.Email));

            RowSet mailData = session.Execute(batch);
        }

        public static List<MailLog> Transform(List<Mail> List)
        {
            List<MailLog> mailes = new List<MailLog>();
            
            foreach(var mail in List)
            {
                mailes.Add(new MailLog(mail.Email, mail.TimeStamp, mail.Password));
            }
            return mailes;
        }

        public static void DeleteAllMails()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            session.Execute("truncate \"Mail\";");
        }

        public static int DeleteMailsFromTo(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return -1;

            var fs = session.Prepare("select \"MailID\", \"TimeStamp\" from \"Mail\" where \"TimeStamp\" > ? and \"TimeStamp\" < ? allow filtering;");
            var list = session.Execute(fs.Bind((DateTimeOffset)lower, (DateTimeOffset)upper));
            int i = 0;

            foreach (var mail in list)
            {
                i++;
                var prepare = session.Prepare("delete from \"Mail\" where \"MailID\" = ? and \"TimeStamp\" = ?;");
                session.Execute(prepare.Bind(mail["MailID"], mail["TimeStamp"]));
            }

            return i;
        }

        #endregion

        #region Mobile
        public static Mobile GetMobileByMailID(string MobileID)
        {
            ISession session = SessionManager.GetSession();
            Mobile mobile = new Mobile();

            if (session != null)
                return null;

            var ps = session.Prepare("select * from \"Mobile\" where \"MobileID\" = ?");
            var st = ps.Bind(MobileID);
            var mobileData = session.Execute(st).FirstOrDefault();

            if (mobileData != null)
            {
                mobile.MobileID = mobileData["MobileID"] != null ? mobileData["MobileID"].ToString() : string.Empty;
                mobile.TimeStamp = ((DateTimeOffset)mobileData["TimeStamp"]).UtcDateTime;
                mobile.Password = mobileData["Password"] != null ? mobileData["Password"].ToString() : string.Empty;
                mobile.MobileNumber = mobileData["MobileNumber"] != null ? mobileData["MobileNumber"].ToString() : string.Empty;
            }
            return mobile;
        }

        public static List<Mobile> GetMobiles(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();
            List<Mobile> mobiles = new List<Mobile>();

            if (session == null)
                return null;

            var mobilesData = session.Execute("select * from \"Mobile\";");

            foreach (var mobileData in mobilesData)
            {
                if ((DateTimeOffset) mobileData["TimeStamp"] >=(DateTimeOffset)lower && (DateTimeOffset)mobileData["TimeStamp"] <= (DateTimeOffset)upper)
                {
                    Mobile mobile = new Mobile();
                    mobile.MobileID = mobileData["MobileID"] != null ? mobileData["MobileID"].ToString() : string.Empty;
                    mobile.TimeStamp =  ((DateTimeOffset )mobileData["TimeStamp"]).UtcDateTime;
                    mobile.Password = mobileData["Password"] != null ? mobileData["Password"].ToString() : string.Empty;
                    mobile.MobileNumber = mobileData["MobileNumber"] != null ? mobileData["MobileNumber"].ToString() : string.Empty;
                    mobiles.Add(mobile);
                }
            }
            return mobiles;
        }

        public static List<Mobile> GetAllMobiles()
        {
            ISession session = SessionManager.GetSession();
            List<Mobile> mobiles = new List<Mobile>();

            if (session == null)
                return null;

            var mobilesData = session.Execute("select * from \"Mobile\";");

            foreach (var mobileData in mobilesData)
            {
                Mobile mobile = new Mobile();
                mobile.MobileID = mobileData["MobileID"] != null ? mobileData["MobileID"].ToString() : string.Empty;
                mobile.TimeStamp = ((DateTimeOffset)mobileData["TimeStamp"]).UtcDateTime;
                mobile.Password = mobileData["Password"] != null ? mobileData["Password"].ToString() : string.Empty;
                mobile.MobileNumber = mobileData["MobileNumber"] != null ? mobileData["MobileNumber"].ToString() : string.Empty;
                mobiles.Add(mobile);
            }
            return mobiles;
        }

        public static void AddMobile(MobileLog MobileLog)
        {
            ISession session = SessionManager.GetSession();
            Mobile mobile = new Mobile(Guid.NewGuid().ToString(), MobileLog);
            var t1 = TimeUuid.NewId((DateTimeOffset)MobileLog.TimeStamp);
            DateTime t = MobileLog.TimeStamp;
            DateTimeOffset dto = new DateTimeOffset(t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.Millisecond, TimeZone.CurrentTimeZone.GetUtcOffset(t));

            if (session == null)
                return;

            var ps = session.Prepare("insert into \"Mobile\" (\"MobileID\", \"TimeStamp\", \"Password\", \"MobileNumber\") VALUES (?, ?, ?, ?)");

            var batch = new BatchStatement().Add(ps.Bind(t1, dto.ToUniversalTime(), mobile.Password, mobile.MobileNumber));

            RowSet mobileData = session.Execute(batch);
        }

        public static List<MobileLog> Transform(List<Mobile> List)
        {
            List<MobileLog> mobiles = new List<MobileLog>();

            foreach (var mobile in List)
            {
                mobiles.Add(new MobileLog(mobile.MobileNumber, mobile.TimeStamp, mobile.Password));
            }
            return mobiles;
        }

        public static void DeleteAllMobiles()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            session.Execute("truncate \"Mobile\";");
        }

        public static int DeleteMobilesFromTo(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return -1;

            var fs = session.Prepare("select \"MobileID\", \"TimeStamp\" from \"Mobile\" where \"TimeStamp\" > ? and \"TimeStamp\" < ? allow filtering;");
            var list = session.Execute(fs.Bind((DateTimeOffset)lower, (DateTimeOffset)upper));
            int i = 0;

            foreach (var mobile in list)
            {
                i++;
                var prepare = session.Prepare("delete from \"Mobile\" where \"MobileID\" = ? and \"TimeStamp\" = ?;");
                session.Execute(prepare.Bind(mobile["MobileID"], mobile["TimeStamp"]));
            }

            return i;
        }
        #endregion

        #region Username
        public static Username GetUsernameByMailID(string UsernameID)
        {
            ISession session = SessionManager.GetSession();
            Username username = new Username();

            if (session != null)
                return null;

            var ps = session.Prepare("select * from \"Username\" where \"UsernameID\" = ?");
            var st = ps.Bind(UsernameID);
            var usernameData = session.Execute(st).FirstOrDefault();

            if (usernameData != null)
            {
                username.UsernameID = usernameData["UsernameID"] != null ? usernameData["UsernameID"].ToString() : string.Empty;
                username.TimeStamp = ((DateTimeOffset)usernameData["TimeStamp"]).UtcDateTime;
                username.Password = usernameData["Password"] != null ? usernameData["Password"].ToString() : string.Empty;
                username.UserName = usernameData["UserName"] != null ? usernameData["UserName"].ToString() : string.Empty;
            }
            return username;
        }

        public static List<Username> GetUsernames(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();
            List<Username> usernames = new List<Username>();

            if (session == null)
                return null;

            var usernameDatas = session.Execute("select * from \"Username\"");

            foreach (var usernameData in usernameDatas)
            {
                if ((DateTimeOffset)usernameData["TimeStamp"] >= lower && (DateTimeOffset)usernameData["TimeStamp"] <= upper)
                {
                    Username username = new Username();
                    username.UsernameID = usernameData["UsernameID"] != null ? usernameData["UsernameID"].ToString() : string.Empty;
                    username.TimeStamp = ((DateTimeOffset)usernameData["TimeStamp"]).UtcDateTime;
                    username.Password = usernameData["Password"] != null ? usernameData["Password"].ToString() : string.Empty;
                    username.UserName = usernameData["UserName"] != null ? usernameData["UserName"].ToString() : string.Empty;
                    usernames.Add(username);
                }
            }
            return usernames;
        }

        public static List<Username> GetAllUsernames()
        {
            ISession session = SessionManager.GetSession();
            List<Username> usernames = new List<Username>();

            if (session == null)
                return null;

            var usernameDatas = session.Execute("select * from \"Username\"");

            foreach (var usernameData in usernameDatas)
            {
                Username username = new Username();
                username.UsernameID = usernameData["UsernameID"] != null ? usernameData["UsernameID"].ToString() : string.Empty;
                username.TimeStamp = ((DateTimeOffset)usernameData["TimeStamp"]).UtcDateTime;
                username.Password = usernameData["Password"] != null ? usernameData["Password"].ToString() : string.Empty;
                username.UserName = usernameData["UserName"] != null ? usernameData["UserName"].ToString() : string.Empty;
                usernames.Add(username);
            }
            return usernames;
        }

        public static void AddUsername(UsernameLog UsernameLog)
        {
            ISession session = SessionManager.GetSession();
            Username username = new Username(Guid.NewGuid().ToString(), UsernameLog);

            var t = TimeUuid.NewId(UsernameLog.TimeStamp);

            if (session == null)
                return;

            var ps = session.Prepare("insert into \"Username\" (\"UsernameID\", \"TimeStamp\", \"Password\", \"UserName\") VALUES (?, ?, ?, ?)");

            var batch = new BatchStatement().Add(ps.Bind(t, (DateTimeOffset)username.TimeStamp, username.Password, username.UserName));

            RowSet usernameData = session.Execute(batch);
        }

        public static List<UsernameLog> Transform(List<Username> List)
        {
            List<UsernameLog> usernames = new List<UsernameLog>();

            foreach (var username in List)
            {
                usernames.Add(new UsernameLog(username.UserName, username.TimeStamp, username.Password));
            }
            return usernames;
        }

        public static void DeleteAllUsernames()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            session.Execute("truncate \"Username\";");
        }

        public static int DeleteUsernamesFromTo(DateTime lower, DateTime upper)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return -1;

            var fs = session.Prepare("select \"UsernameID\", \"TimeStamp\" from \"Username\" where \"TimeStamp\" > ? and \"TimeStamp\" < ? allow filtering;");
            var list = session.Execute(fs.Bind((DateTimeOffset)lower, (DateTimeOffset)upper));
            int i = 0;

            foreach (var username in list)
            {
                i++;
                var prepare = session.Prepare("delete from \"Username\" where \"UsernameID\" = ? and \"TimeStamp\" = ?;");
                session.Execute(prepare.Bind(username["UsernameID"], username["TimeStamp"]));
            }

            return i;
        }
        #endregion

        public static bool ExecuteQuery(string text)
        {
            ISession session = SessionManager.GetSession();
            List<object> list = new List<object>();

            if (session == null)
                return false;

            try
            {
                session.Execute(text);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
