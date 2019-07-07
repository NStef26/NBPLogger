using System;

namespace NBP.Logger.DTO
{
    public class BasicLogger
    {
        public DateTime TimeStamp { get; set; }
        public string Password { get; set; }

        public BasicLogger()
        {
            
        }

        public BasicLogger(DateTime timeStamp, string password)
        {
            TimeStamp = timeStamp;
            Password = password;
        }
    }
}
