using System.Threading.Tasks;
using NServiceBus;
using Lateetud.NServiceBus.Common.Models.NECGeneralAgent;
using Lateetud.NServiceBus.DAL;
using NServiceBus.Logging;

public class NECGeneralAgentHandler :
    IHandleMessages<NECGeneralAgent>
{
    static ILog log = LogManager.GetLogger<NECGeneralAgentHandler>();
    public Task Handle(NECGeneralAgent message, IMessageHandlerContext context)
    {
        Lateetud.NServiceBus.Subscriber.CenturySuretyProcess1.CenturysuretyProcessService csp = new Lateetud.NServiceBus.Subscriber.CenturySuretyProcess1.CenturysuretyProcessService();
        csp.Credentials = new System.Net.NetworkCredential("admin", "Password123");
        var response = csp.CenturysuretyProcess(message.Message);

        BaseManager manager = new BaseManager();
        manager.Update(message.MessageID, response);

        return Task.CompletedTask;
    }
}

//public class NECGeneralAgentResultHandler :
//    IHandleMessages<NECGeneralAgentResult>
//{
//    static ILog log = LogManager.GetLogger<NECGeneralAgentResultHandler>();
//    public Task Handle(NECGeneralAgentResult message, IMessageHandlerContext context)
//    {
//        log.Info($"NECGeneralAgentResult: {message.Message}.");
//        return Task.CompletedTask;
//    }
//}
