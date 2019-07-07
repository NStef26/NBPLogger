using NBP.Logger.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP.Logger.CassandraClient.Entities
{
    public class Username
    {
        public string UsernameID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public Username()
        {

        }

        public Username(string usernameID, UsernameLog usernameLog)
        {
            UsernameID = usernameID;
            TimeStamp = usernameLog.TimeStamp;
            Password = usernameLog.Password;
            UserName = usernameLog.Username;
        }
    }
}
