namespace MqttMessagingService.InboundMessages.Processing
{
  public interface IMessageProcessor
  {
    void ProcessMessage(string topic, byte[] messageBytes);
  }
}