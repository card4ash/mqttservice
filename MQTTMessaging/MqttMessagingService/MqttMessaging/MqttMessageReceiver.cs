using MqttMessagingService.InboundMessages.Processing;

namespace MqttMessagingService.MqttMessaging
{
    public class MqttMessageReceiver : IMqttMessageReceiver
    {
        private readonly IMessageProcessor _messageProcessor;

        public MqttMessageReceiver(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }

        public void ReceiveMessage(string topic, byte[] message)
        {
            _messageProcessor.ProcessMessage(topic, message);
        }
    }
}