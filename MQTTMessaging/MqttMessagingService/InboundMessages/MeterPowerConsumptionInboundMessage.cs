using System;

namespace MqttMessagingService.InboundMessages
{
  public class MeterPowerConsumptionInboundMessage : ISingleMeterInboundMessage
  {
    public long MeterNo { get; set; }
    public long DcuNo { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime RecordedDate { get; set; }
    public decimal PowerConsumption { get; set; }
  }
}