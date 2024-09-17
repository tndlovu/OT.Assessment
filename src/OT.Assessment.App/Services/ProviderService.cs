
namespace OT.Assessment.App.Services
    {
    public class ProviderService : IProviderService
        {
        private readonly IProviderReposistory _providerReposistory;

        public ProviderService()
            {
            _providerReposistory = new ProviderReposistory();
            }
        public Task<bool> ProviderExistsAsync(string providerName)
            {
            //Code to retrieve Provider Name
            var result = _providerReposistory.ProviderByNameExists(providerName);

            return Task.FromResult(true);
            }
        }
    }
