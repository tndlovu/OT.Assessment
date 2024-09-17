namespace OT.Assessment.App.Services.IServices
    {
    public interface IWagerService
        {
        public Task<IList<PlayerWager>> GetWagersForPlayer(string playerId);
        public Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayers);
        }
    }
