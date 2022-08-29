using System;
using MqttMessagingService.MqttMessaging;
using MQTTnet;

namespace MqttMessagingService.EventListening
{
    public class MqttEventListener : IMqttEventListener
    {
        private readonly IMqttMessageReceiver _mqttMessageReceiver;

        public MqttEventListener(IMqttMessageReceiver mqttMessageReceiver)
        {
            _mqttMessageReceiver = mqttMessageReceiver;
        }
        public void OnMqttMsgPublishReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            _mqttMessageReceiver.ReceiveMessage(e.ApplicationMessage.Topic, e.ApplicationMessage.Payload);
        }

    }
}