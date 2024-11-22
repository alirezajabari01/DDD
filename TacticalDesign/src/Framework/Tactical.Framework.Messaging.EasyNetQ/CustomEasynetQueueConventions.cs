using EasyNetQ;

namespace Tactical.Framework.Messaging.EasyNetQ;

public class CustomEasynetQueueConventions : Conventions
{
    public CustomEasynetQueueConventions(ITypeNameSerializer typeNameSerializer) : base(typeNameSerializer)
    {
        ExchangeNamingConvention = type => $"{type.Name}_Exchange";
        QueueNamingConvention = (type, id) => $"{type.Name}_Queue";
        ErrorQueueNamingConvention = info => $"{info.Exchange.Replace("_Exchange", "")}_ErrorQueue";
        ErrorExchangeNamingConvention = info => $"{info.Exchange}_ErrorQueueExchange";
    }
}