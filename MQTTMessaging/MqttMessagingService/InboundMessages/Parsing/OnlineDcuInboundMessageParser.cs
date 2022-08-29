using System;

namespace MqttMessagingService.InboundMessages.Parsing
{
    public class OnlineDcuInboundMessageParser : IInboundMessageParser<OnlineDcuInboundMessage>
    {
        private const char Separator = '-';
        private const int MeterIdIndex = 0;
        public OnlineDcuInboundMessage ParseMessage(string messageString)
        {
            try
            {
                var tokens = messageString.Split(Separator);
                var meterIdString = tokens[MeterIdIndex];
                var meterNo = long.Parse(meterIdString);
                var timestamp = DateTime.Now;

                return new OnlineDcuInboundMessage
                {
                    MeterNo = meterNo,
                    DcuNo = meterNo,
                    Timestamp = timestamp
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}