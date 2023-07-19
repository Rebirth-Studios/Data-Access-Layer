using System;

namespace RebirthStudios.DataAccessLayer
{
    internal class ColumnData
    {
        public string columnName;
        public Type   columnType;

        public ColumnData(string columnName, Type columnType)
        {
            this.columnName = columnName;
            this.columnType = columnType;
        }
    }
}