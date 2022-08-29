using System;
using MqttMessagingService.Configuring;
using MqttMessagingService.EventListening;
using MQTTnet.Client;
using MQTTnet;
using MqttMessagingService.MqttMessaging;
using Microsoft.Extensions.Logging;
using MQTTnet.Client.Options;
using MQTTnet.Protocol;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;

namespace MqttMessagingService.ConnectionHandling
{
    public class MqttConnectionHandler : IMqttConnectionHandler, IMqttMessageSender
    {
        private readonly MqttConfiguration _config;
        private readonly IMqttConfigurationLoader _loader;
        private readonly IMqttEventListener _mqttEventListener;
        private IMqttClient mqttClient { get; set; }
        private readonly ILogger<MqttConnectionHandler> _log;
        public MqttConnectionHandler(IMqttConfigurationLoader loader,
            IMqttEventListener mqttEventListener,
            ILogger<MqttConnectionHandler> logger)
        {
            _loader = loader;
            _mqttEventListener = mqttEventListener;
            _log = logger;
            _config = _loader.LoadMqttConfiguration();
        }

        public void InitializeMqttConnection()
        {
            MakeConnection();
        }
        private void DefinedMqttCommunicationEvents()
        {
            mqttClient.UseConnectedHandler(SubsCribeToTopicHandler);
            mqttClient.UseDisconnectedHandler(DisconnectedHandler);
            mqttClient.UseApplicationMessageReceivedHandler(_mqttEventListener.OnMqttMsgPublishReceived);
        }

        

        private void MakeConnection()
        {
            try
            {
                if (mqttClient == null || !mqttClient.IsConnected)
                {
                    BrokerConnectionWithoutCertificate();
                    //DefinedMqttCommunicationEvents();
                }
            }
            catch (Exception ex)
            {
                _log.LogError("Catch Block In MakeConnection(OuterMost)"+ex.Message,ex);
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    try
                    {
                        mqttClient.DisconnectAsync();
                    }
                    catch
                    {
                        _log.LogError("Catch Block In MakeConnection DisconnectAsync(OuterMost)" + ex.Message, ex);
                    }
                }

                MakeConnection();
            }
        }

        

        public async Task SendMessage(string topic, byte[] message)
        {
            var pubmessage = new MqttApplicationMessageBuilder()
                        .WithTopic(topic)
                        .WithPayload(message)
                        .WithExactlyOnceQoS()
                        .Build();
            await mqttClient.PublishAsync(pubmessage, CancellationToken.None);
        }


        

        private async void BrokerConnectionWithoutCertificate()
        {
            var options = new MqttClientOptionsBuilder()
                        .WithTcpServer(_config.BrokerAddress, _config.BrokerPort) 
                        .Build();
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();
            DefinedMqttCommunicationEvents();
            _log.LogInformation("### Mqtt Client is about to connect ###");
            var result=await mqttClient.ConnectAsync(options, CancellationToken.None);
        }
        private async Task SubsCribeToTopicHandler(MqttClientConnectedEventArgs args)
        {
            _log.LogInformation("### CONNECTED WITH SERVER ###");

            // Subscribe to a topic
            List<MqttTopicFilter> topicFilters = new List<MqttTopicFilter>();
            foreach (var topic in _config.Topics)
            {
                topicFilters.Add(new MqttTopicFilter
                {
                    Topic = topic,
                    QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce
                });
            }
            try
            {
                await mqttClient.SubscribeAsync(topicFilters.ToArray());
            }
            catch (Exception ex)
            {
                _log.LogError("Subscribe to topic failed.");
            }


            _log.LogInformation("### SUBSCRIBED ###");
        }
        private async Task DisconnectedHandler(MqttClientDisconnectedEventArgs args)
        {
            var options = new MqttClientOptionsBuilder()
                        .WithTcpServer(_config.BrokerAddress, _config.BrokerPort)
                        .Build();
            _log.LogError("### DISCONNECTED FROM SERVER ###");
            await Task.Delay(TimeSpan.FromSeconds(5));
            try
            {
                await mqttClient.ConnectAsync(options, CancellationToken.None);
            }
            catch
            {
                _log.LogError("### RECONNECTING FAILED ###");
            }
        }


    }
}