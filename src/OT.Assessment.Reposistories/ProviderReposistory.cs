namespace OT.Assessment.Reposistory
    {
    public class ProviderReposistory : IProviderReposistory
        {
        private readonly AssessmentDbContext _context;
        public ProviderReposistory(AssessmentDbContext context)
            {
            _context = context;
            }
        public Task<Provider> GetProviderByName(string name)
            {
            Provider provider = _context.Provider.Where(pro => pro.ProviderName == name).FirstOrDefault();
            return  Task.FromResult(provider);
            }

        public Task<bool> ProviderByNameExists(string name)
            {
                if(string.IsNullOrEmpty(name))
                    return Task.FromResult(false);

                if(_context.Provider.Where(pro=>pro.ProviderName == name)==null)
                    return Task.FromResult(false);

                return Task.FromResult(true);
            }
        public Task<bool> AddProviderAsync(Provider provider)
            {
            if(provider == null)
                {
                return Task.FromResult(false);
                }
            try
                {
                _context.Provider.Add(provider);
                }catch(Exception ex)
                {
                return Task.FromResult(false);
                }
            return Task.FromResult(true);
            }
        }
    }
    
