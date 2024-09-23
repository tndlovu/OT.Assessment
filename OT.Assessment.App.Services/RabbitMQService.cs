using RabbitMQ.Client;

namespace OT.Assessment.Services
    {
    public class RabbitMQService: IRabbitMQService
        {

        private readonly IConnection _rabbitMqConnection;
        private readonly IRabbitMQReposistory _rabbitMQReposistory;
        private readonly IProviderService _providerSevice;
        private readonly IPlayerervice _Playerervice;

        public RabbitMQService(IProviderService providerSevice,
                                IPlayerervice Playerervice,
                                IRabbitMQReposistory rabbitMQReposistory)
            {

            this._rabbitMQReposistory = rabbitMQReposistory;
            _providerSevice = providerSevice;
            _Playerervice = Playerervice;
            }
        public async Task<bool> PublishWagerEventToRabbitMq(WagerEventModel wagerEvent)
            {
            var result = false;

            result = _rabbitMQReposistory.SaveWagerEventToRabbitMq(wagerEvent);
            return await Task.FromResult(result);
            }

        private IConnection CreateRabbitMqConnection( )
            {
            var factory = new ConnectionFactory { HostName = "localhost" };
            return factory.CreateConnection();
            }

        private bool ValidateWageretails(WagerEventModel wager)
            {
            if( wager == null )
                return false;

            if(!_providerSevice.ProviderExistsAsync(wager.Provider.ToString()).Result)
                return false;
            if(!_Playerervice.PlayerByUserNameExistsAsync(wager.Username).Result)
                return false;
            return true;
            }
        }
    }
