using Microsoft.EntityFrameworkCore;
using OT.Assessment.Consumer.Data;
using OT.Assessment.Data.DataAccess;

namespace OT.Assessment.Consumer.Reposistory
    {
    internal class WagerEventReposistory: IWagerEventReposistory
        {
        private AssessmentDbContext _dbContext;
        public WagerEventReposistory(AssessmentDbContext dbContext)
            {
             this._dbContext = dbContext;
            }
        public WagerEventModel SavePlayerWagerRecord(WagerEventModel model)
            {
            try
                {
                _dbContext.WagerEvent.Add(model);
                _dbContext.SaveChanges();
                }catch (Exception ex) 
                {
                return null;
                }
            return model;
            }
        }
    }
