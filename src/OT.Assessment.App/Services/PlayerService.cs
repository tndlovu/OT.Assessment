using OT.Assessment.App.Models;
using OT.Assessment.App.Reposistory;

namespace OT.Assessment.App.Services
    {
    public class PlayerService: IPlayerService
        {
        private IPlayerReposistory _playerReposistory;
        public PlayerService(IPlayerReposistory  playerReposistory) {
            _playerReposistory= playerReposistory;
            }

        public async Task<Player> GetPlayerById(string playerId)
            {
            var player = new Models.Player { AccountId = Guid.Parse(playerId) };
            return player;
            }

        public async Task<bool> PlayerByUserNameExistsAsync(string userName)
            {
            var playerExists =await _playerReposistory.PlayerByUserNameExistsAsync(userName);
            return playerExists;
            }
        public async Task<Player> GetPlayerByUseNameAsync(string userName)
            {
            var player = _playerReposistory.GetPlayerByUseNameAsync(userName);
            return player.Result;
            }

        public async Task<bool> AddPlayer(Player player)
            {
            return _playerReposistory.AdPlayer(player).Result;
            }
        }
    }
