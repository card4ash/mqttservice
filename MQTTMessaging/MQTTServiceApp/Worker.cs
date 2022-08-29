using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttMessagingService.ConnectionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MQTTServiceApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMqttConnectionHandler _mqttConnection;

        public Worker(ILogger<Worker> logger,
            IMqttConnectionHandler mqttConnection)
        {
            _logger = logger;
            _mqttConnection = mqttConnection;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _mqttConnection.InitializeMqttConnection();
            }
        }
    }
}
