namespace MqttMessagingService.Configuring
{
    public interface IMqttConfigurationLoader
    {
        MqttConfiguration LoadMqttConfiguration();
    }
}