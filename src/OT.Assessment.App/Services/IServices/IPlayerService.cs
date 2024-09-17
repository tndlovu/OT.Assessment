using OT.Assessment.App.Models;
using OT.Assessment.App.Services.IServices;

namespace OT.Assessment.App.Services.IServices
    {
    public interface IPlayerService
        {
        public Task<Player> GetPlayerById(string playerId);
        public Task<Player> GetPlayerByUseNameAsync(string userName);
        public Task<bool> PlayerByUserNameExistsAsync(string userName);
        }
    }
