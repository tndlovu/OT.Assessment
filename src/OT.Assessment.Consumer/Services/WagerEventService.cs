namespace OT.Assessment.Consumer.Services
    {
    public class WagerEventService: IWagerEventService
        {
        readonly IPlayerReposistory _playerReposistory;
        readonly IWagerEventReposistory _wagerEventReposistory;
        private string _connectionString = string.Empty;

        public string ConnectionString { 
            get { 
                    return _connectionString; 
                } 
            set {
                _connectionString=value;
                } 
            }
        public WagerEventService(IPlayerReposistory playerReposistory,
                                   IWagerEventReposistory wagerEventReposistory) { 
             this._playerReposistory = playerReposistory;
             this._wagerEventReposistory = wagerEventReposistory;
            }
        public Player ExtractPlayer(WagerEventModel model)
            {
            Player player = new Player();
            player.AccountId = model.AccountId;
            player.Username = model.Username;
            return player;
            }
        public WagerEventModel SavePlayeWagerRecord(WagerEventModel model)
            {
            WagerEventModel eventModel = new WagerEventModel();
            eventModel =_wagerEventReposistory.SavePlayeWagerRecord(model);
            return eventModel;
            }
        public bool PlayeExists(Player player)
            {
            _playerReposistory.ConnectionString=_connectionString;
            return _playerReposistory.PlayerExists(player.AccountId.ToString());
            }

        public bool AddNewPlayer(Player player)
            {
            _playerReposistory.ConnectionString = _connectionString;
            //string sql = string.Format("INSERT INTO [dbo].[Player] ([AccountId],[Username]) VALUES('5ac75fec-23e9-27d1-b660-179eee70003d','Jay.Bernhard67')");
            
            return _playerReposistory.AddNewPlayer(player);
            
            }
        }
    }
