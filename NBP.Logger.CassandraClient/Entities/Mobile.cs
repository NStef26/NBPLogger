using NBP.Logger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP.Logger.CassandraClient.Entities
{
    public class Mobile
    {
        public string MobileID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Password { get; set; }
        public  string MobileNumber { get; set; }

        public Mobile()
        {

        }

        public Mobile(string mobileID, MobileLog MobileLog)
        {
            MobileID = mobileID;
            TimeStamp = MobileLog.TimeStamp;
            Password = MobileLog.Password;
            MobileNumber = MobileLog.MobileNumber;
        }
    }
}
