using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.DependencyInjection;

namespace Tactical.Framework.Messaging.EasyNetQ;

public class MessageDispatcher : IAutoSubscriberMessageDispatcher
{
    private readonly IServiceProvider _provider;
    public MessageDispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void Dispatch<TMessage, TConsumer>(TMessage message, CancellationToken cancellationToken)
        where TMessage : class
        where TConsumer : class, IConsume<TMessage>
    {
        using var scope = _provider.CreateScope();
        var consumer = (TConsumer)scope.ServiceProvider.GetRequiredService(typeof(TConsumer));
        consumer.Consume(message, cancellationToken);
    }

    public async Task DispatchAsync<TMessage, TConsumer>(TMessage message, CancellationToken cancellationToken)
        where TMessage : class
        where TConsumer : class, IConsumeAsync<TMessage>
    {
        using var scope = _provider.CreateScope();
        var consumer = (TConsumer)scope.ServiceProvider.GetRequiredService(typeof(TConsumer));
        await consumer.ConsumeAsync(message, cancellationToken);
    }
}