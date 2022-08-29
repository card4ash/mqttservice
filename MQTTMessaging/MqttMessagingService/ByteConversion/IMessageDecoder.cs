namespace MqttMessagingService.ByteConversion
{
  public interface IMessageDecoder
  {
    string DecodeMessage(byte[] messageBytes);
  }
}