using OT.Assessment.App.Models;

namespace OT.Assessment.App.Services.IServices
    {
    public interface IGameService
        {
        public Task<Game> GetGameByNameAsync(string nameOfGame);
        public Task<Game> GetGameByThemeAsync(string nameOfTheme);
        public Task<bool> GameByNameExistsAsync(string nameOfGame);
        }
    }
