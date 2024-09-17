using OT.Assessment.App.Models;

namespace OT.Assessment.App.Services
    {
    public class GameService: IGameService
        {
        public GameService()
            {

            }
        public Task<bool> GameByNameExistsAsync(string nameOfGame)
            {
            var result = GetGameByNameAsync(nameOfGame);
            if(result == null)
                {
                return Task.FromResult(false);
                }
            return Task.FromResult(true);
            }
        public Task<Game> GetGameByNameAsync(string nameOfGame)
            {
            //Code to retrieve Game from database
            return Task.FromResult<Game>( null );
            }

        public Task<Game> GetGameByThemeAsync(string nameOfTheme)
            {
            return Task.FromResult<Game>( null );
            }
        }
    }
