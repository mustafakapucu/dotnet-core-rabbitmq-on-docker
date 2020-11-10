using System.Threading.Tasks;

namespace RabbitMQ.Producer.Services
{
    public interface IMqService
    {
        Task<bool> publishMessage(string message);
    }
}