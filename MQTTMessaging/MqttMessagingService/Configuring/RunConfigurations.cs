using System;

namespace MqttMessagingService.Configuring
{
  public static class RunConfigurations
  {
    public static TimeSpan MqttMessageMinimumDelay => TimeSpan.FromMinutes(2);
  }
}