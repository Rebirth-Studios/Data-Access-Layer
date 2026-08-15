using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace RebirthStudios.DataAccessLayer
{
    public class RebirthConnection : IDbConnection
    {
        public RebirthConnection(ILogger logger, string connectionString)
        {
        
            try
            {
                Connection = new SqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception e)
            {
                logger.LogException(e);
            }
        }

        public SqlConnection   Connection { get; set; }
        public ConnectionState State      => Connection.State;

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}