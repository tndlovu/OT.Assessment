namespace OT.Assessment.Reposistory.IReposistory
    {
    public interface IPlayerReposistory
        {
        public Task<bool> PlayerByUserNameExistsAsync(string userName);
        public Task<Player> GetPlayerByUseNameAsync(string userName);
        public Task<IList<Player>> GetAllPlayerAsync();
        public Task<Player> GetPlayerByAccountIdAsync(string accountId);
        public Task<bool> AddPlayer(Player player);
        public Task<bool> PlayerExists(string playerId);
        }
    }
