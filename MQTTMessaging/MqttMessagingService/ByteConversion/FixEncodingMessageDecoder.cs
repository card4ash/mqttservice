using System.Text;

namespace MqttMessagingService.ByteConversion
{
    public class FixEncodingMessageDecoder : IMessageDecoder
    {
        private readonly Encoding _encoding;

        public FixEncodingMessageDecoder(Encoding encoding)
        {
            _encoding = encoding;
        }

        public virtual string DecodeMessage(byte[] messageBytes)
        {
            return _encoding.GetString(messageBytes);
        }
    }
}