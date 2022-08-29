using Microsoft.Extensions.Configuration;
using System;

namespace MqttMessagingService.Configuring
{
    public class MqttConfigurationLoader: IMqttConfigurationLoader
    {
        protected string DefaultBrokerAddress = string.Empty;
        protected int DefaultBrokerPort = 1883;
        protected ushort DefaultBrokerKeepAlivePeriod = 3600;
        protected string DefaultClientId = Guid.NewGuid().ToString();
        protected string DefaultUsername = null;
        protected string DefaultPassword = null;
        private readonly IConfiguration _configuration;

        public MqttConfigurationLoader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MqttConfiguration LoadMqttConfiguration()
        {
            return new MqttConfiguration
            {
                BrokerAddress = GetBrokerAddress(),
                BrokerPort = GetBrokerPort(),
                BrokerKeepAlivePeriod = GetBrokerKeepAlivePeriod(),
                ClientId = GetClientId(),
                Username = GetUsername(),
                Password = GetPassword(),
                IsSsl = GetIsSsl(),
                Topics = GetTopics(),
                QosLevel = GetOosLevel()
            };
        }

        protected string GetBrokerAddress()
        {
            return ReadAppSettings("BrokerAddress") ?? DefaultBrokerAddress;
        }

        protected int GetBrokerPort()
        {
            return ReadAppSettings("BrokerPort") == null
              ? DefaultBrokerPort
              : Convert.ToInt32(ReadAppSettings("BrokerPort"));
        }

        protected ushort GetBrokerKeepAlivePeriod()
        {
            return ReadAppSettings("BrokerKeepAlivePeriod") == null
              ? DefaultBrokerKeepAlivePeriod
              : Convert.ToUInt16(ReadAppSettings("BrokerKeepAlivePeriod"));
        }

        protected string GetClientId()
        {
            return ReadAppSettings("BrokerAccessClientId") ?? DefaultClientId;
        }

        protected string GetUsername()
        {
            return ReadAppSettings("BrokerAccessUsername") ?? DefaultUsername;
        }

        protected string GetPassword()
        {
            return ReadAppSettings("BrokerAccessPassword") ?? DefaultPassword;
        }

        protected string ReadAppSettings(string key)
        {
            var value= _configuration.GetSection("AppConfiguration").GetSection(key).Value;
            return value;
            //return "";//ConfigurationManager.AppSettings[key];
        }

        protected bool GetIsSsl()
        {
            return false;
        }

        protected string[] GetTopics()
        {
            return new[]
            {
                "E/1/totalTimePerDay",
                "E/1/totalUnitPerDay",
                "E/1/totalOfflineTimePerDay",
                "E/1/MeterOnline",
                "E/1/MeterOffline",
                "E/1/DCU/Online"
            };
        }
        
        protected byte GetOosLevel()
        {
            return default(byte);
        }
    }
}