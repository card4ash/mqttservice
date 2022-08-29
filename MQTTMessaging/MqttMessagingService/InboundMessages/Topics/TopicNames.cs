namespace MqttMessagingService.InboundMessages.Topics
{
    public class TopicNames
    {
        public const string MeterPowerConsumption = "E/1/totalUnitPerDay";
        public const string MeterRunningTime = "E/1/totalTimePerDay";
        public const string MeterOfflineTime = "E/1/totalOfflineTimePerDay";
        public const string OnlineMeter = "E/1/MeterOnline";
        public const string OfflineMeter = "E/1/MeterOffline";
        public const string OnlineDcu = "E/1/DCU/Online";
    }
}