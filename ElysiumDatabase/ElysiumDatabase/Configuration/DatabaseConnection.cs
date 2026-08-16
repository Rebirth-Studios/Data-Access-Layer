using System;
using Microsoft.Data.SqlClient;

namespace RebirthStudios.DataAccessLayer.Configuration
{
    public static class DatabaseConnection
    {
        public const string EnvironmentVariableName = "ELYSIUM_DB_CONNECTION";

        public static string Resolve(string connectionString = null)
        {
            var resolved = string.IsNullOrWhiteSpace(connectionString)
                ? Environment.GetEnvironmentVariable(EnvironmentVariableName)
                : connectionString;

            if (string.IsNullOrWhiteSpace(resolved))
            {
                throw new InvalidOperationException(
                    $"A SQL Server connection string is required. Pass it to the constructor or set {EnvironmentVariableName}.");
            }

            return resolved;
        }

        public static string Describe(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var database = string.IsNullOrWhiteSpace(builder.InitialCatalog)
                ? "<default>"
                : builder.InitialCatalog;

            return $"server '{builder.DataSource}', database '{database}'";
        }
    }
}
