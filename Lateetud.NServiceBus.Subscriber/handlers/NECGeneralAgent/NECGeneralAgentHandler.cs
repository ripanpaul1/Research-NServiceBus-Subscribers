using System.Threading.Tasks;
using NServiceBus;
using Lateetud.NServiceBus.Common.Models.NECGeneralAgent;
using Lateetud.NServiceBus.DAL.NECGeneralAgent;
using NServiceBus.Logging;
using Lateetud.NServiceBus.Common;
using System.Configuration;

public class NECGeneralAgentHandler :
    IHandleMessages<NECGeneralAgent>
{
    static ILog log = LogManager.GetLogger<NECGeneralAgentHandler>();
    public Task Handle(NECGeneralAgent message, IMessageHandlerContext context)
    {
        MsmqSqlDBConfiguration msmqsqldbconfig = new MsmqSqlDBConfiguration(ConfigurationManager.ConnectionStrings["SqlPersistence"].ConnectionString, 1, 5);
        if (msmqsqldbconfig.IsFailedQ(context, "NServiceBus.FailedQ"))
        {
            var endpointConfiguration = msmqsqldbconfig.ConfigureEndpoint(context.MessageHeaders["NServiceBus.OriginatingEndpoint"]);
            msmqsqldbconfig.PublishedToBus(endpointConfiguration, new NECGeneralAgent { MessageID = message.MessageID, Message = message.Message });
        }
        else
        {
            Lateetud.NServiceBus.Subscriber.CenturySuretyProcess1.CenturysuretyProcessService csp = new Lateetud.NServiceBus.Subscriber.CenturySuretyProcess1.CenturysuretyProcessService();
            csp.Credentials = new System.Net.NetworkCredential("admin", "Password123");
            var response = csp.CenturysuretyProcess(message.Message);

            new NECGeneralAgentManager().Update(message.MessageID, response);
        }
        return Task.CompletedTask;
    }


    

}


