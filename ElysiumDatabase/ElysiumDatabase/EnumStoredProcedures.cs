using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RebirthStudios.DataAccessLayer
{
    public class EnumStoredProcedures
    {
        public static Dictionary<int, string> Enum_AffectTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumAffectTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["AffectTypeId"].ToString());
                            var sqlName = row["AffectTypeName"].ToString();


                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_AttributeTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumAttributeTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["statId"].ToString());
                            var sqlName = row["statName"].ToString();


                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }

                } 
            }
    
            return myDict;
        }

        public static Dictionary<int, string> Enum_BaseWeaponTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumWeaponTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["weaponBaseId"].ToString());
                            var sqlName = row["weaponBaseName"].ToString();


                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }

                }    
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_ElementalTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumElementalTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["elementalTypeId"].ToString());
                            var sqlName = row["elementalTypeName"].ToString();
                            
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_EntityTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumEntityTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["entityTypeId"].ToString());
                            var sqlName = row["entityTypeName"].ToString();

                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_EquippableTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumEquippableTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["equippableTypeId"].ToString());
                            var sqlName = row["equippableTypeName"].ToString();


                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_GatherableTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumGatherableTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["gatherableTypeId"].ToString());
                            var sqlName = row["gatherableTypeName"].ToString();

                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_GlobalObjectTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumGlobalObjectTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["GlobalObjectTypeId"].ToString());
                            var sqlName = row["GlobalObjectTypeName"].ToString();
                            
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_ItemTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumItemTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["ItemTypeId"].ToString());
                            var sqlName = row["ItemTypeName"].ToString();
                            
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_MainHandWeaponTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumMainHandWeaponTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["weaponTypeId"].ToString());
                            var sqlName = row["weaponTypeName"].ToString();


                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            


            return myDict;
        }

        public static Dictionary<int, string> Enum_TwoHandedWeaponTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumTwoHandedWeaponTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["weaponTypeId"].ToString());
                            var sqlName = row["weaponTypeName"].ToString();
                    
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                } 
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_OffHandWeaponTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumOffHandWeaponTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["weaponTypeId"].ToString());
                            var sqlName = row["weaponTypeName"].ToString();

                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    } 
                }
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_RangedWeaponTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumRangedWeaponTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["weaponTypeId"].ToString());
                            var sqlName = row["weaponTypeName"].ToString();

                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }

                }   
            }

            return myDict;
        }

        public static Dictionary<int, string> Enum_RarityTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumRarityTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["rarityTypeId"].ToString());
                            var sqlName = row["rarityTypeName"].ToString();
                            
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_UseEffectTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumUseEffectTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["effectTypeId"].ToString());
                            var sqlName = row["effectTypeName"].ToString();
                            
                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }
            }
            
            return myDict;
        }

        public static Dictionary<int, string> Enum_WorldObjectTypeGetList(string connectionString)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            var dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "enumWorldObjectTypes";
                    // INPUT PARAMETERS

                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var sqlNumber = Int16.Parse(row["worldObjectTypeId"].ToString());
                            var sqlName = row["worldObjectTypeName"].ToString();

                            myDict.Add(sqlNumber, $"{sqlName}");
                        }
                    }
                }  
            }
            
            return myDict;
        }

    }
}