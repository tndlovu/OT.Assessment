using OT.Assessment.App.Data;

namespace OT.Assessment.App.Reposistory
    {
    public class WagerReposistory : IWagerReposistory
    {
        private IRabbitMQReposistory _rabbitMQReposistory { get; set; }
        private readonly ApplicationDbContext _context;
        public WagerReposistory(ApplicationDbContext context)
        {
            _rabbitMQReposistory = new RabbitMQReposistory();
            _context = context;
        }

        public async Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayers)
            {
            var spenders = new List<TopSpenderModel>();

            spenders = _context.WagerEvent
                .GroupBy(gb => gb.AccountId)
                .Select(tsp => new TopSpenderModel
                    {
                    AccountId = tsp.Select(x => x.AccountId.ToString().Trim()).FirstOrDefault(),
                    Username = tsp.Select(un=>un.Username.Trim()).FirstOrDefault(),
                    TotalAmountSpend = tsp.Sum(am=>am.Amount).ToString().Trim()
                    })
                .OrderBy(ob => ob.Username)
                .ToList()
                .Slice(0, numberOfPlayers);

            return await Task.FromResult(spenders);
            }
        public async Task<bool> SaveWagerEvent(WagerEventModel wagerEvent)
        {
            var WegerSaved =  _rabbitMQReposistory.SaveWagerEventToRabbitMq(wagerEvent);
            return await Task.FromResult(WegerSaved); 
        }
        public async Task<IList<WagerEventModel>> GetWagers(string playeId)
            {
            return (IList<WagerEventModel>)_context.WagerEvent.ToListAsync();
            }
        public async Task<IList<PlayerWager>> GetWagersForPlayer(string playerId)
            {
            IList<PlayerWager> playerWagers=new List<PlayerWager>();
            var players = _context.WagerEvent.Where(p => p.AccountId == Guid.Parse( playerId));
            
            foreach(var player in players)
                {
                playerWagers.Add(
                    new PlayerWager { WagerId = player.WagerId.ToString(), 
                                      GameName = player.GameName.Trim(), 
                                      Provider =player.Provider.ToString(), 
                                      Amount =player.Amount.ToString(), 
                                      CreatedDate =player.CreatedDateTime.ToString()
                                    }
                    );
                }
            return await Task.FromResult(playerWagers);
            }
        }

}
