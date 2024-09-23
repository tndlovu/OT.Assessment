using Microsoft.EntityFrameworkCore;

namespace OT.Assessment.Reposistory
    {
    public class PlayerReposistory : IPlayerReposistory
        {
        private readonly AssessmentDbContext _context;
        public PlayerReposistory(AssessmentDbContext context)
            {
            _context=context;
            }
        public Task<Player> GetPlayerByUseNameAsync(string userName)
            {
            var player = _context.Player.Where(pl=>pl.Username==userName).FirstOrDefault();
            return Task.FromResult(player);
            }

        public Task<IList<Player>> GetAllPlayerAsync()
            {
            return Task.FromResult<IList<Player>>([.. _context.Player]);
            }

        public Task<bool> PlayerByUserNameExistsAsync(string userName)
            {
            if(_context.Player.Where(pl=>pl.Username==userName).FirstOrDefault()==null)
                return Task.FromResult(false);

            return Task.FromResult(true);
            }

        public Task<Player> GetPlayerByAccountIdAsync(string accountId)
            {
            Player player = _context.Player.Where(pl => pl.AccountId == Guid.Parse(accountId)).FirstOrDefault();            
            return Task.FromResult(player);
            }

        public Task<bool> AddPlayer(Player player)
            {
            try
                {
                _context.Player.Add(player);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                return Task.FromResult(false);
                }
            return Task.FromResult(true);
            }
        public Task<bool> PlayerExists(string playerId)
            {
            if(_context.Player.Where(pl=>pl.AccountId.ToString() == playerId).FirstOrDefault()==null)
                return Task.FromResult(false);
            return Task.FromResult(true);
            }
        }
    }
