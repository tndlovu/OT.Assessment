using OT.Assessment.Consumer.Data;

namespace OT.Assessment.Consumer.Reposistory
    {
    internal class WagerEventReposistory: IWagerEventReposistory
        {
        private ApplicationDbContext _dbContext;
        public WagerEventReposistory(ApplicationDbContext dbContext)
            {
             this._dbContext = dbContext;
            }
        public WagerEventModel SavePlayeWagerRecord(WagerEventModel model)
            {
            if (_dbContext.SavePlayerWagerRecord(model))
                {
                return model;
                }
            return null;
            }
        }
    }
