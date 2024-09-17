namespace OT.Assessment.App.Reposistory
    {
    public class ProviderReposistory : IProviderReposistory
        {
        public Task<Provider> GetProviderByName(string name)
            {
            Provider provider = new Provider();
            return  Task.FromResult(provider);
            }

        public Task<bool> ProviderByNameExists(string name)
            {
            //Provider provider = new Provider();
            return Task.FromResult(true);
            }
        }
    }
    
