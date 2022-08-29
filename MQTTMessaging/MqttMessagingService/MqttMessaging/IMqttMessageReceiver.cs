namespace MqttMessagingService.MqttMessaging
{
    public interface IMqttMessageReceiver
    {
        void ReceiveMessage(string topic, byte[] message);
    }
}