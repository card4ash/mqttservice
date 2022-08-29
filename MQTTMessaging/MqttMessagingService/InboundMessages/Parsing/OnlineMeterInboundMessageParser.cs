using MqttMessagingService.InboundMessages.Exceptions;
using System;
using System.Globalization;

namespace MqttMessagingService.InboundMessages.Parsing
{
    public class OnlineMeterInboundMessageParser : IInboundMessageParser<OnlineMeterInboundMessage>
    {
        private const string VersionNo = "1.0";
        private const char Separator = '|';
        private const string TimestampFormat = "yyyy-MM-dd HH:mm:ss";
        private const string DateFormat = "yyyy-MM-dd";
        private const int VersionNoIndex = 0;
        private const int MeterIdIndex = 1;
        private const int DcuIdIndex = 2;
        private const int TimestampIndex = 3;
        public OnlineMeterInboundMessage ParseMessage(string messageString)
        {
            try
            {
                var tokens = messageString.Split(Separator);
                var versionNo = tokens[VersionNoIndex];
                if (versionNo != VersionNo) throw new InvalidMessageException();
                var meterIdString = tokens[MeterIdIndex];
                var meterNo = long.Parse(meterIdString) / 10;
                var dcuIdString = tokens[DcuIdIndex];
                var dcuNo = long.Parse(dcuIdString);
                var timestampString = tokens[TimestampIndex];
                var timestamp = DateTime.ParseExact(timestampString, TimestampFormat, new DateTimeFormatInfo());

                return new OnlineMeterInboundMessage
                {
                    MeterNo = meterNo,
                    DcuNo = dcuNo,
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