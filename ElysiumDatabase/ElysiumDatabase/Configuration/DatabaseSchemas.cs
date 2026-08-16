using System;
using System.Collections.Generic;

namespace RebirthStudios.DataAccessLayer.Configuration
{
    public static class DatabaseSchemas
    {
        public const string Api = "api";
        public const string Content = "content";
        public const string History = "history";
        public const string Identity = "identity";
        public const string Operations = "ops";
        public const string Runtime = "runtime";

        private static readonly HashSet<string> OperationsTables = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase)
        {
            "ab",
            "DB_Errors",
            "historyBatchProcessing",
            "Internal_FK_Definition_Storage",
            "lastUpdatedTables",
            "Table_1",
            "test"
        };

        public static string GetTableSchema(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("Table name is required.", nameof(tableName));
            }

            if (tableName.Equals("playersAccounts", StringComparison.OrdinalIgnoreCase))
            {
                return Identity;
            }

            if (tableName.StartsWith("history", StringComparison.OrdinalIgnoreCase) &&
                !tableName.Equals("historyBatchProcessing", StringComparison.OrdinalIgnoreCase))
            {
                return History;
            }

            if (tableName.StartsWith("characters", StringComparison.OrdinalIgnoreCase) ||
                tableName.StartsWith("instanced", StringComparison.OrdinalIgnoreCase) ||
                tableName.StartsWith("spawned", StringComparison.OrdinalIgnoreCase) ||
                tableName.StartsWith("spawner", StringComparison.OrdinalIgnoreCase) ||
                tableName.Equals("questsGenerated", StringComparison.OrdinalIgnoreCase))
            {
                return Runtime;
            }

            if (tableName.StartsWith("_", StringComparison.Ordinal) ||
                OperationsTables.Contains(tableName))
            {
                return Operations;
            }

            return Content;
        }

        public static string QualifyTable(string tableName)
        {
            var escapedName = tableName.Replace("]", "]]", StringComparison.Ordinal);
            return $"[{GetTableSchema(tableName)}].[{escapedName}]";
        }
    }
}
