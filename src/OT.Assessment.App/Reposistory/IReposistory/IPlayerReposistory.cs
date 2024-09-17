namespace OT.Assessment.App.Reposistory.IReposistory
    {
    public interface IPlayerReposistory
        {
        public Task<bool> PlayerByUserNameExistsAsync(string userName);
        public Task<Player> GetPlayerByUseNameAsync(string userName);
        }
    }
