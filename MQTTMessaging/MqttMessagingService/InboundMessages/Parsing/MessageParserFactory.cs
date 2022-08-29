using MqttMessagingService.InboundMessages.Topics;
using System;

namespace MqttMessagingService.InboundMessages.Parsing
{
    public class MessageParserFactory : IMessageParserFactory
    {
        public IInboundMessageParser<IInboundMessage> CreateMessageParser(TopicType topic)
        {
            switch (topic)
            {
                case TopicType.MeterPowerConsumption:
                    return new MeterPowerConsumptionInboundMessageParserOnePointZero();
                case TopicType.MeterRunningTime:
                    return new MeterRunningTimeInboundMessageParserOnePointZero();
                case TopicType.OnlineMeter:
                    return new OnlineMeterInboundMessageParser();
                case TopicType.MeterOfflineTime:
                    return new MeterOfflineTimeInboundMessageParser();
                case TopicType.OnlineDcu:
                    return new OnlineDcuInboundMessageParser();
                default:
                    throw new Exception($"Invalid Topic Type: {topic}");
            }
        }
    }
}