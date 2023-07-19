//#if SERVER

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RebirthStudios.DataAccessLayer.Enums;
using RebirthStudios.DataAccessLayer.Enums.TableColumns;
using RebirthStudios.DataAccessLayer.Models;
using RebirthStudios.Enums;
using RebirthStudios.Enums.Items;
using RebirthStudios.Enums.Stats;
using RebirthStudios.Enums.WorldObjects;
using RebirthStudios.RebirthStudios.Core.Enums.TableColumns;
// ReSharper disable InconsistentNaming

// ReSharper disable once CheckNamespace
namespace RebirthStudios.DataAccessLayer
{
    public class PlayerAccountRequestResponse
    {
        public bool    success;
        public string? errorMessage;
        public bool?   admin;
        public int?    accountId;
    }
    public class DataTableStoredProcs :   IDisposable
    {
        private static ILogger?              Logger { get; set; }
        private static DataTableStoredProcs? Instance;

        public readonly          DataTables       _dataTables;
        private         readonly DataTableSelects _dataTableSelects;

        private static bool SQL_PROFILING_ENABLED;
        private static byte CopperValue;
        private static byte SilverValue;
        private static int GoldValue;

        public DataTableStoredProcs(
            ILogger logger, 
            byte copperValue,
            byte silverValue,
            int goldValue,
            byte maxBags,
            byte maxPlayerBuybacks, 
            byte maxCharacters,
            bool sqlProfiling)
        {
            Instance          = this;
            Logger            = logger;

            _dataTables       = new DataTables(logger);
            _dataTableSelects = new DataTableSelects(_dataTables, logger);
            
            CopperValue       = copperValue;
            SilverValue       = silverValue;
            GoldValue         = goldValue;
            
            MaxBags          = maxBags;
            MaxPlayerBuybacks = maxPlayerBuybacks;
            MaxCharacters = maxCharacters;
            
            SQL_PROFILING_ENABLED = sqlProfiling;
        }

        public void Init()
        {
            _dataTables.Init();

            StatusEffect_EffectsGetList();
        }


        public void Dispose()
        {
            _dataTables.Dispose();
        }

        public void ProcessSqlUpdates()
        {
            Logger!.Log("Processing SQL Updates");
            _dataTables.ProcessSqlUpdates();
        }
        #region Tables

         internal static Dictionary<int, EnumData> Tables_InstanceItems_GetColumns()
         {
             var  list = new Dictionary<int, EnumData>();
             byte i    = 0;
             foreach (DataColumn column in Instance!._dataTables.InstancedItemsDataTable.Columns)
             {
                 list.Add(i, new EnumData(column.ColumnName, null!, null!));
                 i++;
             }

             return list;
         }

         #endregion
         public static Dictionary<byte, Dictionary<byte, List<CharacterCreationOption>>> CharacterCreationOptions_GetList()
         {
             Dictionary<byte, Dictionary<byte, List<CharacterCreationOption>>> creationData =
                 new Dictionary<byte, Dictionary<byte, List<CharacterCreationOption>>>();
             foreach (DataRow cCO in Instance!._dataTables.CharacterCreationOptionsDataTable.Rows)
             {
                 //byte styleId      = (byte)cCO[(byte)CharacterCreationOptionsColumns.styleId];
                 var  styleName    = (string)cCO[(byte)CharacterCreationOptionsColumns.styleName];
                 byte styleTypeId  = (byte)cCO[(byte)CharacterCreationOptionsColumns.styleTypeId];
                 byte genderTypeId = (byte)cCO[(byte)CharacterCreationOptionsColumns.genderTypeId];
                 var  stylePath    = (string)cCO[(byte)CharacterCreationOptionsColumns.stylePath];
                 if (!creationData.ContainsKey(styleTypeId)) creationData.Add(styleTypeId,
                     new Dictionary<byte, List<CharacterCreationOption>>());
                 
                 if (!creationData[styleTypeId].ContainsKey(genderTypeId)) 
                     creationData[styleTypeId].Add(genderTypeId, new List<CharacterCreationOption>());

                 creationData[styleTypeId][genderTypeId].Add(new CharacterCreationOption(styleName, stylePath));
             } 
 #if UNITY_EDITOR
             if(creationData.Count == 0) Logger!.LogWarning($"ERROR: CharacterCreationOptions_GetList - 0 Results");
 #endif
             return creationData;
         }
         public static Dictionary<string, long> LastUpdatedTables_GetList()
         {
             Dictionary<string, long> lastUpdatedTables = new Dictionary<string, long>();
             foreach (DataRow lUT in Instance!._dataTables.LastUpdatedTablesDataTable.Rows)
             {
                 string lastUpdatedTable = (string) lUT[(byte)LastUpdatedTablesColumns.lastUpdatedTable];
                 var lastUpdate = (DateTime) lUT[(byte)LastUpdatedTablesColumns.lastUpdate];
                 lastUpdatedTables.Add(lastUpdatedTable, lastUpdate.ToBinary());
             } 
 #if UNITY_EDITOR
             if(lastUpdatedTables.Count == 0) Logger!.LogWarning($"ERROR: LastUpdatedTables_GetList - 0 Results");
 #endif
             return lastUpdatedTables;
         }

         #region DATA TABLE STP GETS: ENUMS

         internal static Dictionary<int, EnumData> ApplicationTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow aT in Instance!._dataTables.ApplicationTypesDataTable.Rows)
             {
                 var applicationTypeId = (byte)aT[(byte)ApplicationTypesColumns.applicationTypeId];
                 var applicationType   = (string)aT[(byte)ApplicationTypesColumns.applicationType];

                 EnumData enumData = new EnumData(applicationType, null, null);
                 myDict.Add(applicationTypeId, enumData);
             }
#if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityTypes_GetList - 0 Results");
#endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> AbilityTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow aT in Instance!._dataTables.AbilityTypesDataTable.Rows)
             {
                 var abilityTypeId = (byte)aT[(byte)AbilityTypesColumns.abilityTypeId];
                 var abilityType = (string)aT[(byte)AbilityTypesColumns.abilityType];
                 var abilityTypeName = (string)aT[(byte)AbilityTypesColumns.abilityTypeName];
                 var description = (string)aT[(byte)AbilityTypesColumns.description];

                 EnumData enumData = new EnumData(abilityType, abilityTypeName, description);
                 myDict.Add(abilityTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> AbilityEffectTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow aEt in Instance!._dataTables.AbilityEffectTypesDataTable.Rows)
             {
                 var abilityEffectTypeId = (byte)aEt[(byte)AbilityEffectTypesColumns.abilityEffectTypeId];
                 var abilityEffectType = (string)aEt[(byte)AbilityEffectTypesColumns.abilityEffectType];
                 var abilityEffectTypeName = (string)aEt[(byte)AbilityEffectTypesColumns.abilityEffectTypeName];
                 var description = (string)aEt[(byte)AbilityEffectTypesColumns.description];

                 EnumData enumData = new EnumData(abilityEffectType, abilityEffectTypeName, description);
                 myDict.Add(abilityEffectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityEffectTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> AbilityCostTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow cT in Instance!._dataTables.CostTypesDataTable.Rows)
             {
                 var costTypeId   = (byte)cT[(byte)CostTypesColumns.costTypeId];
                 var costType     = (string)cT[(byte)CostTypesColumns.costType];
                 var costTypeName = (string)cT[(byte)CostTypesColumns.costTypeName];
                 var description  = (string)cT[(byte)CostTypesColumns.costTypeDescription];

                 EnumData enumData = new EnumData(costType, costTypeName, description);
                 myDict.Add(costTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityCostTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> ArmorTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow aT in Instance!._dataTables.ArmorTypesDataTable.Rows)
             {
                 var armorTypeId = (byte)aT[(byte)ArmorTypesColumns.armorTypeId];
                 var armorType = (string)aT[(byte)ArmorTypesColumns.armorType];
                 var armorTypeName = (string)aT[(byte)ArmorTypesColumns.armorTypeName];
                 var description = (string)aT[(byte)ArmorTypesColumns.description];
                 
                 EnumData enumData = new EnumData(armorType, armorTypeName, description);
                 myDict.Add(armorTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ArmorTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> AttributeTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatsDataTable.Select()) 
             {
                 var statTypeId = (byte)sT[(byte)StatsColumns.statTypeId];
                 if(statTypeId == (byte)StatTypes.AttributePrimary || statTypeId == (byte)StatTypes.AttributeSecondary)
                 {
                     var statId = (byte)sT[(byte)StatsColumns.statId];
                     var stat = (string)sT[(byte)StatsColumns.stat];
                     var statName = (string)sT[(byte)StatsColumns.statName];
                     var statDescription = (string)sT[(byte)StatsColumns.statDescription];
                     
                     EnumData enumData = new EnumData(stat, statName, statDescription);
                     myDict.Add(statId, enumData);
                 }
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AttributeTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> CalcStatTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatCalculatedTypesDataTable.Select())
            {
                 var interactableTypeId = (byte)sT[(byte)StatCalculatedTypesColumns.statCalculatedTypeId];
                 var stat = (string)sT[(byte)StatCalculatedTypesColumns.statCalculatedType];
                 var statName = (string)sT[(byte)StatCalculatedTypesColumns.statCalculatedTypeName];
                 var statDescription = (string)sT[(byte)StatCalculatedTypesColumns.description];
                 
                 EnumData enumData = new EnumData(stat, statName, statDescription);
                 myDict.Add(interactableTypeId, enumData);
             
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: CalcStatTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> ContainerTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow cT in Instance!._dataTables.ContainerTypesDataTable.Rows)
             {
                 var containerTypeId   = (byte)cT[(byte)ContainerTypesColumns.containerTypeId];
                 var containerType     = (string)cT[(byte)ContainerTypesColumns.containerType];
                 var containerTypeName = (string)cT[(byte)ContainerTypesColumns.containerTypeName];
                 var description       = (string)cT[(byte)ContainerTypesColumns.description];
                 
                 EnumData enumData = new EnumData(containerType, containerTypeName, description);
                 myDict.Add(containerTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ContainerTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> BagTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow cT in Instance!._dataTables.ConsumableTypesDataTable.Rows)
             {
                 var consumableTypeId = (byte)cT[(byte)ConsumableTypesColumns.consumableTypeId];
                 var consumableType = (string)cT[(byte)ConsumableTypesColumns.consumableType];
                 var consumableTypeName = (string)cT[(byte)ConsumableTypesColumns.consumableTypeName];
                 var description = (string)cT[(byte)ConsumableTypesColumns.description];
                 
                 EnumData enumData = new EnumData(consumableType, consumableTypeName, description);
                 myDict.Add(consumableTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ConsumableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> ConsumableTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow cT in Instance!._dataTables.ConsumableTypesDataTable.Rows)
             {
                 var consumableTypeId = (byte)cT[(byte)ConsumableTypesColumns.consumableTypeId];
                 var consumableType = (string)cT[(byte)ConsumableTypesColumns.consumableType];
                 var consumableTypeName = (string)cT[(byte)ConsumableTypesColumns.consumableTypeName];
                 var description = (string)cT[(byte)ConsumableTypesColumns.description];
                 
                 EnumData enumData = new EnumData(consumableType, consumableTypeName, description);
                 myDict.Add(consumableTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ConsumableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> CurrentStatTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatsDataTable.Rows)
             {
                 var statTypeId = (byte)sT[(byte)StatsColumns.statTypeId];
                 if (statTypeId == 8)
                 {
                     var interactableTypeId = (byte) sT[(byte)StatsColumns.statId];
                     var stat               = (string) sT[(byte)StatsColumns.stat];
                     var statName           = (string) sT[(byte)StatsColumns.statName];
                     var statDescription    = (string) sT[(byte)StatsColumns.statDescription];

                     EnumData enumData = new EnumData(stat, statName, statDescription);
                     myDict.Add(interactableTypeId, enumData);
                 }
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: CurrentStatTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> ElementalTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();

             foreach (DataRow dT in Instance!._dataTables.ElementalTypesDataTable.Rows)
             {
                 var damageTypeId = (byte)dT[(byte)DamageTypesColumns.damageTypeId];
                 var damageType = (string)dT[(byte)DamageTypesColumns.damageType];
                 var damageTypeName = (string)dT[(byte)DamageTypesColumns.damageTypeName];
                 
                 EnumData enumData = new EnumData(damageType, damageTypeName, "");
                 myDict.Add(damageTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: DamageTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> EntityTypes_GetList()
         {
             Dictionary<int, EnumData> entityTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow eT in Instance!._dataTables.EntityTypesDataTable.Rows)
             {
                 byte entityTypeId = (byte)eT[(byte)EntityTypesColumns.entityTypeId];
                 string entityType = (string)eT[(byte)EntityTypesColumns.entityType];
                 string entityTypeName = (string)eT[(byte)EntityTypesColumns.entityTypeName];
                 string description = (string)eT[(byte)EntityTypesColumns.description];
                 
                 EnumData enumData = new EnumData(entityType, entityTypeName, description);
                 entityTypes.Add(entityTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(entityTypes.Count == 0) Logger!.LogWarning($"ERROR: EntityTypes_GetList - 0 Results");
 #endif
             return entityTypes;
         }
         internal static Dictionary<int, EnumData> AnimalTypes_GetList()
         {
             Dictionary<int, EnumData> animalTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow aT in Instance!._dataTables.AnimalTypesDataTable.Rows)
             {
                 byte animalTypeId = (byte)aT[(byte)AnimalTypesColumns.animalTypeId];
                 string animalType = (string)aT[(byte)AnimalTypesColumns.animalType];
                 string animalTypeName = (string)aT[(byte)AnimalTypesColumns.animalTypeName];
                 string description = (string)aT[(byte)AnimalTypesColumns.description];
                 
                 EnumData enumData = new EnumData(animalType, animalTypeName, description);
                 animalTypes.Add(animalTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(animalTypes.Count == 0) Logger!.LogWarning($"ERROR: AnimalTypes_GetList - 0 Results");
 #endif
             return animalTypes;
         }
         
         internal static Dictionary<byte, SubEnumData> AnimalClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> animalSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow aST in Instance!._dataTables.AnimalClassificationTypesDataTable.Rows)
             {
                 byte animalClassificationTypeId = (byte)aST[(byte)AnimalClassificationTypesColumns.animalClassificationTypeId];
                 string animalClassificationType = (string)aST[(byte)AnimalClassificationTypesColumns.animalClassificationType];
                 string animalClassificationTypeName = (string)aST[(byte)AnimalClassificationTypesColumns.animalClassificationTypeName];
                 string description = (string)aST[(byte)AnimalClassificationTypesColumns.description];
                 byte animalTypeId = (byte)aST[(byte)AnimalClassificationTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(animalClassificationType, animalClassificationTypeName, description,animalTypeId);
                 animalSubTypes.Add(animalClassificationTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(animalSubTypes.Count == 0) Logger!.LogWarning($"ERROR: AnimalSubTypes_GetList - 0 Results");
 #endif
             return animalSubTypes;
         }
         internal static Dictionary<byte, SubEnumData> AnimalSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> animalSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow aST in Instance!._dataTables.AnimalSubTypesDataTable.Rows)
             {
                 byte animalSubTypeId = (byte)aST[(byte)AnimalSubTypesColumns.animalSubTypeId];
                 string animalSubType = (string)aST[(byte)AnimalSubTypesColumns.animalSubType];
                 string animalSubTypeName = (string)aST[(byte)AnimalSubTypesColumns.animalSubTypeName];
                 string description = (string)aST[(byte)AnimalSubTypesColumns.description];
                 byte animalTypeId = (byte)aST[(byte)AnimalSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(animalSubType, animalSubTypeName, description,animalTypeId);
                 animalSubTypes.Add(animalSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(animalSubTypes.Count == 0) Logger!.LogWarning($"ERROR: AnimalSubTypes_GetList - 0 Results");
 #endif
             return animalSubTypes;
         }
         
         internal static Dictionary<int, EnumData> EnemyHumanoidTypes_GetList()
         {
             Dictionary<int, EnumData> enemyHumanoidTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow eHT in Instance!._dataTables.EnemyHumanoidTypesDataTable.Rows)
             {
                 byte enemyHumanoidTypeId = (byte)eHT[(byte)EnemyHumanoidTypesColumns.enemyHumanoidTypeId];
                 string enemyHumanoidType = (string)eHT[(byte)EnemyHumanoidTypesColumns.enemyHumanoidType];
                 string enemyHumanoidTypeName = (string)eHT[(byte)EnemyHumanoidTypesColumns.enemyHumanoidTypeName];
                 string description = (string)eHT[(byte)EnemyHumanoidTypesColumns.description];

                 EnumData enumData = new EnumData(enemyHumanoidType, enemyHumanoidTypeName, description);
                 enemyHumanoidTypes.Add(enemyHumanoidTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(enemyHumanoidTypes.Count == 0) Logger!.LogWarning($"ERROR: EnemyHumanoidTypes_GetList - 0 Results");
 #endif
             return enemyHumanoidTypes;
         }
         
         internal static Dictionary<byte, SubEnumData> EnemyHumanoidClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> enemyHumanoidSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow eHST in Instance!._dataTables.EnemyHumanoidClassificationTypesDataTable.Rows)
             {
                 byte enemyHumanoidSubTypeId = (byte)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubTypeId];
                 string enemyHumanoidSubType = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubType];
                 string enemyHumanoidSubTypeName = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubTypeName];
                 string description = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.description];
                 byte enemyHumanoidTypeId = (byte)eHST[(byte)EnemyHumanoidSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(enemyHumanoidSubType, enemyHumanoidSubTypeName, description, enemyHumanoidTypeId);
                 enemyHumanoidSubTypes.Add(enemyHumanoidSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(enemyHumanoidSubTypes.Count == 0) Logger!.LogWarning($"ERROR: EnemyHumanoidSubTypes_GetList - 0 Results");
 #endif
             return enemyHumanoidSubTypes;
         }    
         internal static Dictionary<byte, SubEnumData> EnemyHumanoidSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> enemyHumanoidSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow eHST in Instance!._dataTables.EnemyHumanoidSubTypesDataTable.Rows)
             {
                 byte enemyHumanoidSubTypeId = (byte)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubTypeId];
                 string enemyHumanoidSubType = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubType];
                 string enemyHumanoidSubTypeName = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.enemyHumanoidSubTypeName];
                 string description = (string)eHST[(byte)EnemyHumanoidSubTypesColumns.description];
                 byte enemyHumanoidTypeId = (byte)eHST[(byte)EnemyHumanoidSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(enemyHumanoidSubType, enemyHumanoidSubTypeName, description, enemyHumanoidTypeId);
                 enemyHumanoidSubTypes.Add(enemyHumanoidSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(enemyHumanoidSubTypes.Count == 0) Logger!.LogWarning($"ERROR: EnemyHumanoidSubTypes_GetList - 0 Results");
 #endif
             return enemyHumanoidSubTypes;
         }
         
         internal static Dictionary<int, EnumData> MonsterTypes_GetList()
         {
             Dictionary<int, EnumData> monsterTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow mT in Instance!._dataTables.MonsterTypesDataTable.Rows)
             {
                 byte   monsterTypeId   = (byte)mT[(byte)MonsterTypesColumns.monsterTypeId];
                 string monsterType     = (string)mT[(byte)MonsterTypesColumns.monsterType];
                 string monsterTypeName = (string)mT[(byte)MonsterTypesColumns.monsterTypeName];
                 string description     = (string)mT[(byte)MonsterTypesColumns.description];
                 
                 EnumData enumData = new EnumData(monsterType, monsterTypeName, description);
                 monsterTypes.Add(monsterTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(monsterTypes.Count == 0) Logger!.LogWarning($"ERROR: MonsterTypes_GetList - 0 Results");
 #endif
             return monsterTypes;
         }
         
         internal static Dictionary<byte, SubEnumData> MonsterClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> monsterSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow mST in Instance!._dataTables.MonsterClassificationTypesDataTable.Rows)
             {
                 byte monsterSubTypeId = (byte)mST[(byte)MonsterSubTypesColumns.monsterSubTypeId];
                 string monsterSubType = (string)mST[(byte)MonsterSubTypesColumns.monsterSubType];
                 string monsterSubTypeName = (string)mST[(byte)MonsterSubTypesColumns.monsterSubTypeName];
                 string description = (string)mST[(byte)MonsterSubTypesColumns.description];
                 byte monsterTypeId = (byte)mST[(byte)MonsterSubTypesColumns.parentTypeId];
                 
                 SubEnumData enumData = new SubEnumData(monsterSubType, monsterSubTypeName, description, monsterTypeId);
                 monsterSubTypes.Add(monsterSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(monsterSubTypes.Count == 0) Logger!.LogWarning($"ERROR: MonsterSubTypes_GetList - 0 Results");
 #endif
             return monsterSubTypes;
         }
         internal static Dictionary<byte, SubEnumData> MonsterSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> monsterSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow mST in Instance!._dataTables.MonsterSubTypesDataTable.Rows)
             {
                 byte monsterSubTypeId = (byte)mST[(byte)MonsterSubTypesColumns.monsterSubTypeId];
                 string monsterSubType = (string)mST[(byte)MonsterSubTypesColumns.monsterSubType];
                 string monsterSubTypeName = (string)mST[(byte)MonsterSubTypesColumns.monsterSubTypeName];
                 string description = (string)mST[(byte)MonsterSubTypesColumns.description];
                 byte monsterTypeId = (byte)mST[(byte)MonsterSubTypesColumns.parentTypeId];
                 
                 SubEnumData enumData = new SubEnumData(monsterSubType, monsterSubTypeName, description, monsterTypeId);
                 monsterSubTypes.Add(monsterSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(monsterSubTypes.Count == 0) Logger!.LogWarning($"ERROR: MonsterSubTypes_GetList - 0 Results");
 #endif
             return monsterSubTypes;
         }
         
         internal static Dictionary<int, EnumData> EffectTypes_GetList()
         {
             Dictionary<int, EnumData> effectTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow cST in Instance!._dataTables.EffectTypesDataTable.Rows)
             {
                 byte effectTypeId = (byte)cST[(byte)EffectTypesColumns.effectTypeId];
                 string effectType = (string)cST[(byte)EffectTypesColumns.effectType];
                 string effectTypeName = (string)cST[(byte)EffectTypesColumns.effectTypeName];
                 string description = (string)cST[(byte)EffectTypesColumns.effectTypeDescription];
                 
                 EnumData enumData = new EnumData(effectType, effectTypeName, description);
                 effectTypes.Add(effectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(effectTypes.Count == 0) Logger!.LogWarning($"ERROR: EffectTypes_GetList - 0 Results");
 #endif
             return effectTypes;
         }
         
         internal static Dictionary<int, EnumData> CostTypes_GetList()
         {
             Dictionary<int, EnumData> costTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow eCT in Instance!._dataTables.CostTypesDataTable.Rows)
             {
                 byte costTypeId = (byte)eCT[(byte)CostTypesColumns.costTypeId];
                 string costType = (string)eCT[(byte)CostTypesColumns.costType];
                 string costTypeName = (string)eCT[(byte)CostTypesColumns.costTypeName];
                 string description = (string)eCT[(byte)CostTypesColumns.costTypeDescription];
                 
                 EnumData enumData = new EnumData(costType, costTypeName, description);
                 costTypes.Add(costTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(costTypes.Count == 0) Logger!.LogWarning($"ERROR: CostTypes_GetList - 0 Results");
 #endif
             return costTypes;
         }
         
         internal static Dictionary<int, EnumData> AbilityActivationTypes_GetList()
         {
             Dictionary<int, EnumData> effectActivationTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow eCT in Instance!._dataTables.AbilityActivationTypesDataTable.Rows)
             {
                 byte abilityActivationTypeId = (byte)eCT[(byte)AbilityActivationTypesColumns.abilityActivationTypeId];
                 string abilityActivationType = (string)eCT[(byte)AbilityActivationTypesColumns.abilityActivationType];
                 
                 EnumData enumData = new EnumData(abilityActivationType, "", "");
                 effectActivationTypes.Add(abilityActivationTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(effectActivationTypes.Count == 0) Logger!.LogWarning($"ERROR: AbilityActivationTypes_GetList - 0 Results");
 #endif
             return effectActivationTypes;
         }
         
         internal static Dictionary<byte, SubEnumData> ConsumableClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> consumableSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow cST in Instance!._dataTables.ConsumableClassificationTypesDataTable.Rows)
             {
                 byte consumableSubTypeId = (byte)cST[(byte)ConsumableSubTypesColumns.consumableSubTypeId];
                 string consumableSubType = (string)cST[(byte)ConsumableSubTypesColumns.consumableSubType];
                 string consumableSubTypeName = (string)cST[(byte)ConsumableSubTypesColumns.consumableSubTypeName];
                 string description = (string)cST[(byte)ConsumableSubTypesColumns.description];
                 byte consumableTypeId = (byte)cST[(byte)ConsumableSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(consumableSubType, consumableSubTypeName, description, consumableTypeId);
                 consumableSubTypes.Add(consumableSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(consumableSubTypes.Count == 0) Logger!.LogWarning($"ERROR: ConsumableSubTypes_GetList - 0 Results");
 #endif
             return consumableSubTypes;
         }
         internal static Dictionary<byte, SubEnumData> ConsumableSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> consumableSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow cST in Instance!._dataTables.ConsumableSubTypesDataTable.Rows)
             {
                 byte consumableSubTypeId = (byte)cST[(byte)ConsumableSubTypesColumns.consumableSubTypeId];
                 string consumableSubType = (string)cST[(byte)ConsumableSubTypesColumns.consumableSubType];
                 string consumableSubTypeName = (string)cST[(byte)ConsumableSubTypesColumns.consumableSubTypeName];
                 string description = (string)cST[(byte)ConsumableSubTypesColumns.description];
                 byte consumableTypeId = (byte)cST[(byte)ConsumableSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(consumableSubType, consumableSubTypeName, description, consumableTypeId);
                 consumableSubTypes.Add(consumableSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(consumableSubTypes.Count == 0) Logger!.LogWarning($"ERROR: ConsumableSubTypes_GetList - 0 Results");
 #endif
             return consumableSubTypes;
         }
         
         internal static Dictionary<byte, SubEnumData> MaterialClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> materialSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow mST in Instance!._dataTables.MaterialClassificationTypesDataTable.Rows)
             {
                 byte materialSubTypeId = (byte)mST[(byte)MaterialSubTypesColumns.materialSubTypeId];
                 string materialSubType = (string)mST[(byte)MaterialSubTypesColumns.materialSubType];
                 string materialSubTypeName = (string)mST[(byte)MaterialSubTypesColumns.materialSubTypeName];
                 string description = (string)mST[(byte)MaterialSubTypesColumns.description];
                 byte materialTypeId = (byte)mST[(byte)MaterialSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(materialSubType, materialSubTypeName, description, materialTypeId);
                 materialSubTypes.Add(materialSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(materialSubTypes.Count == 0) Logger!.LogWarning($"ERROR: MaterialSubTypes_GetList - 0 Results");
 #endif
             return materialSubTypes;
         } 
         internal static Dictionary<byte, SubEnumData> MaterialSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> materialSubTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow mST in Instance!._dataTables.MaterialSubTypesDataTable.Rows)
             {
                 byte materialSubTypeId = (byte)mST[(byte)MaterialSubTypesColumns.materialSubTypeId];
                 string materialSubType = (string)mST[(byte)MaterialSubTypesColumns.materialSubType];
                 string materialSubTypeName = (string)mST[(byte)MaterialSubTypesColumns.materialSubTypeName];
                 string description = (string)mST[(byte)MaterialSubTypesColumns.description];
                 byte materialTypeId = (byte)mST[(byte)MaterialSubTypesColumns.parentTypeId];

                 SubEnumData enumData = new SubEnumData(materialSubType, materialSubTypeName, description, materialTypeId);
                 materialSubTypes.Add(materialSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(materialSubTypes.Count == 0) Logger!.LogWarning($"ERROR: MaterialSubTypes_GetList - 0 Results");
 #endif
             return materialSubTypes;
         }
         
         internal static Dictionary<int, EnumData> GeneralItemTypes_GetList()
         {
             Dictionary<int, EnumData> generalItemTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow gIT in Instance!._dataTables.GeneralItemTypesDataTable.Rows)
             {
                 byte   generalItemTypeId   = (byte)gIT[(byte)GeneralItemTypesColumns.generalItemTypeId];
                 string generalItemType     = (string)gIT[(byte)GeneralItemTypesColumns.generalItemType];
                 string generalItemTypeName = (string)gIT[(byte)GeneralItemTypesColumns.generalItemTypeName];
                 string description         = (string)gIT[(byte)GeneralItemTypesColumns.description];
                 
                 EnumData enumData = new EnumData(generalItemType, generalItemTypeName, description);
                 generalItemTypes.Add(generalItemTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(generalItemTypes.Count == 0) Logger!.LogWarning($"ERROR: GeneralItemTypes_GetList - 0 Results");
 #endif
             return generalItemTypes;
         }
         internal static Dictionary<byte, SubEnumData> GeneralItemClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> generalItemTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow gIT in Instance!._dataTables.GeneralItemClassificationTypesDataTable.Rows)
             {
                 byte generalItemSubTypeId = (byte)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubTypeId];
                 string generalItemSubType = (string)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubType];
                 string generalItemSubTypeName = (string)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubTypeName];
                 string description = (string)gIT[(byte)GeneralItemSubTypesColumns.description];
                 byte generalItemTypeId = (byte)gIT[(byte)GeneralItemSubTypesColumns.parentTypeId];
   
                 SubEnumData enumData = new SubEnumData(generalItemSubType, generalItemSubTypeName, description, generalItemTypeId);
                 generalItemTypes.Add(generalItemSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(generalItemTypes.Count == 0) Logger!.LogWarning($"ERROR: GeneralItemTypes_GetList - 0 Results");
 #endif
             return generalItemTypes;
         }
         internal static Dictionary<byte, SubEnumData> GeneralItemSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> generalItemTypes = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow gIT in Instance!._dataTables.GeneralItemSubTypesDataTable.Rows)
             {
                 byte generalItemSubTypeId = (byte)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubTypeId];
                 string generalItemSubType = (string)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubType];
                 string generalItemSubTypeName = (string)gIT[(byte)GeneralItemSubTypesColumns.generalItemSubTypeName];
                 string description = (string)gIT[(byte)GeneralItemSubTypesColumns.description];
                 byte generalItemTypeId = (byte)gIT[(byte)GeneralItemSubTypesColumns.parentTypeId];
   
                 SubEnumData enumData = new SubEnumData(generalItemSubType, generalItemSubTypeName, description, generalItemTypeId);
                 generalItemTypes.Add(generalItemSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(generalItemTypes.Count == 0) Logger!.LogWarning($"ERROR: GeneralItemTypes_GetList - 0 Results");
 #endif
             return generalItemTypes;
         }
         internal static Dictionary<int, EnumData> ArmorSlotTypes_GetList()
         {
             Dictionary<int, EnumData> armorSlotTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow aST in Instance!._dataTables.ArmorSlotTypesDataTable.Rows)
             {
                 byte   armorSlotTypeId = (byte)aST[(byte)ArmorSlotTypesColumns.armorSlotTypeId];
                 string armorSlotType = (string)aST[(byte)ArmorSlotTypesColumns.armorSlotType];
                 string armorSlotTypeName = (string)aST[(byte)ArmorSlotTypesColumns.armorSlotTypeName];
                 
                 EnumData enumData = new EnumData(armorSlotType, armorSlotTypeName, "");
                 armorSlotTypes.Add(armorSlotTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(armorSlotTypes.Count == 0) Logger!.LogWarning($"ERROR: ArmorSlotTypes_GetList - 0 Results");
 #endif
             return armorSlotTypes;
         }

         internal static Dictionary<int, EnumData> AwardEffectTypes_GetList()
         {
             Dictionary<int, EnumData> awardEffectTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow aST in Instance!._dataTables.AwardEffectTypesDataTable.Rows)
             {
                 byte awardEffectTypeId = (byte)aST[(byte)AwardEffectTypesColumns.awardEffectTypeId];
                 string awardEffectType = (string)aST[(byte)AwardEffectTypesColumns.awardEffectType];
                 string awardEffectTypeName = (string)aST[(byte)AwardEffectTypesColumns.awardEffectTypeName];
                 string description = (string)aST[(byte)AwardEffectTypesColumns.description];
                 
                 EnumData enumData = new EnumData(awardEffectType, awardEffectTypeName, description);
                 awardEffectTypes.Add(awardEffectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(awardEffectTypes.Count == 0) Logger!.LogWarning($"ERROR: AwardEffectTypes_GetList - 0 Results");
 #endif
             return awardEffectTypes;
         }
         
         internal static Dictionary<int, EnumData> EquipmentTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow eT in Instance!._dataTables.EquipmentTypesDataTable.Rows)
             {
                 var equipmentTypeId = (byte)eT[(byte)EquipmentTypesColumns.equipmentTypeId];
                 var equipmentType = (string)eT[(byte)EquipmentTypesColumns.equipmentType];
                 var equipmentTypeName = (string)eT[(byte)EquipmentTypesColumns.equipmentTypeName];
                 var description = (string)eT[(byte)EquipmentTypesColumns.description];

                 EnumData enumData = new EnumData(equipmentType, equipmentTypeName, description);
                 myDict.Add(equipmentTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: EquipmentTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> EquipmentSlotTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow eT in Instance!._dataTables.EquipmentSlotTypesDataTable.Rows)
             {
                 var equipmentSlotTypeId = (byte)eT[(byte)EquipmentSlotTypesColumns.equipmentSlotTypeId];
                 var equipmentSlotType = (string)eT[(byte)EquipmentSlotTypesColumns.equipmentSlotType];

                 EnumData enumData = new EnumData(equipmentSlotType, equipmentSlotType, "");
                 myDict.Add(equipmentSlotTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: EquipmentSlotTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> ExperienceEffectTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow eEt in Instance!._dataTables.ExperienceEffectTypesDataTable.Rows)
             {
                 var experienceEffectTypeId = (byte)eEt[(byte)ExperienceEffectTypesColumns.experienceEffectTypeId];
                 var experienceEffectType = (string)eEt[(byte)ExperienceEffectTypesColumns.experienceEffectType];
                 var experienceEffectTypeName = (string)eEt[(byte)ExperienceEffectTypesColumns.experienceEffectTypeName];
                 var description = (string)eEt[(byte)ExperienceEffectTypesColumns.experienceEffectTypeDescription];
                 
                 EnumData enumData = new EnumData(experienceEffectType, experienceEffectTypeName, description);
                 myDict.Add(experienceEffectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ExperienceEffectTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> GatherableTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow gT in Instance!._dataTables.GatherableTypesDataTable.Rows)
             {
                 var gatherableTypeId = (byte)gT[(byte)GatherableTypesColumns.gatherableTypeId];
                 var gatherableType = (string)gT[(byte)GatherableTypesColumns.gatherableType];
                 var gatherableTypeName = (string)gT[(byte)GatherableTypesColumns.gatherableTypeName];
                 var description = (string)gT[(byte)GatherableTypesColumns.description];
                 
                 EnumData enumData = new EnumData(gatherableType, gatherableTypeName, description);
                 myDict.Add(gatherableTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GatherableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<byte, SubEnumData> GatherableClassificationTypes_GetList()
         {
             Dictionary<byte, SubEnumData> myDict = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow gT in Instance!._dataTables.GatherableClassificationTypesDataTable.Rows)
             {
                 var gatherableClassificationTypeId = (byte)gT[(byte)GatherableClassificationTypesColumns.gatherableClassificationTypeId];
                 var gatherableClassificationType = (string)gT[(byte)GatherableClassificationTypesColumns.gatherableClassificationType];
                 var gatherableClassificationTypeName = (string)gT[(byte)GatherableClassificationTypesColumns.gatherableClassificationTypeName];
                 var description = (string)gT[(byte)GatherableClassificationTypesColumns.description];
                 var gatherableTypeId = (byte)gT[(byte)GatherableClassificationTypesColumns.parentTypeId];
                 
                 SubEnumData enumData = new SubEnumData(gatherableClassificationType, gatherableClassificationTypeName, description, gatherableTypeId);
                 myDict.Add(gatherableClassificationTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GatherableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<byte, SubEnumData> GatherableSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> myDict = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow gT in Instance!._dataTables.GatherableSubTypesDataTable.Rows)
             {
                 var gatherableSubTypeId = (byte)gT[(byte)GatherableSubTypesColumns.gatherableSubTypeId];
                 var gatherableSubType = (string)gT[(byte)GatherableSubTypesColumns.gatherableSubType];
                 var gatherableSubTypeName = (string)gT[(byte)GatherableSubTypesColumns.gatherableSubTypeName];
                 var description = (string)gT[(byte)GatherableSubTypesColumns.description];
                 var gatherableTypeId = (byte)gT[(byte)GatherableSubTypesColumns.parentTypeId];
                 
                 SubEnumData enumData = new SubEnumData(gatherableSubType, gatherableSubTypeName, description, gatherableTypeId);
                 myDict.Add(gatherableSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GatherableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> GlobalStatuses_GetList()
         {
             Dictionary<int, EnumData> statuses = new Dictionary<int, EnumData>();
             
             foreach (DataRow gOt in Instance!._dataTables.GlobalStatusesDataTable.Select())
             {
                 var statusId = (byte)gOt[(byte)GlobalStatusesColumns.statusId];
                 var status = (string)gOt[(byte)GlobalStatusesColumns.status];
                 var statusName = (string)gOt[(byte)GlobalStatusesColumns.statusName];
                 var statusDescription = (string)gOt[(byte)GlobalStatusesColumns.statusDescription];

                 EnumData enumData = new EnumData(status, statusName, statusDescription);
                 statuses.Add(statusId, enumData);
             }
 #if UNITY_EDITOR
             if(statuses.Count == 0) Logger!.LogWarning($"ERROR: GlobalStatuses_GetList - 0 Results");
 #endif
             return statuses;
         }
         internal static Dictionary<int, EnumData> GlobalObjectTypes_GetList()
         {
             Dictionary<int, EnumData> globalObjectTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow gOT in Instance!._dataTables.GlobalObjectTypesDataTable.Rows)
             {
                 var objectTypeId = (byte)gOT[(byte)GlobalObjectTypesColumns.objectTypeId];
                 var objectType = (string)gOT[(byte)GlobalObjectTypesColumns.objectType];
                 var objectTypeName = (string)gOT[(byte)GlobalObjectTypesColumns.objectTypeName];
                 
                 EnumData enumData = new EnumData(objectType, objectTypeName, null!);
                 globalObjectTypes.Add(objectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(globalObjectTypes.Count == 0) Logger!.LogWarning($"ERROR: GlobalObjectTypes_GetList - 0 Results");
 #endif
             return globalObjectTypes;
         }
         internal static Dictionary<int, EnumData> ScriptableObjectTypes_GetList()
         {
             Dictionary<int, EnumData> scriptableObjectTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow sOT in Instance!._dataTables.ScriptableObjectTypesDataTable.Rows)
             {
                 var scriptableObjectTypeId = (byte)sOT[(byte)ScriptableObjectTypesColumns.scriptableObjectTypeId];
                 var scriptableObjectType = (string)sOT[(byte)ScriptableObjectTypesColumns.scriptableObjectType];
                 var scriptableObjectTypeName = (string)sOT[(byte)ScriptableObjectTypesColumns.scriptableObjectTypeName];

                 EnumData enumData = new EnumData(scriptableObjectType, scriptableObjectTypeName, null!);
                 scriptableObjectTypes.Add(scriptableObjectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(scriptableObjectTypes.Count == 0) Logger!.LogWarning($"ERROR: ScriptableObjectTypes_GetList - 0 Results");
 #endif
             return scriptableObjectTypes;
         }
         internal static Dictionary<int, EnumData> InteractableTypes_GetList()
         {
             Dictionary<int, EnumData> interactableTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow iT in Instance!._dataTables.InteractableTypesDataTable.Rows)
             {
                 var interactableTypeId = (byte)iT[(byte)InteractableTypesColumns.interactableTypeId];
                 var interactableType = (string)iT[(byte)InteractableTypesColumns.interactableType];
                 var interactableTypeName = (string)iT[(byte)InteractableTypesColumns.interactableTypeName];
                 var description = (string)iT[(byte)InteractableTypesColumns.interactableTypeDescription];

                 EnumData enumData = new EnumData(interactableType, interactableTypeName, description);
                 interactableTypes.Add(interactableTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(interactableTypes.Count == 0) Logger!.LogWarning($"ERROR: InteractableTypes_GetList - 0 Results");
 #endif
             return interactableTypes;
         }
         internal static Dictionary<int, EnumData> ItemTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow iT in Instance!._dataTables.ItemTypesDataTable.Rows)
             {
                 var itemTypeId = (byte)iT[(byte)ItemTypesColumns.itemTypeId];
                 var itemType = (string)iT[(byte)ItemTypesColumns.itemType];
                 var itemTypeName = (string)iT[(byte)ItemTypesColumns.itemTypeName];
                 var description = (string)iT[(byte)ItemTypesColumns.itemTypeDescription];
                 
                 EnumData enumData = new EnumData(itemType, itemTypeName, description);
                 myDict.Add(itemTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ItemTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> JeweleryTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow iT in Instance!._dataTables.JeweleryTypesDataTable.Rows)
             {
                 var jeweleryTypeId   = (byte)iT[(byte)JeweleryTypesColumns.jeweleryTypeId];
                 var jeweleryType     = (string)iT[(byte)JeweleryTypesColumns.jeweleryType];
                 var jeweleryTypeName = (string)iT[(byte)JeweleryTypesColumns.jeweleryTypeName];
                 var description      = (string)iT[(byte)JeweleryTypesColumns.description];
                 
                 EnumData enumData = new EnumData(jeweleryType, jeweleryTypeName, description);
                 myDict.Add(jeweleryTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: JeweleryTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> LootTableTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow lT in Instance!._dataTables.LootTableTypesDataTable.Rows)
             {
                 var lootTableTypeId = (byte)lT[(byte)LootTableTypesColumns.lootTableTypeId];
                 var lootTableType = (string)lT[(byte)LootTableTypesColumns.lootTableType];
                 var lootTableTypeName = (string)lT[(byte)LootTableTypesColumns.lootTableTypeName];
                 var description = (string)lT[(byte)LootTableTypesColumns.description];
                 
                 EnumData enumData = new EnumData(lootTableType, lootTableTypeName, description);
                 myDict.Add(lootTableTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: LootTableTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<byte, SubEnumData> LootTableSubTypes_GetList()
         {
             Dictionary<byte, SubEnumData> myDict = new Dictionary<byte, SubEnumData>();
             
             foreach (DataRow lSt in Instance!._dataTables.LootTableMainTypesDataTable.Rows)
             {
                 var lootTableSubTypeId = (byte)lSt[(byte)LootTableSubTypesColumns.lootTableSubTypeId];
                 var lootTableSubType = (string)lSt[(byte)LootTableSubTypesColumns.lootTableSubType];
                 var lootTableSubTypeName = (string)lSt[(byte)LootTableSubTypesColumns.lootTableSubTypeName];
                 var description = (string)lSt[(byte)LootTableSubTypesColumns.description];
                 var lootTableTypeId = (byte)lSt[(byte)LootTableSubTypesColumns.lootTableTypeId];

                 SubEnumData enumData = new SubEnumData(lootTableSubType, lootTableSubTypeName, description, lootTableTypeId);
                 myDict.Add(lootTableSubTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: LootTableSubTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> MaterialTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow mT in Instance!._dataTables.MaterialTypesDataTable.Rows)
             {
                 var materialTypeId = (byte)mT[(byte)MaterialTypesColumns.materialTypeId];
                 var materialType = (string)mT[(byte)MaterialTypesColumns.materialType];
                 var materialTypeName = (string)mT[(byte)MaterialTypesColumns.materialTypeName];
                 var description = (string)mT[(byte)MaterialTypesColumns.description];

                 EnumData enumData = new EnumData(materialType, materialTypeName, description);
                 myDict.Add(materialTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: MaterialTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> ModifierTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow mT in Instance!._dataTables.ModifierTypesDataTable.Rows)
             {
                 var materialModifierTypeId = (byte)mT[(byte)ModifierTypesColumns.materialModifierTypeId];
                 var materialModifierType = (string)mT[(byte)ModifierTypesColumns.materialModifierType];
                 var materialModifierTypeName = (string)mT[(byte)ModifierTypesColumns.materialModifierTypeName];
                 var description = (string)mT[(byte)ModifierTypesColumns.description];

                 EnumData enumData = new EnumData(materialModifierType, materialModifierTypeName, description);
                 myDict.Add(materialModifierTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ModifierTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> NpcTypes_GetList()
         {
             Dictionary<int, EnumData> entityTypes = new Dictionary<int, EnumData>();
             
             foreach (DataRow nT in Instance!._dataTables.NpcTypesDataTable.Rows)
             {
                 byte   npcTypeId   = (byte)nT[(byte)NpcTypesColumns.npcTypeId];
                 string npcType     = (string)nT[(byte)NpcTypesColumns.npcType];
                 string npcTypeName = (string)nT[(byte)NpcTypesColumns.npcTypeName];
                 string description = (string)nT[(byte)NpcTypesColumns.description];
               
                 EnumData enumData = new EnumData(npcType, npcTypeName, description);
                 entityTypes.Add(npcTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(entityTypes.Count == 0) Logger!.LogWarning($"ERROR: NpcTypes_GetList - 0 Results");
 #endif
             return entityTypes;
         }

         internal static Dictionary<int, EnumData> QualityTypes_GetList()
         {
             Dictionary<int, EnumData> qualities = new Dictionary<int, EnumData>();
             
             foreach (DataRow sR in Instance!._dataTables.ScriptableQualitiesDataTable.Select())
             {
                 var qualityId = (byte)sR[(byte)ScriptableQualitiesColumns.scriptableQualityId];
                 var quality = (string)sR[(byte)ScriptableQualitiesColumns.quality];
                 var qualityName = (string)sR[(byte)ScriptableQualitiesColumns.qualityName];
                 var description = (string)sR[(byte)ScriptableQualitiesColumns.description];
                 
                 EnumData enumData = new EnumData(quality, qualityName, description);
                 qualities.Add(qualityId, enumData);
             }
 #if UNITY_EDITOR
             if(qualities.Count == 0) Logger!.LogWarning($"ERROR: QualityTypes_GetList - 0 Results");
 #endif
             return qualities;
         }
         //QUESTS
         internal static Dictionary<int, EnumData> QuestCategoryTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow qCt in Instance!._dataTables.QuestCategoryTypesDataTable.Rows) 
             {
                 var questCategoryTypeId = (byte)qCt[(byte)QuestCategoryTypesColumns.questCategoryTypeId];
                 var questCategoryType = (string)qCt[(byte)QuestCategoryTypesColumns.questCategoryType];
                 var questCategoryTypeName = (string)qCt[(byte)QuestCategoryTypesColumns.questCategoryTypeName];
                 var description = (string)qCt[(byte)QuestCategoryTypesColumns.description];
                 
                 EnumData enumData = new EnumData(questCategoryType, questCategoryTypeName, description);
                 myDict.Add(questCategoryTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: QuestCategoryTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> QuestObjectiveTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow qOt in Instance!._dataTables.QuestObjectiveTypesDataTable.Rows)
             {
                 var questObjectiveTypeId = (byte)qOt[(byte)QuestObjectiveTypesColumns.questObjectiveTypeId];
                 var questObjectiveType = (string)qOt[(byte)QuestObjectiveTypesColumns.questObjectiveType];
                 var questObjectiveTypeName = (string)qOt[(byte)QuestObjectiveTypesColumns.questObjectiveTypeName];
                 var description = (string)qOt[(byte)QuestObjectiveTypesColumns.description];

                 EnumData enumData = new EnumData(questObjectiveType, questObjectiveTypeName, description);
                 myDict.Add(questObjectiveTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: QuestObjectiveTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> AdventuringQuestTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow aQt in Instance!._dataTables.AdventuringQuestTypesDataTable.Rows)
             {
                 var adventuringQuestTypeId = (byte)aQt[(byte)AdventuringQuestTypesColumns.adventuringQuestTypeId];
                 var adventuringQuestType = (string)aQt[(byte)AdventuringQuestTypesColumns.adventuringQuestType];
                 var adventuringQuestTypeName = (string)aQt[(byte)AdventuringQuestTypesColumns.adventuringQuestTypeName];
                 var description = (string)aQt[(byte)AdventuringQuestTypesColumns.description];
                 
                 EnumData enumData = new EnumData(adventuringQuestType, adventuringQuestTypeName, description);
                 myDict.Add(adventuringQuestTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AdventuringQuestTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> GatheringQuestTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow gQt in Instance!._dataTables.GatheringQuestTypesDataTable.Rows)
             {
                 var gatheringQuestTypeId = (byte)gQt[(byte)GatheringQuestTypesColumns.gatheringQuestTypeId];
                 var gatheringQuestType = (string)gQt[(byte)GatheringQuestTypesColumns.gatheringQuestType];
                 var gatheringQuestTypeName = (string)gQt[(byte)GatheringQuestTypesColumns.gatheringQuestTypeName];
                 var description = (string)gQt[(byte)GatheringQuestTypesColumns.description];
                 
                 EnumData enumData = new EnumData(gatheringQuestType, gatheringQuestTypeName, description);
                 myDict.Add(gatheringQuestTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GatheringQuestTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> RequirementTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow gQt in Instance!._dataTables.RequirementTypesDataTable.Rows)
             {
                 var requirementTypeId = (byte)gQt[(byte)RequirementTypesColumns.requirementTypeId];
                 var requirementType = (string)gQt[(byte)RequirementTypesColumns.requirementType];
                 var requirementTypeName = (string)gQt[(byte)RequirementTypesColumns.requirementTypeName];
                 var description = (string)gQt[(byte)RequirementTypesColumns.description];
                 
                 EnumData enumData = new EnumData(requirementType, requirementTypeName, description);
                 myDict.Add(requirementTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: RequirementTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> CraftingQuestTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             foreach (DataRow cQt in Instance!._dataTables.CraftingQuestTypesDataTable.Rows)
             {
                 var craftingQuestTypeId = (byte)cQt[(byte)CraftingQuestTypesColumns.craftingQuestTypeId];
                 var craftingQuestType = (string)cQt[(byte)CraftingQuestTypesColumns.craftingQuestType];
                 var craftingQuestTypeName = (string)cQt[(byte)CraftingQuestTypesColumns.craftingQuestTypeName];
                 var description = (string)cQt[(byte)CraftingQuestTypesColumns.description];
                 
                 EnumData enumData = new EnumData(craftingQuestType, craftingQuestTypeName, description);
                 myDict.Add(craftingQuestTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: CraftingQuestTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         //RARITY
         internal static Dictionary<int, EnumData> RarityTypes_GetList()
         {
             Dictionary<int, EnumData> rarities = new Dictionary<int, EnumData>();
             foreach (DataRow sR in Instance!._dataTables.ScriptableRaritiesDataTable.Select())
             {
                 var rarityTypeId = (byte)sR[ScriptableRaritiesColumns.scriptableRarityId.ToString()];
                 var rarity = (string)sR[ScriptableRaritiesColumns.rarity.ToString()];
                 var rarityName = (string)sR[ScriptableRaritiesColumns.rarityName.ToString()];
                 var rarityDescription = (string)sR[ScriptableRaritiesColumns.description.ToString()];
                 
                 EnumData rarityData = new EnumData(rarity, rarityName, rarityDescription);
                 rarities.Add(rarityTypeId, rarityData);
             }
 #if UNITY_EDITOR
             if(rarities.Count == 0) Logger!.LogWarning($"ERROR: RarityTypes_GetList - 0 Results");
 #endif
             return rarities;
         }

         internal static Dictionary<int, EnumData> BaseStatTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatBaseTypesDataTable.Rows)
             {
                 var statId = (byte) sT[(byte)StatBaseTypesColumns.statBaseTypeId];
                 var stat = (string) sT[(byte)StatBaseTypesColumns.statBaseType];
                 var statName = (string) sT[(byte)StatBaseTypesColumns.statBaseTypeName];
                 var statDescription = (string) sT[(byte)StatBaseTypesColumns.description];
                 
                 EnumData enumData = new EnumData(stat, statName, statDescription);
                 myDict.Add(statId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: BaseStatTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> StatMultiplierTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatMultiplierTypesDataTable.Rows)
             {
                 var statId = (byte) sT[(byte)StatMultiplierTypesColumns.statMultiplierTypeId];
                 var stat = (string) sT[(byte)StatMultiplierTypesColumns.statMultiplierType];
                 var statName = (string) sT[(byte)StatMultiplierTypesColumns.statMultiplierTypeName];
                 var statDescription = (string) sT[(byte)StatMultiplierTypesColumns.description];
                 
                 EnumData enumData = new EnumData(stat, statName, statDescription);
                 myDict.Add(statId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: StatMultiplierTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> BodyPartTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.BodyPartTypesDataTable.Rows)
             {
                 var bodyPartTypeId = (byte)sT[(byte)BodyPartTypesColumns.bodyPartTypeId];
                 var bodyPartType       = (string)sT[(byte)BodyPartTypesColumns.bodyPartType];
                 
                 EnumData rarityData = new EnumData(bodyPartType, null, null);
                 myDict.Add(bodyPartTypeId, rarityData);
             }
#if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: StatTypes_GetList - 0 Results");
#endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> StatTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.StatTypesDataTable.Rows)
             {
                 var statTypeId = (byte)sT[(byte)StatTypesColumns.statTypeId];  
                 var statType = (string)sT[(byte)StatTypesColumns.statType];
                 var statTypeName = (string)sT[(byte)StatTypesColumns.statTypeName];
                 var description = (string)sT[(byte)StatTypesColumns.statTypeDescription];
                 
                 EnumData rarityData = new EnumData(statType, statTypeName, description);
                 myDict.Add(statTypeId, rarityData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: StatTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> SkillTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow sT in Instance!._dataTables.SkillTypesDataTable.Rows)
             {
                 var skillTypeId = (byte)sT[(byte)SkillTypesColumns.skillTypeId];
                 var skillType = (string)sT[(byte)SkillTypesColumns.skillType];
                 var skillTypeName = (string)sT[(byte)SkillTypesColumns.skillTypeName];
                 var description = (string)sT[(byte)SkillTypesColumns.skillTypeDescription];

                 EnumData enumData = new EnumData(skillType, skillTypeName, description);
                 myDict.Add(skillTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: SkillTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> UnlockEffectTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow uEt in Instance!._dataTables.UnlockEffectTypesDataTable.Rows)
             {
                 var unlockEffectTypeId   = (byte)uEt[(byte)UnlockEffectTypesColumns.unlockEffectTypeId];
                 var unlockEffectType     = (string)uEt[(byte)UnlockEffectTypesColumns.unlockEffectType];
                 var unlockEffectTypeName = (string)uEt[(byte)UnlockEffectTypesColumns.unlockEffectTypeName];
                 var description          = (string)uEt[(byte)UnlockEffectTypesColumns.description];
                 
                 EnumData enumData = new EnumData(unlockEffectType, unlockEffectTypeName, description);
                 myDict.Add(unlockEffectTypeId, enumData);

             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: UnlockEffectTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> EffectAmountTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow eT in Instance!._dataTables.EffectAmountTypesDataTable.Rows)
             {
                 var effectTypeId   = (byte)eT[(byte)EffectTypesColumns.effectTypeId];
                 var effectType     = (string)eT[(byte)EffectTypesColumns.effectType];
                 var effectTypeName = (string)eT[(byte)EffectTypesColumns.effectTypeName];
                 var description    = (string)eT[(byte)EffectTypesColumns.effectTypeDescription];

                 EnumData enumData = new EnumData(effectType, effectTypeName, description);
                 myDict.Add(effectTypeId, enumData);
             }
#if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: UseEffectTypes_GetList - 0 Results");
#endif
             return myDict;
         }
         internal static Dictionary<int, EnumData> UseEffectTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow eT in Instance!._dataTables.EffectTypesDataTable.Rows)
             {
                 var effectTypeId   = (byte)eT[(byte)EffectTypesColumns.effectTypeId];
                 var effectType     = (string)eT[(byte)EffectTypesColumns.effectType];
                 var effectTypeName = (string)eT[(byte)EffectTypesColumns.effectTypeName];
                 var description    = (string)eT[(byte)EffectTypesColumns.effectTypeDescription];

                 EnumData enumData = new EnumData(effectType, effectTypeName, description);
                 myDict.Add(effectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: UseEffectTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         //WEAPONS
         internal static Dictionary<int, EnumData> WeaponSlotTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow wS in Instance!._dataTables.WeaponSlotTypesDataTable.Rows)
             {
                 var weaponSlotId   = (byte)wS[(byte)WeaponSlotTypesColumns.weaponSlotId];
                 var weaponSlot     = (string)wS[(byte)WeaponSlotTypesColumns.weaponSlotType];
                 var weaponSlotName = (string)wS[(byte)WeaponSlotTypesColumns.weaponSlotTypeName];
                 var description    = (string)wS[(byte)WeaponSlotTypesColumns.description];

                 EnumData enumData = new EnumData(weaponSlot, weaponSlotName, description);
                 myDict.Add(weaponSlotId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: WeaponSlotTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         internal static Dictionary<int, EnumData> WeaponTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow wT in Instance!._dataTables.WeaponTypesDataTable.Rows)
             {
                 var weaponTypeId   = (byte)wT[(byte)WeaponTypesColumns.weaponTypeId];
                 var weaponType     = (string)wT[(byte)WeaponTypesColumns.weaponType];
                 var weaponTypeName = (string)wT[(byte)WeaponTypesColumns.weaponTypeName];

                 EnumData enumData = new EnumData(weaponType, weaponTypeName, "");
                 myDict.Add(weaponTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: WeaponTypes_GetList - 0 Results");
 #endif
             return myDict;
         }
         
         internal static Dictionary<int, EnumData> WorldObjectTypes_GetList()
         {
             Dictionary<int, EnumData> myDict = new Dictionary<int, EnumData>();
             
             foreach (DataRow wOt in Instance!._dataTables.WorldObjectTypesDataTable.Rows)
             {
                 var worldObjectTypeId = (byte)wOt[(byte)WorldObjectTypesColumns.worldObjectTypeId];
                 var worldObjectType = (string)wOt[(byte)WorldObjectTypesColumns.worldObjectType];
                 var worldObjectTypeName = (string)wOt[(byte)WorldObjectTypesColumns.worldObjectTypeName];
                 var description = (string)wOt[(byte)WorldObjectTypesColumns.description];

                 EnumData enumData = new EnumData(worldObjectType, worldObjectTypeName, description);
                 myDict.Add(worldObjectTypeId, enumData);
             }
 #if UNITY_EDITOR
             if(myDict.Count == 0) Logger!.LogWarning($"ERROR: WorldObjectTypes_GetList - 0 Results");
 #endif
             return myDict;
         }

         #endregion
         
        
         #region DATA TABLE STP GETS: CHARACTERS
         public static PlayerAccountRequestResponse PlayerAccount_GetPassword(string userName, string password)
         {
             int accountId = -1;
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool admin = false;
             if (!Instance!._dataTables.PlayersAccountsDictionaryByUserName.ContainsKey(userName.ToLower())) return new PlayerAccountRequestResponse()
             {
                 success      = false,
                 errorMessage = "Invalid username",
                 admin        = null,
                 accountId    = null
             };
             var pA = Instance._dataTables.PlayersAccountsDictionaryByUserName[userName.ToLower()];
             if ((string)pA[(byte)PlayersAccountsColumns.password] != password) return new PlayerAccountRequestResponse()
             {
                 success      = false,
                 errorMessage = "Invalid Password",
                 admin        = null,
                 accountId    = null
             };
             accountId = (int) (pA[(byte)PlayersAccountsColumns.playerAccountId]);
             admin     = (bool) (pA[(byte)PlayersAccountsColumns.admin]);
             
             Logger!.LogProfiling($"DataTableStoredProcs.PlayerAccount_GetPassword took {watch!.ElapsedTicks/10000f} ms");

             return new PlayerAccountRequestResponse()
             {
                 success      = true,
                 errorMessage = null,
                 admin        = admin,
                 accountId    = accountId
             };
         }

         public static Dictionary<string, int> Character_GetAll()
         {
             Dictionary<string, int> characters = new Dictionary<string, int>();
             
             foreach (DataRow cH in Instance!._dataTables.CharactersDataTable.Select()) 
             {
                 if(cH[(byte)CharactersColumns.status].ToString() == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;

                 var characterId   = (int)cH[(byte)CharactersColumns.characterId];
                 var characterName = (string)cH[(byte)CharactersColumns.characterName];
                 
                 characters.Add(characterName, characterId);
             }
             return characters;
         }

         public static CharacterModel[] Character_GetList(int playerAccountId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             CharacterModel[] charactersList = new CharacterModel[MaxCharacters!.Value];
             int index = 0;
             foreach (DataRow cH in Instance!._dataTables.CharactersDataTable.Select()) 
             {
                 if((string)cH[(byte)CharactersColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if((int) cH[(byte)CharactersColumns.playerAccountId] != playerAccountId) continue;
                 
                 var spawnedWorldObjectId = (Guid)cH[(byte)CharactersColumns.spawnedWorldObjectId];
                 var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                 var cC = Instance._dataTables.SpawnedWorldObjectsCurrencyDictionary[spawnedWorldObjectId];
                 int characterId = (int)cH[(byte)CharactersColumns.characterId];
                 string characterName = (string)cH[(byte)CharactersColumns.characterName];
                 
                 (float x, float y, float z) position = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateX], 
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ]);
                 (float x, float y, float z) rotation = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ]);
                 
                 (float x, float y, float z) scale = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ]);
                 int     chunk         = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                 
                 (float x, float y, float z) spawnLocation = (
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateX],
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateY], 
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateZ]);
                 
                 var experience = (int)cH[(byte)CharactersColumns.characterExperience];
                 var rank = (byte)cH[(byte)CharactersColumns.characterTierId];
                 var level = (byte)cH[(byte)CharactersColumns.characterRankId];
                 
                 var race       = (byte)cH[(byte)CharactersColumns.race];
                 var gender     = (byte)cH[(byte)CharactersColumns.gender];
                 var face       = (byte)cH[(byte)CharactersColumns.face];
                 var eyebrows   = (byte)cH[(byte)CharactersColumns.eyebrows];
                 var hair       = (byte)cH[(byte)CharactersColumns.hair];
                 var facialHair = (byte)cH[(byte)CharactersColumns.facialHair];
                 
                 HexColorModel skinColor    = (string)cH[(byte)CharactersColumns.skinColor];
                 HexColorModel eyeColor     = (string)cH[(byte)CharactersColumns.eyeColor];
                 HexColorModel hairColor    = (string)cH[(byte)CharactersColumns.hairColor];
                 HexColorModel stubbleColor = (string)cH[(byte)CharactersColumns.stubbleColor];
                
                 var gold              = (uint)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Gold];
                 var silver            = (byte)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Silver];
                 var copper            = (byte)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Copper];
                 var adventuringTokens = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_adventuring];
                 var craftingTokens    = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_crafting];
                 var gatheringTokens   = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_gathering];
                 
                 CharacterModel characterData = new CharacterModel(characterId, spawnedWorldObjectId, characterName, position, 
                     rotation, scale, chunk, spawnLocation, experience, rank, level, race, gender, face, eyebrows, hair, facialHair, skinColor, eyeColor, 
                     hairColor, stubbleColor, gold, silver, copper, adventuringTokens, craftingTokens, gatheringTokens);
                 
                 charactersList[index] = characterData;
                 index++;
             }
             var characters                                           = charactersList.ToList();
             for (; index < MaxCharacters; index++) characters[index] = default!;
             characters.Sort((data, characterData) => (data?.CharacterId ?? 0).CompareTo(characterData?.CharacterId ?? 0));
             var array = charactersList.ToArray();

             Logger!.LogProfiling($"DataTableStoredProcs.Character_GetList took {watch!.ElapsedTicks/10000f} ms");
             return array;
         }

         public static CharacterModel Character_GetInfo(int characterId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             CharacterModel characterData;
             try
             {
                 var cH                   = Instance!._dataTables.CharactersDictionaryByCharacterId[characterId];
                 var spawnedWorldObjectId = (Guid)cH[(byte)CharactersColumns.spawnedWorldObjectId];
                 var sWo                  = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                 var cC                   = Instance._dataTables.SpawnedWorldObjectsCurrencyDictionary[spawnedWorldObjectId];
                  
                 string characterName = (string)cH[(byte)CharactersColumns.characterName];
                 //var characterFactionId = (byte)cH[(byte)CharactersColumns.characterFactionId];
                 
                 (float x, float y, float z) position = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateX], 
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY], 
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ]);
                 (float x, float y, float z) rotation = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ]);
                 
                 (float x, float y, float z) scale = (
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY],
                     (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ]);
                 
                 var chunk = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];

                 (float x, float y, float z) spawnLocation = (
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateX],
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateY], 
                     (float)(decimal)cH[(byte)CharactersColumns.spawnCoordinateZ]);

                 var characterExperience = (int)cH[(byte)CharactersColumns.characterExperience];
                 var rank                = (byte)cH[(byte)CharactersColumns.characterTierId];
                 var level               = (byte)cH[(byte)CharactersColumns.characterRankId];

                 var race                = (byte)cH[(byte)CharactersColumns.race];
                 var gender              = (byte)cH[(byte)CharactersColumns.gender];
                 var face                = (byte)cH[(byte)CharactersColumns.face];
                 var eyebrows            = (byte)cH[(byte)CharactersColumns.eyebrows];
                 var hair                = (byte)cH[(byte)CharactersColumns.hair];
                 var facialHair          = (byte)cH[(byte)CharactersColumns.facialHair];

                 HexColorModel skinColor    = (string)cH[(byte)CharactersColumns.skinColor];
                 HexColorModel eyeColor     = (string)cH[(byte)CharactersColumns.eyeColor];
                 HexColorModel hairColor    = (string)cH[(byte)CharactersColumns.hairColor];
                 HexColorModel stubbleColor = (string)cH[(byte)CharactersColumns.stubbleColor];
                 
                 var gold = (uint)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Gold];
                 var silver = (byte)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Silver];
                 var copper = (byte)cC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Copper];
                 var adventuringTokens = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_adventuring];
                 var craftingTokens = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_crafting];
                 var gatheringTokens = (ushort)(int)cC[(byte)SpawnedWorldObjectsCurrencyColumns.token_gathering];
                 
                 characterData = new CharacterModel(characterId, spawnedWorldObjectId, characterName, position, rotation, scale, 
                     chunk, spawnLocation, characterExperience, rank, level, race, gender, face, eyebrows, hair, facialHair, 
                     skinColor, eyeColor, hairColor, stubbleColor, gold, silver, copper, adventuringTokens, craftingTokens, 
                     gatheringTokens);  
             }
             catch (Exception e)
             {
                 characterData = default!;
                 Logger!.LogError($"SQL EXCEPTION (Character_GetInfo): {e.Message} - Params: CharacterId: {characterId}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_GetInfo took {watch!.ElapsedTicks/10000f} ms"); 
           

             return characterData;
         }

         public static Dictionary<string, int> Character_AbilitiesGetList(int characterId)
         {
             Dictionary<string, int> myDict = new Dictionary<string, int>();
             
             foreach (DataRow cA in Instance!._dataTables.CharactersAbilitiesDataTable.Select())
             {
                 if (characterId == (int) (cA[(byte)CharactersAbilitiesColumns.characterId]))
                 {
                     myDict.Add((string)cA[(byte)CharactersAbilitiesColumns.globalObject], 
                         (int)cA[(byte)CharactersAbilitiesColumns.characterAbilityExperience]);
                 }
             }
             return myDict;
         }

         public static Dictionary<byte, Dictionary<byte, byte>> Character_AttributePointsGetAll()
         {
             Dictionary<byte, Dictionary<byte, byte>> myDict = new Dictionary<byte, Dictionary<byte, byte>>();
             
             foreach (DataRow aT in Instance!._dataTables.AttributePointsDataTable.Rows)
             {

                 var tierId               = (byte)aT[(byte)AttributePointsColumns.tierId];
                 var rankId               = (byte)aT[(byte)AttributePointsColumns.rankId];
                 var attributePointsValue = (byte)aT[(byte)AttributePointsColumns.attributePointsValue];

                 if (!myDict.ContainsKey(tierId)) myDict.Add(tierId, new Dictionary<byte, byte>());
                 myDict[tierId].Add(rankId, attributePointsValue);
             }
             return myDict;
         }

         public static CharacterBagModel[] Character_BagsGetList(Guid spawnedWorldObjectId)
         {
             CharacterBagModel[] characterBags = new CharacterBagModel[MaxBags!.Value];
             
             foreach (DataRow cB in Instance!._dataTables.SpawnedWorldObjectsBagsDataTable.Select())
             {
                 if((Guid)cB[(byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId] != spawnedWorldObjectId) continue;
                 if(cB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] == DBNull.Value) continue;

                 var instancedItemId = (Guid)(cB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId]);
                 //var iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 var slotIndex       = (byte)cB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];
                 
                 var characterBagId = (int)cB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 var characterBag   = new CharacterBagModel(instancedItemId, characterBagId);

                 characterBags[slotIndex] = characterBag;

             }
             return characterBags;
         }

         public static List<CharacterBagsData> Character_BagsGetAll()
         {
             List<CharacterBagsData> allBagData = new List<CharacterBagsData>();
             
             foreach (DataRow sWOB in Instance!._dataTables.SpawnedWorldObjectsBagsDataTable.Select())
             {
                 if(sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] == DBNull.Value) continue;
                 
                 var instancedItemId = (Guid)(sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId]);
                 var spawnedWorldObjectId = (Guid)(sWOB[(byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId]);
                 //var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 var slotIndex = (byte)sWOB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                 var characterBagId  = (int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 var characterBag = new CharacterBagModel(instancedItemId, characterBagId);
                 
                 var index = allBagData.FindIndex((t) => t.CharacterId == spawnedWorldObjectId);
                 if (index == -1)
                 {
                     allBagData.Add(new CharacterBagsData()
                     {
                         CharacterId = spawnedWorldObjectId, 
                         CharacterBags = new CharacterBagModel[MaxBags!.Value]    
                     });
                     index = allBagData.Count - 1;
                 }
                 allBagData[index].CharacterBags[slotIndex] = characterBag;
             }
             return allBagData;
         }

         public static List<BuybackModel> Character_BuybacksGetList(int characterId)
         {
             List<BuybackModel> myDict = new List<BuybackModel>();
             
             foreach (DataRow cB in Instance!._dataTables.CharactersBuyBacksDataTable.Select())
             {
                 if (characterId == (int) (cB[(byte)CharactersBuybacksColumns.characterId]))
                 {
                     var       itemId          = cB[(byte)CharactersBuybacksColumns.instancedItemId];
                     var       date            = cB[(byte)CharactersBuybacksColumns.soldDate];
                     
                     Guid?     instancedItemId = itemId == DBNull.Value ? null : (Guid?) itemId;
                     DateTime? soldDate        = date   == DBNull.Value ? null : (DateTime?) date;
                     
                     if(!instancedItemId.HasValue) continue;
                     
                     var   iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId.Value];

                     var itemTypeId = (byte)iI[(byte)InstancedItemsColumns.itemTypeId];
                     myDict.Add(new BuybackModel(instancedItemId.Value, soldDate, itemTypeId));
                 }
             }
             return myDict;
         }
        
         public static List<CharacterEquipmentData> Character_EquipmentGetAll()
         {
             List <CharacterEquipmentData> armorData = new List<CharacterEquipmentData>();
             
             foreach (var spawnedWorldObjectId in Instance!._dataTables.SpawnedWorldObjectsEquipmentDictionary)
             {
                 var characterEquipmentData = new CharacterEquipmentData()
                 {
                     CharacterId = spawnedWorldObjectId.Key,
                     Equipment   = new (EquipmentTypes equipmentType, Guid instanceItemId)[(byte)EquipmentSlotTypes.MAX_VALUE]
                 };

                 foreach (DataRow sWoe in spawnedWorldObjectId.Value)
                 {
                     if(sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] == DBNull.Value) continue;
                     var instancedItemId = (Guid) (sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId]);
                     
                     var equipmentType = (EquipmentTypes) Instance._dataTables.InstancedEquipmentDictionary[instancedItemId][(byte)InstancedEquipmentColumns.equipmentTypeId];
                     
                     var slotIndex = (byte) sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId];
                     
                     characterEquipmentData.Equipment[slotIndex] = (equipmentType, instancedItemId);
                 }

                 armorData.Add(characterEquipmentData);
             }
             
             return armorData;
         }

         public static CharacterEquipmentData Character_EquipmentGetList(Guid spawnedWorldObjectId)
         {
             CharacterEquipmentData armorData = new CharacterEquipmentData(){
                 CharacterId = spawnedWorldObjectId,
                 Equipment   = new (EquipmentTypes equipmentType, Guid instanceItemId)[(byte)EquipmentSlotTypes.MAX_VALUE]
             };

             if (!Instance!._dataTables.SpawnedWorldObjectsEquipmentDictionary.ContainsKey(spawnedWorldObjectId)) return armorData;
             foreach (DataRow sWoe in Instance._dataTables.SpawnedWorldObjectsEquipmentDictionary[spawnedWorldObjectId])
             {
                 if(sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] == DBNull.Value) continue;
                 var instancedItemId = (Guid) (sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId]);
                 
                 var equipmentType = (EquipmentTypes) Instance._dataTables.InstancedEquipmentDictionary[instancedItemId][(byte)InstancedEquipmentColumns.equipmentTypeId];
                 
                 var slotIndex = (byte) sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId];
                 armorData.Equipment[slotIndex] = (equipmentType, instancedItemId);
             }
             return armorData;
         }
         
         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryArmorGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> armorData = 
                 new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();
             
             foreach (DataRow iA in Instance!._dataTables.InstancedArmorDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iA[(byte)InstancedArmorColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 
                 var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                 var characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                 //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                 
                 var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                 Guid spawnedWorldObjectId = (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId];
                 var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                 if (!armorData.ContainsKey(spawnedWorldObjectId))
                     armorData.Add(spawnedWorldObjectId, new Dictionary<byte, Dictionary<byte, Guid>>());
                 if (!armorData[spawnedWorldObjectId].ContainsKey(bagIndex))
                     armorData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                 armorData[spawnedWorldObjectId][bagIndex]
                     .Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
             }
             return armorData;
         }
         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryArmorGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<byte, Dictionary<byte, Guid>> armorData = new Dictionary<byte, Dictionary<byte, Guid>>();
             
             foreach (DataRow iA in Instance!._dataTables.InstancedArmorDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iA[(byte)InstancedArmorColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     var characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                     var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                     var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                     if (!armorData.ContainsKey(bagIndex)) armorData.Add(bagIndex, new Dictionary<byte, Guid>());
                     armorData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                 }
             }
             return armorData;
         }

         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryBagsGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> bagData = new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();
             
             foreach (DataRow iB in Instance!._dataTables.InstancedBagsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iB[(byte)InstancedBagsColumns.instancedItemId]);
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                 int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                 //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                 var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                 
                 var  bagIndex             = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];
                 Guid spawnedWorldObjectId = (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId]);
                 if (!bagData.ContainsKey(spawnedWorldObjectId))
                     bagData.Add(spawnedWorldObjectId,
                         new Dictionary<byte, Dictionary<byte, Guid>>());
                 if (!bagData[spawnedWorldObjectId].ContainsKey(bagIndex))
                     bagData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                 bagData[spawnedWorldObjectId][bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
             }
             return bagData;
         }

         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryBagsGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<byte, Dictionary<byte, Guid>> bagData = new Dictionary<byte, Dictionary<byte, Guid>>();
             
             foreach (DataRow iB in Instance!._dataTables.InstancedBagsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iB[(byte)InstancedBagsColumns.instancedItemId]);
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                     var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                     var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                     if (!bagData.ContainsKey(bagIndex)) bagData.Add(bagIndex, new Dictionary<byte, Guid>());
                     bagData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                 }
             }
             
             return bagData;
         }

         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryConsumablesGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> consumableData = new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();
             
             foreach (DataRow iC in Instance!._dataTables.InstancedConsumablesDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iC[(byte)InstancedConsumablesColumns.instancedItemId]);
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                 int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                 //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                 var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];

                 var  bagIndex             = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];
                 Guid spawnedWorldObjectId = (Guid) (iI[(byte)InstancedItemsColumns.spawnedWorldObjectId]);
                 if (!consumableData.ContainsKey(spawnedWorldObjectId))
                     consumableData.Add(spawnedWorldObjectId, new Dictionary<byte, Dictionary<byte, Guid>>());
                 if (!consumableData[spawnedWorldObjectId].ContainsKey(bagIndex))
                     consumableData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                 consumableData[spawnedWorldObjectId][bagIndex]
                     .Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
             }
             return consumableData;
         }

         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryConsumablesGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<byte, Dictionary<byte, Guid>> consumableData = new Dictionary<byte, Dictionary<byte, Guid>>();
             
             foreach (DataRow iC in Instance!._dataTables.InstancedConsumablesDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iC[(byte)InstancedConsumablesColumns.instancedItemId]);
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                     var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                     var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                     if (!consumableData.ContainsKey(bagIndex))
                         consumableData.Add(bagIndex, new Dictionary<byte, Guid>());
                     consumableData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                 }                
             }
             
             return consumableData;
         }

         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryGeneralItemsGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> generalItemsData = new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();
             
             
             foreach (DataRow iG in Instance!._dataTables.InstancedGeneralItemsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iG[(byte)InstancedGeneralItemsColumns.instancedItemId]);
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;

                 if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                 int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                 //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                 var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];

                 var  bagIndex             = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];
                 Guid spawnedWorldObjectId = (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId]);
                 if (!generalItemsData.ContainsKey(spawnedWorldObjectId))
                     generalItemsData.Add(spawnedWorldObjectId, new Dictionary<byte, Dictionary<byte, Guid>>());
                 if (!generalItemsData[spawnedWorldObjectId].ContainsKey(bagIndex))
                     generalItemsData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                 generalItemsData[spawnedWorldObjectId][bagIndex]
                     .Add((byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId], instancedItemId);
             }
             
             return generalItemsData;
         }

         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryGeneralItemsGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<byte, Dictionary<byte, Guid>> generalItemsData = new Dictionary<byte, Dictionary<byte, Guid>>();
             foreach (DataRow iG in Instance!._dataTables.InstancedGeneralItemsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iG[(byte)InstancedGeneralItemsColumns.instancedItemId]);
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;
   
                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                     var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                     var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                     if (!generalItemsData.ContainsKey(bagIndex))
                         generalItemsData.Add(bagIndex, new Dictionary<byte, Guid>());
                     generalItemsData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                 }                
             }
             return generalItemsData;
         }

         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryMaterialsGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> materialData = new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();
             
             foreach (DataRow iM in Instance!._dataTables.InstancedMaterialsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iM[(byte)InstancedMaterialsColumns.instancedItemId]);
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status]       == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] == DBNull.Value) continue;
                 
                 if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                 int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                 //if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                 var  sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                 var  bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];
                 Guid spawnedWorldObjectId = (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId]);
                 if (!materialData.ContainsKey(spawnedWorldObjectId))
                     materialData.Add(spawnedWorldObjectId, new Dictionary<byte, Dictionary<byte, Guid>>());
                 if (!materialData[spawnedWorldObjectId].ContainsKey(bagIndex))
                     materialData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                 materialData[spawnedWorldObjectId][bagIndex]
                     .Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
             }
             
             return materialData;
         }

         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryMaterialsGetList(Guid spawnedWorldObjectId)
         {
             //Logger.LogDebug($"Character_InventoryMaterialsGetList: {spawnedWorldObjectId}");
             Dictionary<byte, Dictionary<byte, Guid>> materialData = new Dictionary<byte, Dictionary<byte, Guid>>();

             ////var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             foreach (DataRow iM in Instance!._dataTables.InstancedMaterialsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)(iM[(byte)InstancedMaterialsColumns.instancedItemId]);
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (!Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     int characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     if (!Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId)) continue;
                     var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                     var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                     if (!materialData.ContainsKey(bagIndex))
                         materialData.Add(bagIndex, new Dictionary<byte, Guid>());
                     materialData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                 }
             }
             //Logger.LogDebug($"Character_InventoryMaterialsGetList: {spawnedWorldObjectId}");
             
             return materialData;
         }

         public static Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> Character_InventoryWeaponsGetAll()
         {
             Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>> weaponData = new Dictionary<Guid,Dictionary<byte, Dictionary<byte, Guid>>>();

             foreach (DataRow iW in Instance!._dataTables.InstancedWeaponsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iW[(byte)InstancedWeaponsColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;

                 if (Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId))
                 {
                     var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                     var characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                     if (Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId))
                     {
                         var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                         Guid spawnedWorldObjectId = (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId];
                         var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                         
                         if (!weaponData.ContainsKey(spawnedWorldObjectId))
                             weaponData.Add(spawnedWorldObjectId, new Dictionary<byte, Dictionary<byte, Guid>>());
                         if (!weaponData[spawnedWorldObjectId].ContainsKey(bagIndex))
                             weaponData[spawnedWorldObjectId].Add(bagIndex, new Dictionary<byte, Guid>());
                         weaponData[spawnedWorldObjectId][bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                     }
                 }
             }
             
             return weaponData;
         }

         public static Dictionary<byte, Dictionary<byte, Guid>> Character_InventoryWeaponsGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<byte, Dictionary<byte, Guid>> weaponData = new Dictionary<byte, Dictionary<byte, Guid>>();
             
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             foreach (DataRow iW in Instance!._dataTables.InstancedWeaponsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iW[(byte)InstancedWeaponsColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 if (spawnedWorldObjectId == (Guid) iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])
                 {
                     if (Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId))
                     {
                         var sWoi = Instance._dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
                         var characterBagId = (int) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId];
                         if (Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.ContainsKey(characterBagId))
                         {
                             var sWoB = Instance._dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId[characterBagId];
                             var bagIndex = (byte) sWoB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId];

                             if (!weaponData.ContainsKey(bagIndex))
                                 weaponData.Add(bagIndex, new Dictionary<byte, Guid>());
                             weaponData[bagIndex].Add((byte) sWoi[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag], instancedItemId);
                         }
                     }
                 }
             }
             
             return weaponData;
         }
         
         public static Dictionary<Guid,List<MailContentModel>> Character_MailAttachmentsGetAll()
         {
             Dictionary<Guid,List<MailContentModel>> myDict = new Dictionary<Guid,List<MailContentModel>>();
             
             foreach (DataRow cMa in Instance!._dataTables.CharactersMailAttachmentsDataTable.Select())
             {
                 Guid mailId = (Guid)cMa[(byte)CharactersMailAttachmentsColumns.charactersMailId];
                 var  slotIndex = (byte)cMa[(byte)CharactersMailAttachmentsColumns.slotIndex];
                 var  instancedItemId = (Guid)cMa[(byte)CharactersMailAttachmentsColumns.instancedItemId];
                 var  claimed = cMa[(byte)CharactersMailAttachmentsColumns.takenbyPlayerDateTime].ToString() != "";
                 var itemTypeId = (byte)Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[
                         (Guid)cMa[(byte)CharactersMailAttachmentsColumns.instancedItemId]]
                     [(byte)InstancedItemsColumns.itemTypeId];
                 
                 if (!myDict.ContainsKey(mailId)) myDict.Add(mailId, new List<MailContentModel>());

                 myDict[mailId].Add(new MailContentModel(slotIndex, instancedItemId, claimed, itemTypeId));
             }
             return myDict;
         }
         public static Dictionary<int, List<MailModel>> Character_MailGetAll()
         {
             Dictionary<int, List<MailModel>> myDict = new Dictionary<int, List<MailModel>>();
             
             foreach (DataRow cM in Instance!._dataTables.CharactersMailDataTable.Select()) 
             {
                 var recipientCharacterId = (int) cM[(byte)CharactersMailColumns.recipientCharacterId];
                 if (!myDict.ContainsKey(recipientCharacterId)) myDict.Add(recipientCharacterId, new List<MailModel>());
                 
                 var senderCharacterIdData = cM[(byte)CharactersMailColumns.senderCharacterId];
                 var mailId     = (Guid)cM[(byte)CharactersMailColumns.charactersMailId];
                 var senderName = (string)cM[(byte)CharactersMailColumns.senderName];
                 var senderCharacterId = senderCharacterIdData == DBNull.Value ? 0: (int)senderCharacterIdData;
                 var mailSubject     = (string)cM[(byte)CharactersMailColumns.mailSubject];
                 var mailBody        = (string)cM[(byte)CharactersMailColumns.mailBody];
                 var gold            = (uint)(int)cM[(byte)CharactersMailColumns.sentGold];
                 var silver          = (byte)cM[(byte)CharactersMailColumns.sentSilver];
                 var copper          = (byte)cM[(byte)CharactersMailColumns.sentCopper];
                 var currencyClaimed = (bool)cM[(byte)CharactersMailColumns.currencyClaimed];
                 var contentsClaimed = (bool)cM[(byte)CharactersMailColumns.contentsClaimed];
                 var unread          = (bool)cM[(byte)CharactersMailColumns.unread];
                 var sentDateTime    = DateTime.Parse(cM[(byte)CharactersMailColumns.sentDateTime].ToString());
                 var appearDateTime  = DateTime.Parse(cM[(byte)CharactersMailColumns.appearDateTime].ToString());
                 var expireDataTime  = DateTime.Parse(cM[(byte)CharactersMailColumns.autoDeleteDateTime].ToString());
                     
                 myDict[recipientCharacterId].Add(new MailModel(mailId, senderName, senderCharacterId, mailSubject, mailBody, gold, silver, copper, currencyClaimed, contentsClaimed, unread, sentDateTime, appearDateTime, expireDataTime));
             }
             return myDict;
         }

         public static Dictionary<string, string> Character_MissionsGetList(int characterId)
         {
             Dictionary<string, string> myDict = new Dictionary<string, string>();

             // TODO IMPLEMENT
//             //throw new NotImplementedException();
             
             return myDict;
         }
         
         public static Dictionary<byte, List<ushort>> Character_QuestsGetList(int characterId)
         {
             Dictionary<byte, List<ushort>> myDict = new Dictionary<byte, List<ushort>>();

             foreach (DataRow cQ in Instance!._dataTableSelects.CharactersQuestsSelectRows(characterId))
             {
                 var questStatusId = (byte) cQ[(byte)CharactersQuestsColumns.questStatusId];
                 string questGlobalObject = (string) cQ[(byte)CharactersQuestsColumns.questGlobalObject];
                 var questId = (ushort)(int) Instance._dataTables.ScriptableQuestsDictionary[questGlobalObject][(byte)ScriptableQuestsColumns.scriptableQuestId];
                 if(!myDict.ContainsKey(questStatusId)) myDict.Add(questStatusId, new List<ushort>());
                 myDict[questStatusId].Add(questId);
             }
             
             
             return myDict;
         }

         public static Dictionary<ushort, Dictionary<byte, List<QuestObjectiveModel>>> Character_QuestsObjectivesGetList(int characterId)
         {
             Dictionary<ushort, Dictionary<byte, List<QuestObjectiveModel>>> myDict = new Dictionary<ushort, Dictionary<byte, List<QuestObjectiveModel>>>();

             foreach (DataRow cQo in Instance!._dataTableSelects.CharactersQuestsObjectivesSelectRows(characterId))
             {
                 var questGlobalObject = (string) cQo[(byte)CharactersQuestsObjectivesColumns.questGlobalObject];
                 string objectiveGlobalObject = (string) cQo[(byte)CharactersQuestsObjectivesColumns.objectiveGlobalObject];
                 
                 var sQ = Instance._dataTables.ScriptableQuestsDictionary[questGlobalObject];
                 var sQo = Instance._dataTables.ScriptableQuestObjectivesDictionary[questGlobalObject][objectiveGlobalObject];
                 var sO = Instance._dataTables.ScriptableObjectsDictionary[objectiveGlobalObject];

                 var scriptableQuestId = (ushort)(int) sQ[(byte)ScriptableQuestsColumns.scriptableQuestId];
                 var scriptableObjectPath = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                 var currentProgress = (short) cQo[(byte)CharactersQuestsObjectivesColumns.currentProgress];
                 var objectiveTypeId = (byte) sQo[(byte)ScriptableQuestObjectivesColumns.objectiveTypeId];

                 if(!myDict.ContainsKey(scriptableQuestId)) myDict.Add(scriptableQuestId, new Dictionary<byte, List<QuestObjectiveModel>>());
                 if(!myDict[scriptableQuestId].ContainsKey(objectiveTypeId)) myDict[scriptableQuestId].Add(objectiveTypeId, new List<QuestObjectiveModel>());
                 myDict[scriptableQuestId][objectiveTypeId].Add(new QuestObjectiveModel(objectiveGlobalObject, 
                     scriptableObjectPath, "", currentProgress, 0, objectiveTypeId));
             }
             
             return myDict;
         }
         public static List<string> Character_RecipesGetList(int characterId)
         {
             List<string> recipes = new List<string>();

             foreach (DataRow cR in Instance!._dataTables.CharactersRecipesDataTable.Select())
             {
                 if (characterId == (int) cR[(byte)CharactersRecipesColumns.characterId])
                 {
                     string recipeId = (string) cR[(byte)CharactersRecipesColumns.globalObject];
                     recipes.Add(recipeId);
                 }
             }
             return recipes;
         }
             
         public static Dictionary<string, int> Character_SkillsGetList(int characterId)
         {
             Dictionary<string, int> myDict = new Dictionary<string, int>();

             foreach (DataRow cS in Instance!._dataTables.CharactersSkillsDataTable.Select())
             {
                 if (characterId == (int) cS[(byte)CharactersSkillsColumns.characterId])
                 {
                     string globalObject             = (string) cS[(byte)CharactersSkillsColumns.globalObject];
                     int    characterSkillExperience = (int)cS[(byte)CharactersSkillsColumns.characterSkillExperience];
                     myDict.Add(globalObject, characterSkillExperience);
                 }
             }
             return myDict;
         }
         public static List<ushort> Character_TitlesGetList(int characterId)
         {
             List<ushort> myDict = new List<ushort>();

             foreach (DataRow cT in Instance!._dataTables.CharactersTitlesDataTable.Select())
             {
                 if (characterId == (int) cT[(byte)CharactersTitlesColumns.characterId])
                 {
                     ushort titleId = (ushort)(int) Instance._dataTables.ScriptableTitlesDataTable.Select($"{ScriptableTitlesColumns.globalObject} = {cT[(byte)CharactersTitlesColumns.globalObject]}")[0][(byte)ScriptableTitlesColumns.globalObject];
                     myDict.Add(titleId);
                 }
             }
             return myDict;
         }
         public static List<ushort> Character_AchievementsGetList(int characterId)
         {
             List<ushort> myDict = new List<ushort>();

             foreach (DataRow cA in Instance!._dataTables.CharactersAchievementsDataTable.Select())
             {
                 if (characterId == (int) cA[(byte)CharactersAchievementsColumns.characterId])
                 {
                     ushort achievementId = 
                         (ushort)(int) Instance._dataTables.ScriptableAchievementsDataTable.
                         Select($"{ScriptableAchievementsColumns.globalObject} = {cA[(byte)CharactersAchievementsColumns.globalObject]}")[0][(byte)ScriptableAchievementsColumns.globalObject];
                     myDict.Add(achievementId);
                 }
             }
             return myDict;
         }
         public static List<StatModel> Character_StatsGetList(int characterId)
         {
             List<StatModel> myDict = new List<StatModel>();
             
             foreach (DataRow cS in Instance!._dataTables.CharactersStatsDataTable.Select())
             {
                 if (characterId == (int) cS[(byte)CharactersStatsColumns.characterId])
                 {
                     var statTypeId = (byte) cS[(byte)CharactersStatsColumns.characterStatTypeId];
                     var statId = (byte) cS[(byte)CharactersStatsColumns.statId];
                     float statValue = (float) (decimal) cS[(byte)CharactersStatsColumns.characterStatValue];
                     var statRow = Instance._dataTables.StatsDataTable.Select(
                         $"{EntityStatsColumns.statTypeId} = {statTypeId} AND {EntityStatsColumns.statId} = {statId}")[0];
                     float minValue = (float)(decimal)statRow[(byte)StatsColumns.statMinValue];
                     float maxValue = (float)(decimal)statRow[(byte)StatsColumns.statMaxValue];
                     myDict.Add(new StatModel(statTypeId, statId, statValue, minValue, maxValue));
                 }
             }
             return myDict;
         }

         #endregion
         
         #region DATA TABLE STP INSERT / UPDATES / DELETES: CHARACTERS

         //PLAYER
         // public static int PlayerAccount_Create(in Guid steamId, string steamName, string userName, string emailAddress)
         // {
         //     Stopwatch? watch                = null;
         //    if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
         //     int playerAccountId = -1;
         //     string password = "testpassword";
         //     string salt = "Salt";
         //     string lastIpAddressOnLogin = "192.168.1.1";
         //     var lastLoginTime = DateTime.Now;
         //
         //     try
         //     {
         //         //  NEW ROW
         //         DataRow pA = Instance._dataTables.PlayersAccountsDataTable.NewRow();
         //         //  POPULATE ROW WITH DATA
         //         pA = Instance._dataTableSelects.PopulatePlayerAccountsDataRow(pA, steamId, steamName, userName, emailAddress, password, salt, lastIpAddressOnLogin, lastLoginTime);
         //         //  ADD ROW TO TABLE
         //         Instance._dataTables.PlayersAccountsDataTable.Rows.Add(pA);
         //         //GET KEY FROM ROW ADDED TO TABLE
         //         playerAccountId = (int)pA[(byte)PlayersAccountsColumns.playerAccountId];
         //     }
         //     catch (Exception e)
         //     {
         //         Logger!.LogError($"SQL EXCEPTION (PlayerAccount_Create): {e.Message} - Params: Username: {userName}, Password: {password}");
         //     }
         //
         //     Logger!.LogProfiling($"DataTableStoredProcs.PlayerAccount_Create took {watch!.ElapsedTicks/10000f} ms"); 
         //     return playerAccountId;
         // }
         public static int PlayerAccount_Create(string userName, string password)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             Guid steamId = Guid.NewGuid();
             int playerAccountId = -1;
             string salt = "Salt";
             string lastIpAddressOnLogin = "192.168.1.1";
             var lastLoginTime = DateTime.Now;
             try
             {
                 if(Instance!._dataTables.PlayersAccountsDictionaryByUserName.ContainsKey(userName.ToLower()))
                     throw new Exception($@"Username: {userName} already exists in the database");
                 //  NEW ROW
                 DataRow pA = Instance._dataTables.PlayersAccountsDataTable.NewRow();
                 //  POPULATE ROW WITH DATA
                 pA = Instance._dataTableSelects.PopulatePlayerAccountsDataRow(pA, steamId, "", userName.ToLower(), password, "", salt, lastIpAddressOnLogin, lastLoginTime);
                 //  ADD ROW TO TABLE
                 Instance._dataTables.PlayersAccountsDataTable.Rows.Add(pA);
                 Instance._dataTables.PlayersAccountsDictionaryByUserName.Add(userName.ToLower(), pA);
                 //GET KEY FROM ROW ADDED TO TABLE
                 playerAccountId = (int)pA[(byte)PlayersAccountsColumns.playerAccountId];
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (PlayerAccount_Create): {e.Message} - 
                     Params: Username: {userName}, Password: {password}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.PlayerAccount_Create took {watch!.ElapsedTicks/10000f} ms"); 
             return playerAccountId;
         }
         //UPDATE
         public static int PlayerAccount_ResetPassword(string userName, string password)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             int playerAccountId = -1;
             try
             {
                 DataRow pA = Instance!._dataTableSelects.PlayersAccountsSelectRows(userName)[0];
                 pA[(byte)PlayersAccountsColumns.password] = password;
                 playerAccountId = (int)pA[(byte)PlayersAccountsColumns.playerAccountId];
             }
             catch (Exception e)
             {
                 Logger!.LogError($"SQL EXCEPTION (PlayerAccount_ResetPassword): {e.Message} - Params: Username: {userName}, Password: {password}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.PlayerAccount_ResetPassword took {watch!.ElapsedTicks/10000f} ms"); 
             return playerAccountId;
         }
         public static bool Character_AbilitiesAdd(int characterId, string abilityGlobalObject, ushort abilityId, int abilityExperience)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 Instance!._dataTableSelects.AddCharactersAbilitiesDataRow(characterId, abilityGlobalObject, abilityExperience);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_AbilitiesAdd):{e.Message} - 
                     Params: CharacterId: {characterId}, AbilityGlobalObject: {abilityGlobalObject}, 
                     AbilityId: {abilityId}, AbilityExperience: {abilityExperience}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_AbilitiesAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_AbilitiesUpdate(
             int            characterId,
             string abilityGlobalObject, 
             ushort         abilityId,
             int abilityExperience)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 var cHA = Instance!._dataTableSelects.CharactersAbilitiesSelectRows_ByGlobalObjectCode(characterId, abilityGlobalObject); 
                 cHA[(byte)CharactersAbilitiesColumns.characterAbilityExperience] = ((int)cHA[(byte)CharactersAbilitiesColumns.characterAbilityExperience] + abilityExperience);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($"SQL EXCEPTION (Character_AbilitiesUpdate):{e.Message} - Params: CharacterId: {characterId}, AbilityGlobalObject: {abilityGlobalObject}, AbilityId: {abilityId}, AbilityExperience: {abilityExperience}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_AbilitiesUpdate took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_AchievementsUnlock(int characterId, string achievementGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 Instance!._dataTableSelects.AddCharactersAchievementsDataRow(characterId, achievementGlobalObject);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_AchievementsAdd):{e.Message} - Params: CharacterId: {characterId},
                 AchievementGlobalObject: {achievementGlobalObject}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_AbilitiesAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         private static byte? MaxBags; 
         private static byte? MaxPlayerBuybacks; 
         private static byte? MaxCharacters; 
         public static int Character_Create(int playerAccountId, string characterName, int characterFactionId, float coordinateX, 
             float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, 
             float scaleY, float scaleZ, int race, int gender, int face, int eyebrows, int hair, int facialHair, string skinColor, 
             string eyeColor, string hairColor, string stubbleColor, float spawnLocationX, float spawnLocationY, float spawnLocationZ)
         {
             Logger!.LogDebug($"Character_Create: {characterName}");

             
             int    characterTierId  = 1; 
             int    characterRankId  = 1; 
             int    characterModelId = 1;
             byte   globalTierId     = 1;
             byte   globalRankId     = 1;
             var    ignoreSpawnTable = true;
             byte variationId      = 0;
             string prefabId      = "";
             string status           = "active";

             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             try
             {
                 if (Instance!._dataTables.CharactersDictionaryByCharacterName.ContainsKey(characterName))
                 {
                     throw new Exception($"Character name already exists");
                 }

                 Guid spawnedWorldObjectId = Guid.NewGuid();
                 int validCharacters = 0;
                 if (Instance._dataTables.CharactersDictionaryByPlayerAccountId.TryGetValue(playerAccountId,
                         out var characters))
                 {
                     validCharacters      = characters.Count;
                 }
                 if (validCharacters == MaxCharacters) throw new InvalidDataException("Max Characters Created");

                 #region INSERT INTO SPAWNED WORLD OBJECTS
                 //  INSERT SPAWNED WORLD OBJECT
                 Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Entity,
                     "playerCharacter",  coordinateX, coordinateY, coordinateZ, chunk, rotationX, 
                     rotationY, rotationZ, scaleX, scaleY, scaleZ, globalTierId, globalRankId, variationId,prefabId,
                     ignoreSpawnTable, null);
                 //  POPULATE ROW WITH DATA
                 DataRow characterRow = Instance._dataTableSelects.AddCharactersDataRow(spawnedWorldObjectId, playerAccountId, characterTierId, 
                     characterRankId, characterModelId, characterFactionId, 0, characterName, gender, 
                     face, eyebrows, hair, facialHair, eyeColor, hairColor, skinColor, race, stubbleColor, spawnLocationX,
                     spawnLocationY, spawnLocationZ, status);
                 var characterId = (int)characterRow[(byte)CharactersColumns.characterId];

                 #endregion
                 #region INSERT INTO CHARACTERS
                 //GET DATA FROM STATS TABLE
                 var stats = Instance._dataTables.StatsDataTable.Select();

                 //LOOP ON DATA FROM STATS TABLE
                 foreach (var statRow in stats)
                 {
                     int    characterStatTypeId      = (byte)statRow[(byte)StatsColumns.statTypeId];
                     int    characterStatStatusId    = (byte)statRow[(byte)StatsColumns.statStatusId];
                     int    characterStatTierId      = (byte)statRow[(byte)StatsColumns.statTierId];
                     float  characterStatValue       = (float)(decimal)statRow[(byte)StatsColumns.statInitialValue];
                     string characterStatDescription = (string)statRow[(byte)StatsColumns.statDescription];
                     int    characterStatIconId      = (int)statRow[(byte)StatsColumns.statIconId];

                     int    statId        = (byte)statRow[(byte)StatsColumns.statId];
                     string characterStat = (string)statRow[(byte)StatsColumns.stat];

                     //  POPULATE ROW WITH DATA
                     Instance._dataTableSelects.AddCharactersStatsDataRow(characterId, characterStatTypeId, characterStatStatusId, characterStatTierId, 
                         characterStatValue, characterStatDescription, characterStatIconId, statId, characterStat);
                 }

                 //GET DATA FROM EQUIPMENT LOCATIONS TABLE
                 var equipmentLocations = Instance._dataTables.EquipmentSlotTypesDataTable.Select();
                 
                 //LOOP ON DATA FROM EQUIPMENT LOCATIONS TABLE
                 Instance._dataTables.SpawnedWorldObjectsEquipmentDictionary.Add(spawnedWorldObjectId, new List<DataRow>());
                 for (int i = 1; i < equipmentLocations.Length; i++)
                 {
                     // IGNORES 0 = NONE
                     DataRow eST = equipmentLocations[i];
                     DataRow spawnedWorldObjectsEquipmentLocationsRow = Instance._dataTables.SpawnedWorldObjectsEquipmentDataTable.NewRow();
                     byte equipmentLocationId = (byte)eST[(byte)EquipmentSlotTypesColumns.equipmentSlotTypeId];
                     
                     //  POPULATE ROW WITH DATA
                     spawnedWorldObjectsEquipmentLocationsRow = Instance._dataTableSelects.PopulateSpawnedWorldObjectsEquipmentDataRow(spawnedWorldObjectsEquipmentLocationsRow, spawnedWorldObjectId, equipmentLocationId, Guid.Empty);

                     //  ADD ROW TO TABLE
                     Instance._dataTables.SpawnedWorldObjectsEquipmentDataTable.Rows.Add(spawnedWorldObjectsEquipmentLocationsRow);
                     Instance._dataTables.SpawnedWorldObjectsEquipmentDictionary[spawnedWorldObjectId].Add(spawnedWorldObjectsEquipmentLocationsRow);
                 }
         
                 for(byte i = 0; i < MaxBags; i++)
                 {
                     //  POPULATE ROW WITH DATA
                     Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, i);
                 }
                 for(byte i = 0; i < MaxPlayerBuybacks; i++)
                 {
                     //  POPULATE ROW WITH DATA
                     Instance._dataTableSelects.AddCharactersBuybacksDataRow(characterId);
                 }
                 
                 #endregion
                 #region INSERT INTO SPAWNED WORLD OBJECT CURRENCY
                 //#4: INSERT SPAWNED WORLD OBJECT CURRENCY
                 int amount_Gold = 0; 
                 byte amount_Silver = 0;
                 byte amount_Copper = 0;
                 int token_adventuring = 0;
                 int token_crafting = 0;
                 int token_gathering = 0;
                 Instance._dataTableSelects.AddSpawnedWorldObjectsCurrencyDataRow(spawnedWorldObjectId, amount_Gold, amount_Silver, amount_Copper, token_adventuring, token_crafting, token_gathering);
                 #endregion

                 Instance._dataTables.CharactersDictionaryByPlayerAccountId.TryAdd(playerAccountId, new List<DataRow>());
                 Instance._dataTables.CharactersDictionaryByPlayerAccountId[playerAccountId].Add(characterRow);
                 Instance._dataTables.CharactersDictionaryByCharacterName.Add(characterName, characterRow);
                 //Instance._dataTables.CharactersDictionaryBySpawnedWorldObjectId.Add(spawnedWorldObjectId, characterRow);

                 Logger!.LogProfiling($"DataTableStoredProcs.Character_Create({true}) took {watch!.ElapsedTicks/10000f} ms");
                 return characterId;
             }
             catch (Exception e)
             {
                 Logger.LogException(e);
                 return 0;
             }
             
            
         }
         
         /// <summary>
         /// Used when spawning a bag without equipping it, I.E spawning a spawned world object for the first and they
         /// have no bags yet so we need to add one instead of equipping
         /// </summary>
         /// <param name="spawnedWorldObjectId"></param>
         /// <param name="instancedItemId"></param>
         /// <param name="bagLocationId"></param>
         /// <param name="bagSize"></param>
         /// <returns></returns>
         public static bool Character_BagAdd(Guid spawnedWorldObjectId, Guid instancedItemId, byte bagLocationId, byte bagSize)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 var bags = Instance!._dataTableSelects._dataTables.SpawnedWorldObjectsBagsDataTable.Select(
                     $"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId} = " + "'" + spawnedWorldObjectId + "'");

                 if (bags.Length == 0)
                 {
                     for(byte i = 0; i < MaxBags; i++)
                     {
                         //  POPULATE ROW WITH DATA
                         Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, i);
                     }
                 }
                 // UPDATE THE ROW BECAUSE BAGS ARE PRE-SPAWNED WHEN CHARACTER IS CREATED.
                 var sWOB = Instance._dataTableSelects.UpdateSpawnedWorldObjectsBag(spawnedWorldObjectId,bagLocationId, instancedItemId);
                 int characterBagId = (int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 
                 // ADD BAG SLOTS TO SPAWNED WORLD OBJECT INVENTORY SLOTS
                 for (byte i = 0; i < bagSize; i++)
                 {
                     Instance._dataTableSelects.AddSpawnedWorldObjectsInventory(in spawnedWorldObjectId, characterBagId, i);
                 }

                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_BagAdd): {0} - 
                     Params: SpawnedWorldObjectId: {1}, InstancedItemId: {2}, BagIndex: {3}",
                     e.Message, spawnedWorldObjectId, instancedItemId, bagLocationId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_BagAdd @ {bagLocationId} took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_BagRemove(Guid spawnedWorldObjectId, byte bagIndex)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             try
             {
                 // TODO DELETE INVENTORY SLOTS FIRST
                 Instance!._dataTableSelects.ResetSpawnedWorldObjectsBag(spawnedWorldObjectId, bagIndex);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_BagRemove): {e.Message} - 
                     Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, BagIndex: {bagIndex}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_BagRemove took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_BuybacksAdd(int characterId, Guid instancedItemId, long soldDateTimeBinary)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             try
             {
                 Instance!._dataTableSelects.UpdateCharactersBuybacksDataRow(characterId, instancedItemId, DateTime.FromBinary(soldDateTimeBinary));
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_BuybacksAdd): {e.Message} - 
                     Params: CharacterId: {characterId}, InstancedItemId: {instancedItemId}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_BuybacksAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_BuybacksRemove(int characterId, Guid instancedItemId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             try
             {
                 Instance!._dataTableSelects.ResetCharactersBuybacks(characterId, instancedItemId);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_BuybacksRemove): {e.Message} - 
                     Params: CharacterId: {characterId}, InstancedItemId: {instancedItemId}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_BuybacksRemove took " + watch!.ElapsedTicks / 10000f + " ms");
             return success;
         }

         private static (ushort newGold, byte newSilver, byte newCopper, long totalCurrency) Money_Calculate(int goldCoins, short silverCoins, short copperCoins)
         {
             var totalCurrency = goldCoins * GoldValue + silverCoins * SilverValue + copperCoins;

             return Money_Calculate(totalCurrency);
         }
         private static (ushort newGold, byte newSilver, byte newCopper, long totalCurrency) Money_Calculate(
             long totalCurrency)
         {
             var newTotalCurrency = totalCurrency;
             
             ushort goldCoins =  (ushort)(newTotalCurrency / GoldValue);
             newTotalCurrency %= GoldValue;
             
             byte silverCoins =  (byte)(newTotalCurrency / SilverValue);
             newTotalCurrency %= SilverValue;

             byte copperCoins = (byte)newTotalCurrency;

             return (goldCoins, silverCoins, copperCoins, totalCurrency);
         }
         public static bool Character_CurrencyUpdate(Guid spawnedWorldObjectId, int goldCost, short silverCost,
             short copperCost, short adventuringTokensCost, short craftingTokensCost, short gatheringTokensCost,
             string description)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             int amountGoldTransaction   = 0;
             short  amountSilverTransaction = 0;
             short  amountCopperTransaction = 0;
             
             try
             {
                 var sWOC = Instance!._dataTableSelects.SpawnedWorldObjectsCurrencySelectRow(spawnedWorldObjectId);
                 if (sWOC == null) throw new Exception($"Failed to Update Currency: No Currency Data Found");

                 var amountGoldCurrent = (int)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Gold];
                 byte amountSilverCurrent = (byte)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Silver];
                 byte amountCopperCurrent = (byte)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Copper];
                 var tokensAdventurerCurrent = (int)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_adventuring];
                 var tokensGathererCurrent = (int)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_gathering];
                 var tokensCrafterCurrent = (int)sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_crafting];

                 #region INSERT INTO HISTORY CURRENCY TRANSACTIONS
                 var tokensAdventurerTransaction = tokensAdventurerCurrent + adventuringTokensCost;
                 var tokensGathererTransaction = tokensGathererCurrent + craftingTokensCost;
                 var tokensCrafterTransaction = tokensCrafterCurrent + gatheringTokensCost;

                 var currencyData = Money_Calculate(amountGoldCurrent + goldCost, (short)(amountSilverCurrent + silverCost), (short)(amountCopperCurrent + copperCost));

                 amountGoldTransaction = currencyData.newGold;
                 amountSilverTransaction = currencyData.newSilver;
                 amountCopperTransaction = currencyData.newCopper;
                 
                 if (amountCopperTransaction > SilverValue)
                 {
                     throw new Exception($"Currency Update Failed: Copper Overflow");
                 }
                 
                 if (amountSilverTransaction > SilverValue)
                 {
                     throw new Exception($"Currency Update Failed: Silver Overflow");
                 }
                 
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Gold] = amountGoldTransaction;
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Silver] = (byte)amountSilverTransaction;
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Copper] = (byte)amountCopperTransaction;
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_adventuring] = tokensAdventurerTransaction;
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_gathering] = tokensGathererTransaction;
                 sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_crafting] = tokensCrafterTransaction;
                 
                 Instance._dataTableSelects.AddHistoryCurrencyTransactionsDataRow(spawnedWorldObjectId, amountGoldTransaction, (byte)amountSilverTransaction, (byte)amountCopperTransaction, 
                 description, tokensAdventurerTransaction, tokensGathererTransaction, tokensCrafterTransaction);
                 success = true;
                 #endregion
             }
             catch (Exception e)
             {
                     Logger!.LogError($@"SQL EXCEPTION (Character_CurrencyUpdate): {e.Message} - 
                     Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, GoldChanged: {goldCost}, 
                     SilverChanged: {silverCost}, CopperChanged: {copperCost}, AdventuringTokensChanged: {adventuringTokensCost}, 
                     CraftingTokensChanged: {craftingTokensCost}, GatheringTokensChanged: {gatheringTokensCost}, 
                     Description: {description}, AmountGoldTransactions {amountGoldTransaction}, AmountSilverTransactions: {amountSilverTransaction}, AmountCopperTransactions: {amountCopperTransaction}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_CurrencyUpdate took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static string? Character_Delete(int characterId)
         {
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             

             try
             {
                 var cH                   = Instance!._dataTables.CharactersDictionaryByCharacterId[characterId];
                 var spawnedWorldObjectId = (Guid) cH[(byte)CharactersColumns.spawnedWorldObjectId];
                 int charactersId         = (int)cH[(byte)CharactersColumns.characterId];
                 int playerAccountId      = (int)cH[(byte)CharactersColumns.playerAccountId];
                 cH[(byte)CharactersColumns.status] = GlobalStatusTypes.Deleted.ToString().ToLower();

                 //Character_InventoryDeleteAll(spawnedWorldObjectId);

                 //DeleteCharactersSocial_ByCharacterId(charactersId);
                 //DeleteCharactersAbilities_ByCharacterId(charactersId);
                 //DeleteCharactersAchievements_ByCharacterId(charactersId);
                 //DeleteCharactersQuests_ByCharacterId(charactersId);
                 //DeleteCharactersRecipes_ByCharacterId(charactersId);
                 //DeleteCharactersSkills_ByCharacterId(charactersId);
                 //DeleteCharactersStats_ByCharacterId(charactersId);
                 //DeleteCharactersTitles_ByCharacterId(charactersId);

             
                 //UPDATE CHARACTERS STATUS TO 'DELETED'
     
                 
                 //UPDATE ON FRIENDS LIST TO CHARACTER DELETED
                 List<DataRow> charactersSocialDataRows = Instance._dataTableSelects.CharactersSocialSelectRows_BySocialCharacterId(charactersId);
                 if (charactersSocialDataRows.Count > 0)
                 {
                     //var charactersSocialDataRow = charactersSocialDataRows[0];
                     //charactersSocialDataRow[(byte)CharactersSocialColumns.status] = GlobalStatusTypes.Deleted.ToString().ToLower();
                 }

                 Instance._dataTables.CharactersDictionaryByPlayerAccountId[playerAccountId].Remove(cH);
                 Instance._dataTables.CharactersDictionaryByCharacterId.Remove(charactersId);
                 Instance._dataTables.CharactersDictionaryBySpawnedWorldObjectId.Remove((Guid)cH[(byte)CharactersColumns.spawnedWorldObjectId]);
                 Instance._dataTables.CharactersDictionaryByCharacterName.Remove((string)cH[(byte)CharactersColumns.characterName]);

                 Instance._dataTables.SpawnedWorldObjectsDictionary.Remove(spawnedWorldObjectId);
                 Instance._dataTables.SpawnedWorldObjectsCurrencyDictionary.Remove(spawnedWorldObjectId);
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_Delete): {e.Message} - Params: CharacterId: {characterId}");
                 return string.Format(@"SQL EXCEPTION (Character_Delete): {0} - Params: CharacterId: {1}",
                     e.Message, characterId);
             }


             Logger!.LogProfiling($"DataTableStoredProcs.Character_Delete took {watch!.ElapsedTicks/10000f} ms");

             return null;
         }
         public static bool Character_EquipmentMove(Guid spawnedWorldObjectId, byte fromSlotIndex, byte toSlotIndex)
         {
             var moveEquipmentLocationId = 99; // Used to move item out of slot
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             bool success = false;
             
             try
             {
                 //SELECT
                 var data1 = Instance!._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_BySpawnedWorldObjectId(spawnedWorldObjectId, fromSlotIndex);
                 var data2 = Instance._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_BySpawnedWorldObjectId(spawnedWorldObjectId, toSlotIndex);
                 
                 if (!(data1.Count == 1 && data2.Count == 1)) throw new Exception($"Failed To Move Equipment: Invalid Data");
                 DataRow spawnedWorldObjectsEquipmentDataRow1 = data1[0];
                 Guid fromItemId = (Guid)spawnedWorldObjectsEquipmentDataRow1[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId];
                 DataRow spawnedWorldObjectsEquipmentDataRow2 = data2[0];
                 Guid toItemId = (Guid)spawnedWorldObjectsEquipmentDataRow2[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId];


                 DataRow dr1 = Instance._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_ByInstancedItemId(fromItemId)[0];
                 dr1[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] = moveEquipmentLocationId; // Used to move item out of slot
                 DataRow dr2 = Instance._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_ByInstancedItemId(toItemId)[0];
                 dr2[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] = toSlotIndex;
                 dr1[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] = fromSlotIndex; // Used to move item out of slot
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(@$"SQL EXCEPTION (Character_EquipmentMove):{e.Message} - 
                     Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, FromSlotIndex: {fromSlotIndex}, 
                     ToSlotIndex: {toSlotIndex}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_EquipmentMove took {watch!.ElapsedTicks/10000f} ms");

             return success;
         }
         public static bool Character_EquipmentRemove(Guid spawnedWorldObjectId, byte equipmentSlotIndex)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             try
             {
                 Instance!._dataTableSelects.DeleteSpawnedWorldObjectsEquipment_ByEquipmentLocationId(spawnedWorldObjectId, equipmentSlotIndex);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_EquipmentRemove):{e.Message} - 
                     Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, EquipmentSlotIndex: {equipmentSlotIndex}");
             }

             if (SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_EquipmentRemove took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryAddItem(Guid spawnedWorldObjectId, Guid instancedItemId, byte bagIndex, byte slotIndex)
         {
             bool       success               = false;
             Stopwatch? watch                 = null;
             if (SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             try
             {
                 if (instancedItemId == default) throw new Exception($"Failed To Add Item: Invalid Item Id");

                 //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
                 var data = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(spawnedWorldObjectId,
                     bagIndex);
                 if (data.Count == 0) throw new Exception($"No bag located");
                 DataRow sWOB           = data[0];
                 int     characterBagId = (int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];

                 var sWOI = Instance._dataTableSelects.UpdateSpawnedWorldObjectsInventory(spawnedWorldObjectId,
                     instancedItemId, characterBagId, slotIndex);
                 if (sWOI == null)
                     throw new Exception(
                         $"Failed to add item to inventory, inventory slot not found {characterBagId}, {slotIndex}");

                 success = true;
             }
             catch(Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_InventoryAddItem):{e.Message} - 
                     Params: SpawnedWorldObjectId = {spawnedWorldObjectId}, InstancedItemId = {instancedItemId}, BagIndex = {bagIndex}, SlotIndex = {slotIndex}");
                 success = false;
             }
             
             if (SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryAddItem took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         /// <summary>
         /// Used for switching bag locations between bag slots
         /// </summary>
         /// <param name="spawnedWorldObjectId"></param>
         /// <param name="fromBagIndex"></param>
         /// <param name="toBagIndex"></param>
         /// <returns>Success</returns>
         /// <remarks> Only works for same entity, bag swapping across entities is not supported.</remarks>
         public static bool Character_InventoryBagChangeLocation(Guid spawnedWorldObjectId, byte fromBagIndex, byte toBagIndex)
         {
             var tempBagIndex = 99; // Used to move item out of slot
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             try
             {
                 //SELECT
                 var fromBag = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(spawnedWorldObjectId, fromBagIndex);
                 var toBag = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(spawnedWorldObjectId, toBagIndex);

                 if (toBag.Count == 1) //IF BAG EXISTS IN INDEX TO MOVE BAG TO
                 {
                     DataRow fromBagDataRow = fromBag[0];
                     DataRow toBagDataRow = toBag[0];

                     if ((int)toBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId] >
                         (int)fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId])
                     {
                         toBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = tempBagIndex; //move to location 99
                         fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = toBagIndex;
                         toBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = fromBagIndex;
                     }
                     else
                     {
                         fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = tempBagIndex; //move to location 99
                         toBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId]   = fromBagIndex;
                         fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = toBagIndex;
                     }
                     success = true;
                 }
                 else //BAG DOES NOT EXISTS IN INDEX TO MOVE BAG TO, AKA MOVING BAG TO EMPTY BAG INDEX
                 {
                     DataRow fromBagDataRow = fromBag[0];
                     fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = toBagIndex;
                     success = true;
                 }
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_InventoryBagChangeLocation):{e.Message} - 
                     Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, FromBagIndex: {fromBagIndex}, ToBagIndex: {toBagIndex}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryBagChangeLocation took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryBagUnequip(Guid fromSpawnedWorldObjectId, byte fromBagIndex, Guid toSpawnedObjectId, 
             byte toBagIndex, byte toSlotIndex)
         {
             var  watch   = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 // TYPE 0: FIND instancedItemId for the BAG TO DE - EQUIP.
                 var fromSWOB = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedWorldObjectId, fromBagIndex)[0];
                 var fromInstancedItemId = (Guid)fromSWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId];
                 //var fromBagId = (int)fromSWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 
                 //  DELETE BAG TO DE-EQUIP FROM CHARACTER BAGS TABLE
                 if(Instance._dataTableSelects.RemoveSpawnedWorldObjectsBag_ByInstancedItemId(fromInstancedItemId) == null) 
                     throw new Exception($"Failed to Delete Bag");
                 
                 Logger!.Log($"Character_InventoryBagUnequip: {fromSpawnedWorldObjectId}");
                 DataRow toSWOB = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(toSpawnedObjectId, toBagIndex)[0];
                 var toBagId = (int)toSWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 
                 Instance._dataTableSelects.UpdateSpawnedWorldObjectsInventory(toSpawnedObjectId, fromInstancedItemId, toBagId, toSlotIndex);
                 
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_InventoryBagUnequip):{e.Message} - 
                     Params: FromSpawnedWorldObjectId: {fromSpawnedWorldObjectId}, FromBagIndex: {fromBagIndex}, 
                     ToSpawnedObjectId: {toSpawnedObjectId}, ToBagIndex: {toBagIndex}, ToSlotIndex: {toSlotIndex}");
             }

             Logger.LogProfiling($"DataTableStoredProcs.Character_InventoryBagEquip took {watch.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryBagEquip(Guid fromSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, Guid toSpawnedObjectId, byte toBagIndex, byte bagSize)
         {
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             // TYPE 0: FIND instancedItemId for the container BAG where the bag you want de-equip will be placed. 
             // TYPE 1: FIND instancedItemId for the container BAG for where the bag you want to equip currently resides.
             DataRow fromSWOB            = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedWorldObjectId, fromBagIndex)[0];
             int     fromBagId           = (int)fromSWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
             DataRow fromSWOI            = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(fromSpawnedWorldObjectId, fromBagId, fromSlotIndex);
             Guid    fromInstancedItemId = (Guid)fromSWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];

             //DataRow toSWOB = SpawnedWorldObjectsBagsSelectRows(toSpawnedObjectId, toBagIndex)[0];
             Instance._dataTableSelects.ResetSpawnedWorldInventory_ByInstancedItemId(fromInstancedItemId);
             
             Character_BagAdd(toSpawnedObjectId, fromInstancedItemId, toBagIndex, bagSize);

             //toSWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = fromInstancedItemId;
             var success = true;

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryBagEquip took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_InventoryBagsSwap(Guid fromSpawnedObjectId, byte fromBagIndex, Guid toSpawnedObjectId, byte toBagIndex)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;
             try
             {
                 var fromSWOB = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedObjectId, fromBagIndex)[0];
                 var toSWOB   = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(toSpawnedObjectId, toBagIndex)[0];
                 
                 Guid fromInstancedItemId = (Guid)fromSWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId];
                 Guid toInstancedItemId = (Guid)toSWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId];
                 
                 Instance._dataTableSelects.ResetSpawnedWorldObjectsBag(fromSpawnedObjectId, fromBagIndex);
                 Instance._dataTableSelects.ResetSpawnedWorldObjectsBag(toSpawnedObjectId, toBagIndex);
                 
                 Instance._dataTableSelects.UpdateSpawnedWorldObjectsBag(fromSpawnedObjectId, fromBagIndex, toInstancedItemId);
                 Instance._dataTableSelects.UpdateSpawnedWorldObjectsBag(toSpawnedObjectId, toBagIndex, fromInstancedItemId);
                 
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryBagEquip):{0} - 
                     Params: FromSpawnedWorldObjectId: {1}, FromBagIndex: {2}, 
                     ToSpawnedObjectId: {3}, ToSlotIndex: {4}",
                     e.Message, fromSpawnedObjectId, fromBagIndex, toSpawnedObjectId, toBagIndex));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryBagEquip took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryDeleteAll(Guid spawnedWorldObjectId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             try
             {
                 Instance!._dataTableSelects.DeleteSpawnedWorldObjectsInventory_BySpawnedWorldObjectId(spawnedWorldObjectId);
                 Instance._dataTableSelects.DeleteSpawnedWorldObjectsEquipment_BySpawnedWorldObjectId(spawnedWorldObjectId);
                 Instance._dataTableSelects.DeleteSpawnedWorldObjectsBags_BySpawnedWorldObjectId(spawnedWorldObjectId);
                 Instance._dataTableSelects.DeleteSpawnedWorldObjectsCurrency_BySpawnedWorldObjectId(spawnedWorldObjectId);

                 foreach (var iI in Instance._dataTables.InstancedItemsDataTable.Select($"spawnedWorldObjectId='{spawnedWorldObjectId}' AND status <> 'deleted'"))
                 {
                     if((Guid)iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] != spawnedWorldObjectId) continue;
                     if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                     
                     iI[(byte)InstancedItemsColumns.status] = GlobalStatusTypes.Deleted.ToString().ToLower();
                 }
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryDeleteAll):{0} - Params: SpawnedWorldObjectId: {1}",
                     e.Message, spawnedWorldObjectId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryDeleteAll took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryEquip(Guid spawnedWorldObjectId, byte equipmentSlotId, byte bagIndex, byte slotIndex, byte equipType)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
              //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
              
             try
             {
                 //RETRIEVE Character Bag Id
                 var containerBagData = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(spawnedWorldObjectId, bagIndex);
                 DataRow containerBagDataRow = containerBagData[0];
                 var containerBagId = (int)containerBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 
                 if (equipType == 0) // TYPE 0: UN-EQUIP ITEM
                 {
                     // FIND instancedItemId for the ITEM TO UN-EQUIP.
                     var equipmentData = Instance._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_BySpawnedWorldObjectId(spawnedWorldObjectId, equipmentSlotId);
                     DataRow equipmentDataRow = equipmentData[0];
                     var itemToUnEquipId = (Guid)equipmentDataRow[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId];
                     
                     //  DELETE ITEM TO DE-EQUIP FROM CHARACTER EQUIPMENT TABLE 
                     //DeleteSpawnedWorldObjectsEquipment_ByInstancedItemId(itemToUnEquipId);        
                     Instance._dataTableSelects.ResetSpawnedWorldObjectsEquipment_ByRow(equipmentDataRow);
                     Instance._dataTableSelects.UpdateSpawnedWorldObjectsInventory(spawnedWorldObjectId, itemToUnEquipId, containerBagId, slotIndex);
                     //  INSERT DE-EQUIPPED ITEM INTO CHARACTER INVENTORY
                     //DataRow dr = SpawnedWorldObjectsInventoryDataTable.NewRow(); //  NEW ROW
                     //  POPULATE ROW WITH DATA
                     //dr = PopulateSpawnedWorldObjectsInventoryDataRow(dr, spawnedWorldObjectId, itemToUnEquipId, containerBagId, slotIndex);
                     //  ADD ROW TO TABLE
                     //SpawnedWorldObjectsInventoryDataTable.Rows.Add(dr);
                     success = true;
                 }
                 //  TYPE 1: EQUIP
                 else if (equipType == 1) //EQUIP ITEM
                 {
                     // FIND instancedItemId for the ITEM TO EQUIP.
                     DataRow sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(spawnedWorldObjectId, containerBagId, slotIndex);
                     if (sWOI == null) throw new Exception($"Failed to Find Spawned World Object Inventory Slot");
                     if(sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"Invalid InstancedItemId @ Inventory Slot");
                     var itemToEquipId = (Guid)sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];

                     //  DELETE ITEM TO EQUIP FROM CHARACTER INVENTORY TABLE
                     //DeleteSpawnedWorldObjectsInventory_ByInstancedItemId(itemToEquipId);
                     Instance._dataTableSelects.ResetSpawnedWorldInventory_ByInstancedItemId(itemToEquipId);
                     //  INSERT ITEM INTO CHARACTER EQUIPMENT
                     Instance._dataTableSelects.UpdateSpawnedWorldObjectsEquipment(spawnedWorldObjectId, itemToEquipId, equipmentSlotId);
                     
                     //DataRow dr = SpawnedWorldObjectsEquipmentDataTable.NewRow(); //  NEW ROW
                     //  POPULATE ROW WITH DATA
                     //dr = PopulateSpawnedWorldObjectsEquipmentDataRow(dr, spawnedWorldObjectId,  equipmentSlotId, itemToEquipId);
                     //  ADD ROW TO TABLE
                     //Instance._dataTables.SpawnedWorldObjectsBagsDataTable.Rows.Add(dr);
                     success = true;
                 }
                 else if (equipType == 2) //SWAP EQUIPPED ITEM WITH ITEM IN INVENTORY
                 {
                     // FIND instancedItemId for the EQUIPMENT ITEM TO UN-EQUIP.
                     var equipmentData = Instance._dataTableSelects.SpawnedWorldObjectsEquipmentSelectRows_BySpawnedWorldObjectId(spawnedWorldObjectId, equipmentSlotId);
                     DataRow sWOE = equipmentData[0];
                     var itemToUnEquipId = (Guid)sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId];

                     // FIND instancedItemId for the ITEM TO EQUIP.
                     DataRow sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(spawnedWorldObjectId, containerBagId, slotIndex);
                     if (sWOI == null) throw new Exception($"Failed to Find Spawned World Object Inventory Slot");
                     if(sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"Invalid InstancedItemId @ Inventory Slot");
                     var itemToEquipId = (Guid)sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                     
                     //  INSERT DE-EQUIPPED ITEM INTO CHARACTER INVENTORY
                     Instance._dataTableSelects.UpdateSpawnedWorldObjectsInventory(spawnedWorldObjectId, itemToUnEquipId, containerBagId, slotIndex);
                     //DataRow dr = SpawnedWorldObjectsInventoryDataTable.NewRow(); //  NEW ROW
                     //  POPULATE ROW WITH DATA
                     //dr = PopulateSpawnedWorldObjectsInventoryDataRow(dr, spawnedWorldObjectId, itemToUnEquipId, containerBagId, slotIndex);
                     //  ADD ROW TO TABLE
                     //SpawnedWorldObjectsInventoryDataTable.Rows.Add(dr);
                     
                     //  INSERT EQUIPPED ITEM INTO CHARACTER EQUIPMENT
                     Instance._dataTableSelects.UpdateSpawnedWorldObjectsEquipment(spawnedWorldObjectId, itemToEquipId, equipmentSlotId);
                     //DataRow newEquipmentDataRow = SpawnedWorldObjectsEquipmentDataTable.NewRow(); //  NEW ROW
                     //  POPULATE ROW WITH DATA
                     //newEquipmentDataRow = PopulateSpawnedWorldObjectsEquipmentDataRow(newEquipmentDataRow,  spawnedWorldObjectId, equipmentSlotId,itemToEquipId);
                     //  ADD ROW TO TABLE
                     //Instance._dataTables.SpawnedWorldObjectsBagsDataTable.Rows.Add(newEquipmentDataRow);
                     success = true;
                 }
             } 
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryEquip):{0} - 
                     Params: SpawnedWorldObjectId: {1}, equipmentSlotId: {2}, 
                     bagIndex: {3}, slotIndex: {4}, EquipType: {5}",
                     e.Message, spawnedWorldObjectId, equipmentSlotId, bagIndex, slotIndex, equipType));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryEquip took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryMergeStacks(
             Guid fromSpawnedWorldObjectId, 
             Guid toSpawnedWorldObjectId, 
             byte fromBagIndex,
             byte fromSlotIndex,
             byte fromQuantity,
             byte toBagIndex,
             byte toSlotIndex,
             byte toQuantity)
         {
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 //SELECT
                 var fromBagData = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedWorldObjectId, fromBagIndex); //From Character Bag Id
                 var toBagData = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(toSpawnedWorldObjectId, toBagIndex); //To Character Bag Id
                 DataRow from_sWOB = fromBagData[0];
                 int fromBagId = (int)from_sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 DataRow to_sWOB = toBagData[0];
                 int toBagId = (int)to_sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];

                 DataRow from_sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(fromSpawnedWorldObjectId, fromBagId, fromSlotIndex); //FROM_Stack ItemId
                 if (from_sWOI == null) throw new Exception($"Failed to Find From Inventory Slot");
                 if(from_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"Invalid From InstancedItemId @ Inventory Slot");
                 Guid fromStackItemId = (Guid)from_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                 

                 DataRow to_sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(toSpawnedWorldObjectId, toBagId, toSlotIndex); //TO_Stack ItemId
                 if (to_sWOI == null) throw new Exception($"Failed to Find To Inventory Slot");
                 if(to_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"Invalid To InstancedItemId @ Inventory Slot");
                 Guid toStackItemId = (Guid)to_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                 
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryMergeStacks):{0} - 
                     Params: FromSpawnedWorldObjectId: {1}, ToSpawnedWorldObjectId: {2}, 
                     FromSlotIndex: {3}, FromQuantity: {4}, ToSlotIndex: {5}, ToQuantity: {6}",
                     e.Message, fromSpawnedWorldObjectId, toSpawnedWorldObjectId, fromSlotIndex, fromQuantity, toSlotIndex, toQuantity));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryMergeStacks took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static bool Character_InventoryMove(
             Guid fromSpawnedWorldObjectId,
             byte fromBagIndex,
             byte fromSlotIndex,
             Guid toSpawnedWorldObjectId, 
             byte toBagIndex, 
             byte toSlotIndex)
         {
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success;
             //SELECT
             var fromBag = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedWorldObjectId, fromBagIndex);
             var toBag = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(toSpawnedWorldObjectId, toBagIndex);
             if(fromBag.Count == 0) throw new Exception($"Failed to Find From Bag");
             if(toBag.Count == 0) throw new Exception($"Failed to Find To Bag");
     
             DataRow spawnedWorldObjectsBagDataRow1 = fromBag[0];
             int fromBagId = (int)spawnedWorldObjectsBagDataRow1[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
             DataRow spawnedWorldObjectsBagDataRow2 = toBag[0];
             int toBagId = (int)spawnedWorldObjectsBagDataRow2[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
             
             var from_SWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(fromSpawnedWorldObjectId, fromBagId, fromSlotIndex);
             var to_SWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(toSpawnedWorldObjectId, toBagId, toSlotIndex);

             if(from_SWOI == null) throw new Exception($"Failed to Find From Inventory Slot");
             if(to_SWOI == null) throw new Exception($"Failed to Find To Inventory Slot");
             
             if(from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"Invalid From InstancedItemId @ Inventory Slot");
             Guid fromItemId = (Guid)from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];

             if (fromSpawnedWorldObjectId != toSpawnedWorldObjectId) //IF MOVING TO DIFFERENT CHARACTER
             { 
                 Logger!.Log($"Moving to different character");
                 if (to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value)
                 {
                     Logger.Log($"Moving to empty slot");
                     from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
                     to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = fromItemId;
                     
                     //UPDATE Item Ownership
                     DataRow from_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(fromItemId)[0];
                     from_iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] = toSpawnedWorldObjectId; // 
                     from_iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now; // 
                     success = true;
                 }
                 else
                 {
                     Logger.Log($"Swap!");
                     Guid toItemId = (Guid)to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                     from_SWOI.BeginEdit();
                     
                     from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = toItemId; // 
                     to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = fromItemId; // 
                     from_SWOI.EndEdit();

                     //UPDATE Item Ownership
                     DataRow from_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(fromItemId)[0];
                     from_iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] = toSpawnedWorldObjectId; // 
                     from_iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now; // 
                 
                     //UPDATE Item Ownership
                     DataRow to_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(toItemId)[0];
                     to_iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] = fromSpawnedWorldObjectId; // 
                     to_iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now; // 
                     success = true;
                 }
             }
             else //IF MOVING TO SAME CHARACTER
             {
                 Logger!.Log($"Moving to same character");

                 if (to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) //IF NO ITEM IN TO_LOCATION
                 {
                     from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
                     to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = fromItemId;
                     success = true;
                 }
                 else //ITEM IN TO_LOCATION
                 {
                     Guid toItemId = (Guid)to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                     from_SWOI.BeginEdit();
                     
                     from_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = toItemId; // 
                     to_SWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = fromItemId; // 
                     
                     from_SWOI.EndEdit();
                     success = true;

                 }
             }

             Logger.LogProfiling($"DataTableStoredProcs.Character_InventoryMove({success}) took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventoryRemoveItem(
             Guid spawnedWorldObjectId, 
             Guid instancedItemId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
                 
             try
             {
                 Instance!._dataTableSelects.ResetSpawnedWorldInventory_ByInstancedItemId(instancedItemId);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryRemoveItem):{0} - 
                     Params: SpawnedWorldObjectId: {1}, InstancedItemId: {2}",
                     e.Message, spawnedWorldObjectId, instancedItemId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryRemoveItem took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         private static bool Character_InventorySpawn(
             Guid spawnedWorldObjectId, 
             byte bagIndex,
             byte slotIndex, 
             Guid instancedItemId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             try
             {
                 //FIND SPAWNED WORLD OBJECT ID FOR BAG
                 var fromBag = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(spawnedWorldObjectId, bagIndex);
                 if (fromBag.Count == 1)
                 {
                     DataRow bagDataRow = fromBag[0];
                     int characterBagId = (int)bagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];

                     //  INSERT INTO CHARACTER INVENTORY
                     Instance._dataTableSelects.UpdateSpawnedWorldObjectsInventory(spawnedWorldObjectId,instancedItemId,characterBagId,slotIndex);
                     
                     
                     //DataRow dr = SpawnedWorldObjectsInventoryDataTable.NewRow(); //  NEW ROW
                     //  POPULATE ROW WITH DATA
                     //dr = PopulateSpawnedWorldObjectsInventoryDataRow(dr, spawnedWorldObjectId, instancedItemId, characterBagId, bagSlotIndex);
                     //  ADD ROW TO TABLE
                     //SpawnedWorldObjectsInventoryDataTable.Rows.Add(dr);
                     success = true;
                 }
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventorySpawn):{0} - Params: SpawnedWorldObjectId: {1},
                 BagIndex: {2}, SlotIndex: {3}, InstancedItemId: {4}", e.Message, spawnedWorldObjectId, bagIndex, slotIndex, 
                     instancedItemId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventorySpawn took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_InventorySplitStack(
             Guid fromSpawnedWorldObjectId,
             byte fromBagIndex, 
             byte fromSlotIndex, 
             byte fromQuantity,
             Guid toSpawnedWorldObjectId,
             byte toBagIndex,
             byte toSlotIndex,
             byte toQuantity,
             Guid instancedItemId)
         {
             
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;
             
              try
              {
                 //  GET From Character Bag Id
                 var fromBagData = Instance!._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(fromSpawnedWorldObjectId, fromBagIndex); 
                 DataRow fromBagDataRow = fromBagData[0];
                 int fromBagId = (int)fromBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId]; 
                 //  GET To Character Bag Id
                 var toBagData = Instance._dataTableSelects.SpawnedWorldObjectsBagsSelectRows(toSpawnedWorldObjectId, toBagIndex);
                 DataRow toBagDataRow = toBagData[0];
                 int toBagId = (int)toBagDataRow[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                 //  FIND ITEM TO SPLIT - FROM_Stack ItemId
                 var from_sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(fromSpawnedWorldObjectId, fromBagId, fromSlotIndex); 
                 if (from_sWOI == null || from_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] == DBNull.Value) throw new Exception($"From InstancedItemId is null");
                 {
                     Guid fromInstancedItemId = (Guid)from_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                     var to_sWOI = Instance._dataTableSelects.SpawnedWorldObjectsInventorySelectRow(toSpawnedWorldObjectId, toBagId, toSlotIndex); //TO_Stack ItemId
                     if (to_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] != DBNull.Value) //HANDLE SPLITTING INTO NON-EMPTY BAG SLOT
                     {
                         Guid toInstancedItemId = (Guid)to_sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                         //NON-EMPTY BAG SLOT STEP 1: UPDATE Quantity for FROM_Stack
                         DataRow from_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(fromInstancedItemId)[0];
                         from_iI[(byte)InstancedItemsColumns.quantity] = fromQuantity;

                         //NON-EMPTY BAG SLOT STEP 2: UPDATE Quantity TO_Stack
                         DataRow to_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(toInstancedItemId)[0];
                         to_iI[(byte)InstancedItemsColumns.quantity] = toQuantity;
                         success = true;
                     }
                     else //HANDLE SPLITTING INTO EMPTY BAG SLOT
                     {
                         //EMPTY BAG SLOT STEP 1: GET INFO TO CREATE NEW ITEM
                         DataRow from_iI = Instance._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(fromInstancedItemId)[0]; //FROM ITEM ID
                         string globalObject = (string)from_iI[(byte)InstancedItemsColumns.globalObject];
                         var rarityId = (byte)from_iI[(byte)InstancedItemsColumns.rarityId];
                         var qualityId = (byte)from_iI[(byte)InstancedItemsColumns.qualityId];
                         var durabilityPercentage = (float)(decimal) from_iI[(byte)InstancedItemsColumns.durabilityPercentage];
                         bool wasCrafted = (bool)from_iI[(byte)InstancedItemsColumns.wasCrafted];
                         string crafterName = from_iI[(byte)InstancedItemsColumns.crafterName].ToString();
                         bool wasLooted = (bool)from_iI[(byte)InstancedItemsColumns.wasLooted];

                         //EMPTY BAG SLOT STEP 2: CREATE NEW ITEM
                         InstancedItems_SplitCreateGuid(globalObject, rarityId, qualityId,toQuantity, 
                             durabilityPercentage, wasCrafted, crafterName, wasLooted, toSpawnedWorldObjectId, instancedItemId);

                         //EMPTY BAG SLOT STEP 3: ADD NEW ITEM TO BAG
                         Character_InventorySpawn(toSpawnedWorldObjectId, toBagIndex, toSlotIndex, instancedItemId);
                         
                         //EMPTY BAG SLOT STEP 4: UPDATE Item Quantity for Original Stack
                         from_iI[(byte)InstancedItemsColumns.quantity] = fromQuantity; //UPDATE Item Quantity for FROM_Stack
                         success = true;
                     }
                 
                 }

             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_InventorySplitStack):{e.Message} - 
                     Params: FromSpawnedWorldObjectId: {fromSpawnedWorldObjectId}, ToSpawnedWorldObjectId: {toSpawnedWorldObjectId}, 
                     FromSlotIndex: {fromSlotIndex}, FromQuantity: {fromQuantity}, ToSlotIndex: {toSlotIndex}, ToQuantity: {toQuantity}, 
                     InstancedItemId: {instancedItemId}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventorySplitStack took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_InventoryUpdateQuantity(Guid instancedItemId, byte quantity)
         {

             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success                    = false;

             try
             {
                 DataRow iI = Instance!._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 iI[(byte)InstancedItemsColumns.quantity]   = quantity;
                 iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now;
                 if (quantity == 0)
                 {
                     
                     Instance._dataTableSelects.ResetSpawnedWorldInventory_ByInstancedItemId(instancedItemId);
                     iI[(byte)InstancedItemsColumns.status] = GlobalStatusTypes.Deleted.ToString().ToLower();
                 }

                 success = true;
             }
             catch (NullReferenceException e)
             {
                 throw;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_InventoryUpdateQuantity): {0} - 
                     Params: InstancedItemId: {1}, Quantity: {2}",
                     e.Message, instancedItemId, quantity));
                 success = false;
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_InventoryUpdateQuantity took {watch!.ElapsedTicks/10000f} ms");
             
             return success;
         }

         public static bool Character_MailDelete(Guid mailId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             try
             {
                 DataRow dr = Instance!._dataTableSelects.CharactersMailSelectRows(mailId)[0];
                 dr[(byte)CharactersMailColumns.deletedbyPlayerDateTime] = DateTime.Now;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_MailDelete): {e.Message} - 
                     Params: MailId: {mailId}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_MailDelete took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_MailSend(Guid mailId, byte mailIndex, int senderCharacterId,
             string? senderName, string mailSubject, string mailBody, uint gold, byte silver, byte copper, bool currencyClaimed,
              bool contentsClaimed, bool unread, int recipientCharacterId, long sentDateTimeBinary, long appearDateTimeBinary,
             long deleteDateTimeBinary)
         {
             Logger!.Log($"Character_MailSend");
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 if (string.IsNullOrEmpty(senderName)) senderName = "UNKNOWN";

                 Instance!._dataTableSelects.AddCharactersMailDataRow(mailId, mailIndex, senderCharacterId, senderName, 
                 mailSubject, mailBody, gold, silver, copper, currencyClaimed, contentsClaimed, unread, recipientCharacterId,
                 DateTime.FromBinary(sentDateTimeBinary), DateTime.FromBinary(appearDateTimeBinary), DateTime.FromBinary(deleteDateTimeBinary));
                 //  ADD ROW TO TABLE
                 success = true;
             }
             catch (Exception e)
             {
                 Logger.LogError(string.Format(@"SQL EXCEPTION (Character_MailSend): {0} - 
                     Params: MailId: {1}, MailIndex: {2}, SenderCharacterId: {3},
                     SenderName: {4}, MailSubject: {5}, MailBody: {6}, Gold: {7}, Silver: {8},
                     Copper: {9}, CurrencyClaimed: {10}, ContentsClaimed: {11}, Unread: {12}, 
                     RecipientCharacterId: {13}, SentDateTime: {14}, 
                     DeleteDateTime: {15}, AppearDateTime: {16}", e.Message, mailId,
                     mailIndex, senderCharacterId, senderName, mailSubject, mailBody, gold, silver, copper, currencyClaimed,
                     contentsClaimed, unread, recipientCharacterId, DateTime.FromBinary(sentDateTimeBinary), DateTime.FromBinary(deleteDateTimeBinary), DateTime.FromBinary(appearDateTimeBinary)));
             }

             Logger.LogProfiling($"DataTableStoredProcs.Character_MailSend took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static bool Character_MailSendAttachments(Guid mailId, Guid instancedItemId, byte slotIndex, long sentDateTimeBinary)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             var sentDateTime    = DateTime.FromBinary(sentDateTimeBinary);
             try
             {
                 //  NEW ROW
                 DataRow dr = Instance!._dataTables.CharactersMailAttachmentsDataTable.NewRow();
                 //  POPULATE ROW WITH DATA
                 
                 dr = Instance._dataTableSelects.PopulateCharactersMailAttachmentsDataRow(dr, mailId, instancedItemId, slotIndex, sentDateTime);
                 //  ADD ROW TO TABLE
                 Instance._dataTables.CharactersMailAttachmentsDataTable.Rows.Add(dr);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_MailSendAttachments): {0} - 
                     Params: MailId: {1}, InstancedItemId: {2}, SlotIndex: {3}, SentDateTime: {4}",
                     e.Message, mailId, instancedItemId, slotIndex, sentDateTime));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_MailSendAttachments took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_MailTakeAttachment(Guid mailId, byte slotIndex)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             try
             {
                 var charactersMailAttachmentsData = Instance!._dataTableSelects.CharactersMailAttachmentsSelectRows(mailId, slotIndex);
                 DataRow charactersMailAttachmentsDataRow = charactersMailAttachmentsData[0];
                 charactersMailAttachmentsDataRow[(byte)CharactersMailAttachmentsColumns.takenbyPlayerDateTime] = DateTime.Now;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_MailTakeAttachment): {0} - 
                     Params: MailId: {1}, SlotIndex: {2}",
                     e.Message, mailId, slotIndex));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_MailTakeAttachment took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_MailClaimCurrency(Guid mailId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 var charactersMailData = Instance!._dataTableSelects.CharactersMailSelectRows(mailId);
                 charactersMailData[0][(byte)CharactersMailColumns.currencyClaimed] = true;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_MailClaimCurrency): {e.Message} - 
                     Params: MailId: {mailId}");
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MailClaimCurrency took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_MailClaimContents(Guid mailId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 var charactersMailData = Instance!._dataTableSelects.CharactersMailSelectRows(mailId);
                 DataRow charactersMailDataRow = charactersMailData[0];
                 charactersMailDataRow[(byte)CharactersMailColumns.contentsClaimed] = true;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_MailClaimContents): {e.Message} - 
                     Params: MailId: {mailId}");
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MailClaimContents took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_MailRead(Guid mailId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;

             try
             {
                 var charactersMailData = Instance!._dataTableSelects.CharactersMailSelectRows(mailId);
                 DataRow charactersMailDataRow = charactersMailData[0];
                 charactersMailDataRow[(byte)CharactersMailColumns.unread] = false;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError($@"SQL EXCEPTION (Character_MailRead): {e.Message} - 
                     Params: MailId: {mailId}");
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MailRead took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_MissionAbandoned(int characterId, Guid missionId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;
             
             try
             {
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_MissionAbandoned): {0} - 
                     Params: CharacterId: {1}, MissionId: {2}", 
                     e.Message, characterId, missionId));
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MissionAbandoned took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static bool Character_MissionAccepted(int characterId, Guid missionId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success                    = false;

             try
             {
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_MissionAccepted): {0} - 
                     Params: CharacterId: {1}, MissionId: {2}", 
                     e.Message, characterId, missionId));
             }
             
             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MissionAccepted took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_MissionCompleted(int characterId, Guid missionId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success                    = false;
             
             try
             {
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_MissionCompleted): {0} - 
                     Params: CharacterId: {1}, MissionId: {2}", 
                     e.Message, characterId, missionId));
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_MissionCompleted took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_QuestAbandoned(int characterId, string questGlobalObject)
         {
             Stopwatch? watch = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;
             
             try
             {
                 var charactersQuestsDataRow = Instance!._dataTableSelects.CharactersQuestsSelectRow(characterId, questGlobalObject);
                 if(charactersQuestsDataRow == null) throw new Exception($"Failed to Find Character Quest");
                 charactersQuestsDataRow[(byte)CharactersQuestsColumns.questStatusId] = (1); //
          
                 success = true;
                 
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestAbandoned): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}",    
                     e.Message, characterId, questGlobalObject));
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestAbandoned took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }     
         
         public static bool Character_QuestAccepted(int characterId, string questGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             
             bool success = false;
             
             try
             {
                 
                 var charactersQuestsDataRow = Instance!._dataTableSelects.CharactersQuestsSelectRow(characterId, questGlobalObject);
                 success = true;
                 if (charactersQuestsDataRow != null) //QUEST ALREADY EXISTS (WAS ABANDONED)
                 {
                     charactersQuestsDataRow[(byte)CharactersQuestsColumns.questStatusId] = (0); //SET QUEST STATUS TO ACTIVE
                     Character_QuestInsertUpdateObjectives(characterId, questGlobalObject);
                     //INSERT QUEST OBJECTIVES
                     //Character_QuestInsertObjectives(questGlobalObject, characterId);
                 }
                 else //QUEST DOES NOT EXIST
                 {
                     //INSERT QUEST
                     DataRow charactersQuestDataRow = Instance._dataTables.CharactersQuestsDataTable.NewRow();
                     charactersQuestDataRow[(byte)CharactersQuestsColumns.characterId] = (characterId);
                     charactersQuestDataRow[(byte)CharactersQuestsColumns.questGlobalObject] = (questGlobalObject);
                     charactersQuestDataRow[(byte)CharactersQuestsColumns.questStatusId] = (0); //
                     Instance._dataTables.CharactersQuestsDataTable.Rows.Add(charactersQuestDataRow);
                     
                     //INSERT QUEST OBJECTIVES
                     Character_QuestInsertObjectives(questGlobalObject, characterId);
                 }
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestAccepted): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}",    
                     e.Message, characterId, questGlobalObject));
             }

             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestAccepted took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_QuestInsertObjectives(string questGlobalObject, int characterId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 var scriptableQuestObjectivesData = Instance!._dataTableSelects.ScriptableQuestObjectivesSelectRows(questGlobalObject);
                 foreach (DataRow scriptableQuestObjectiveModelRow in scriptableQuestObjectivesData)
                 {
                     DataRow charactersQuestObjectiveModelRow = Instance._dataTables.CharactersQuestsObjectivesDataTable.NewRow();
                     charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.characterId] = (characterId);
                     charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.questGlobalObject] = questGlobalObject;
                     charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.objectiveGlobalObject] = 
                         scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.objectiveGlobalObject];
                     charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.numRequired] = scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.numRequired];
                     charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.currentProgress] = (0); //
                     Instance._dataTables.CharactersQuestsObjectivesDataTable.Rows.Add(charactersQuestObjectiveModelRow);
                 }
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestInsertObjectives): {0} - 
                     Params: SpawnedWorldObjectId: {1}, globalObject: {2}",    
                     e.Message, characterId, questGlobalObject));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestInsertObjectives took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

         public static bool Character_QuestInsertUpdateObjectives(int characterId, string questGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             try
             {
                 var scriptableQuestObjectivesData = Instance!._dataTableSelects.ScriptableQuestObjectivesSelectRows(questGlobalObject);
                 foreach (DataRow scriptableQuestObjectiveModelRow in scriptableQuestObjectivesData)
                 {

                     var charactersQuestsObjectivesData = Instance._dataTableSelects.CharactersQuestsObjectivesSelectRows(characterId, questGlobalObject,
                         scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.objectiveGlobalObject].ToString());
                     if (charactersQuestsObjectivesData.Count == 1) //IF EXISTS, UPDATE
                     {
                         DataRow charactersQuestsObjectivesDataRow = charactersQuestsObjectivesData[0];
                         charactersQuestsObjectivesDataRow[(byte)CharactersQuestsObjectivesColumns.numRequired] =
                             scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.numRequired];
                         charactersQuestsObjectivesDataRow[(byte)CharactersQuestsObjectivesColumns.currentProgress] = (0); //
                     }
                     else //IF NOT EXISTS, INSERT
                     {
                         DataRow charactersQuestObjectiveModelRow = Instance._dataTables.CharactersQuestsObjectivesDataTable.NewRow();
                         charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.characterId] = 
                             characterId;
                         charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.questGlobalObject] = 
                             questGlobalObject;
                         charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.objectiveGlobalObject] = 
                             scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.objectiveGlobalObject];
                         charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.numRequired] =
                             scriptableQuestObjectiveModelRow[(byte)ScriptableQuestObjectivesColumns.numRequired];
                         charactersQuestObjectiveModelRow[(byte)CharactersQuestsObjectivesColumns.currentProgress] = (0); //
                         Instance._dataTables.CharactersQuestsObjectivesDataTable.Rows.Add(charactersQuestObjectiveModelRow);
                     }
                 }
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestInsertUpdateObjectives): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}",    
                     e.Message, characterId, questGlobalObject));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestInsertUpdateObjectives took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_QuestCompleted(int characterId, string questGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             try
             {
                 var     cQs = Instance!._dataTableSelects.CharactersQuestsSelectRows(characterId, questGlobalObject);
                 DataRow cQ  = cQs[0];
                 cQ[(byte)CharactersQuestsColumns.questStatusId] = (2); //
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestCompleted): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}",    
                     e.Message, characterId, questGlobalObject));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestCompleted took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static bool Character_QuestUpdate(int characterId, string questGlobalObject, string objectiveGlobalObject, int currentProgress)   
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 var charactersQuestsObjectivesData = Instance!._dataTableSelects.CharactersQuestsObjectivesSelectRows(characterId, questGlobalObject, objectiveGlobalObject);
                 if (charactersQuestsObjectivesData.Count == 1) 
                 {
                     DataRow charactersQuestsObjectiveDataRow = charactersQuestsObjectivesData[0];
                     charactersQuestsObjectiveDataRow[(byte)CharactersQuestsObjectivesColumns.currentProgress] = (currentProgress);
                     success = true;
                 }
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_QuestUpdate): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}, objectiveGlobalObject: {3}, currentProgress: {4}",    
                     e.Message, characterId, questGlobalObject,objectiveGlobalObject, currentProgress));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_QuestUpdate took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_RecipeAdd(int characterId, string recipeGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 Instance!._dataTableSelects.AddCharactersRecipesDataRow(characterId, recipeGlobalObject);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(
                     $@"SQL EXCEPTION (Character_RecipeAdd): {e.Message} - Params: CharacterId: {characterId}, 
                 RecipeGlobalObject: {recipeGlobalObject}");
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_RecipeAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
      
         public static bool Character_SkillsAdd(int characterId, string globalObject, ushort skillId, int characterSkillExperience,
             byte characterSkillRankId, byte characterSkillLevelId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             try
             {
                 Instance!._dataTableSelects.AddCharactersSkillsDataRow(characterId, globalObject, (int)characterSkillExperience);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_SkillsAdd): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}, 
                     skillId: {3}, CharacterSkillExperience: {4}, 
                     RankId: {5}, Level: {6}",    
                     e.Message, characterId, globalObject, skillId, characterSkillExperience, characterSkillRankId, characterSkillLevelId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_SkillsAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_SkillsUpdate(int characterId, string globalObject, int experienceAdded, byte characterSkillRankId, byte characterSkillLevelId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 DataRow cHS = Instance!._dataTableSelects.CharactersSkillsSelectRow(characterId, globalObject);
                 int currentSkillExperience = 
                     (int)cHS[(byte)CharactersSkillsColumns.characterSkillExperience];
                 cHS[(byte)CharactersSkillsColumns.characterSkillExperience] 
                     = (currentSkillExperience + experienceAdded); //

                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_SkillsUpdate): {0} - 
                     Params: CharacterId: {1}, globalObject: {2}, 
                     ExperienceGained: {3}, RankId: {4}, Level: {5}",    
                     e.Message, characterId, globalObject, experienceAdded, characterSkillRankId, characterSkillLevelId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_SkillsUpdate took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_TitlesUnlock(int characterId, string titleGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             try
             {
                 Instance!._dataTableSelects.AddCharactersTitlesDataRow(characterId, titleGlobalObject);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_TitleAdd):{0} - 
                     Params: CharacterId: {1}, TitleGlobalObject: {2}", e.Message, 
                     characterId, titleGlobalObject));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_AbilitiesAdd took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_SaveExperience(int characterId, int characterExperience, byte rankId, byte levelId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             try
             {
                 //  GET ROW TO UPDATE
                 var cH = Instance!._dataTables.CharactersDictionaryByCharacterId[characterId];
                 //  UPDATE ROW DATA
                 cH.BeginEdit();
                 cH[(byte)CharactersColumns.characterExperience] = characterExperience;
                 cH[(byte)CharactersColumns.characterTierId] = rankId;
                 cH[(byte)CharactersColumns.characterRankId] = levelId;
                 cH[(byte)CharactersColumns.lastUpdated] = DateTime.Now;
                 cH.EndEdit();
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_SaveExperience): {0} - 
                     Params: CharacterId: {1}, CharacterExperience: {2}, 
                     RankId: {3}, LevelId: {4}",  
                     e.Message, characterId, characterExperience, rankId, levelId));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_SaveExperience took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_SaveLocation(Guid spawnedWorldObjectId, double coordinateX, double coordinateY, double coordinateZ, int chunk, double rotationX, double rotationY, double rotationZ)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             try
             {
                 //  GET ROW TO UPDATE
                 if (!Instance!._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) throw new Exception($"Failed to Save Location - Spawned World Object not found");
                 var sWO = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];

                 //  UPDATE ROW DATA
                 sWO[(byte)SpawnedWorldObjectsColumns.coordinateX] = coordinateX;
                 sWO[(byte)SpawnedWorldObjectsColumns.coordinateY] = coordinateY;
                 sWO[(byte)SpawnedWorldObjectsColumns.coordinateZ] = coordinateZ;
                 sWO[(byte)SpawnedWorldObjectsColumns.rotationX] = rotationX;
                 sWO[(byte)SpawnedWorldObjectsColumns.rotationY] = rotationY;
                 sWO[(byte)SpawnedWorldObjectsColumns.rotationZ] = rotationZ;
                 sWO[(byte)SpawnedWorldObjectsColumns.lastUpdate] = DateTime.Now;
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_SaveLocation): {0} - 
                     Params: spawnedWorldObjectId: {1}, CoordinateX: {2}, 
                     CoordinateY: {3}, CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, 
                     RotationY: {7}, RotationZ: {8}",    
                     e.Message, spawnedWorldObjectId, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_SaveLocation took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         public static bool Character_StatsUpdate(int characterId, byte statTypeId, byte statId, float characterStatValue)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;

             try
             {
                 var cSRows = Instance!._dataTableSelects.CharactersStatsSelectRows(characterId, statTypeId, statId);
                 DataRow cS = cSRows[0];
                 cS[(byte)CharactersStatsColumns.characterStatValue] = characterStatValue; //
             
                 success = true;
             
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_StatsUpdate): {0} - 
                     Params: CharacterId: {1}, StatTypeId: {2}, 
                     StatId: {3}, StatValue: {4}",    
                     e.Message, characterId, statTypeId, statId, characterStatValue));
             }

             Logger!.LogProfiling($"DataTableStoredProcs.Character_StatsUpdate took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }

        #endregion
        #region DATA TABLE STP GETS: HISTORY

         public static List<CollectedHistoryModel> Character_HistoryCollectedGetList(int characterId)
         {
             List<CollectedHistoryModel> collectedHistory = new List<CollectedHistoryModel>();

             foreach (DataRow hC in Instance!._dataTableSelects.HistoryCharacterCollectedSelectRows(characterId))
             {
                 byte   rarityId           = (byte)hC[(byte)HistoryCharacterCollectedColumns.rarityId];
                 string itemGlobalObject = (string)hC[(byte)HistoryCharacterCollectedColumns.itemGlobalObject];
                 byte   quantity           = (byte)hC[(byte)HistoryCharacterCollectedColumns.quantity];

                 var craftedData = new CollectedHistoryModel(rarityId, itemGlobalObject, quantity);
                 collectedHistory.Add(craftedData);
             }
             return collectedHistory;
         }
         
         public static List<CraftedHistoryModel> Character_HistoryCraftedGetList(int characterId)
         {
             List<CraftedHistoryModel> craftedHistory = new List<CraftedHistoryModel>();

             foreach (DataRow hC in Instance!._dataTableSelects.HistoryCharacterCraftedSelectRows(characterId))
             {
                 byte   rarityId           = (byte)hC[(byte)HistoryCharacterCraftedColumns.rarityId];
                 string itemGlobalObject = (string)hC[(byte)HistoryCharacterCraftedColumns.itemGlobalObject];
                 byte   quantity           = (byte)hC[(byte)HistoryCharacterCraftedColumns.quantity];

                 var craftedData = new CraftedHistoryModel(rarityId, itemGlobalObject, quantity);
                 craftedHistory.Add(craftedData);
             }
             return craftedHistory;
         }

         public static List<GatheredHistoryModel> Character_HistoryGatheredGetList(int characterId)
         {
             List<GatheredHistoryModel> gatherHistory = new List<GatheredHistoryModel>();

             foreach (DataRow hG in Instance!._dataTableSelects.HistoryCharacterGatheredSelectRows(characterId))
             {
                 string gatherableGlobalObject = (string)hG[(byte)HistoryCharacterGatheredColumns.gatherableGlobalObject];
                 byte rankId = (byte)hG[(byte)HistoryCharacterGatheredColumns.rankId];
                 byte variationId = (byte)hG[(byte)HistoryCharacterGatheredColumns.variationId];
                 var gatheredData = new GatheredHistoryModel(gatherableGlobalObject, rankId, variationId);
                 gatherHistory.Add(gatheredData);
             }

             return gatherHistory;
         }
         
         public static List<KillHistoryModel> Character_HistoryKillsGetList(int characterId)
         {
             List<KillHistoryModel> killHistory = new List<KillHistoryModel>();

             foreach (DataRow hK in Instance!._dataTableSelects.HistoryCharacterKillsSelectRows(characterId))
             {
                 string entityGlobalObject = (string)hK[(byte)HistoryCharacterKillsColumns.entityGlobalObject];
                 var killData = new KillHistoryModel(entityGlobalObject);
                 killHistory.Add(killData);
             }

             return killHistory;
         }

         #endregion
         #region DATA TABLE STP INSERT / UPDATES / DELETES: HISTORY

         public static bool Character_HistoryAddCollected(int characterId, byte rarityId, string itemGlobalObject, 
         byte quantity)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             Instance!._dataTableSelects.AddHistoryCharacterCollectedDataRow(characterId, rarityId,itemGlobalObject, quantity);

             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddCollected took {watch!.ElapsedTicks/10000f} ms");
             var success = true;
             return success;
         }
         
         public static bool Character_HistoryAddCombat(int characterId, int blocks, int blocked, int strikesReceived, 
             int strikesGiven, int damageReceived, int damageGiven)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             Instance!._dataTableSelects.AddHistoryCharacterCombatDataRow(characterId, blocks, blocked, strikesReceived, strikesGiven,damageReceived, damageGiven);
             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddCombat took {watch!.ElapsedTicks/10000f} ms");
             var success = true;
             return success;
         }
         
         public static bool Character_HistoryAddCrafted(int characterId, byte rarityId, string itemGlobalObject, byte quantity)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             //  NEW ROW
             Instance!._dataTableSelects.AddHistoryCharacterCraftedDataRow(characterId, rarityId, itemGlobalObject,quantity);
             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddCrafted took {watch!.ElapsedTicks/10000f} ms");

             var success = true;
             return success;
         }
         
         public static bool Character_HistoryAddDeath(int characterId, Guid killedBySpawnedWorldId, int globalTierId, int globalRankId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew(); 
             Instance!._dataTableSelects.AddHistoryCharacterDeathDataRow(characterId, killedBySpawnedWorldId, globalTierId, globalRankId);
             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddDeath took {watch!.ElapsedTicks/10000f} ms");
             var success = true;
             return success;
         }
         
         public static void Character_HistoryAddGathered(int characterId, string gatherableGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             

             try
             {
                 Instance!._dataTableSelects.AddHistoryCharacterGatheredDataRow(characterId, gatherableGlobalObject);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_HistoryAddGathered): {0} - 
                     Params: CharacterId: {1}, GatherableGlobalObject: {2}",    
                     e.Message, characterId, gatherableGlobalObject));
             }
             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddGathered took {watch!.ElapsedTicks/10000f} ms");
             //return success;
         }

         public static bool Character_HistoryAddKill(int characterId, byte entityTierId, string entityGlobalObject)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
             bool success = false;
             

             try
             {
                 Instance!._dataTableSelects.AddHistoryCharacterKillsDataRow(characterId, entityTierId, entityGlobalObject);
                 success = true;
             }
             catch (Exception e)
             {
                 Logger!.LogError(string.Format(@"SQL EXCEPTION (Character_HistoryAddKill): {0} - 
                     Params: CharacterId: {1}, EntityTierId: {2}, EntityGlobalObject: {3}",    
                     e.Message, characterId, entityTierId, entityGlobalObject));      
             }
             Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddKill took {watch!.ElapsedTicks/10000f} ms");
             return success;
         }
         
         public static bool Character_HistoryAddLooted(int characterId, string itemGlobalObject, byte rarityId, byte quantity)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();


             Instance!._dataTableSelects.AddHistoryCharacterLootedDataRow(characterId, itemGlobalObject, rarityId, quantity);
             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddLooted took {watch!.ElapsedTicks/10000f} ms");
             var success = true;
             
             return success;
         }
         
         public static bool Character_HistoryAddQuest(int characterId,
             byte questTypeId, byte questTierId, byte questRankId)
         {
             Stopwatch? watch                = null;
             if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

             Instance!._dataTableSelects.AddHistoryCharacterQuestDataRow(characterId, questTypeId, questTierId, questRankId);
             if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.Character_HistoryAddQuest took {watch!.ElapsedTicks/10000f} ms");
             var success = true;
             

             return success;
         }

         public static List<CharacterStatusEffectData> Character_StatusEffectsGetList(int characterId)
         {
             var statusEffects = new List<CharacterStatusEffectData>();
             if (Instance._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject
                 .ContainsKey(characterId))
             {

                 foreach (var statusEffect in Instance._dataTables
                              .CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject[characterId]
                              .Values)
                 {
                     statusEffects.Add(new CharacterStatusEffectData(
                         (string)statusEffect[(byte)CharactersStatusEffectsColumns.effectGroupGlobalObject],
                         (float)(double)statusEffect[(byte)CharactersStatusEffectsColumns.remainingDuration],
                         (byte)statusEffect[(byte)CharactersStatusEffectsColumns.stacks]));
                 }
             }
             else Logger.LogError($"No Status Effects found!");
             return statusEffects;
         }
         public static bool Character_StatusEffectsAdd(int characterId,       string effectGroupGlobalObject,
             float                                         remainingDuration, byte stacks)
         {
             var success = true;

             var cSE = Instance!._dataTableSelects.AddCharactersStatusEffectsDataRow(characterId, effectGroupGlobalObject, remainingDuration, stacks);
             Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject.TryAdd(characterId, new Dictionary<string, DataRow>());
             Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject[characterId].TryAdd(effectGroupGlobalObject, cSE);
             
             return success;
         }

         public static bool Character_StatusEffectsUpdate(int characterId,       string effectGroupGlobalObject,
             float                                            remainingDuration, byte stacks)
         {
             Logger.LogDebug(
                 $"Character_StatusEffectsUpdate: {characterId}, {effectGroupGlobalObject}, {remainingDuration}, {stacks}");
             var success = true;

             if (!Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject.ContainsKey((characterId))) return false;
             if (!Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject[characterId].ContainsKey(effectGroupGlobalObject)) return false;
             
             var cSE = Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject
                 [characterId][effectGroupGlobalObject];

             Logger!.LogDebug($"{cSE[(byte)CharactersStatusEffectsColumns.remainingDuration]} => {remainingDuration}");
             cSE[(byte)CharactersStatusEffectsColumns.remainingDuration] = remainingDuration;
             cSE[(byte)CharactersStatusEffectsColumns.stacks]            = stacks;

             return success;
         }
         
         public static bool Character_StatusEffectsRemove(int characterId,       string effectGroupGlobalObject)
         {
             Logger.Log($"Character_StatusEffectsRemove: {characterId}, {effectGroupGlobalObject}");
             //if (!Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject.ContainsKey((characterId))) return false;
             //if (!Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject[characterId].ContainsKey(effectGroupGlobalObject)) return false;
             
             var cSE = Instance!._dataTables.CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject
                 [characterId][effectGroupGlobalObject];

             cSE.Delete();
             Instance._dataTables.CharactersStatusEffectsDataTable.Rows.Remove(cSE);
             Instance!._dataTables
                 .CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject[characterId]
                 .Remove(effectGroupGlobalObject);
                 return true;
         }

         #endregion
         
         #region DATA TABLE STP GETS: INSTANCED
         public static List<SpawnedEquipmentModel> InstancedItems_ArmorGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedEquipmentModel> armor = new List<SpawnedEquipmentModel>();
             foreach (DataRow iA in Instance!._dataTables.InstancedArmorDataTable.Select()) 
             {
                 Guid instancedItemId = (Guid)iA[(byte)InstancedArmorColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if (spawnedWorldObjectId != (Guid)iI[(byte)InstancedItemsColumns.spawnedWorldObjectId]) continue;
                 
                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];
                 
                 SpawnedEquipmentModel armorModel = new SpawnedEquipmentModel(instancedItemId, globalObject,maxStack, quantity, rarityId,
                     qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted, (byte)EquipmentTypes.Armor);
                 armor.Add(armorModel);
             }
             return armor;
         }
         public static List<SpawnedEquipmentModel> Character_Equipment_InstancedItems_EquipmentGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedEquipmentModel> armor = new List<SpawnedEquipmentModel>();
             foreach (DataRow sWoe in Instance!._dataTables.SpawnedWorldObjectsEquipmentDictionary[spawnedWorldObjectId]) 
             {
                 if(sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] == DBNull.Value) continue;
                 
                 Guid instancedItemId = (Guid)sWoe[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 
                 string globalObject = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 if(!Instance._dataTables.ScriptableEquipmentDictionary.ContainsKey(globalObject)) continue;
                 var sE  = Instance._dataTables.ScriptableEquipmentDictionary[globalObject];

                 var quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];
                 
                 SpawnedEquipmentModel armorModel = new SpawnedEquipmentModel(instancedItemId, globalObject,maxStack, quantity, rarityId,
                     qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted, (byte)sE[(byte)ScriptableEquipmentColumns.equipmentMainTypeId]);
                 armor.Add(armorModel);
             }
             return armor;
         }
         
         public static List<SpawnedEquipmentModel> InstancedItems_ArmorGetAll()
         {
             List<SpawnedEquipmentModel> armor = new List<SpawnedEquipmentModel>();
             
             foreach (DataRow iA in Instance!._dataTables.InstancedArmorDataTable.Select()) 
             {
                 Guid instancedItemId = (Guid)iA[(byte)InstancedArmorColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;


                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedEquipmentModel armorModel = new SpawnedEquipmentModel(instancedItemId, globalObject, quantity, maxStack, rarityId, qualityId,
                     durabilityPercentage, wasCrafted, crafterName, wasLooted, (byte)EquipmentTypes.Armor);
                 armor.Add(armorModel);
             }
             return armor;
         }

         public static List<SpawnedBagModel> InstancedItems_BagsGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedBagModel> bags = new List<SpawnedBagModel>();
             
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             foreach (DataRow iB in Instance!._dataTables.InstancedBagsDataTable.Select())
             {
                 var instancedItemId = (Guid) (iB[(byte)InstancedBagsColumns.instancedItemId]);
                 var iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if (spawnedWorldObjectId != (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])) continue;


                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 var    glO                  = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];
                 var    bagSize              = (byte)iB[(byte)InstancedBagsColumns.slots];
                 SpawnedBagModel bagModel = new SpawnedBagModel(instancedItemId, globalObject, quantity,maxStack, rarityId, qualityId, 
                     durabilityPercentage, wasCrafted, crafterName, wasLooted, bagSize);
                 bags.Add(bagModel);

             }
             return bags;
         }

         public static List<SpawnedBagModel> InstancedItems_BagsGetAll()
         {
             List<SpawnedBagModel> bags = new List<SpawnedBagModel>();
             
             foreach (DataRow iB in Instance!._dataTables.InstancedBagsDataTable.Select())
             {
                 var instancedItemId = (Guid)(iB[(byte)InstancedBagsColumns.instancedItemId]);
                 var iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 string globalObject = (string)iI[(byte)InstancedItemsColumns.globalObject];

                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];
                 var    bagSize              = (byte)iB[(byte)InstancedBagsColumns.slots];
                 SpawnedBagModel bagModel = new SpawnedBagModel(instancedItemId, globalObject,quantity, maxStack, rarityId,
                     qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted, bagSize);
                 bags.Add(bagModel);
             }
             return bags;
         }

         public static List<SpawnedItemModel> InstancedItems_ConsumablesGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedItemModel> consumables = new List<SpawnedItemModel>();
             
             //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
             foreach  (DataRow iC in Instance!._dataTables.InstancedConsumablesDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iC[(byte)InstancedConsumablesColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if (spawnedWorldObjectId != (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])) continue;

                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedItemModel consumableModel = new SpawnedItemModel(instancedItemId, globalObject, quantity,maxStack, rarityId, 
                     qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                 consumables.Add(consumableModel);
             }
             return consumables;
         }

         public static List<SpawnedItemModel> InstancedItems_ConsumablesGetAll()
         {
             List<SpawnedItemModel> consumables = new List<SpawnedItemModel>();
             
             foreach (DataRow iC in Instance!._dataTables.InstancedConsumablesDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iC[(byte)InstancedConsumablesColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedItemModel consumableModel = new SpawnedItemModel(instancedItemId, globalObject, quantity,maxStack, rarityId, qualityId,
                     durabilityPercentage, wasCrafted, crafterName, wasLooted);
                 consumables.Add(consumableModel);
             }
             return consumables;
         }

         public static List<SpawnedItemModel> InstancedItems_GeneralItemsGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedItemModel> generalItems         = new List<SpawnedItemModel>();
             foreach (DataRow iGI in Instance!._dataTables.InstancedGeneralItemsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iGI[(byte)InstancedGeneralItemsColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if (spawnedWorldObjectId != (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])) continue;
    
                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedItemModel generalItemModel = new SpawnedItemModel(instancedItemId, globalObject, quantity,maxStack, rarityId, qualityId,
                     durabilityPercentage, wasCrafted, crafterName, wasLooted);
                 generalItems.Add(generalItemModel);
             }
             return generalItems;
         }

         public static List<SpawnedItemModel> InstancedItems_GeneralItemsGetAll()
         {
             List<SpawnedItemModel> generalItems = new List<SpawnedItemModel>();
             
             foreach (DataRow iGI in Instance!._dataTables.InstancedGeneralItemsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iGI[(byte)InstancedGeneralItemsColumns.instancedItemId];
                 var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 
                 byte   quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 byte   maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 byte   rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 byte   qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 float  durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 bool   wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 string crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 bool   wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedItemModel generalItemModel = new SpawnedItemModel(instancedItemId, globalObject,quantity, maxStack, rarityId, qualityId,
                     durabilityPercentage, wasCrafted, crafterName, wasLooted);
                 generalItems.Add(generalItemModel);
             }
             return generalItems;
         }

         public static Dictionary<Guid,List<IngredientModel>> InstancedItems_IngredientsGetAll()
         {
             Dictionary<Guid,List<IngredientModel>> ingredientData = new Dictionary<Guid,List<IngredientModel>>();
             
             foreach (var iI in Instance!._dataTables.InstancedItemsDataTable.Select())
             {
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 
                 //string globalObject       = (string) iI[(byte)InstancedItemsColumns.globalObject];
                 var recipeGlobalObject = iI[(byte)InstancedItemsColumns.recipeGlobalObject];
                 
                 if(!(bool)iI[(byte)InstancedItemsColumns.wasCrafted]) continue;
                 if(recipeGlobalObject == DBNull.Value || string.IsNullOrEmpty((string)recipeGlobalObject)) continue;
                 
                 Guid   instancedItemId = (Guid)iI[(byte)InstancedItemsColumns.instancedItemId];
                 var    sR = Instance._dataTables.ScriptableRecipesDictionaryByGlobalObject[(string)recipeGlobalObject];
                 string srGlobalObject = (string)sR[(byte)ScriptableRecipesColumns.globalObject];
                 if(!Instance._dataTables.ScriptableRecipeIngredientsDictionaryByNestedObjectCode.ContainsKey(srGlobalObject)) continue;
                 
                 var nestedRecipeIngredients = Instance._dataTables.ScriptableRecipeIngredientsDictionaryByNestedObjectCode[srGlobalObject];
                 
                 if (!Instance._dataTables.InstancedItemsIngredientsDictionaryByInstancedItemId.ContainsKey(instancedItemId)) continue;
                 
                 var ingredients = Instance._dataTables.InstancedItemsIngredientsDictionaryByInstancedItemId[(Guid)iI[(byte)InstancedItemsColumns.instancedItemId]];
                 foreach (DataRow iIi in ingredients)
                 {
                     string ingredientGlobalObject = (string)iIi[(byte)InstancedItemsIngredientsColumns.ingredientGlobalObject];
                     var    sRi                      = nestedRecipeIngredients[ingredientGlobalObject];
                     float  ingredientWeight         = (float)((byte)sRi[(byte)ScriptableRecipeIngredientsColumns.ingredientWeight] / 100d);
                     bool   primaryIngredient        = (bool)sRi[(byte)ScriptableRecipeIngredientsColumns.primaryIngredient];
         
                     if (!ingredientData.ContainsKey(instancedItemId)) ingredientData.Add(instancedItemId, new List<IngredientModel>());
                     ingredientData[instancedItemId].Add(new IngredientModel(ingredientGlobalObject, ingredientWeight, primaryIngredient));
                 }
             }
             return ingredientData;
         }

         public static Dictionary<Guid,List<IngredientModel>> InstancedItems_IngredientsGetList(Guid spawnedWorldObjectId)
         {
             Dictionary<Guid,List<IngredientModel>> ingredientData = new Dictionary<Guid,List<IngredientModel>>();

             foreach (var iI in Instance!._dataTables.InstancedItemsDataTable.Select())
             {
                 if((Guid)iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] != spawnedWorldObjectId) continue;

                 //string globalObject = (string) iI[(byte)InstancedItemsColumns.globalObject];
                 var recipeGlobalObject = iI[(byte)InstancedItemsColumns.recipeGlobalObject];
                 
                 if(!(bool)iI[(byte)InstancedItemsColumns.wasCrafted]) continue;
                 if(recipeGlobalObject == DBNull.Value || string.IsNullOrEmpty((string)recipeGlobalObject)) continue;

                 Guid instancedItemId = (Guid)iI[(byte)InstancedItemsColumns.instancedItemId];
                 //var  instancedItemId = instancedItemId;
                 if (Instance._dataTables.ScriptableRecipesDictionaryByGlobalObject.ContainsKey((string)recipeGlobalObject))
                 {
                     var    sR = Instance._dataTables.ScriptableRecipesDictionaryByGlobalObject[(string)recipeGlobalObject];
                     string srGlobalObject = (string)sR[(byte)ScriptableRecipesColumns.globalObject];
                     if(!Instance._dataTables.ScriptableRecipeIngredientsDictionaryByNestedObjectCode.ContainsKey(srGlobalObject)) continue;
                     
                     var nestedRecipeIngredients = Instance._dataTables.ScriptableRecipeIngredientsDictionaryByNestedObjectCode[srGlobalObject];
                     if (Instance._dataTables.InstancedItemsIngredientsDictionaryByInstancedItemId.ContainsKey(instancedItemId))
                     {
                         var ingredients = Instance._dataTables.InstancedItemsIngredientsDictionaryByInstancedItemId[(Guid)iI[(byte)InstancedItemsColumns.instancedItemId]];
                         foreach (DataRow iIi in ingredients)
                         {
                             string ingredientGlobalObject = (string)iIi[(byte)InstancedItemsIngredientsColumns.ingredientGlobalObject];
                             var sRi = nestedRecipeIngredients[ingredientGlobalObject];
                             float ingredientWeight = (float)((byte)sRi[(byte)ScriptableRecipeIngredientsColumns.ingredientWeight] / 100d);
                             bool primaryIngredient = (bool)sRi[(byte)ScriptableRecipeIngredientsColumns.primaryIngredient];
         
                             if (!ingredientData.ContainsKey(instancedItemId)) ingredientData.Add(instancedItemId, new List<IngredientModel>());
                             ingredientData[instancedItemId].Add(new IngredientModel(ingredientGlobalObject, ingredientWeight, primaryIngredient));
                         }
                     }
                     
                 }
             }
             return ingredientData;
         }

         public static List<SpawnedItemModel> InstancedItems_MaterialsGetList(Guid spawnedWorldObjectId)
         {
             List<SpawnedItemModel> materials = new List<SpawnedItemModel>();
             
             foreach (DataRow iM in Instance!._dataTables.InstancedMaterialsDataTable.Select())
             {
                 Guid instancedItemId = (Guid)iM[(byte)InstancedMaterialsColumns.instancedItemId];
                 var iI = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                 if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                 if (spawnedWorldObjectId != (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])) continue;

                 string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                 
                 var    quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                 var    maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                 var    rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                 var    qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                 var    durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                 var    wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                 var    crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                 var    wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                 SpawnedItemModel materialModel = new SpawnedItemModel(instancedItemId, globalObject, quantity, maxStack, rarityId, qualityId,
                     durabilityPercentage, wasCrafted, crafterName, wasLooted);
                 materials.Add(materialModel);
             }
             return materials;
         }

        public static List<SpawnedItemModel> InstancedItems_MaterialsGetAll()
        {
            List<SpawnedItemModel> materials = new List<SpawnedItemModel>();
            
            foreach (DataRow iM in Instance!._dataTables.InstancedMaterialsDataTable.Select())
            {
                Guid instancedItemId = (Guid)iM[(byte)InstancedMaterialsColumns.instancedItemId];
                var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                
                string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                
                byte   maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                byte   quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                byte   rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                byte   qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                float  durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                bool   wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                string crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                bool   wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                SpawnedItemModel materialModel = new SpawnedItemModel(instancedItemId, globalObject, quantity,maxStack, rarityId, qualityId,
                    durabilityPercentage, wasCrafted, crafterName, wasLooted);
                materials.Add(materialModel);
            }
            return materials;
        }

        public static List<SpawnedEquipmentModel> InstancedItems_WeaponsGetList(Guid spawnedWorldObjectId)
        {
            List<SpawnedEquipmentModel> weapons = new List<SpawnedEquipmentModel>();
            
            foreach (DataRow iW in Instance!._dataTables.InstancedWeaponsDataTable.Select())
            {
                Guid instancedItemId = (Guid)iW[(byte)InstancedWeaponsColumns.instancedItemId];
                var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;
                if (spawnedWorldObjectId != (Guid)(iI[(byte)InstancedItemsColumns.spawnedWorldObjectId])) continue;

                string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                
                byte   maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                byte   quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                byte   rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                byte   qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                float  durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                bool   wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                string crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                bool   wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];
                
                SpawnedEquipmentModel weaponModel = new SpawnedEquipmentModel(instancedItemId, globalObject, quantity, maxStack,
                    rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted, (byte)EquipmentTypes.Weapon);
                weapons.Add(weaponModel);
            }
            return weapons;
        }

        public static List<SpawnedEquipmentModel> InstancedItems_WeaponsGetAll()
        {
            List<SpawnedEquipmentModel> weapons = new List<SpawnedEquipmentModel>();
            //TODO REPLACE TO USE Dictionary!!!
            //foreach (var iW in Instance!._dataTables.InstancedItemsDictionaryByInstancedItemId)
            foreach (DataRow iW in Instance!._dataTables.InstancedWeaponsDataTable.Select())
            {
                Guid instancedItemId = (Guid)iW[(byte)InstancedWeaponsColumns.instancedItemId];
                var  iI              = Instance._dataTables.InstancedItemsDictionaryByInstancedItemId[instancedItemId];
                if((string)iI[(byte)InstancedItemsColumns.status] == GlobalStatusTypes.Deleted.ToString().ToLower()) continue;

                string globalObject         = (string)iI[(byte)InstancedItemsColumns.globalObject];
                
                byte   maxStack             = (byte)iI[(byte)InstancedItemsColumns.maxStack];
                byte   quantity             = (byte)iI[(byte)InstancedItemsColumns.quantity];
                byte   rarityId             = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                byte   qualityId            = (byte)iI[(byte)InstancedItemsColumns.qualityId];
                float  durabilityPercentage = (float)(decimal)iI[(byte)InstancedItemsColumns.durabilityPercentage];
                bool   wasCrafted           = (bool)iI[(byte)InstancedItemsColumns.wasCrafted];
                string crafterName          = iI[(byte)InstancedItemsColumns.crafterName].ToString();
                bool   wasLooted            = (bool)iI[(byte)InstancedItemsColumns.wasLooted];

                SpawnedEquipmentModel weaponModel = new SpawnedEquipmentModel(instancedItemId, globalObject, quantity, maxStack, 
                    rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted, (byte)EquipmentTypes.Weapon);
                weapons.Add(weaponModel);
                
            }
            return weapons;
        }


        #endregion
        #region DATA TABLE STP INSERT / UPDATES: INSTANCED

        public static bool InstancedItems_AmmunitionCreate(string globalObject, byte rarityId, byte qualityId, byte quantity,
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            


            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                DataRow sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Ammunition, maxStack,
                 quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedAmmunitionDataRow(instancedItemId, globalObject);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_AmmunitionCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_AmmunitionCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_ArmorCreate(string globalObject, byte rarityId, byte qualityId, byte quantity,
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, 
            Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                DataRow sI       = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var     maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
           
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Equipment, maxStack,
                    quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedEquipmentDataRow(instancedItemId, globalObject, (byte)EquipmentTypes.Armor);
                Instance._dataTableSelects.AddInstancedArmorDataRow(instancedItemId, globalObject);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_ArmorCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            if(SQL_PROFILING_ENABLED) Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_ArmorCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_BagCreate(string globalObject, byte rarityId, byte qualityId, byte quantity,
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, byte bagSize, Guid spawnedWorldObjectId,
            Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;

            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                var sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];

                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Bag, maxStack, 
                    quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName,
                    wasLooted);
                Instance._dataTableSelects.AddInstancedBagsDataRow(instancedItemId, globalObject, bagSize);
                #endregion
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_BagCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, 
                    crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_BagCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_ConsumableCreate(string globalObject, byte rarityId, byte qualityId, 
            byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, 
            Guid spawnedWorldObjectId, Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                DataRow sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];

                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Consumable, maxStack,
                    quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedConsumablesDataRow(instancedItemId, globalObject);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_ConsumableCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_ConsumableCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }

        public static bool InstancedItems_GeneralItemCreate(string globalObject, byte rarityId, byte qualityId, 
            byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, 
            Guid spawnedWorldObjectId, Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                DataRow sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.GeneralItem, 
                    maxStack, quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, 
                    crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedGeneralItemsDataRow(instancedItemId, globalObject);

                #endregion
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_GeneralItemCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, 
                    wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_GeneralItemCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_MaterialCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, 
            float durabilityPercentage,bool wasCrafted, string crafterName, bool wasLooted,  Guid spawnedWorldObjectId,
            Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;

            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                var sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Material, maxStack,
                    quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedMaterialsDataRow(instancedItemId, globalObject);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_MaterialCreate): {0} - 
                    Params: globalObject: {1}, rarityId: {2}, qualityId: {3}, 
                    quantity: {4}, durabilityPercentage: {5}, wasCrafted: {6}, 
                    crafterName: {7}, wasLooted: {8}, spawnedWorldObjectId: {9},
                    instancedItemId: {10}",
                    e.Message, globalObject, rarityId, qualityId, quantity, durabilityPercentage, 
                    wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_MaterialCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_WeaponCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, 
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                DataRow sI = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var maxStack = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, (byte)ItemTypes.Equipment, maxStack, 
                quantity, globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                Instance._dataTableSelects.AddInstancedEquipmentDataRow(instancedItemId, globalObject, (byte)EquipmentTypes.Weapon);
                Instance._dataTableSelects.AddInstancedWeaponsDataRow(instancedItemId, globalObject);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_WeaponCreate):{0} - 
                    Params: GlobalObject: {1}, RarityId{2}, QualityId: {3}, Quantity: {4}, 
                    DurabilityPercentage: {5}, WasCrafted: {6}, CrafterName: {7}, WasLooted: {8}, 
                    SpawnedWorldObjectId: {9}, instancedItemId: {10}", e.Message, 
                    globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, 
                    spawnedWorldObjectId, instancedItemId));
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_WeaponCreate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_IngredientAdd(Guid instancedItemId, string ingredientGlobalObject)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                //  NEW ROW
                DataRow iI = Instance!._dataTables.InstancedItemsIngredientsDataTable.NewRow();
                //  POPULATE ROW WITH DATA
                iI = Instance._dataTableSelects.PopulateInstancedItemsIngredientsDataRow(iI, instancedItemId, ingredientGlobalObject);
                //  ADD ROW TO TABLE
                Instance._dataTables.InstancedItemsIngredientsDataTable.Rows.Add(iI);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_IngredientAdd): {0} - 
                    Params: InstancedItemId: {1}, IngredientGlobalObject: {2}",
                    e.Message, instancedItemId, ingredientGlobalObject));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_IngredientAdd took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_DurabilityUpdate(Guid instancedItemId, float durabilityPercentage)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            
            //var instancedItemId = new Guid(instancedItemId);
            try
            {
                DataRow iI = Instance!._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(instancedItemId)[0];
                iI[(byte)InstancedItemsColumns.durabilityPercentage] = durabilityPercentage;
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_DurabilityUpdate): {0} - 
                    Params: instancedItemId: {1}, durabilityPercentage: {2}",
                    e.Message, instancedItemId, durabilityPercentage));    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_DurabilityUpdate took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static bool InstancedItems_IsLooted(Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

             //var instancedItemId = new Guid(instancedItemId);
            try
            {
                //  GET ROW TO UPDATE
                var data = Instance!._dataTableSelects.InstancedItemsSelectRows_ByInstancedItemId(instancedItemId);
                if (data.Count == 0) throw new Exception($"Failed to Update InstancedItem Looted Status: No Instanced Item Data Found");
                var iI = data[0];
                //  UPDATE ROW DATA
                iI[(byte)InstancedItemsColumns.wasLooted]  = 1;
                iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now;
                success          = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (InstancedItems_IsLooted): {e.Message} - 
                    Params: InstancedItemId: {instancedItemId}");    
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_IsLooted took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }

        private static bool InstancedItems_SplitCreateGuid(string globalObject, byte rarityId, byte qualityId, byte quantity,
          float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            
            try
            {
                #region INSERT INTO INSTANCED ITEMS
                //SELECT DATA FROM SCRIPTABLE ITEMS
                var sI         = Instance!._dataTableSelects.ScriptableItemsSelectRow(globalObject);
                var itemTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var maxStack   = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                
                Instance._dataTableSelects.AddInstancedItemsDataRow(instancedItemId, spawnedWorldObjectId, itemTypeId, maxStack, quantity, 
                globalObject, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted);
                #endregion
                
                if (itemTypeId == (byte)ItemTypes.Ammunition) { }
                else if (itemTypeId == (byte)ItemTypes.Bag) 
                {
                    var dataScriptableBags = Instance._dataTableSelects.ScriptableBagsSelectRows(globalObject);
                    DataRow sB = dataScriptableBags[0];
                    var slots = (byte)sB[(byte)ScriptableBagsColumns.slots];
                    Instance._dataTableSelects.AddInstancedBagsDataRow(instancedItemId, globalObject, slots);
                    success = true;
                }
                else if (itemTypeId == (byte)ItemTypes.Consumable) 
                {
                    Instance._dataTableSelects.AddInstancedConsumablesDataRow(instancedItemId, globalObject);
                    success = true;
                }
                else if (itemTypeId == (byte)ItemTypes.Material)
                {
                    Instance._dataTableSelects.AddInstancedMaterialsDataRow(instancedItemId, globalObject);
                    success = true;
                }
                else if (itemTypeId == (byte)ItemTypes.GeneralItem)
                {
                    Instance._dataTableSelects.AddInstancedGeneralItemsDataRow(instancedItemId, globalObject);
                    success = true;
                }
                else if (itemTypeId == (byte)ItemTypes.Equipment)
                {
                    byte itemSubTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemSubTypeId];
                    if (itemSubTypeId == (byte)EquipmentTypes.Armor) 
                    {
                        Instance._dataTableSelects.AddInstancedArmorDataRow(instancedItemId, globalObject);
                        success = true;
                    }
                    else if (itemSubTypeId == (byte)EquipmentTypes.Weapon)
                    {
                        Instance._dataTableSelects.AddInstancedWeaponsDataRow(instancedItemId, globalObject);
                        success = true;
                    }
                }
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (InstancedItems_SplitCreateGuid):{0} - 
                    Params: GlobalObject: {1}, RarityId{2}, QualityId: {3}, Quantity: {4}, 
                    DurabilityPercentage: {5}, WasCrafted: {6}, CrafterName: {7}, WasLooted: {8}, 
                    SpawnedWorldObjectId: {9}, instancedItemId: {10}", e.Message, 
                    globalObject, rarityId, qualityId, quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, 
                    spawnedWorldObjectId, instancedItemId));
            }

            Logger!.LogProfiling($"DataTableStoredProcs.InstancedItems_SplitCreateGuid took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
         #endregion
        
        #region DATA TABLE STP GETS: REFERENCE
        public static Dictionary<string, List<AbilityRankModel>> Abilities_RanksGetList()
        {
            Dictionary<string, List<AbilityRankModel>> abilityRanks = new Dictionary<string, List<AbilityRankModel>>();
            
            foreach (DataRow sAR in Instance!._dataTables.ScriptableAbilitiesRanksDataTable.Rows)
            {
                string globalObject = (string)(sAR[(byte)ScriptableAbilitiesRanksColumns.globalObject]);
                byte rankId           = (byte) sAR[(byte)ScriptableAbilitiesRanksColumns.rankId];
                if (Instance._dataTables.ScriptableAbilitiesRanksActivationCostsDictionary.ContainsKey(globalObject))
                {
                    var sArac = Instance._dataTables.ScriptableAbilitiesRanksActivationCostsDictionary[globalObject][rankId][0];
                    var sOr = Instance._dataTables.ScriptableObjectRanksDictionaryByNestedObjectCode[globalObject][rankId];
                    //var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                    //var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                    //var statusId = (byte)glO[(byte)GlobalObjectsColumns.statusId];

                    var eGtom = Instance._dataTables.EffectGroupsToObjectsMappingDictionary[globalObject][rankId];
                    var effectGroupGlobalObject= (string)eGtom[(byte)EffectGroupsToObjectsMappingColumns.effectGroupGlobalObject];
                    var eG = Instance._dataTables.EffectGroupsDictionary[effectGroupGlobalObject];
                    var sOab = Instance._dataTables.ScriptableObjectsDictionary[effectGroupGlobalObject];
                    var scriptableObjectTypeId = (byte)sOab[(byte)ScriptableObjectsColumns.scriptableObjectTypeId];

                    if (scriptableObjectTypeId != (byte)ScriptableObjectTypes.Ability) continue;

                    var rankIndex      = (byte)sOr[(byte)ScriptableObjectRanksColumns.levelId];
                    var rankName       = (string)sOr[(byte)ScriptableObjectRanksColumns.scriptableObjectSpawnable];
                    var statusEffectId = (ushort)eG[(byte)EffectGroupsColumns.effectGroupId];
                    var abilityRankGlobalObjectName = (string)sOr[(byte)ScriptableObjectRanksColumns.scriptableObjectSpawnable];
                    var activateWhileMoving = (bool)sAR[(byte)ScriptableAbilitiesRanksColumns.activateWhileMoving];
                    var damageCancels = (bool)eG[(byte)EffectGroupsColumns.damageCancels];
                    var castTime = (float)(decimal)sAR[(byte)ScriptableAbilitiesRanksColumns.activationTime];
                    var effectCostTypeId = (byte)sArac[(byte)ScriptableAbilitiesRanksActivationCostsColumns.costTypeId];
                    var effectCostStatId = (byte)sArac[(byte)ScriptableAbilitiesRanksActivationCostsColumns.statId];
                    var effectCostStatTypeId = (byte)sArac[(byte)ScriptableAbilitiesRanksActivationCostsColumns.statTypeId];
                    var duration = (int)eG[(byte)EffectGroupsColumns.duration];
                    var cost = (int)sArac[(byte)ScriptableAbilitiesRanksActivationCostsColumns.cost];
                    var cooldown = (int)sAR[(byte)ScriptableAbilitiesRanksColumns.cooldown];    
                    var abilityRank = new AbilityRankModel(rankIndex, rankName, 0, activateWhileMoving, 
                        damageCancels, castTime, effectCostTypeId, effectCostStatId, effectCostStatTypeId, 
                        duration, cost, cooldown, statusEffectId,abilityRankGlobalObjectName);
                    if (!abilityRanks.ContainsKey(globalObject)) abilityRanks.Add(globalObject, new List<AbilityRankModel>());
                    abilityRanks[globalObject].Add(abilityRank);
                }
            }
#if UNITY_EDITOR
            if(Instance._dataTables.ScriptableAbilitiesRanksDataTable.Rows.Count != 0 && abilityRanks.Count == 0) Logger!.LogWarning($"ERROR: Abilities_RanksGetList - 0 Results");
#endif
            return abilityRanks;
        }
        public static Dictionary<string, AbilityModel> Abilities_GetList()
        {
            Dictionary<string, AbilityModel> abilities = new Dictionary<string, AbilityModel>();
           
            foreach (DataRow sA in Instance!._dataTables.ScriptableAbilitiesDataTable.Select())
            {
                string globalObject = (string)(sA[(byte)ScriptableAbilitiesColumns.globalObject]);
                var gOb = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var statusId = (byte)gOb[(byte)GlobalObjectsColumns.statusId];
                
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var abilityId = (ushort)(int)sA[(byte)ScriptableAbilitiesColumns.scriptableAbilityId];
                var globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var abilityName = (string)gOb[(byte)GlobalObjectsColumns.globalObjectName];
                var abilityDescription = (string)sA[(byte)ScriptableAbilitiesColumns.abilityDescription];
                var abilityTier = (byte)sA[(byte)ScriptableAbilitiesColumns.abilityDifficultyTierId];
                var abilityActivationId = (byte)sA[(byte)ScriptableAbilitiesColumns.abilityActivationTypeId];
                var globalObjectTypeId = (byte)gOb[(byte)GlobalObjectsColumns.globalObjectTypeId];

                AbilityModel abilityModel = new AbilityModel(abilityId, globalObject, statusId, globalObjectPath, abilityName, abilityDescription, abilityTier, abilityActivationId, globalObjectTypeId);
                
                abilities.Add(globalObject, abilityModel);
            }
#if UNITY_EDITOR
            if(abilities.Count == 0) Logger!.LogWarning($"ERROR: Abilities_GetList - 0 Results");
#endif
            return abilities;
        }
        public static Dictionary<byte, Dictionary<byte, LevelModel>> AbilityExperienceRequired_GetList()
        {
            Dictionary<byte, Dictionary<byte, LevelModel>> myDict = new Dictionary<byte, Dictionary<byte, LevelModel>>();
            
            foreach (DataRow lRa in Instance!._dataTables.LevelRequirementsAbilitiesDataTable.Select())
            {
                byte skillRank  = (byte)lRa[(byte)LevelRequirementsAbilitiesColumns.rankId];
                byte skillLevel = (byte)lRa[(byte)LevelRequirementsAbilitiesColumns.levelId];
                
                if (!myDict.ContainsKey(skillRank)) myDict.Add(skillRank, new Dictionary<byte, LevelModel>());

                int experienceRequired = (int)lRa[(byte)LevelRequirementsAbilitiesColumns.minExperience];
                int maxExperience      = (int)lRa[(byte)LevelRequirementsAbilitiesColumns.maxExperience];

                if (!myDict[skillRank].ContainsKey(skillLevel)) 
                    myDict[skillRank].Add(skillLevel, new LevelModel(experienceRequired, maxExperience));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityExperienceRequired_GetList - 0 Results");
#endif
            return myDict;
        }
        public static Dictionary<byte, float> AbilityDifficultyMultipliers_GetList()
        {
            Dictionary<byte, float> myDict = new Dictionary<byte, float>();
            
            foreach (DataRow aDT in Instance!._dataTables.AbilityDifficultyTiersDataTable.Select())
            {
                myDict.Add(
                    (byte)aDT[(byte)AbilityDifficultyTiersColumns.abilityDifficultyTierId],
                    (float)(decimal)aDT[(byte)AbilityDifficultyTiersColumns.abilityDifficultyExperiencePenalty]);
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: AbilityDifficultyMultipliers_GetList - 0 Results");
#endif
            return myDict;
        }
        public static Dictionary<string, List<AwardEffectModel>> AwardEffects_GetList()
        {
            Dictionary<string, List<AwardEffectModel>> myDict = new Dictionary<string, List<AwardEffectModel>>();
            foreach (DataRow aE in Instance!._dataTables.AwardEffectsDataTable.Rows) 
            {
                var globalObject = (string)(aE[(byte)AwardEffectsColumns.globalObject]);

                if (!Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGroupGlobalObjectCode.ContainsKey(globalObject))
                {
                    continue;
                }
                var nestedEffectGlobalObjects = Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGroupGlobalObjectCode[globalObject];
                
                foreach (var eTegm in nestedEffectGlobalObjects)
                {
                    var effectGroupGlobalObject = eTegm.Key;
                    byte globalStatusId        = (byte)Instance._dataTables.GlobalObjectsDictionary[effectGroupGlobalObject][(byte)GlobalObjectsColumns.statusId];
                    var effectGroupGlobalObjectData = effectGroupGlobalObject;
                    
                    if (!myDict.ContainsKey(effectGroupGlobalObjectData)) myDict.Add(effectGroupGlobalObjectData, new List<AwardEffectModel>());
                        
                    var    awardEffectTypeId   = (byte)aE[(byte)AwardEffectsColumns.awardEffectTypeId];
                    string awardGlobalObject = (string)aE[(byte)AwardEffectsColumns.awardGlobalObject];
                    myDict[effectGroupGlobalObjectData].Add(new AwardEffectModel(awardGlobalObject, globalStatusId, awardEffectTypeId));
                }
            }
            #if UNITY_EDITOR
            if(!(Instance._dataTables.AwardEffectsDataTable.Rows.Count != 0 && myDict.Count == 0)) Logger!.LogWarning($"ERROR: AwardEffects_GetList - 0 Results");
            #endif
            return myDict;
        }
        public static Dictionary<string, List<BodyPartMultiplierModel>> BodyPartMultipliers_GetList()
        {
            Dictionary<string, List<BodyPartMultiplierModel>> myDict = new Dictionary<string, List<BodyPartMultiplierModel>>();
            
            foreach (DataRow bPm in Instance!._dataTables.BodyPartMultipliersDataTable.Select())
            {
                string globalObject = (string)bPm[(byte)BodyPartMultipliersColumns.globalObject];
               
                if (!myDict.ContainsKey(globalObject)) myDict.Add(globalObject, new List<BodyPartMultiplierModel>());

                float multiplier = (float)(decimal)bPm[(byte)BodyPartMultipliersColumns.multiplierValue];
                byte  bodyPartId = (byte)bPm[(byte)BodyPartMultipliersColumns.bodyPartTypeId];
                
                myDict[globalObject].Add(new BodyPartMultiplierModel(multiplier, bodyPartId));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: BodyPartMultipliers_GetList - 0 Results");
#endif
            return myDict;
        }
        public static Dictionary<string, List<BodyPartPathModel>> BodyPartPaths_GetList()
        {
            Dictionary<string, List<BodyPartPathModel>> myDict = new Dictionary<string, List<BodyPartPathModel>>();
            
            foreach (DataRow row in Instance!._dataTables.BodyPartPathsDataTable.Select())
            {
                string globalObject = (string)row[(byte)BodyPartPathsColumns.globalObject];
                string bodyPartPath = (string)row[(byte)BodyPartPathsColumns.bodyPartPath];
                byte bodyPartTypeId = (byte)row[(byte)BodyPartPathsColumns.bodyPartTypeId];

                if (!myDict.ContainsKey(globalObject)) myDict.Add(globalObject, new List<  BodyPartPathModel>());

                myDict[globalObject].Add(new BodyPartPathModel(bodyPartPath, bodyPartTypeId));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: BodyPartPaths_GetList - 0 Results");
#endif
            return myDict;
        }
        public static Dictionary<string, List<ExperienceEffectModel>> ExperienceEffects_GetList()
        {
            Dictionary<string, List<ExperienceEffectModel>> myDict =
                new Dictionary<string, List<ExperienceEffectModel>>();
            foreach (DataRow eE in Instance!._dataTables.ExperienceEffectsDataTable.Select())
            {
                string globalObject   = (string)(eE[(byte)ExperienceEffectsColumns.globalObject]);
                if (Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode.ContainsKey(globalObject))
                {
                    var nestedEffectGlobalObjects = Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode[globalObject];
                    foreach (var eTegm in nestedEffectGlobalObjects)
                    {
                        var  effectGroupGlobalObject     = eTegm.Key;
                        //var  eG                          = Instance._dataTables.EffectGroupsDictionary[effectGroupGlobalObject];

                        if (!myDict.ContainsKey(effectGroupGlobalObject))
                            myDict.Add(effectGroupGlobalObject, new List<ExperienceEffectModel>());

                        byte experienceTypeId = (byte)eE[(byte)ExperienceEffectsColumns.experienceEffectTypeId];
                        int  experienceGain   = (int)eE[(byte)ExperienceEffectsColumns.experienceGain];

                        myDict[effectGroupGlobalObject].Add(new ExperienceEffectModel(experienceTypeId, experienceGain));
                    }
                }

            }   
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ExperienceEffects_GetList - 0 Results");
#endif
            return myDict;
        }
        public static List<ScriptableObjectModel> ScriptableObjects_GetList()
        {
            List<ScriptableObjectModel> myDict = new List<ScriptableObjectModel>();
            
            foreach (var sO in Instance!._dataTables.ScriptableObjectsDictionary)
            {
                var glO              = Instance._dataTables.GlobalObjectsDictionary[sO.Key];
                var globalObject = (string) glO[(byte)GlobalObjectsColumns.globalObject];
                var globalStatusId = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var singularName     = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var pluralName       = (string) glO[(byte)GlobalObjectsColumns.globalObjectNamePlural];
                var globalObjectPath = (string) sO.Value[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var objectTypeId     = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];

                myDict.Add(new ScriptableObjectModel(globalObject, globalStatusId, globalObjectPath, singularName,
                    pluralName, objectTypeId));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GlobalObjects_GetList - 0 Results");
#endif
            return myDict;
        }
        
        public static List<ScriptableObjectModel> ScriptableItems_GetList()
        {
            List<ScriptableObjectModel> myDict = new List<ScriptableObjectModel>();
            
            foreach (var sO in Instance!._dataTables.ScriptableObjectsDictionary)
            {
                var glO              = Instance._dataTables.GlobalObjectsDictionary[sO.Key];
                var globalObject     = (string) glO[(byte)GlobalObjectsColumns.globalObject];
                var globalStatusId   = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var singularName     = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var pluralName       = (string) glO[(byte)GlobalObjectsColumns.globalObjectNamePlural];
                var globalObjectPath = (string) sO.Value[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var objectTypeId     = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];

                if((GlobalObjectTypes)objectTypeId != GlobalObjectTypes.Item) continue;
                
                myDict.Add(new ScriptableObjectModel(globalObject, globalStatusId, globalObjectPath, singularName,
                    pluralName, objectTypeId));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: GlobalObjects_GetList - 0 Results");
#endif
            return myDict;
        }
        public static Dictionary<byte, Dictionary<byte, LevelModel>> LevelRequirement_GetList()
        {
            Dictionary<byte, Dictionary<byte, LevelModel>> levels = new Dictionary<byte, Dictionary<byte, LevelModel>>();
            
            foreach (DataRow lR in Instance!._dataTables.LevelRequirementsDataTable.Select())
            {
                var rankId = (byte)lR[(byte)LevelRequirementsColumns.rankId];
                var level  = (byte)lR[(byte)LevelRequirementsColumns.levelId];

                if (!levels.ContainsKey(rankId)) levels.Add(rankId, new Dictionary<byte, LevelModel>());
                var experienceRequired = (int)lR[(byte)LevelRequirementsColumns.minExperience];
                var maxExperience      = (int)lR[(byte)LevelRequirementsColumns.maxExperience];

                levels[rankId].Add(level, new LevelModel(experienceRequired, maxExperience));
            }
            return levels;
        }
        public static Dictionary<byte, Dictionary<byte, LevelModel>> LevelRequirementSkills_GetList()
        {
            Dictionary<byte, Dictionary<byte, LevelModel>> levels = new Dictionary<byte, Dictionary<byte, LevelModel>>();
            
            foreach (DataRow lR in Instance!._dataTables.LevelRequirementsSkillsDataTable.Select())
            {
                var rankId = (byte)lR[(byte)LevelRequirementsColumns.rankId];
                var level = (byte)lR[(byte)LevelRequirementsColumns.levelId];

                if (!levels.ContainsKey(rankId)) levels.Add(rankId, new Dictionary<byte, LevelModel>());
                var experienceRequired = (int)lR[(byte)LevelRequirementsColumns.minExperience];
                var maxExperience      = (int)lR[(byte)LevelRequirementsColumns.maxExperience];
                
                levels[rankId].Add(level, new LevelModel(experienceRequired, maxExperience));
            }
            return levels;
        }
        public static Dictionary<string, LootTableModel> LootTables_GetList()
        {
            Dictionary<string, LootTableModel> lootTableData = new Dictionary<string, LootTableModel>();
            
            foreach (DataRow sLt in Instance!._dataTables.ScriptableLootTablesDataTable.Rows)
            {
                string globalObject = (string) sLt[(byte)ScriptableLootTablesColumns.globalObject];
                var glO              = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sO               = Instance._dataTables.ScriptableObjectsDictionary[globalObject];

                var globalStatusId       = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var lootTableName        = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var scriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var lootTableTypeId      = (byte)sLt[(byte)ScriptableLootTablesColumns.lootTableTypeId];
                var lootTableSubTypeId   = (byte)sLt[(byte)ScriptableLootTablesColumns.lootTableMainTypeId];
                var llobalObjectTypeId   = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];

                LootTableModel lootTable = new LootTableModel(globalObject, globalStatusId, lootTableName, scriptableObjectPath, lootTableTypeId, lootTableSubTypeId, llobalObjectTypeId);
                lootTableData.Add(globalObject, lootTable);
            }
#if UNITY_EDITOR
            if(lootTableData.Count == 0) Logger!.LogWarning($"ERROR: LootTables_GetList - 0 Results");
#endif
            return lootTableData;
        }
        public static Dictionary<string, List<LootTableDropModel>> LootTables_DropsGetList()
        {
            Dictionary<string, List<LootTableDropModel>> lootTableDropData = new Dictionary<string, List<LootTableDropModel>>();
            
            foreach (DataRow sLtt in Instance!._dataTables.ScriptableLootTablesToLootTableDataTable.Select())
            {
                string inheritedLootTableGlobalObject = (string)sLtt[(byte)ScriptableLootTablesToLootTableColumns.inheritedLootTableGlobalObject];
                
                if (Instance._dataTables.ScriptableLootTableDropsDictionaryByGlobalObjectCode.ContainsKey(inheritedLootTableGlobalObject))
                {
                    var sLdNested = Instance._dataTables.ScriptableLootTableDropsDictionaryByGlobalObjectCode[inheritedLootTableGlobalObject];
               
                    foreach (var sLd in sLdNested)
                    {
                        var sldRow = sLd.Value;
                        string recipeGlobalObject = (string)sldRow[(byte)ScriptableLootTableDropsColumns.recipeGlobalObject];
                        var rsO = Instance._dataTables.ScriptableObjectsDictionary[recipeGlobalObject];
                    
                        string lootTableId = (string)sLtt[(byte)ScriptableLootTablesToLootTableColumns.globalObject];
                     
                        var itemGlobalObject = (string)sldRow[(byte)ScriptableLootTableDropsColumns.itemGlobalObject];
                        var qualityId = (byte)sldRow[(byte)ScriptableLootTableDropsColumns.qualityId];
                        var dropChance = (float)(decimal)sldRow[(byte)ScriptableLootTableDropsColumns.dropChance];
                        var recipeScriptableObjectPath = (string)rsO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                        
                        LootTableDropModel dropData = new LootTableDropModel(itemGlobalObject, dropChance, qualityId,
                            recipeGlobalObject, recipeScriptableObjectPath);
                        
                        if (!lootTableDropData.ContainsKey(lootTableId)) lootTableDropData.Add(lootTableId, new List<LootTableDropModel>());
                        lootTableDropData[lootTableId].Add(dropData);
                    }         
                }
                
            }
#if UNITY_EDITOR
            if(lootTableDropData.Count == 0) Logger!.LogWarning($"ERROR: LootTables_DropsGetList - 0 Results");
#endif
            return lootTableDropData;
        }
        public static Dictionary<string, Dictionary<string, List<LootTableRarityModel>>> LootTables_RaritiesGetList()
        {
            Dictionary<string, Dictionary<string, List<LootTableRarityModel>>> lootTableRarityData = new Dictionary<string, Dictionary<string, List<LootTableRarityModel>>>();

            foreach (var lootTableGlobalObject in Instance!._dataTables.ScriptableLootTableRaritiesDictionaryByGlobalObjectCode)
            {
                foreach (var itemGlobalObject in lootTableGlobalObject.Value)
                {
                    foreach (var rarityId in itemGlobalObject.Value)
                    {
                        var rarityChance = (float)(decimal)rarityId.Value[(byte)ScriptableLootTableRaritiesColumns.rarityChance];
                        LootTableRarityModel rarityData = new LootTableRarityModel(rarityId.Key, rarityChance);
                        if (!lootTableRarityData.ContainsKey(lootTableGlobalObject.Key))
                            lootTableRarityData.Add(lootTableGlobalObject.Key, new Dictionary<string, List<LootTableRarityModel>>());
                        if (!lootTableRarityData[lootTableGlobalObject.Key].ContainsKey(itemGlobalObject.Key))
                            lootTableRarityData[lootTableGlobalObject.Key].Add(itemGlobalObject.Key, new List<LootTableRarityModel>());
                        lootTableRarityData[lootTableGlobalObject.Key][itemGlobalObject.Key].Add(rarityData);
                    }
                }   
            }
#if UNITY_EDITOR
            if(lootTableRarityData.Count == 0) Logger!.LogWarning($"ERROR: LootTables_RaritiesGetList - 0 Results");
#endif
            return lootTableRarityData;
        }
        public static Dictionary<string, Dictionary<string, List<LootTableQuantityModel>>> LootTables_QuantitiesGetList()
        {
            Dictionary<string, Dictionary<string, List<LootTableQuantityModel>>> lootTableQuantityData = 
                new Dictionary<string, Dictionary<string, List<LootTableQuantityModel>>>();

            foreach (var lootTableGlobalObject in Instance!._dataTables.ScriptableLootTableQuantitiesDictionaryByGlobalObjectCode)
            {
                foreach (var itemGlobalObject in lootTableGlobalObject.Value)
                {
                    foreach (var quantity in itemGlobalObject.Value)
                    {
                        var quantityChance = (float)(decimal)quantity.Value[(byte)ScriptableLootTableQuantitiesColumns.quantityChance];
                        LootTableQuantityModel quantityData = new LootTableQuantityModel(quantity.Key, quantityChance);
                        var globalObject     = lootTableGlobalObject.Key;
                        if (!lootTableQuantityData.ContainsKey(globalObject))
                            lootTableQuantityData.Add(globalObject,
                                new Dictionary<string, List<LootTableQuantityModel>>());
                        if (!lootTableQuantityData[globalObject].ContainsKey(itemGlobalObject.Key))
                            lootTableQuantityData[globalObject]
                                .Add(itemGlobalObject.Key, new List<LootTableQuantityModel>());
                        lootTableQuantityData[globalObject][itemGlobalObject.Key].Add(quantityData);
                    }
                }
            }
#if UNITY_EDITOR
            if(lootTableQuantityData.Count == 0) Logger!.LogWarning($"ERROR: LootTables_QuantitiesGetList - 0 Results");
#endif
            return lootTableQuantityData;
        }
        public static List<QualityModel> Qualities_GetList()
        {
            var qualityData = new List<QualityModel>();
            
            foreach (var sQ in Instance!._dataTables.ScriptableQualitiesDataTable.Select())
            {
                var qualityId = (byte)sQ[(byte)ScriptableQualitiesColumns.scriptableQualityId];
                var       qualityName     = (string)sQ[(byte)ScriptableQualitiesColumns.qualityName];
                var        valueMultiplier = (float)(decimal)sQ[(byte)ScriptableQualitiesColumns.valueMultiplier];
                var       description = (string)sQ[(byte)ScriptableQualitiesColumns.description];
                    
                var quality = new QualityModel(qualityId, qualityName, valueMultiplier, description);
                
                qualityData.Add(quality);
            }
#if UNITY_EDITOR
            if(qualityData.Count == 0) Logger!.LogWarning($"ERROR: Qualities_GetList - 0 Results");
#endif
            return qualityData;
        }
        public static Dictionary<byte, List<ModifierModel>> Qualities_ModifiersGetList()
        {
            Dictionary<byte, List<ModifierModel>> qualityModifiers = new Dictionary<byte, List<ModifierModel>>();
            
            foreach (DataRow sqM in Instance!._dataTables.ScriptableQualityModifiersDataTable.Select())
            {

                byte qualityTypeId = (byte)sqM[(byte)ScriptableQualityModifiersColumns.qualityId];

                byte  modifierTypeId = (byte)sqM[(byte)ScriptableQualityModifiersColumns.modifierTypeId];
                float modifierValue  = (float)(decimal)sqM[(byte)ScriptableQualityModifiersColumns.modifierMultiplier];
                        
                ModifierModel modifierData = new ModifierModel(modifierTypeId, modifierValue);

                if (!qualityModifiers.ContainsKey(qualityTypeId)) qualityModifiers.Add(qualityTypeId, new List<ModifierModel>());
                qualityModifiers[qualityTypeId].Add(modifierData);
            }
#if UNITY_EDITOR
            if(qualityModifiers.Count == 0) Logger!.LogWarning($"ERROR: Qualities_ModifiersGetList - 0 Results");
#endif
            return qualityModifiers;
        }
        public static List<RarityModel> Rarities_GetList()
        {
            List<RarityModel> rarityData = new List<RarityModel>();
            
            foreach (DataRow sR in Instance!._dataTables.ScriptableRaritiesDataTable.Select())
            {
                var         rarityId        = (byte)sR[(byte)ScriptableRaritiesColumns.scriptableRarityId];
                var         rarityName      = (string)sR[(byte)ScriptableRaritiesColumns.rarityName];
                var         valueMultiplier = (float)(decimal)sR[(byte)ScriptableRaritiesColumns.valueMultiplier];
                var         rarityColor     = (string)sR[(byte)ScriptableRaritiesColumns.rarityColor];
                var         description     = (string)sR[(byte)ScriptableRaritiesColumns.description];
                RarityModel rarity = new RarityModel(rarityId, rarityName, valueMultiplier, rarityColor, description);
                rarityData.Add(rarity);
            }
#if UNITY_EDITOR
            if(rarityData.Count == 0) Logger!.LogWarning($"ERROR: Rarities_GetList - 0 Results");
#endif
            return rarityData;
        }
        public static Dictionary<byte, List<ModifierModel>> Rarities_ModifiersGetList()
        {
            Dictionary<byte, List<ModifierModel>> rarityModifiers = new Dictionary<byte, List<ModifierModel>>();
            
            foreach (DataRow srM in Instance!._dataTables.ScriptableRarityModifiersDataTable.Select())
            {
                byte rarityTypeId = (byte)srM[(byte)ScriptableRarityModifiersColumns.rarityId];

                byte modifierTypeId = (byte)srM[(byte)ScriptableRarityModifiersColumns.modifierTypeId];
                float modifierValue  = (float)(decimal)srM[(byte)ScriptableRarityModifiersColumns.modifierMultiplier];
                ModifierModel modifierData = new ModifierModel(modifierTypeId, modifierValue);

                if (!rarityModifiers.ContainsKey(rarityTypeId)) rarityModifiers.Add(rarityTypeId, new List<ModifierModel>());
                rarityModifiers[rarityTypeId].Add(modifierData);
            }
#if UNITY_EDITOR
            if(rarityModifiers.Count == 0) Logger!.LogWarning($"ERROR: Rarities_ModifiersGetList - 0 Results");
#endif
            return rarityModifiers;
        }

        public static Dictionary<string, RecipeModel> Recipes_GetList()
        {
            Dictionary<string, RecipeModel> recipeData = new Dictionary<string, RecipeModel>();
            
            //var iconsTableData = IconsSelectRows($"");
            foreach (DataRow sR in Instance!._dataTables.ScriptableRecipesDataTable.Rows)
            {
                string globalObject = (string) sR[(byte)ScriptableRecipesColumns.globalObject];
                Logger!.LogProfiling($"DataTableStoredProcs.globalObject: {globalObject}");
                //var sK = scriptableSkillsData[globalObject];
                var gOb            = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var globalStatusId = (byte) gOb[(byte)GlobalObjectsColumns.statusId];
                
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                ushort skillId = (ushort) (int)Instance._dataTables.ScriptableSkillsDictionary[(string)sR[(byte)ScriptableRecipesColumns.requiredSkillGlobalObject]][(byte)ScriptableSkillsColumns.scriptableSkillId];    
                    
                var recipeId = (ushort) (int) sR[(byte)ScriptableRecipesColumns.scriptableRecipeId];
                var recipeName = (string) gOb[(byte)GlobalObjectsColumns.globalObjectName];
                var recipeDescription = (string) sR[(byte)ScriptableRecipesColumns.recipeDescription];
                var recipeTierId = (byte) gOb[(byte)GlobalObjectsColumns.globalTierId];
                var globalObjectTypeId = (byte) gOb[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var scriptableObjectPath = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var containerTypeId = (byte) sR[(byte)ScriptableRecipesColumns.requiredContainerTypeId];
                var craftDuration = (float) (decimal) sR[(byte)ScriptableRecipesColumns.craftDuration];
                var requiredSkillTier = (byte) sR[(byte)ScriptableRecipesColumns.minimumSkillRankId];
                var requiredSkillLevel = (byte) sR[(byte)ScriptableRecipesColumns.minimumSkillLevelId];
                var recipeExperience = (uint) (int) sR[(byte)ScriptableRecipesColumns.experienceTotalSkill];
                var dynamicRecipe = (bool) sR[(byte)ScriptableRecipesColumns.dynamicRecipe];
                RecipeModel recipe = new RecipeModel(recipeId, globalObject, globalStatusId, recipeName, recipeDescription, 
                    recipeTierId, skillId, globalObjectTypeId, scriptableObjectPath, containerTypeId, craftDuration, 
                    requiredSkillTier, requiredSkillLevel, recipeExperience, dynamicRecipe);
                recipeData.Add(globalObject, recipe);


            }
#if UNITY_EDITOR
            if(recipeData.Count == 0) Logger!.LogWarning($"ERROR: Recipes_GetList - 0 Results");
#endif
            return recipeData;
        }
        public static Dictionary<string, Dictionary<byte, List<RecipeIngredientModel>>> Recipes_GetIngredients()
        {
            Dictionary<string, Dictionary<byte, List<RecipeIngredientModel>>> ingredientData = new Dictionary<string, Dictionary<byte, List<RecipeIngredientModel>>>();

            foreach (DataRow sR in Instance!._dataTables.ScriptableRecipesDataTable.Rows)
            {
                string recipeGlobalObject = (string)sR[(byte)ScriptableRecipesColumns.globalObject];
                var    gOb                  = Instance._dataTables.GlobalObjectsDictionary[recipeGlobalObject];
                //var    globalStatusId             = (byte) gOb[(byte)GlobalObjectsColumns.statusId];
                
                foreach (DataRow rI in Instance._dataTables.ScriptableRecipeIngredientsDataTable.Rows)
                {
                    if(rI.RowState == DataRowState.Deleted) continue;
                    
                    if((string)rI[(byte)ScriptableRecipeIngredientsColumns.globalObject] != recipeGlobalObject) continue;
                    
                    string ingredientGlobalObject = (string)rI[(byte)ScriptableRecipeIngredientsColumns.ingredientGlobalObject];
                    var globalStatusId = (byte) gOb[(byte)GlobalObjectsColumns.statusId];
                    byte ingredientQuantity = (byte)rI[(byte)ScriptableRecipeIngredientsColumns.quantity];
                    float ingredientWeight = (byte)rI[(byte)ScriptableRecipeIngredientsColumns.ingredientWeight]/100f;
                    byte ingredientSlot = (byte)rI[(byte)ScriptableRecipeIngredientsColumns.ingredientSlotId];
                    bool primaryIngredient = (bool)rI[(byte)ScriptableRecipeIngredientsColumns.primaryIngredient];
                    RecipeIngredientModel ingredient = new RecipeIngredientModel(ingredientGlobalObject, globalStatusId,
                        ingredientQuantity, ingredientWeight, ingredientSlot, primaryIngredient);
                
                    if (!ingredientData.ContainsKey(recipeGlobalObject)) ingredientData.Add(recipeGlobalObject, new Dictionary<byte, List<RecipeIngredientModel>>());
                    if(!ingredientData[recipeGlobalObject].ContainsKey(ingredientSlot)) ingredientData[recipeGlobalObject].Add(ingredientSlot, new List<RecipeIngredientModel>());
                    ingredientData[recipeGlobalObject][ingredientSlot].Add(ingredient);
                }   
            }
#if UNITY_EDITOR
            if(ingredientData.Count == 0) Logger!.LogWarning($"ERROR: Recipes_GetIngredients - 0 Results");
#endif
            return ingredientData;
        }

        public static Dictionary<string, RecipeProductModel> Recipes_GetProducts()
        {
            Dictionary<string, RecipeProductModel> recipeData = new Dictionary<string, RecipeProductModel>();
            
            foreach (DataRow sR in Instance!._dataTables.ScriptableRecipesDataTable.Rows)
            {
                string globalObject = (string) sR[(byte)ScriptableRecipesColumns.globalObject];
                var gOb = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var statusId = (byte) gOb[(byte)GlobalObjectsColumns.statusId];
                
                var productGlobalObject = (string) sR[(byte)ScriptableRecipesColumns.productGlobalObject];
                var productQuantity       = (byte) sR[(byte)ScriptableRecipesColumns.productQuantity]; 
                recipeData.Add(globalObject, new RecipeProductModel(productGlobalObject, statusId, productQuantity));
            }
#if UNITY_EDITOR
            if(recipeData.Count == 0) Logger!.LogWarning($"ERROR: Recipes_GetProducts - 0 Results");
#endif
            return recipeData;
        }
        public static Dictionary<string, List<ushort>> StatEffects_GetList()
        {
            Dictionary<string, List<ushort>> myDict = new Dictionary<string, List<ushort>>();
            
            foreach (DataRow eGtim in Instance!._dataTables.EffectGroupsToItemsMappingDataTable.Rows)
            {
                string effectGroupGlobalObject = (string)(eGtim[(byte)EffectGroupsToItemsMappingColumns.effectGroupGlobalObject]);
                var eG = Instance._dataTables.EffectGroupsDictionary[effectGroupGlobalObject];
                //var sO = Instance._dataTables.ScriptableObjectsDictionary[effectGroupGlobalObject];
                string globalObject = (string)eGtim[(byte)EffectGroupsToItemsMappingColumns.scriptableItemGlobalObject];
                var statusId = (byte)Instance._dataTables.GlobalObjectsDictionary[globalObject][
                        (byte)GlobalObjectsColumns.statusId];
                if ((GlobalStatusTypes) statusId == GlobalStatusTypes.Locked) continue;
                
                                ushort statusEffectId = (ushort)(int)eG[(byte)EffectGroupsColumns.effectGroupId];
                if (!myDict.ContainsKey(globalObject)) myDict.Add(globalObject, new List<ushort>());
                myDict[globalObject].Add(statusEffectId);
            }
            #if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: StatEffects_GetList - 0 Results");
            #endif
            return myDict;
        }
        public static Dictionary<byte, Dictionary<byte, LevelModel>> SkillExperienceRequired_GetList()
        {
            Dictionary<byte, Dictionary<byte, LevelModel>> myDict = new Dictionary<byte, Dictionary<byte, LevelModel>>();
            foreach (DataRow lRS in Instance!._dataTables.LevelRequirementsSkillsDataTable.Select())
            {
                byte skillRank  = (byte)lRS[(byte)LevelRequirementsColumns.rankId];
                byte skillLevel = (byte)lRS[(byte)LevelRequirementsColumns.levelId];
                
                if (!myDict.ContainsKey(skillRank)) myDict.Add(skillRank, new Dictionary<byte, LevelModel>());
                int experienceRequired = (int)lRS[(byte)LevelRequirementsColumns.minExperience];
                int maxExperience      = (int)lRS[(byte)LevelRequirementsColumns.maxExperience];

                myDict[skillRank].Add(skillLevel, new LevelModel(experienceRequired, maxExperience));
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: SkillExperienceRequired_GetList - 0 Results");
#endif
            return myDict;
        }

        public static Dictionary<byte, float> SkillDifficultyMultipliers_GetList()
        {
            Dictionary<byte, float> myDict = new Dictionary<byte, float>();
            foreach (DataRow sDT in Instance!._dataTables.SkillDifficultyTiersDataTable.Select())
            {
                byte skillTier = (byte)sDT[(byte)SkillDifficultyTiersColumns.skillDifficultyTierId];
                float difficultyMultiplier = (float)(decimal)sDT[(byte)SkillDifficultyTiersColumns.skillDifficultyExperiencePenalty];

                myDict.Add(skillTier, difficultyMultiplier);
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: SkillDifficultyMultipliers_GetList - 0 Results");
#endif
            return myDict;
        }

        public static Dictionary<ushort, StatusEffectModel> StatusEffects_GetList()
        {
            Dictionary<ushort, StatusEffectModel> statusEffects = new  Dictionary<ushort, StatusEffectModel>();
            foreach (DataRow eG in Instance!._dataTables.EffectGroupsDataTable.Rows)
            {
                string globalObject = (string) eG[(byte)EffectGroupsColumns.effectGroupGlobalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var statusId = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                
                var   statusEffectId          = (ushort) (int) eG[(byte)EffectGroupsColumns.effectGroupId];
                var   globalObjectPath        = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var   statusEffectName        = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var   description             = (string) eG[(byte)EffectGroupsColumns.description];
                var   duration                = (int) eG[(byte)EffectGroupsColumns.duration];
                short maxStacks               = (short) eG[(byte)EffectGroupsColumns.maxStacks];
                var   globalObjectTypeId      = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var   damageCancels           = (bool)eG[(byte)EffectGroupsColumns.damageCancels];
                var   applicationTypeId       = (ApplicationTypes)(byte)eG[(byte)EffectGroupsColumns.applicationTypeId];
                var   numTimesApplied         = (short) eG[(byte)EffectGroupsColumns.numTimesApplied];
                var   timeBetweenApplications = (float) (decimal) eG[(byte)EffectGroupsColumns.timeBetweenApplications];
                var   removeWhenEffectEnds    = (bool) eG[(byte)EffectGroupsColumns.removeWhenEffectEnds];
                var statusEffectData = new StatusEffectModel(statusEffectId, globalObject, statusId, globalObjectPath, 
                    statusEffectName, description, duration, maxStacks, globalObjectTypeId, damageCancels, applicationTypeId, numTimesApplied, timeBetweenApplications, removeWhenEffectEnds);
                    
                statusEffects.Add(statusEffectData.StatusEffectId, statusEffectData);
            }
#if UNITY_EDITOR
            if(statusEffects.Count == 0) Logger!.LogWarning($"ERROR: StatusEffects_GetList - 0 Results");
#endif
            return statusEffects;
        }

        public static Dictionary<string, List<StatEffectModel>> StatusEffect_EffectsGetList()
        {
            Dictionary<string, List<StatEffectModel>> myDict = new Dictionary<string, List<StatEffectModel>>();
            
            //Logger.Log($"StatusEffect_EffectsGetList: {Instance!._dataTables.StatEffectsDictionary.Count}");
            foreach (var sE in Instance!._dataTables.StatEffectsDictionary)
            {
                string globalObject = sE.Key;
                if (Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode.ContainsKey(globalObject))
                {
                    //Logger.Log($"<color=green>StatusEffect_EffectsGetList: {globalObject}</color>");
                    var nestedEffectGlobalObjects = Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode[globalObject];
                    foreach (var eTegm in nestedEffectGlobalObjects)
                    {
                                        var effectGroupGlobalObject = eTegm.Key;
                        //var eG = Instance._dataTables.EffectGroupsDictionary[effectGroupGlobalObject];

                        var statusEffectAmount = (int)sE.Value[(byte)StatEffectsColumns.statEffectAmount];
                        var statusEffectAmountTypeId = (byte)sE.Value[(byte)StatEffectsColumns.statEffectAmountTypeId];
                        var statTypeId = (byte)sE.Value[(byte)StatEffectsColumns.statTypeId];
                        var statId = (byte)sE.Value[(byte)StatEffectsColumns.statId];
                        
                        StatEffectModel effectData = new StatEffectModel(statTypeId, statId, statusEffectAmountTypeId, statusEffectAmount);
                        
                        if (!myDict.ContainsKey(effectGroupGlobalObject))
                            myDict.Add(effectGroupGlobalObject, new List<StatEffectModel>());
                        myDict[effectGroupGlobalObject].Add(effectData);
                    }
                }
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: StatusEffect_EffectsGetList - 0 Results");
#endif
            return myDict;
        }
        
        public static Dictionary<string, SkillModel> Skills_GetList()
        {
            Dictionary<string, SkillModel> myDict = new Dictionary<string, SkillModel>();
            foreach (DataRow sK in Instance!._dataTables.ScriptableSkillsDataTable.Rows)
            {
                string globalObject = (string)(sK[(byte)ScriptableSkillsColumns.globalObject]);
                var glO              = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var statusId         = (byte)(glO[(byte)GlobalObjectsColumns.statusId]);
                var sO                      = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var bsK                     = Instance._dataTables.ScriptableSkillsDictionary[globalObject];
                var baseSkillGlobalObject = (string)(bsK[(byte)ScriptableSkillsColumns.baseSkillGlobalObject]);
                var bsO                     = Instance._dataTables.ScriptableObjectsDictionary[baseSkillGlobalObject];
                    
                var skillId = (ushort)(int)sK[(byte)ScriptableSkillsColumns.scriptableSkillId];
                var globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var skillName = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var skillDescription = (string)sK[(byte)ScriptableSkillsColumns.skillDescription];
                var skillCategoryTypeId = (byte)sK[(byte)ScriptableSkillsColumns.skillCategoryId];
                var skillTierId = (byte)sK[(byte)ScriptableSkillsColumns.skillDifficultyTierId];
                var skillTypeId = (byte)sK[(byte)ScriptableSkillsColumns.skillTypeId];
                var baseSkillPath = (string)bsO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                    
                var skillData = new SkillModel(skillId, globalObject, statusId, globalObjectPath, skillName, skillDescription,
                    skillCategoryTypeId, skillTierId, skillTypeId, baseSkillPath, globalObjectTypeId);
                myDict.Add(globalObject, skillData);

            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: Skills_GetList - 0 Results");
#endif
            return myDict;
        }

        public static Dictionary<string, List<UnlockEffectModel>> UnlockEffects_GetList()
        {
            Dictionary<string, List<UnlockEffectModel>> myDict = new Dictionary<string, List<UnlockEffectModel>>();

            foreach (DataRow uE in Instance!._dataTables.UnlockEffectsDataTable.Select())
            {
                var  globalObject       = (string) uE[(byte)UnlockEffectsColumns.globalObject];
                var  unlockGlobalObject = (string) uE[(byte)UnlockEffectsColumns.unlockGlobalObject];

                if (Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode.ContainsKey(globalObject))
                {
                    var nestedEffectGlobalObjects = Instance._dataTables.EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode[globalObject];
                    

                    //var eTegmList = nestedEffectGlobalObjects[effectGroupGlobalObject];

                    foreach (var eTegm in nestedEffectGlobalObjects)
                    {
                        byte unlockEffectTypeId = (byte)uE[(byte)UnlockEffectsColumns.unlockEffectTypeId];
                        byte unlockRank         = (byte)uE[(byte)UnlockEffectsColumns.unlockRankId];
                        byte unlockLevel        = (byte)uE[(byte)UnlockEffectsColumns.unlockLevelId];
                        byte unlockGlobalStatusId        = (byte)Instance._dataTables.GlobalObjectsDictionary[unlockGlobalObject][(byte)GlobalObjectsColumns.statusId];
                        var unlockEffectData = new UnlockEffectModel(unlockGlobalObject, unlockGlobalStatusId, unlockEffectTypeId,
                            unlockRank, unlockLevel);

                        var effectGroupGlobalObject = eTegm.Key;
                        //byte effectGroupGlobalStatusId        = (byte)Instance._dataTables.GlobalObjectsDictionary[effectGroupGlobalObject][(byte)GlobalObjectsColumns.statusId];
                        if (!myDict.ContainsKey(effectGroupGlobalObject)) myDict.Add(effectGroupGlobalObject, new List<UnlockEffectModel> {unlockEffectData});
                        else myDict[effectGroupGlobalObject].Add(unlockEffectData);
                    }
                }
                
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: UnlockEffects_GetList - 0 Results");
#endif
            return myDict;
        }

        public static Dictionary<string, List<WeaponPositionModel>> WeaponPositions_GetList()
        {
            Dictionary<string, List<WeaponPositionModel>> weaponsPositions = new Dictionary<string, List<WeaponPositionModel>>();
            
            foreach (DataRow wP in Instance!._dataTables.WeaponsPositionsDataTable.Select()) 
            {

                string globalObject = (string)wP[(byte)WeaponsPositionsColumns.globalObject];

                byte                equipmentSlotTypeId = (byte)wP[(byte)WeaponsPositionsColumns.weaponSlotTypeId];
                float               positionX           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.positionX];
                float               positionY           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.positionY];
                float               positionZ           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.positionZ];
                float               rotationX           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.rotationX];
                float               rotationY           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.rotationY];
                float               rotationZ           = (float)(decimal)wP[(byte)WeaponsPositionsColumns.rotationZ];
                WeaponPositionModel weaponsPositionData = new WeaponPositionModel(equipmentSlotTypeId, positionX, positionY, positionZ, rotationX, rotationY, rotationZ);

                //Logger!.Log($"{globalObject}, {weaponsPositionData.equipmentSlotTypeId}, {weaponsPositionData.positionX}");
                if (!weaponsPositions.ContainsKey(globalObject)) weaponsPositions.Add(globalObject, new List<WeaponPositionModel>());
                weaponsPositions[globalObject].Add(weaponsPositionData);
            }
#if UNITY_EDITOR
            if(weaponsPositions.Count == 0) Logger!.LogWarning($"ERROR: WeaponPositions_GetList - 0 Results");
#endif
            return weaponsPositions;
        }


        #endregion
        
        #region DATA TABLE STP GETS: SCRIPTABLE
        public static List<ScriptableArmorModel> ScriptableItems_ArmorGetList()
        {
            List<ScriptableArmorModel> armors = new List<ScriptableArmorModel>();
            
            foreach (var row in Instance!._dataTables.ScriptableArmorDictionary)
            {
                var            sA             = row.Value;
                string globalObject = row.Key;
                var            sE             = Instance._dataTables.ScriptableEquipmentDictionary[globalObject];
                var            sI             = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var            sO             = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var            glO            = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{GlobalObjectsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];
                
                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByGlobalObject.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByGlobalObject[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                ushort skillId = 0;
                if (Instance._dataTables.ScriptableSkillsDictionary.ContainsKey(globalObject)) skillId = (ushort)(int)Instance._dataTables.ScriptableSkillsDictionary[(string)sE[(byte)ScriptableEquipmentColumns.skillGlobalObject]][(byte)ScriptableSkillsColumns.scriptableSkillId];

                var    itemId             = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath   = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId     = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName           = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    itemDescription    = (string)sI[(byte)ScriptableItemsColumns.itemDescription];
                var    weight             = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack           = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue          = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability      = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity       = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                int    defense            = (int)sE[(byte)ScriptableEquipmentColumns.defense];
                string equipEffect        = (string)sE[(byte)ScriptableEquipmentColumns.equipmentDescription];
                byte   globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   itemTypeId         = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                byte   equipmentTypeId    = (byte)sE[(byte)ScriptableEquipmentColumns.equipmentMainTypeId];
                byte   armorSlotTypeId    = (byte)sA[(byte)ScriptableArmorColumns.armorSlotTypeId];
                byte   armorTypeId        = (byte)sA[(byte)ScriptableArmorColumns.armorClassificationTypeId];
                string armorPrefabPath    = (string) sA[(byte)ScriptableArmorColumns.armorPrefabPath];
                
                var armorData = new ScriptableArmorModel(itemId, globalObjectPath,globalObject, globalStatusId, itemName, 
                    itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId,  qualityId, maxQualityId,
                    maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId, defense, 
                    skillId, equipmentTypeId, equipEffect, armorSlotTypeId, armorTypeId, armorPrefabPath);
                armors.Add(armorData);
            }
#if UNITY_EDITOR
            if(armors.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_ArmorGetList - 0 Results");
#endif
            return armors;
        }
        public static List<ScriptableJeweleryModel> ScriptableItems_JeweleryGetList()
        {
            List<ScriptableJeweleryModel> jewelery = new List<ScriptableJeweleryModel>();
            
            foreach (var row in Instance!._dataTables.ScriptableJeweleryDictionary)
            {
                var            sJ             = row.Value;
                string globalObject = row.Key;
                var            sE             = Instance._dataTables.ScriptableEquipmentDictionary[globalObject];
                var            sI             = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var            sO             = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var            glO            = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];
                
                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                ushort skillId = 0;
                if (Instance._dataTables.ScriptableSkillsDictionary.ContainsKey(globalObject))
                {
                    skillId = (ushort)(int)Instance._dataTables.ScriptableSkillsDictionary[(string)sE[(byte)ScriptableEquipmentColumns.skillGlobalObject]][(byte)ScriptableSkillsColumns.scriptableSkillId];
                }

                var    itemId             = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath   = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId     = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName           = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    itemDescription    = (string)sI[(byte)ScriptableItemsColumns.itemDescription];
                var    weight             = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack           = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue          = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability      = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity       = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                int    defense            = (int)sE[(byte)ScriptableEquipmentColumns.defense];
                string equipEffect        = (string)sE[(byte)ScriptableEquipmentColumns.equipmentDescription];
                byte   globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   itemTypeId         = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                byte   equipmentTypeId    = (byte)sE[(byte)ScriptableEquipmentColumns.equipmentMainTypeId];
                byte   jewelerySlotTypeId = (byte)sJ[(byte)ScriptableJewelryColumns.jewelrySlotTypeId];
                byte   jeweleryTypeId     = (byte)sJ[(byte)ScriptableJewelryColumns.jewelryClassificationTypeId];
                
                var jeweleryData = new ScriptableJeweleryModel(itemId, globalObjectPath,globalObject, globalStatusId, itemName, 
                    itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId,
                    maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId, defense, 
                    skillId, equipmentTypeId, equipEffect, jewelerySlotTypeId, jeweleryTypeId);
                jewelery.Add(jeweleryData);
            }
#if UNITY_EDITOR
            if(jewelery.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_JeweleryGetList - 0 Results");
#endif
            return jewelery;
        }

        public static Dictionary<string, List<EquipmentRequirementModel>> ScriptableItems_EquipmentRequirementsGetList()
        {
            Dictionary<string, List<EquipmentRequirementModel>> myDict = new Dictionary<string, List<EquipmentRequirementModel>>();
            
            foreach (DataRow sER in Instance!._dataTables.ScriptableEquipmentRequirementsDataTable.Rows)
            {
                string globalObject = (string) sER[(byte)ScriptableEquipmentRequirementsColumns.globalObject];
                
                byte requiredStatTypeId = (byte)sER[(byte)ScriptableEquipmentRequirementsColumns.requiredStatTypeId];
                byte requiredStatId = (byte)sER[(byte)ScriptableEquipmentRequirementsColumns.requiredStatId];
                int requiredAmount = (int)sER[(byte)ScriptableEquipmentRequirementsColumns.requiredAmount];
                
                EquipmentRequirementModel equipmentRequirementModel = new EquipmentRequirementModel(requiredStatTypeId, requiredStatId, requiredAmount);
                if(!myDict.ContainsKey(globalObject)) myDict.Add(globalObject, new List<EquipmentRequirementModel>());
                myDict[globalObject].Add(equipmentRequirementModel);
            }
#if UNITY_EDITOR
            if(myDict.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_EquipmentRequirementsGetList - 0 Results");
#endif
            return myDict;
        }

        public static List<ScriptableBagModel> ScriptableItems_BagsGetList()
        {
            List<ScriptableBagModel> bags = new List<ScriptableBagModel>();
            
            
            foreach (DataRow sB in Instance!._dataTables.ScriptableBagsDataTable.Select())
            {
                string globalObject = (string) sB[(byte)ScriptableBagsColumns.globalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];
                //
                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                var    itemId             = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath   = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId     = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName           = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    weight             = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack           = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue          = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue        = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability      = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity       = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                var    itemDescription    = (string)sI[(byte)ScriptableItemsColumns.itemDescription];
                var    globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var    itemTypeId         = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var    baseSize           = (byte)sB[(byte)ScriptableBagsColumns.slots];
                var    bagTypeId          = (byte) sB[(byte)ScriptableBagsColumns.bagMainTypeId];
                var    equipEffect        = (string)sB[(byte)ScriptableBagsColumns.description];
                var bagData = new ScriptableBagModel(itemId, globalObjectPath, globalObject, globalStatusId, itemName, itemDescription, 
                    weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId,maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity, 
                    prefabFilePath, globalObjectTypeId, itemTypeId, baseSize, bagTypeId, equipEffect);
                bags.Add(bagData);
            }
#if UNITY_EDITOR
            if(bags.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_BagsGetList - 0 Results");
#endif
            return bags;
        }

        public static List<ScriptableConsumableModel> ScriptableItems_ConsumablesGetList()
        {
            List<ScriptableConsumableModel> consumables = new List<ScriptableConsumableModel>();
            
            foreach (DataRow sC in Instance!._dataTables.ScriptableConsumablesDataTable.Select())
            {
                string globalObject = (string) sC[(byte)ScriptableConsumablesColumns.globalObject];
                var sI               = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var sO               = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO              = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];

                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                var    itemId           = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId   = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName         = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    weight           = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack         = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue        = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId           = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId         = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability    = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity     = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                var    itemDescription  = (string)sI[(byte)ScriptableItemsColumns.itemDescription];

                var globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var itemTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var consumableMainTypeId = (byte)sC[(byte)ScriptableConsumablesColumns.consumableMainTypeId];
                var consumableClassificationTypeId = (byte)sC[(byte)ScriptableConsumablesColumns.consumableClassificationTypeId];
                var consumableSubTypeId = (byte)sC[(byte)ScriptableConsumablesColumns.consumableSubTypeId];
                var useEffect = (string)sC[(byte)ScriptableConsumablesColumns.description];
                
                var consumableData = new ScriptableConsumableModel(itemId, globalObjectPath, globalObject, globalStatusId, itemName, 
                    itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability,
                    manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId, consumableMainTypeId, 
                    consumableClassificationTypeId, consumableSubTypeId, useEffect);
                consumables.Add(consumableData);
            }
#if UNITY_EDITOR
            if(consumables.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_ConsumablesGetList - 0 Results");
#endif
            return consumables;
        }
        
        public static Dictionary<string, Dictionary<byte, List<EntityAbilityRank>>> ScriptableEntities_AbilitiesGetList()
        {
            Dictionary<string, Dictionary<byte, List<EntityAbilityRank>>> abilityRanks =
                new Dictionary<string, Dictionary<byte, List<EntityAbilityRank>>>();

            foreach (DataRow aRTORM in Instance!._dataTables.AbilityRanksToObjectRanksMappingDataTable.Rows)
            {
                string entityGlobalObject  = (string) aRTORM[(byte)AbilityRanksToObjectRanksMappingColumns.globalObject];
                var entityRankId            = (byte) (aRTORM[(byte)AbilityRanksToObjectRanksMappingColumns.rankId]);
                string abilityGlobalObject = (string) (aRTORM[(byte)AbilityRanksToObjectRanksMappingColumns.abilityGlobalObject]);
                var abilityRankId           = (byte) aRTORM[(byte)AbilityRanksToObjectRanksMappingColumns.abilityRankId];
                
                
                if (Instance._dataTables.ScriptableObjectRanksDictionaryByNestedObjectCode.ContainsKey(entityGlobalObject))
                {
                    if (Instance._dataTables.ScriptableObjectRanksDictionaryByNestedObjectCode.ContainsKey(abilityGlobalObject))
                    {
                        if (!abilityRanks.ContainsKey(entityGlobalObject))
                            abilityRanks.Add(entityGlobalObject, new Dictionary<byte, List<EntityAbilityRank>>());
                        if (!abilityRanks[entityGlobalObject].ContainsKey(entityRankId))
                            abilityRanks[entityGlobalObject].Add(entityRankId, new List<EntityAbilityRank>());
                        
                        var index       = (byte) abilityRanks[entityGlobalObject][entityRankId].Count;
                        var abilityRank = new EntityAbilityRank(index, abilityGlobalObject, abilityRankId);

                        abilityRanks[entityGlobalObject][entityRankId].Add(abilityRank);
                    }
                }
            }

            return abilityRanks;
        }

        public static List<ScriptableGeneralItemModel> ScriptableItems_GeneralGetList()
        {
            List<ScriptableGeneralItemModel> generalItems = new List<ScriptableGeneralItemModel>();
            
            foreach (DataRow sG in Instance!._dataTables.ScriptableGeneralItemsDataTable.Select())
            {
                string globalObject = (string) sG[(byte)ScriptableGeneralItemsColumns.globalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];
                
                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                var    itemId           = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId   = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName         = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    weight           = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack         = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue        = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId           = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability    = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity     = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                var    itemDescription  = (string)sI[(byte)ScriptableItemsColumns.itemDescription];

                var globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var itemTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var generalItemTypeId = (byte)sG[(byte)ScriptableGeneralItemsColumns.generalItemMainTypeId];
                var generalItemClassificationTypeId = (byte)sG[(byte)ScriptableGeneralItemsColumns.generalItemClassificationTypeId];
                var generalItem = new ScriptableGeneralItemModel(itemId, globalObject, globalStatusId, itemName, globalObjectPath, itemDescription, 
                    weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity,
                    prefabFilePath, globalObjectTypeId, itemTypeId, generalItemTypeId, generalItemClassificationTypeId, generalItemClassificationTypeId);
                generalItems.Add(generalItem);
                                  
            }
#if UNITY_EDITOR
            if(generalItems.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_GeneralGetList - 0 Results");
#endif
            return generalItems;
        }        
        public static List<ScriptableMaterialModel> ScriptableItems_MaterialsGetList()
        {
            List<ScriptableMaterialModel> materials = new List<ScriptableMaterialModel>();
            
            foreach (DataRow sM in Instance!._dataTables.ScriptableMaterialsDataTable.Select())
            {
                string globalObject = (string) sM[(byte)ScriptableMaterialsColumns.globalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];
                
                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                var    itemId           = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId   = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName         = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    weight           = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack         = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue        = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId           = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];

                ushort maxDurability    = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity     = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                var    itemDescription  = (string)sI[(byte)ScriptableItemsColumns.itemDescription];

                var globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var itemTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var materialTypeId = (byte)sM[(byte)ScriptableMaterialsColumns.materialMainTypeId];
                var materialClassificationTypeId = (byte)sM[(byte)ScriptableMaterialsColumns.materialClassificationTypeId];
                var materialSubTypeId = (byte)sM[(byte)ScriptableMaterialsColumns.materialSubTypeId];
                var ingredientName = (string)sM[(byte)ScriptableMaterialsColumns.ingredientName];
           
                var materialData = new ScriptableMaterialModel(itemId, globalObjectPath, globalObject, globalStatusId, itemName, itemDescription, 
                    weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity,
                    prefabFilePath, globalObjectTypeId, itemTypeId, materialTypeId, materialClassificationTypeId, 
                    materialSubTypeId,ingredientName);
                materials.Add(materialData);
                                  
            }
#if UNITY_EDITOR
            if(materials.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_MaterialsGetList - 0 Results");
#endif
            return materials;
        }
        
        public static Dictionary<string, List<ModifierModel>> ScriptableMaterials_ModifiersGetList()
        {
            Dictionary<string, List<ModifierModel>> materialModifiers = new Dictionary<string, List<ModifierModel>>();
            
            foreach (DataRow sMm in Instance!._dataTables.ScriptableMaterialModifiersDataTable.Select())
            {
                string globalObject = (string)sMm[(byte)ScriptableMaterialModifiersColumns.globalObject];
                if (!materialModifiers.ContainsKey(globalObject)) materialModifiers.Add(globalObject, new List<ModifierModel>());
                byte  modifierTypeId = (byte)sMm[(byte)ScriptableMaterialModifiersColumns.modifierTypeId];
                float modifierValue  = (float)(decimal)sMm[(byte)ScriptableMaterialModifiersColumns.modifierMultiplier];
                
                materialModifiers[globalObject].Add(new ModifierModel(modifierTypeId, modifierValue));
            }
#if UNITY_EDITOR
            if(materialModifiers.Count == 0) Logger!.LogWarning($"ERROR: ScriptableMaterials_ModifiersGetList - 0 Results");
#endif
            return materialModifiers;
        }      
        
        public static List<ScriptableWeaponModel> ScriptableItems_WeaponsGetList()
        {
            List<ScriptableWeaponModel> weapons = new List<ScriptableWeaponModel>();
            
            foreach (var row in Instance!._dataTables.ScriptableWeaponsDictionary)
            {
                var sW = row.Value;
                var globalObject = row.Key;
                var sE = Instance._dataTables.ScriptableEquipmentDictionary[globalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var prefabFilePath = "";
                var prefabs = Instance._dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject} = '{globalObject}'");
                if (prefabs.Length != 0) prefabFilePath = (string)prefabs[0][(byte)PrefabsColumns.prefabFilePath];

                // ushort recipeId = 0;
                // if (Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode.ContainsKey(globalObject))
                // {
                //     recipeId = (ushort)(int)Instance._dataTables.ScriptableRecipesDictionaryByProductGlobalObjectCode[globalObject][(byte)ScriptableRecipesColumns.scriptableRecipeId];
                // }
                
                ushort skillId = 0;
                if (Instance._dataTables.ScriptableSkillsDictionary.ContainsKey(globalObject)) skillId = (ushort)(int)Instance._dataTables.ScriptableSkillsDictionary[(string)sE[(byte)ScriptableEquipmentColumns.skillGlobalObject]][(byte)ScriptableSkillsColumns.scriptableSkillId];

                var    itemId           = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    globalStatusId   = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var    itemName         = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    weight           = (float)(decimal)sI[(byte)ScriptableItemsColumns.itemWeight];
                var    maxStack         = (byte)sI[(byte)ScriptableItemsColumns.itemStackMax];
                var    goldValue        = (uint)(int)sI[(byte)ScriptableItemsColumns.itemValueGold];
                var    silverValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueSilver];
                var    copperValue      = (byte)sI[(byte)ScriptableItemsColumns.itemValueCopper];
                var    tierId           = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                var    rarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityBaseId];
                var    maxRarityId           = (byte)sI[(byte)ScriptableItemsColumns.itemRarityMaxId];
                var    qualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityBaseId];
                var    maxQualityId          = (byte)sI[(byte)ScriptableItemsColumns.itemQualityMaxId];
                ushort maxDurability    = (ushort) (int) sI[(byte)ScriptableItemsColumns.itemDurabilityMax];
                ushort manaCapacity     = (ushort) (int)sI[(byte)ScriptableItemsColumns.itemManaCapacity];
                var    itemDescription  = (string)sI[(byte)ScriptableItemsColumns.itemDescription];

                var    defense = (int)sE[(byte)ScriptableEquipmentColumns.defense];
                var    globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var    itemTypeId = (byte)sI[(byte)ScriptableItemsColumns.itemTypeId];
                var    equipmentTypeId = (byte)sE[(byte)ScriptableEquipmentColumns.equipmentMainTypeId];

                var equipEffect = (string)sE[(byte)ScriptableEquipmentColumns.equipmentDescription];
                var minDamage =  (float)(decimal)sW[(byte)ScriptableWeaponsColumns.minDamage];
                var attackSpeed = (float)(decimal)sW[(byte)ScriptableWeaponsColumns.attackSpeed];
                var weaponSlotId = (byte)sW[(byte)ScriptableWeaponsColumns.weaponSlotId];
                var weaponTypeId = (byte)sW[(byte)ScriptableWeaponsColumns.weaponClassificationTypeId];
                var damageTypeId = (byte)sW[(byte)ScriptableWeaponsColumns.damageTypeId];

                var weaponData = new ScriptableWeaponModel(itemId, globalObjectPath, globalObject, globalStatusId, itemName, itemDescription,
                    weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity,
                    prefabFilePath, globalObjectTypeId, itemTypeId, defense, skillId, equipmentTypeId, equipEffect,
                    minDamage, attackSpeed, weaponSlotId, weaponTypeId, damageTypeId);
                weapons.Add(weaponData);
            }
#if UNITY_EDITOR
            if(weapons.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_WeaponsGetList - 0 Results");
#endif
            return weapons;
        }

        public static Dictionary<string, List<RankModel>> ScriptableInteractables_RanksGetList()
        {
            Dictionary<string, List<RankModel>> ranks = new Dictionary<string, List<RankModel>>();

            foreach (DataRow sI in Instance!._dataTables.ScriptableInteractablesDataTable.Rows)
            {
                string globalObject = (string) sI[(byte)ScriptableInteractablesColumns.globalObject];
                if (!Instance._dataTables.ScriptableObjectsSpawnablesDictionaryByNestedObjectCode.ContainsKey(globalObject))
                {
                    Logger!.LogError($"{globalObject} has no ScriptableObjectRanks associated to it.");
                    continue;
                }
                if (!Instance._dataTables.WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode
                        .ContainsKey(globalObject))
                {
                    Logger!.LogError($"{globalObject} Rank has no Loot Table Associated to it.");
                    continue;
                }
                
                var sORs = Instance._dataTables.ScriptableObjectsSpawnablesDictionaryByNestedObjectCode[globalObject];
                ranks.Add(globalObject, new List<RankModel>());
                foreach (var sOS in sORs)
                {
                    var scriptableObjectSpawnable = (string)sOS[(byte)ScriptableObjectSpawnablesColumns.scriptableObjectSpawnable];
                    var wORs = Instance._dataTables.WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode[globalObject];
                    if (!wORs.ContainsKey(scriptableObjectSpawnable))
                    {
                        Logger.LogError($"WorldObjectsRanksToLootTables does not contain Rank {scriptableObjectSpawnable} for {globalObject}");
                        continue;
                    }
                    
                    byte dataAttributeId = 0;
                    if (Instance._dataTables.DataAttributesToGlobalObjectsDictionaryByWorldObjectGlobalObjectCode
                        .TryGetValue(globalObject, out var dA))
                    {
                        dataAttributeId = (byte) dA[(byte) DataAttributesToGlobalObjectsColumns.dataAttributeTypeId];
                    }
                    
                    var wOR = wORs[scriptableObjectSpawnable]; 
                    byte   globalStatusId        = (byte)Instance._dataTables.GlobalObjectsDictionary[globalObject][(byte)GlobalObjectsColumns.statusId];
                    string scriptableObjectRank  = (string) sOS[(byte)ScriptableObjectSpawnablesColumns.scriptableObjectSpawnable];
                    byte levelId = (byte)sOS[(byte)ScriptableObjectSpawnablesColumns.levelId];
                    byte variationId = (byte)sOS[(byte)ScriptableObjectSpawnablesColumns.variationId];
                    byte   allowedRolls          = (byte) wOR[(byte)SpawnablesToLootTablesColumns.allowedRolls];
                    string lootTableGlobalObject = (string)wOR[(byte)SpawnablesToLootTablesColumns.lootTableGlobalObject];
                    uint   minCurrencyReward     = (uint)(int) wOR[(byte)SpawnablesToLootTablesColumns.minCurrencyReward];
                    uint   maxCurrencyReward     = (uint)(int) wOR[(byte)SpawnablesToLootTablesColumns.maxCurrencyReward];
                    int   experienceRewardPlayer      = (int) wOR[(byte)SpawnablesToLootTablesColumns.experienceTotalPlayer];
                    int   experienceRewardSkill      = (int) wOR[(byte)SpawnablesToLootTablesColumns.experienceTotalSkill];
                    int   skillRequired      = (int) wOR[(byte)SpawnablesToLootTablesColumns.skillRequired];
                    byte imbuedType            = (byte) sOS[(byte)ScriptableObjectSpawnablesColumns.imbuedTypeId];
                    byte entityTypeId  = (byte) sI[(byte)ScriptableInteractablesColumns.interactableTypeId];
  
                    List<string> prefabPaths = new List<string>();
                    foreach (var prefabPath in Instance._dataTables.SpawnablesToPrefabsByWorldObjectGlobalObjectCode[globalObject][levelId][variationId])
                    {
                        prefabPaths.Add((string)prefabPath[(byte)SpawnablesToPrefabsColumns.prefabPath]);
                    }
                    
                    var rankData = new RankModel(scriptableObjectRank, globalStatusId, levelId, variationId, allowedRolls, lootTableGlobalObject,
                        minCurrencyReward, maxCurrencyReward, experienceRewardPlayer, experienceRewardSkill, skillRequired, dataAttributeId, imbuedType, entityTypeId, prefabPaths);
                    ranks[globalObject].Add(rankData);
                }
            }

            return ranks;
        }
        public static Dictionary<string, List<RankModel>> ScriptableEntities_RanksGetList()
        {
            Dictionary<string, List<RankModel>> ranks = new Dictionary<string, List<RankModel>>();

            foreach (DataRow sE in Instance!._dataTables.ScriptableEntitiesDataTable.Rows)
            {
                string globalObject = (string) sE[(byte)ScriptableEntitiesColumns.globalObject];
                if (!Instance._dataTables.ScriptableObjectsSpawnablesDictionaryByNestedObjectCode.ContainsKey(globalObject)) continue;
                if (!Instance._dataTables.WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode.ContainsKey(globalObject)) continue;
                
                var sORs = Instance._dataTables.ScriptableObjectsSpawnablesDictionaryByNestedObjectCode[globalObject];
                ranks.Add(globalObject, new List<RankModel>());
                foreach (var sOS in sORs)
                {
                    var scriptableObjectSpawnable = (string)sOS[(byte)ScriptableObjectSpawnablesColumns.scriptableObjectSpawnable];
                    var wORs = Instance._dataTables.WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode[globalObject];
                    if (!wORs.ContainsKey(scriptableObjectSpawnable))
                    {
                        Logger.LogError($"WorldObjectsRanksToLootTables does not contain Rank {scriptableObjectSpawnable} for {globalObject}");
                        continue;
                    }
                    
                    var wOR = wORs[scriptableObjectSpawnable]; 
                    
                    byte dataAttributeId = 0;
                    if (Instance._dataTables.DataAttributesToGlobalObjectsDictionaryByWorldObjectGlobalObjectCode
                        .TryGetValue(globalObject, out var dA))
                    {
                        dataAttributeId = (byte) dA[(byte) DataAttributesToGlobalObjectsColumns.dataAttributeTypeId];
                    }
                    string scriptableObjectRank = (string) sOS[(byte)ScriptableObjectSpawnablesColumns.scriptableObjectSpawnable];
                    byte   globalStatusId        = (byte)Instance._dataTables.GlobalObjectsDictionary[globalObject][(byte)GlobalObjectsColumns.statusId];
                    byte levelId = (byte)sOS[(byte)ScriptableObjectSpawnablesColumns.levelId];
                    byte variationId = (byte)sOS[(byte)ScriptableObjectSpawnablesColumns.variationId];
                    byte allowedRolls = (byte) wOR[(byte)SpawnablesToLootTablesColumns.allowedRolls];
                    string lootTableGlobalObject = (string) wOR[(byte)SpawnablesToLootTablesColumns.lootTableGlobalObject];
                    if (string.IsNullOrEmpty(lootTableGlobalObject))
                    {
                        Logger!.LogError($"Entity Rank {globalObject} Loot Table is null {lootTableGlobalObject}");
                    }
                    uint minCurrencyReward = (uint) (int) wOR[(byte)SpawnablesToLootTablesColumns.minCurrencyReward];
                    uint maxCurrencyReward = (uint) (int) wOR[(byte)SpawnablesToLootTablesColumns.maxCurrencyReward];
                    int experienceRewardPlayer  = (int) wOR[(byte)SpawnablesToLootTablesColumns.experienceTotalPlayer];
                    int experienceRewardSkill  = (int) wOR[(byte)SpawnablesToLootTablesColumns.experienceTotalSkill];
                    int skillRequired  = (int) wOR[(byte)SpawnablesToLootTablesColumns.skillRequired];
                    byte imbuedTypeId  = (byte) sOS[(byte)ScriptableObjectSpawnablesColumns.imbuedTypeId];
                    byte entityTypeId  = (byte) sE[(byte)ScriptableEntitiesColumns.entityTypeId];
                    
                    List<string> prefabPaths = new List<string>();
                    foreach (var prefabPath in Instance._dataTables.SpawnablesToPrefabsByWorldObjectGlobalObjectCode[globalObject][levelId][variationId])
                    {
                        prefabPaths.Add((string)prefabPath[(byte)SpawnablesToPrefabsColumns.prefabPath]);
                    }
                    
                    var rankData = new    RankModel(scriptableObjectRank, globalStatusId, levelId, variationId, allowedRolls, lootTableGlobalObject, 
                        minCurrencyReward, maxCurrencyReward, experienceRewardPlayer, experienceRewardSkill, skillRequired, dataAttributeId, imbuedTypeId, entityTypeId, prefabPaths);
                    ranks[globalObject].Add(rankData);
                }
            }

            return ranks;
        }
        public static Dictionary<string, TotalModel> ScriptableTotals_GetList()
        {
            Dictionary<string, TotalModel> totals = new Dictionary<string, TotalModel>();
            
            foreach (DataRow sT in Instance!._dataTables.ScriptableTotalsDataTable.Rows) 
            {
                string totalGlobalObject = (string)sT[(byte)ScriptableTotalsColumns.totalGlobalObject];
                var    sO                  = Instance._dataTables.ScriptableObjectsDictionary[totalGlobalObject];
                var    gLO                 = Instance._dataTables.GlobalObjectsDictionary[totalGlobalObject];
                
                ushort totalId = (ushort) (int) sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                string totalName = (string) gLO[(byte)GlobalObjectsColumns.globalObjectName];
                string scriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];

                TotalModel totalData = new TotalModel(totalId, totalGlobalObject, totalName, scriptableObjectPath);
                totals.Add(totalGlobalObject, totalData);
            }
#if UNITY_EDITOR
            if(totals.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_GetList - 0 Results");
#endif
            return totals;
        }
        public static Dictionary<ushort, List<ushort>> ScriptableTotals_MilestonesGetList()
        {
            Dictionary<ushort, List<ushort>> milestones = new Dictionary<ushort, List<ushort>>();
            
            foreach (DataRow sM in Instance!._dataTables.ScriptableMilestonesDataTable.Rows) 
            {
                var sT          = Instance._dataTables.ScriptableTotalsDictionary[(string)sM[(byte)ScriptableMilestonesColumns.milestoneTotalGlobalObject]];
                var totalId     = (ushort)(int)sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                var milestoneId = (ushort)(int)sM[(byte)ScriptableMilestonesColumns.scriptableMilestonesId];
                if (!milestones.ContainsKey(totalId)) milestones.Add(totalId, new List<ushort>());
                milestones[totalId].Add(milestoneId);
            }
#if UNITY_EDITOR
            if(milestones.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_MilestonesGetList - 0 Results");
#endif
            return milestones;
        }

        public static List<KillTotalModel> ScriptableTotals_KillsGetList()
        {
            List<KillTotalModel> killTotals = new List<KillTotalModel>();
            
            foreach (DataRow sTK in Instance!._dataTables.ScriptableTotalsKillsDataTable.Rows) 
            {
                string totalGlobalObject = (string)sTK[(byte)ScriptableTotalsKillColumns.totalGlobalObject];
                var sT = Instance._dataTables.ScriptableTotalsDictionary[totalGlobalObject];
                var sE = Instance._dataTables.ScriptableEntitiesDictionary[(string)sTK[(byte)ScriptableTotalsKillColumns.killRequiredGlobalObject]];
                
                var totalId = (ushort)(int)sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                var killTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.killTypeId];
                var killMainTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.killMainTypeId];
                var killClassificationTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.killClassificationTypeId];
                var killSubTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.killSubTypeId];
                var entityTierId = (byte) sTK[(byte)ScriptableTotalsKillColumns.killEntityTierId];
                var dataAttributeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.dataAttributeTypeId];
                var imbuedTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.imbuedTypeId];
                var difficultyTypeId = (byte) sTK[(byte)ScriptableTotalsKillColumns.difficultyTypeId];
                var entityId = (ushort) (int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];

                KillTotalModel killTotalData = new KillTotalModel(totalId, killTypeId, killMainTypeId,
                    killClassificationTypeId, killSubTypeId, entityTierId, dataAttributeId, imbuedTypeId, difficultyTypeId, entityId);
                killTotals.Add(killTotalData);
            }
#if UNITY_EDITOR
            if(killTotals.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_KillsGetList - 0 Results");
#endif
            return killTotals;
        }
        
        public static List<GatherTotalModel> ScriptableTotals_GatherGetList()
        {
            List<GatherTotalModel> gatherTotals = new List<GatherTotalModel>();
            
            foreach (DataRow sTG in Instance!._dataTables.ScriptableTotalsGatherDataTable.Rows) 
            {
                string totalGlobalObject = (string)sTG[(byte)ScriptableTotalsGatherColumns.totalGlobalObject];
                var sT = Instance._dataTables.ScriptableTotalsDictionary[totalGlobalObject];
                var sI = Instance._dataTables.ScriptableInteractablesDictionary[(string)sTG[(byte)ScriptableTotalsGatherColumns.gatherRequiredGlobalObject]];
                var totalId = (ushort)(int)sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                var gatherTypeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.gatherTypeId];
                var gatherMainTypeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.gatherMainTypeId];
                var gatherClassificationTypeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.gatherClassificationTypeId];
                var gatherSubTypeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.gatherSubTypeId];
                var tierId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.gatherTierId];
                var dataAttributeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.dataAttributeTypeId];
                var imbuedTypeId = (byte) sTG[(byte)ScriptableTotalsGatherColumns.imbuedTypeId];
                var scriptableInteractableId = (ushort) (int) sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                GatherTotalModel gatherTotalData = new GatherTotalModel(totalId, gatherTypeId, gatherMainTypeId, gatherClassificationTypeId,
                    gatherSubTypeId, tierId, dataAttributeId, imbuedTypeId, scriptableInteractableId);
                gatherTotals.Add(gatherTotalData);
            }
#if UNITY_EDITOR
            if(gatherTotals.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_GatherGetList - 0 Results");
#endif
            return gatherTotals;
        }
        
        public static List<CraftTotalModel> ScriptableTotals_CraftGetList()
        {
            List<CraftTotalModel> craftTotals = new List<CraftTotalModel>();
            
            foreach (DataRow sTC in Instance!._dataTables.ScriptableTotalsCraftDataTable.Rows) 
            {
                var totalGlobalObject = (string)sTC[(byte)ScriptableTotalsCraftColumns.totalGlobalObject];
                var sT = Instance._dataTables.ScriptableTotalsDictionary[totalGlobalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[(string)sTC[(byte)ScriptableTotalsCraftColumns.craftRequiredGlobalObject]];
                var totalId = (ushort)(int)sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                var craftedTypeId = (byte) sTC[(byte)ScriptableTotalsCraftColumns.craftTypeId];
                var craftedMainTypeId = (byte) sTC[(byte)ScriptableTotalsCraftColumns.craftMainTypeId];
                var craftedClassificationTypeId = (byte) sTC[(byte)ScriptableTotalsCraftColumns.craftClassificationTypeId];
                var craftedSubTypeId = (byte) sTC[(byte)ScriptableTotalsCraftColumns.craftSubTypeId];
                var rarityId = (byte) sTC[(byte)ScriptableTotalsCraftColumns.craftRarityId];
                var itemId = (ushort) (int) sI[(byte)ScriptableItemsColumns.scriptableItemId];
                CraftTotalModel craftTotalData = new CraftTotalModel(totalId, craftedTypeId, craftedMainTypeId, 
                    craftedClassificationTypeId, craftedSubTypeId, rarityId, itemId);
                craftTotals.Add(craftTotalData);
            }
#if UNITY_EDITORz   
            if(craftTotals.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_CraftGetList - 0 Results");
#endif
            return craftTotals;
        }
        
        public static List<CollectTotalModel> ScriptableTotals_CollectGetList()
        {
            List<CollectTotalModel> collectTotals = new List<CollectTotalModel>();
            
            foreach (DataRow sTC in Instance!._dataTables.ScriptableTotalsCollectDataTable.Rows) 
            {
                string totalGlobalObject = (string)sTC[(byte)ScriptableTotalsCollectColumns.totalGlobalObject];
                var sT = Instance._dataTables.ScriptableTotalsDictionary[totalGlobalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[(string)sTC[(byte)ScriptableTotalsCollectColumns.collectRequiredGlobalObject]];
                var totalId = (ushort)(int)sT[(byte)ScriptableTotalsColumns.scriptableTotalId];
                var collectTypeId = (byte) sTC[(byte)ScriptableTotalsCollectColumns.collectTypeId];
                var collectMainTypeId = (byte) sTC[(byte)ScriptableTotalsCollectColumns.collectMainTypeId];
                var collectClassificationTypeId = (byte) sTC[(byte)ScriptableTotalsCollectColumns.collectClassificationTypeId];
                var collectSubTypeId = (byte) sTC[(byte)ScriptableTotalsCollectColumns.collectSubTypeId];
                var rarityId = (byte) sTC[(byte)ScriptableTotalsCollectColumns.collectRarityId];
                var itemId = (ushort) (int) sI[(byte)ScriptableItemsColumns.scriptableItemId];
                CollectTotalModel collectTotalData = new CollectTotalModel(totalId, collectTypeId, collectMainTypeId, collectClassificationTypeId, collectSubTypeId, rarityId, itemId);
                collectTotals.Add(collectTotalData);
            }
#if UNITY_EDITOR
            if(collectTotals.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTotals_CollectGetList - 0 Results");
#endif
            return collectTotals;
        }
        public static Dictionary<string, MilestoneModel> ScriptableMilestones_GetList()
        {
            Dictionary<string, MilestoneModel> milestones = new Dictionary<string, MilestoneModel>();
            
            foreach (DataRow sM in Instance!._dataTables.ScriptableMilestonesDataTable.Rows) 
            {
                var milestoneGlobalObject = (string)sM[(byte)ScriptableMilestonesColumns.milestoneGlobalObject];
                var sO                      = Instance._dataTables.ScriptableObjectsDictionary[milestoneGlobalObject];
                var gLO                     = Instance._dataTables.GlobalObjectsDictionary[milestoneGlobalObject];
                
                ushort milestoneId = (ushort) (int) sM[(byte)ScriptableMilestonesColumns.scriptableMilestonesId];
                string milestoneName = (string) gLO[(byte)GlobalObjectsColumns.globalObjectName];
                uint requiredTotal = (uint)(int)sM[(byte)ScriptableMilestonesColumns.milestoneRequiredTotal];
                string scriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                
                MilestoneModel milestoneModel = new MilestoneModel(milestoneId, milestoneGlobalObject, milestoneName, 
                    requiredTotal, scriptableObjectPath);
                milestones.Add(milestoneGlobalObject, milestoneModel);
            }
            
            return milestones;
        }
        
        public static Dictionary<string, AchievementModel> ScriptableAchievements_GetList()
        {
            Dictionary<string, AchievementModel> achievements = new Dictionary<string, AchievementModel>();
            
            foreach (DataRow sA in Instance!._dataTables.ScriptableAchievementsDataTable.Rows) 
            {
                string globalObject = (string) sA[(byte)ScriptableAchievementsColumns.globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var gLO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                
                var achievementId = (ushort)(int)sA[(byte)ScriptableAchievementsColumns.achievementId];
                var achievementName = (string) gLO[(byte)GlobalObjectsColumns.globalObjectName];
                var achievementDescription = (string) sA[(byte)ScriptableAchievementsColumns.achievementDescription]; 
                var isUnique = (bool) sA[(byte)ScriptableAchievementsColumns.achievementIsUnique];
                var scriptableObjectPath = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                AchievementModel achievementModel = new AchievementModel(achievementId, globalObject, achievementName, 
                    achievementDescription, isUnique, scriptableObjectPath);
                achievements.Add(globalObject, achievementModel);
            }
#if UNITY_EDITOR
            if(achievements.Count == 0) Logger!.LogWarning($"ERROR: ScriptableAchievements_GetList - 0 Results");
#endif
            return achievements;
        }
        
        public static Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> ScriptableAchievements_PreReqsGetList()
        {
            Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> prereqs = new Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>>();
            
            foreach (DataRow sA in Instance!._dataTables.ScriptableAchievementsDataTable.Rows) 
            {
                string achievementGlobalObject = (string) sA[(byte)ScriptableAchievementsColumns.globalObject];
                if(!Instance._dataTables.ScriptableRequirementsDictionary.ContainsKey(achievementGlobalObject)) continue;
                var sRs = Instance._dataTables.ScriptableRequirementsDictionary[achievementGlobalObject];
                prereqs.Add(achievementGlobalObject, new Dictionary<byte, List<QuestObjectiveModel>>());
                foreach (var sR in sRs)
                {
                    byte objectiveTypeId = (byte) sR.Value[(byte)ScriptableRequirementsColumns.requirementTypeId];
                    if(!prereqs[achievementGlobalObject].ContainsKey((objectiveTypeId))) prereqs[achievementGlobalObject].Add(objectiveTypeId, new List<QuestObjectiveModel>());
                    var sO = Instance._dataTables.ScriptableObjectsDictionary[sR.Key];
                    var objectiveScriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                    string objectiveGlobalObject = (string)sO[(byte)ScriptableObjectsColumns.globalObject];
                    var requiredAmount = (short)sR.Value[(byte)ScriptableRequirementsColumns.numRequired];
                    prereqs[achievementGlobalObject][objectiveTypeId].Add(new QuestObjectiveModel(objectiveGlobalObject, 
                        objectiveScriptableObjectPath, "", 0,requiredAmount, objectiveTypeId));
                }
            }
#if UNITY_EDITOR
            if(prereqs.Count == 0) Logger!.LogWarning($"ERROR: ScriptableAchievements_PreReqsGetList - 0 Results");
#endif
            return prereqs;
        }
        public static Dictionary<string, TitleModel> ScriptableTitles_GetList()
        {
            Dictionary<string, TitleModel> titles = new Dictionary<string, TitleModel>();
            
            foreach (DataRow sT in Instance!._dataTables.ScriptableTitlesDataTable.Rows) 
            {
                var globalObject = (string) sT[(byte)ScriptableTitlesColumns.globalObject];
                //var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var gLO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                
                var titleId = (ushort)(int)sT[(byte)ScriptableTitlesColumns.titleId];
                var titleName = (string) gLO[(byte)GlobalObjectsColumns.globalObjectName];
                var titleDescription = (string) sT[(byte)ScriptableTitlesColumns.description];
                var isUpgradable = (bool) sT[(byte)ScriptableTitlesColumns.isUpgradable];
                var isUnique = (bool) sT[(byte)ScriptableTitlesColumns.isUnique];
                            
                TitleModel titleData = new TitleModel(titleId, globalObject, titleName, titleDescription, 
                    isUpgradable, isUnique);
                titles.Add(globalObject, titleData);
            }
#if UNITY_EDITOR
            if(titles.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTitles_GetList - 0 Results");
#endif
            return titles;
        }
        
        public static Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> ScriptableTitles_PreReqsGetList()
        {
            Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> prereqs = new Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>>();
            
            foreach (DataRow sT in Instance!._dataTables.ScriptableTitlesDataTable.Rows) 
            {
                string titleGlobalObject = (string) sT[(byte)ScriptableTitlesColumns.globalObject];
                if(!Instance._dataTables.ScriptableRequirementsDictionary.ContainsKey(titleGlobalObject)) continue;
                var sRs = Instance._dataTables.ScriptableRequirementsDictionary[titleGlobalObject];
                prereqs.Add(titleGlobalObject, new Dictionary<byte, List<QuestObjectiveModel>>());
                foreach (var sR in sRs)
                {
                    byte objectiveTypeId = (byte) sR.Value[(byte)ScriptableRequirementsColumns.requirementTypeId];
                    if(!prereqs[titleGlobalObject].ContainsKey((objectiveTypeId))) prereqs[titleGlobalObject].Add(objectiveTypeId, new List<QuestObjectiveModel>());
                    var sO = Instance._dataTables.ScriptableObjectsDictionary[sR.Key];
                    var objectiveScriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                    string objectiveGlobalObject = (string) sO[(byte)ScriptableObjectsColumns.globalObject];
                    var requiredAmount = (short)sR.Value[(byte)ScriptableRequirementsColumns.numRequired];
                    prereqs[titleGlobalObject][objectiveTypeId].Add(new QuestObjectiveModel(objectiveGlobalObject, objectiveScriptableObjectPath, "", 0,requiredAmount, objectiveTypeId));
                }
            }
#if UNITY_EDITOR
            if(prereqs.Count == 0) Logger!.LogWarning($"ERROR: ScriptableTitles_PreReqsGetList - 0 Results");
#endif
            return prereqs;
        }
        //QUESTS STATIC
        public static List<QuestLineModel> ScriptableQuests_GetQuestLines()
        {
            List<QuestLineModel> staticQuests = new List<QuestLineModel>();
            
            foreach (DataRow sQ in Instance!._dataTables.ScriptableQuestlinesDataTable.Rows) 
            {
                var questlineGlobalObject = (string)(sQ[(byte)ScriptableQuestlinesColumns.questlineGlobalObject]);
                var sO                      = Instance._dataTables.ScriptableObjectsDictionary[questlineGlobalObject];
                var glO                     = Instance._dataTables.GlobalObjectsDictionary[questlineGlobalObject];

                string globalObject       = (string)sQ[(byte)ScriptableQuestlinesColumns.questlineGlobalObject];
                byte globalStatusId      = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                string questLineName        = (string)sQ[(byte)ScriptableQuestlinesColumns.questlineName];
                string scriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];

                QuestLineModel staticQuest = new QuestLineModel(globalObject, globalStatusId, questLineName, scriptableObjectPath);
                staticQuests.Add((staticQuest));
            }
#if UNITY_EDITOR
            if(staticQuests.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetQuestLines - 0 Results");
#endif
            return staticQuests;
        }

        public static Dictionary<string, Dictionary<byte, List<string>>> ScriptableQuests_GetQuestLineOrder()
        {
            Dictionary<string, Dictionary<byte, List<string>>> questOrders = new Dictionary<string, Dictionary<byte, List<string>>>();
            
            foreach (DataRow sQqo in Instance!._dataTables.ScriptableQuestlineQuestOrderDataTable.Rows) 
            {
                string questGlobalObject = (string)(sQqo[(byte)ScriptableQuestlineQuestOrderColumns.questGlobalObject]);
                var sO = Instance._dataTables.ScriptableObjectsDictionary[questGlobalObject];
                
                string questLineGlobalObject = (string) sQqo[(byte)ScriptableQuestlineQuestOrderColumns.questlineGlobalObject];
                byte orderNum = (byte)sQqo[(byte)ScriptableQuestlineQuestOrderColumns.orderNum];
                var globalObject = (string)sO[(byte)ScriptableObjectsColumns.globalObject];

                if (!questOrders.ContainsKey(questLineGlobalObject)) questOrders.Add(questLineGlobalObject, new Dictionary<byte, List<string>>());
                if (!questOrders[questLineGlobalObject].ContainsKey(orderNum)) questOrders[questLineGlobalObject].Add(orderNum, new List<string>());
                questOrders[questLineGlobalObject][orderNum].Add(globalObject);
            }
#if UNITY_EDITOR
            if(questOrders.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetQuestLineOrder - 0 Results");
#endif
            return questOrders;
        }

        public static Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>> ScriptableQuests_LevelPrerequisitesGetList()
        {
            Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>> prereqs = 
                new Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>>();
            
            foreach (DataRow sQ in Instance!._dataTables.ScriptableQuestsDataTable.Rows)
            {
                var questGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.questGlobalObject]);
                if(!Instance._dataTables.ScriptableRequirementsDictionary.ContainsKey(questGlobalObject)) continue;
                var nestedScriptableRequirementsObjectCodes = Instance._dataTables.ScriptableRequirementsDictionary[questGlobalObject];

                //var eTegmList = nestedEffectGlobalObjects[effectGroupGlobalObject];

                foreach (var sR in nestedScriptableRequirementsObjectCodes)
                {
                    var requirementGlobalObject = sR.Key;

                    byte objectiveTypeId = (byte) sR.Value[(byte)ScriptableRequirementsColumns.requirementTypeId];
                    if (objectiveTypeId != (byte)RequirementTypes.Ability &&
                        objectiveTypeId != (byte)RequirementTypes.Level   &&
                        objectiveTypeId != (byte)RequirementTypes.Skill) continue;
                    var glO = Instance._dataTables.GlobalObjectsDictionary[requirementGlobalObject];

                    if (!prereqs.ContainsKey(questGlobalObject))
                        prereqs.Add(questGlobalObject, new Dictionary<byte, List<LevelObjectiveModel>>());
                    if (!prereqs[questGlobalObject].ContainsKey((objectiveTypeId)))
                        prereqs[questGlobalObject].Add(objectiveTypeId, new List<LevelObjectiveModel>());

                    var objectiveName = (string)glO[(byte)GlobalObjectsColumns.globalObjectNamePlural];
                    var rankId        = (byte) sR.Value[(byte)ScriptableRequirementsColumns.requirementLevelId];
                    var levelId       = (byte)sR.Value[(byte)ScriptableRequirementsColumns.requirementLevelId];
                    prereqs[questGlobalObject][objectiveTypeId].Add(
                        new LevelObjectiveModel(requirementGlobalObject, objectiveName, 1, objectiveTypeId, rankId, levelId));


                }
            }
#if UNITY_EDITOR
            if(prereqs.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_LevelPrerequisitesGetList - 0 Results");
#endif
            return prereqs;
        }

        public static Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> ScriptableQuests_PrerequisitesGetList()
        {
            Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> prereqs = new Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>>();
            
            foreach (DataRow sQ in Instance!._dataTables.ScriptableQuestsDataTable.Rows)
            {
                var questGlobalObject = (string)sQ[(byte)ScriptableQuestsColumns.questGlobalObject];
                if(!Instance._dataTables.ScriptableRequirementsDictionary.ContainsKey(questGlobalObject)) continue;
                var nestedScriptableRequirementsObjectCodes = Instance._dataTables.ScriptableRequirementsDictionary[questGlobalObject];
                foreach (var sR in nestedScriptableRequirementsObjectCodes)
                {
                    string requirementGlobalObject = sR.Key;

                    byte objectiveTypeId = (byte) sR.Value[(byte)ScriptableRequirementsColumns.requirementTypeId];
                    if(objectiveTypeId is (byte)RequirementTypes.Ability ||
                       objectiveTypeId is (byte)RequirementTypes.Level   || objectiveTypeId is
                       (byte)RequirementTypes.Skill) continue;
                    
                    var sO = Instance._dataTables.ScriptableObjectsDictionary[requirementGlobalObject];
                    var glO = Instance._dataTables.GlobalObjectsDictionary[requirementGlobalObject];

                    
                    if (!prereqs.ContainsKey(questGlobalObject))
                        prereqs.Add(questGlobalObject, new Dictionary<byte, List<QuestObjectiveModel>>());
                    if (!prereqs[questGlobalObject].ContainsKey((objectiveTypeId)))
                        prereqs[questGlobalObject].Add(objectiveTypeId, new List<QuestObjectiveModel>());

                    var objectiveScriptableObjectPath = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                    var objectiveName = (string) glO[(byte)GlobalObjectsColumns.globalObjectNamePlural];
                    var requiredAmount = (short) sR.Value[(byte)ScriptableRequirementsColumns.numRequired];
                    prereqs[questGlobalObject][objectiveTypeId].Add(new QuestObjectiveModel(requirementGlobalObject, 
                        objectiveScriptableObjectPath, objectiveName, 0, requiredAmount, objectiveTypeId));
                }

            }
#if UNITY_EDITOR
            if(prereqs.Count == 0) Logger!.LogWarning($"ERROR: ScriptableItems_WeaponRequirementsGetList - 0 Results");
#endif
            return prereqs;
        }

        public static Dictionary<string, List<ushort>> ScriptableQuests_GetExclusions()
        {
            Dictionary<string, List<ushort>> exclusions = new Dictionary<string, List<ushort>>();
            
            foreach (DataRow sQe in Instance!._dataTables.ScriptableQuestExclusionsDataTable.Rows)
            {
                var excludedQuestGlobalObject = (string)(sQe[(byte)ScriptableQuestExclusionsColumns.excludedQuestGlobalObject]);
                var sQ = Instance._dataTables.ScriptableQuestsDictionary[excludedQuestGlobalObject];
                
                string questGlobalObject = (string)sQe[(byte)ScriptableQuestExclusionsColumns.questGlobalObject];
                ushort questId             = (ushort) (int) sQ[(byte)ScriptableQuestsColumns.scriptableQuestId];
                if(!exclusions.ContainsKey(questGlobalObject)) exclusions.Add(questGlobalObject, new List<ushort>());
                exclusions[questGlobalObject].Add(questId);
                
            }
#if UNITY_EDITOR
            if(exclusions.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetExclusions - 0 Results");
#endif
            return exclusions;
        }

        public static List<QuestObjectivesModel> ScriptableMissions_GetMissionObjectives()
        {
            List<QuestObjectivesModel> missionRanks = new List<QuestObjectivesModel>();

            // foreach (DataRow mO in Instance!._dataTables.MissionObjectivesDataTable.Rows)
            // {
            // }
            return missionRanks;
        }
        public static Dictionary<QuestRankTypes, MissionRankModel> ScriptableMissions_GetMissionRanks()
        {
            Dictionary<QuestRankTypes, MissionRankModel> missionRanks = new Dictionary<QuestRankTypes, MissionRankModel>();
         
            return missionRanks;
        }

        public static Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>> ScriptableQuests_GetLevelObjectives()
        {
            Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>> objectives = new Dictionary<string, Dictionary<byte, List<LevelObjectiveModel>>>();
            
            foreach (DataRow sQo in Instance!._dataTables.ScriptableQuestObjectivesDataTable.Rows)
            {
                var objectiveGlobalObject = (string)(sQo[(byte)ScriptableQuestObjectivesColumns.objectiveGlobalObject]);
                //var sO = Instance._dataTables.ScriptableObjectsDictionary[objectiveGlobalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[objectiveGlobalObject];
                
                string questGlobalObject = (string)sQo[(byte)ScriptableQuestObjectivesColumns.questGlobalObject];
                byte objectiveTypeId = (byte)sQo[(byte)ScriptableQuestObjectivesColumns.objectiveTypeId];

                if (!objectives.ContainsKey(questGlobalObject)) objectives.Add(questGlobalObject, new Dictionary<byte, List<LevelObjectiveModel>>());
                if (!objectives[questGlobalObject].ContainsKey((objectiveTypeId))) objectives[questGlobalObject].Add(objectiveTypeId, new List<LevelObjectiveModel>());

                var objectiveName  = (string)glO[(byte)GlobalObjectsColumns.globalObjectNamePlural];
                var rankId         = (byte)sQo[(byte)ScriptableQuestObjectivesColumns.requiredRankId];
                var levelId = (byte)sQo[(byte)ScriptableQuestObjectivesColumns.requiredLevelId];
                objectives[questGlobalObject][objectiveTypeId].Add(new LevelObjectiveModel(objectiveGlobalObject, 
                    objectiveName, 1, objectiveTypeId, rankId, levelId));
            }
#if UNITY_EDITOR
            if(objectives.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetLevelObjectives - 0 Results");
#endif
            return objectives;
        }

        public static Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> ScriptableQuests_GetObjectives()
        {
            Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>> objectives = 
                new Dictionary<string, Dictionary<byte, List<QuestObjectiveModel>>>();
            
            foreach (DataRow sQo in Instance!._dataTables.ScriptableQuestObjectivesDataTable.Rows)
            {
                var objectiveGlobalObject = (string)(sQo[(byte)ScriptableQuestObjectivesColumns.objectiveGlobalObject]);
                var sO              = Instance._dataTables.ScriptableObjectsDictionary[objectiveGlobalObject];
                var gLO             = Instance._dataTables.GlobalObjectsDictionary[objectiveGlobalObject];
                
                string questGlobalObject = (string) sQo[(byte)ScriptableQuestObjectivesColumns.questGlobalObject];
                byte   objectiveTypeId     = (byte) sQo[(byte)ScriptableQuestObjectivesColumns.objectiveTypeId];

                if(!objectives.ContainsKey(questGlobalObject)) objectives.Add(questGlobalObject, new Dictionary<byte, List<QuestObjectiveModel>>());
                if(!objectives[questGlobalObject].ContainsKey((objectiveTypeId))) objectives[questGlobalObject].Add(objectiveTypeId, new List<QuestObjectiveModel>());

                string globalObject = objectiveGlobalObject;
                var objectiveScriptableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var objectiveName = (string)gLO[(byte)GlobalObjectsColumns.globalObjectName];
                var requiredAmount = (short)sQo[(byte)ScriptableQuestObjectivesColumns.numRequired];
                    
                objectives[questGlobalObject][objectiveTypeId].Add(new QuestObjectiveModel(globalObject, 
                    objectiveScriptableObjectPath, objectiveName, 0, requiredAmount, objectiveTypeId));
            }
#if UNITY_EDITOR
            if(objectives.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetObjectives - 0 Results");
#endif
            return objectives;
        }
        
        public static Dictionary<string, StaticQuestModel> ScriptableQuests_GetStaticQuests()
        {
            Dictionary<string, StaticQuestModel> staticQuests = new Dictionary<string, StaticQuestModel>();
            
            foreach (DataRow sQ in Instance!._dataTables.ScriptableQuestsDataTable.Rows)
            {
                string questGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.questGlobalObject]);
                string questLineGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.questlineGlobalObject]);
                string guaranteedLootTableGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.guaranteedLootTableGlobalObject]);
                string optionalLootTableGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.optionalLootTableGlobalObject]);
                
                var qSo  = Instance._dataTables.ScriptableObjectsDictionary[questGlobalObject];
                var qGlO = Instance._dataTables.GlobalObjectsDictionary[questGlobalObject];

                var questId = (ushort)(int)sQ[(byte)ScriptableQuestsColumns.scriptableQuestId];
                var questName = (string)qGlO[(byte)GlobalObjectsColumns.globalObjectName];
                string questScriptableObjectPath = (string)qSo[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var questCategoryTypeId = (byte)sQ[(byte)ScriptableQuestsColumns.questCategoryTypeId];
                var questTypeId = (byte)sQ[(byte)ScriptableQuestsColumns.questTypeId];
                var questSubTierId = (byte)sQ[(byte)ScriptableQuestsColumns.questMainTierId];
                var tierAvailable = (byte)sQ[(byte)ScriptableQuestsColumns.tierAvailableId];
                var guaranteedItems = (byte)sQ[(byte)ScriptableQuestsColumns.guaranteedDrops];
                var options = (byte)sQ[(byte)ScriptableQuestsColumns.optionalDrops];
                var questDescription = (string)sQ[(byte)ScriptableQuestsColumns.questDescription];
                var questObjectiveDescription = (string)sQ[(byte)ScriptableQuestsColumns.questObjectiveDescription];
                var questCompletionDescription = (string)sQ[(byte)ScriptableQuestsColumns.questCompletionDescription];
                var goldReward = (uint)(int)sQ[(byte)ScriptableQuestsColumns.questRewardGold];
                var silverReward = (byte)sQ[(byte)ScriptableQuestsColumns.questRewardSilver];
                var copperReward = (byte)sQ[(byte)ScriptableQuestsColumns.questRewardCopper];
                int experienceReward = (int)sQ[(byte)ScriptableQuestsColumns.questRewardExperience];
                var shareable = (bool)sQ[(byte)ScriptableQuestsColumns.questShareable];
                var questGiverName = (string)Instance._dataTables.GlobalObjectsDictionary[(string)sQ[(byte)ScriptableQuestsColumns.questNpcGlobalObject]][(byte)GlobalObjectsColumns.globalObjectName];
                StaticQuestModel staticQuest = new StaticQuestModel(questId, questGlobalObject, questName, questScriptableObjectPath,
                    questLineGlobalObject, questCategoryTypeId, questTypeId, questSubTierId, tierAvailable, 
                    guaranteedLootTableGlobalObject, guaranteedItems, optionalLootTableGlobalObject, options, 
                    goldReward, silverReward, copperReward, experienceReward , questDescription, questObjectiveDescription,
                    questCompletionDescription, shareable, questGiverName);
                staticQuests.Add(questGlobalObject, staticQuest);
            }
#if UNITY_EDITOR
            if(staticQuests.Count == 0) Logger!.LogWarning($"ERROR: ScriptableQuests_GetStaticQuests - 0 Results");
#endif
            return staticQuests;
        }

        public static Dictionary<string, Dictionary<RarityTypes, string>> ScriptableObjects_IconsGetList()
        {
            Dictionary<string, Dictionary<RarityTypes, string>> icons = new Dictionary<string, Dictionary<RarityTypes, string>>();
            foreach (var iC in Instance!._dataTables.IconsDataTable.Select())
            {
                string globalObject = (string) iC[(byte)IconsColumns.globalObject];
                string iconFilePath = iC[(byte)IconsColumns.iconFilePath].ToString();
                RarityTypes rarityType = (RarityTypes)(byte)iC[(byte)IconsColumns.rarityId];
                            
                if(!icons.ContainsKey(globalObject)) icons.Add(globalObject, new Dictionary<RarityTypes, string>());
                icons[globalObject].Add(rarityType, iconFilePath);
            }
#if UNITY_EDITOR
            if(icons.Count == 0) Logger!.LogWarning($"ERROR: ScriptableObjects_IconsGetList - 0 Results");
#endif
            return icons;
        }
        public static Dictionary<string, Dictionary<byte, List<StatModel>>> ScriptableWorldObjects_StatsGetList()
        {
            Dictionary<string, Dictionary<byte, List<StatModel>>> statData = new Dictionary<string, Dictionary<byte, List<StatModel>>>();
            
            foreach (DataRow eS in Instance!._dataTables.EntityStatsDataTable.Rows)
            {
                string globalObject = (string)(eS[(byte)EntityStatsColumns.globalObject]);
                var rankId = (byte)(eS[(byte)EntityStatsColumns.scriptableLevelId]);
                
                //var sOR = Instance._dataTables.ScriptableObjectRanksDictionaryByNestedObjectCode[globalObject][rankId];
                
                byte  statTypeId = (byte)eS[(byte)EntityStatsColumns.statTypeId];
                byte  statId     = (byte)eS[(byte)EntityStatsColumns.statId];
                float statValue  = (float)(decimal)eS[(byte)EntityStatsColumns.statInitialValue];
                var statRow = Instance._dataTables.StatsDataTable.Select(
                    $"{EntityStatsColumns.statTypeId} = {statTypeId} AND {EntityStatsColumns.statId} = {statId}")[0];
                float minValue = (float)(decimal)statRow[(byte)StatsColumns.statMinValue];
                float maxValue = (float)(decimal)statRow[(byte)StatsColumns.statMaxValue];
                var   stat     = new StatModel(statTypeId, statId, statValue, minValue, maxValue);
                if (!statData.ContainsKey(globalObject)) statData.Add(globalObject, new Dictionary<byte, List<StatModel>>());
                if (!statData[globalObject].ContainsKey(rankId)) statData[globalObject].Add(rankId, new List<StatModel>());
                statData[globalObject][rankId].Add(stat);
            }
#if UNITY_EDITOR
            if(statData.Count == 0) Logger!.LogWarning($"ERROR: ScriptableWorldObjects_StatsGetList - 0 Results");
#endif
            return statData;
        }

        public static List<InteractableModel> ScriptableWorldObjects_DroppedItemsGetList()
        {
            List<InteractableModel> entityData = new List<InteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.ScriptableInteractablesDataTable.Select())
            {
                if((byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId] != (byte)InteractableTypes.DroppedItem) continue;
                
                string globalObject = (string) sI[(byte)ScriptableInteractablesColumns.globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];

                var    globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    interactableId = (ushort)(int) sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var    interactableName = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte   tierId = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte   globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   worldObjectTypeId = (byte) WorldObjectTypes.Interactable;
                byte   interactableTypeId = (byte) InteractableTypes.DroppedItem;
                ushort interactableHealth = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                bool   immortal = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                string   skillGlobalObject = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];
                
                InteractableModel entity = new InteractableModel(interactableId, globalObject, globalStatusId, interactableName,
                    globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject);
                entityData.Add(entity);
            }
            return entityData;
        }

        public static List<InteractableModel> ScriptableWorldObjects_MailBoxGetList()
        {
            List<InteractableModel> entityData = new List<InteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.ScriptableInteractablesDataTable.Select())
            {
                if((byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId] != (byte)InteractableTypes.Mailbox) continue;

                string globalObject = (string) sI[(byte)ScriptableInteractablesColumns.globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];

                var    globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    interactableId = (ushort)(int) sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var    interactableName = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte   tierId = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte   globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   worldObjectTypeId = (byte)WorldObjectTypes.Interactable;
                byte   interactableTypeId = (byte)InteractableTypes.Mailbox;
                ushort interactableHealth = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                bool   immortal = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                string   skillGlobalObject = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];

                InteractableModel entity = new InteractableModel(interactableId, globalObject, globalStatusId, 
                    interactableName,globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject);
                entityData.Add(entity);
            }
            return entityData;
        }
        public static List<InteractableModel> ScriptableWorldObjects_BankGetList()
        {
            List<InteractableModel> entityData = new List<InteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.ScriptableInteractablesDataTable.Select())
            {
                if((byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId] != (byte)InteractableTypes.Bank) continue;

                string globalObject = (string) sI[(byte)ScriptableInteractablesColumns.globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];

                var    globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    interactableId = (ushort)(int) sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var    interactableName = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte   tierId = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte   globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   worldObjectTypeId = (byte)WorldObjectTypes.Interactable;
                byte   interactableTypeId = (byte)InteractableTypes.Bank;
                ushort interactableHealth = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                bool   immortal = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                string   skillGlobalObject = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];

                InteractableModel entity = new InteractableModel(interactableId, globalObject, globalStatusId, 
                    interactableName,globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject);
                entityData.Add(entity);
            }
            return entityData;
        }
        public static List<QuestBoardModel> ScriptableWorldObjects_QuestBoardsGetList()
        {
            List<QuestBoardModel> entityData = new List<QuestBoardModel>();
            
            foreach (DataRow sI in Instance!._dataTables.ScriptableInteractablesDataTable.Select())
            {
                if((byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId] != (byte)InteractableTypes.QuestBoard) continue;
                
                string globalObject = (string) sI[(byte)ScriptableInteractablesColumns.globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];

                var    globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var    globalObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var    interactableId = (ushort)(int) sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var    interactableName = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte   tierId = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte   globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   worldObjectTypeId = (byte)WorldObjectTypes.Interactable;
                byte   interactableTypeId = (byte)InteractableTypes.QuestBoard;
                ushort interactableHealth = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                bool   immortal = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                var            skillGlobalObject             = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];

                QuestBoardModel entity = new QuestBoardModel(interactableId, globalObject, 
                    globalStatusId, interactableName, globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, 
                    interactableHealth, immortal, skillGlobalObject);
                entityData.Add(entity);
            }
            return entityData;
        }
        public static Dictionary<string, AnimalModel> ScriptableWorldObjects_AnimalsGetList()
        {
            Dictionary<string, AnimalModel> entityData = new Dictionary<string, AnimalModel>();
            
            foreach (DataRow sA in Instance!._dataTables.ScriptableAnimalsDataTable.Select())
            {
                string globalObject = (string) sA[(byte)ScriptableAnimalsColumns.globalObject];
                var sE = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var  entityId                   = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId             = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var  entityName                 = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var  globalObjectPath           = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte tierId                     = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId         = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId          = (byte) WorldObjectTypes.Entity;
                byte entityTypeId               = (byte) EntityTypes.Animal;
                byte animalTypeId               = (byte) sA[(byte)ScriptableAnimalsColumns.animalMainTypeId];
                byte animalClassificationTypeId = (byte) sA[(byte)ScriptableAnimalsColumns.animalClassificationTypeId];
                byte animalSubTypeId            = (byte) sA[(byte)ScriptableAnimalsColumns.animalSubTypeId];
                AnimalModel entity = new AnimalModel(entityId, globalObject, globalStatusId,entityName, globalObjectPath, tierId,
                    globalObjectTypeId, worldObjectTypeId, entityTypeId, animalTypeId, animalClassificationTypeId, 
                    animalSubTypeId);
                entityData.Add(globalObject, entity);
            }
            return entityData;
        }

       public static Dictionary<string, EnemyHumanoidModel> ScriptableWorldObjects_EnemyHumanoidsGetList()
        {
            Dictionary<string, EnemyHumanoidModel> entityData = new Dictionary<string, EnemyHumanoidModel>();
            
            foreach (DataRow sEh in Instance!._dataTables.ScriptableEnemyHumanoidsDataTable.Rows)
            {
                var globalObject = (string) sEh[(byte)ScriptableEnemyHumanoidsColumns.globalObject];
                var sE = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                
                var entityId = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId                  = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var globalObjectPath = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var entityName = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte tierId = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId = (byte) WorldObjectTypes.Entity;
                byte entityTypeId = (byte)EntityTypes.EnemyHumanoid;
                byte enemyHumanoidTypeId = (byte) sEh[(byte)ScriptableEnemyHumanoidsColumns.enemyHumanoidMainTypeId];
                byte enemyHumanoidClassificationTypeId = (byte) sEh[(byte)ScriptableEnemyHumanoidsColumns.enemyHumanoidSubTypeId];
                byte enemyHumanoidSubTypeId = (byte) sEh[(byte)ScriptableEnemyHumanoidsColumns.enemyHumanoidSubTypeId];
                EnemyHumanoidModel entity = new EnemyHumanoidModel(entityId, globalObject, globalStatusId,
                 entityName, globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, entityTypeId, enemyHumanoidTypeId, 
                 enemyHumanoidClassificationTypeId, enemyHumanoidSubTypeId);
                entityData.Add(globalObject, entity);
            }
            return entityData;
        }

        public static Dictionary<string, MonsterModel> ScriptableWorldObjects_MonstersGetList()
        {
            Dictionary<string, MonsterModel> entityData = new Dictionary<string, MonsterModel>();
            
            foreach (DataRow sM in Instance!._dataTables.ScriptableMonstersDataTable.Rows)
            {
                var globalObject = (string) sM[(byte)ScriptableMonstersColumns.globalObject];
                var sE = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var  entityId                    = (ushort)(int)sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId                  = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var  entityName                  = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var  globalObjectPath            = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte tierId                      = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId          = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId           = (byte) WorldObjectTypes.Entity;
                byte entityTypeId                = (byte)EntityTypes.Monster;
                byte monsterTypeId               = (byte) sM[(byte)ScriptableMonstersColumns.monsterMainTypeId];
                byte monsterClassificationTypeId = (byte) sM[(byte)ScriptableMonstersColumns.monsterMainTypeId];
                byte monsterSubTypeId            = (byte) sM[(byte)ScriptableMonstersColumns.monsterSubTypeId];

                MonsterModel entity = new MonsterModel(entityId, globalObject, globalStatusId, entityName, globalObjectPath, tierId,
                    globalObjectTypeId, worldObjectTypeId, entityTypeId, monsterTypeId, monsterClassificationTypeId, monsterSubTypeId);
                entityData.Add(globalObject, entity);
            }
            return entityData;
        }

        public static Dictionary<string, EntityModel> ScriptableWorldObjects_NpcsGetList()
        {
            Dictionary<string, EntityModel> entityData = new Dictionary<string, EntityModel>();
            
            foreach (DataRow sN in Instance!._dataTables.ScriptableNpcsDataTable.Select())
            {
                string globalObject = (string) sN[(byte)ScriptableNpcsColumns.globalObject];
                var sE             = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO             = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO            = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var npcTypeId = (byte)sN[(byte)ScriptableNpcsColumns.npcMainTypeId]; 
                if (npcTypeId == (byte)NpcTypes.Vendor || npcTypeId == (byte)NpcTypes.QuestGiver) continue;

                var  entityId           = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var  entityName         = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var  globalObjectPath   = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte tierId             = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId  = (byte) WorldObjectTypes.Entity;
                byte entityTypeId       = (byte) EntityTypes.NPC;
                EntityModel entity = new EntityModel(entityId, globalObject, globalStatusId, entityName, globalObjectPath, tierId,
                    globalObjectTypeId, worldObjectTypeId, entityTypeId);
                entityData.Add(globalObject, entity);
            }
            return entityData;
        }

        public static Dictionary<string, List<VendorItemModel>> ScriptableWorldObjects_VendorsItemsGetList()
        {
            Dictionary<string, List<VendorItemModel>> vendorItems = new Dictionary<string, List<VendorItemModel>>();
            foreach (DataRow sVi in Instance!._dataTables.ScriptableVendorItemsDataTable.Select())
            {
                string itemGlobalObject   =  (string) sVi[(byte)ScriptableVendorItemsColumns.itemGlobalObject];
                var    sI                   = Instance._dataTables.ScriptableItemsDictionary[itemGlobalObject];
                string vendorGlobalObject = (string) sVi[(byte)ScriptableVendorItemsColumns.npcGlobalObject];

                ushort itemId                = (ushort)(int)(sI[(byte)ScriptableItemsColumns.scriptableItemId]);
                byte   rarityTypeId          = (byte)(sVi[(byte)ScriptableVendorItemsColumns.rarityId]);
                uint   goldValue             = (uint)(int)sVi[(byte)ScriptableVendorItemsColumns.price_money_gold];
                byte   silverValue           = (byte)sVi[(byte)ScriptableVendorItemsColumns.price_money_silver];
                byte   copperValue           = (byte)(sVi[(byte)ScriptableVendorItemsColumns.price_money_copper]);
                ushort   adventuringTokenValue = (ushort)(int)sVi[(byte)ScriptableVendorItemsColumns.price_token_adventuring];
                ushort   craftingTokenValue    = (ushort)(int)sVi[(byte)ScriptableVendorItemsColumns.price_token_crafting];
                ushort   gatheringTokenValue   = (ushort)(int)sVi[(byte)ScriptableVendorItemsColumns.price_token_gathering];

                byte   maxStack              = (byte)(sI[(byte)ScriptableItemsColumns.itemStackMax]);
                short  maxStock              = (short)(sVi[(byte)ScriptableVendorItemsColumns.maxStock]);
                float  spawnChance           = (float)(decimal)(sVi[(byte)ScriptableVendorItemsColumns.spawnChance]);
                short  restockAmount         = (short)(sVi[(byte)ScriptableVendorItemsColumns.restockAmt]);
                    
                VendorItemModel vendorItemData = new VendorItemModel(itemId, itemGlobalObject, rarityTypeId, goldValue, silverValue, copperValue, adventuringTokenValue, craftingTokenValue, gatheringTokenValue, maxStack, spawnChance, maxStock, restockAmount);

                if (!vendorItems.ContainsKey(vendorGlobalObject))
                    vendorItems.Add(vendorGlobalObject, new List<VendorItemModel>());
                vendorItems[vendorGlobalObject].Add(vendorItemData);
            }
#if UNITY_EDITOR
            if(vendorItems.Count == 0) Logger!.LogWarning($"ERROR: ScriptableWorldObjects_VendorsItemsGetList - 0 Results");
#endif
            return vendorItems;
        }

        public static Dictionary<string, VendorModel> ScriptableWorldObjects_VendorsGetList()
        {
            Dictionary<string, VendorModel> vendorData = new Dictionary<string, VendorModel>();
            
            foreach (DataRow sV in Instance!._dataTables.ScriptableVendorsDataTable.Rows)
            {
                string globalObject = (string) sV[(byte)ScriptableVendorsColumns.globalObject];
                var sE = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var  entityId           = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var  globalObjectPath   = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var  entityName         = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                byte tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId  = (byte)WorldObjectTypes.Entity;
                byte entityTypeId       = (byte) EntityTypes.NPC;
                var  restockInterval    = (int)sV[(byte)ScriptableVendorsColumns.restockInterval];
                VendorModel vendor = new VendorModel(entityId, globalObject, globalStatusId, globalObjectPath, entityName, tierId,
                    globalObjectTypeId, worldObjectTypeId, entityTypeId, restockInterval);
                vendorData.Add(globalObject, vendor);
            }
            return vendorData;

        }

        public static Dictionary<string, List<string>> ScriptableWorldObjects_QuestGiverQuestsGetList()
        {
            Dictionary<string, List<string>> offeredQuests = new Dictionary<string, List<string>>();
            
            foreach (DataRow sQ in Instance!._dataTables.ScriptableQuestsDataTable.Select())
            {
                var questGlobalObject = (string)(sQ[(byte)ScriptableQuestsColumns.questGlobalObject]);
                //var sO = Instance._dataTables.ScriptableObjectsDictionary[questGlobalObject];
                
                string questGiverGlobalObject = (string)sQ[(byte)ScriptableQuestsColumns.questNpcGlobalObject];
                
                if (!offeredQuests.ContainsKey(questGiverGlobalObject)) offeredQuests.Add(questGiverGlobalObject, new List<string>());
                offeredQuests[questGiverGlobalObject].Add(questGlobalObject);
            }
#if UNITY_EDITOR
            if(offeredQuests.Count == 0) Logger!.LogWarning($"ERROR: ScriptableWorldObjects_QuestGiverQuestsGetList - 0 Results");
#endif
            return offeredQuests;
        }

        public static Dictionary<string, EntityModel> ScriptableWorldObjects_QuestGiversGetList()
        {
            Dictionary<string, EntityModel> entityData = new Dictionary<string, EntityModel>();
            
            foreach (DataRow sN in Instance!._dataTables.ScriptableNpcsDataTable.Select())
            {
                if((byte)sN[(byte)ScriptableNpcsColumns.npcMainTypeId] != (byte)NpcTypes.QuestGiver) continue;
                
                string globalObject = (string) sN[(byte)ScriptableNpcsColumns.globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var sE = Instance._dataTables.ScriptableEntitiesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                

                var         entityId           = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var         globalStatusId         = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var         entityName         = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var         globalObjectPath   = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte        tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte        globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte        worldObjectTypeId  = (byte) WorldObjectTypes.Entity;
                byte        entityTypeId       = (byte) EntityTypes.NPC;
                EntityModel entity             = new EntityModel(entityId, globalObject, globalStatusId, entityName, globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, entityTypeId);
                entityData.Add(globalObject, entity);
            }
            return entityData;
        }

        public static List<EntityModel> ScriptableWorldObjects_PlayersGetList()
        {
            List<EntityModel> entityData = new List<EntityModel>();
            
            foreach (DataRow sE in Instance!._dataTables.ScriptableEntitiesDataTable.Select())
            {
                if((byte)sE[(byte)ScriptableEntitiesColumns.entityTypeId] != (byte)EntityTypes.PC) continue;

                var globalObject = (string) (sE[(byte)ScriptableEntitiesColumns.globalObject]);
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];

                var  entityId           = (ushort)(int) sE[(byte)ScriptableEntitiesColumns.scriptableEntityId];
                var  globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var  entityName         = (string) glO[(byte)GlobalObjectsColumns.globalObjectName];
                var  globalObjectPath   = (string) sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte tierId             = (byte)glO[(byte)GlobalObjectsColumns.globalTierId];
                byte globalObjectTypeId = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte worldObjectTypeId  = (byte) WorldObjectTypes.Entity;
                EntityModel entity = new EntityModel(entityId, globalObject, globalStatusId, entityName, globalObjectPath, tierId,
                    globalObjectTypeId, worldObjectTypeId, (byte)EntityTypes.PC);
                entityData.Add(entity);
            }
            return entityData;
        }

        public static List<GatherableModel> ScriptableWorldObjects_GatherablesGetList()
        {
            List<GatherableModel> gatherableData = new List<GatherableModel>();
            
            foreach (DataRow sG in Instance!._dataTables.ScriptableGatherablesDataTable.Select())
            {
                string globalObject = (string) sG[(byte)ScriptableGatherablesColumns.globalObject];
                var sI = Instance._dataTables.ScriptableInteractablesDictionary[globalObject];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO = Instance._dataTables.GlobalObjectsDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];

                var    interactableId                 = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var  globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var    interactableName               = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var    globalObjectPath               = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte   tierId                         = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte   globalObjectTypeId             = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte   worldObjectTypeId              = (byte) WorldObjectTypes.Interactable;
                byte   interactableTypeId             = (byte) InteractableTypes.Gatherable;
                ushort interactableHealth             = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                var    immortal                       = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                string   skillGlobalObject = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];
                //int   skillExperienceGained          = (int)sG[(byte)ScriptableGatherablesColumns.];
                var    requiredTier                  = (byte)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillTierId];
                var    requiredLevel                  = (byte)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillLevelId];
                byte   gatherTypeId                   = (byte)sG[(byte)ScriptableGatherablesColumns.gatherTypeId];
                byte   gatherableTypeId               = (byte)sG[(byte)ScriptableGatherablesColumns.gatherableTypeId];
                byte   gatherableClassificationTypeId = (byte)sG[(byte)ScriptableGatherablesColumns.gatherableClassificationTypeId];
                byte   gatherableSubTypeId            = (byte)sG[(byte)ScriptableGatherablesColumns.gatherableSubTypeId];
                var    requiredWeaponTypeId           = (byte)sG[(byte)ScriptableGatherablesColumns.requiredWeaponTypeId];
                var    requiredToolPower              = (byte)sG[(byte)ScriptableGatherablesColumns.requiredPower];
                var    maxToolPowerBonus              = (byte)sG[(byte)ScriptableGatherablesColumns.maxToolPower];
                    
                GatherableModel gatherable = new GatherableModel(interactableId, globalObject, globalStatusId, interactableName,
                    globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject,
                    requiredTier, requiredLevel, gatherTypeId, gatherableTypeId, gatherableClassificationTypeId, 
                    gatherableSubTypeId, requiredWeaponTypeId, requiredToolPower, maxToolPowerBonus);

                gatherableData.Add(gatherable);
            }
            return gatherableData;
        }

        public static Dictionary<string, List<string>> ScriptableWorldObjects_PrefabsGetList()
        {
            Dictionary<string, List<string>> prefabData = new Dictionary<string, List<string>>();
            
            foreach (DataRow pR in Instance!._dataTables.PrefabsDataTable.Select())
            {
                string globalObject = (string)pR[(byte)PrefabsColumns.globalObject];
                string prefabFilePath = pR[(byte)PrefabsColumns.prefabFilePath].ToString();

                if (!prefabData.ContainsKey(globalObject)) prefabData.Add(globalObject, new List<string> { prefabFilePath });
                else prefabData[globalObject].Add(prefabFilePath);
            }
            return prefabData;
        }

        public static List<ContainerModel> ScriptableWorldObjects_ContainersGetList()
        {
            List<ContainerModel> containerData = new List<ContainerModel>();
            
            foreach (DataRow sC in Instance!._dataTables.ScriptableContainersDataTable.Select())
            {
                string globalObject = (string) sC[(byte)ScriptableContainersColumns.globalObject];
                var    sI             = Instance._dataTables.ScriptableInteractablesDictionary[globalObject];
                var sWO = Instance._dataTables.ScriptableWorldObjectsDictionary[globalObject];
                var    sO             = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var    glO            = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                //ushort skillId = 0;
                //if (Instance._dataTables.ScriptableSkillsDictionary.ContainsKey(globalObject)) 
                //skillId = (ushort)(int)Instance._dataTables.ScriptableSkillsDictionary[(string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject]][(byte)ScriptableSkillsColumns.scriptableSkillId];
                
                var requiredSkillGlobalObject = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];
                
                var            interactableId       = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.scriptableInteractableId];
                var  globalStatusId     = (byte) glO[(byte)GlobalObjectsColumns.statusId];
                var            interactableName     = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var            globalObjectPath     = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                byte           tierId               = (byte) glO[(byte)GlobalObjectsColumns.globalTierId];
                byte           globalObjectTypeId   = (byte) glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                byte           worldObjectTypeId    = (byte) sWO[(byte)ScriptableWorldObjectsColumns.worldObjectTypeId];
                byte           interactableTypeId   = (byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId];
                ushort         interactableHealth   = (ushort)(int)sI[(byte)ScriptableInteractablesColumns.interactableHealth];
                var            immortal             = (bool)sWO[(byte)ScriptableWorldObjectsColumns.isImmortal];
                var            skillGlobalObject             = (string)sI[(byte)ScriptableInteractablesColumns.interactableRequiredSkillGlobalObject];
                var            requiredWeaponTypeId = (byte)sC[(byte)ScriptableContainersColumns.requiredWeaponTypeId];
                var            width                = (byte)sC[(byte)ScriptableContainersColumns.width];
                var            height               = (byte)sC[(byte)ScriptableContainersColumns.height];
                byte containerTypeId      = (byte)sC[(byte)ScriptableContainersColumns.containerMainTypeId];

                ContainerModel container = new ContainerModel(interactableId, globalObject, globalStatusId, interactableName,
                    globalObjectPath,  tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject,
                    requiredSkillGlobalObject, requiredWeaponTypeId, width, height, containerTypeId);
                containerData.Add(container);
            
            }
            return containerData;
        }

        #endregion
        
        #region DATA TABLE STP GETS: SPAWNED
        public static List<SpawnTableModel> SpawnTables_GetList()
        {
            List<SpawnTableModel> spawnTableData = new List<SpawnTableModel>();
            
            foreach (DataRow sST in Instance!._dataTables.ScriptableSpawnTablesDataTable.Rows)
            {
                string globalObject = (string) sST[(byte)ScriptableSpawnTablesColumns.globalObject];
                var sO               = Instance._dataTables.ScriptableObjectsDictionary[globalObject];
                var glO              = Instance._dataTables.GlobalObjectsDictionary[globalObject];

                var   globalStatusId   = (byte)glO[(byte)GlobalObjectsColumns.statusId];
                var spawnTableName                    = (string)glO[(byte)GlobalObjectsColumns.globalObjectName];
                var scriptableObjectPath              = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var respawnTime                       = (int)sST[(byte)ScriptableSpawnTablesColumns.respawnTime];
                var globalObjectTypeId                = (byte)glO[(byte)GlobalObjectsColumns.globalObjectTypeId];
                var baseSpawnableObjectGlobalObject = (string)sST[(byte)ScriptableSpawnTablesColumns.baseSpawnableObjectGlobalObject];
                
                SpawnTableModel spawnTable = new SpawnTableModel(globalObject, globalStatusId, spawnTableName, scriptableObjectPath,
                    respawnTime, globalObjectTypeId, baseSpawnableObjectGlobalObject);
                spawnTableData.Add(spawnTable);
                             
            }
            return spawnTableData;
        }
        public static Dictionary<string, List<SpawnTableOption>> SpawnTables_OptionsGetList()
        {
            Dictionary<string, List<SpawnTableOption>> spawnTableData = new Dictionary<string, List<SpawnTableOption>>();
            
            foreach (DataRow sSTO in Instance!._dataTables.ScriptableSpawnTableOptionsDataTable.Rows)
            {
                string globalObject = (string)sSTO[(byte)ScriptableSpawnTableOptionsColumns.globalObject];
                var worldObjectGlobalObject = (string) sSTO[(byte)ScriptableSpawnTableOptionsColumns.worldObjectGlobalObject];
                var rankId = (byte) sSTO[(byte)ScriptableSpawnTableOptionsColumns.levelId];
                var variationId = (byte) sSTO[(byte)ScriptableSpawnTableOptionsColumns.variationId];
                var sO = Instance._dataTables.ScriptableObjectsDictionary[worldObjectGlobalObject];
                var spawnableObjectPath = (string)sO[(byte)ScriptableObjectsColumns.scriptableObjectPath];
                var minRange = (int)sSTO[(byte)ScriptableSpawnTableOptionsColumns.minRange];
                var maxRange = (int)sSTO[(byte)ScriptableSpawnTableOptionsColumns.maxRange];
                SpawnTableOption spawnTable = new SpawnTableOption(spawnableObjectPath, rankId, variationId, minRange, maxRange);
                
                if (!spawnTableData.ContainsKey(globalObject)) spawnTableData.Add(globalObject, new List<SpawnTableOption>());
                spawnTableData[globalObject].Add(spawnTable);
                
            }
#if UNITY_EDITOR
            if(spawnTableData.Count == 0) Logger!.LogWarning($"ERROR: SpawnTables_OptionsGetList - 0 Results");
#endif
            return spawnTableData;
        }
         public static List<SpawnedEntityModel> SpawnedWorldObjects_AnimalsGetList()
        {
            List<SpawnedEntityModel> animalData = new List<SpawnedEntityModel>();
            
            foreach (DataRow sA in Instance!._dataTables.SpawnedAnimalsDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sA[(byte)SpawnedAnimalsColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject     = (string) sWo[(byte)SpawnedWorldObjectsColumns.globalObject];
                var    coordinateX      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateX];
                var    coordinateY      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk            = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY]; 
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var    prefabId      = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var    ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var    locationId       = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var    rank             = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var    entityTypeId     = (byte)EntityTypes.Animal;
                var    variationId      = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];

                SpawnedEntityModel animal = new SpawnedEntityModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, 
                    prefabId, ignoreSpawnTable, locationId, rank, variationId, entityTypeId);
                animalData.Add(animal);
            }

            return animalData;
        }
        public static List<SpawnedContainerModel> SpawnedWorldObjects_ContainersGetList()
        {
            List<SpawnedContainerModel> containers = new List<SpawnedContainerModel>();
            
            foreach (DataRow sC in Instance!._dataTables.SpawnedContainersDataTable.Select()) 
            {
                var spawnedWorldObjectId = (Guid) sC[(byte)SpawnedContainersColumns.spawnedWorldObjectId];
                var sI = Instance._dataTables.SpawnedInteractablesDictionary[spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) sWo[(byte)SpawnedWorldObjectsColumns.globalObject];
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                byte rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                byte interactableTypeId = (byte)(sI[(byte)SpawnedInteractablesColumns.interactableTypeId]);
                var containerTypeId = (byte)Instance._dataTables.ScriptableContainersDictionary[globalObject][(byte)ScriptableContainersColumns.containerMainTypeId];

                SpawnedContainerModel container = new SpawnedContainerModel(spawnedWorldObjectId, globalObject,
                    coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId, interactableTypeId, containerTypeId);
                containers.Add(container);
            }

            return containers;
        }
        public static List<SpawnedInteractableModel> SpawnedWorldObjects_MailboxesGetList()
        {
            List<SpawnedInteractableModel> containers = new List<SpawnedInteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.SpawnedInteractablesDataTable.Select()) 
            {
                var spawnedWorldObjectId = (Guid) sI[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY]; 
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var interactableTypeId = (byte)(sI[(byte)SpawnedInteractablesColumns.interactableTypeId]);
                if(interactableTypeId != (byte)InteractableTypes.Mailbox) continue;
                //var containerTypeId = (byte)Instance._dataTables.ScriptableContainersDictionary[globalObject][(byte)ScriptableContainersColumns.containerMainTypeId];
                    
                SpawnedInteractableModel container = new SpawnedInteractableModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId, interactableTypeId);
                containers.Add(container);
            }

            return containers;
        }
        public static List<SpawnedInteractableModel> SpawnedWorldObjects_BankGetList()
        {
            List<SpawnedInteractableModel> containers = new List<SpawnedInteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.SpawnedInteractablesDataTable.Select()) 
            {
                var spawnedWorldObjectId = (Guid) sI[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY]; 
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var interactableTypeId = (byte)(sI[(byte)SpawnedInteractablesColumns.interactableTypeId]);
                if(interactableTypeId != (byte)InteractableTypes.Bank) continue;
                //var containerTypeId = (byte)Instance._dataTables.ScriptableContainersDictionary[globalObject][(byte)ScriptableContainersColumns.containerMainTypeId];
                    
                SpawnedInteractableModel container = new SpawnedInteractableModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId, interactableTypeId);
                containers.Add(container);
            }

            return containers;
        }
        public static List<SpawnedInteractableModel> SpawnedWorldObjects_DroppedItemsGetList()
        {
            List<SpawnedInteractableModel> droppedItems = new List<SpawnedInteractableModel>();
            
            foreach (DataRow sI in Instance!._dataTables.SpawnedInteractablesDataTable.Select()) 
            {
                var spawnedWorldObjectId = (Guid) sI[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;

                byte interactableTypeId = (byte) sI[(byte)SpawnedInteractablesColumns.interactableTypeId];
                if(interactableTypeId != (byte)InteractableTypes.DroppedItem) continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];

                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                SpawnedInteractableModel droppedItem = new SpawnedInteractableModel(spawnedWorldObjectId, globalObject, 
                    coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ,
                    prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId, interactableTypeId);
                
                droppedItems.Add(droppedItem);
            }
            return droppedItems;
        }
        public static List<SpawnedEntityModel> SpawnedWorldObjects_EnemyHumanoidsGetList()
        {
            List<SpawnedEntityModel> enemyHumanoidData = new List<SpawnedEntityModel>();
            
            foreach (DataRow sEH in Instance!._dataTables.SpawnedEnemyHumanoidsDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sEH[(byte)SpawnedEnemyHumanoidsColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject     = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX      = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk            = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var    scaleX           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var    prefabId      = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var    ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var    locationId       = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var    rank             = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var    variationId      = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var    entityTypeId     = (byte)EntityTypes.EnemyHumanoid;
                    
                SpawnedEntityModel enemyHumanoid = new SpawnedEntityModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank,variationId, entityTypeId);
                enemyHumanoidData.Add(enemyHumanoid);
            }

            return enemyHumanoidData;
        }
        public static List<SpawnedInteractableModel> SpawnedWorldObjects_GatherablesGetList()
        {
            List<SpawnedInteractableModel> gatherableData = new List<SpawnedInteractableModel>();
            
            foreach (DataRow sG in Instance!._dataTables.SpawnedGatherablesDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sG[(byte)SpawnedGatherablesColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                string globalObject     = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX      = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ      = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk            = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ        = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var    scaleX           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var    ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var    locationId       = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var    rank             = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var    variationId      = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                SpawnedInteractableModel gatherable = new SpawnedInteractableModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, 
                    prefabId, ignoreSpawnTable, locationId, rank, variationId, (byte)InteractableTypes.Gatherable);
                gatherableData.Add(gatherable);
            }
            return gatherableData;
        }
        public static List<SpawnedEntityModel> SpawnedWorldObjects_MonstersGetList()
        {
            List<SpawnedEntityModel> monsterData = new List<SpawnedEntityModel>();
            
            foreach (DataRow sM in Instance!._dataTables.SpawnedMonstersDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sM[(byte)SpawnedMonstersColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                float  scaleX       = 0;
                float  scaleY       = 0;
                float  scaleZ       = 0;
                //var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                //var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                //var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];

                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var entityTypeId = (byte)EntityTypes.Monster;
                    
                SpawnedEntityModel monster = new SpawnedEntityModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId, entityTypeId);

                monsterData.Add(monster);
                
            }

            return monsterData;
        }
        public static List<SpawnedEntityModel> SpawnedWorldObjects_NpcsGetList()
        {
            List<SpawnedEntityModel> npCdata = new List<SpawnedEntityModel>();
            
            foreach (DataRow sN in Instance!._dataTables.SpawnedNpcsDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sN[(byte)SpawnedNPCsColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var entityTypeId = (byte)EntityTypes.NPC;
                    
                SpawnedEntityModel npc = new SpawnedEntityModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, 
                    locationId, rank, variationId,entityTypeId);
                npCdata.Add(npc);
            }
            return npCdata;
        }
        public static List<SpawnedEntityModel> SpawnedWorldObjects_QuestGiversGetList()
        {
            List<SpawnedEntityModel> questGiverData = new List<SpawnedEntityModel>();
            
            foreach (DataRow sN in Instance!._dataTables.SpawnedNpcsDataTable.Select())
            {
                var npcTypeId = (byte) (sN[(byte)SpawnedNPCsColumns.npcTypeId]);
                if (npcTypeId != (byte)NpcTypes.QuestGiver) continue;

                var spawnedWorldObjectId = (Guid) sN[(byte)SpawnedNPCsColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;
                
                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var ignoreSpawnTable = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var prefabId = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var locationId = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var rank = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var variationId = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var entityTypeId = (byte)EntityTypes.NPC;
                    
                SpawnedEntityModel questGiver = new SpawnedEntityModel(spawnedWorldObjectId, globalObject, coordinateX, 
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, 
                    ignoreSpawnTable, locationId, rank, variationId, entityTypeId);
                questGiverData.Add(questGiver);
            }
            return questGiverData;
        }
        public static List<SpawnedVendorModel> SpawnedWorldObjects_VendorsGetList()
        {
            List<SpawnedVendorModel> vendorData = new List<SpawnedVendorModel>();
            
            foreach (DataRow sV in Instance!._dataTables.SpawnedVendorsDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sV[(byte)SpawnedVendorsColumns.spawnedWorldObjectId];
                if (!Instance._dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) continue;
                var sWo = Instance._dataTables.SpawnedWorldObjectsDictionary[spawnedWorldObjectId];
                var status = sWo[(byte)SpawnedWorldObjectsColumns.status].ToString();
                if(status != "active") continue;

                string globalObject = (string) (sWo[(byte)SpawnedWorldObjectsColumns.globalObject]);
                var    coordinateX  = (float)(decimal)(sWo[(byte)SpawnedWorldObjectsColumns.coordinateX]);
                var    coordinateY  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateY];
                var    coordinateZ  = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.coordinateZ];
                var    chunk        = (int)sWo[(byte)SpawnedWorldObjectsColumns.chunk];
                var    rotationX    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationX];
                var    rotationY    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationY];
                var    rotationZ    = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.rotationZ];
                var scaleX = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleX];
                var    scaleY           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleY];
                var    scaleZ           = (float)(decimal)sWo[(byte)SpawnedWorldObjectsColumns.scaleZ];
                var                prefabId           = (string)sWo[(byte)SpawnedWorldObjectsColumns.prefabId];
                var                locationId           = (uint)(int)sWo[(byte)SpawnedWorldObjectsColumns.locationId];
                var                ignoreSpawnTable     = (bool)sWo[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable];
                var                rankId                 = (byte)sWo[(byte)SpawnedWorldObjectsColumns.globalRankId];
                var                variationId          = (byte)sWo[(byte)SpawnedWorldObjectsColumns.variationId];
                var                EntityTypeId         = (byte)EntityTypes.NPC;
                var lastRestockTime = (DateTime?) sV[(byte)SpawnedVendorsColumns.lastRestockTime];
                SpawnedVendorModel npc                  = new SpawnedVendorModel(spawnedWorldObjectId, globalObject, coordinateX,
                    coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, locationId, rankId,
                    variationId, EntityTypeId, lastRestockTime);
                vendorData.Add(npc);
              
            }
            return vendorData;
        }
        
        public static List<VendorInventoryData> SpawnedWorldObjects_VendorInventoriesGetList()
        {
            List<VendorInventoryData> vendorInventories = new List<VendorInventoryData>();
            
            foreach (DataRow sVI in Instance!._dataTables.SpawnedVendorInventoryDataTable.Select())
            {
                var spawnedWorldObjectId = (Guid) sVI[(byte)SpawnedVendorInventoryColumns.spawnedWorldObjectId];

                string globalObject = (string) sVI[(byte)SpawnedVendorInventoryColumns.globalObject];
                var sI = Instance._dataTables.ScriptableItemsDictionary[globalObject];
                
                ushort itemId = (ushort)(int)sI[(byte)ScriptableItemsColumns.scriptableItemId];
                byte   rarityId = (byte)sVI[(byte)SpawnedVendorInventoryColumns.rarityId];
                byte   currentStock = (byte)sVI[(byte)SpawnedVendorInventoryColumns.currentStock];
                Logger!.LogDebug(spawnedWorldObjectId.ToString());
                var index = vendorInventories.FindIndex((t) =>
                {
                    return t.VendorSpawnedWorldObjectId == spawnedWorldObjectId;
                });
                if (index == -1) 
                {
                    Logger.LogDebug($"No match for {spawnedWorldObjectId} inserting new entry");
                    vendorInventories.Add(new VendorInventoryData()
                    {
                        VendorSpawnedWorldObjectId = spawnedWorldObjectId,
                        Inventory = new List<VendorInventoryModel>()
                    });
                    index = vendorInventories.Count - 1;
                }
                vendorInventories[index].Inventory.Add(new VendorInventoryModel(itemId, rarityId, currentStock));

              
            }
#if UNITY_EDITOR
            if(vendorInventories.Count == 0) Logger!.LogWarning($"ERROR: SpawnedWorldObjects_VendorInventoriesGetList - 0 Results");
#endif
            return vendorInventories;
        }
        #endregion
        #region DATA TABLE STP INSERT / UPDATES / DELETES: SPAWNED
        public static (bool successful, string errorMessage) SpawnedWorldObjects_AnimalCreate(string animalGlobalObject, float coordinateX,
            float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, 
            float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, 
            uint locationId, Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            bool success = false;
            string errorMessage = "";
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(animalGlobalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId,
                    (byte)WorldObjectTypes.Entity,
                    animalGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ,
                    scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);
                Instance._dataTableSelects.AddSpawnedEntitiesDataRow(spawnedWorldObjectId, (byte)EntityTypes.Animal);
                Instance._dataTableSelects.AddSpawnedAnimalsDataRow(spawnedWorldObjectId);
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                //ADD ROW TO TABLE
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                errorMessage = $@"SQL EXCEPTION (SpawnedWorldObjects_AnimalCreate): {e.Message} - 
                    Params: AnimalGlobalObject: {animalGlobalObject}, CoordinateX: {coordinateX}, CoordinateY: {coordinateY},
                    CoordinateZ: {coordinateZ}, Chunk: {chunk}, RotationX: {rotationX}, RotationY: {rotationY}, RotationZ: {rotationZ}, 
                    VariationId: {variationId}, IgnoreSpawnTable: {ignoreSpawnTable}, Rank: {rank}, SpawnedWorldObjectId: {spawnedWorldObjectId}";
                Logger!.LogError(errorMessage);
                
            }

            
            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_AnimalCreate took {watch!.ElapsedTicks/10000f} ms");

            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_AnimalDelete(Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedAnimals_BySpawnedWorldObjectId(spawnedWorldObjectId);
                //DeleteSpawnedEntities_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_AnimalDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_AnimalDelete took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        
        public static (bool successful, string errorMessage) SpawnedWorldObjects_ContainerCreate(string interactableGlobalObject,
            float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
            float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, 
            uint locationId, Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            Logger!.Log($"SpawnedWorldObjects_ContainerCreate: {interactableGlobalObject} - {spawnedWorldObjectId}");
            bool   success      = false;
            string errorMessage = "";
            
            try
            {

                bool openedBefore = false;

                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var     dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(interactableGlobalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var     globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Interactable, 
                interactableGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ,
                scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);
                
                var dataScriptableInteractables = Instance._dataTableSelects.ScriptableInteractablesSelectRows(interactableGlobalObject);
                DataRow sI = dataScriptableInteractables[0];
                var interactableTypeId = (byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId];
                Instance._dataTableSelects.AddSpawnedInteractablesDataRow(spawnedWorldObjectId, interactableTypeId);
                
                Instance._dataTableSelects.AddSpawnedContainersDataRow(spawnedWorldObjectId, openedBefore);
                Instance._dataTableSelects.AddSpawnedWorldObjectsCurrencyDataRow(spawnedWorldObjectId, 0, 0, 0, 0, 0, 0);
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                #endregion
                
                success = true;
            }      
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_ContainerCreate): {0} - 
                    Params: ContainerGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                    CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                    VariationId: {9}, IgnoreSpawnTable: {10}, Rank:{11}, SpawnedWorldObjectId: {12}", 
                    e.Message, interactableGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId);
                Logger.LogError(errorMessage);
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_ContainerCreate took {watch!.ElapsedTicks/10000f} ms");

            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_ContainerDelete(Guid spawnedWorldObjectId)
        {
            
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            bool success = false;
            
            
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedContainers_BySpawnedWorldObjectId(spawnedWorldObjectId);
                //DeleteSpawnedInteractables_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_ContainerDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }


            
            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_ContainerDelete took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }
        
        public static (bool successful, string errorMessage) SpawnedWorldObjects_EnemyHumanoidCreate(string enemyHumanoidGlobalObject,
            float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
            float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable,
            uint locationId, Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            bool   success      = false;
            string errorMessage = "";
            
            
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var     dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(enemyHumanoidGlobalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var     globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Entity,
                    enemyHumanoidGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, 
                    rotationZ, scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId, ignoreSpawnTable, locationId);
                
                var dataScriptableEntities = Instance._dataTableSelects.ScriptableEntitiesSelectRows(enemyHumanoidGlobalObject);
                DataRow sE = dataScriptableEntities[0];
                var entityTypeId = (byte)sE[(byte)ScriptableEntitiesColumns.entityTypeId];

                Instance._dataTableSelects.AddSpawnedEntitiesDataRow(spawnedWorldObjectId, entityTypeId);
                Instance._dataTableSelects.AddSpawnedEnemyHumanoidsDataRow(spawnedWorldObjectId);
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                #endregion

                success = true;
            }
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_EnemyHumanoidCreate): {0} - 
                    Params: EnemyHumanoidGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                    CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                    VariationId: {9}, IgnoreSpawnTable: {10}, Rank: {11}, SpawnedWorldObjectId: {12}", 
                    e.Message, enemyHumanoidGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId);
                Logger!.LogError(errorMessage);
            }



            
            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidCreate took {watch!.ElapsedTicks/10000f} ms");
            
            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_EnemyHumanoidDelete(Guid spawnedWorldObjectId)
        {
            
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            bool success = false;
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedEnemyHumanoids_BySpawnedWorldObjectId(spawnedWorldObjectId);
                //DeleteSpawnedEntities_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_EnemyHumanoidDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidDelete took {watch!.ElapsedTicks/10000f} ms");
            
            return success;
        }

        public static (bool successful, string errorMessage) SpawnedWorldObjects_GatherableCreate(string interactableGlobalObject,
            float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
            float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable,
            uint locationId, Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            bool   success      = false;
            string errorMessage = "";
            

            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var     dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(interactableGlobalObject);
                DataRow sWO                        = dataScriptableWorldObjects[0];
                var     globalTierId               = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Interactable,
                    interactableGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, 
                    rotationZ, scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId, ignoreSpawnTable,
                    locationId);
                Instance._dataTableSelects.AddSpawnedInteractablesDataRow(spawnedWorldObjectId, (byte)InteractableTypes.Gatherable);
                Instance._dataTableSelects.AddSpawnedGatherablesDataRow(spawnedWorldObjectId);
                
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                #endregion
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_GatherableCreate): {0} - 
                    Params: GatherableGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                    CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                    VariationId: {9}, IgnoreSpawnTable: {10}, Rank: {11}, SpawnedWorldObjectId: {12}", 
                    e.Message, interactableGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId);
                Logger!.LogError(errorMessage);
            }
            

            
            
            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_GatherableCreate took {watch!.ElapsedTicks/10000f} ms");
            
            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_GatherableDelete(Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedGatherables_BySpawnedWorldObjectId(spawnedWorldObjectId);
                //DeleteSpawnedInteractables_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_GatherableDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger!.Log($"SpawnedWorldObjects_GatherableDelete took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static (bool successful, string errorMessage) SpawnedWorldObjects_InteractableCreate(string globalObject, float coordinateX, 
            float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX,
            float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            Logger!.Log($"SpawnedWorldObjects_InteractableCreate: {globalObject} - {spawnedWorldObjectId}");
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            string errorMessage = "";
            

            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(globalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Logger.Log($"{globalObject}, {locationId}");

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Interactable, 
                    globalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY,
                    rotationZ, scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);
                
                var dataScriptableInteractables = Instance._dataTableSelects.ScriptableInteractablesSelectRows(globalObject);
                DataRow sI = dataScriptableInteractables[0];
                var interactableTypeId = (byte)sI[(byte)ScriptableInteractablesColumns.interactableTypeId];

                Instance._dataTableSelects.AddSpawnedInteractablesDataRow(spawnedWorldObjectId, interactableTypeId);
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                #endregion
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_InteractableCreate): {0} - 
                    Params: InteractableGlobalObject: {1}, CoordinateX: {2}, 
                    CoordinateY: {3}, CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, 
                    RotationY: {7}, RotationZ: {8}, VariationId: {9}, IgnoreSpawnTable: {10},
                    Rank: {11}, SpawnedWorldObjectId: {12}", 
                    e.Message, globalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId);
                Logger.LogError(errorMessage);
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_InteractableCreate took {watch!.ElapsedTicks/10000f} ms");

            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_InteractableDelete(Guid spawnedWorldObjectId)
        {
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId); 
            Logger!.Log($"SpawnedWorldObjects_InteractableDelete: {spawnedWorldObjectId}");
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedInteractables_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger.LogError(message: $@"SQL EXCEPTION (SpawnedWorldObjects_InteractableDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_InteractableDelete took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        public static (bool successful, string errorMessage) SpawnedWorldObjects_MonsterCreate(string monsterGlobalObject,
        float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
        float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable,
        uint locationId, Guid spawnedWorldObjectId)
        {
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            Logger!.Log($"SpawnedWorldObjects_MonsterCreate: {monsterGlobalObject} - {spawnedWorldObjectId}");
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            string errorMessage = "";
            

            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(monsterGlobalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Entity, 
                    monsterGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, 
                    rotationZ, scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);

                Instance._dataTableSelects.AddSpawnedEntitiesDataRow(spawnedWorldObjectId, (byte)EntityTypes.Monster);
                Instance._dataTableSelects.AddSpawnedMonstersDataRow(spawnedWorldObjectId);
                Instance._dataTableSelects.AddSpawnedWorldObjectsBag(spawnedWorldObjectId, 0);
                #endregion
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_MonsterCreate): {0} - 
                    Params: MonsterGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                    CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                    VariationId: {9}, IgnoreSpawnTable: {10}, Rank: {11}, SpawnedWorldObjectId: {12}",
                    e.Message, monsterGlobalObject, coordinateX, coordinateY, coordinateZ, chunk,
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId);
                Logger.LogError(errorMessage);
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_MonsterCreate took {watch!.ElapsedTicks/10000f} ms");

            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_MonsterDelete(Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedMonsters_BySpawnedWorldObjectId(spawnedWorldObjectId);
                //DeleteSpawnedEntities_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_MonsterDelete): {0} - 
                    Params: SpawnedWorldObjectId: {1}", 
                    e.Message, spawnedWorldObjectId));
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_MonsterDelete took {watch!.ElapsedTicks/10000f} ms");

            return success;
        }
        
        public static (bool successful, string errorMessage) SpawnedWorldObjects_NpcCreate(string npcGlobalObject, float coordinateX,
            float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, 
            float scaleX, float scaleY, float scaleZ,
            byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId, byte npcTypeId)
        {
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            Logger!.Log($"SpawnedWorldObjects_NpcCreate: {npcGlobalObject}, {variationId}, {locationId} - {spawnedWorldObjectId}");
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool   success                  = false;
            string errorMessage             = "";

            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(npcGlobalObject);
                DataRow sWO = dataScriptableWorldObjects[0];
                var globalTierId = (byte)sWO[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Entity, 
                    npcGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, 
                    scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);
                Instance._dataTableSelects.AddSpawnedEntitiesDataRow(spawnedWorldObjectId, (byte)EntityTypes.NPC);
                Instance._dataTableSelects.AddSpawnedNpcsDataRow(spawnedWorldObjectId,npcTypeId);
                #endregion
                
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_NpcCreate): {0} - 
                    Params: NpcGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                    CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                    VariationId: {9}, IgnoreSpawnTable: {10}, Rank: {11}, SpawnedWorldObjectId: {12}, 
                    NpcTypeId: {13}", 
                    e.Message, npcGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId, npcTypeId);
                Logger.LogError(errorMessage);
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_NpcCreate took {watch!.ElapsedTicks/10000f} ms");

            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_NpcDelete(Guid spawnedWorldObjectId)
        {
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            Logger!.Log($"SpawnedWorldObjects_NpcDelete: {spawnedWorldObjectId}");
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            bool success = false;
            

            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedNpc(spawnedWorldObjectId);
                //DeleteSpawnedEntities_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_NpcDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_NpcDelete took {watch!.ElapsedTicks/10000f} ms");


            return success;
        }
        // Selling an item to a vendor.
        public static bool SpawnedWorldObjects_VendorSellItem(Guid vendorSpawnedWorldObjectId, int characterId, 
            Guid instancedItemId, int priceGold, byte priceSilver, byte priceCopper, short priceTokenAdventuring, 
            short priceTokenGathering, short priceTokenCrafting)
        {
            
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            bool success = false;
            

            var transactionDescription = "Vendor Purchase";
            
            
            //var vendorSpawnedWorldObjectIdGuid = new Guid(vendorSpawnedWorldObjqqqqqqqqqectId);
            try
            {
                //DataRow[] itemData = Instance!._dataTables.InstancedItemsDataTable.Select($"{InstancedItemsColumns.instancedItemId} = '{instancedItemId}'");
                //DataRow iI = itemData[0];
                //string itemGlobalObject =  (string)itemData[0][(byte)InstancedItemsColumns.globalObject];
            
                //DataRow[] vendorData = Instance._dataTables.SpawnedVendorsDataTable.Select($"spawnedWorldObjectId = '{vendorSpawnedWorldObjectId}'");
                //byte rarityId = (byte)iI[(byte)InstancedItemsColumns.rarityId];
                
                 var currencySuccess = Character_CurrencyUpdate(((Guid)Instance!._dataTables.CharactersDictionaryByCharacterId[characterId][(byte)CharactersColumns.spawnedWorldObjectId]), 
                     priceGold, priceSilver, priceCopper, priceTokenAdventuring, priceTokenGathering,
                     priceTokenCrafting, transactionDescription);
                 if (!currencySuccess) throw new Exception();
                //INSERT INTO BUY BACKS
                
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($"SQL EXCEPTION (SpawnedWorldObjects_VendorSellItem): {e.Message} - Params: VendorSpawnedWorldObjectId: {vendorSpawnedWorldObjectId}, CharacterId: {characterId}, InstancedItemId: {instancedItemId}");
            }


            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorBuyItem took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }
        public static (bool successful, string errorMessage) SpawnedWorldObjects_VendorCreate(string npcGlobalObject, float coordinateX,
            float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, 
            float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId,
                Guid spawnedWorldObjectId)
        {
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            bool   success      = false;
            string errorMessage = "";
            

            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                #region INSERT INTO SPAWNED WORLD OBJECTS
                //SELECT DATA FROM SCRIPTABLE OBJECTS
                var dataScriptableWorldObjects = Instance!._dataTableSelects.ScriptableWorldObjectsSelectRows(npcGlobalObject);
                DataRow dataRowScriptableWorldObjects = dataScriptableWorldObjects[0];
                var globalTierId = (byte)dataRowScriptableWorldObjects[(byte)ScriptableWorldObjectsColumns.globalTierId];

                Instance._dataTableSelects.AddSpawnedWorldObjectsDataRow(spawnedWorldObjectId, (byte)WorldObjectTypes.Entity,
                    npcGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, 
                    scaleX, scaleY, scaleZ, globalTierId, rank, variationId, prefabId,ignoreSpawnTable, locationId);
                
                Instance._dataTableSelects.AddSpawnedEntitiesDataRow(spawnedWorldObjectId, (byte)EntityTypes.NPC);
                Instance._dataTableSelects.AddSpawnedNpcsDataRow(spawnedWorldObjectId, (byte)NpcTypes.Vendor);
                Instance._dataTableSelects.AddSpawnedVendorsDataRow(spawnedWorldObjectId);
                
                var scriptableVendorItemsData = Instance._dataTableSelects.ScriptableVendorItemsSelectRows(npcGlobalObject);
                foreach (var svI in scriptableVendorItemsData)
                {
                    string itemGlobalObject = (string)svI[(byte)ScriptableVendorItemsColumns.itemGlobalObject];
                    var    rarityId           = (byte)svI[(byte)ScriptableVendorItemsColumns.rarityId];
                    Instance._dataTableSelects.AddSpawnedVendorInventoryDataRow(spawnedWorldObjectId, itemGlobalObject, rarityId, 0);
                }
                #endregion
                success             = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_VendorCreate): {0} - 
                        Params: NpcGlobalObject: {1}, CoordinateX: {2}, CoordinateY: {3},
                        CoordinateZ: {4}, Chunk: {5}, RotationX: {6}, RotationY: {7}, RotationZ: {8}, 
                        VariationId: {9}, IgnoreSpawnTable: {10}, Rank: {11}, SpawnedWorldObjectId: {12}", 
                    e.Message, npcGlobalObject, coordinateX, coordinateY, coordinateZ, chunk, 
                    rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, spawnedWorldObjectId));
            }
            
            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorCreate took {watch!.ElapsedTicks/10000f} ms");
            
            return (success, errorMessage);
        }
        
        public static bool SpawnedWorldObjects_VendorDelete(Guid spawnedWorldObjectId)
        {
            
            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            bool success                    = false;
            
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            try
            {
                //Character_InventoryDeleteAll(spawnedWorldObjectId);
                //DeleteSpawnedVendor(spawnedWorldObjectId);
                //DeleteSpawnedNpc(spawnedWorldObjectId);
                //DeleteSpawnedEntities_BySpawnedWorldObjectId(spawnedWorldObjectId);
                Instance!._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(spawnedWorldObjectId);
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_VendorDelete): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}");
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorDelete took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }
        public static bool SpawnedWorldObjects_VendorsInventoryAddItem(Guid spawnedWorldObjectId, string itemGlobalObject,
           byte rarityId, byte currentStock)
        {

            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();
            
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            bool success = false;
            try
            {
                Instance!._dataTableSelects.AddSpawnedVendorInventoryDataRow(spawnedWorldObjectId, itemGlobalObject, rarityId, currentStock);
                success             = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_VendorsInventoryAddItem): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, ItemGlobalObject: {itemGlobalObject}");
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorsInventoryAddItem took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }

        public static bool SpawnedWorldObjects_VendorUpdateQuantity(Guid spawnedWorldObjectId, string itemGlobalObject,
            byte rarityId, short amountChanged)
        {


            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            bool success = false;
            //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
            
            try
            {
                DataRow sVI = Instance!._dataTableSelects.SpawnedVendorInventorySelectRows(spawnedWorldObjectId, itemGlobalObject, rarityId)[0];
                var newStock = (byte)sVI[(byte)SpawnedVendorInventoryColumns.currentStock] + amountChanged;
                if (newStock < 0)
                {
                    newStock = 0;
                }
                else if(newStock > 255)
                {
                    newStock = 255;
                }
                
                sVI[(byte)SpawnedVendorInventoryColumns.currentStock] = (byte)newStock;
                sVI[(byte)SpawnedVendorInventoryColumns.lastUpdate]   = DateTime.Now;
                success             = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_VendorUpdateQuantity): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, ItemGlobalObject: {itemGlobalObject}, 
                    RarityId: {rarityId}, AmountChanged: {amountChanged}");
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorUpdateQuantity took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }

        public static bool SpawnedWorldObjects_VendorRestock(Guid spawnedWorldObjectId, long lastRestockTimeBinary)
        {

            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            bool success = false;
            try
            {
                //var spawnedWorldObjectId = new Guid(spawnedWorldObjectId);
                DataRow[] vendorData = Instance!._dataTables.SpawnedVendorsDataTable.Select($"spawnedWorldObjectId = '{spawnedWorldObjectId}'");
                if(vendorData.Length == 0) throw new Exception($"No Vendor found for SpawnedWorldObjectId: {spawnedWorldObjectId} 0/{Instance._dataTables.SpawnedVendorsDataTable.Rows.Count}");
                DataRow sV = vendorData[0];
                sV[(byte)SpawnedVendorsColumns.lastRestockTime] = DateTime.FromBinary(lastRestockTimeBinary);
                sV.AcceptChanges();
                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError($@"SQL EXCEPTION (SpawnedWorldObjects_VendorRestock): {e.Message} - 
                    Params: SpawnedWorldObjectId: {spawnedWorldObjectId}, LastRestockTime: {DateTime.FromBinary(lastRestockTimeBinary)}"); 
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorRestock took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }
        
        public static bool SpawnedWorldObjects_VendorBuyItem(Guid vendorSpawnedWorldObjectId, int characterId, Guid instancedItemId, 
            int goldChanged, short silverChanged, short copperChanged, short adventuringTokensChanged, short craftingTokensChanged,
            short gatheringTokensChanged)
        {
            

            Stopwatch? watch                = null;
            if(SQL_PROFILING_ENABLED) watch = Stopwatch.StartNew();

            bool success = false;
            var transactionDescription = "Sold Item to Vendor";

            try
            {
                //GET NPC ID
                //DataRow[] npcData = Instance!._dataTables.SpawnedNpcsDataTable.Select($"{SpawnedVendorsColumns.spawnedWorldObjectId} = '{vendorSpawnedWorldObjectId}'");
                //var sN = npcData[0];
                //int spawnedNpcId =  (int)npcData[0][(byte)SpawnedNPCsColumns.spawnedWorldObjectId];
            
                //USE NPC ID TO GET GET VENDOR ID
                //DataRow[] vendorData = Instance._dataTables.SpawnedVendorsDataTable.Select($"{SpawnedVendorsColumns.spawnedWorldObjectId} = '{spawnedNpcId}'");
                //byte rarityId =  (byte)vendorData[0][(byte)SpawnedVendorsColumns)"];
                
                //INCREASE CHARACTERS CURRENCY
                var currencySuccess = Character_CurrencyUpdate(((Guid)Instance!._dataTables.CharactersDictionaryByCharacterId[characterId][(byte)CharactersColumns.spawnedWorldObjectId]), 
                     goldChanged, silverChanged, copperChanged, adventuringTokensChanged, 
                     craftingTokensChanged, gatheringTokensChanged, transactionDescription);
                 if (!currencySuccess) throw new NotSupportedException();
                //
                //ResetSpawnedWorldInventory_ByInstancedItemId(instancedItemId);
                // //INSERT INTO BUY BACKS
                //Character_BuybacksAdd(characterId, instancedItemId);

                success = true;
            }
            catch (Exception e)
            {
                Logger!.LogError(string.Format(@"SQL EXCEPTION (SpawnedWorldObjects_VendorSellItem): {0} - 
                    Params: VendorSpawnedWorldObjectId: {1}, CharacterId: {2},
                    InstancedItemId: {3}, GoldChanged: {4}, SilverChanged: {5}, 
                    CopperChanged: {6}, AdventuringTokensChanged: {7}, 
                    CraftingTokensChanged: {8}, GatheringTokensChanged: {9}",
                    e.Message, vendorSpawnedWorldObjectId, characterId, instancedItemId,
                    goldChanged, silverChanged, copperChanged, adventuringTokensChanged, craftingTokensChanged,
                    gatheringTokensChanged));
            }

            Logger!.LogProfiling($"DataTableStoredProcs.SpawnedWorldObjects_VendorSellItem took {watch!.ElapsedTicks/10000f} ms");
            return success;
        }
        #endregion

        public static bool SpawnerLocations_Overwrite(List<LocationModel> interactableLocations, 
            List<LocationModel> entityLocations, List<LocationModel> itemLocations)
        {
            Instance._dataTables._dataSet.EnforceConstraints = false;

            foreach (var sWO in Instance!._dataTables.SpawnedWorldObjectsDictionary)
            {
                if (sWO.Value[(byte)SpawnedWorldObjectsColumns.locationId] != DBNull.Value)
                {
                    Instance._dataTableSelects.DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(sWO.Key);
                }
                            
            }

            foreach (DataRow sL in Instance._dataTables.SpawnerLocationsDataTable.Rows)
            {
                sL.Delete();
            }

            var row = Instance._dataTables.SpawnerLocationsDataTable.NewRow();
            row[(byte)SpawnerLocationsColumns.positionX]        = 0m;
            row[(byte)SpawnerLocationsColumns.positionY]        = 0m;
            row[(byte)SpawnerLocationsColumns.positionZ]        = 0m;
            row[(byte)SpawnerLocationsColumns.rotationX]        = 0m;
            row[(byte)SpawnerLocationsColumns.rotationY]        = 0m;
            row[(byte)SpawnerLocationsColumns.rotationZ]        = 0m;
            row[(byte)SpawnerLocationsColumns.chunk]            = 0;
            row[(byte)SpawnerLocationsColumns.variationId] = 0;
            row[(byte)SpawnerLocationsColumns.ignoreSpawnTable] = false;
            row[(byte)SpawnerLocationsColumns.rankId]           = 0;
            row[(byte)SpawnerLocationsColumns.spawnerTypeId]    = 0;
            row[(byte)SpawnerLocationsColumns.globalObject]     = "";
            row[(byte)SpawnerLocationsColumns.scaleX]           = 1m;
            row[(byte)SpawnerLocationsColumns.scaleY]           = 1m;
            row[(byte)SpawnerLocationsColumns.scaleZ]           = 1m;
            row[(byte)SpawnerLocationsColumns.prefabId]           = "";
            Instance._dataTables.SpawnerLocationsDataTable.Rows.Add(row);
            
            foreach (var location in interactableLocations)
            {
                row = Instance._dataTables.SpawnerLocationsDataTable.NewRow();
                row[(byte)SpawnerLocationsColumns.positionX] = (decimal)location.position.x;
                row[(byte)SpawnerLocationsColumns.positionY] = (decimal)location.position.y;
                row[(byte)SpawnerLocationsColumns.positionZ] = (decimal)location.position.z;
                row[(byte)SpawnerLocationsColumns.rotationX] = (decimal)location.eulerAngles.x;
                row[(byte)SpawnerLocationsColumns.rotationY] = (decimal)location.eulerAngles.y;
                row[(byte)SpawnerLocationsColumns.rotationZ] = (decimal)location.eulerAngles.z;
                
                row[(byte)SpawnerLocationsColumns.scaleX]        = (decimal)location.scale.x;
                row[(byte)SpawnerLocationsColumns.scaleY]        = (decimal)location.scale.y;
                row[(byte)SpawnerLocationsColumns.scaleZ]        = (decimal)location.scale.z;
                
                row[(byte)SpawnerLocationsColumns.chunk]            = location.chunk;
                row[(byte)SpawnerLocationsColumns.ignoreSpawnTable] = location.ignoreSpawnTable;
                row[(byte)SpawnerLocationsColumns.rankId]           = location.rankId;
                row[(byte)SpawnerLocationsColumns.variationId]      = location.variationId;
                row[(byte)SpawnerLocationsColumns.prefabId]      = location.prefabId;
                row[(byte)SpawnerLocationsColumns.spawnerTypeId]    = 1;
                row[(byte)SpawnerLocationsColumns.globalObject]     = location.baseGlobalObject;
                Instance._dataTables.SpawnerLocationsDataTable.Rows.Add(row);
            }
            
            foreach (var location in entityLocations)
            {
                row = Instance._dataTables.SpawnerLocationsDataTable.NewRow(); 
                row[(byte)SpawnerLocationsColumns.positionX] = (decimal)location.position.x;
                row[(byte)SpawnerLocationsColumns.positionY] = (decimal)location.position.y;
                row[(byte)SpawnerLocationsColumns.positionZ] = (decimal)location.position.z;
                row[(byte)SpawnerLocationsColumns.rotationX] = (decimal)location.eulerAngles.x;
                row[(byte)SpawnerLocationsColumns.rotationY] = (decimal)location.eulerAngles.y;
                row[(byte)SpawnerLocationsColumns.rotationZ] = (decimal)location.eulerAngles.z;
                row[(byte)SpawnerLocationsColumns.scaleX]        = (decimal)location.scale.x;
                row[(byte)SpawnerLocationsColumns.scaleY]        = (decimal)location.scale.y;
                row[(byte)SpawnerLocationsColumns.scaleZ]        = (decimal)location.scale.z;
                row[(byte)SpawnerLocationsColumns.chunk] = location.chunk;
                row[(byte)SpawnerLocationsColumns.prefabId]      = location.prefabId;
                row[(byte)SpawnerLocationsColumns.ignoreSpawnTable] = location.ignoreSpawnTable;
                row[(byte)SpawnerLocationsColumns.rankId] = location.rankId;
                row[(byte)SpawnerLocationsColumns.variationId] = location.variationId;
                row[(byte)SpawnerLocationsColumns.spawnerTypeId] = 2;
                row[(byte)SpawnerLocationsColumns.globalObject] = location.baseGlobalObject;
                Instance._dataTables.SpawnerLocationsDataTable.Rows.Add(row);
            }
            
            foreach (var location in itemLocations)
            {
                row = Instance._dataTables.SpawnerLocationsDataTable.NewRow(); 
                row[(byte)SpawnerLocationsColumns.positionX] = (decimal)location.position.x;
                row[(byte)SpawnerLocationsColumns.positionY] = (decimal)location.position.y;
                row[(byte)SpawnerLocationsColumns.positionZ] = (decimal)location.position.z;
                row[(byte)SpawnerLocationsColumns.rotationX] = (decimal)location.eulerAngles.x;
                row[(byte)SpawnerLocationsColumns.rotationY] = (decimal)location.eulerAngles.y;
                row[(byte)SpawnerLocationsColumns.rotationZ] = (decimal)location.eulerAngles.z;
                row[(byte)SpawnerLocationsColumns.scaleX]        = (decimal)location.scale.x;
                row[(byte)SpawnerLocationsColumns.scaleY]        = (decimal)location.scale.y;
                row[(byte)SpawnerLocationsColumns.scaleZ]        = (decimal)location.scale.z;
                row[(byte)SpawnerLocationsColumns.chunk] = location.chunk;
                row[(byte)SpawnerLocationsColumns.prefabId]      = location.prefabId;
                row[(byte)SpawnerLocationsColumns.ignoreSpawnTable] = location.ignoreSpawnTable;
                row[(byte)SpawnerLocationsColumns.rankId] = location.rankId;
                row[(byte)SpawnerLocationsColumns.spawnerTypeId] = 2;
                row[(byte)SpawnerLocationsColumns.variationId] = location.variationId;
                row[(byte)SpawnerLocationsColumns.globalObject] = location.baseGlobalObject;
                Instance._dataTables.SpawnerLocationsDataTable.Rows.Add(row);
            }
            Instance._dataTables._dataSet.EnforceConstraints = true;

            return true;
        }

        public static bool SpawnerLocations_LastDeath(uint locationId, long respawnTimeBinary)
        {
            var rows = Instance!._dataTables.SpawnerLocationsDataTable.Select($"locationId = {locationId}");
            if (rows.Length == 0) throw new Exception($"Failed to Update SpawnerLocation Respawn Time. Row is null");
            var row = rows[0];
            Logger.LogDebug($"{locationId}, {respawnTimeBinary}, {row}");
            row[(byte)SpawnerLocationsColumns.lastDeathTime] = DateTime.FromBinary(respawnTimeBinary);

            return true;
        }
        
        public static Dictionary<byte, Dictionary<string, List<LocationModel>>> SpawnerLocations_GetList()
        {
            Dictionary<byte, Dictionary<string, List<LocationModel>>> spawnerLocations =
                new Dictionary<byte, Dictionary<string, List<LocationModel>>>();

            foreach (DataRow row in Instance!._dataTables.SpawnerLocationsDataTable.Rows)
            {
                byte   spawnerTypeId  = (byte)row[(byte)SpawnerLocationsColumns.spawnerTypeId];
                string globalObject = (string)row[(byte)SpawnerLocationsColumns.globalObject];
                if(!spawnerLocations.ContainsKey(spawnerTypeId)) spawnerLocations.Add(spawnerTypeId, new Dictionary<string, List<LocationModel>>());
                if(!spawnerLocations[spawnerTypeId].ContainsKey(globalObject)) spawnerLocations[spawnerTypeId].Add(globalObject, new List<LocationModel>());
                uint locationId = (uint)(int)row[(byte)SpawnerLocationsColumns.locationId];
                
                var position = (((float)(decimal)row[(byte)SpawnerLocationsColumns.positionX],
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.positionY], 
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.positionZ]));
                
                var eulerAngles = ((float)(decimal)row[(byte)SpawnerLocationsColumns.rotationX],
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.rotationY],
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.rotationZ]);
                
               var scale = ((float)(decimal)row[(byte)SpawnerLocationsColumns.scaleX],
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.scaleY],
                    (float)(decimal)row[(byte)SpawnerLocationsColumns.scaleZ]);

               string prefabId = (string)row[(byte)SpawnerLocationsColumns.prefabId];
               
               byte rankId = (byte)row[(byte)SpawnerLocationsColumns.rankId];
               byte variationId = (byte)row[(byte)SpawnerLocationsColumns.variationId];
                bool ignoreSpawnTable = (bool)row[(byte)SpawnerLocationsColumns.ignoreSpawnTable];
                byte chunk = (byte)(int)row[(byte)SpawnerLocationsColumns.chunk];
                LocationModel locationData = new LocationModel(locationId, globalObject, position, eulerAngles, scale, chunk, prefabId, ignoreSpawnTable, rankId, variationId);
                spawnerLocations[spawnerTypeId][globalObject].Add(locationData);
            }
            return spawnerLocations;
        }
        public static Dictionary<byte, Dictionary<uint, long>> SpawnerLocations_RespawnTimersGetList()
        {
            Dictionary<byte, Dictionary<uint, long>> respawnTimers = new Dictionary<byte, Dictionary<uint, long>>();

            Logger.Log(Instance!._dataTables.SpawnerLocationsDataTable.Rows.Count.ToString());
            foreach (DataRow row in Instance!._dataTables.SpawnerLocationsDataTable.Rows)
            {
                byte spawnerTypeId = (byte)row[(byte)SpawnerLocationsColumns.spawnerTypeId];
                uint locationId    = (uint)(int)row[(byte)SpawnerLocationsColumns.locationId];
                DateTime lastRespawnTime = row[(byte)SpawnerLocationsColumns.lastDeathTime] == DBNull.Value ?
                    DateTime.MinValue : (DateTime)row[(byte)SpawnerLocationsColumns.lastDeathTime];
                respawnTimers.TryAdd(spawnerTypeId, new Dictionary<uint, long>());
                respawnTimers[spawnerTypeId].Add(locationId, lastRespawnTime.ToBinary());
            }
            return respawnTimers;
        }

    }
}
