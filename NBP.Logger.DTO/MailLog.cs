using System;
using System.Collections.Generic;
using System.Text;

namespace NBP.Logger.DTO
{
    public class MailLog : BasicLogger
    {
        public string Mail { get; set; }
        public MailLog(string mail, DateTime dateTime, string password)
            :base(dateTime,password)
        {
            Mail = mail;
        }        
    }
}
