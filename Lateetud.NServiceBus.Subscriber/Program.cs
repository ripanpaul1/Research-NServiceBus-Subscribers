using NServiceBus;
using System;
using System.Threading.Tasks;
using Lateetud.NServiceBus.Common;
using NServiceBus.Persistence.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Lateetud.NServiceBus.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            //MsmqSqlDBConfiguration msmqsqldbconfig = new MsmqSqlDBConfiguration(ConfigurationManager.ConnectionStrings["SqlPersistence"].ConnectionString);
            //List<PublisherEndpoints> publisherEndpoints = new List<PublisherEndpoints>();
            //publisherEndpoints.Add(new PublisherEndpoints(endpointName: "testqueue.Publisher", messageType: typeof(TestMessage)));
            //var endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("testqueue.Subscriber", publisherEndpoints);
            //msmqsqldbconfig.StartEndpoint(endpointConfiguration).GetAwaiter().GetResult();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
