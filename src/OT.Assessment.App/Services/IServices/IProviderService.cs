namespace OT.Assessment.App.Services.IServices
    {
    public interface IProviderService
        {
        public Task<bool> ProviderExistsAsync(string providerName);
        }
    }
