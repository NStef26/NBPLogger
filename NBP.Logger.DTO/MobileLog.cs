using System;
using System.Collections.Generic;
using System.Text;

namespace NBP.Logger.DTO
{
    public class MobileLog : NBP.Logger.DTO.BasicLogger
    {
        public string MobileNumber { get; set; }
        public MobileLog(string mobileNumber, DateTime dateTime, string password)
            :base(dateTime, password)
        {
            MobileNumber = mobileNumber;
        }
    }
}
