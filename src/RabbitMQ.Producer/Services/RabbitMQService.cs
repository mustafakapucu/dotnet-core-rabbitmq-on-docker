using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace RabbitMQ.Producer.Services
{
    public class RabbitMQService : IMqService
    {
        string rabbitMQConnectionUrl;
        public RabbitMQService(IConfiguration configuration)
        {
            rabbitMQConnectionUrl = configuration.GetSection("RabbitMq:Url").Value;
        }
        public async Task<bool> publishMessage(string message)
        {
            var factory = new ConnectionFactory() { HostName = rabbitMQConnectionUrl };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "m1",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "m1",
                                     basicProperties: null,
                                     body: body);
            }
            return true;
        }

    }
}