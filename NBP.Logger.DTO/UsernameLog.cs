using System;
using System.Collections.Generic;
using System.Text;

namespace NBP.Logger.DTO
{
    public class UsernameLog : BasicLogger
    {
        public string Username { get; set; }
        public UsernameLog(string username, DateTime dateTime, string password)
            :base(dateTime,password)
        {
            Username = username;
        }
    }
}
