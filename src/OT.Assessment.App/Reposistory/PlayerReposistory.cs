

using OT.Assessment.App.Data;

namespace OT.Assessment.App.Reposistory
    {
    public class PlayerReposistory : IPlayerReposistory
        {
        private readonly ApplicationDbContext _context;
        public PlayerReposistory(ApplicationDbContext context)
            {
            _context=context;
            }
        public Task<Player> GetPlayerByUseNameAsync(string userName)
            {
            var player = _context.Players.Where(pl=>pl.Username==userName).FirstOrDefault();
            return Task.FromResult(player);
            }

        public async Task<IList<Player>> GetAllPlayersAsync()
            {
            return [.. _context.Players];
            }

        public Task<bool> PlayerByUserNameExistsAsync(string userName)
            {
            if(_context.Players.Where(pl=>pl.Username==userName).FirstOrDefault()==null)
                return Task.FromResult(false);

            return Task.FromResult(true);
            }

        public Task<Player> GetPlayerByAccountIdAsync(string accountId)
            {
            Player player = _context.Players.Where(pl => pl.AccountId == Guid.Parse(accountId)).FirstOrDefault();            
            return Task.FromResult(player);
            }

        public Task<bool> AdPlayer(Player player)
            {
            try
                {
                _context.Players.Add(player);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                return Task.FromResult(false);
                }
            return Task.FromResult(true);
            }
        }
    }
