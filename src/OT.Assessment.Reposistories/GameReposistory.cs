namespace OT.Assessment.Reposistory
    {
    public class GameReposistory : IGameReposistory
        {
        private readonly AssessmentDbContext _context;
        public GameReposistory(AssessmentDbContext context)
            {
            _context = context;
            }

        public Task<IList<Game>> GetAllGame( )
            {
                IList <Game> Game = _context.Game.ToList();
                return (Task<IList<Game>>)Game;
            }

        public Task<Game> GetGameById(string gameId)
            {
            return Task.FromResult(_context.Game.Where(g=>g.Name== gameId).FirstOrDefault());
            }

        public Task<Game> GetGameByName(string gameName)
            {
            return Task.FromResult(_context.Game.Where(g => g.Name == gameName).FirstOrDefault());
            }

        public Task<bool> HasGame(string gameId)
            {
            Game foundGame = _context.Game.Where(g => g.Name == gameId).FirstOrDefault();
            if(foundGame != null)
                return Task.FromResult(false);
            return Task.FromResult(true);
            }

        public Task<bool> AddGame(Game newGame)
            {
            try
                {
                _context.Game.Add(newGame);
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
