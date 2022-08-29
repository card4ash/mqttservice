using MQTTnet;
using System;

namespace MqttMessagingService.EventListening
{
  public interface IMqttEventListener
  {
        void OnMqttMsgPublishReceived(MqttApplicationMessageReceivedEventArgs args);
  }
}