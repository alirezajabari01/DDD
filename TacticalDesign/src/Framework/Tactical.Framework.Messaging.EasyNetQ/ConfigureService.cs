using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using EasyNetQ.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Tactical.Framework.Messaging.EasyNetQ;

public static class ConfigureService
{

    public static IServiceCollection AddEasyNetQ(this IServiceCollection services, string rabbitMQConnectionString)
    {
        services.AddSingleton<IAutoSubscriberMessageDispatcher, MessageDispatcher>();

        services.AddSingleton(RabbitHutch.CreateBus(rabbitMQConnectionString, services => services.Register<IConventions>(c => new CustomEasynetQueueConventions(c.Resolve<ITypeNameSerializer>()))));

        return services;
    }


    public static void ConfigureConsumers<T>(this IServiceProvider provider)
    {
        var autoSubscriber = new AutoSubscriber(provider.GetRequiredService<IBus>(), "Behnam")
        {
            AutoSubscriberMessageDispatcher = provider.GetRequiredService<IAutoSubscriberMessageDispatcher>(),
            GenerateSubscriptionId = c => "Queue"
        };

        autoSubscriber.SubscribeAsync(typeof(T).Assembly.GetTypes());
    }
}
