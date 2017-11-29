using System.Threading.Tasks;
using NServiceBus;
using Lateetud.NServiceBus.Common;
using NServiceBus.Logging;

public class MyHandler :
    IHandleMessages<TestMessage>
{

    static ILog log = LogManager.GetLogger<MyHandler>();

    public Task Handle(TestMessage message, IMessageHandlerContext context)
    {
        log.Info($"Subscriber has received RowMessage event with OrderId {message.Message}.");
        return Task.CompletedTask;
    }
}