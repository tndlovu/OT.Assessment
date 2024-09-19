using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OT.Assessment.App.Models;
using OT.Assessment.App.Reposistory;
using RabbitMQ.Client;
using System.Text;

namespace OT.Assessment.App.Services
    {
    public class RabbitMQService: IRabbitMQService
        {

        private readonly IConnection _rabbitMqConnection;
        private readonly IRabbitMQReposistory _rabbitMQReposistory;
        private readonly IProviderService _providerSevice;
        private readonly IPlayerService _playerService;

        public RabbitMQService(IProviderService providerSevice,
                                IPlayerService playerService,
                                IRabbitMQReposistory rabbitMQReposistory)
            {

            this._rabbitMQReposistory = rabbitMQReposistory;
            _providerSevice = providerSevice;
            _playerService = playerService;
            }
        public async Task<bool> PublishWagerEventToRabbitMq(WagerEventModel wagerEvent)
            {
            var result = false;
            //if(!ValidateWageretails(wagerEvent))
            //    return result;

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
            if(!_playerService.PlayerByUserNameExistsAsync(wager.Username).Result)
                return false;
            return true;
            }
        }
    }
