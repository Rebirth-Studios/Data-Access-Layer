using System;
using System.Data;
using Microsoft.Data.SqlClient;
using RebirthStudios.DataAccessLayer.Configuration;
using RebirthStudios.Logging;

namespace RebirthStudios.DataAccessLayer
{
    public class RebirthConnection : IDbConnection
    {
        public RebirthConnection(ILogger logger, string connectionString)
        {
            try
            {
                logger.Log($"Opening SQL Server connection to {DatabaseConnection.Describe(connectionString)}.");
                Connection = new SqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception e)
            {
                logger.LogException(e);
                throw;
            }
        }

        public SqlConnection   Connection { get; }
        public ConnectionState State      => Connection.State;

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
