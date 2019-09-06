using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TesteFullStackPleno.Infrastructure.Services
{
    public class RabbitMqService : IMessageQueueService
    {
        private readonly ConnectionFactory _factory;
        public RabbitMqService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public void Consume()
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "comportamento",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    Send(channel);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                    };

                    channel.BasicConsume(queue: "comportamento",
                                         autoAck: true,
                                         consumer: consumer);
                }
            }
        }

        private void Send(IModel channel)
        {
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "comportamento",
                                 basicProperties: null,
                                 body: body);
        }

        public void Send(byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
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
