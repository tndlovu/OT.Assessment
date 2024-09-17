using OT.Assessment.App.Models;

namespace OT.Assessment.App.Services.IServices
    {
    public interface IRabbitMQService
        {
        Task<bool> PublishWagerEventToRabbitMq(WagerEventModel wagerEvent);
        }
    }
