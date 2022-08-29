using System;

namespace MqttMessagingService.InboundMessages.Topics.Classification
{
    public class InvalidTopicException : Exception
    {
        public InvalidTopicException(string topic) : base($"Invalid topic: {topic}")
        {
        }
    }
}