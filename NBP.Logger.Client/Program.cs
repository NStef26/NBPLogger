using NBP.Logger.CassandraClient.Entities;
using NBP.Logger.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NBP.Logger.CassandraClient;
using NBP.Logger.RedisClient;
using Newtonsoft.Json;

namespace NBP.Logger.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.Start();
        }
    }
}
