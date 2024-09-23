namespace OT.Assessment.App.Reposistory.IReposistory
    {
    public interface IPlayerReposistory
        {
        public Task<bool> PlayerByUserNameExistsAsync(string userName);
        public Task<Player> GetPlayerByUseNameAsync(string userName);
        public Task<IList<Player>> GetAllPlayersAsync();
        public Task<Player> GetPlayerByAccountIdAsync(string accountId);
        public Task<bool> AdPlayer(Player player);
        }
    }
