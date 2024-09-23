namespace OT.Assessment.Reposistory.IReposistory
    {
    public interface IWagerReposistory
    {
        Task<bool> SaveWagerEvent(WagerEventModel wagerEvent);
        public Task<IList<PlayerWager>> GetWagersForPlayer(string playerId);
        public Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayer);
        Task<bool> SavePlayerWagerRecord(WagerEventModel model);
        }
}
