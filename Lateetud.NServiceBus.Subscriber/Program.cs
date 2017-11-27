using NServiceBus;
using System;
using System.Threading.Tasks;
using Lateetud.NServiceBus.Common;
using NServiceBus.Persistence.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Lateetud.NServiceBus.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeQueue("testqueue.Subscriber", "testqueue.Publisher").GetAwaiter().GetResult();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        // InitiazeQueue
        static async Task InitializeQueue(string EndpointName_Subscriber, string EndpointName_Publisher)
        {
            var endpointConfiguration = new EndpointConfiguration(EndpointName_Subscriber);
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.EnableInstallers();

            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.SqlVariant(SqlVariant.MsSqlServer);
            persistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new SqlConnection(ConfigurationManager.ConnectionStrings["SqlPersistence"].ConnectionString);
                });
            var subscriptions = persistence.SubscriptionSettings();
            subscriptions.CacheFor(TimeSpan.FromDays(Convert.ToDouble(ConfigurationManager.AppSettings["Persistence.Subscriptions.CacheFor"])));

            var transport = endpointConfiguration.UseTransport<MsmqTransport>();
            var routing = transport.Routing();
            routing.RegisterPublisher(
                assembly: typeof(RowMessage).Assembly,
                publisherEndpoint: EndpointName_Publisher);

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
