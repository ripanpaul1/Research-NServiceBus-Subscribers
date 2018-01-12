using System.Threading.Tasks;
using System.Net;
using NServiceBus;
using Lateetud.NServiceBus.Common.Models.Smart;
using Lateetud.NServiceBus.DAL.Smart;
using Lateetud.NServiceBus.DAL.ef;
using System;

public class RpaHandler :
    IHandleMessages<RPA>
{
    public Task Handle(RPA message, IMessageHandlerContext context)
    {
        // invoke blue prism service & send data and also get processed data
        //BP_AutomationService.InitBlueprismDataItemfromCService obj = new BP_AutomationService.InitBlueprismDataItemfromCService();
        //obj.Credentials = new NetworkCredential("admin", "Password2");
        //string rpaOutput = obj.InitBlueprismDataItemfromC(message.Message);

        // db operation here
        new SmartRpaManager().Update(new SmartRpa { RequestId = message.RequestID, MessageId = context.MessageId, Status = "Done" });

        return Task.CompletedTask;


        //return Task.FromCanceled(System.Threading.CancellationToken.None);

    }


    

}


