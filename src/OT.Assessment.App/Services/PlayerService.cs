using OT.Assessment.App.Models;
using OT.Assessment.App.Reposistory;

namespace OT.Assessment.App.Services
    {
    public class PlayerService: IPlayerService
        {
        private IPlayerReposistory playerReposistory;
        public PlayerService() {
            playerReposistory=new PlayerReposistory();
            }

        public async Task<Player> GetPlayerById(string playerId)
            {
            var player = new Models.Player { AccountId = Guid.Parse(playerId) };
            return player;
            }

        public async Task<bool> PlayerByUserNameExistsAsync(string userName)
            {
            var playerExists =await playerReposistory.PlayerByUserNameExistsAsync(userName);
            return playerExists;
            }
        public async Task<Player> GetPlayerByUseNameAsync(string userName)
            {
            var player = playerReposistory.GetPlayerByUseNameAsync(userName);
            return player.Result;
            }
        }
    }
