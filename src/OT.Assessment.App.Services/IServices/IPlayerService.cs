namespace OT.Assessment.Services.IServices
    {
    public interface IPlayerervice
        {
        public Task<Player> GetPlayerById(string playerId);
        public Task<Player> GetPlayerByUseNameAsync(string userName);
        public Task<bool> PlayerByUserNameExistsAsync(string userName);
        }
    }
