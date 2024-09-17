using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.Consumer.Reposistory.IReposistory
    {
    public interface IPlayerReposistory
        {
        bool PlayerExists(string playerId);

        bool AddNewPlayer(Player player);
        string ConnectionString { get; set; }
            
        }
    }
