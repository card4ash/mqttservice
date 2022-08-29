using MqttMessagingService.InboundMessages.Topics.Classification;
using System;
using MqttMessagingService.InboundMessages;
using MqttMessagingService.ByteConversion;
using MqttMessagingService.InboundMessages.Parsing;
using Microsoft.Extensions.Logging;
using MqttMessagingService.InboundMessages.Topics;

namespace MqttMessagingService.InboundMessages.Processing
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly ITopicClassifier _topicClassifier;
        private readonly IMessageDecoder _messageDecoder;
        private readonly IMessageParserFactory _messageParserFactory;
        private readonly ILogger<MessageProcessor> _log;

        public MessageProcessor(ITopicClassifier topicClassifier,
            IMessageDecoder messageDecoder,
            IMessageParserFactory messageParserFactory,
            ILogger<MessageProcessor> log)
        {
            _topicClassifier = topicClassifier;
            _messageDecoder = messageDecoder;
            _messageParserFactory = messageParserFactory;
            _log = log;
        }

        public async void ProcessMessage(string topic, byte[] messageBytes)
        {
            try
            {
                var topicType = _topicClassifier.GetTopicType(topic);
                if (topicType == TopicType.OfflineMeter) return;
                var messageString = _messageDecoder.DecodeMessage(messageBytes);
                var messageParser = _messageParserFactory.CreateMessageParser(topicType);
                var message = messageParser.ParseMessage(messageString);
                if (message == null) return;
                _log.LogDebug(messageString);
            }

            catch (Exception ex)
            {
                _log.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}