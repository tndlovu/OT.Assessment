namespace OT.Assessment.Services.IServices
    {
    public interface IRabbitMQService
        {
        Task<bool> PublishWagerEventToRabbitMq(WagerEventModel wagerEvent);
        }
    }
