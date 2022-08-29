using System.Text;

namespace MqttMessagingService.ByteConversion
{
  public class FixEncodingMessageEncoder : IMessageEncoder
  {
    private readonly Encoding _encoding;

    public FixEncodingMessageEncoder(Encoding encoding)
    {
      _encoding = encoding;
    }

    public virtual byte[] EncodeMessage(string stringMessage)
    {
      return _encoding.GetBytes(stringMessage);
    }
  }
}