namespace OT.Assessment.App.Reposistory.IReposistory
    {
    public interface IRabbitMQReposistory
        {
         bool SaveWagerEventToRabbitMq(WagerEventModel wagerEvent);
        }
    }
