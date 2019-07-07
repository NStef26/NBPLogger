using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP.Logger.CassandraClient
{
    public static class SessionManager
    {
        public static ISession Session;

        public static ISession GetSession()
        {
            if (Session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                Session = cluster.Connect("proba");
            }
            return Session;
        }
    }
}
