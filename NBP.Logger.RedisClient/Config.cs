using System;
using StackExchange.Redis;

namespace NBP.Logger.RedisClient
{
    public class Config
    {
        public readonly ConnectionMultiplexer redis;
        //var options = ConfigurationOptions.Parse()
        
        public IDatabase Database;
        public Config()
        {
            redis = ConnectionMultiplexer.Connect("localhost:6379"); ;
            Database = redis.GetDatabase();
        }
    }
}
