using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MqttMessagingService.ByteConversion;
using MqttMessagingService.Configuring;
using MqttMessagingService.ConnectionHandling;
using MqttMessagingService.EventListening;
using MqttMessagingService.InboundMessages.Parsing;
using MqttMessagingService.InboundMessages.Processing;
using MqttMessagingService.InboundMessages.Topics.Classification;
using MqttMessagingService.MqttMessaging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MQTTServiceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "\\logs\\log-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Logger.Information("Application Starting");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .UseWindowsService()
                        .ConfigureServices((hostContext, services) =>
                        {
                            services.AddTransient<IMqttConnectionHandler, MqttConnectionHandler>();
                            services.AddTransient<IMqttConfigurationLoader, MqttConfigurationLoader>();
                            services.AddTransient<IMqttEventListener, MqttEventListener>();
                            services.AddTransient<IMqttMessageReceiver, MqttMessageReceiver>();
                            services.AddTransient<IMessageProcessor, MessageProcessor>();
                            services.AddTransient<ITopicClassifier, TopicClassifier>();

                            services.AddTransient<IMessageDecoder, Utf8MessageDecoder>();
                            services.AddTransient<IMessageParserFactory, MessageParserFactory>();

                            services.AddHostedService<Worker>();
                        })
                        .UseSerilog();
        }
        
    }
}
