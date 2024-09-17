using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Assessment.Consumer.Services.IServices
    {
    public interface IWagerEventService
        {
        string ConnectionString { get; set; }
        Player ExtractPlayer(WagerEventModel model);
        bool PlayeExists(Player player);
        WagerEventModel SavePlayeWagerRecord(WagerEventModel model);
        bool AddNewPlayer(Player player);
        }
    }
