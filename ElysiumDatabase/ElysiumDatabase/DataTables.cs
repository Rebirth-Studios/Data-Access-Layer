//#if SERVER

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RebirthStudios.DataAccessLayer.Enums.TableColumns;
using RebirthStudios.RebirthStudios.Core.Enums.TableColumns;

namespace RebirthStudios.DataAccessLayer
{
    public interface IDbConnection : IDisposable
    {
        public ConnectionState State { get; }
        
    }

    public interface ILogger
    {
        public void Log(string message);
        public void LogProfiling(string message);
        public void LogDebug(string message);
        public void LogWarning(string message);
        public void LogError(string message);
        public void LogException(Exception e);
    }
    
    public class Logger : ILogger
    {
        public Action<string> LogMethod { get; set; }
        public Action<string> LogProfilingMethod { get; set; }
        public Action<string> LogDebugMethod { get; set; }
        public Action<string> LogWarningMethod { get; set; }
        public Action<string> LogErrorMethod { get; set; }
        public Action<Exception> LogExceptionMethod { get; set; }
        
        public void Log(string message)
        {
            LogMethod.Invoke(message);
        }
        public void LogProfiling(string message)
        {
            LogProfilingMethod.Invoke(message);
        } 
       public void LogDebug(string message)
        {
            LogDebugMethod.Invoke(message);
        }

        public void LogWarning(string      message)
        {
            LogWarningMethod.Invoke(message);
        }

        public void LogError(string        message)
        {
            LogErrorMethod.Invoke(message);
        }

        public void LogException(Exception e)
        {
            LogExceptionMethod.Invoke(e);
        }
    } 
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
    public class DataTables : IDisposable
    {
        private ILogger Logger { get; set; }
        
        public        DataSet _dataSet;
        // public        DataSet _charactersDataSet;
        // public        DataSet _enumsDataSet;
        // public        DataSet _historyDataSet;
        // public        DataSet _instancedItemsDataSet;
        // public        DataSet _referenceDataSet;
        // public        DataSet _spawnedWorldObjectsDataSet;
        // public        DataSet _scriptableDataSet;
        
        #region TABLE NAMES, DATA TABLES, UPDATE AND INSERT COMMANDS: CHARACTERS

        private const string                      PlayersAccountsTableName = "playersAccounts";
        public        DataTable                   PlayersAccountsDataTable;
        private       SqlCommand                  _playersAccountsTableUpdate;
        private       SqlCommand                  _playersAccountsTableInsert;
        public        Dictionary<string, DataRow> PlayersAccountsDictionaryByUserName;

        private const string CharactersTableName = "characters";
        public DataTable CharactersDataTable;
        private SqlCommand _charactersTableUpdate;
        private SqlCommand _charactersTableInsert;
        public Dictionary<int, DataRow> CharactersDictionaryByCharacterId;
        public Dictionary<int, List<DataRow>> CharactersDictionaryByPlayerAccountId;
        public Dictionary<Guid, DataRow> CharactersDictionaryBySpawnedWorldObjectId;
        public Dictionary<string, DataRow> CharactersDictionaryByCharacterName;

        private const string CharactersAbilitiesTableName = "charactersAbilities";
        public DataTable CharactersAbilitiesDataTable;
        private SqlCommand _charactersAbilitiesTableUpdate;
        private SqlCommand _charactersAbilitiesTableInsert;

        private const string CharactersAchievementsTableName = "charactersAchievements";
        public DataTable CharactersAchievementsDataTable;
        private SqlCommand _charactersAchievementsTableUpdate;
        private SqlCommand _charactersAchievementsTableInsert;

        private const string CharactersBuyBacksTableName = "charactersBuybacks";
        public DataTable CharactersBuyBacksDataTable;
        private SqlCommand _charactersBuyBacksTableUpdate;
        private SqlCommand _charactersBuyBacksTableInsert;

        private const string CharactersMailTableName = "charactersMail";
        public DataTable CharactersMailDataTable;
        private SqlCommand _charactersMailTableUpdate;
        private SqlCommand _charactersMailTableInsert;

        private const string CharactersMailAttachmentsTableName = "charactersMailAttachments";
        public DataTable CharactersMailAttachmentsDataTable;
        private SqlCommand _charactersMailAttachmentsTableUpdate;
        private SqlCommand _charactersMailAttachmentsTableInsert;

        private const string CharactersMissionsTableName = "charactersMissions";
        public DataTable CharactersMissionsDataTable;
        private SqlCommand _charactersMissionsTableUpdate;
        private SqlCommand _charactersMissionsTableInsert;

        private const string CharactersQuestsTableName = "charactersQuests";
        public DataTable CharactersQuestsDataTable;
        private SqlCommand _charactersQuestsTableUpdate;
        private SqlCommand _charactersQuestsTableInsert;

        private const string CharactersQuestsObjectivesTableName = "charactersQuestsObjectives";
        public DataTable CharactersQuestsObjectivesDataTable;
        private SqlCommand _charactersQuestsObjectivesTableUpdate;
        private SqlCommand _charactersQuestsObjectivesTableInsert;

        private const string CharactersRecipesTableName = "charactersRecipes";
        public DataTable CharactersRecipesDataTable;
        private SqlCommand _charactersRecipesTableUpdate;
        private SqlCommand _charactersRecipesTableInsert;

        private const string CharactersSkillsTableName = "charactersSkills";
        public DataTable CharactersSkillsDataTable;
        private SqlCommand _charactersSkillsTableUpdate;
        private SqlCommand _charactersSkillsTableInsert;

        private const string CharactersSocialTableName = "charactersSocial";
        public DataTable CharactersSocialDataTable;
        private SqlCommand _charactersSocialTableUpdate;
        private SqlCommand _charactersSocialTableInsert;

        private const string CharactersStatsTableName = "charactersStats";
        public DataTable CharactersStatsDataTable;
        private SqlCommand _charactersStatsTableUpdate;
        private SqlCommand _charactersStatsTableInsert;

        private const string     CharactersStatusEffectsTableName = "charactersStatusEffects";
        public        DataTable  CharactersStatusEffectsDataTable;
        private       SqlCommand _charactersStatusEffectsTableUpdate;
        private       SqlCommand _charactersStatusEffectsTableInsert;
        public Dictionary<int, Dictionary<string, DataRow>> CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject;

        private const string     CharactersTitlesTableName = "charactersTitles";
        public        DataTable  CharactersTitlesDataTable;
        private       SqlCommand _charactersTitlesTableUpdate;
        private       SqlCommand _charactersTitlesTableInsert;
        
        #endregion
        
        #region TABLE NAMES, DATA TABLES, UPDATE AND INSERT COMMANDS: HISTORY

        private const string HistoryCharacterCollectedTableName = "historyCharacterCollected";
        public DataTable HistoryCharacterCollectedDataTable;
        private SqlCommand _historyCharacterCollectedTableUpdate;
        private SqlCommand _historyCharacterCollectedTableInsert;

        private const string HistoryCharacterCombatTableName = "historyCharacterCombat";
        public DataTable HistoryCharacterCombatDataTable;
        private SqlCommand _historyCharacterCombatTableUpdate;
        private SqlCommand _historyCharacterCombatTableInsert;

        private const string HistoryCharacterCraftedTableName = "historyCharacterCrafted";
        public DataTable HistoryCharacterCraftedDataTable;
        private SqlCommand _historyCharacterCraftedTableUpdate;
        private  SqlCommand _historyCharacterCraftedTableInsert;

        private const string                 HistoryCharacterDeathsTableName = "historyCharacterDeaths";
        public        DataTable              HistoryCharacterDeathsDataTable;
        private       SqlCommand _historyCharacterDeathsTableUpdate;
        private       SqlCommand _historyCharacterDeathsTableInsert;

        private const string                 HistoryCharacterGatheredTableName = "historyCharacterGathered";
        public        DataTable              HistoryCharacterGatheredDataTable;
        private       SqlCommand _historyCharacterGatheredTableUpdate;
        private       SqlCommand _historyCharacterGatheredTableInsert;

        private const string                 HistoryCharacterKillsTableName = "historyCharacterKills";
        public        DataTable              HistoryCharacterKillsDataTable;
        private       SqlCommand _historyCharacterKillsTableUpdate;
        private       SqlCommand _historyCharacterKillsTableInsert;

        private const string HistoryCharacterLootTableName = "historyCharacterLoot";
        public DataTable HistoryCharacterLootDataTable;
        private SqlCommand _historyCharacterLootTableUpdate;
        private SqlCommand _historyCharacterLootTableInsert;

        private const string HistoryCharacterQuestsTableName = "historyCharacterQuests";
        public DataTable HistoryCharacterQuestsDataTable;
        private SqlCommand HistoryCharacterQuestsTableUpdate;
        private SqlCommand HistoryCharacterQuestsTableInsert;

        private const string HistoryCurrencyTransactionsTableName = "historyCurrencyTransactions";
        public DataTable HistoryCurrencyTransactionsDataTable;
        private SqlCommand _historyCurrencyTransactionsTableUpdate;
        private SqlCommand _historyCurrencyTransactionsTableInsert;
        
        #endregion
        
        #region TABLE NAMES, DATA TABLES, UPDATE AND INSERT COMMANDS: INSTANCED ITEMS

        private const string InstancedAmmunitionTableName = "instancedAmmunition";
        public DataTable InstancedAmmunitionDataTable;
        private SqlCommand _instancedAmmunitionTableUpdate;
        private SqlCommand _instancedAmmunitionTableInsert;

        private const string InstancedArmorTableName = "instancedArmor";
        public DataTable InstancedArmorDataTable;
        private SqlCommand InstancedArmorTableUpdate;
        private SqlCommand InstancedArmorTableInsert;

        private const string InstancedBagsTableName = "instancedBags";
        public DataTable InstancedBagsDataTable;
        private SqlCommand InstancedBagsTableUpdate;
        private SqlCommand InstancedBagsTableInsert;

        private const string InstancedConsumablesTableName = "instancedConsumables";
        public DataTable InstancedConsumablesDataTable;
        private SqlCommand InstancedConsumablesTableUpdate;
        private SqlCommand InstancedConsumablesTableInsert;

        private const string InstancedEquipmentTableName = "instancedEquipment";
        public DataTable InstancedEquipmentDataTable;
        private SqlCommand _instancedEquipmentTableUpdate;
        private SqlCommand _instancedEquipmentTableInsert;
        public Dictionary<Guid, DataRow> InstancedEquipmentDictionary;

        private const string InstancedGeneralItemsTableName = "instancedGeneralItems";
        public DataTable InstancedGeneralItemsDataTable;
        private SqlCommand _instancedGeneralItemsTableUpdate;
        private SqlCommand _instancedGeneralItemsTableInsert;

        private const string InstancedItemsTableName = "instancedItems";
        public DataTable InstancedItemsDataTable;
        private SqlCommand _instancedItemsTableUpdate;
        private SqlCommand _instancedItemsTableInsert;
        public Dictionary<Guid, DataRow> InstancedItemsDictionaryByInstancedItemId;
        public Dictionary<Guid, List<DataRow>> InstancedItemsDictionaryBySpawnedWorldObjectId;

        private const string InstancedItemsIngredientsTableName = "instancedItemsIngredients";
        public DataTable InstancedItemsIngredientsDataTable;
        public Dictionary<Guid, List<DataRow>> InstancedItemsIngredientsDictionaryByInstancedItemId;
        private SqlCommand InstancedItemsIngredientsTableUpdate;
        private SqlCommand InstancedItemsIngredientsTableInsert;
        
        private const string InstancedMaterialsTableName = "instancedMaterials";
        public DataTable InstancedMaterialsDataTable;
        private SqlCommand InstancedMaterialsTableUpdate;
        private SqlCommand InstancedMaterialsTableInsert;

        private const string InstancedMissionsTableName = "instancedMissions";
        public DataTable InstancedMissionsDataTable;
        private SqlCommand InstancedMissionsTableUpdate;
        private SqlCommand InstancedMissionsTableInsert;

        private const string InstancedWeaponsTableName = "instancedWeapons";
        public DataTable InstancedWeaponsDataTable;
        private SqlCommand InstancedWeaponsTableUpdate;
        private SqlCommand InstancedWeaponsTableInsert;
        #endregion
        
        #region TABLE NAMES, DATA TABLES, UPDATE AND INSERT COMMANDS: SPAWNED

        private const string SpawnedAnimalsTableName = "spawnedAnimals";
        public DataTable SpawnedAnimalsDataTable;
        private SqlCommand _spawnedAnimalsTableUpdate;
        private SqlCommand _spawnedAnimalsTableInsert;

        private const string SpawnedContainersTableName = "spawnedContainers";
        public DataTable SpawnedContainersDataTable;
        private SqlCommand _spawnedContainersTableUpdate;
        private SqlCommand _spawnedContainersTableInsert;

        private const string SpawnedEnemyHumanoidsTableName = "spawnedEnemyHumanoids";
        public DataTable SpawnedEnemyHumanoidsDataTable;
        private SqlCommand _spawnedEnemyHumanoidsTableUpdate;
        private SqlCommand _spawnedEnemyHumanoidsTableInsert;

        private const string SpawnedEntitiesTableName = "spawnedEntities";
        public DataTable SpawnedEntitiesDataTable;
        private SqlCommand _spawnedEntitiesTableUpdate;
        private SqlCommand _spawnedEntitiesTableInsert;

        private const string SpawnedGatherablesTableName = "spawnedGatherables";
        public DataTable SpawnedGatherablesDataTable;
        private SqlCommand _spawnedGatherablesTableUpdate;
        private SqlCommand _spawnedGatherablesTableInsert;

        private const string SpawnedInteractablesTableName = "spawnedInteractables";
        public DataTable SpawnedInteractablesDataTable;
        private SqlCommand _spawnedInteractablesTableUpdate;
        private SqlCommand _spawnedInteractablesTableInsert;
        public Dictionary<Guid, DataRow> SpawnedInteractablesDictionary;

        private const string SpawnedMonstersTableName = "spawnedMonsters";
        public DataTable SpawnedMonstersDataTable;
        private SqlCommand _spawnedMonstersTableUpdate;
        private SqlCommand _spawnedMonstersTableInsert;

        private const string SpawnedNpcsTableName = "spawnedNPCs";
        public DataTable SpawnedNpcsDataTable;
        private SqlCommand _spawnedNpcsTableUpdate;
        private SqlCommand _spawnedNpcsTableInsert;

        private const string SpawnedVendorInventoryTableName = "spawnedVendorInventory";
        public DataTable SpawnedVendorInventoryDataTable;
        private SqlCommand _spawnedVendorInventoryTableUpdate;
        private SqlCommand _spawnedVendorInventoryTableInsert;

        private const string SpawnedVendorsTableName = "spawnedVendors";
        public DataTable SpawnedVendorsDataTable;
        private SqlCommand _spawnedVendorsTableUpdate;
        private SqlCommand _spawnedVendorsTableInsert;

        private const string SpawnedWorldObjectsTableName = "spawnedWorldObjects";
        public DataTable SpawnedWorldObjectsDataTable;
        private SqlCommand _spawnedWorldObjectsTableUpdate;
        private SqlCommand _spawnedWorldObjectsTableInsert;
        public Dictionary<Guid, DataRow> SpawnedWorldObjectsDictionary;


        private const string SpawnedWorldObjectsBagsTableName = "spawnedWorldObjectsBags";
        public DataTable SpawnedWorldObjectsBagsDataTable;
        private SqlCommand _spawnedWorldObjectsBagsTableUpdate;
        private SqlCommand _spawnedWorldObjectsBagsTableInsert;
        public Dictionary<int, DataRow> SpawnedWorldObjectsBagsDictionaryByCharacterBagId;

        private const string SpawnedWorldObjectsCurrencyTableName = "spawnedWorldObjectsCurrency";
        public DataTable SpawnedWorldObjectsCurrencyDataTable;
        private SqlCommand _spawnedWorldObjectsCurrencyTableUpdate;
        private SqlCommand _spawnedWorldObjectsCurrencyTableInsert;
        public Dictionary<Guid, DataRow> SpawnedWorldObjectsCurrencyDictionary;

        private const string SpawnedWorldObjectsEquipmentTableName = "spawnedWorldObjectsEquipment";
        public DataTable SpawnedWorldObjectsEquipmentDataTable;
        private SqlCommand _spawnedWorldObjectsEquipmentTableUpdate;
        private SqlCommand _spawnedWorldObjectsEquipmentTableInsert;
        public Dictionary<Guid, List<DataRow>> SpawnedWorldObjectsEquipmentDictionary;

        private const string SpawnedWorldObjectsInventoryTableName = "spawnedWorldObjectsInventory";
        public DataTable SpawnedWorldObjectsInventoryDataTable;
        private SqlCommand _spawnedWorldObjectsInventoryTableUpdate;
        private SqlCommand _spawnedWorldObjectsInventoryTableInsert;
        public Dictionary<Guid, DataRow> SpawnedWorldObjectsInventoryDictionaryByInstancedItemId;
        #endregion
        
        private const string SpawnerLocationsTableName = "spawnerLocations";
        public DataTable SpawnerLocationsDataTable;
        private SqlCommand _spawnerLocationsTableUpdate;
        private SqlCommand _spawnerLocationsTableInsert;
        
        #region READ ONLY TABLE NAMES, DATA TABLES: ENUM

        private const string ApplicationTypesTableName = "applicationTypes";
        public DataTable ApplicationTypesDataTable;

        private const string AbilityTypesTableName = "abilityTypes";
        public DataTable AbilityTypesDataTable;

        private const string AbilityEffectTypesTableName = "abilityEffectTypes";
        public DataTable AbilityEffectTypesDataTable;

        private const string ArmorTypesTableName = "armorTypes";
        public DataTable ArmorTypesDataTable;

        private const string AdventuringQuestTypesTableName = "adventuringQuestTypes";
        public DataTable AdventuringQuestTypesDataTable;

        private const string AnimalTypesTableName = "animalTypes";
        public DataTable AnimalTypesDataTable;

        private const string AnimalClassificationTypesTableName = "animalClassificationTypes";
        public DataTable AnimalClassificationTypesDataTable;
        
        private const string AnimalSubTypesTableName = "animalSubTypes";
        public DataTable AnimalSubTypesDataTable;

        private const string BagTypesTableName = "bagTypes";
        public DataTable BagTypesDataTable;
        
        private const string BagClassificationTypesTableName = "bagClassificationTypes";
        public DataTable BagClassificationTypesDataTable;
        
        private const string BagSubTypesTableName = "bagSubTypes";
        public DataTable BagSubTypesDataTable;

        private const string ConsumableTypesTableName = "consumableTypes";
        public DataTable ConsumableTypesDataTable;

        private const string    ConsumableClassificationTypesTableName = "consumableClassificationTypes";
        public        DataTable ConsumableClassificationTypesDataTable;
        
        private const string    ConsumableSubTypesTableName = "consumableSubTypes";
        public        DataTable ConsumableSubTypesDataTable;


        private const string ContainerTypesTableName = "containerTypes";
        public DataTable ContainerTypesDataTable;

        private const string CostTypesTableName = "costTypes";
        public DataTable CostTypesDataTable;

        private const string CraftingQuestTypesTableName = "craftingQuestTypes";
        public DataTable CraftingQuestTypesDataTable;

        private const string ElementalTypesTableName = "elementalTypes";
        public DataTable ElementalTypesDataTable;

        private const string EffectAmountTypesTableName = "effectAmountTypes";
        public DataTable EffectAmountTypesDataTable;
        
        private const string EffectTypesTableName = "effectTypes";
        public DataTable EffectTypesDataTable;
        
        private const string AbilityActivationTypesTableName = "abilityActivationTypes";
        public DataTable AbilityActivationTypesDataTable;

        private const string EntityTypesTableName = "entityTypes";
        public DataTable EntityTypesDataTable;

        private const string EnemyHumanoidTypesTableName = "enemyHumanoidTypes";
        public DataTable EnemyHumanoidTypesDataTable;

        private const string EnemyHumanoidClassificationTypesTableName = "enemyHumanoidClassificationTypes";
        public DataTable EnemyHumanoidClassificationTypesDataTable;

        private const string EnemyHumanoidSubTypesTableName = "enemyHumanoidSubTypes";
        public DataTable EnemyHumanoidSubTypesDataTable;

        private const string MonsterTypesTableName = "monsterTypes";
        public DataTable MonsterTypesDataTable;

        private const string MonsterClassificationTypesTableName = "monsterClassificationTypes";
        public DataTable MonsterClassificationTypesDataTable;

        private const string MonsterSubTypesTableName = "monsterSubTypes";
        public DataTable MonsterSubTypesDataTable;

        private const string GeneralItemTypesTableName = "generalItemTypes";
        public DataTable GeneralItemTypesDataTable;

        private const string    GeneralItemClassificationTypesTableName = "generalItemClassificationTypes";
        public        DataTable GeneralItemClassificationTypesDataTable;

        private const string GeneralItemSubTypesTableName = "generalItemSubTypes";
        public DataTable GeneralItemSubTypesDataTable;
        
        private const string AwardEffectTypesTableName = "awardEffectTypes";
        public DataTable AwardEffectTypesDataTable;

        private const string ArmorSlotTypesTableName = "armorSlotTypes";
        public DataTable ArmorSlotTypesDataTable;

        private const string EquipmentTypesTableName = "equipmentTypes";
        public DataTable EquipmentTypesDataTable;
        
        private const string EquipmentSlotTypesTableName = "equipmentSlotTypes";
        public DataTable EquipmentSlotTypesDataTable;
        
        private const string ExperienceEffectTypesTableName = "experienceEffectTypes";
        public DataTable ExperienceEffectTypesDataTable;

        private const string GatherableTypesTableName = "gatherableTypes";
        public DataTable GatherableTypesDataTable;
        
        private const string GatherableClassificationTypesTableName = "gatherableClassificationTypes";
        public DataTable GatherableClassificationTypesDataTable; 
        
        private const string GatherableSubTypesTableName = "gatherableSubTypes";
        public DataTable GatherableSubTypesDataTable;
        
        private const string GatheringQuestTypesTableName = "gatheringQuestTypes";
        public DataTable GatheringQuestTypesDataTable;

        private const string RequirementTypesTableName = "requirementTypes";
        public DataTable RequirementTypesDataTable;

        
        private const string GlobalObjectTypesTableName = "globalObjectTypes";
        public DataTable GlobalObjectTypesDataTable;

        private const string InteractableTypesTableName = "interactableTypes";
        public DataTable InteractableTypesDataTable;

        private const string ItemSubTypesTableName = "itemSubTypes";
        public DataTable ItemSubTypesDataTable;

        private const string ItemTypesTableName = "itemTypes";
        public DataTable ItemTypesDataTable;

        
        private const string    JewelerySlotTypesTableName = "jewelrySlotTypes";
        public        DataTable JewelerySlotTypesDataTable;
        
        private const string    JeweleryTypesTableName = "jewelryTypes";
        public        DataTable JeweleryTypesDataTable;
        
        private const string LootTableTypesTableName = "lootTableTypes";
        public DataTable LootTableTypesDataTable;

        private const string LootTableMainTypesTableName = "lootTableClassificationTypes";
        public DataTable LootTableMainTypesDataTable;

        private const string MaterialTypesTableName = "materialTypes";
        public DataTable MaterialTypesDataTable;
        
        private const string MaterialClassificationTypesTableName = "materialClassificationTypes";
        public DataTable MaterialClassificationTypesDataTable;        
        
        private const string MaterialSubTypesTableName = "materialSubTypes";
        public DataTable MaterialSubTypesDataTable;
        
        private const string ModifierTypesTableName = "modifierTypes";
        public DataTable ModifierTypesDataTable;

        private const string NpcTypesTableName = "npcTypes";
        public DataTable NpcTypesDataTable;

        private const string QuestCategoryTypesTableName = "questCategoryTypes";
        public DataTable QuestCategoryTypesDataTable;

        private const string QuestObjectiveTypesTableName = "questObjectiveTypes";
        public DataTable QuestObjectiveTypesDataTable;

        private const string SkillTypesTableName = "skillTypes";
        public DataTable SkillTypesDataTable;

        private const string UnlockEffectTypesTableName = "unlockEffectTypes";
        public DataTable UnlockEffectTypesDataTable;

        private const string WeaponTypesTableName = "weaponTypes";
        public DataTable WeaponTypesDataTable;

        private const string WeaponsSlotTypesTableName = "weaponSlotTypes";
        public DataTable WeaponSlotTypesDataTable;

        private const string WorldObjectTypesTableName = "worldObjectTypes";
        public DataTable WorldObjectTypesDataTable;
        #endregion
        
        #region READ ONLY TABLE NAMES, DATA TABLES: REFERENCE
        public const string AbilityDifficultyTiersTableName = "abilityDifficultyTiers";
        public DataTable AbilityDifficultyTiersDataTable;

        private const string AwardEffectsTableName = "awardEffects";
        public DataTable AwardEffectsDataTable;

        private const string AbilityLevelsToObjectSpawnablesMappingTableName = "abilityLevelsToObjectSpawnablesMapping";
        public DataTable AbilityRanksToObjectRanksMappingDataTable;

        private const string AttributePointsTableName = "attributePoints";
        public DataTable AttributePointsDataTable;

        private const string BodyPartPathsTableName = "bodyPartPaths";
        public DataTable BodyPartPathsDataTable;

        private const string BodyPartMultipliersTableName = "bodyPartMultipliers";
        public DataTable BodyPartMultipliersDataTable;
        
        private const string BodyPartTypesTableName = "bodyPartTypes";
        public DataTable BodyPartTypesDataTable;
        
        private const string CharacterCreationOptionsTableName = "characterCreationOptions";
        public DataTable CharacterCreationOptionsDataTable;

        private const string EffectsTableName = "effects";
        public DataTable EffectsDataTable;
        public Dictionary<string, DataRow> EffectsDictionary;

        private const string EffectGroupsTableName = "effectGroups";
        public DataTable EffectGroupsDataTable;
        public Dictionary<string, DataRow> EffectGroupsDictionary;

        private const string EffectGroupsToItemsMappingTableName = "effectGroupsToItemsMapping";
        public DataTable EffectGroupsToItemsMappingDataTable;

        private const string EffectGroupsToObjectsMappingTableName = "effectGroupsToObjectsMapping";
        public DataTable EffectGroupsToObjectsMappingDataTable;
        public Dictionary<string, Dictionary<byte, DataRow>> EffectGroupsToObjectsMappingDictionary;

        private const string EffectsToEffectGroupsMappingTableName = "effectsToEffectGroupsMapping";
        public DataTable EffectsToEffectGroupsMappingDataTable;
        public Dictionary<string, Dictionary<string, DataRow>> EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode;
        public Dictionary<string, Dictionary<string, DataRow>> EffectsToEffectGroupsMappingDictionaryByEffectGroupGlobalObjectCode;

        private const string EntityStatsTableName = "entityStats";
        public DataTable EntityStatsDataTable;
        
        private const string ExperienceEffectsTableName = "experienceEffects";
        public DataTable ExperienceEffectsDataTable;

        private const string GlobalObjectsTableName = "globalObjects";
        public DataTable GlobalObjectsDataTable;
        public Dictionary<string, DataRow> GlobalObjectsDictionary;

        private const string GlobalStatusesTableName = "globalStatuses";
        public DataTable GlobalStatusesDataTable;

        private const string GlobalTiersTableName = "globalTiers";
        public DataTable GlobalTiersDataTable;

        private const string IconsTableName = "icons";
        public DataTable IconsDataTable;

        private const string LastUpdatedTablesTableName = "lastUpdatedTables";
        public DataTable LastUpdatedTablesDataTable;

        private const string LevelRequirementsTableName = "levelRequirements";
        public DataTable LevelRequirementsDataTable;

        private const string LevelRequirementsAbilitiesTableName = "levelRequirementsAbilities";
        public DataTable LevelRequirementsAbilitiesDataTable;

        private const string LevelRequirementsSkillsTableName = "levelRequirementsSkills";
        public DataTable LevelRequirementsSkillsDataTable;

        private const string PrefabsTableName = "prefabs";
        public DataTable PrefabsDataTable;

        private const string SkillDifficultyTiersTableName = "skillDifficultyTiers";
        public DataTable SkillDifficultyTiersDataTable;

        private const string StatEffectsTableName = "statEffects";
        public DataTable StatEffectsDataTable;
        public Dictionary<string, DataRow> StatEffectsDictionary;

        private const string StatsTableName = "stats";
        public DataTable StatsDataTable;

        private const string StatBaseTypesTableName = "statBaseTypes";
        public DataTable StatBaseTypesDataTable;

        private const string StatCalculatedTypesTableName = "statCalculatedTypes";
        public DataTable StatCalculatedTypesDataTable;

        private const string StatMultiplierTypesTableName = "statMultiplierTypes";
        public DataTable StatMultiplierTypesDataTable;

        private const string StatTypesTableName = "statTypes";
        public DataTable StatTypesDataTable;

        private const string UnlockEffectsTableName = "unlockEffects";
        public DataTable UnlockEffectsDataTable;

        private const string WeaponsPositionsTableName = "weaponsPositions";
        public DataTable WeaponsPositionsDataTable;

        private const string WorldObjectsRanksToLootTablesTableName = "spawnablesToLootTables";
        public DataTable WorldObjectsRanksToLootTablesDataTable;
        public Dictionary<string, Dictionary<string, DataRow>> WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode;
      
        private const string SpawnablesToPrefabsTableName = "spawnablesToPrefabs";
        public DataTable SpawnablesToPrefabsDataTable;
        public Dictionary<string, Dictionary<byte, Dictionary<byte, List<DataRow>>>> SpawnablesToPrefabsByWorldObjectGlobalObjectCode;

        private const string DataAttributesToGlobalObjectsTableName = "dataAttributesToGlobalObjects";
        public DataTable DataAttributesToGlobalObjectsDataTable;
        public Dictionary<string, DataRow> DataAttributesToGlobalObjectsDictionaryByWorldObjectGlobalObjectCode;

        
        #endregion

        //private const string    MissionObjectivesTableName = "missionObjectives";
        //public DataTable MissionObjectivesDataTable;
        
        #region READ ONLY TABLE NAMES, DATA TABLES: SCRIPTABLE

        private const string ScriptableAbilitiesTableName = "scriptableAbilities";
        public DataTable ScriptableAbilitiesDataTable;

        private const string ScriptableAbilitiesLevelsTableName = "scriptableAbilitiesLevels";
        public DataTable ScriptableAbilitiesRanksDataTable;
        
        private const string ScriptableAbilitiesLevelsActivationCostsTableName = "scriptableAbilitiesLevelsActivationCosts";
        public DataTable ScriptableAbilitiesRanksActivationCostsDataTable;
        public Dictionary<string, Dictionary<byte, List<DataRow>>> ScriptableAbilitiesRanksActivationCostsDictionary;

        private const string ScriptableAchievementsTableName = "scriptableAchievements";
        public DataTable ScriptableAchievementsDataTable;
        
        private const string ScriptableAnimalsTableName = "scriptableAnimals";
        public DataTable ScriptableAnimalsDataTable;

        private const string ScriptableArmorTableName = "scriptableArmor";
        public DataTable ScriptableArmorDataTable;
        public Dictionary<string, DataRow> ScriptableArmorDictionary;

        private const string ScriptableBagsTableName = "scriptableBags";
        public DataTable ScriptableBagsDataTable;

        private const string ScriptableConsumablesTableName = "scriptableConsumables";
        public DataTable ScriptableConsumablesDataTable;

        private const string                      ScriptableContainersTableName = "scriptableContainers";
        public DataTable                   ScriptableContainersDataTable;
        public Dictionary<string, DataRow> ScriptableContainersDictionary;

        private const string ScriptableEnemyHumanoidsTableName = "scriptableEnemyHumanoids";
        public DataTable ScriptableEnemyHumanoidsDataTable;

        private const string ScriptableEquipmentTableName = "scriptableEquipment";
        public DataTable ScriptableEquipmentDataTable;
        public Dictionary<string, DataRow> ScriptableEquipmentDictionary;
        
        private const string ScriptableEquipmentRequirementsTableName = "scriptableEquipmentRequirements";
        public DataTable ScriptableEquipmentRequirementsDataTable;
        public Dictionary<string, DataRow> ScriptableEquipmentRequirementsDictionary;

        private const string ScriptableEntitiesTableName = "scriptableEntities";
        public DataTable ScriptableEntitiesDataTable;
        public Dictionary<string, DataRow> ScriptableEntitiesDictionary;

        private const string ScriptableGatherablesTableName = "scriptableGatherables";
        public DataTable ScriptableGatherablesDataTable;

        private const string ScriptableGeneralItemsTableName = "scriptableGeneralItems";
        public DataTable ScriptableGeneralItemsDataTable;

        private const string ScriptableInteractablesTableName = "scriptableInteractables";
        public DataTable ScriptableInteractablesDataTable;
        public Dictionary<string, DataRow> ScriptableInteractablesDictionary;

        private const string ScriptableItemsTableName = "scriptableItems";
        public DataTable ScriptableItemsDataTable;
        public Dictionary<string, DataRow> ScriptableItemsDictionary;

        private const string ScriptableJeweleryTableName = "scriptableJewelry";
        public DataTable ScriptableJeweleryDataTable;
        public Dictionary<string, DataRow> ScriptableJeweleryDictionary;
        
        private const string ScriptableLootTablesTableName = "scriptableLootTables";
        public DataTable ScriptableLootTablesDataTable;

        private const string ScriptableLootTablesToLootTableTableName = "scriptableLootTablesToLootTable";
        public DataTable ScriptableLootTablesToLootTableDataTable;

        private const string ScriptableLootTableDropsTableName = "scriptableLootTableDrops";
        public DataTable ScriptableLootTableDropsDataTable;
        //public Dictionary<string, DataRow> ScriptableLootTableDropsDictionary;
        public Dictionary<string, Dictionary<string, DataRow>> ScriptableLootTableDropsDictionaryByGlobalObjectCode;

        private const string ScriptableLootTableRaritiesTableName = "scriptableLootTableRarities";
        public DataTable ScriptableLootTableRaritiesDataTable;
        //public Dictionary<string, DataRow> ScriptableLootTableRaritiesDictionary = new Dictionary<string, DataRow>();
        public Dictionary<string, Dictionary<string, Dictionary<byte,DataRow>>> ScriptableLootTableRaritiesDictionaryByGlobalObjectCode;

        private const string ScriptableLootTableQuantitiesTableName = "scriptableLootTableQuantities";
        public DataTable ScriptableLootTableQuantitiesDataTable;
        //public Dictionary<string, DataRow> ScriptableLootTableQuantitiesDictionary = new Dictionary<string, DataRow>();
        public Dictionary<string, Dictionary<string, Dictionary<byte,DataRow>>> ScriptableLootTableQuantitiesDictionaryByGlobalObjectCode;

        private const string ScriptableMaterialsTableName = "scriptableMaterials";
        public DataTable ScriptableMaterialsDataTable;

        private const string ScriptableMaterialModifiersTableName = "scriptableMaterialModifiers";
        public DataTable ScriptableMaterialModifiersDataTable;

        private const string ScriptableMilestonesTableName = "scriptableMilestones";
        public DataTable ScriptableMilestonesDataTable;

        private const string ScriptableMonstersTableName = "scriptableMonsters";
        public DataTable ScriptableMonstersDataTable;

        private const string ScriptableNpcsTableName = "scriptableNpcs";
        public DataTable ScriptableNpcsDataTable;

        private const string ScriptableObjectsTableName = "scriptableObjects";
        public DataTable ScriptableObjectsDataTable;
        public Dictionary<string, DataRow> ScriptableObjectsDictionary;

        private const string ScriptableObjectTypesTableName = "scriptableObjectTypes";
        public DataTable ScriptableObjectTypesDataTable;

        private const string ScriptableObjectRanksTableName = "scriptableObjectLevels";
        public DataTable ScriptableObjectRanksDataTable;
        public Dictionary<string, Dictionary<byte, DataRow>> ScriptableObjectRanksDictionaryByNestedObjectCode;

        private const string ScriptableObjectsSpawnablesTableName = "scriptableObjectSpawnables";
        public DataTable ScriptableObjectsSpawnablesDataTable;
        public Dictionary<string, List<DataRow>> ScriptableObjectsSpawnablesDictionaryByNestedObjectCode;

        private const string ScriptableQuestsTableName = "scriptableQuests";
        public DataTable ScriptableQuestsDataTable;
        public Dictionary<string, DataRow> ScriptableQuestsDictionary;

        private const string ScriptableQuestlinesTableName = "scriptableQuestlines";
        public DataTable ScriptableQuestlinesDataTable;

        private const string ScriptableQuestlineQuestOrderTableName = "scriptableQuestlineQuestOrder";
        public DataTable ScriptableQuestlineQuestOrderDataTable;

        private const string ScriptableQuestExclusionsTableName = "scriptableQuestExclusions";
        public DataTable ScriptableQuestExclusionsDataTable;

        private const string ScriptableQuestObjectivesTableName = "scriptableQuestObjectives";
        public DataTable ScriptableQuestObjectivesDataTable;
        public Dictionary<string, Dictionary<string, DataRow>> ScriptableQuestObjectivesDictionary;
        
        public const string ScriptableRecipesTableName = "scriptableRecipes";
        public DataTable ScriptableRecipesDataTable;
        public Dictionary<string, DataRow> ScriptableRecipesDictionaryByGlobalObject;

        private const string ScriptableRequirementsTableName = "scriptableRequirements";
        public DataTable ScriptableRequirementsDataTable;
        public Dictionary<string, Dictionary<string, DataRow>> ScriptableRequirementsDictionary;

        private const string ScriptableQualitiesTableName = "scriptableQualities";
        public DataTable ScriptableQualitiesDataTable;

        private const string ScriptableQualityModifiersTableName = "scriptableQualityModifiers";
        public DataTable ScriptableQualityModifiersDataTable;

        private const string ScriptableRaritiesTableName = "scriptableRarities";
        public DataTable ScriptableRaritiesDataTable;

        private const string ScriptableRarityModifiersTableName = "scriptableRarityModifiers";
        public DataTable ScriptableRarityModifiersDataTable;

        private const string ScriptableRecipeIngredientsTableName = "scriptableRecipeIngredients";
        public DataTable ScriptableRecipeIngredientsDataTable;
        //public Dictionary<string, DataRow> ScriptableRecipeIngredientsDictionary = new Dictionary<string, DataRow>();
        public Dictionary<string, Dictionary<string, DataRow>> ScriptableRecipeIngredientsDictionaryByNestedObjectCode;

        private const string ScriptableSkillsTableName = "scriptableSkills";
        public DataTable ScriptableSkillsDataTable;
        public Dictionary<string, DataRow> ScriptableSkillsDictionary;

        private const string ScriptableSpawnTablesTableName = "scriptableSpawnTables";
        public DataTable ScriptableSpawnTablesDataTable;

        private const string ScriptableSpawnTableOptionsTableName = "scriptableSpawnTableOptions";
        public DataTable ScriptableSpawnTableOptionsDataTable;

        private const string ScriptableTitlesTableName = "scriptableTitles";
        public DataTable ScriptableTitlesDataTable;

        private const string ScriptableTotalsTableName = "scriptableTotals";
        public DataTable ScriptableTotalsDataTable;
        public Dictionary<string, DataRow> ScriptableTotalsDictionary;

        private const string ScriptableTotalsCraftTableName = "scriptableTotalsCraft";
        public DataTable ScriptableTotalsCraftDataTable;

        private const string ScriptableTotalsCollectTableName = "scriptableTotalsCollect";
        public DataTable ScriptableTotalsCollectDataTable;

        private const string ScriptableTotalsGatherTableName = "scriptableTotalsGather";
        public DataTable ScriptableTotalsGatherDataTable;

        private const string ScriptableTotalsKillTableName = "scriptableTotalsKill";
        public DataTable ScriptableTotalsKillsDataTable;

        private const string ScriptableVendorsTableName = "scriptableVendors";
        public DataTable ScriptableVendorsDataTable;
        public Dictionary<string, DataRow> ScriptableVendorsDictionary;

        private const string ScriptableVendorItemsTableName = "scriptableVendorItems";
        public DataTable ScriptableVendorItemsDataTable;

        private const string ScriptableWeaponsTableName = "scriptableWeapons";
        public DataTable ScriptableWeaponsDataTable;
        public Dictionary<string, DataRow> ScriptableWeaponsDictionary;

        private const string ScriptableWorldObjectsTableName = "scriptableWorldObjects";
        public DataTable ScriptableWorldObjectsDataTable;
        public Dictionary<string, DataRow> ScriptableWorldObjectsDictionary;
        #endregion
        
#region SET DEFAULT VIEW SORT
        public void SetDefaultViewsCharacterTables()
        {
            //SET DEFAULT VIEWS FOR IMPROVE QUERY PERFORMANCE
            CharactersAbilitiesDataTable.DefaultView.Sort = "characterId";
            CharactersAchievementsDataTable.DefaultView.Sort = "characterId";
            CharactersQuestsDataTable.DefaultView.Sort = "characterId";
            CharactersRecipesDataTable.DefaultView.Sort = "characterId";
            CharactersSkillsDataTable.DefaultView.Sort = "characterId";
            CharactersSocialDataTable.DefaultView.Sort = "characterId";
            CharactersStatsDataTable.DefaultView.Sort = "characterId";
            CharactersTitlesDataTable.DefaultView.Sort = "characterId";
        }
        
        public void SetDefaultViewsScriptableTables()
        {
            //SET DEFAULT VIEWS FOR IMPROVE QUERY PERFORMANCE
            GlobalObjectsDataTable.DefaultView.Sort = "globalObject";
            ScriptableObjectsDataTable.DefaultView.Sort = "globalObject";
            ScriptableItemsDataTable.DefaultView.Sort = "globalObject";
            ScriptableEquipmentDataTable.DefaultView.Sort = "globalObject";
            //ScriptableRaritiesDataTable.DefaultView.Sort = "globalObject";
            ScriptableRecipesDataTable.DefaultView.Sort = "globalObject";
            ScriptableSkillsDataTable.DefaultView.Sort = "globalObject";
            PrefabsDataTable.DefaultView.Sort = "globalObject";
            ScriptableSpawnTablesDataTable.DefaultView.Sort = "globalObject";
            ScriptableSpawnTableOptionsDataTable.DefaultView.Sort = "globalObject";
        }
        
        public void SetDefaultViewsInstancedItemsTables()
        {
            //SET DEFAULT VIEWS FOR IMPROVE QUERY PERFORMANCE
            CharactersBuyBacksDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            CharactersMailDataTable.DefaultView.Sort = "recipientSpawnedWorldObjectId";
            CharactersMailAttachmentsDataTable.DefaultView.Sort = "charactersMailId";
            //InstancedAmmunitionDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            InstancedArmorDataTable.DefaultView.Sort = "instancedItemId";
            InstancedBagsDataTable.DefaultView.Sort = "instancedItemId";
            InstancedConsumablesDataTable.DefaultView.Sort = "instancedItemId";
            InstancedEquipmentDataTable.DefaultView.Sort = "instancedItemId";
            InstancedGeneralItemsDataTable.DefaultView.Sort = "instancedItemId";
            InstancedItemsDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            InstancedItemsIngredientsDataTable.DefaultView.Sort = "instancedItemId";
            InstancedMaterialsDataTable.DefaultView.Sort = "instancedItemId";
            InstancedWeaponsDataTable.DefaultView.Sort = "instancedItemId";
        }
        
        public void SetDefaultViewsSpawnedTables()
        {
            //SET DEFAULT VIEWS FOR IMPROVE QUERY PERFORMANCE
            SpawnedAnimalsDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedContainersDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedEnemyHumanoidsDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedEntitiesDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedGatherablesDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedInteractablesDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedMonstersDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedNpcsDataTable.DefaultView.Sort = "spawnedEntityId";
            SpawnedVendorsDataTable.DefaultView.Sort = "spawnedNPCId";
            SpawnedVendorInventoryDataTable.DefaultView.Sort = "spawnedVendorId";
            SpawnedWorldObjectsDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedWorldObjectsBagsDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedWorldObjectsCurrencyDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedWorldObjectsEquipmentDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            SpawnedWorldObjectsInventoryDataTable.DefaultView.Sort = "spawnedWorldObjectId";
            
        }
        

        #endregion

        #region LOAD DATA FROM SQL INTO DATATABLES

        public void FillEnumDataSet()
        {
            ApplicationTypesDataTable           = FillTable(_dataSet, ApplicationTypesTableName);
            AbilityTypesDataTable           = FillTable(_dataSet, AbilityTypesTableName);
            AbilityEffectTypesDataTable     = FillTable(_dataSet, AbilityEffectTypesTableName);
            AbilityActivationTypesDataTable = FillTable(_dataSet, AbilityActivationTypesTableName);
            AdventuringQuestTypesDataTable  = FillTable(_dataSet, AdventuringQuestTypesTableName);
            
            AnimalTypesDataTable               = FillTable(_dataSet, AnimalTypesTableName);
            AnimalClassificationTypesDataTable = FillTable(_dataSet, AnimalClassificationTypesTableName);
            AnimalSubTypesDataTable            = FillTable(_dataSet, AnimalSubTypesTableName);
            
            ArmorTypesDataTable                    = FillTable(_dataSet, ArmorTypesTableName);
            ArmorSlotTypesDataTable                = FillTable(_dataSet, ArmorSlotTypesTableName);
            AwardEffectTypesDataTable              = FillTable(_dataSet, AwardEffectTypesTableName);
            
            BodyPartTypesDataTable               = FillTable(_dataSet, BodyPartTypesTableName);
            
            ConsumableTypesDataTable               = FillTable(_dataSet, ConsumableTypesTableName);
            ConsumableSubTypesDataTable            = FillTable(_dataSet, ConsumableSubTypesTableName);
            ConsumableClassificationTypesDataTable = FillTable(_dataSet, ConsumableClassificationTypesTableName);
            ContainerTypesDataTable                = FillTable(_dataSet, ContainerTypesTableName);
            CostTypesDataTable                     = FillTable(_dataSet, CostTypesTableName);
            CraftingQuestTypesDataTable            = FillTable(_dataSet, CraftingQuestTypesTableName);
            ElementalTypesDataTable                   = FillTable(_dataSet, ElementalTypesTableName);
            EffectAmountTypesDataTable                   = FillTable(_dataSet, EffectAmountTypesTableName);
            EffectTypesDataTable                   = FillTable(_dataSet, EffectTypesTableName);
            
            EnemyHumanoidTypesDataTable               = FillTable(_dataSet, EnemyHumanoidTypesTableName);
            EnemyHumanoidClassificationTypesDataTable = FillTable(_dataSet, EnemyHumanoidClassificationTypesTableName);
            EnemyHumanoidSubTypesDataTable            = FillTable(_dataSet, EnemyHumanoidSubTypesTableName);
            
            EquipmentTypesDataTable        = FillTable(_dataSet, EquipmentTypesTableName);
            EquipmentSlotTypesDataTable    = FillTable(_dataSet, EquipmentSlotTypesTableName);
            ExperienceEffectTypesDataTable = FillTable(_dataSet, ExperienceEffectTypesTableName);
            EntityTypesDataTable           = FillTable(_dataSet, EntityTypesTableName); 
            
            GatherableTypesDataTable               = FillTable(_dataSet, GatherableTypesTableName); 
            GatherableClassificationTypesDataTable = FillTable(_dataSet, GatherableClassificationTypesTableName); 
            GatherableSubTypesDataTable            = FillTable(_dataSet, GatherableSubTypesTableName); 
            
            GatheringQuestTypesDataTable = FillTable(_dataSet, GatheringQuestTypesTableName);
            
            GeneralItemTypesDataTable               = FillTable(_dataSet, GeneralItemTypesTableName);
            GeneralItemClassificationTypesDataTable = FillTable(_dataSet, GeneralItemClassificationTypesTableName);
            GeneralItemSubTypesDataTable            = FillTable(_dataSet, GeneralItemSubTypesTableName);
            
            GlobalObjectTypesDataTable  = FillTable(_dataSet, GlobalObjectTypesTableName);
            GlobalStatusesDataTable     = FillTable(_dataSet, GlobalStatusesTableName); 
            GlobalTiersDataTable        = FillTable(_dataSet, GlobalTiersTableName); 
            InteractableTypesDataTable  = FillTable(_dataSet, InteractableTypesTableName);
            ItemTypesDataTable          = FillTable(_dataSet, ItemTypesTableName);
            ItemSubTypesDataTable       = FillTable(_dataSet, ItemSubTypesTableName);
            JewelerySlotTypesDataTable  = FillTable(_dataSet, JewelerySlotTypesTableName);
            JeweleryTypesDataTable      = FillTable(_dataSet, JeweleryTypesTableName);
            LootTableTypesDataTable     = FillTable(_dataSet, LootTableTypesTableName);
            LootTableMainTypesDataTable = FillTable(_dataSet, LootTableMainTypesTableName); 
            
            MaterialTypesDataTable               = FillTable(_dataSet, MaterialTypesTableName);
            MaterialClassificationTypesDataTable = FillTable(_dataSet, MaterialClassificationTypesTableName); 
            MaterialSubTypesDataTable            = FillTable(_dataSet, MaterialSubTypesTableName);
            
            ModifierTypesDataTable               = FillTable(_dataSet, ModifierTypesTableName); 
            
            MonsterTypesDataTable = FillTable(_dataSet, MonsterTypesTableName);
            MonsterClassificationTypesDataTable = FillTable(_dataSet, MonsterClassificationTypesTableName);
            MonsterSubTypesDataTable = FillTable(_dataSet, MonsterSubTypesTableName);
            
            NpcTypesDataTable              = FillTable(_dataSet, NpcTypesTableName); 
            QuestCategoryTypesDataTable    = FillTable(_dataSet, QuestCategoryTypesTableName); 
            QuestObjectiveTypesDataTable   = FillTable(_dataSet, QuestObjectiveTypesTableName);
            RequirementTypesDataTable      = FillTable(_dataSet, RequirementTypesTableName);
            ScriptableObjectTypesDataTable = FillTable(_dataSet, ScriptableObjectTypesTableName); 
            ScriptableRaritiesDataTable    = FillTable(_dataSet, ScriptableRaritiesTableName); 
            ScriptableQualitiesDataTable   = FillTable(_dataSet, ScriptableQualitiesTableName); 
            SkillTypesDataTable            = FillTable(_dataSet, SkillTypesTableName);
            StatBaseTypesDataTable   = FillTable(_dataSet, StatBaseTypesTableName);
            StatCalculatedTypesDataTable   = FillTable(_dataSet, StatCalculatedTypesTableName);
            StatMultiplierTypesDataTable   = FillTable(_dataSet, StatMultiplierTypesTableName);
            StatTypesDataTable             = FillTable(_dataSet, StatTypesTableName);
            UnlockEffectTypesDataTable     = FillTable(_dataSet, UnlockEffectTypesTableName); 
            WeaponTypesDataTable           = FillTable(_dataSet, WeaponTypesTableName); 
            WeaponSlotTypesDataTable       = FillTable(_dataSet, WeaponsSlotTypesTableName); 
            WorldObjectTypesDataTable      = FillTable(_dataSet, WorldObjectTypesTableName); 
        }

        private void FillReferenceDataSet()
        {
            
            AttributePointsDataTable = FillTable(_dataSet, AttributePointsTableName); 
            AbilityDifficultyTiersDataTable = FillTable(_dataSet, AbilityDifficultyTiersTableName); 
            CharacterCreationOptionsDataTable = FillTable(_dataSet, CharacterCreationOptionsTableName); 
            LastUpdatedTablesDataTable = FillTable(_dataSet, LastUpdatedTablesTableName);
            LevelRequirementsDataTable = FillTable(_dataSet, LevelRequirementsTableName); 
            LevelRequirementsSkillsDataTable = FillTable(_dataSet, LevelRequirementsSkillsTableName); 
            LevelRequirementsAbilitiesDataTable = FillTable(_dataSet, LevelRequirementsAbilitiesTableName);
            StatsDataTable = FillTable(_dataSet, StatsTableName);
            SkillDifficultyTiersDataTable = FillTable(_dataSet, SkillDifficultyTiersTableName);

            //REFERENCE TABLES
            GlobalObjectsDataTable = FillTable(_dataSet, GlobalObjectsTableName);
            // EFFECTS
            BodyPartPathsDataTable = FillTable(_dataSet, BodyPartPathsTableName); 
            BodyPartMultipliersDataTable = FillTable(_dataSet, BodyPartMultipliersTableName);
            EntityStatsDataTable = FillTable(_dataSet, EntityStatsTableName);
            
            EffectsDataTable = FillTable(_dataSet, EffectsTableName); 
            AwardEffectsDataTable = FillTable(_dataSet, AwardEffectsTableName); 
            ExperienceEffectsDataTable = FillTable(_dataSet, ExperienceEffectsTableName); 
            StatEffectsDataTable = FillTable(_dataSet, StatEffectsTableName);
            UnlockEffectsDataTable = FillTable(_dataSet, UnlockEffectsTableName); 

            EffectGroupsDataTable = FillTable(_dataSet, EffectGroupsTableName); 
            EffectsToEffectGroupsMappingDataTable = FillTable(_dataSet, EffectsToEffectGroupsMappingTableName); 
            EffectGroupsToItemsMappingDataTable = FillTable(_dataSet, EffectGroupsToItemsMappingTableName); 
            EffectGroupsToObjectsMappingDataTable = FillTable(_dataSet, EffectGroupsToObjectsMappingTableName); 
            
            IconsDataTable = FillTableUsingStoredProcedure(_dataSet, "spIcons"); 
            PrefabsDataTable = FillTableUsingStoredProcedure(_dataSet, "spPrefabs"); 
        
            //WorldObjectsRanksToLootTablesDataTable = FillTable(_dataSet, WorldObjectsRanksToLootTablesTableName);
            WorldObjectsRanksToLootTablesDataTable = FillTableUsingStoredProcedure(_dataSet, "spSpawnablesToLootTables");
            SpawnablesToPrefabsDataTable = FillTable(_dataSet, SpawnablesToPrefabsTableName);
            DataAttributesToGlobalObjectsDataTable = FillTable(_dataSet, DataAttributesToGlobalObjectsTableName);
            
            SpawnerLocationsDataTable = FillTable(_dataSet, SpawnerLocationsTableName);

        }

        private void FillScriptableDataSet()
        {
            //ScriptableObjectsDataTable = FillTable(_dataSet,ScriptableObjectsTableName);
            ScriptableObjectsDataTable = FillTableUsingStoredProcedure(_dataSet,"spScriptableObjects");
            
            ScriptableObjectRanksDataTable = FillTable(_dataSet,ScriptableObjectRanksTableName); 
            //ScriptableObjectsSpawnablesDataTable = FillTable(_dataSet,ScriptableObjectsSpawnablesTableName); 
            ScriptableObjectsSpawnablesDataTable = FillTableUsingStoredProcedure(_dataSet,"spScriptableObjectSpawnables"); 
            
            ScriptableAchievementsDataTable = FillTable(_dataSet,ScriptableAchievementsTableName);
            ScriptableMilestonesDataTable = FillTable(_dataSet, ScriptableMilestonesTableName); 
            ScriptableSkillsDataTable = FillTable(_dataSet, ScriptableSkillsTableName);
            ScriptableTitlesDataTable = FillTable(_dataSet, ScriptableTitlesTableName);
            // ITEMS
            ScriptableItemsDataTable = FillTableUsingStoredProcedure(_dataSet, "spScriptableItems"); 
            
            ScriptableBagsDataTable = FillTable(_dataSet, ScriptableBagsTableName); 
            ScriptableConsumablesDataTable = FillTable(_dataSet, ScriptableConsumablesTableName); 
            ScriptableGeneralItemsDataTable = FillTable(_dataSet, ScriptableGeneralItemsTableName); 
            ScriptableMaterialsDataTable = FillTable(_dataSet, ScriptableMaterialsTableName); 
            ScriptableMaterialModifiersDataTable = FillTable(_dataSet, ScriptableMaterialModifiersTableName); 
            ScriptableEquipmentDataTable = FillTable(_dataSet, ScriptableEquipmentTableName); 
            ScriptableEquipmentRequirementsDataTable = FillTable(_dataSet, ScriptableEquipmentRequirementsTableName);
            ScriptableArmorDataTable = FillTable(_dataSet, ScriptableArmorTableName); 
            ScriptableJeweleryDataTable = FillTable(_dataSet, ScriptableJeweleryTableName); 
            ScriptableWeaponsDataTable = FillTable(_dataSet, ScriptableWeaponsTableName); 

            ScriptableWorldObjectsDataTable = FillTable(_dataSet, ScriptableWorldObjectsTableName);
            // INTERACTABLES
            ScriptableInteractablesDataTable = FillTable(_dataSet, ScriptableInteractablesTableName); 
            ScriptableGatherablesDataTable = FillTable(_dataSet, ScriptableGatherablesTableName); 
            ScriptableContainersDataTable = FillTable(_dataSet, ScriptableContainersTableName); 
            // ENTITIES
            ScriptableEntitiesDataTable = FillTable(_dataSet, ScriptableEntitiesTableName); 
            ScriptableAnimalsDataTable = FillTable(_dataSet, ScriptableAnimalsTableName); 
            ScriptableEnemyHumanoidsDataTable = FillTable(_dataSet, ScriptableEnemyHumanoidsTableName); 
            ScriptableMonstersDataTable = FillTable(_dataSet, ScriptableMonstersTableName); 
            ScriptableNpcsDataTable = FillTable(_dataSet, ScriptableNpcsTableName); 
            ScriptableVendorsDataTable = FillTable(_dataSet, ScriptableVendorsTableName);
            ScriptableVendorItemsDataTable = FillTable(_dataSet, ScriptableVendorItemsTableName);
            // ABILITIES
            ScriptableAbilitiesDataTable = FillTable(_dataSet, ScriptableAbilitiesTableName); 
            ScriptableAbilitiesRanksDataTable = FillTable(_dataSet, ScriptableAbilitiesLevelsTableName);
            ScriptableAbilitiesRanksActivationCostsDataTable = FillTable(_dataSet, ScriptableAbilitiesLevelsActivationCostsTableName);
            AbilityRanksToObjectRanksMappingDataTable = FillTable(_dataSet, AbilityLevelsToObjectSpawnablesMappingTableName);
            // LOOT TABLES
            ScriptableLootTablesDataTable = FillTable(_dataSet, ScriptableLootTablesTableName); 
            ScriptableLootTablesToLootTableDataTable = FillTable(_dataSet, ScriptableLootTablesToLootTableTableName); 
            ScriptableLootTableDropsDataTable = FillTable(_dataSet, ScriptableLootTableDropsTableName); 
            ScriptableLootTableRaritiesDataTable = FillTable(_dataSet, ScriptableLootTableRaritiesTableName); 
            ScriptableLootTableQuantitiesDataTable = FillTable(_dataSet, ScriptableLootTableQuantitiesTableName); 
            // QUALITIES
            ScriptableQualityModifiersDataTable = FillTable(_dataSet, ScriptableQualityModifiersTableName);
            // QUESTS
            ScriptableQuestsDataTable = FillTable(_dataSet, ScriptableQuestsTableName); 
            ScriptableQuestExclusionsDataTable = FillTable(_dataSet, ScriptableQuestExclusionsTableName); 
            ScriptableQuestObjectivesDataTable = FillTable(_dataSet, ScriptableQuestObjectivesTableName);
            // QUEST LINES
            ScriptableQuestlinesDataTable = FillTable(_dataSet, ScriptableQuestlinesTableName); 
            ScriptableQuestlineQuestOrderDataTable = FillTable(_dataSet, ScriptableQuestlineQuestOrderTableName);
            // RARITIES
            ScriptableRarityModifiersDataTable = FillTable(_dataSet, ScriptableRarityModifiersTableName);
            // RECIPES
            ScriptableRecipesDataTable = FillTable(_dataSet, ScriptableRecipesTableName); 
            ScriptableRecipeIngredientsDataTable = FillTable(_dataSet, ScriptableRecipeIngredientsTableName); 
            
            ScriptableSpawnTablesDataTable = FillTable(_dataSet, ScriptableSpawnTablesTableName); 
            ScriptableSpawnTableOptionsDataTable = FillTable(_dataSet, ScriptableSpawnTableOptionsTableName); 

            // TOTALS
            ScriptableTotalsDataTable = FillTable(_dataSet, ScriptableTotalsTableName); 
            ScriptableTotalsCollectDataTable = FillTable(_dataSet, ScriptableTotalsCollectTableName); 
            ScriptableTotalsCraftDataTable = FillTable(_dataSet, ScriptableTotalsCraftTableName); 
            ScriptableTotalsGatherDataTable = FillTable(_dataSet, ScriptableTotalsGatherTableName); 
            ScriptableTotalsKillsDataTable = FillTable(_dataSet, ScriptableTotalsKillTableName); 
            WeaponsPositionsDataTable = FillTable(_dataSet, WeaponsPositionsTableName); 
            ScriptableRequirementsDataTable = FillTable(_dataSet, ScriptableRequirementsTableName);
            
            //MissionObjectivesDataTable = FillTable(_dataSet,MissionObjectivesTableName);
        }

        private void FillInstancedItemDataSet()
        {
            //INSTANCED ITEMS TABLES
            InstancedItemsDataTable = FillTable(_dataSet, InstancedItemsTableName);
            InstancedItemsIngredientsDataTable = FillTable(_dataSet, InstancedItemsIngredientsTableName); 
            InstancedAmmunitionDataTable = FillTable(_dataSet, InstancedAmmunitionTableName); 
            InstancedBagsDataTable = FillTable(_dataSet, InstancedBagsTableName); 
            InstancedConsumablesDataTable = FillTable(_dataSet, InstancedConsumablesTableName);
            InstancedGeneralItemsDataTable = FillTable(_dataSet, InstancedGeneralItemsTableName); 
            InstancedMaterialsDataTable = FillTable(_dataSet, InstancedMaterialsTableName); 
            InstancedEquipmentDataTable = FillTable(_dataSet, InstancedEquipmentTableName);
            InstancedArmorDataTable = FillTable(_dataSet, InstancedArmorTableName); 
            InstancedWeaponsDataTable = FillTable(_dataSet, InstancedWeaponsTableName);

            InstancedMissionsDataTable = FillTable(_dataSet, InstancedMissionsTableName); 
            //SPAWNED TABLES
        }

        private void FillSpawnWorldObjectsDataSet()
        {
            SpawnedWorldObjectsDataTable = FillTable(_dataSet, SpawnedWorldObjectsTableName); 
            SpawnedWorldObjectsDataTable.PrimaryKey = new[] {SpawnedWorldObjectsDataTable.Columns[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId]};
            
            SpawnedWorldObjectsBagsDataTable = FillTable(_dataSet, SpawnedWorldObjectsBagsTableName);
            
            SpawnedWorldObjectsCurrencyDataTable = FillTable(_dataSet, SpawnedWorldObjectsCurrencyTableName); 
            SpawnedWorldObjectsEquipmentDataTable = FillTable(_dataSet, SpawnedWorldObjectsEquipmentTableName); 
            SpawnedWorldObjectsInventoryDataTable = FillTable(_dataSet, SpawnedWorldObjectsInventoryTableName);
            // SPAWNED INTERACTABLES
            SpawnedInteractablesDataTable = FillTable(_dataSet, SpawnedInteractablesTableName); 
            SpawnedGatherablesDataTable = FillTable(_dataSet, SpawnedGatherablesTableName); 
            SpawnedContainersDataTable = FillTable(_dataSet, SpawnedContainersTableName);
            // SPAWNED ENTITIES
            SpawnedEntitiesDataTable = FillTable(_dataSet, SpawnedEntitiesTableName);
            
            SpawnedAnimalsDataTable = FillTable(_dataSet, SpawnedAnimalsTableName); 
            SpawnedEnemyHumanoidsDataTable = FillTable(_dataSet, SpawnedEnemyHumanoidsTableName); 
            SpawnedMonstersDataTable = FillTable(_dataSet, SpawnedMonstersTableName); 
            SpawnedNpcsDataTable = FillTable(_dataSet, SpawnedNpcsTableName); 
            SpawnedVendorsDataTable = FillTable(_dataSet, SpawnedVendorsTableName); 
            SpawnedVendorInventoryDataTable = FillTable(_dataSet, SpawnedVendorInventoryTableName);
        }

        private void FillCharacterDataSet()
        {
            //CHARACTER TABLES
            PlayersAccountsDataTable = FillTable(_dataSet, PlayersAccountsTableName); //Console.WriteLine($"Rows in PlayersAccounts:{PlayersAccountsDataTable.Rows.Count}");
            CharactersDataTable = FillTable(_dataSet, CharactersTableName); //Console.WriteLine($"Rows in Characters:{CharactersDataTable.Rows.Count}");
            CharactersDataTable.Columns["characterId"].AutoIncrementSeed = 1;
            CharactersAbilitiesDataTable = FillTable(_dataSet, CharactersAbilitiesTableName); //Console.WriteLine($"Rows in CharactersAbilities:{CharactersAbilitiesDataTable.Rows.Count}");
            CharactersAchievementsDataTable = FillTable(_dataSet, CharactersAchievementsTableName); //Console.WriteLine($"Rows in CharactersAchievements:{CharactersAchievementsDataTable.Rows.Count}");
            CharactersBuyBacksDataTable = FillTable(_dataSet, CharactersBuyBacksTableName); 
            CharactersMissionsDataTable = FillTable(_dataSet, CharactersMissionsTableName); //Console.WriteLine($"Rows in CharactersQuests:{CharactersQuestsDataTable.Rows.Count}");
            CharactersQuestsDataTable = FillTable(_dataSet, CharactersQuestsTableName); //Console.WriteLine($"Rows in CharactersQuests:{CharactersQuestsDataTable.Rows.Count}");
            CharactersQuestsObjectivesDataTable = FillTable(_dataSet, CharactersQuestsObjectivesTableName); //Console.WriteLine($"Rows in CharactersQuests:{CharactersQuestsDataTable.Rows.Count}");
            CharactersRecipesDataTable = FillTable(_dataSet, CharactersRecipesTableName); //Console.WriteLine($"Rows in CharactersRecipes:{CharactersRecipesDataTable.Rows.Count}");
            CharactersSkillsDataTable = FillTable(_dataSet, CharactersSkillsTableName); //Console.WriteLine($"Rows in CharactersSkills:{CharactersSkillsDataTable.Rows.Count}");
            CharactersSocialDataTable = FillTable(_dataSet, CharactersSocialTableName); //Console.WriteLine($"Rows in CharactersSocial:{CharactersSocialDataTable.Rows.Count}");
            CharactersStatsDataTable = FillTable(_dataSet, CharactersStatsTableName); //Console.WriteLine($"Rows in CharactersStats:{CharactersStatsDataTable.Rows.Count}");
            CharactersStatusEffectsDataTable = FillTable(_dataSet, CharactersStatusEffectsTableName); //Console.WriteLine($"Rows in CharactersStats:{CharactersStatsDataTable.Rows.Count}");
            CharactersTitlesDataTable = FillTable(_dataSet, CharactersTitlesTableName); //Console.WriteLine($"Rows in CharactersTitles:{CharactersTitlesDataTable.Rows.Count}");
            CharactersMailDataTable = FillTable(_dataSet, CharactersMailTableName);
            CharactersMailAttachmentsDataTable = FillTable(_dataSet, CharactersMailAttachmentsTableName); 
        }

        private void FillHistoryDataSet()
        {
            HistoryCharacterCollectedDataTable = FillTable(_dataSet, HistoryCharacterCollectedTableName); 
            HistoryCharacterCombatDataTable = FillTable(_dataSet, HistoryCharacterCombatTableName); 
            HistoryCharacterCraftedDataTable = FillTable(_dataSet, HistoryCharacterCraftedTableName); 
            HistoryCharacterGatheredDataTable = FillTable(_dataSet, HistoryCharacterGatheredTableName); 
            HistoryCharacterDeathsDataTable = FillTable(_dataSet, HistoryCharacterDeathsTableName); 
            HistoryCharacterKillsDataTable = FillTable(_dataSet, HistoryCharacterKillsTableName); 
            HistoryCharacterLootDataTable = FillTable(_dataSet, HistoryCharacterLootTableName); 
            HistoryCharacterQuestsDataTable = FillTable(_dataSet, HistoryCharacterQuestsTableName); 
            HistoryCurrencyTransactionsDataTable = FillTable(_dataSet, HistoryCurrencyTransactionsTableName);
        }
        private void FillDataTablesFromSql()
        {
            var t = Connection;
            if (t.State != ConnectionState.Open)
            {
                Logger.LogError("Failed to open connection to database.");
                
            }
            _dataSet = new DataSet();
            Time(FillEnumDataSet);
            Time(FillReferenceDataSet);
            Time(FillScriptableDataSet);
            Time(FillInstancedItemDataSet);
            Time(FillSpawnWorldObjectsDataSet);
            Time(FillCharacterDataSet);
            Time(FillHistoryDataSet);
            
            var spawnedWorldObjectIdColumn = (byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId;
            var bagLocationIdColumn        = (byte)SpawnedWorldObjectsBagsColumns.bagLocationId;
            DataColumn[] spawnedWorldObjectsBagsPrimaryKeys =
            {
                SpawnedWorldObjectsBagsDataTable.Columns[spawnedWorldObjectIdColumn],
                SpawnedWorldObjectsBagsDataTable.Columns[bagLocationIdColumn]
            };
            
            var uniqueBag = new UniqueConstraint(
                "spawnedWorldObjectsBags_spawnedWorldObjectId_bagLocationId_uindex", spawnedWorldObjectsBagsPrimaryKeys, false);
            // var fKInstancedItemId = new ForeignKeyConstraint("FK_charactersBags_instancedItems",
            //     InstancedItemsDataTable.Columns[UnsafeUtility.EnumToInt(InstancedItemsColumns.instancedItemId)], 
            //     SpawnedWorldObjectsBagsDataTable.Columns[UnsafeUtility.EnumToInt(SpawnedWorldObjectsBagsColumns.instancedItemId)]);
            SpawnedWorldObjectsBagsDataTable.Constraints.Add(uniqueBag);
            
            _dataSet.EnforceConstraints = true;
            
            //SpawnedWorldObjectsBagsDataTable.Constraints.Add(fKInstancedItemId);

            //instancedItems_scriptableItems_globalObject_fk.DeleteRule = Rule.SetNull;
            //instancedItems_scriptableItems_globalObject_fk.UpdateRule = Rule.Cascade;
            //instancedItems_scriptableItems_globalObject_fk.AcceptRejectRule = AcceptRejectRule.None;

            //ScriptableItemsDataTable.Constraints.Add("scriptableItems_primaryKey", _dataSet.Tables[ScriptableItemsTableName].Columns[(byte)ScriptableItemsColumns.globalObject], true);
            //InstancedItemsDataTable.Constraints.Add("instancedItems_primaryKey", _dataSet.Tables[InstancedItemsTableName].Columns[(byte)InstancedItemsColumns.globalObject], true);
            
            
            var instancedItems_scriptableItems_globalObject_fk = new ForeignKeyConstraint("instancedItems_scriptableItems_globalObject_fk", 
                ScriptableItemsDataTable.Columns[(byte)ScriptableItemsColumns.globalObject],
                InstancedItemsDataTable.Columns[(byte)InstancedItemsColumns.globalObject])
            {
                DeleteRule = Rule.None,
                AcceptRejectRule = AcceptRejectRule.None,
            };
            
            InstancedItemsDataTable.Constraints.Add(instancedItems_scriptableItems_globalObject_fk);
            
            
            
            var FK_charactersBags_instancedItems = new ForeignKeyConstraint("FK_charactersBags_instancedItems",
                InstancedItemsDataTable.Columns[(byte)InstancedItemsColumns.instancedItemId], 
                SpawnedWorldObjectsBagsDataTable.Columns[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId]);
            SpawnedWorldObjectsBagsDataTable.Constraints.Add(FK_charactersBags_instancedItems);
        
            // var spawnedWorldObjectsInventory_UQ_2 = new UniqueConstraint("spawnedWorldObjectsInventory_UQ_2",
            // new []
            // {
            //     SpawnedWorldObjectsInventoryDataTable.Columns[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId],
            //     SpawnedWorldObjectsInventoryDataTable.Columns[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag]   
            // });
            // SpawnedWorldObjectsInventoryDataTable.Constraints.Add(spawnedWorldObjectsInventory_UQ_2);
            
            var spawnedWorldObjects_spawnerLocations_locationId_fk = 
                new ForeignKeyConstraint("spawnedWorldObjects_spawnerLocations_locationId_fk",
                    SpawnerLocationsDataTable.Columns[(byte)SpawnerLocationsColumns.locationId], 
                    SpawnedWorldObjectsDataTable.Columns[(byte)SpawnedWorldObjectsColumns.locationId]);
            SpawnedWorldObjectsDataTable.Constraints.Add(spawnedWorldObjects_spawnerLocations_locationId_fk);
            
            var spawnedEntities_spawnedWorldObjects_spawnedWorldObjectId_fk = 
                new ForeignKeyConstraint("spawnedEntities_spawnedWorldObjects_spawnedWorldObjectId_fk",
                SpawnedWorldObjectsDataTable.Columns[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId], 
                SpawnedEntitiesDataTable.Columns[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId]);
            SpawnedEntitiesDataTable.Constraints.Add(spawnedEntities_spawnedWorldObjects_spawnedWorldObjectId_fk);
            
            var spawnedInteractables_spawnedWorldObjects_spawnedWorldObjectId_fk = 
                new ForeignKeyConstraint("spawnedInteractables_spawnedWorldObjects_spawnedWorldObjectId_fk",
                    SpawnedWorldObjectsDataTable.Columns[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId], 
                    SpawnedInteractablesDataTable.Columns[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId]);
            SpawnedInteractablesDataTable.Constraints.Add(spawnedInteractables_spawnedWorldObjects_spawnedWorldObjectId_fk);
            
            var spawnedEnemyHumanoids_spawnedEntities_spawnedWorldObjectId_fk = new ForeignKeyConstraint("spawnedEnemyHumanoids_spawnedEntities_spawnedWorldObjectId_fk",
                SpawnedEntitiesDataTable.Columns[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId], 
                SpawnedEnemyHumanoidsDataTable.Columns[(byte)SpawnedEnemyHumanoidsColumns.spawnedWorldObjectId]);
            SpawnedEnemyHumanoidsDataTable.Constraints.Add(spawnedEnemyHumanoids_spawnedEntities_spawnedWorldObjectId_fk);
        }

        private void Time(Action action)
        {
            #if PROFILING
            var watch = Stopwatch.StartNew();
            watch.Restart();
            #endif
            
            action();
            
            #if PROFILING
            Debug.LogFormat("DataTables.{0} took {1} ms", action.Method.Name, watch.ElapsedTicks/10000f);
            watch.Stop();
            #endif
        }
       
        private DataTable FillTable(DataSet dataset, string tableName)
        {
            DataTable dtTempTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection  = (Connection as RebirthConnection)!.Connection;
                command.CommandType = CommandType.Text;
                command.CommandText = $"SELECT * FROM {tableName}";
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.FillSchema(dtTempTable, SchemaType.Source);
                    dataAdapter.Fill(dtTempTable);
                    //Debug.Log($"{tableName}: {dtTempTable.Rows.Count} records");
                }
            }
            
            dataset.Tables.Add(dtTempTable);
            return dtTempTable;
        }
        private DataTable FillTableUsingStoredProcedure(DataSet dataset, string storedProcedure)
        {
            DataTable dtTempTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection  = (Connection as RebirthConnection)!.Connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    //dataAdapter.FillSchema(dtTempTable, SchemaType.Source);
                    dataAdapter.Fill(dtTempTable);
                }
            }
            
            dataset.Tables.Add(dtTempTable);
            return dtTempTable;
        }
        
        
        private void FillDictionaries()
        {
            CharactersDictionaryByCharacterId = CharactersDataTable.ToDictionary<int>(CharactersColumns.characterId.ToString(), 
            CharactersColumns.status.ToString(), "active"); 
            CharactersDictionaryByPlayerAccountId = CharactersDataTable.ToDictionary_NestedList<int>( CharactersColumns.playerAccountId.ToString());
            
            CharactersDictionaryByCharacterName = CharactersDataTable.ToDictionary<string>( CharactersColumns.characterName.ToString(), 
            CharactersColumns.status.ToString(), "active");
            CharactersDictionaryBySpawnedWorldObjectId = CharactersDataTable.ToDictionary<Guid>( CharactersColumns.spawnedWorldObjectId.ToString());
            CharactersStatusEffectsDictionaryByCharacterIdByEffectGroupGlobalObject = CharactersStatusEffectsDataTable.ToDictionary<int, string>( CharactersStatusEffectsColumns.characterId.ToString(), CharactersStatusEffectsColumns.effectGroupGlobalObject.ToString());
            EffectsDictionary = EffectsDataTable.ToDictionary<string>(EffectsColumns.globalObject.ToString());
            EffectGroupsDictionary = EffectGroupsDataTable.ToDictionary<string>(EffectGroupsColumns.effectGroupGlobalObject.ToString());
            EffectsToEffectGroupsMappingDictionaryByEffectGlobalObjectCode = 
                EffectsToEffectGroupsMappingDataTable.ToDictionary<string, string>(EffectsToEffectGroupsMappingColumns.effectGlobalObject.ToString(),
                    EffectsToEffectGroupsMappingColumns.scriptableObjectLevel.ToString());
            
            EffectsToEffectGroupsMappingDictionaryByEffectGroupGlobalObjectCode = 
                EffectsToEffectGroupsMappingDataTable.ToDictionary<string, string>(EffectsToEffectGroupsMappingColumns.scriptableObjectLevel.ToString(),
                    EffectsToEffectGroupsMappingColumns.effectGlobalObject.ToString());
            
            EffectGroupsToObjectsMappingDictionary = EffectGroupsToObjectsMappingDataTable.ToDictionary<string, byte>(
                EffectGroupsToObjectsMappingColumns.scriptableObjectLevel.ToString(),
                EffectGroupsToObjectsMappingColumns.levelId.ToString());
            GlobalObjectsDictionary = GlobalObjectsDataTable.ToDictionary<string>(GlobalObjectsColumns.globalObject.ToString());
            
            InstancedEquipmentDictionary = InstancedEquipmentDataTable.ToDictionary<Guid>(InstancedEquipmentColumns.instancedItemId.ToString());
            InstancedItemsDictionaryByInstancedItemId = InstancedItemsDataTable.ToDictionary<Guid>(InstancedItemsColumns.instancedItemId.ToString());
            InstancedItemsDictionaryBySpawnedWorldObjectId = InstancedItemsDataTable.ToDictionary_NestedList<Guid>(InstancedItemsColumns.spawnedWorldObjectId.ToString());
            InstancedItemsIngredientsDictionaryByInstancedItemId = InstancedItemsIngredientsDataTable.ToDictionary_NestedList<Guid>(InstancedItemsIngredientsColumns.instancedItemId.ToString());

            PlayersAccountsDictionaryByUserName = PlayersAccountsDataTable.ToDictionary<string>(PlayersAccountsColumns.steamName.ToString());

            ScriptableObjectsDictionary = ScriptableObjectsDataTable.ToDictionary<string>(ScriptableObjectsColumns.globalObject.ToString());


            ScriptableAbilitiesRanksActivationCostsDictionary         = ScriptableAbilitiesRanksActivationCostsDataTable.ToDictionary_KeyKey_Nested<string, byte>(ScriptableAbilitiesLevelsActivationCostsColumns.globalObject.ToString(), ScriptableAbilitiesLevelsActivationCostsColumns.levelId.ToString());
            ScriptableArmorDictionary                                 = ScriptableArmorDataTable.ToDictionary<string>(ScriptableArmorColumns.globalObject.ToString());
            ScriptableEquipmentDictionary                             = ScriptableEquipmentDataTable.ToDictionary<string>(ScriptableEquipmentColumns.globalObject.ToString());
            //ScriptableEquipmentRequirementsDictionary                 = ScriptableEquipmentRequirementsDataTable.ToDictionary<string>(ScriptableEquipmentRequirementsColumns.globalObject.ToString());
            ScriptableEntitiesDictionary                              = ScriptableEntitiesDataTable.ToDictionary<string>(ScriptableEntitiesColumns.globalObject.ToString());
            ScriptableItemsDictionary                                 = ScriptableItemsDataTable.ToDictionary<string>(ScriptableItemsColumns.globalObject.ToString());
            ScriptableInteractablesDictionary                         = ScriptableInteractablesDataTable.ToDictionary<string>(ScriptableInteractablesColumns.globalObject.ToString());
            ScriptableLootTableDropsDictionaryByGlobalObjectCode      = ScriptableLootTableDropsDataTable.ToDictionary<string, string>(ScriptableLootTableDropsColumns.globalObject.ToString(), ScriptableLootTableDropsColumns.itemGlobalObject.ToString());
            ScriptableLootTableRaritiesDictionaryByGlobalObjectCode   = ScriptableLootTableRaritiesDataTable.ToDictionary<string,string,byte>(ScriptableLootTableRaritiesColumns.globalObject.ToString(),
                ScriptableLootTableRaritiesColumns.itemGlobalObject.ToString(), ScriptableLootTableRaritiesColumns.rarityId.ToString());
            
            ScriptableLootTableQuantitiesDictionaryByGlobalObjectCode =
                ScriptableLootTableQuantitiesDataTable.ToDictionary<string, string, byte>(
                    ScriptableLootTableQuantitiesColumns.globalObject.ToString(),
                    ScriptableLootTableQuantitiesColumns.itemGlobalObject.ToString(),
                    ScriptableLootTableQuantitiesColumns.quantity.ToString());

            ScriptableObjectRanksDictionaryByNestedObjectCode =
                ScriptableObjectRanksDataTable.ToDictionary<string, byte>(
                    ScriptableObjectRanksColumns.globalObject.ToString(),
                    ScriptableObjectRanksColumns.levelId.ToString());
            
            ScriptableObjectsSpawnablesDictionaryByNestedObjectCode =
                ScriptableObjectsSpawnablesDataTable.ToDictionary_NestedList<string>(
                    ScriptableObjectSpawnablesColumns.globalObject.ToString());

            
            ScriptableRecipesDictionaryByGlobalObject      = ScriptableRecipesDataTable.ToDictionary<string>(ScriptableRecipesColumns.globalObject.ToString());
            ScriptableRecipeIngredientsDictionaryByNestedObjectCode =
                ScriptableRecipeIngredientsDataTable.ToDictionary<string, string>(
                    ScriptableRecipeIngredientsColumns.globalObject.ToString(),
                    ScriptableRecipeIngredientsColumns.ingredientGlobalObject.ToString());

            ScriptableRequirementsDictionary                          = ScriptableRequirementsDataTable.ToDictionary<string, string>(ScriptableRequirementsColumns.requiredForGlobalObject.ToString(), ScriptableRequirementsColumns.requirementGlobalObject.ToString());
            ScriptableQuestsDictionary                                = ScriptableQuestsDataTable.ToDictionary<string>(ScriptableQuestsColumns.questGlobalObject.ToString());
            ScriptableQuestObjectivesDictionary                       = ScriptableQuestObjectivesDataTable.ToDictionary<string, string>(ScriptableQuestObjectivesColumns.questGlobalObject.ToString(), ScriptableQuestObjectivesColumns.objectiveGlobalObject.ToString());

            ScriptableSkillsDictionary                              = ScriptableSkillsDataTable.ToDictionary<string>(ScriptableSkillsColumns.globalObject.ToString());
            ScriptableTotalsDictionary                              = ScriptableTotalsDataTable.ToDictionary<string>(ScriptableTotalsColumns.totalGlobalObject.ToString());
            ScriptableVendorsDictionary                             = ScriptableVendorsDataTable.ToDictionary<string>(ScriptableVendorsColumns.globalObject.ToString());
            ScriptableWeaponsDictionary                             = ScriptableWeaponsDataTable.ToDictionary<string>(ScriptableWeaponsColumns.globalObject.ToString());
            ScriptableJeweleryDictionary                            = ScriptableJeweleryDataTable.ToDictionary<string>(ScriptableJewelryColumns.globalObject.ToString());
            ScriptableWorldObjectsDictionary                        = ScriptableWorldObjectsDataTable.ToDictionary<string>(ScriptableWorldObjectsColumns.globalObject.ToString());
            ScriptableContainersDictionary                          = ScriptableContainersDataTable.ToDictionary<string>(ScriptableContainersColumns.globalObject.ToString());

            SpawnedInteractablesDictionary                          = SpawnedInteractablesDataTable.ToDictionary<Guid>(SpawnedInteractablesColumns.spawnedWorldObjectId.ToString());
            SpawnedWorldObjectsDictionary                           = SpawnedWorldObjectsDataTable.ToDictionary<Guid>(SpawnedWorldObjectsColumns.spawnedWorldObjectId.ToString(), SpawnedWorldObjectsColumns.status.ToString(), "active");
            SpawnedWorldObjectsBagsDictionaryByCharacterBagId       = SpawnedWorldObjectsBagsDataTable.ToDictionary<int>(SpawnedWorldObjectsBagsColumns.characterBagId.ToString());
            SpawnedWorldObjectsCurrencyDictionary                   = SpawnedWorldObjectsCurrencyDataTable.ToDictionary<Guid>(SpawnedWorldObjectsCurrencyColumns.spawnedWorldObjectId.ToString());
            SpawnedWorldObjectsEquipmentDictionary                  = SpawnedWorldObjectsEquipmentDataTable.ToDictionary_NestedList<Guid>(SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId.ToString());
            SpawnedWorldObjectsInventoryDictionaryByInstancedItemId = SpawnedWorldObjectsInventoryDataTable.ToDictionary<Guid>(SpawnedWorldObjectsInventoryColumns.instancedItemId.ToString());

            StatEffectsDictionary = StatEffectsDataTable.ToDictionary<string>(StatEffectsColumns.statEffectGlobalObject.ToString());
            WorldObjectsRanksToLootTablesDictionaryByWorldObjectGlobalObjectCode = WorldObjectsRanksToLootTablesDataTable.ToDictionary<string, string>(SpawnablesToLootTablesColumns.globalObject.ToString(), SpawnablesToLootTablesColumns.scriptableObjectSpawnable.ToString());
            SpawnablesToPrefabsByWorldObjectGlobalObjectCode = SpawnablesToPrefabsDataTable.ToDictionary_KeyKeyKey_Nested<string, byte, byte>(SpawnablesToPrefabs.globalObject.ToString(), SpawnablesToPrefabs.levelId.ToString(), SpawnablesToPrefabs.variationId.ToString());
            DataAttributesToGlobalObjectsDictionaryByWorldObjectGlobalObjectCode = DataAttributesToGlobalObjectsDataTable.ToDictionary<string>(DataAttributesToGlobalObjectsColumns.globalObject.ToString());
        }
        
        #endregion

        #region BUILD UPDATE AND INSERT SQL COMMANDS
       
        public void SetCharacterTablesSqlCommands()
        {
            //BUILD INSERT SQL COMMANDS
            var sqlColumns = GetListSqlTableColumns(PlayersAccountsDataTable.TableName);
            var sqlInsertCommandText = BuildInsertSqlStatement_Identity(PlayersAccountsDataTable.TableName, sqlColumns);
            _playersAccountsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            var sqlUpdateCommandText = BuildUpdateSqlStatement(PlayersAccountsDataTable.TableName, sqlColumns);
            _playersAccountsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersDataTable.TableName, sqlColumns);
            _charactersTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersDataTable.TableName, sqlColumns);
            _charactersTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersAbilitiesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersAbilitiesDataTable.TableName, sqlColumns);
            _charactersAbilitiesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersAbilitiesDataTable.TableName, sqlColumns);
            _charactersAbilitiesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersAchievementsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersAchievementsDataTable.TableName, sqlColumns);
            _charactersAchievementsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersAchievementsDataTable.TableName, sqlColumns);
            _charactersAchievementsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersBuyBacksDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersBuyBacksDataTable.TableName, sqlColumns);
            _charactersBuyBacksTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersBuyBacksDataTable.TableName, sqlColumns);
            _charactersBuyBacksTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(CharactersMailDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(CharactersMailDataTable.TableName, sqlColumns);
            _charactersMailTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersMailDataTable.TableName, sqlColumns);
            _charactersMailTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(CharactersMailAttachmentsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersMailAttachmentsDataTable.TableName, sqlColumns);
            _charactersMailAttachmentsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersMailAttachmentsDataTable.TableName, sqlColumns);
            _charactersMailAttachmentsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(CharactersMissionsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersMissionsDataTable.TableName, sqlColumns);
            _charactersMissionsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersMissionsDataTable.TableName, sqlColumns);
            _charactersMissionsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(CharactersQuestsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersQuestsDataTable.TableName, sqlColumns);
            _charactersQuestsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersQuestsDataTable.TableName, sqlColumns);
            _charactersQuestsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersQuestsObjectivesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersQuestsObjectivesDataTable.TableName, sqlColumns);
            _charactersQuestsObjectivesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersQuestsObjectivesDataTable.TableName, sqlColumns);
            _charactersQuestsObjectivesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(CharactersRecipesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersRecipesDataTable.TableName, sqlColumns);
            _charactersRecipesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersRecipesDataTable.TableName, sqlColumns);
            _charactersRecipesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersSkillsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersSkillsDataTable.TableName, sqlColumns);
            _charactersSkillsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersSkillsDataTable.TableName, sqlColumns);
            _charactersSkillsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersSocialDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersSocialDataTable.TableName, sqlColumns);
            _charactersSocialTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersSocialDataTable.TableName, sqlColumns);
            _charactersSocialTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersStatsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersStatsDataTable.TableName, sqlColumns);
            _charactersStatsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersStatsDataTable.TableName, sqlColumns);
            _charactersStatsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(CharactersStatusEffectsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(CharactersStatusEffectsDataTable.TableName, sqlColumns);
            _charactersStatusEffectsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersStatusEffectsDataTable.TableName, sqlColumns);
            _charactersStatusEffectsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);

            sqlColumns = GetListSqlTableColumns(CharactersTitlesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(CharactersTitlesDataTable.TableName, sqlColumns);
            _charactersTitlesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(CharactersTitlesDataTable.TableName, sqlColumns);
            _charactersTitlesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedMissionsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(InstancedMissionsDataTable.TableName, sqlColumns);
            InstancedMissionsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedMissionsDataTable.TableName, sqlColumns);
            InstancedMissionsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
        }

        private void SetHistoryTablesSqlCommands()
        {
            //BUILD INSERT SQL COMMANDS
            var sqlColumns = GetListSqlTableColumns(HistoryCharacterKillsDataTable.TableName);
            var sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCharacterKillsDataTable.TableName, sqlColumns);
            _historyCharacterKillsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            var sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCharacterKillsDataTable.TableName, sqlColumns);
            _historyCharacterKillsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(HistoryCurrencyTransactionsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCurrencyTransactionsDataTable.TableName, sqlColumns);
            _historyCurrencyTransactionsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCurrencyTransactionsDataTable.TableName, sqlColumns);
            _historyCurrencyTransactionsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(HistoryCharacterCollectedDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCharacterCollectedDataTable.TableName, sqlColumns);
            _historyCharacterCollectedTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCharacterCollectedDataTable.TableName, sqlColumns);
            _historyCharacterCollectedTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(HistoryCharacterGatheredDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCharacterGatheredDataTable.TableName, sqlColumns);
            _historyCharacterGatheredTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCharacterGatheredDataTable.TableName, sqlColumns);
            _historyCharacterGatheredTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(HistoryCharacterCraftedDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCharacterCraftedDataTable.TableName, sqlColumns);
            _historyCharacterCraftedTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCharacterCraftedDataTable.TableName, sqlColumns);
            _historyCharacterCraftedTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(HistoryCharacterKillsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(HistoryCharacterKillsDataTable.TableName, sqlColumns);
            _historyCharacterKillsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(HistoryCharacterKillsDataTable.TableName, sqlColumns);
            _historyCharacterKillsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
        }

       private void SetInstancedItemsTablesSqlCommands()
        {
            //BUILD INSERT SQL COMMANDS
            var sqlColumns = GetListSqlTableColumns(InstancedAmmunitionDataTable.TableName);
            var sqlInsertCommandText = BuildInsertSqlStatement_Identity(InstancedAmmunitionDataTable.TableName, sqlColumns);
            _instancedAmmunitionTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            var sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedAmmunitionDataTable.TableName, sqlColumns);
            _instancedAmmunitionTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedArmorDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedArmorDataTable.TableName, sqlColumns);
            InstancedArmorTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedArmorDataTable.TableName, sqlColumns);
            InstancedArmorTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedBagsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedBagsDataTable.TableName, sqlColumns);
            InstancedBagsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedBagsDataTable.TableName, sqlColumns);
            InstancedBagsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(InstancedConsumablesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedConsumablesDataTable.TableName, sqlColumns);
            InstancedConsumablesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedConsumablesDataTable.TableName, sqlColumns);
            InstancedConsumablesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedEquipmentDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedEquipmentDataTable.TableName, sqlColumns);
            _instancedEquipmentTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedEquipmentDataTable.TableName, sqlColumns);
            _instancedEquipmentTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedGeneralItemsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedGeneralItemsDataTable.TableName, sqlColumns);
            _instancedGeneralItemsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedGeneralItemsDataTable.TableName, sqlColumns);
            _instancedGeneralItemsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedItemsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedItemsDataTable.TableName, sqlColumns);
            _instancedItemsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedItemsDataTable.TableName, sqlColumns);
            _instancedItemsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedItemsIngredientsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedItemsIngredientsDataTable.TableName, sqlColumns);
            InstancedItemsIngredientsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedItemsIngredientsDataTable.TableName, sqlColumns);
            InstancedItemsIngredientsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedMaterialsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedMaterialsDataTable.TableName, sqlColumns);
            InstancedMaterialsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedMaterialsDataTable.TableName, sqlColumns);
            InstancedMaterialsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(InstancedWeaponsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(InstancedWeaponsDataTable.TableName, sqlColumns);
            InstancedWeaponsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(InstancedWeaponsDataTable.TableName, sqlColumns);
            InstancedWeaponsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
        }

       private void SetSpawnedWorldObjectsTablesSqlCommands()
        {
            //BUILD INSERT SQL COMMANDS
            var sqlColumns = GetListSqlTableColumns(SpawnedAnimalsDataTable.TableName);
            var sqlInsertCommandText = BuildInsertSqlStatement(SpawnedAnimalsDataTable.TableName, sqlColumns);
            _spawnedAnimalsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            var sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedAnimalsDataTable.TableName, sqlColumns);
            _spawnedAnimalsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedContainersDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedContainersDataTable.TableName, sqlColumns);
            _spawnedContainersTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedContainersDataTable.TableName, sqlColumns);
            _spawnedContainersTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedEnemyHumanoidsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedEnemyHumanoidsDataTable.TableName, sqlColumns);
            _spawnedEnemyHumanoidsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedEnemyHumanoidsDataTable.TableName, sqlColumns);
            _spawnedEnemyHumanoidsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedEntitiesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedEntitiesDataTable.TableName, sqlColumns);
            _spawnedEntitiesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedEntitiesDataTable.TableName, sqlColumns);
            _spawnedEntitiesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedGatherablesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedGatherablesDataTable.TableName, sqlColumns);
            _spawnedGatherablesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedGatherablesDataTable.TableName, sqlColumns);
            _spawnedGatherablesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedInteractablesDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedInteractablesDataTable.TableName, sqlColumns);
            _spawnedInteractablesTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedInteractablesDataTable.TableName, sqlColumns);
            _spawnedInteractablesTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedMonstersDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedMonstersDataTable.TableName, sqlColumns);
            _spawnedMonstersTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedMonstersDataTable.TableName, sqlColumns);
            _spawnedMonstersTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedNpcsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedNpcsDataTable.TableName, sqlColumns);
            _spawnedNpcsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedNpcsDataTable.TableName, sqlColumns);
            _spawnedNpcsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedVendorInventoryDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnedVendorInventoryDataTable.TableName, sqlColumns);
            _spawnedVendorInventoryTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedVendorInventoryDataTable.TableName, sqlColumns);
            _spawnedVendorInventoryTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
           
            sqlColumns = GetListSqlTableColumns(SpawnedVendorsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedVendorsDataTable.TableName, sqlColumns);
            _spawnedVendorsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedVendorsDataTable.TableName, sqlColumns);
            _spawnedVendorsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnedWorldObjectsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement(SpawnedWorldObjectsDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnedWorldObjectsBagsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnedWorldObjectsBagsDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsBagsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            //sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsBagsDataTable.TableName, sqlColumns, "spawnedWorldObjectsBags_spawnedWorldObjectId_bagLocationId_uindex");
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsBagsDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsBagsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnedWorldObjectsCurrencyDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnedWorldObjectsCurrencyDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsCurrencyTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsCurrencyDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsCurrencyTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnedWorldObjectsEquipmentDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnedWorldObjectsEquipmentDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsEquipmentTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsEquipmentDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsEquipmentTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnedWorldObjectsInventoryDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnedWorldObjectsInventoryDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsInventoryTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnedWorldObjectsInventoryDataTable.TableName, sqlColumns);
            _spawnedWorldObjectsInventoryTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);
            
            sqlColumns = GetListSqlTableColumns(SpawnerLocationsDataTable.TableName);
            sqlInsertCommandText = BuildInsertSqlStatement_Identity(SpawnerLocationsDataTable.TableName, sqlColumns);
            _spawnerLocationsTableInsert = SqlCommandAddParameters(sqlInsertCommandText, sqlColumns);
            sqlUpdateCommandText = BuildUpdateSqlStatement(SpawnerLocationsDataTable.TableName, sqlColumns);
            _spawnerLocationsTableUpdate = SqlCommandAddParameters(sqlUpdateCommandText, sqlColumns);

        }
       
        private List<SqlData> GetListSqlTableColumns(string tblName)
        {
            List<SqlData> sqlColumns = new List<SqlData>();

            //Query
            var query = $"SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tblName}'";

            using (var cmd = new SqlCommand(query, (Connection as RebirthConnection)!.Connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.Log($"reader[0]:{reader[0]}, reader[1]:{reader[1]}, reader[2]:{reader[2]}, reader[3]:{reader[3]}, reader[4]:{reader[4]}");

                        var columnName = (string) reader[0];
                        var dataType = (string) reader[1];
                        var characterMaximumLength = 0;
                        if (reader[2] != DBNull.Value) characterMaximumLength = (int)reader[2];
                            
                        byte numericPrecision = 0;
                        if (reader[3] != DBNull.Value) numericPrecision = (byte)reader[3];
                        
                        byte numericScale = 0;
                        if (reader[4] != DBNull.Value) numericScale = (byte)(int)reader[4];
                        //Debug.Log($"{columnName},{dataType},{characterMaximumLength},{numericPrecision},{numericScale}");
                        sqlColumns.Add(new SqlData()
                        {
                            ColumnName = columnName,
                            DataType = dataType,
                            MAXLength = characterMaximumLength,
                            NumberPrecision = numericPrecision,
                            Scale = numericScale,
                        });
                  



                    }
                }
            }
            return sqlColumns;
        }

        private string BuildInsertSqlStatement(string tblName, List<SqlData> sqlColumns, bool skipFirstValue=false)
        {
            
            string insertStringTest = $"Insert into [dbo].[{tblName}](";
            bool skipSecondValue = skipFirstValue;
            int firstName = 0;
            foreach (var sqlData in sqlColumns)
            {
                if (!skipFirstValue)
                {
                    if (firstName == 0) insertStringTest = $"{insertStringTest}[{sqlData.ColumnName}]";
                    else insertStringTest = $"{insertStringTest},[{sqlData.ColumnName}]";
                    firstName += 1;
                }
                skipFirstValue = false;
            }

            insertStringTest = $"{insertStringTest}) values (";
            firstName = 0;
            foreach (var sqlData in sqlColumns)
            {
                if (!skipFirstValue)
                {
                    if (firstName == 0) insertStringTest = $"{insertStringTest}@{sqlData.ColumnName}";
                    else insertStringTest = $"{insertStringTest}, @{sqlData.ColumnName}";
                    firstName += 1;
                }
                skipSecondValue = false;
            }

            insertStringTest = $"{insertStringTest})";
            return insertStringTest;
        }
       
        private string BuildInsertSqlStatement_Identity(string tblName, List<SqlData> sqlColumns)
        {
            string insertStringTest = $"SET IDENTITY_INSERT [dbo].[{tblName}] ON\n";
            insertStringTest += $"Insert into [dbo].[{tblName}](";

            int firstName = 0;
            foreach (var sqlData in sqlColumns)
            {
                   
                if (firstName == 0) insertStringTest += $"{sqlData.ColumnName}";
                else insertStringTest += $",{sqlData.ColumnName}";
                firstName += 1;
            }

            insertStringTest += ") values (";
            firstName = 0;
            foreach (var sqlData in sqlColumns)
            {
                if (firstName == 0) insertStringTest = $"{insertStringTest}@{sqlData.ColumnName}";
                else insertStringTest = $"{insertStringTest}, @{sqlData.ColumnName}";
                firstName += 1;
            }

            insertStringTest += ")\n";
            insertStringTest += $"SET IDENTITY_INSERT [dbo].[{tblName}] OFF";
            return insertStringTest;
        }
        
        private string BuildUpdateSqlStatement(string tblName, List<SqlData> sqlColumns, string ignoreConstraintName = null)
        {


            //string updateStringExample = @"UPDATE [dbo].[charactersStats] SET characterId = @characterId, characterStatTypeId = @characterStatTypeId, characterStatStatusId = @characterStatStatusId, characterStatTierId = @characterStatTierId, characterStatValue = @characterStatValue, 
            //characterStatValue = @characterStatValue, characterStatDescription = @characterStatDescription, characterStatIconId = @characterStatIconId, statId = @statId, characterStat = @characterStat, lastUpdate = @lastUpdate)";

            string                         updateString = "";
            if (ignoreConstraintName != null)
                updateString += $@"INDEX {ignoreConstraintName} ON {tblName} DISABLE;
";

            updateString += $"UPDATE [dbo].[{tblName}] SET ";

            int firstName = 0;
            int index = 0;
            foreach (var sqlData in sqlColumns)
            {
                if (index == 0)
                {
                    index++;
                    continue;
                }
                
                var columnName = sqlData.ColumnName;
                if (firstName == 0) updateString += $"{columnName} = @{columnName}";
                else updateString += $", {columnName} = @{columnName}";
                firstName += 1;
            }
            updateString += $" WHERE {sqlColumns[0].ColumnName   } = @{sqlColumns[0].ColumnName}";

            if (ignoreConstraintName != null) updateString += $@"
INDEX {ignoreConstraintName} ON {tblName} DISABLE";
            return updateString;
            
        }
        private SqlCommand SqlCommandAddParameters2(string insertString, List<SqlData> sqlColumns)
        {
            SqlCommand insertCommand = new SqlCommand(insertString);


            foreach (var sqlData in sqlColumns)
            {
                string columnName = sqlData.ColumnName;
                string dataType = sqlData.DataType;
                int characterMaximumLength = sqlData.MAXLength;
                int numericPrecision = sqlData.NumberPrecision;
                int numericScale = sqlData.Scale;

                switch (dataType)
                {
                    case ("uniqueidentifier"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.UniqueIdentifier, characterMaximumLength, $"{columnName}");
                        break;
                    case ("varchar"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.VarChar, characterMaximumLength, $"{columnName}");
                        break;
                    case ("int"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.Int, characterMaximumLength, $"{columnName}");
                        break;
                    case ("smallint"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.SmallInt, characterMaximumLength, $"{columnName}");
                        break;
                    case ("tinyint"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.TinyInt, characterMaximumLength, $"{columnName}");
                        break;
                    case ("bit"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.Bit, characterMaximumLength, $"{columnName}");
                        break;
                    case ("decimal"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.Decimal, characterMaximumLength, $"{columnName}");
                        break;
                    case ("datetime"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.DateTime, characterMaximumLength, $"{columnName}");
                        break;
                    case ("smalldatetime"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.SmallDateTime, characterMaximumLength, $"{columnName}");
                        break;
                    case ("char"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.Char, characterMaximumLength, $"{columnName}");
                        break;
                    case ("bigint"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.BigInt, characterMaximumLength, $"{columnName}");
                        break;
                    case ("float"):
                        insertCommand.Parameters.Add($"@{columnName}", SqlDbType.Float, characterMaximumLength, $"{columnName}");
                        break;
                                            
                    default:
                        Logger.LogError($"UNMAPPED DATA_TYPE: {dataType}");
                        break;
                }
            }
            return insertCommand;
        }
        
        private SqlCommand SqlCommandAddParameters(string insertString, List<SqlData> sqlColumns, bool skipFirst = false)
        {
            SqlCommand insertCommand = new SqlCommand(insertString);


            if (skipFirst)
            {
                for (int i = 1; i < sqlColumns.Count; i++)
                {
                    var sqlData = sqlColumns[i];
                    string columnName = sqlData.ColumnName;
                    string dataType = sqlData.DataType;
                    int characterMaximumLength = sqlData.MAXLength;
                    byte numericPrecision = sqlData.NumberPrecision;
                    byte numericScale = sqlData.Scale;

                    var parameter = insertCommand.CreateParameter();
                    switch (dataType)
                    {
                        case ("uniqueidentifier"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.UniqueIdentifier;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("varchar"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.VarChar;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("int"):        
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Int;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("smallint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.SmallInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("tinyint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.TinyInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("bit"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Bit;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("decimal"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Decimal;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("datetime"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.DateTime;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("smalldatetime"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.SmallDateTime;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("char"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Char;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("bigint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.BigInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("float"):
                           parameter.ParameterName = $"@{columnName}";
                           parameter.SqlDbType = SqlDbType.Float;
                           parameter.Size = characterMaximumLength;
                           parameter.Precision = numericPrecision;
                           parameter.Scale = numericScale;
                           parameter.SourceColumn = columnName;
                           insertCommand.Parameters.Add(parameter);
                           break;     
                        default:
                            Logger.LogError($"UNMAPPED DATA_TYPE: {dataType}");
                            break;
                    }
                }
            }
            else
            {
                foreach (var sqlData in sqlColumns)
                {
                    string columnName = sqlData.ColumnName;
                    string dataType = sqlData.DataType;
                    int characterMaximumLength = sqlData.MAXLength;
                    byte numericPrecision = sqlData.NumberPrecision;
                    byte numericScale = sqlData.Scale;

                    var parameter = insertCommand.CreateParameter();
                    switch (dataType)
                    {
                        case ("uniqueidentifier"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.UniqueIdentifier;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("varchar"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.VarChar;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("int"):        
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Int;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("smallint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.SmallInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("tinyint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.TinyInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("bit"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Bit;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("decimal"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Decimal;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("datetime"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.DateTime;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("smalldatetime"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.SmallDateTime;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("char"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.Char;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("bigint"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType = SqlDbType.BigInt;
                            parameter.Size = characterMaximumLength;
                            parameter.Precision = numericPrecision;
                            parameter.Scale = numericScale;
                            parameter.SourceColumn = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        case ("float"):
                            parameter.ParameterName = $"@{columnName}";
                            parameter.SqlDbType     = SqlDbType.Float;
                            parameter.Size          = characterMaximumLength;
                            parameter.Precision     = numericPrecision;
                            parameter.Scale         = numericScale;
                            parameter.SourceColumn  = columnName;
                            insertCommand.Parameters.Add(parameter);
                            break;
                        default:
                            Logger.LogError($"UNMAPPED DATA_TYPE: {dataType}");
                            break;
                    }
                }
            }
            return insertCommand;
        }

        
        #endregion
       
        #region BATCH DELETE, UPDATE, INSERT
        //MUST BE DONE IN ORDER, DELETE, UPDATE, INSERT

        private const string ConnectionString = @"Data Source=192.168.2.197,1445\ELYSIUM;User id=SA;Password=PoliceBox21;Initial Catalog=Elysium_DEV";
        private IDbConnection _connection;

        public IDbConnection Connection
        {
            get
            {
                return _connection ??= new RebirthConnection(Logger, ConnectionString);
            }
            
        }

        public DataTables(ILogger logger)
        {
            Logger = logger;
            DataTableExtensions.Logger = logger;
            _connection = new RebirthConnection(Logger, ConnectionString);
        }
        
        private void ProcessUpdates()
        { 
            BatchUpdate(PlayersAccountsDataTable, _playersAccountsTableUpdate, 1);

            BatchInsert(SpawnerLocationsDataTable, _spawnerLocationsTableInsert, 1);
            BatchUpdate(SpawnedWorldObjectsDataTable, _spawnedWorldObjectsTableUpdate, 1);
            BatchUpdate(SpawnedEntitiesDataTable, _spawnedEntitiesTableUpdate, 1);

            BatchUpdate(CharactersDataTable, _charactersTableUpdate, 1);
            
            BatchUpdate(CharactersAbilitiesDataTable, _charactersAbilitiesTableUpdate, 1);
            
            BatchUpdate(CharactersAchievementsDataTable, _charactersAchievementsTableUpdate, 1);
            BatchUpdate(CharactersBuyBacksDataTable, _charactersBuyBacksTableUpdate, 1);
            BatchUpdate(CharactersMailDataTable, _charactersMailTableUpdate, 1);
            BatchUpdate(CharactersMailAttachmentsDataTable, _charactersMailAttachmentsTableUpdate, 1);
            BatchUpdate(CharactersMissionsDataTable, _charactersMissionsTableUpdate, 1);
            BatchUpdate(CharactersQuestsDataTable, _charactersQuestsTableUpdate, 1);
            BatchUpdate(CharactersQuestsObjectivesDataTable, _charactersQuestsObjectivesTableUpdate, 1);
            BatchUpdate(CharactersRecipesDataTable, _charactersRecipesTableUpdate, 1);
            BatchUpdate(CharactersSkillsDataTable, _charactersSkillsTableUpdate, 1);
            BatchUpdate(CharactersSocialDataTable, _charactersSocialTableUpdate, 1);
            BatchUpdate(CharactersStatsDataTable, _charactersStatsTableUpdate, 1);
            BatchUpdate(CharactersStatusEffectsDataTable, _charactersStatusEffectsTableUpdate, 1);
            BatchUpdate(CharactersTitlesDataTable, _charactersTitlesTableUpdate, 1);
            BatchUpdate(InstancedMissionsDataTable, InstancedMissionsTableUpdate, 1);
            BatchUpdate(SpawnedInteractablesDataTable, _spawnedInteractablesTableUpdate, 1);
            BatchUpdate(SpawnedAnimalsDataTable, _spawnedAnimalsTableUpdate, 1);
            BatchUpdate(SpawnedContainersDataTable, _spawnedContainersTableUpdate, 1);
            BatchUpdate(SpawnedEnemyHumanoidsDataTable, _spawnedEnemyHumanoidsTableUpdate, 1);
            BatchUpdate(SpawnedGatherablesDataTable, _spawnedGatherablesTableUpdate, 1);
            BatchUpdate(SpawnedMonstersDataTable, _spawnedMonstersTableUpdate, 1);
            BatchUpdate(SpawnedNpcsDataTable, _spawnedNpcsTableUpdate, 1);
            BatchUpdate(SpawnedVendorsDataTable, _spawnedVendorsTableUpdate, 1);
            
            BatchUpdate(InstancedItemsDataTable, _instancedItemsTableUpdate, 1);
            BatchUpdate(InstancedEquipmentDataTable, _instancedEquipmentTableUpdate, 1);
            BatchUpdate(InstancedAmmunitionDataTable, _instancedAmmunitionTableUpdate, 1);
            BatchUpdate(InstancedArmorDataTable, InstancedArmorTableUpdate, 1);
            BatchUpdate(InstancedBagsDataTable, InstancedBagsTableUpdate, 1);
            BatchUpdate(InstancedConsumablesDataTable, InstancedConsumablesTableUpdate, 1);
            BatchUpdate(InstancedGeneralItemsDataTable, _instancedGeneralItemsTableUpdate, 1);
            BatchUpdate(InstancedItemsIngredientsDataTable, InstancedItemsIngredientsTableUpdate, 1);
            BatchUpdate(InstancedMaterialsDataTable, InstancedMaterialsTableUpdate, 1);
            BatchUpdate(InstancedWeaponsDataTable, InstancedWeaponsTableUpdate, 1);
            BatchUpdate(SpawnedVendorInventoryDataTable, _spawnedVendorInventoryTableUpdate, 1);
            BatchUpdate(SpawnedWorldObjectsBagsDataTable, _spawnedWorldObjectsBagsTableUpdate, 1);
            BatchUpdate(SpawnedWorldObjectsInventoryDataTable, _spawnedWorldObjectsInventoryTableUpdate, 1);
            BatchUpdate(SpawnedWorldObjectsEquipmentDataTable, _spawnedWorldObjectsEquipmentTableUpdate, 1);
            BatchUpdate(SpawnedWorldObjectsCurrencyDataTable, _spawnedWorldObjectsCurrencyTableUpdate, 1);
            
            BatchUpdate(HistoryCharacterCollectedDataTable, _historyCharacterCollectedTableUpdate,1);
            BatchUpdate(HistoryCharacterCraftedDataTable, _historyCharacterCraftedTableUpdate,1);
            BatchUpdate(HistoryCharacterGatheredDataTable, _historyCharacterGatheredTableUpdate,1);
            BatchUpdate(HistoryCharacterKillsDataTable, _historyCharacterKillsTableUpdate,1);
            BatchUpdate(HistoryCurrencyTransactionsDataTable, _historyCurrencyTransactionsTableUpdate,1);
            BatchUpdate(SpawnerLocationsDataTable, _spawnerLocationsTableUpdate, 1);
        }
        
        public void ProcessInserts()
        {
            BatchInsert(PlayersAccountsDataTable, _playersAccountsTableInsert, 1);
            
            
            BatchInsert(SpawnedWorldObjectsDataTable, _spawnedWorldObjectsTableInsert, 1);

            
            BatchInsert(CharactersDataTable, _charactersTableInsert, 1);
            
            
            BatchInsert(CharactersAbilitiesDataTable, _charactersAbilitiesTableInsert, 1);
            
            
            BatchInsert(CharactersAchievementsDataTable, _charactersAchievementsTableInsert, 1);
            
            
            BatchInsert(CharactersBuyBacksDataTable, _charactersBuyBacksTableInsert, 1);
            
            
            BatchInsert(CharactersMailDataTable, _charactersMailTableInsert, 1);
            
            
            BatchInsert(CharactersMailAttachmentsDataTable, _charactersMailAttachmentsTableInsert, 1);

            
            BatchInsert(CharactersMissionsDataTable, _charactersMissionsTableInsert, 1);
            
            
            BatchInsert(CharactersQuestsDataTable, _charactersQuestsTableInsert, 1);
            
            
            BatchInsert(CharactersQuestsObjectivesDataTable, _charactersQuestsObjectivesTableInsert, 1);
            
            
            BatchInsert(CharactersRecipesDataTable, _charactersRecipesTableInsert, 1);
            
            
            BatchInsert(CharactersSkillsDataTable, _charactersSkillsTableInsert, 1);
            
            
            BatchInsert(CharactersSocialDataTable, _charactersSocialTableInsert, 1);
            
            
            BatchInsert(CharactersStatsDataTable, _charactersStatsTableInsert, 1);
            
            BatchInsert(CharactersStatusEffectsDataTable, _charactersStatusEffectsTableInsert, 1);

            BatchInsert(CharactersTitlesDataTable, _charactersTitlesTableInsert, 1);
            
            

            BatchInsert(InstancedMissionsDataTable, InstancedMissionsTableInsert, 1);
            
            //#2: SPAWNED WORLD OBJECTS TABLES
            
            
    BatchInsert(SpawnedInteractablesDataTable, _spawnedInteractablesTableInsert, 1);
            
            
                    BatchInsert(SpawnedEntitiesDataTable, _spawnedEntitiesTableInsert, 1);
              BatchInsert(SpawnedAnimalsDataTable, _spawnedAnimalsTableInsert, 1);
            
            
            BatchInsert(SpawnedContainersDataTable, _spawnedContainersTableInsert, 1);
            
            
            BatchInsert(SpawnedEnemyHumanoidsDataTable, _spawnedEnemyHumanoidsTableInsert, 1);
            
            
            BatchInsert(SpawnedGatherablesDataTable, _spawnedGatherablesTableInsert, 1);
            
            
            BatchInsert(SpawnedMonstersDataTable, _spawnedMonstersTableInsert, 1);
            
            
            BatchInsert(SpawnedNpcsDataTable, _spawnedNpcsTableInsert, 1);
            
            
            BatchInsert(SpawnedVendorsDataTable, _spawnedVendorsTableInsert, 1);
            
            //#3: INSTANCED ITEMS
            
            BatchInsert(InstancedItemsDataTable, _instancedItemsTableInsert, 1);
            
            
        
            BatchInsert(InstancedEquipmentDataTable, _instancedEquipmentTableInsert, 1);
                    
            
            BatchInsert(InstancedAmmunitionDataTable, _instancedAmmunitionTableInsert, 1);
            
            
            BatchInsert(InstancedArmorDataTable, InstancedArmorTableInsert, 1);

            BatchInsert(InstancedBagsDataTable, InstancedBagsTableInsert, 1);

            BatchInsert(InstancedConsumablesDataTable, InstancedConsumablesTableInsert, 1);

            BatchInsert(InstancedGeneralItemsDataTable, _instancedGeneralItemsTableInsert, 1);

            BatchInsert(InstancedItemsIngredientsDataTable, InstancedItemsIngredientsTableInsert, 1);

            BatchInsert(InstancedMaterialsDataTable, InstancedMaterialsTableInsert, 1);

            BatchInsert(InstancedWeaponsDataTable, InstancedWeaponsTableInsert, 1);
            
            //#4: SPAWNED ITEMS
            BatchInsert(SpawnedVendorInventoryDataTable, _spawnedVendorInventoryTableInsert, 1);

            BatchInsert(SpawnedWorldObjectsBagsDataTable, _spawnedWorldObjectsBagsTableInsert, 1);

            BatchInsert(SpawnedWorldObjectsInventoryDataTable, _spawnedWorldObjectsInventoryTableInsert, 1);

            BatchInsert(SpawnedWorldObjectsEquipmentDataTable, _spawnedWorldObjectsEquipmentTableInsert, 1);

            BatchInsert(SpawnedWorldObjectsCurrencyDataTable, _spawnedWorldObjectsCurrencyTableInsert, 1);

            BatchInsert(HistoryCharacterCollectedDataTable, _historyCharacterCollectedTableInsert, 1);

            BatchInsert(HistoryCharacterCraftedDataTable, _historyCharacterCraftedTableInsert, 1);

            BatchInsert(HistoryCharacterGatheredDataTable, _historyCharacterGatheredTableInsert, 1);

            BatchInsert(HistoryCharacterKillsDataTable, _historyCharacterKillsTableInsert, 1);

            BatchInsert(HistoryCurrencyTransactionsDataTable, _historyCurrencyTransactionsTableInsert, 1);

        }
        
        public void ProcessSqlUpdates()
        {
            //SQL UPDATES
            //MUST PROCESS IN THE ORDER OF DELETES, UPDATES, INSERTS
            //WILL UPDATE ALL CHANGES SINCE LAST TIME YOU RAN THIS
            //#1: CHARACTERS TABLES
            
            ProcessUpdates();
            ProcessInserts();
        }
       
       
        private void BatchDelete(DataTable table, SqlCommand deleteCommand, int batchSize)
        {
            deleteCommand.Connection = (Connection as RebirthConnection)!.Connection;
            // When setting UpdateBatchSize to a value other than 1, all the commands
            // associated with the SqlDataAdapter have to have their UpdatedRowSource
            // property set to None or OutputParameters. An exception is thrown otherwise.
            deleteCommand.UpdatedRowSource = UpdateRowSource.None;
            
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.DeleteCommand = deleteCommand;
                // Gets or sets the number of rows that are processed in each round-trip to the server.
                // Setting it to 1 disables batch updates, as rows are sent one at a time.
                adapter.UpdateBatchSize = batchSize;

                // First process deletes
                adapter.Update(table.Select(null, null, DataViewRowState.Deleted));

                Logger.Log($"Successfully deleted records from {table.TableName}");
            }
        }

        private void BatchUpdate(DataTable table, SqlCommand updateCommand, int batchSize)
        {

            try
            {
                DataRow[] dataRows = table.Select("", "", DataViewRowState.ModifiedCurrent);

                if(dataRows.Length == 0) return;
                Logger.Log(updateCommand.CommandText);

                if (table.HasErrors)
                {
                    Logger.Log($"Failed to update {dataRows.Length} records for {table.TableName} - {table.HasErrors}");
                    foreach (var row in table.GetErrors())
                    {
                        Logger.LogError($"ERROR: {row.HasErrors}, {row.RowError}, {row.RowState}");
                    }
                    //return;
                }
                
                updateCommand.Connection = (Connection as RebirthConnection)!.Connection;
                // When setting UpdateBatchSize to a value other than 1, all the commands
                // associated with the SqlDataAdapter have to have their UpdatedRowSource
                // property set to None or OutputParameters. An exception is thrown otherwise.
                updateCommand.UpdatedRowSource = UpdateRowSource.None;
                
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.UpdateCommand = updateCommand;
                    // Gets or sets the number of rows that are processed in each round-trip to the server.
                    // Setting it to 1 disables batch updates, as rows are sent one at a time.
                    adapter.UpdateBatchSize = batchSize;
                    // Next process updates.
                    var transaction = (Connection as RebirthConnection)!.Connection.BeginTransaction();
                    adapter.UpdateCommand.Transaction = transaction;
                    try
                    {
                        adapter.Update(dataRows);
                        transaction.Commit();
                        Logger.Log($"Successfully updated {dataRows.Length} records for {table.TableName}");
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Logger.Log($"Failed to update {dataRows.Length} records for {table.TableName} - {table.HasErrors}");
                        foreach (var row in table.GetErrors())
                        {
                            if (table.TableName == "spawnedWorldObjectBags")
                                Logger.LogError(row[(byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId] + ", " +
                                                row[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId]);
                            Logger.LogError($"ERROR: {row.HasErrors}, {row.RowError}, {row.RowState}");
                        }

                        Logger.LogError($"BatchUpdate({table.TableName}) Transaction Failed, Rolling back. Exception: " +
                                        e.Message);
                        throw;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                
            }
        }
        
        private void BatchUpdate_Insert(DataTable table, SqlCommand updateCommand, SqlCommand insertCommand, int batchSize)
        {
            var dataRows = table.Select("", "", DataViewRowState.ModifiedCurrent);
            if(dataRows.Length == 0) return;
            
            updateCommand.Connection = (Connection as RebirthConnection)!.Connection;
            // When setting UpdateBatchSize to a value other than 1, all the commands
            // associated with the SqlDataAdapter have to have their UpdatedRowSource
            // property set to None or OutputParameters. An exception is thrown otherwise.
            updateCommand.UpdatedRowSource = UpdateRowSource.None;

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.UpdateCommand = updateCommand;
                adapter.InsertCommand = insertCommand;
                // Gets or sets the number of rows that are processed in each round-trip to the server.
                // Setting it to 1 disables batch updates, as rows are sent one at a time.
                adapter.UpdateBatchSize = batchSize;
                // Next process updates.

                var transaction = (Connection as RebirthConnection)!.Connection.BeginTransaction();
                adapter.UpdateCommand.Transaction = transaction;
                try
                {
                    adapter.Update(table);
                    transaction.Commit();
                    Logger.Log($"Successfully updated {dataRows.Length} records for {table.TableName}");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Logger.LogError($"BatchUpdate/Insert({table.TableName}) Transaction Failed, Exception: " + e.Message);
                }
            }
        }

        private void BatchInsert(DataTable table, SqlCommand insertCommand, int batchSize)
        {
            var dataRows = table.Select(null, null, DataViewRowState.Added);
            if(dataRows.Length == 0) return;

            insertCommand.Connection = (Connection as RebirthConnection)!.Connection;
            // When setting UpdateBatchSize to a value other than 1, all the commands
            // associated with the SqlDataAdapter have to have their UpdatedRowSource
            // property set to None or OutputParameters. An exception is thrown otherwise.
            insertCommand.UpdatedRowSource = UpdateRowSource.None;

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.InsertCommand = insertCommand;
                // Gets or sets the number of rows that are processed in each round-trip to the server.
                // Setting it to 1 disables batch updates, as rows are sent one at a time.
                // Finally, process inserts.
                adapter.UpdateBatchSize = batchSize;

                var transaction = (Connection as RebirthConnection)!.Connection.BeginTransaction();
                adapter.InsertCommand.Transaction = transaction;
                try
                {
                    adapter.Update(dataRows);
                    transaction.Commit();
                    #if SQL_LOGGING
                    Logger.Log($"Successfully inserted {dataRows.Length} records for {table.TableName}");
                    #endif
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Logger.LogError($"BatchInsert({table.TableName}) Transaction Failed, Exception: " + e.Message);
                    foreach (var row in table.GetErrors())
                    {
                        if (table.TableName == "spawnedEntities")
                        {
                            Logger.LogError(row[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId] + ", " + (byte)row[(byte)SpawnedEntitiesColumns.entityTypeId]);
                        }
                        //Logger.LogError(row[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId)] + ", " + row[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId)]);
                        Logger.LogError($"{row.HasErrors}, {row.RowError}, {row.RowState}");
                    }
                }
            }
        }
       

        #endregion
       
        private struct SqlData
        {
            public string ColumnName;
            public string DataType;
            public int MAXLength;
            public byte NumberPrecision;
            public byte Scale;

        }

        private SqlConnection CreateConnection(string connectionString)
        {
            var t = new SqlConnection(connectionString);
            t.Open();
            return t;
        }
        public void Init()
        {
            Time(() =>
            {
                Time(FillDataTablesFromSql);
                Time(FillDictionaries);
                //#2: SET SQL UPDATE AND INSERT STATEMENTS FOR ALL TABLES
                Time(SetCharacterTablesSqlCommands);
                Time(SetHistoryTablesSqlCommands);
                Time(SetInstancedItemsTablesSqlCommands);
                Time(SetSpawnedWorldObjectsTablesSqlCommands);

                //SetDefaultViewsCharacterTables();
                //SetDefaultViewsInstancedItemsTables();
                //SetDefaultViewsSpawnedTables();
                //SetDefaultViewsScriptableTables();
            });


            //LAST: PUSH ALL CHANGES TO SQL DATABASE
            //ProcessSqlUpdates(conString);
        }

        public void Dispose()
        {
            _dataSet.Dispose();
            
            PlayersAccountsDataTable.Dispose();
            _playersAccountsTableUpdate.Dispose();
            _playersAccountsTableInsert.Dispose();
            CharactersDataTable.Dispose();
            _charactersTableUpdate.Dispose();
            _charactersTableInsert.Dispose();
            CharactersAbilitiesDataTable.Dispose();
            _charactersAbilitiesTableUpdate.Dispose();
            _charactersAbilitiesTableInsert.Dispose();
            CharactersAchievementsDataTable.Dispose();
            _charactersAchievementsTableUpdate.Dispose();
            _charactersAchievementsTableInsert.Dispose();
            CharactersBuyBacksDataTable.Dispose();
            _charactersBuyBacksTableUpdate.Dispose();
            _charactersBuyBacksTableInsert.Dispose();
            CharactersMailDataTable.Dispose();
            _charactersMailTableUpdate.Dispose();
            _charactersMailTableInsert.Dispose();
            CharactersMailAttachmentsDataTable.Dispose();
            _charactersMailAttachmentsTableUpdate.Dispose();
            _charactersMailAttachmentsTableInsert.Dispose();
            CharactersMissionsDataTable.Dispose();
            _charactersMissionsTableUpdate.Dispose();
            _charactersMissionsTableInsert.Dispose();
            CharactersQuestsDataTable.Dispose();
            _charactersQuestsTableUpdate.Dispose();
            _charactersQuestsTableInsert.Dispose();
            CharactersQuestsObjectivesDataTable.Dispose();
            _charactersQuestsObjectivesTableUpdate.Dispose();
            _charactersQuestsObjectivesTableInsert.Dispose();
            CharactersRecipesDataTable.Dispose();
            _charactersRecipesTableUpdate.Dispose();
            _charactersRecipesTableInsert.Dispose();
            CharactersSkillsDataTable.Dispose();
            _charactersSkillsTableUpdate.Dispose();
            _charactersSkillsTableInsert.Dispose();
            CharactersSocialDataTable.Dispose();
            _charactersSocialTableUpdate.Dispose();
            _charactersSocialTableInsert.Dispose();
            CharactersStatsDataTable.Dispose();
            _charactersStatsTableUpdate.Dispose();
            _charactersStatsTableInsert.Dispose();
            CharactersTitlesDataTable.Dispose();
            _charactersTitlesTableUpdate.Dispose();
            _charactersTitlesTableInsert.Dispose();
            HistoryCharacterCollectedDataTable.Dispose();
            _historyCharacterCollectedTableUpdate.Dispose();
            _historyCharacterCollectedTableInsert.Dispose();
            HistoryCharacterCombatDataTable.Dispose();
            _historyCharacterCombatTableUpdate.Dispose();
            _historyCharacterCombatTableInsert.Dispose();
            HistoryCharacterCraftedDataTable.Dispose();
            _historyCharacterCraftedTableUpdate.Dispose();
            _historyCharacterCraftedTableInsert.Dispose();
            HistoryCharacterDeathsDataTable.Dispose();
            _historyCharacterDeathsTableUpdate.Dispose();
            _historyCharacterDeathsTableInsert.Dispose();
            HistoryCharacterGatheredDataTable.Dispose();
            _historyCharacterGatheredTableUpdate.Dispose();
            _historyCharacterGatheredTableInsert.Dispose();
            HistoryCharacterKillsDataTable.Dispose();
            _historyCharacterKillsTableUpdate.Dispose();
            _historyCharacterKillsTableInsert.Dispose();
            HistoryCharacterLootDataTable.Dispose();
            _historyCharacterLootTableUpdate.Dispose();
            _historyCharacterLootTableInsert.Dispose();
            HistoryCharacterQuestsDataTable.Dispose();
            HistoryCharacterQuestsTableUpdate.Dispose();
            HistoryCharacterQuestsTableInsert.Dispose();
            HistoryCurrencyTransactionsDataTable.Dispose();
            _historyCurrencyTransactionsTableUpdate.Dispose();
            _historyCurrencyTransactionsTableInsert.Dispose();
            InstancedAmmunitionDataTable.Dispose();
            _instancedAmmunitionTableUpdate.Dispose();
            _instancedAmmunitionTableInsert.Dispose();
            InstancedArmorDataTable.Dispose();
            InstancedArmorTableUpdate.Dispose();
            InstancedArmorTableInsert.Dispose();
            InstancedBagsDataTable.Dispose();
            InstancedBagsTableUpdate.Dispose();
            InstancedBagsTableInsert.Dispose();
            InstancedConsumablesDataTable.Dispose();
            InstancedConsumablesTableUpdate.Dispose();
            InstancedConsumablesTableInsert.Dispose();
            InstancedEquipmentDataTable.Dispose();
            _instancedEquipmentTableUpdate.Dispose();
            _instancedEquipmentTableInsert.Dispose();
            InstancedGeneralItemsDataTable.Dispose();
            _instancedGeneralItemsTableUpdate.Dispose();
            _instancedGeneralItemsTableInsert.Dispose();
            InstancedItemsDataTable.Dispose();
            _instancedItemsTableUpdate.Dispose();
            _instancedItemsTableInsert.Dispose();
            InstancedItemsIngredientsDataTable.Dispose();
            InstancedItemsIngredientsTableUpdate.Dispose();
            InstancedItemsIngredientsTableInsert.Dispose();
            InstancedMaterialsDataTable.Dispose();
            InstancedMaterialsTableUpdate.Dispose();
            InstancedMaterialsTableInsert.Dispose();
            InstancedMissionsDataTable.Dispose();
            InstancedMissionsTableUpdate.Dispose();
            InstancedMissionsTableInsert.Dispose();
            InstancedWeaponsDataTable.Dispose();
            InstancedWeaponsTableUpdate.Dispose();
            InstancedWeaponsTableInsert.Dispose();
            SpawnedAnimalsDataTable.Dispose();
            _spawnedAnimalsTableUpdate.Dispose();
            _spawnedAnimalsTableInsert.Dispose();
            SpawnedContainersDataTable.Dispose();
            _spawnedContainersTableUpdate.Dispose();
            _spawnedContainersTableInsert.Dispose();
            SpawnedEnemyHumanoidsDataTable.Dispose();
            _spawnedEnemyHumanoidsTableUpdate.Dispose();
            _spawnedEnemyHumanoidsTableInsert.Dispose();
            SpawnedEntitiesDataTable.Dispose();
            _spawnedEntitiesTableUpdate.Dispose();
            _spawnedEntitiesTableInsert.Dispose();
            SpawnedGatherablesDataTable.Dispose();
            _spawnedGatherablesTableUpdate.Dispose();
            _spawnedGatherablesTableInsert.Dispose();
            SpawnedInteractablesDataTable.Dispose();
            _spawnedInteractablesTableUpdate.Dispose();
            _spawnedInteractablesTableInsert.Dispose();
            SpawnedMonstersDataTable.Dispose();
            _spawnedMonstersTableUpdate.Dispose();
            _spawnedMonstersTableInsert.Dispose();
            SpawnedNpcsDataTable.Dispose();
            _spawnedNpcsTableUpdate.Dispose();
            _spawnedNpcsTableInsert.Dispose();
            SpawnedVendorInventoryDataTable.Dispose();
            _spawnedVendorInventoryTableUpdate.Dispose();
            _spawnedVendorInventoryTableInsert.Dispose();
            SpawnedVendorsDataTable.Dispose();
            _spawnedVendorsTableUpdate.Dispose();
            _spawnedVendorsTableInsert.Dispose();
            SpawnedWorldObjectsDataTable.Dispose();
            _spawnedWorldObjectsTableUpdate.Dispose();
            _spawnedWorldObjectsTableInsert.Dispose();
            SpawnedWorldObjectsBagsDataTable.Dispose();
            _spawnedWorldObjectsBagsTableUpdate.Dispose();
            _spawnedWorldObjectsBagsTableInsert.Dispose();
            SpawnedWorldObjectsCurrencyDataTable.Dispose();
            _spawnedWorldObjectsCurrencyTableUpdate.Dispose();
            _spawnedWorldObjectsCurrencyTableInsert.Dispose();
            SpawnedWorldObjectsEquipmentDataTable.Dispose();
            _spawnedWorldObjectsEquipmentTableUpdate.Dispose();
            _spawnedWorldObjectsEquipmentTableInsert.Dispose();
            SpawnedWorldObjectsInventoryDataTable.Dispose();
            _spawnedWorldObjectsInventoryTableUpdate.Dispose();
            _spawnedWorldObjectsInventoryTableInsert.Dispose();
            SpawnerLocationsDataTable.Dispose();
            _spawnerLocationsTableUpdate.Dispose();
            _spawnerLocationsTableInsert.Dispose();
            AbilityTypesDataTable.Dispose();
            AbilityEffectTypesDataTable.Dispose();
            ArmorTypesDataTable.Dispose();
            AdventuringQuestTypesDataTable.Dispose();
            AnimalTypesDataTable.Dispose();
            AnimalClassificationTypesDataTable.Dispose();
            AnimalSubTypesDataTable.Dispose();
            BagTypesDataTable.Dispose();
            BagClassificationTypesDataTable.Dispose();
            BagSubTypesDataTable.Dispose();
            ConsumableTypesDataTable.Dispose();
            ConsumableClassificationTypesDataTable.Dispose();
            ConsumableSubTypesDataTable.Dispose();
            ContainerTypesDataTable.Dispose();
            CostTypesDataTable.Dispose();
            CraftingQuestTypesDataTable.Dispose();
            ElementalTypesDataTable.Dispose();
            EffectTypesDataTable.Dispose();
            AbilityActivationTypesDataTable.Dispose();
            EntityTypesDataTable.Dispose();
            EnemyHumanoidTypesDataTable.Dispose();
            EnemyHumanoidClassificationTypesDataTable.Dispose();
            EnemyHumanoidSubTypesDataTable.Dispose();
            MonsterTypesDataTable.Dispose();
            MonsterClassificationTypesDataTable.Dispose();
            MonsterSubTypesDataTable.Dispose();
            GeneralItemTypesDataTable.Dispose();
            GeneralItemClassificationTypesDataTable.Dispose();
            GeneralItemSubTypesDataTable.Dispose();
            AwardEffectTypesDataTable.Dispose();
            ArmorSlotTypesDataTable.Dispose();
            EquipmentTypesDataTable.Dispose();
            EquipmentSlotTypesDataTable.Dispose();
            ExperienceEffectTypesDataTable.Dispose();
            GatherableTypesDataTable.Dispose();
            GatherableClassificationTypesDataTable.Dispose();
            GatherableSubTypesDataTable.Dispose();
            GatheringQuestTypesDataTable.Dispose();
            RequirementTypesDataTable.Dispose();
            GlobalObjectTypesDataTable.Dispose();
            InteractableTypesDataTable.Dispose();
            ItemSubTypesDataTable.Dispose();
            ItemTypesDataTable.Dispose();
            JeweleryTypesDataTable.Dispose();
            LootTableTypesDataTable.Dispose();
            LootTableMainTypesDataTable.Dispose();
            MaterialTypesDataTable.Dispose();
            MaterialClassificationTypesDataTable.Dispose();
            MaterialSubTypesDataTable.Dispose();
            ModifierTypesDataTable.Dispose();
            NpcTypesDataTable.Dispose();
            QuestCategoryTypesDataTable.Dispose();
            QuestObjectiveTypesDataTable.Dispose();
            SkillTypesDataTable.Dispose();
            UnlockEffectTypesDataTable.Dispose();
            WeaponTypesDataTable.Dispose();
            WeaponSlotTypesDataTable.Dispose();
            WorldObjectTypesDataTable.Dispose();
            AbilityDifficultyTiersDataTable.Dispose();
            AwardEffectsDataTable.Dispose();
            AbilityRanksToObjectRanksMappingDataTable.Dispose();
            AttributePointsDataTable.Dispose();
            BodyPartPathsDataTable.Dispose();
            BodyPartMultipliersDataTable.Dispose();
            CharacterCreationOptionsDataTable.Dispose();
            EffectsDataTable.Dispose();
            EffectGroupsDataTable.Dispose();
            EffectGroupsToItemsMappingDataTable.Dispose();
            EffectGroupsToObjectsMappingDataTable.Dispose();
            EffectsToEffectGroupsMappingDataTable.Dispose();
            EntityStatsDataTable.Dispose();
            ExperienceEffectsDataTable.Dispose();
            GlobalObjectsDataTable.Dispose();
            GlobalStatusesDataTable.Dispose();
            GlobalTiersDataTable.Dispose();
            IconsDataTable.Dispose();
            LastUpdatedTablesDataTable.Dispose();
            LevelRequirementsDataTable.Dispose();
            LevelRequirementsAbilitiesDataTable.Dispose();
            LevelRequirementsSkillsDataTable.Dispose();
            PrefabsDataTable.Dispose();
            SkillDifficultyTiersDataTable.Dispose();
            StatEffectsDataTable.Dispose();
            StatsDataTable.Dispose();
            StatTypesDataTable.Dispose();
            UnlockEffectsDataTable.Dispose();
            WeaponsPositionsDataTable.Dispose();
            WorldObjectsRanksToLootTablesDataTable.Dispose();
            //MissionObjectivesDataTable.Dispose();
            ScriptableAbilitiesDataTable.Dispose();
            ScriptableAbilitiesRanksDataTable.Dispose();
            ScriptableAbilitiesRanksActivationCostsDataTable.Dispose();
            ScriptableAchievementsDataTable.Dispose();
            ScriptableAnimalsDataTable.Dispose();
            ScriptableArmorDataTable.Dispose();
            ScriptableBagsDataTable.Dispose();
            ScriptableConsumablesDataTable.Dispose();
            ScriptableContainersDataTable.Dispose();
            ScriptableEnemyHumanoidsDataTable.Dispose();
            ScriptableEquipmentDataTable.Dispose();
            ScriptableEquipmentRequirementsDataTable.Dispose();
            ScriptableEntitiesDataTable.Dispose();
            ScriptableGatherablesDataTable.Dispose();
            ScriptableGeneralItemsDataTable.Dispose();
            ScriptableInteractablesDataTable.Dispose();
            ScriptableItemsDataTable.Dispose();
            ScriptableJeweleryDataTable.Dispose();
            ScriptableLootTablesDataTable.Dispose();
            ScriptableLootTablesToLootTableDataTable.Dispose();
            ScriptableLootTableDropsDataTable.Dispose();
            ScriptableLootTableRaritiesDataTable.Dispose();
            ScriptableLootTableQuantitiesDataTable.Dispose();
            ScriptableMaterialsDataTable.Dispose();
            ScriptableMaterialModifiersDataTable.Dispose();
            ScriptableMilestonesDataTable.Dispose();
            ScriptableMonstersDataTable.Dispose();
            ScriptableNpcsDataTable.Dispose();
            ScriptableObjectsDataTable.Dispose();
            ScriptableObjectTypesDataTable.Dispose();
            ScriptableObjectRanksDataTable.Dispose();
            ScriptableQuestsDataTable.Dispose();
            ScriptableQuestlinesDataTable.Dispose();
            ScriptableQuestlineQuestOrderDataTable.Dispose();
            ScriptableQuestExclusionsDataTable.Dispose();
            ScriptableQuestObjectivesDataTable.Dispose();
            ScriptableRecipesDataTable.Dispose();
            ScriptableRequirementsDataTable.Dispose();
            ScriptableQualitiesDataTable.Dispose();
            ScriptableQualityModifiersDataTable.Dispose();
            ScriptableRaritiesDataTable.Dispose();
            ScriptableRarityModifiersDataTable.Dispose();
            ScriptableRecipeIngredientsDataTable.Dispose();
            ScriptableSkillsDataTable.Dispose();
            ScriptableSpawnTablesDataTable.Dispose();
            ScriptableSpawnTableOptionsDataTable.Dispose();
            ScriptableTitlesDataTable.Dispose();
            ScriptableTotalsDataTable.Dispose();
            ScriptableTotalsCraftDataTable.Dispose();
            ScriptableTotalsCollectDataTable.Dispose();
            ScriptableTotalsGatherDataTable.Dispose();
            ScriptableTotalsKillsDataTable.Dispose();
            ScriptableVendorsDataTable.Dispose();
            ScriptableVendorItemsDataTable.Dispose();
            ScriptableWeaponsDataTable.Dispose();
            ScriptableWorldObjectsDataTable.Dispose();
            
            Connection.Dispose();
        }
    }
}

//#endif