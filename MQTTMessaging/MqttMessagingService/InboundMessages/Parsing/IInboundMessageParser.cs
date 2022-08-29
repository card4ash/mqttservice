namespace MqttMessagingService.InboundMessages.Parsing
{
    public interface IInboundMessageParser<out TMessage>
    {
        TMessage ParseMessage(string messageString);
    }
}