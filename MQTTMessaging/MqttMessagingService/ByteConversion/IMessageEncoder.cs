namespace MqttMessagingService.ByteConversion
{
  public interface IMessageEncoder
  {
    byte[] EncodeMessage(string stringMessage);
  }
}