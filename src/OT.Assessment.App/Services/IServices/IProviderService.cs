namespace OT.Assessment.App.Services.IServices
    {
    public interface IProviderService
        {
        public Task<bool> ProviderExistsAsync(string providerName);
        public Task<bool> AddProviderAsync(Provider provider);
        public Task<Provider> GetProviderByNameAsync(string providerName);
        }
    }
