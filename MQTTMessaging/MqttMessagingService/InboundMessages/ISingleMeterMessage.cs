using System;

namespace MqttMessagingService.InboundMessages
{
  public interface ISingleMeterMessage : IMessage
  {
    long MeterNo { get; set; }
    long DcuNo { get; set; }
    DateTime Timestamp { get; set; }
  }
}