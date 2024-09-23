namespace OT.Assessment.Services
    {
    public class Playerervice: IPlayerervice
        {
        private IPlayerReposistory _playerReposistory;
        public Playerervice(IPlayerReposistory  playerReposistory) {
            _playerReposistory= playerReposistory;
            }

        public async Task<Player> GetPlayerById(string playerId)
            {
            var player = new Player { AccountId = Guid.Parse(playerId) };
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
            return _playerReposistory.AddPlayer(player).Result;
            }
        }
    }
