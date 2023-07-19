//#if SERVER

using System;
using System.Collections.Generic;
using System.Data;

namespace RebirthStudios.DataAccessLayer
{
    internal static class DataTableExtensions
    {
        public static ILogger Logger { get; set; } 
        public static Dictionary<T1, Dictionary<T2, List<DataRow>>> ToDictionary_KeyKey_Nested<T1,T2>(this DataTable dt, string primaryKey, string secondaryKey)
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, Dictionary<T2, List<DataRow>>> rows = new Dictionary<T1, Dictionary<T2, List<DataRow>>>();
            
            foreach (DataRow row in dt.Select())
            {
                T1 primaryKeyValue   = (T1)row[primaryKey];
                T2 secondaryKeyValue = (T2)row[secondaryKey];
                if (!rows.ContainsKey(primaryKeyValue))
                {
                    rows.Add(primaryKeyValue,new Dictionary<T2, List<DataRow>>());
                }
                if (!rows[primaryKeyValue].ContainsKey(secondaryKeyValue))
                {
                    rows[primaryKeyValue].Add(secondaryKeyValue,new List<DataRow>());
                }
                rows[primaryKeyValue][secondaryKeyValue].Add(row);
            }
            
            return rows;
        }
        public static Dictionary<T1, Dictionary<T2, Dictionary<T3, List<DataRow>>>> ToDictionary_KeyKeyKey_Nested<T1,T2,T3>(this DataTable dt, string primaryKey, string secondaryKey, string tertiaryKey)
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, Dictionary<T2, Dictionary<T3, List<DataRow>>>> rows = new Dictionary<T1, Dictionary<T2, Dictionary<T3, List<DataRow>>>>();
            
            foreach (DataRow row in dt.Select())
            {
                T1 primaryKeyValue   = (T1)row[primaryKey];
                T2 secondaryKeyValue = (T2)row[secondaryKey];
                T3 tertiaryKeyValue = (T3)row[tertiaryKey];
                if (!rows.ContainsKey(primaryKeyValue))
                {
                    rows.Add(primaryKeyValue,new Dictionary<T2, Dictionary<T3, List<DataRow>>>());
                }
                if (!rows[primaryKeyValue].ContainsKey(secondaryKeyValue))
                {
                    rows[primaryKeyValue].Add(secondaryKeyValue,new Dictionary<T3, List<DataRow>>());
                }  
                if (!rows[primaryKeyValue][secondaryKeyValue].ContainsKey(tertiaryKeyValue))
                {
                    rows[primaryKeyValue][secondaryKeyValue].Add(tertiaryKeyValue, new List<DataRow>());
                }
                rows[primaryKeyValue][secondaryKeyValue][tertiaryKeyValue].Add(row);
            }
            
            return rows;
        }
        
        internal static Dictionary<T1, DataRow> ToDictionary<T1>(this DataTable dt, string fieldName, string statusName = "", string statusValue = "") where T1 : notnull
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, DataRow> rows = new Dictionary<T1, DataRow>();
            
            if (statusName != "")
            {
                foreach (DataRow row in dt.Select($"{statusName} = '{statusValue}'"))
                {
                    if(row[fieldName] == DBNull.Value || row[fieldName].GetType() != typeof(T1)) continue;
                    rows.Add((T1)row[fieldName],row);
                }   
            }
            else
            {
                foreach (DataRow row in dt.Select())
                {
                    if(row[fieldName] == DBNull.Value || row[fieldName].GetType() != typeof(T1)) continue;
                    rows.Add((T1)row[fieldName],row);
                }   
            }

            return rows;
        }    
        internal static Dictionary<T1, Dictionary<T2, DataRow>> ToDictionary<T1,T2>(this DataTable dt, string primaryKey, string secondaryKey) where T1 : notnull
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, Dictionary<T2, DataRow>> rows = new Dictionary<T1, Dictionary<T2, DataRow>>();
            
            foreach (DataRow row in dt.Select())
            {
                if (!rows.ContainsKey((T1)row[primaryKey]))
                {
                    rows.Add((T1)row[primaryKey],new Dictionary<T2, DataRow>());
                }
                rows[(T1)row[primaryKey]].Add((T2)row[secondaryKey], row);
            }

            foreach (var row in rows)
            {
                foreach (var r in row.Value)
                {
                    //Logger.Log($"{dt.TableName} - {row.Key}, {r.Key}, {r.Value}");
                }
            }

            return rows;
        }
        internal static Dictionary<T1, Dictionary<T2, Dictionary<T3,DataRow>>> ToDictionary<T1,T2,T3>(this DataTable dt, string primaryKey, string secondaryKey, string tertiaryKey)
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, Dictionary<T2, Dictionary<T3,DataRow>>> rows = new Dictionary<T1, Dictionary<T2, Dictionary<T3,DataRow>>>();
            
            foreach (DataRow row in dt.Select())
            {
                if (!rows.ContainsKey((T1)row[primaryKey]))
                {
                    rows.Add((T1)row[primaryKey],new Dictionary<T2, Dictionary<T3,DataRow>>());
                }
                if (!rows[(T1)row[primaryKey]].ContainsKey((T2)row[secondaryKey]))
                {
                    rows[(T1)row[primaryKey]].Add((T2)row[secondaryKey], new Dictionary<T3,DataRow>());
                }
                
                rows[(T1)row[primaryKey]][(T2)row[secondaryKey]].Add((T3)row[tertiaryKey], row);
            }
            
            return rows;
        }
        
        public static Dictionary<T1, List<DataRow>> ToDictionary_NestedList<T1>(this DataTable dt, string primaryKey)
        {
            if(dt.Rows.Count == 0) Logger.LogWarning($"DataTable: {dt.TableName} is empty");
            Dictionary<T1, List<DataRow>> rows = new Dictionary<T1, List<DataRow>>();
            
            foreach (DataRow row in dt.Select())
            {
                if (!rows.ContainsKey((T1)row[primaryKey]))
                {
                    rows.Add((T1)row[primaryKey],new List<DataRow>());
                }
                rows[(T1)row[primaryKey]].Add(row);
            }
            
            return rows;
        }
    }
}

//#endif