using MQTTnet;
using System;

namespace MqttMessagingService.EventListening
{
    public abstract class MqttEventListenerDecorator : IMqttEventListener
    {
        private readonly IMqttEventListener _mqttEventListener;

        protected MqttEventListenerDecorator(IMqttEventListener mqttEventListener)
        {
            _mqttEventListener = mqttEventListener;
        }


        public virtual void OnMqttMsgPublishReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            _mqttEventListener.OnMqttMsgPublishReceived(e);
        }

    }
}