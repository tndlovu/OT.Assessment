namespace OT.Assessment.Services
    {
    public class WagerService: IWagerService
        {
        private readonly IWagerReposistory _wagerReposistory;

        public WagerService(IWagerReposistory wagerReposistory)
            {
            _wagerReposistory = wagerReposistory;
            }

        public Task<IList<PlayerWager>> GetWagersForPlayer(string playerId)
            {
            return _wagerReposistory.GetWagersForPlayer(playerId);
            }
        public Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayer )
            {
            return _wagerReposistory.GetTopSpenders(numberOfPlayer);
            }
        }
    }
