using System;

namespace MqttMessagingService.InboundMessages
{
  public class OnlineDcuInboundMessage  : ISingleMeterInboundMessage
  {
    public long MeterNo { get; set; }
    public long DcuNo { get; set; }
    public DateTime Timestamp { get; set; }
  }
}