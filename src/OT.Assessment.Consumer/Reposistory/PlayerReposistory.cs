using OT.Assessment.Consumer.Data;
namespace OT.Assessment.Consumer.Reposistory
    {
    public class PlayerReposistory: IPlayerReposistory
        {
        private ApplicationDbContext _dbContext;
        private string _connectionString=string.Empty;
        public string ConnectionString
            {
            get
                {
                return _connectionString;

                }
            set
                {
                _connectionString = value;
                }
            }
        public PlayerReposistory(ApplicationDbContext dbContext) {
            this._dbContext = dbContext;
            }
        public bool PlayerExists(string playerId)
            {
            string sql = string.Format("SELECT * FROM dbo.Player WHERE AccountId = '{0}'", playerId);
            _dbContext._connectionString = _connectionString;
            if (_dbContext.PlayerExists(sql) ==null)
                {
                return false;
                }
            return true;
            }
        public bool AddNewPlayer(Player player)
            {
            
            return _dbContext.ExecuteNonQueryStringCommandType(player);
           
            }
        }
    }
