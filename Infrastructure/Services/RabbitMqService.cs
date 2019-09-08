using RabbitMQ.Client;

namespace TesteFullStackPleno.Infrastructure.Services
{
    public class RabbitMqService : IMessageQueueService
    {
        private readonly ConnectionFactory _factory;
        public RabbitMqService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public void Send(byte[] message)
        {
            using (var connection = _factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "comportamento",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "comportamento",
                                         basicProperties: null,
                                         body: message);
                }
        }
    }
}
