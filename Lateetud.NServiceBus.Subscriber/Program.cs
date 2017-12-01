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
            MsmqSqlDBConfiguration msmqsqldbconfig = new MsmqSqlDBConfiguration(ConfigurationManager.ConnectionStrings["SqlPersistence"].ConnectionString);
            

            // set to register Publisher endpoints to Subscribers end
            List<PublisherEndpoints> publisherEndpoints = new List<PublisherEndpoints>();
            publisherEndpoints.Add(new PublisherEndpoints(endpointName: "queue1.publisher", messageType: typeof(TestMessage)));

            // if queue does not exists, created & got pipeline
            var endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("queue2.subscriber", publisherEndpoints);
            msmqsqldbconfig.StartEndpoint(endpointConfiguration).GetAwaiter().GetResult();

            // if queue does not exists, created & got pipeline
            endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("queue3.subscriber", publisherEndpoints);
            msmqsqldbconfig.StartEndpoint(endpointConfiguration).GetAwaiter().GetResult();


            // set to register Publisher endpoints to Subscribers end
            publisherEndpoints = new List<PublisherEndpoints>();
            publisherEndpoints.Add(new PublisherEndpoints(endpointName: "queue2.publisher", messageType: typeof(TestMessage)));
            publisherEndpoints.Add(new PublisherEndpoints(endpointName: "queue3.publisher", messageType: typeof(TestMessage)));

            // if queue does not exists, created & got pipeline
            endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("queue1.subscriber", publisherEndpoints);
            msmqsqldbconfig.StartEndpoint(endpointConfiguration).GetAwaiter().GetResult();



            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
