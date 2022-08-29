namespace MqttMessagingService.InboundMessages.Topics.Classification
{
    public class TopicClassifier : ITopicClassifier
    {
        public TopicType GetTopicType(string topic)
        {
            switch (topic)
            {
                case TopicNames.MeterPowerConsumption:
                    return TopicType.MeterPowerConsumption;
                case TopicNames.MeterRunningTime:
                    return TopicType.MeterRunningTime;
                case TopicNames.MeterOfflineTime:
                    return TopicType.MeterOfflineTime;
                case TopicNames.OnlineMeter:
                    return TopicType.OnlineMeter;
                case TopicNames.OfflineMeter:
                    return TopicType.OfflineMeter;
                case TopicNames.OnlineDcu:
                    return TopicType.OnlineDcu;
                default:
                    throw new InvalidTopicException(topic);
            }
        }
    }
}