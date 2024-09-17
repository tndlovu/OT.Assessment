using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace OT.Assessment.Consumer.Data
    {
    public class ApplicationDbContext : DbContext
        {
        public string _connectionString=string.Empty;
        SqlConnection _connection;
        public ApplicationDbContext()
            {
            }

        public Player PlayerExists(string sql)
            {
            Player player = null;
            if (_connectionString == string.Empty)
                {
                return null;
                }
            if (!OpenConnection())
                {
                return null;
                }
            
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            try
                {
                var reader= cmd.ExecuteReader();
                while (reader.Read())
                    {
                    player = new Player();
                    player.AccountId = Guid.Parse(reader["AccountId"].ToString());
                    player.Username=reader["Username"].ToString();
                    }
                }
            catch (Exception ex)
                {
                CloseConnection();
                return null;
                }
            CloseConnection();
            return player;
            }
        public bool ExecuteNonQueryStringCommandType(Player player)
            {

            if (_connectionString == string.Empty)
                {
                return false;
                }
            if(!OpenConnection()){
                return false;
                }

            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.CommandText= "AddPlayer";
            cmd.Parameters.Add("@accountId", System.Data.SqlDbType.UniqueIdentifier).Value = player.AccountId;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar,10).Value = player.Username;
            try
                {
                cmd.ExecuteNonQuery();
                }catch (Exception ex)
                {
                CloseConnection();
                return false;
                }
            CloseConnection();
            return true;
            }
        public bool SavePlayerWagerRecord(WagerEventModel model)
            {

            if (_connectionString == string.Empty)
                {
                return false;
                }
            if (!OpenConnection())
                {
                return false;
                }

            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "AddPlayerWager";
            cmd.Parameters.Add("@WagerId", System.Data.SqlDbType.UniqueIdentifier).Value = model.WagerId;
            cmd.Parameters.Add("@Theme", System.Data.SqlDbType.NChar, 50).Value = model.Theme;
            cmd.Parameters.Add("@Provider", System.Data.SqlDbType.NChar, 50).Value = model.Provider;
            cmd.Parameters.Add("@GameName", System.Data.SqlDbType.NChar, 50).Value = model.GameName;
            cmd.Parameters.Add("@TransactionId", System.Data.SqlDbType.UniqueIdentifier).Value = model.TransactionId;
            cmd.Parameters.Add("@BrandId", System.Data.SqlDbType.UniqueIdentifier).Value = model.BrandId;
            cmd.Parameters.Add("@AccountId", System.Data.SqlDbType.UniqueIdentifier).Value = model.AccountId;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.NChar, 50).Value = model.Username;
            cmd.Parameters.Add("@ExternalReferenceId", System.Data.SqlDbType.UniqueIdentifier).Value = model.ExternalReferenceId;
            cmd.Parameters.Add("@TransactionTypeId", System.Data.SqlDbType.UniqueIdentifier).Value = model.TransactionTypeId;
            cmd.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal).Value = model.Amount;
            cmd.Parameters.Add("@CreatedDateTime", System.Data.SqlDbType.DateTimeOffset).Value = model.CreatedDateTime;
            cmd.Parameters.Add("@NumberOfBets", System.Data.SqlDbType.SmallInt).Value = model.NumberOfBets;
            cmd.Parameters.Add("@CountryCode", System.Data.SqlDbType.NChar, 10).Value = model.CountryCode;
            cmd.Parameters.Add("@SessionData", System.Data.SqlDbType.VarChar).Value = model.SessionData;
            cmd.Parameters.Add("@Duration", System.Data.SqlDbType.BigInt).Value = model.Duration;
            try
                {
                cmd.ExecuteNonQuery();
                }
            catch (Exception ex)
                {
                //Log error message here
                CloseConnection();
                return false;
                }
            CloseConnection();
            return true;
            }
        public bool OpenConnection( )
            {
            if(_connection == null )
                {
                _connection = new SqlConnection(_connectionString);
                
                }
            if(_connection.State!= ConnectionState.Open)
            {
                try
                    {
                    _connection.Open();
                    }
                catch (Exception e)
                    {
                    return false;
                    }
                }
            return true;
            }
        public bool CloseConnection( )
            {
            if(_connection == null)
                {
                return true;
                }
            if( _connection != null )
                {
                _connection.Close();
                }
            return true;
            }

        }
    }
