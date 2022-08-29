using System.Threading.Tasks;

namespace MqttMessagingService
{
    public abstract class MqttMessagingServiceInstance
    {
        public abstract Task Start();

        public abstract Task Stop();
    }
}