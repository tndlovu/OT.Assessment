namespace OT.Assessment.Reposistory.IReposistory
    {
    public interface IGameReposistory
        {
        public Task<IList<Game>> GetAllGame( );
        public Task<Game> GetGameByName(string gameName);
        public Task<Game> GetGameById(string gameId);
        public Task<bool> HasGame(string gameId);
        }
    }
