namespace OT.Assessment.Services.IServices
    {
    public interface IGameervice
        {
        public Task<Game> GetGameByNameAsync(string nameOfGame);
        public Task<Game> GetGameByThemeAsync(string nameOfTheme);
        public Task<bool> GameByNameExistsAsync(string nameOfGame);
        }
    }
