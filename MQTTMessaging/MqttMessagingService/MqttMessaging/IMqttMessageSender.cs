using System.Threading.Tasks;

namespace MqttMessagingService.MqttMessaging
{
    public interface IMqttMessageSender
    {
        Task SendMessage(string topic, byte[] message);
    }
}