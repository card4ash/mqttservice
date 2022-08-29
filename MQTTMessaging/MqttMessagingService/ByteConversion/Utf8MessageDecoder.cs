using System.Text;

namespace MqttMessagingService.ByteConversion
{
  public class Utf8MessageDecoder : FixEncodingMessageDecoder
  {
    public Utf8MessageDecoder() : base(Encoding.UTF8)
    {
    }
  }
}