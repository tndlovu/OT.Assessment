namespace OT.Assessment.Services
    {
    public class Gameervice: IGameervice
        {
        public Gameervice()
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
