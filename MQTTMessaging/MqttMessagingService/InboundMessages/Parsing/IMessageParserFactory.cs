
using MqttMessagingService.InboundMessages.Topics;

namespace MqttMessagingService.InboundMessages.Parsing
{
    public interface IMessageParserFactory
    {
        IInboundMessageParser<IInboundMessage> CreateMessageParser(TopicType topic);
    }
}