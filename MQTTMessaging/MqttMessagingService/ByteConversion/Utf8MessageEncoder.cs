using System.Text;

namespace MqttMessagingService.ByteConversion
{
  public class Utf8MessageEncoder : FixEncodingMessageEncoder
  {
    public Utf8MessageEncoder() : base(Encoding.UTF8)
    {
    }
  }
}