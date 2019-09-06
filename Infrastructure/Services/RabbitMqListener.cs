using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Infrastructure.Persistence;

namespace TesteFullStackPleno.Infrastructure.Services
{
    public class RabbitMqListener : IHostedService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string ConnectionString = "Data source=.\\SQLEXPRESS;Initial Catalog=comportamentosDb;Integrated Security=SSPI";

        public RabbitMqListener(IServiceScopeFactory scopeFactory)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Listen();
            return Task.CompletedTask;
        }

        private void Listen()
        {
            _channel.QueueDeclare(queue: "comportamento",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, basicDeliver) =>
            {
                var body = basicDeliver.Body;
                var message = Encoding.UTF8.GetString(body);
                var comportamento = JsonConvert.DeserializeObject<Comportamento>(message);

                var optionsBuilder = new DbContextOptionsBuilder<TesteContext>();
                optionsBuilder.UseSqlServer(ConnectionString);

                using (var context = new TesteContext(optionsBuilder.Options))
                {
                    context.Comportamentos.Add(comportamento);
                    context.SaveChanges();
                }
            };

            _channel.BasicConsume(queue: "comportamento",
                                    autoAck: true,
                                    consumer: consumer);
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();
            return Task.CompletedTask;
        }
    }
}
