namespace MqttMessagingService.InboundMessages.Topics.Classification
{
    public interface ITopicClassifier
    {
        TopicType GetTopicType(string topic);
    }
}