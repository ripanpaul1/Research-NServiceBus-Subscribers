
using System;
using System.Configuration;
using System.Collections.Generic;
using Lateetud.NServiceBus.Common;
using Lateetud.NServiceBus.Common.Models.NECGeneralAgent;

namespace Lateetud.NServiceBus.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            MsmqSqlDBConfiguration msmqsqldbconfig = new MsmqSqlDBConfiguration(ConfigurationManager.ConnectionStrings["SqlPersistence"].ConnectionString);
            

            List<PublisherEndpoints> publisherEndpoints = new List<PublisherEndpoints>();
            publisherEndpoints.Add(new PublisherEndpoints(endpointName: "NEC.GeneralAgent.Publisher", messageType: typeof(NECGeneralAgent)));
            var endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("NEC.GeneralAgent.Subscriber", publisherEndpoints);
            msmqsqldbconfig.CreateEndpointInitializePipeline(endpointConfiguration).GetAwaiter().GetResult();

            publisherEndpoints.Clear();
            publisherEndpoints.Add(new PublisherEndpoints(endpointName: "NEC.GeneralAgent.Publisher", messageType: typeof(NECGeneralAgentResult)));
            endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint("NEC.GeneralAgent.Subscriber", publisherEndpoints);
            msmqsqldbconfig.CreateEndpointInitializePipeline(endpointConfiguration).GetAwaiter().GetResult();


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
