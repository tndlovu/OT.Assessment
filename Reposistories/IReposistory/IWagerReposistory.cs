using OT.Assessment.App.Models;

namespace OT.Assessment.App.Reposistory.IReposistory
{
    public interface IWagerReposistory
    {
        Task<bool> SaveWagerEvent(WagerEventModel wagerEvent);
        public Task<IList<PlayerWager>> GetWagersForPlayer(string playerId);
        public Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayers);
        }
}
