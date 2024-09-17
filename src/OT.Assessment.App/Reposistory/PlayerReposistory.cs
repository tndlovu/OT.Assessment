

namespace OT.Assessment.App.Reposistory
    {
    public class PlayerReposistory : IPlayerReposistory
        {
        public Task<Player> GetPlayerByUseNameAsync(string userName)
            {
            return Task.FromResult(new Player());
            }

        public Task<bool> PlayerByUserNameExistsAsync(string userName)
            {
            return Task.FromResult(true);
            }
        }
    }
