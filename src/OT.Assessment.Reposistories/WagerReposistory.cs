namespace OT.Assessment.Reposistory
    {
    public class WagerReposistory : IWagerReposistory
    {
        private IRabbitMQReposistory _rabbitMQReposistory { get; set; }
        private readonly AssessmentDbContext _context;
        public WagerReposistory(AssessmentDbContext context)
        {
            _rabbitMQReposistory = new RabbitMQReposistory();
            _context = context;
        }

        public async Task<IList<TopSpenderModel>> GetTopSpenders(int numberOfPlayer)
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
                .Slice(0, numberOfPlayer);

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
            var Player = _context.WagerEvent.Where(p => p.AccountId == Guid.Parse( playerId));
            
            foreach(var player in Player)
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
        public async Task<bool> SavePlayerWagerRecord(WagerEventModel model)
            {
            if (!_context.Player.Where(pl => pl.AccountId == model.AccountId).Any())
                {
                await _context.Player.AddAsync(new Player
                    {
                    AccountId = model.AccountId,
                    Username = model.Username

                    });
                _context.SaveChanges();
                }

            try
                {
                await _context.WagerEvent.AddAsync(model);
                _context.SaveChanges();
                }
            catch (Exception)
                {

                return false;
                }

            return true;
            }
        }

}
