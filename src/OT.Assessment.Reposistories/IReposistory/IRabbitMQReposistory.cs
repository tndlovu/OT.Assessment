namespace OT.Assessment.Reposistory.IReposistory
    {
    public interface IRabbitMQReposistory
        {
         bool SaveWagerEventToRabbitMq(WagerEventModel wagerEvent);
        }
    }
