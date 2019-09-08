using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Core.Repositories;

namespace TesteFullStackPleno.Infrastructure.Services
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMqListener(IServiceScopeFactory serviceScopeFactory)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _serviceScopeFactory = serviceScopeFactory;
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

                WriteToSql(comportamento);
                WriteToFile(comportamento);
            };

            _channel.BasicConsume(queue: "comportamento",
                                    autoAck: true,
                                    consumer: consumer);
        }

        private void WriteToFile(Comportamento comportamento)
        {
            CsvWriter.Write(comportamento);
        }

        private void WriteToSql(Comportamento comportamento)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IComportamentoRepository>();

                repository.Add(comportamento);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Listen();
            return Task.CompletedTask;
        }
    }
}
