namespace OT.Assessment.Services
    {
    public class ProviderService : IProviderService
        {
        private readonly IProviderReposistory _providerReposistory;

        public ProviderService(IProviderReposistory providerReposistory)
            {
            _providerReposistory = providerReposistory;
            }
        public async Task<bool> ProviderExistsAsync(string providerName)
            {
            //Code to retrieve Provider Name
            var providerExists = await _providerReposistory.ProviderByNameExists(providerName);
            if (!providerExists)
                return false;

            return true;
            }

        public async Task<bool> AddProviderAsync(Provider provider)
            {
            //Code to retrieve Provider Name
            var providerAdded = await _providerReposistory.AddProviderAsync(provider);

            if (!providerAdded)
                return false;

            return true;
            }
        public async Task<Provider> GetProviderByNameAsync(string providerName)
            {
            var provider =await  _providerReposistory.GetProviderByName(providerName);
            return provider;
            }
        }
    }
