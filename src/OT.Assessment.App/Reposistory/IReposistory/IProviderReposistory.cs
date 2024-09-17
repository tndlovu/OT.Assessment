namespace OT.Assessment.App.Reposistory.IReposistory
    {
    public interface IProviderReposistory
        {
        public Task<Provider> GetProviderByName(string name);
        public Task<bool> ProviderByNameExists(string name);
        }
    }
