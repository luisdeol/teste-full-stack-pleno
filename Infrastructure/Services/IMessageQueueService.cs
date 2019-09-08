namespace TesteFullStackPleno.Infrastructure.Services
{
    public interface IMessageQueueService
    {
        void Send(byte[] message);
    }
}
