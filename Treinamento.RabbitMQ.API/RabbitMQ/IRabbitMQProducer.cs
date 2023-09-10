namespace Treinamento.RabbitMQ.API.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
