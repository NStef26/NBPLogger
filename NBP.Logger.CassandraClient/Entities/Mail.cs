using NBP.Logger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP.Logger.CassandraClient.Entities
{
    public class Mail
    {
        public string MailID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Password { get; set; }
        public  string Email { get; set; }

        public Mail()
        {

        }
        public Mail(string mailID, MailLog MailLog)
        {
            MailID = mailID;
            TimeStamp = MailLog.TimeStamp;
            Password = MailLog.Password;
            Email = MailLog.Mail;
        }
    }
}
