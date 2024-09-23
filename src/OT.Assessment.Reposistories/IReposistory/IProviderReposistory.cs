namespace OT.Assessment.Reposistory.IReposistory
    {
    public interface IProviderReposistory
        {
        public Task<Provider> GetProviderByName(string name);
        public Task<bool> ProviderByNameExists(string name);
        public Task<bool> AddProviderAsync(Provider provider);
        }
    }
