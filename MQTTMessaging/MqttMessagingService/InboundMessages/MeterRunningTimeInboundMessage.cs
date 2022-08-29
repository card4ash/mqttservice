using System;

namespace MqttMessagingService.InboundMessages
{
  public class MeterRunningTimeInboundMessage : ISingleMeterInboundMessage
  {
    public long MeterNo { get; set; }
    public long DcuNo { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime RecordedDate { get; set; }
    public TimeSpan CumulativeRunningTime { get; set; }
  }
}