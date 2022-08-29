namespace MqttMessagingService.Configuring
{
    public class MqttConfiguration
    {
        public string BrokerAddress { get; set; }
        public int BrokerPort { get; set; }
        public ushort BrokerKeepAlivePeriod { get; set; }
        public string ClientId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSsl { get; set; }
        public string[] Topics { get; set; }
        public byte QosLevel { get; set; }
    }
}