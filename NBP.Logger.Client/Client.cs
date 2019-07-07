using NBP.Logger.CassandraClient;
using NBP.Logger.DTO;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NBP.Logger.Client
{
    public static class Client
    {
        public static void Start()
        {
            var logger = new LoggerConfiguration()
                          .WriteTo.Console()
                          .CreateLogger();
            int i = 0;

            while (true)
            {
                BasicLogger basic = new BasicLogger();

                if (i % 3 == 0)
                    basic = new MailLog(RandomGenerator.GenerateRandomMail(), DateTime.UtcNow, RandomGenerator.GenerateRandomPassword());
                if (i % 3 == 1)
                    basic = new MobileLog(RandomGenerator.GenerateRandomMobileNumber(), DateTime.UtcNow, RandomGenerator.GenerateRandomPassword());
                if (i % 3 == 2)
                    basic = new UsernameLog(RandomGenerator.GenerateRandomUsername(), DateTime.UtcNow, RandomGenerator.GenerateRandomPassword());

                logger.Information(JsonConvert.SerializeObject(basic));
                i++;
                if (i > 100)
                    break;

                if (basic is MailLog)
                    DataProvider.AddMail(basic as MailLog);
                if (basic is MobileLog)
                    DataProvider.AddMobile(basic as MobileLog);
                if (basic is UsernameLog)
                    DataProvider.AddUsername(basic as UsernameLog);

                Thread.Sleep(300);
            }
        }
    }
}
