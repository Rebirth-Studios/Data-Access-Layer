    //#if SERVER

using System;
using System.Collections.Generic;
using System.Data;
using RebirthStudios.DataAccessLayer.Enums.TableColumns;

    namespace RebirthStudios.DataAccessLayer
{
    public class DataTableSelects
    {
        internal DataTables _dataTables;
        
        public DataTableSelects(DataTables dataTables, ILogger slogger)
        {
            _dataTables = dataTables;
        }
        
        #region DATA TABLE SELECT: CHARACTERS
        public List<DataRow> PlayersAccountsSelectRows(string userName, string password)
        {
            List<DataRow> rows = new List<DataRow>();
            if (userName == "")
            {
                foreach (var row in _dataTables.PlayersAccountsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.PlayersAccountsDataTable.Select($"{PlayersAccountsColumns.steamName}='{userName}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> PlayersAccountsSelectRows(string userName)
        {
            List<DataRow> rows = new List<DataRow>();
            if (userName == "")
            {
                foreach (var row in _dataTables.PlayersAccountsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.PlayersAccountsDataTable.Select($"{PlayersAccountsColumns.steamName}='{userName}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> CharacterCreationOptionsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.CharacterCreationOptionsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public DataRow CharactersSelectRows_BySpawnedWorldObjectId(Guid spawnedWorldObjectId)
        {
            if (!_dataTables.SpawnedWorldObjectsDictionary.ContainsKey(spawnedWorldObjectId)) throw new Exception("Character not found(CharactersSelectRows_BySpawnedWorldObjectId)");
            return _dataTables.CharactersDictionaryBySpawnedWorldObjectId[spawnedWorldObjectId];
        }

        public List<DataRow> CharactersSelectRows_ByPlayerAccountId(int? playerAccountId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (playerAccountId == null)
            {
                foreach (var row in _dataTables.CharactersDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersDataTable.Select($"{CharactersColumns.playerAccountId}='{playerAccountId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> CharactersAbilitiesSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersAbilitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersAbilitiesDataTable.Select($"{CharactersAbilitiesColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public DataRow CharactersAbilitiesSelectRows_ByGlobalObjectCode(int characterId, string globalObjectCode)
        {
            foreach (var cHA in _dataTables.CharactersAbilitiesDataTable.Select($"{CharactersAbilitiesColumns.characterId}={characterId} AND {CharactersAbilitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
            {
                return cHA;
            }
            throw new Exception("Failed to select Character Ability.");
        }

        public List<DataRow> CharactersBuybacksSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersBuyBacksDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersBuyBacksDataTable.Select($"{CharactersBuybacksColumns.characterId}='{characterId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> CharactersMailSelectRows(Guid? mailId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (mailId == null) 
            {
                foreach (var row in _dataTables.CharactersMailDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersMailDataTable.Select($"{CharactersMailColumns.charactersMailId}='{mailId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> CharactersMailAttachmentsSelectRows_GetAll()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.CharactersMailAttachmentsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> CharactersMailAttachmentsSelectRows(Guid mailId, byte slotIndex)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var item in _dataTables.CharactersMailAttachmentsDataTable.Select($"{CharactersMailAttachmentsColumns.charactersMailId}='{mailId}' AND {CharactersMailAttachmentsColumns.slotIndex}='{slotIndex}'", "", DataViewRowState.CurrentRows))
            {
                rows.Add(item);
            }
            return rows;
        }
        public List<DataRow> CharactersMissionsSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersMissionsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
                return rows;
            }
            else
            {
                foreach (var item in _dataTables.CharactersMissionsDataTable.Select($"{CharactersMissionsColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> CharactersRecipesSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersRecipesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
                return rows;
            }
            else
            {
                foreach (var item in _dataTables.CharactersRecipesDataTable.Select($"{CharactersRecipesColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> CharactersSocialSelectRows_BySocialCharacterId(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersSocialDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersSocialDataTable.Select($"{CharactersSocialColumns.socialCharacterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> CharactersSkillsSelectRows_ByCharacterId(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersSkillsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersSkillsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public DataRow? CharactersQuestsSelectRow(int characterId, string questGlobalObjectCode)     
        {
            foreach (var item in _dataTables.CharactersQuestsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId} AND {CharactersQuestsColumns.questGlobalObject}='{questGlobalObjectCode}'", "", DataViewRowState.CurrentRows))
            {
                return item;
            }
            return null;
        }
        public List<DataRow> CharactersQuestsSelectRows(int characterId, string? questGlobalObjectCode = null)     
        {
            List<DataRow> rows = new List<DataRow>();
            if (questGlobalObjectCode == null)
            {
                foreach (var item in _dataTables.CharactersQuestsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId}", "",
                             DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersQuestsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId} AND {CharactersQuestsColumns.questGlobalObject}='{questGlobalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            
            return rows;
        }
        public List<DataRow> CharactersQuestsObjectivesSelectRows(int? characterId, string? questGlobalObjectCode = null, string? objectiveGlobalObjectCode = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(questGlobalObjectCode))
            {
                foreach (var item in _dataTables.CharactersQuestsObjectivesDataTable.Select($"{CharactersQuestsObjectivesColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersQuestsObjectivesDataTable.Select($"{CharactersQuestsObjectivesColumns.characterId}={characterId} AND {CharactersQuestsObjectivesColumns.questGlobalObject}='{questGlobalObjectCode}' AND {CharactersQuestsObjectivesColumns.objectiveGlobalObject}='{objectiveGlobalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public DataRow CharactersSkillsSelectRow(int characterId, string globalObjectCode)
        {
            foreach (var item in _dataTables.CharactersSkillsDataTable.Select($"{CharactersSkillsColumns.characterId}={characterId} AND {CharactersSkillsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
            {
                return item;
            }

            throw new Exception("Failed to find Character Skill.");
        }
        public List<DataRow> CharactersStatsSelectRows_ByCharacterId(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.CharactersStatsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.CharactersStatsDataTable.Select($"{CharactersStatsColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> CharactersStatsSelectRows(int characterId, byte characterStatTypeId, byte statId)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var item in _dataTables.CharactersStatsDataTable.Select($"{CharactersStatsColumns.characterId}={characterId} AND {CharactersStatsColumns.characterStatTypeId}='{characterStatTypeId}' AND {CharactersStatsColumns.statId}='{statId}'", "", DataViewRowState.CurrentRows))
            {
                rows.Add(item);
            }
            return rows;
        }

        #endregion
        
        #region DATA TABLE SELECT: ENUMS

        public List<DataRow> AbilityTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AbilityTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> AbilityEffectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AbilityEffectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ArmorTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ArmorTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> AdventuringQuestTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AdventuringQuestTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ConsumableTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ConsumableTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ContainerTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ContainerTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> CostTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.CostTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> CraftingQuestTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.CraftingQuestTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> DamageTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ElementalTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> EffectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EffectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> EntityTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EntityTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public Dictionary<byte, DataRow> EntityTypesSelectRows_Dictionary()
        {
            Dictionary<byte, DataRow> rows = new Dictionary<byte, DataRow>();
            
                foreach (var eT in _dataTables.EntityTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((byte)eT[(byte)EntityTypesColumns.typeId],eT);
                }
            return rows;
        }
        public List<DataRow> EquipmentTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EquipmentTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ExperienceEffectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ExperienceEffectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> GatherableTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var gT in _dataTables.GatherableTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(gT);
            }
            return rows;
        }
        public List<DataRow> GatheringQuestTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var gQT in _dataTables.GatheringQuestTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(gQT);
            }
            return rows;

        }
        public List<DataRow> GlobalObjectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var gOT in _dataTables.GlobalObjectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(gOT);
            }
            return rows;

        }
        public List<DataRow> InteractableTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var iT in _dataTables.InteractableTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(iT);
            }
            return rows;
        }
        public Dictionary<byte, DataRow> InteractableTypesSelectRows_Dictionary()
        {
            Dictionary<byte, DataRow> rows = new Dictionary<byte, DataRow>();
            
            foreach (var iT in _dataTables.InteractableTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add((byte)iT[(byte)InteractableTypesColumns.typeId],iT);
            }
            return rows;
        }
        public List<DataRow> ItemSubTypesSelectRows(byte? itemSubTypeId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (itemSubTypeId == null)
            {
                foreach (var iST in _dataTables.ItemSubTypesDataTable.Select($"", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(iST);
                }

            }
            else
            {
                foreach (var iST in _dataTables.ItemSubTypesDataTable.Select($"{ItemSubTypesColumns.typeId}='{itemSubTypeId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(iST);
                }
            }
            return rows;

        }
        public List<DataRow> ItemTypesSelectRows(byte? itemTypeId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (itemTypeId == null)
            {
                foreach (var row in _dataTables.ItemTypesDataTable.Select($"", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }

            }
            else
            {
                foreach (var row in _dataTables.ItemTypesDataTable.Select($"{ItemTypesColumns.typeId}='{itemTypeId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            return rows;

        }
        public List<DataRow> LootTableTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.LootTableTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> LootTableSubTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.LootTableMainTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> MaterialTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.MaterialTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;

        }
        public List<DataRow> ModifierTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ModifierTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> NpcTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.NpcTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;

        }
        public List<DataRow> QuestObjectiveTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.QuestObjectiveTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> QuestCategoryTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.QuestCategoryTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ScriptableObjectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableObjectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ScriptableQualitiesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableQualitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ScriptableRaritiesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableRaritiesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> SkillTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.SkillTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> StatTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.StatTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> UnlockEffectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.UnlockEffectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        
        public List<DataRow> WeaponsSlotsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.WeaponSlotTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> WorldObjectTypesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.WorldObjectTypesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        #endregion
        
        #region DATA TABLE SELECT: HISTORY
          public List<DataRow> HistoryCharacterCollectedSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.HistoryCharacterCollectedDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterCollectedDataTable.Select($"{HistoryCharacterCollectedColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCharacterCombatSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.HistoryCharacterCombatDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterCombatDataTable.Select($"{HistoryCharacterCombatColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCharacterCraftedSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.HistoryCharacterCraftedDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterCraftedDataTable.Select($"{HistoryCharacterCraftedColumns.characterId}={characterId.Value}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> HistoryCharacterDeathsSelectRows(int characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == 0)
            {
                foreach (var row in _dataTables.HistoryCharacterDeathsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterDeathsDataTable.Select($"characterId={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
       
        public List<DataRow> HistoryCharacterGatheredSelectRows(int? characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == null)
            {
                foreach (var row in _dataTables.HistoryCharacterGatheredDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterGatheredDataTable.Select($"{HistoryCharacterGatheredColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCharacterKillsSelectRows(int characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == default)
            {
                foreach (var row in _dataTables.HistoryCharacterKillsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterKillsDataTable.Select($"{HistoryCharacterKillsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCharacterLootSelectRows(int characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == default)
            {
                foreach (var row in _dataTables.HistoryCharacterLootDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterLootDataTable.Select($"{HistoryCharacterLootColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCharacterQuestsSelectRows(int characterId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (characterId == default)
            {
                foreach (var row in _dataTables.HistoryCharacterQuestsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.HistoryCharacterQuestsDataTable.Select($"{HistoryCharacterQuestsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        
        public List<DataRow> HistoryCurrencyTransactionsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.HistoryCurrencyTransactionsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        #endregion
        
        #region DATA TABLE SELECT: INSTANCED

        public List<DataRow> InstancedArmorSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedArmorDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedArmorDataTable.Select($"{InstancedArmorColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedBagsSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedBagsDataTable.Select($"{InstancedBagsColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedBagsDataTable.Select($"{InstancedBagsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<Guid, DataRow> InstancedBagsSelectRows_Dictionary()
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            
                foreach (var iB in _dataTables.InstancedBagsDataTable.Select($"{InstancedBagsColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)iB[(byte)InstancedBagsColumns.instancedItemId],iB);
                }
                return rows;
        }
        public Dictionary<Guid, DataRow> InstancedBagsSelectRows_Dictionary(Guid? instancedItemId)
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            if (instancedItemId == null)
            {
                foreach (var iB in _dataTables.InstancedBagsDataTable.Select($"{InstancedBagsColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)iB[(byte)InstancedBagsColumns.instancedItemId], iB);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedBagsDataTable.Select($"{InstancedBagsColumns.instancedItemId}='{instancedItemId}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)item[(byte)InstancedBagsColumns.instancedItemId], item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedItemsSelectRows_BySpawnedWorldObjectId(Guid? instancedItemId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedItemsDataTable.Select($"{InstancedItemsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public Dictionary<Guid, DataRow> InstancedItemsSelectRows_ByInstancedItemId_Dictionary(Guid? instancedItemId = null)
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedItemsDataTable.Select("", $"{InstancedItemsColumns.instancedItemId}", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)row[(byte)InstancedItemsColumns.instancedItemId],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedItemsDataTable.Select($"{InstancedItemsColumns.instancedItemId}='{instancedItemId}'", $"{InstancedItemsColumns.instancedItemId}", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)item[(byte)InstancedItemsColumns.instancedItemId],item);
                }
            }

            return rows;
        }

        public List<DataRow> InstancedItemsSelectRows_ByInstancedItemId(Guid? instancedItemId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedItemsDataTable.Select($"{InstancedItemsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedConsumablesSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedConsumablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedConsumablesDataTable.Select($"{InstancedConsumablesColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedEquipmentSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedEquipmentDataTable.Select($"{InstancedEquipmentColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedEquipmentDataTable.Select($"{InstancedEquipmentColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedGeneralItemsSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedGeneralItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedGeneralItemsDataTable.Select($"{InstancedGeneralItemsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedItemsIngredientsSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedItemsIngredientsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedItemsIngredientsDataTable.Select($"{InstancedItemsIngredientsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> InstancedMaterialsSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedMaterialsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedMaterialsDataTable.Select($"{InstancedMaterialsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public Dictionary<Guid, DataRow> InstancedMaterialsSelectRows_ByInstancedItemIdId_Dictionary(Guid? instancedItemId = null)
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedMaterialsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)row[(byte)InstancedMaterialsColumns.instancedItemId],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedMaterialsDataTable.Select($"{InstancedMaterialsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)item[(byte)InstancedMaterialsColumns.instancedItemId],item);
                }
            }

            return rows;
        }
        
        public List<DataRow> InstancedWeaponsSelectRows(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.InstancedWeaponsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.InstancedWeaponsDataTable.Select($"{InstancedWeaponsColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        #endregion
        
        #region DATA TABLE SELECT: REFERENCE
        public List<DataRow> AbilityDifficultyTiersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AbilityDifficultyTiersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> AwardEffectsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AwardEffectsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> LevelRequirementsAbilitiesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.LevelRequirementsAbilitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> AbilityRanksToObjectRanksMappingSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AbilityRanksToObjectRanksMappingDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> AttributePointsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.AttributePointsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> BodyPartPathsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.BodyPartPathsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> BodyPartMultipliersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.BodyPartMultipliersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> EntityStatsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EntityStatsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> EffectsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EffectsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> EffectGroupsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EffectGroupsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public Dictionary<string, DataRow> EffectGroupsSelectRows_Dictionary()
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            foreach (var eG in _dataTables.EffectGroupsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add((string)eG[(byte)EffectGroupsColumns.effectGroupGlobalObject], eG);
            }
           
            return rows;
        }
        
        public List<DataRow> EffectGroupsToItemsMappingSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var eGTIM in _dataTables.EffectGroupsToItemsMappingDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(eGTIM);
            }
            return rows;
        }

        public List<DataRow> EffectsToEffectGroupsMappingSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EffectsToEffectGroupsMappingDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> EffectGroupsToObjectsMappingSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.EffectGroupsToObjectsMappingDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> ExperienceEffectsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ExperienceEffectsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> GlobalObjectsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                //Console.WriteLine("globalObjectCode == ''");
                foreach (var row in _dataTables.GlobalObjectsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var gO in _dataTables.GlobalObjectsDataTable.Select($"{GlobalObjectsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(gO);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> GlobalObjectsSelectRows_Dictionary(string globalObjectCode = default)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                //Console.WriteLine("globalObjectCode == ''");
                foreach (var row in _dataTables.GlobalObjectsDataTable.Select("", $"{GlobalObjectsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)GlobalObjectsColumns.globalObject], row);
                }
            }
            else
            {
                foreach (var item in _dataTables.GlobalObjectsDataTable.Select($"{GlobalObjectsColumns.globalObject}='{globalObjectCode}'", $"{GlobalObjectsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)GlobalObjectsColumns.globalObject], item);
                }
            }
            return rows;
        }

        public List<DataRow> IconsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.IconsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.IconsDataTable.Select($"{IconsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> IconsSelectRows_Dictionary(string globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.IconsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(new string((string)row[(byte)IconsColumns.globalObject]),row);
                }
            }
            else
            {
                foreach (var item in _dataTables.IconsDataTable.Select($"{IconsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(new string((string)item[(byte)IconsColumns.globalObject]),item);
                }
            }

            return rows;
        }
        public List<DataRow> LevelRequirementsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.LevelRequirementsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> LevelRequirementsSkillsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.LevelRequirementsSkillsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> PrefabsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.PrefabsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, List<DataRow>> PrefabsSelectRows_Dictionary(string globalObjectCode = default)
        {
            Dictionary<string, List<DataRow>> rows = new Dictionary<string, List<DataRow>>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.PrefabsDataTable.Select("", $"{PrefabsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    var globalObjectId = (string)row[(byte)PrefabsColumns.globalObject];
                    if(!rows.ContainsKey(globalObjectId)) rows.Add(globalObjectId, new List<DataRow>());
                    rows[globalObjectId].Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.PrefabsDataTable.Select($"{PrefabsColumns.globalObject}='{globalObjectCode}'", $"{PrefabsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    if(!rows.ContainsKey(globalObjectCode)) rows.Add(globalObjectCode, new List<DataRow>());
                    rows[globalObjectCode].Add(item);
                }
            }

            return rows;
        }

        public List<DataRow> SkillDifficultyTiersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.SkillDifficultyTiersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> StatsSelectRows(params uint[] statTypeIds)
        {
            List<DataRow> rows = new List<DataRow>();
            if (statTypeIds.Length == 0)
            {
                foreach (var row in _dataTables.StatsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var statTypeId in statTypeIds)
                {
                    foreach (var item in _dataTables.StatsDataTable.Select($"{StatsColumns.statTypeId}='{statTypeId}'"))
                    {
                        rows.Add(item);
                    }
                }
            }
            return rows;
        }

        public List<DataRow> StatEffectsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.StatEffectsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }


        public List<DataRow> UnlockEffectsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.UnlockEffectsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> WeaponsPositionsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.WeaponsPositionsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> WorldObjectsToLootTablesSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.WorldObjectsRanksToLootTablesDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public Dictionary<string, DataRow> WorldObjectsToLootTablesSelectRows_Dictionary()
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            foreach (var row in _dataTables.WorldObjectsRanksToLootTablesDataTable.Select("", SpawnablesToLootTablesColumns.globalObject.ToString(), DataViewRowState.CurrentRows))
            {
                rows.Add((string)row[(byte)SpawnablesToLootTablesColumns.globalObject],row);
            }
            return rows;
        }

        #endregion
        
        #region DATA TABLE SELECT: SCRIPTABLE
        public List<DataRow> ScriptableAbilitiesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAbilitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAbilitiesDataTable.Select($"{ScriptableAbilitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableAbilitiesSelectRows_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAbilitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableAbilitiesColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAbilitiesDataTable.Select($"{ScriptableAbilitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableAbilitiesColumns.globalObject],item);
                }
            }

            return rows;
        }
        public List<DataRow> ScriptableAbilitiesRanksSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAbilitiesRanksDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAbilitiesRanksDataTable.Select($"{ScriptableAbilitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableAbilitiesRanksActivationCostsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAbilitiesRanksActivationCostsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAbilitiesRanksActivationCostsDataTable.Select($"{ScriptableAbilitiesLevelsActivationCostsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableAnimalsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAnimalsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAnimalsDataTable.Select($"{ScriptableAnimalsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableAnimalsSelectRows_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableAnimalsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableAnimalsColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableAnimalsDataTable.Select($"{ScriptableAnimalsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableAnimalsColumns.globalObject],item);
                }
            }

            return rows;
        }
        public List<DataRow> ScriptableArmorSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableArmorDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableArmorDataTable.Select($"{ScriptableArmorColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableArmorSelectRows_Dictionary(string globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableArmorDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableArmorColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableArmorDataTable.Select($"{ScriptableArmorColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableArmorColumns.globalObject],item);
                }
            }

            return rows;
        }
        public List<DataRow> ScriptableBagsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableBagsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableBagsDataTable.Select($"{ScriptableBagsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableBagsSelectRows_Dictionary(string globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableBagsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableBagsColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableBagsDataTable.Select($"{ScriptableBagsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableBagsColumns.globalObject],item);
                }
            }

            return rows;
        }
        public List<DataRow> ScriptableConsumablesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableConsumablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableConsumablesDataTable.Select($"{ScriptableConsumablesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableContainersSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableContainersDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableContainersDataTable.Select($"{ScriptableContainersColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableEquipmentSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableEquipmentDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableEquipmentDataTable.Select($"{ScriptableEquipmentColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableEquipmentSelectRows_Dictionary(string globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableEquipmentDataTable.Select("", $"{ScriptableEquipmentColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableEquipmentColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableEquipmentDataTable.Select($"{ScriptableEquipmentColumns.globalObject}='{globalObjectCode}'", $"{ScriptableEquipmentColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableEquipmentColumns.globalObject],item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableEquipmentRequirementsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableEquipmentRequirementsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableEquipmentRequirementsDataTable.Select($"{ScriptableEquipmentRequirementsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableEntitiesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableEntitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableEntitiesDataTable.Select($"{ScriptableEntitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableEnemyHumanoidsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableEnemyHumanoidsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableEnemyHumanoidsDataTable.Select($"{ScriptableEnemyHumanoidsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableGatherablesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableGatherablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableGatherablesDataTable.Select($"{ScriptableGatherablesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableGeneralItemsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableGeneralItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableGeneralItemsDataTable.Select($"{ScriptableGeneralItemsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableInteractablesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableInteractablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableInteractablesDataTable.Select($"{ScriptableInteractablesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public DataRow ScriptableItemsSelectRow(string globalObjectCode)
        {
            
            foreach (var sI in _dataTables.ScriptableItemsDataTable.Select($"{ScriptableItemsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
            {
                return sI;
            }
            throw new Exception("Failed to Select Scriptable Item, No Row Found");
        }
        public List<DataRow> ScriptableItemsSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableItemsSelectRows_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableItemsDataTable.Select("", $"{ScriptableItemsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableItemsColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableItemsDataTable.Select($"{ScriptableItemsColumns.globalObject}='{globalObjectCode}'", $"{ScriptableItemsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableItemsColumns.globalObject],item);
                }
            }

            return rows;
        }
        public List<DataRow> ScriptableMaterialsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableMaterialsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableMaterialsDataTable.Select($"{ScriptableMaterialsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableMonstersSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableMonstersDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableMonstersDataTable.Select($"{ScriptableMonstersColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableNpcsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableNpcsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableNpcsDataTable.Select($"{ScriptableNpcsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableQuestsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableQuestsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableQuestsDataTable.Select($"{ScriptableQuestsColumns.questGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableQuestExclusionsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableQuestExclusionsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableQuestExclusionsDataTable.Select($"{ScriptableQuestExclusionsColumns.questGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableQuestlinesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableQuestlinesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableQuestlinesDataTable.Select($"{ScriptableQuestlinesColumns.questlineGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableQuestObjectivesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableQuestObjectivesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableQuestObjectivesDataTable.Select($"{ScriptableQuestObjectivesColumns.questGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableMaterialModifiersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableMaterialModifiersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ScriptableRecipesSelectRows(string globalObjectCode = "")
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableRecipesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableRecipesDataTable.Select($"{ScriptableRecipesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableRecipesSelectRows_ByProductGlobalObjectCode_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableRecipesDataTable.Select("", $"{ScriptableRecipesColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableRecipesColumns.productGlobalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableRecipesDataTable.Select($"{ScriptableRecipesColumns.productGlobalObject}='{globalObjectCode}'", $"{ScriptableRecipesColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableRecipesColumns.productGlobalObject],item);
                }
            }
            return rows;
        }

        public Dictionary<string, DataRow> ScriptableRecipesSelectRows_ByGlobalObjectCode_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableRecipesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableRecipesColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableRecipesDataTable.Select($"{ScriptableRecipesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableRecipesColumns.globalObject],item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableRecipeIngredientsSelectRows(string globalObjectCode = "")
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableRecipeIngredientsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableRecipeIngredientsDataTable.Select($"{ScriptableRecipeIngredientsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableRequirementsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableRequirementsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableRequirementsDataTable.Select($"{ScriptableRequirementsColumns.requirementGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public DataRow ScriptableSkillsSelectRow(string globalObjectCode)
        {
            foreach (var item in _dataTables.ScriptableSkillsDataTable.Select($"{ScriptableSkillsColumns.globalObject}='{globalObjectCode}'", ""))
            {
                return item;
            }
            throw new Exception("Failed to Select ScriptableSkill, no row found");
        }

        public List<DataRow> ScriptableSkillsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableSkillsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableSkillsDataTable.Select($"{ScriptableSkillsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableSkillsSelectRows_Dictionary(string? globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableSkillsDataTable.Select("", $"{ScriptableSkillsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableSkillsColumns.globalObject],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableSkillsDataTable.Select($"{ScriptableSkillsColumns.globalObject}='{globalObjectCode}'", $"{ScriptableSkillsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableSkillsColumns.globalObject],item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableWeaponsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableWeaponsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableWeaponsDataTable.Select($"{ScriptableWeaponsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableLootTablesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableLootTablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableLootTablesDataTable.Select($"{ScriptableLootTablesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableLootTablesToLootTableSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableLootTablesToLootTableDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableLootTablesToLootTableDataTable.Select($"{ScriptableLootTablesToLootTableColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableLootTableDropsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableLootTableDropsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableLootTableDropsDataTable.Select($"{ScriptableLootTableDropsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableLootTableRaritiesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableLootTableRaritiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableLootTableRaritiesDataTable.Select($"{ScriptableLootTableRaritiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableLootTableQuantitiesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableLootTableQuantitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableLootTableQuantitiesDataTable.Select($"{ScriptableLootTableQuantitiesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableObjectsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableObjectsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableObjectsDataTable.Select($"{ScriptableObjectsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public Dictionary<string, DataRow> ScriptableObjectsSelectRows_Dictionary(string globalObjectCode = null)
        {
            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableObjectsDataTable.Select("", $"{ScriptableObjectsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)row[(byte)ScriptableObjectsColumns.globalObject], row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableObjectsDataTable.Select($"{ScriptableObjectsColumns.globalObject}='{globalObjectCode}'", $"{ScriptableObjectsColumns.globalObject}", DataViewRowState.CurrentRows))
                {
                    rows.Add((string)item[(byte)ScriptableObjectsColumns.globalObject], item);
                }
            }
            return rows;
        }
        public List<DataRow> ScriptableQualityModifiersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableQualityModifiersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        
        public List<DataRow> ScriptableQuestlineQuestOrderSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableQuestlineQuestOrderDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> ScriptableRarityModifiersSelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.ScriptableRarityModifiersDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }

        public List<DataRow> ScriptableSpawnTablesSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableSpawnTablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableSpawnTablesDataTable.Select($"{ScriptableSpawnTablesColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> ScriptableSpawnTableOptionsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableSpawnTableOptionsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableSpawnTableOptionsDataTable.Select($"{ScriptableSpawnTableOptionsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> ScriptableVendorsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableVendorsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableVendorsDataTable.Select($"{ScriptableVendorsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> ScriptableVendorItemsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableVendorItemsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableVendorItemsDataTable.Select($"{ScriptableVendorItemsColumns.npcGlobalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public List<DataRow> ScriptableWorldObjectsSelectRows(string globalObjectCode)
        {
            List<DataRow> rows = new List<DataRow>();
            if (string.IsNullOrEmpty(globalObjectCode))
            {
                foreach (var row in _dataTables.ScriptableWorldObjectsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.ScriptableWorldObjectsDataTable.Select($"{ScriptableWorldObjectsColumns.globalObject}='{globalObjectCode}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

       
        #endregion
        
        #region DATA TABLE SELECT: SPAWNED

        public List<DataRow> SpawnedAnimalsSelectRows(Guid? spawnedWorldObjectId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedAnimalsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedAnimalsDataTable.Select($"{SpawnedAnimalsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public List<DataRow> SpawnedContainersSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedContainersDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedContainersDataTable.Select($"{SpawnedContainersColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public List<DataRow> SpawnedEntitiesSelectRows(Guid? spawnedWorldObjectId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedEntitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedEntitiesDataTable.Select($"{SpawnedEntitiesColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public Dictionary<int, DataRow> SpawnedEntitiesSelectRows_Dictionary(Guid? spawnedWorldObjectId = null)
        {
            Dictionary<int, DataRow> rows = new Dictionary<int, DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedEntitiesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((int)row[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedEntitiesDataTable.Select($"{SpawnedEntitiesColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((int)item[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId],item);
                }
            }

            return rows;
        }

        public List<DataRow> SpawnedEnemyHumanoidsSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedEnemyHumanoidsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedEnemyHumanoidsDataTable.Select($"{SpawnedEnemyHumanoidsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }

        public List<DataRow> SpawnedGatherablesSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedGatherablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedGatherablesDataTable.Select($"{SpawnedGatherablesColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }

        public List<DataRow> SpawnedInteractablesSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedInteractablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedInteractablesDataTable.Select($"{SpawnedInteractablesColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public Dictionary<Guid, DataRow> SpawnedInteractablesSelectRows_Dictionary(Guid? spawnedWorldObjectId = null)
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedInteractablesDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)row[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedInteractablesDataTable.Select($"{SpawnedInteractablesColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)item[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId],item);
                }
            }

            return rows;
        }
        public List<DataRow> SpawnedMonstersSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedMonstersDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedMonstersDataTable.Select($"{SpawnedMonstersColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public List<DataRow> SpawnedNpcsSelectRows(Guid? spawnedWorldObjectId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedNpcsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedNpcsDataTable.Select($"{SpawnedNPCsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'"))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public Dictionary<int, DataRow> SpawnedNpcsSelectRows_Dictionary(Guid? spawnedWorldObjectId = null)
        {
            Dictionary<int, DataRow> rows = new Dictionary<int, DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedNpcsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((int)row[(byte)SpawnedNPCsColumns.spawnedWorldObjectId],row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedNpcsDataTable.Select($"{SpawnedNPCsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((int)item[(byte)SpawnedNPCsColumns.spawnedWorldObjectId],item);
                }
            }

            return rows;
        }
        public List<DataRow> SpawnedVendorsSelectRows(Guid? spawnedWorldObjectId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedVendorsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedVendorsDataTable.Select($"{SpawnedVendorsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'"))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }

        public List<DataRow> SpawnedVendorInventorySelectRows(Guid? spawnedWorldObjectId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedVendorInventoryDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedVendorInventoryDataTable.Select($"{SpawnedVendorInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'"))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }

        public List<DataRow> SpawnedVendorInventorySelectRows(Guid spawnedWorldObjectId, string globalObjectCode, byte rarityId)
        {
            List<DataRow> rows = new List<DataRow>();
            
            foreach (var item in _dataTables.SpawnedVendorInventoryDataTable.Select($"{SpawnedVendorInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedVendorInventoryColumns.globalObject} = '{globalObjectCode}' AND rarityId = '{rarityId}'"))
            {
                rows.Add(item);
            }
            return rows;
        }
        
        public List<DataRow> SpawnedWorldObjectsSelectRows(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedWorldObjectsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsDataTable.Select($"{SpawnedWorldObjectsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }

            return rows;
        }
        public Dictionary<Guid, DataRow> SpawnedWorldObjectsSelectRows_Dictionary(Guid? spawnedWorldObjectId)
        {
            Dictionary<Guid, DataRow> rows = new Dictionary<Guid, DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedWorldObjectsDataTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)row[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId], row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsDataTable.Select($"{SpawnedVendorInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add((Guid)item[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId], item);
                }
            }

            return rows;
        }

        public DataRow AddSpawnedWorldObjectsBag(Guid spawnedWorldObjectId, byte bagLocationId)
        {
            DataRow sWOB = _dataTables.SpawnedWorldObjectsBagsDataTable.NewRow();
            
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId]        = bagLocationId;
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId]      = DBNull.Value;
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.lastUpdate]           = DateTime.Now;
            
            _dataTables.SpawnedWorldObjectsBagsDataTable.Rows.Add(sWOB);
            _dataTables.SpawnedWorldObjectsBagsDictionaryByCharacterBagId.Add((int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId], sWOB);

            return sWOB;
        }
        public DataRow UpdateSpawnedWorldObjectsBag(in Guid spawnedWorldObjectId, byte bagLocationId, in Guid instancedItemId)
        {
            if(instancedItemId == default) throw new Exception("UpdateSpawnedWorldObjectsBag: InstancedItemId cannot be default");
            foreach (var sWOI in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsBagsColumns.bagLocationId} = {bagLocationId}"))
            {
                sWOI[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = instancedItemId;
                sWOI[(byte)SpawnedWorldObjectsBagsColumns.lastUpdate] = DateTime.Now;
                return sWOI;
            }
            throw new Exception("Failed to Update Bag Slot, Bag Slot not found");
        }
        public DataRow ResetSpawnedWorldObjectsBag(in Guid spawnedWorldObjectId, byte bagLocationId)
        {
            foreach (var sWOB in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsBagsColumns.bagLocationId} = {bagLocationId}"))
            {
                var characterBagId = (int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];
                sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = DBNull.Value;
                sWOB[(byte)SpawnedWorldObjectsBagsColumns.lastUpdate] = DateTime.Now;
                foreach (var sWOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.characterBagId}={characterBagId}"))
                {
                    sWOI.Delete();
                }
                return sWOB;
            }
            throw new Exception("Failed to Reset Spawned World Object Bag, Bag Slot not found");
        }
        public DataRow? RemoveSpawnedWorldObjectsBag_ByInstancedItemId(in Guid instancedItemId)
        {
            foreach (var sWOB in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.instancedItemId}='{instancedItemId}'"))
            {
                var characterBagId = (int)sWOB[(byte)SpawnedWorldObjectsBagsColumns.characterBagId];

                sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = DBNull.Value;
                sWOB[(byte)SpawnedWorldObjectsBagsColumns.lastUpdate]      = DateTime.Now;

                foreach (var sWOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.characterBagId}={characterBagId}", "", DataViewRowState.Added))
                {
                    _dataTables.SpawnedWorldObjectsInventoryDataTable.Rows.Remove(sWOI);
                }
                foreach (var sWOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.characterBagId}={characterBagId}", "", DataViewRowState.CurrentRows))
                {
                    sWOI.Delete();
                }
                
                return sWOB;
            }
            throw new Exception("Failed to Delete Bag By InstancedItemId");
        }
        
        public List<DataRow> SpawnedWorldObjectsBagsSelectRows(Guid? spawnedWorldObjectId = null, int? bagLocationId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else if (bagLocationId == null)
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId} AND {SpawnedWorldObjectsBagsColumns.instancedItemId} IS NOT NULL'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsBagsColumns.bagLocationId} = {bagLocationId}"))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }

        public Dictionary<int, DataRow> SpawnedWorldObjectsBagsSelectRows_ByCharacterBagId_Dictionary()
        {
            Dictionary<int, DataRow> rows = new Dictionary<int, DataRow>();
            foreach (var row in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.instancedItemId} IS NOT NULL", $"{SpawnedWorldObjectsBagsColumns.characterBagId}", DataViewRowState.CurrentRows))
            {
                rows.Add((int)row[(byte)SpawnedWorldObjectsBagsColumns.characterBagId], row);
            }
            
            return rows;
        }
        
        public List<DataRow> SpawnedWorldObjectsBagsSelectRows_ByCharacterBagId(int characterBagId)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var item in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.characterBagId}='{characterBagId} AND {SpawnedWorldObjectsBagsColumns.instancedItemId} IS NOT NULL'"))
            {
                rows.Add(item);
            }
            return rows;
        }
        public DataRow SpawnedWorldObjectsCurrencySelectRow(Guid spawnedWorldObjectId)
        {
            foreach (var item in _dataTables.SpawnedWorldObjectsCurrencyDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.CurrentRows))
            {
                return item;
            }

            return null;
        }
        public List<DataRow> SpawnedWorldObjectsCurrencySelectRows()
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (var row in _dataTables.SpawnedWorldObjectsCurrencyDataTable.Select("", "", DataViewRowState.CurrentRows))
            {
                rows.Add(row);
            }
            return rows;
        }
        public List<DataRow> SpawnedWorldObjectsEquipmentSelectRows_BySpawnedWorldObjectId(Guid? spawnedWorldObjectId, int? equipmentLocationId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var spawnedWorldObject in _dataTables.SpawnedWorldObjectsEquipmentDictionary.Values)
                {
                    foreach (var sWOE in spawnedWorldObject)
                    {
                        rows.Add(sWOE);   
                    }
                }
            }
            else if (equipmentLocationId == null)
            {
                if (!_dataTables.SpawnedWorldObjectsEquipmentDictionary.ContainsKey(spawnedWorldObjectId.Value)) return rows;
                foreach (var sWOE in _dataTables.SpawnedWorldObjectsEquipmentDictionary[spawnedWorldObjectId.Value])
                {
                    rows.Add(sWOE);
                }
            }
            else
            {
                if (!_dataTables.SpawnedWorldObjectsEquipmentDictionary.ContainsKey(spawnedWorldObjectId.Value)) return rows;
                foreach (var sWOE in _dataTables.SpawnedWorldObjectsEquipmentDictionary[spawnedWorldObjectId.Value])
                {
                    if((byte)sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] == equipmentLocationId) rows.Add(sWOE);
                }
            }
            return rows;
        }
        public List<DataRow> SpawnedWorldObjectsEquipmentSelectRows_ByInstancedItemId(Guid? instancedItemId = null)
        {
            List<DataRow> rows = new List<DataRow>();
            if (instancedItemId == null)
            {
                foreach (var row in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.instancedItemId}='{instancedItemId.Value}'", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            return rows;
        }
        public DataRow AddSpawnedWorldObjectsEquipment(in Guid spawnedWorldObjectId, byte equipmentSlotId)
        {
            DataRow sWOE = _dataTables.SpawnedWorldObjectsEquipmentDataTable.NewRow();
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = DBNull.Value;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] = equipmentSlotId;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedWorldObjectsEquipmentDataTable.Rows.Add(sWOE);
            return sWOE;
        }
        public void UpdateSpawnedWorldObjectsEquipment(in Guid spawnedWorldObjectId, in Guid instancedItemId, byte equipmentSlotId)
        {
            foreach (var sWOE in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsEquipmentColumns.equipmentLocationId}={equipmentSlotId}", "", DataViewRowState.CurrentRows))
            {
                sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = instancedItemId;
                sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate] = DateTime.Now;
                return;
            }
            throw new Exception("Failed to Update Equipment, Slot not found");
        }
        public DataRow ResetSpawnedWorldObjectsEquipment_ByInstancedItemId(in Guid instancedItemId)
        {
            foreach (var sWOE in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.instancedItemId}='{instancedItemId}'"))
            {
                sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = DBNull.Value;
                sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate] = DateTime.Now;
                return sWOE;
            }
            throw new Exception("Failed to Reset Equipment, InstancedItemId not found");
        }
        public DataRow ResetSpawnedWorldObjectsEquipment_ByRow(DataRow sWOE)
        {
            if(sWOE == null) throw new Exception("Failed to Reset Equipment, InstancedItemId not found");
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = DBNull.Value;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate] = DateTime.Now;
            return sWOE;
        }
        public bool AddSpawnedWorldObjectsInventory(in Guid spawnedWorldObjectId, int characterBagId, byte slotIndex)
        {
            bool success = false;
            DataRow sWOI = _dataTables.SpawnedWorldObjectsInventoryDataTable.NewRow();
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.characterBagId] = characterBagId;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.locationInsideBag] = slotIndex;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.lastUpdate] = DateTime.Now;
            
            _dataTables.SpawnedWorldObjectsInventoryDataTable.Rows.Add(sWOI);
            return success;
        }
        public DataRow UpdateSpawnedWorldObjectsInventory(in Guid spawnedWorldObjectId, in Guid instancedItemId, int characterBagId, byte slotIndex)
        {
            foreach (var sWOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsInventoryColumns.characterBagId} = {characterBagId} AND {SpawnedWorldObjectsInventoryColumns.locationInsideBag} = {slotIndex}"))
            {
                if (sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] != DBNull.Value)
                {
                    var originalItemId = (Guid)sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId];
                    if (_dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(originalItemId))
                    {
                        _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.Remove(originalItemId);
                    }
                }

                sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = instancedItemId;
                sWOI[(byte)SpawnedWorldObjectsInventoryColumns.lastUpdate] = DateTime.Now;

                if (!_dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.TryAdd(instancedItemId, sWOI))
                {
                    throw new NullReferenceException($"SpawnedWorldObjectsInventoryDictionaryByInstancedItemId already contains {instancedItemId}, {sWOI}");   
                }
                else _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId] = sWOI;
                

                return sWOI;
            }

            throw new Exception("Failed to Update Spawned World Object Inventory, Invalid Inventory Slot");
        }
        public DataRow ResetSpawnedWorldObjectsInventory(in Guid spawnedWorldObjectId, int characterBagId, byte slotIndex)
        {
            foreach (var sWOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsInventoryColumns.characterBagId} = {characterBagId} AND locationInsideBag = {slotIndex}"))
            {
                _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.Remove((Guid)sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId]);

                sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
                sWOI[(byte)SpawnedWorldObjectsInventoryColumns.lastUpdate] = DateTime.Now;
                return sWOI;
            }

            throw new Exception("Failed to Reset Spawned World Object Inventory, Invalid Inventory Slot");
        }
        public DataRow ResetSpawnedWorldObjectsInventory(DataRow sWOI)
        {
            if(sWOI == null) throw new Exception("Failed to Reset Spawned World Object Inventory, Invalid Inventory Slot");
            _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.Remove((Guid)sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId]);
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.lastUpdate]      = DateTime.Now;
            return sWOI;
        }
        public DataRow  ResetSpawnedWorldInventory_ByInstancedItemId(in Guid instancedItemId)
        {
            if (!_dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.ContainsKey(instancedItemId))
            {
                throw new KeyNotFoundException($"Failed to Reset {instancedItemId} from SpawnedWorldObjectInventory");
            }
            var sWOI = _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId[instancedItemId];
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.instancedItemId] = DBNull.Value;
            sWOI[(byte)SpawnedWorldObjectsInventoryColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedWorldObjectsInventoryDictionaryByInstancedItemId.Remove(instancedItemId);
            return sWOI;
        }
        public List<DataRow> SpawnedWorldObjectsInventorySelectRows_BySpawnedWorldObjectId(Guid? spawnedWorldObjectId)
        {
            List<DataRow> rows = new List<DataRow>();
            if (spawnedWorldObjectId == null)
            {
                foreach (var row in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(row);
                }
            }
            else
            {
                foreach (var item in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId.Value}' AND {SpawnedWorldObjectsInventoryColumns.instancedItemId} IS NOT NULL", "", DataViewRowState.CurrentRows))
                {
                    rows.Add(item);
                }
            }
            
            return rows;
        }
  
        public DataRow SpawnedWorldObjectsInventorySelectRow(in Guid spawnedWorldObjectId, int characterBagId, uint locationInsideBag)
        {
            foreach (var swOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsInventoryColumns.characterBagId}={characterBagId} AND {SpawnedWorldObjectsInventoryColumns.locationInsideBag}={locationInsideBag}"))
            {
                return swOI;
            }
            return null;
        }        
        public DataRow SpawnedWorldObjectsInventorySelectRow_ByBagIndex(in Guid spawnedWorldObjectId, int bagLocation, uint locationInsideBag)
        {
            foreach (var swOI in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsInventoryColumns.locationInsideBag}={bagLocation} AND {SpawnedWorldObjectsInventoryColumns.locationInsideBag}={locationInsideBag}"))
            {
                return swOI;
            }
            return null;
        }
        
        #endregion

        #region DATA TABLE DELETE: CHARACTERS
        public void DeleteCharactersAbilities_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersAbilitiesDataTable.Select($"{CharactersAbilitiesColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersAbilitiesDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersAbilitiesDataTable.Select($"{CharactersAbilitiesColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
}
        public void DeleteCharactersAchievements_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersAchievementsDataTable.Select($"{CharactersAchievementsColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersAchievementsDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersAchievementsDataTable.Select($"{CharactersAchievementsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void ResetCharactersBuybacks(int characterId, in Guid instancedItemId)
        {
            foreach (var cBB in _dataTables.CharactersBuyBacksDataTable.Select($"{CharactersBuybacksColumns.characterId}={characterId} AND {CharactersBuybacksColumns.instancedItemId}='{instancedItemId}'", "", DataViewRowState.Added))
            {
                cBB[(byte)CharactersBuybacksColumns.instancedItemId] = DBNull.Value;
                cBB[(byte)CharactersBuybacksColumns.soldDate]        = DBNull.Value;
            } 
        }
        public void DeleteCharactersQuests_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersQuestsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersQuestsDataTable.Rows.Remove(row);
            }

            foreach (var row in _dataTables.CharactersQuestsDataTable.Select($"{CharactersQuestsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteCharactersQuestObjectives_ByCharacterId(int characterId, string questGlobalObjectCode)
        {
            foreach (var row in _dataTables.CharactersQuestsObjectivesDataTable.Select($"{CharactersQuestsObjectivesColumns.characterId}={characterId} AND {CharactersQuestsObjectivesColumns.questGlobalObject}='{questGlobalObjectCode}'", "", DataViewRowState.Added))
            {
                _dataTables.CharactersQuestsObjectivesDataTable.Rows.Remove(row);
            }

            foreach (var row in _dataTables.CharactersQuestsObjectivesDataTable.Select($"{CharactersQuestsObjectivesColumns.characterId}={characterId} AND {CharactersQuestsObjectivesColumns.questGlobalObject}='{questGlobalObjectCode}'", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteCharactersRecipes_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersRecipesDataTable.Select($"{CharactersRecipesColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersRecipesDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersRecipesDataTable.Select($"{CharactersRecipesColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteCharactersSkills_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersSkillsDataTable.Select($"{CharactersSkillsColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersSkillsDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersSkillsDataTable.Select($"{CharactersSkillsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteCharactersStats_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersStatsDataTable.Select($"{CharactersStatsColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersStatsDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersStatsDataTable.Select($"{CharactersStatsColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteCharactersSocial_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersSocialDataTable.Select($"{CharactersSocialColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersSocialDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersSocialDataTable.Select($"{CharactersSocialColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }

        public void DeleteCharactersTitles_ByCharacterId(int characterId)
        {
            foreach (var row in _dataTables.CharactersTitlesDataTable.Select($"{CharactersTitlesColumns.characterId}={characterId}", "", DataViewRowState.Added))
            {
                _dataTables.CharactersTitlesDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.CharactersTitlesDataTable.Select($"{CharactersTitlesColumns.characterId}={characterId}", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        #endregion      
        
        #region DATA TABLE DELETE: SPAWNED
        public void DeleteSpawnedWorldObjects_BySpawnedWorldObjectId(in Guid spawnedWorldObjectId)
        {
            try
            {
                var row = _dataTables.SpawnedWorldObjectsDataTable.Select($"{SpawnedWorldObjectsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "")[0];
                row[(byte)SpawnedWorldObjectsColumns.status] = "deleted";
                row[(byte)SpawnedWorldObjectsColumns.locationId] = DBNull.Value;
            }
            catch
            {
                throw new RowNotInTableException($"DeleteSpawnedWorldObjects_BySpawnedWorldObjectId: Row not found with spawnedObjectId {spawnedWorldObjectId}");
            }

            
        }
        public void DeleteSpawnedWorldObjectsBags_BySpawnedWorldObjectId(in Guid spawnedWorldObjectId)
        {
            foreach (var row in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.Added))
            {
                _dataTables.SpawnedWorldObjectsBagsDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.SpawnedWorldObjectsBagsDataTable.Select($"{SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteSpawnedWorldObjectsEquipment_BySpawnedWorldObjectId(in Guid spawnedWorldObjectId)
        {
            foreach (var row in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.Added))
            {
                _dataTables.SpawnedWorldObjectsEquipmentDataTable.Rows.Remove(row);
            }
            foreach (var row in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
            }
        }
        public void DeleteSpawnedWorldObjectsEquipment_ByEquipmentLocationId(in Guid spawnedWorldObjectId, byte equipmentLocationId)
        {
            foreach (var row in _dataTables.SpawnedWorldObjectsEquipmentDataTable.Select($"{SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}' AND {SpawnedWorldObjectsEquipmentColumns.equipmentLocationId}='{equipmentLocationId}'"))
            {
                row[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = DBNull.Value;
                row[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate] = DateTime.Now;
            }
        }

        public void DeleteSpawnedWorldObjectsInventory_BySpawnedWorldObjectId(in Guid spawnedWorldObjectId)
        {
            bool foundRow = false;
            foreach (var row in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.Added))
            {
                _dataTables.SpawnedWorldObjectsInventoryDataTable.Rows.Remove(row);
                foundRow = true;
            }
            foreach (var row in _dataTables.SpawnedWorldObjectsInventoryDataTable.Select($"{SpawnedWorldObjectsInventoryColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "", DataViewRowState.CurrentRows))
            {
                row.Delete();
                foundRow = true;
            }

            if (!foundRow)
            {
                throw new RowNotInTableException($"DeleteSpawnedWorldObjectsInventory_BySpawnedWorldObjectId: Row not found with spawnedObjectId {spawnedWorldObjectId}");
            }
        }
        public void DeleteSpawnedWorldObjectsCurrency_BySpawnedWorldObjectId(in Guid spawnedWorldObjectId)
        {
            var rows = _dataTables.SpawnedWorldObjectsCurrencyDataTable.Select(
                $"{SpawnedWorldObjectsCurrencyColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "",
                DataViewRowState.Added);
            if (rows.Length > 0)
            {
                _dataTables.SpawnedWorldObjectsCurrencyDataTable.Rows.Remove(rows[0]);
            }
            else
            {
                rows = _dataTables.SpawnedWorldObjectsCurrencyDataTable.Select(
                    $"{SpawnedWorldObjectsCurrencyColumns.spawnedWorldObjectId}='{spawnedWorldObjectId}'", "",
                    DataViewRowState.CurrentRows);
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    return;
                }
            }
            throw new RowNotInTableException($"DeleteSpawnedWorldObjectsCurrency_BySpawnedWorldObjectId: Row not found with spawnedObjectId {spawnedWorldObjectId}");
        }
        #endregion
   
        #region DATA TABLE POPULATE DATA ROWS: CHARACTER
        //PLAYERS ACCOUNTS
        public DataRow PopulatePlayerAccountsDataRow(DataRow pA, in Guid steamId, string steamName, string userName, 
            string password, string emailAddress, string salt, string lastIpAddressOnLogin, DateTime lastLoginTime)
        {
            pA[(byte)PlayersAccountsColumns.steamId] = steamId;
            pA[(byte)PlayersAccountsColumns.steamName] = steamName;
            //pA[(byte)PlayersAccountsColumns.userName] = userName;
            //pA[(byte)PlayersAccountsColumns.password] = password;
            //pA[(byte)PlayersAccountsColumns.emailAddress] = emailAddress;
            //pA[(byte)PlayersAccountsColumns.salt] = salt;
            pA[(byte)PlayersAccountsColumns.lastIpAddressOnLogin] = lastIpAddressOnLogin;
            pA[(byte)PlayersAccountsColumns.lastLoginTime] = DateTime.Now;
            pA[(byte)PlayersAccountsColumns.isAdmin] = false;
            return pA;
        }
        //CHARACTERS
        public DataRow AddCharactersDataRow(in Guid spawnedWorldObjectId, int playerAccountId, int characterTierId, 
            int characterRankId, int characterModelId, int characterFactionId, int characterExperience, string characterName,
            int gender, int face, int eyebrows, int hair, int facialHair, string eyeColor, string hairColor, string skinColor,
            int race, string stubbleColor, float spawnLocationX, float spawnLocationY, float spawnLocationZ, string status)
        {
            DataRow cH = _dataTables.CharactersDataTable.NewRow();
            cH[(byte)CharactersColumns.playerAccountId] = playerAccountId;
            cH[(byte)CharactersColumns.characterTierId] = characterTierId;
            cH[(byte)CharactersColumns.characterRankId] = characterRankId;
            cH[(byte)CharactersColumns.characterModelId] = characterModelId;
            cH[(byte)CharactersColumns.characterFactionId] = characterFactionId;
            cH[(byte)CharactersColumns.characterExperience] = characterExperience;
            cH[(byte)CharactersColumns.dateTimeCreated] = DateTime.Now;
            cH[(byte)CharactersColumns.characterName] = characterName;
            cH[(byte)CharactersColumns.lastUpdated] = DateTime.Now;
            cH[(byte)CharactersColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            
            cH[(byte)CharactersColumns.spawnCoordinateX] = spawnLocationX;
            cH[(byte)CharactersColumns.spawnCoordinateY] = spawnLocationY;
            cH[(byte)CharactersColumns.spawnCoordinateZ] = spawnLocationZ;
            
            cH[(byte)CharactersColumns.gender] = gender;
            cH[(byte)CharactersColumns.face] = face;
            cH[(byte)CharactersColumns.eyebrows] = eyebrows;
            cH[(byte)CharactersColumns.hair] = hair;
            cH[(byte)CharactersColumns.facialHair] = facialHair;
            cH[(byte)CharactersColumns.eyeColor] = eyeColor;
            cH[(byte)CharactersColumns.hairColor] = hairColor;
            cH[(byte)CharactersColumns.skinColor] = skinColor;
            cH[(byte)CharactersColumns.race] = race;
            cH[(byte)CharactersColumns.stubbleColor] = stubbleColor;
            cH[(byte)CharactersColumns.status] = status;
            _dataTables.CharactersDataTable.Rows.Add(cH);
            _dataTables.CharactersDictionaryBySpawnedWorldObjectId.Add(spawnedWorldObjectId, cH);
            //GET KEY FROM ROW ADDED TO Characters
            _dataTables.CharactersDictionaryByCharacterId.Add((int)cH[(byte)CharactersColumns.characterId], cH);
            return cH;
        }
        
        public DataRow AddCharactersAbilitiesDataRow(int characterId, string globalObjectCode, int characterAbilityExperience)
        {
            DataRow cHA = _dataTables.CharactersAbilitiesDataTable.NewRow();

            cHA[(byte)CharactersAbilitiesColumns.characterId] = characterId;
            cHA[(byte)CharactersAbilitiesColumns.globalObject] = globalObjectCode;
            cHA[(byte)CharactersAbilitiesColumns.characterAbilityExperience] = characterAbilityExperience;
            cHA[(byte)CharactersAbilitiesColumns.lastUpdated] = DateTime.Now;

            _dataTables.CharactersAbilitiesDataTable.Rows.Add(cHA);

            return cHA;
        }
        //ABILITIES
        public DataRow PopulateCharactersAbilitiesDataRow(DataRow cHA, int characterId, string globalObjectCode, int characterAbilityExperience)
        {
            cHA[(byte)CharactersAbilitiesColumns.characterId] = characterId;
            cHA[(byte)CharactersAbilitiesColumns.globalObject] = globalObjectCode;
            cHA[(byte)CharactersAbilitiesColumns.characterAbilityExperience] = characterAbilityExperience;
            cHA[(byte)CharactersAbilitiesColumns.lastUpdated] = DateTime.Now;
            
            return cHA;
        }
        public DataRow AddCharactersAchievementsDataRow(int characterId, string globalObjectCode)
        {
            DataRow cHA = _dataTables.CharactersAchievementsDataTable.NewRow();
            cHA[(byte)CharactersAchievementsColumns.characterId] = characterId;
            cHA[(byte)CharactersAchievementsColumns.globalObject] = globalObjectCode;
            cHA[(byte)CharactersAchievementsColumns.lastUpdated] = DateTime.Now;
            _dataTables.CharactersAchievementsDataTable.Rows.Add(cHA);
            return cHA;
        }
        public void AddCharactersBuybacksDataRow(int characterId, in Guid? instancedItemId = null, DateTime? soldDate = null)
        {
            DataRow cB = _dataTables.CharactersBuyBacksDataTable.NewRow();
            cB[(byte)CharactersBuybacksColumns.characterId]     = characterId;
            cB[(byte)CharactersBuybacksColumns.instancedItemId] = instancedItemId.HasValue ? (object) instancedItemId.Value : DBNull.Value;
            cB[(byte)CharactersBuybacksColumns.soldDate]        = soldDate.HasValue ? (object)soldDate.Value : DBNull.Value;
            _dataTables.CharactersBuyBacksDataTable.Rows.Add(cB);
        }  
        public void UpdateCharactersBuybacksDataRow(int characterId, in Guid? instancedItemId = null, DateTime? soldDate = null)
        {

            foreach (DataRow cBB in _dataTables.CharactersBuyBacksDataTable.Rows)
            {
                if ((int)cBB[(byte)CharactersBuybacksColumns.characterId] == characterId)
                {
                   if(cBB[(byte)CharactersBuybacksColumns.instancedItemId] != DBNull.Value) continue;
                   cBB[(byte)CharactersBuybacksColumns.instancedItemId] = instancedItemId;
                   cBB[(byte)CharactersBuybacksColumns.soldDate]        = soldDate;
                   break;
                }
            }
        }
        public void AddCharactersMailDataRow(in Guid charactersMailId, byte mailIndex, int senderCharacterId,
            string senderName, string mailSubject, string mailBody, long sentGold, byte sentSilver, byte sentCopper, bool currencyClaimed,
             bool contentsClaimed, bool unread, int recipientCharacterId, DateTime sentDateTime, DateTime appearDateTime,
            DateTime autoDeleteDateTime)
        {
            DataRow cM = _dataTables.CharactersMailDataTable.NewRow();
            cM[(byte)CharactersMailColumns.charactersMailId] = charactersMailId;
            cM[(byte)CharactersMailColumns.mailIndex] = mailIndex;
            cM[(byte)CharactersMailColumns.senderCharacterId] = senderCharacterId;
            cM[(byte)CharactersMailColumns.senderName] = senderName;
            cM[(byte)CharactersMailColumns.autoDeleteDateTime] = autoDeleteDateTime;
            cM[(byte)CharactersMailColumns.appearDateTime] = appearDateTime;
            cM[(byte)CharactersMailColumns.sentDateTime] = sentDateTime;
            cM[(byte)CharactersMailColumns.mailSubject] = mailSubject;
            cM[(byte)CharactersMailColumns.mailBody] = mailBody;
            cM[(byte)CharactersMailColumns.sentGold] = sentGold;
            cM[(byte)CharactersMailColumns.sentSilver] = sentSilver;
            cM[(byte)CharactersMailColumns.sentCopper] = sentCopper;
            cM[(byte)CharactersMailColumns.currencyClaimed] = currencyClaimed;
            cM[(byte)CharactersMailColumns.contentsClaimed] = contentsClaimed;
            cM[(byte)CharactersMailColumns.unread] = unread;
            cM[(byte)CharactersMailColumns.recipientCharacterId] = recipientCharacterId;
            _dataTables.CharactersMailDataTable.Rows.Add(cM);
        }
        public DataRow PopulateCharactersMailAttachmentsDataRow(DataRow row, in Guid charactersMailId, in Guid instancedItemId, byte slotIndex, DateTime sentDateTime)
        {
            row[(byte)CharactersMailAttachmentsColumns.charactersMailId] = charactersMailId;
            row[(byte)CharactersMailAttachmentsColumns.instancedItemId] = instancedItemId;
            row[(byte)CharactersMailAttachmentsColumns.slotIndex] = slotIndex;
            row[(byte)CharactersMailAttachmentsColumns.sentDateTime] = sentDateTime;
           
            return row;
        }

        public DataRow AddCharactersRecipesDataRow(int characterId, string globalObjectCode)
        {
            DataRow cHR = _dataTables.CharactersRecipesDataTable.NewRow();
            cHR[(byte)CharactersRecipesColumns.globalObject] = globalObjectCode;
            cHR[(byte)CharactersRecipesColumns.lastUpdate]       = DateTime.Now;
            cHR[(byte)CharactersRecipesColumns.characterId]      = characterId;
            _dataTables.CharactersRecipesDataTable.Rows.Add(cHR);
            return cHR;
        }

        public DataRow AddCharactersSkillsDataRow(int characterId, string globalObjectCode, int characterSkillExperience)
        {
            DataRow cHS = _dataTables.CharactersSkillsDataTable.NewRow();
            cHS[(byte)CharactersSkillsColumns.characterId] = characterId;
            cHS[(byte)CharactersSkillsColumns.globalObject] = globalObjectCode;
            cHS[(byte)CharactersSkillsColumns.characterSkillExperience] = characterSkillExperience;
            cHS[(byte)CharactersSkillsColumns.lastUpdated] = DateTime.Now;
            _dataTables.CharactersSkillsDataTable.Rows.Add(cHS);
            return cHS;
        }

        public void AddCharactersStatsDataRow(int characterId, int characterStatTypeId, int characterStatStatusId, int characterStatTierId, float characterStatValue, string characterStatDescription, int characterStatIconId, int statId, string characterStat)
        {
            DataRow cS = _dataTables.CharactersStatsDataTable.NewRow();
            
            cS[(byte)CharactersStatsColumns.characterStatTypeId] = characterStatTypeId;
            cS[(byte)CharactersStatsColumns.characterStatStatusId] = characterStatStatusId;
            cS[(byte)CharactersStatsColumns.characterStatTierId] = characterStatTierId;
            cS[(byte)CharactersStatsColumns.characterStatValue] = characterStatValue;
            cS[(byte)CharactersStatsColumns.characterStatDescription] = characterStatDescription;
            cS[(byte)CharactersStatsColumns.characterStatIconId] = characterStatIconId;
            cS[(byte)CharactersStatsColumns.statId] = statId;
            cS[(byte)CharactersStatsColumns.characterStat] = characterStat;
            cS[(byte)CharactersStatsColumns.lastUpdate] = DateTime.Now;
            cS[(byte)CharactersStatsColumns.characterId] = characterId;
            _dataTables.CharactersStatsDataTable.Rows.Add(cS);
        }

        public void AddCharactersTitlesDataRow(int characterId, string titleGlobalObjectCode)
        {
            DataRow cHT = _dataTables.CharactersTitlesDataTable.NewRow();
            cHT[(byte)CharactersTitlesColumns.characterId] = characterId;
            cHT[(byte)CharactersTitlesColumns.globalObject] = titleGlobalObjectCode;
            cHT[(byte)CharactersTitlesColumns.lastUpdated] = DateTime.Now;
            _dataTables.CharactersTitlesDataTable.Rows.Add(cHT);

        }

        #endregion
        
        #region DATA TABLE POPULATE DATA ROWS: INSTANCED

        public DataRow AddInstancedItemsDataRow(in Guid instancedItemId, in Guid spawnedWorldObjectId, 
            byte itemTypeId, byte maxStack, byte quantity, string globalObjectCode, byte rarityId, byte qualityId, 
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted)
        {
            DataRow iI = _dataTables.InstancedItemsDataTable.NewRow();

            iI[(byte)InstancedItemsColumns.instancedItemId] = instancedItemId;
            iI[(byte)InstancedItemsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            iI[(byte)InstancedItemsColumns.itemTypeId] = itemTypeId;
            iI[(byte)InstancedItemsColumns.maxStack] = maxStack;
            iI[(byte)InstancedItemsColumns.quantity] = quantity;
            iI[(byte)InstancedItemsColumns.globalObject] = globalObjectCode;
            iI[(byte)InstancedItemsColumns.rarityId] = rarityId;
            iI[(byte)InstancedItemsColumns.qualityId] = qualityId;
            iI[(byte)InstancedItemsColumns.durabilityPercentage] = durabilityPercentage;
            iI[(byte)InstancedItemsColumns.wasCrafted] = wasCrafted;
            iI[(byte)InstancedItemsColumns.crafterName] = crafterName;
            iI[(byte)InstancedItemsColumns.wasLooted] = wasLooted;
            iI[(byte)InstancedItemsColumns.status] = "active";
            iI[(byte)InstancedItemsColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedItemsDataTable.Rows.Add(iI);
            _dataTables.InstancedItemsDictionaryByInstancedItemId.Add(instancedItemId, iI);
            if(!_dataTables.InstancedItemsDictionaryBySpawnedWorldObjectId.ContainsKey(spawnedWorldObjectId)) 
                _dataTables.InstancedItemsDictionaryBySpawnedWorldObjectId.Add(spawnedWorldObjectId, new List<DataRow>() {iI});
            else _dataTables.InstancedItemsDictionaryBySpawnedWorldObjectId[spawnedWorldObjectId].Add(iI);
            return iI;
        }
        public DataRow AddInstancedAmmunitionDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iA = _dataTables.InstancedAmmunitionDataTable.NewRow();
            iA[(byte)InstancedAmmunitionColumns.instancedItemId] = instancedItemId;
            iA[(byte)InstancedAmmunitionColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedAmmunitionDataTable.Rows.Add(iA);
            return iA;
        }
        public DataRow AddInstancedArmorDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iA = _dataTables.InstancedArmorDataTable.NewRow();
            iA[(byte)InstancedArmorColumns.instancedItemId] = instancedItemId;
            iA[(byte)InstancedArmorColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedArmorDataTable.Rows.Add(iA);
            return iA;
        }
        public DataRow AddInstancedBagsDataRow(in Guid instancedItemId, string globalObjectCode, byte slots)
        {
            DataRow iB = _dataTables.InstancedBagsDataTable.NewRow();
            iB[(byte)InstancedBagsColumns.instancedItemId] = instancedItemId;
            iB[(byte)InstancedBagsColumns.slots] = slots;
            iB[(byte)InstancedBagsColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedBagsDataTable.Rows.Add(iB);
            return iB;
        }
        public DataRow AddInstancedConsumablesDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iC = _dataTables.InstancedConsumablesDataTable.NewRow();
            iC[(byte)InstancedConsumablesColumns.instancedItemId] = instancedItemId;
            iC[(byte)InstancedConsumablesColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedConsumablesDataTable.Rows.Add(iC);
            return iC;
        }
        
        public DataRow AddInstancedEquipmentDataRow(in Guid instancedItemId, string globalObjectCode, byte equipmentTypeId)
        {
            DataRow iE = _dataTables.InstancedEquipmentDataTable.NewRow();
            iE[(byte)InstancedEquipmentColumns.instancedItemId] = instancedItemId;
            iE[(byte)InstancedEquipmentColumns.equipmentTypeId] = equipmentTypeId;
            iE[(byte)InstancedEquipmentColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedEquipmentDataTable.Rows.Add(iE);
            return iE;
        }
        public DataRow AddInstancedGeneralItemsDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iG = _dataTables.InstancedGeneralItemsDataTable.NewRow();
            iG[(byte)InstancedGeneralItemsColumns.instancedItemId] = instancedItemId;
            iG[(byte)InstancedGeneralItemsColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedGeneralItemsDataTable.Rows.Add(iG);
            return iG;
        }
        public DataRow AddInstancedMaterialsDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iM = _dataTables.InstancedMaterialsDataTable.NewRow();
            iM[(byte)InstancedMaterialsColumns.instancedItemId] = instancedItemId;
            iM[(byte)InstancedMaterialsColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedMaterialsDataTable.Rows.Add(iM);
            return iM;
        }
        public DataRow AddInstancedWeaponsDataRow(in Guid instancedItemId, string globalObjectCode)
        {
            DataRow iW = _dataTables.InstancedWeaponsDataTable.NewRow();
            iW[(byte)InstancedWeaponsColumns.instancedItemId] = instancedItemId;
            iW[(byte)InstancedWeaponsColumns.lastUpdate] = DateTime.Now;
            _dataTables.InstancedWeaponsDataTable.Rows.Add(iW);
            return iW;
        }
        public DataRow PopulateInstancedItemsIngredientsDataRow(DataRow iII, in Guid instancedItemId, string ingredientGlobalObjectCode)
        {
            iII[(byte)InstancedItemsIngredientsColumns.instancedItemId] = instancedItemId;
            iII[(byte)InstancedItemsIngredientsColumns.ingredientGlobalObject] = ingredientGlobalObjectCode;
            iII[(byte)InstancedItemsIngredientsColumns.lastUpdate] = DateTime.Now;
            return iII;
        }

        
        #endregion
        
        #region DATA TABLE POPULATE DATA ROWS: SPAWNED
        public void AddSpawnedAnimalsDataRow(in Guid spawnedWorldObjectId)
        {
            DataRow sA = _dataTables.SpawnedAnimalsDataTable.NewRow();
            sA[(byte)SpawnedAnimalsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sA[(byte)SpawnedAnimalsColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedAnimalsDataTable.Rows.Add(sA);
        }

        public void AddSpawnedContainersDataRow(in Guid spawnedWorldObjectId, bool openedBefore)
        {
            DataRow sC = _dataTables.SpawnedContainersDataTable.NewRow();
            sC[(byte)SpawnedContainersColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sC[(byte)SpawnedContainersColumns.openedBefore] = openedBefore;
            sC[(byte)SpawnedContainersColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedContainersDataTable.Rows.Add(sC);
        }

        public void AddSpawnedEnemyHumanoidsDataRow(in Guid spawnedWorldObjectId)
        {
            DataRow sEH = _dataTables.SpawnedEnemyHumanoidsDataTable.NewRow();
            sEH[(byte)SpawnedEnemyHumanoidsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sEH[(byte)SpawnedEnemyHumanoidsColumns.lastUpdate] = DateTime.Now;                
            _dataTables.SpawnedEnemyHumanoidsDataTable.Rows.Add(sEH);
        }

        public void AddSpawnedEntitiesDataRow(in Guid spawnedWorldObjectId, byte entityTypeId)
        {
            DataRow sA = _dataTables.SpawnedEntitiesDataTable.NewRow();
            sA[(byte)SpawnedEntitiesColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sA[(byte)SpawnedEntitiesColumns.entityTypeId] = entityTypeId;
            sA[(byte)SpawnedEntitiesColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedEntitiesDataTable.Rows.Add(sA);
        }

        public void AddSpawnedGatherablesDataRow(in Guid spawnedWorldObjectId)
        {
            DataRow sG = _dataTables.SpawnedGatherablesDataTable.NewRow();
            sG[(byte)SpawnedGatherablesColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sG[(byte)SpawnedGatherablesColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedGatherablesDataTable.Rows.Add(sG);
        }

        public void AddSpawnedInteractablesDataRow(in Guid spawnedWorldObjectId, uint interactableTypeId)
        {
            DataRow sI = _dataTables.SpawnedInteractablesDataTable.NewRow();
            sI[(byte)SpawnedInteractablesColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sI[(byte)SpawnedInteractablesColumns.interactableTypeId] = interactableTypeId;
            sI[(byte)SpawnedInteractablesColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedInteractablesDataTable.Rows.Add(sI);
            _dataTables.SpawnedInteractablesDictionary.Add(spawnedWorldObjectId, sI);
        }

        public void AddSpawnedMonstersDataRow(in Guid spawnedWorldObjectId)
        {
            DataRow sM = _dataTables.SpawnedMonstersDataTable.NewRow();
            sM[(byte)SpawnedMonstersColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sM[(byte)SpawnedMonstersColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedMonstersDataTable.Rows.Add(sM);
        }

        public void AddSpawnedNpcsDataRow(in Guid spawnedWorldObjectId, byte npcTypeId)
        {
            DataRow sN = _dataTables.SpawnedNpcsDataTable.NewRow();
            sN[(byte)SpawnedNPCsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sN[(byte)SpawnedNPCsColumns.npcTypeId] = npcTypeId;
            sN[(byte)SpawnedNPCsColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedNpcsDataTable.Rows.Add(sN);
        }   
        

        public void AddSpawnedVendorsDataRow(in Guid spawnedWorldObjectId)
        {
            DataRow sV = _dataTables.SpawnedVendorsDataTable.NewRow();
            sV[(byte)SpawnedVendorsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sV[(byte)SpawnedVendorsColumns.lastRestockTime] = DateTime.Now;
            _dataTables.SpawnedVendorsDataTable.Rows.Add(sV);
        }

        public void AddSpawnedVendorInventoryDataRow(in Guid spawnedWorldObjectId, string globalObjectCode, byte rarityId, uint currentStock)
        {
            DataRow sVI = _dataTables.SpawnedVendorInventoryDataTable.NewRow();
            sVI[(byte)SpawnedVendorInventoryColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sVI[(byte)SpawnedVendorInventoryColumns.globalObject] = globalObjectCode;
            sVI[(byte)SpawnedVendorInventoryColumns.rarityId] = rarityId;
            sVI[(byte)SpawnedVendorInventoryColumns.currentStock] = currentStock;
            sVI[(byte)SpawnedVendorInventoryColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedVendorInventoryDataTable.Rows.Add(sVI);
        }

        // ReSharper disable all HeapView.BoxingAllocation

        public void AddSpawnedWorldObjectsDataRow(in Guid spawnedWorldObjectId, byte worldObjectTypeId, string globalObjectCode,
            float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ,
            float scaleX, float scaleY, float scaleZ, byte globalTierId, byte globalRankId, byte variationId, string prefabId,
            bool ignoreSpawnTable, uint? locationId)
        {
            DataRow sWO = _dataTables.SpawnedWorldObjectsDataTable.NewRow();
            sWO[(byte)SpawnedWorldObjectsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sWO[(byte)SpawnedWorldObjectsColumns.worldObjectTypeId] = worldObjectTypeId;
            sWO[(byte)SpawnedWorldObjectsColumns.globalObject] = globalObjectCode;
            sWO[(byte)SpawnedWorldObjectsColumns.coordinateX] = coordinateX;
            sWO[(byte)SpawnedWorldObjectsColumns.coordinateY] = coordinateY;
            sWO[(byte)SpawnedWorldObjectsColumns.coordinateZ] = coordinateZ;
            sWO[(byte)SpawnedWorldObjectsColumns.chunk] = chunk;
            sWO[(byte)SpawnedWorldObjectsColumns.rotationX] = rotationX;
            sWO[(byte)SpawnedWorldObjectsColumns.rotationY] = rotationY;
            sWO[(byte)SpawnedWorldObjectsColumns.rotationZ] = rotationZ;
            sWO[(byte)SpawnedWorldObjectsColumns.scaleX] = scaleX;
            sWO[(byte)SpawnedWorldObjectsColumns.scaleY] = scaleY;
            sWO[(byte)SpawnedWorldObjectsColumns.scaleZ] = scaleZ;
            sWO[(byte)SpawnedWorldObjectsColumns.globalTierId] = globalTierId;
            sWO[(byte)SpawnedWorldObjectsColumns.globalRankId] = globalRankId;
            sWO[(byte)SpawnedWorldObjectsColumns.variationId] = variationId;
            sWO[(byte)SpawnedWorldObjectsColumns.prefabId] = prefabId;
            sWO[(byte)SpawnedWorldObjectsColumns.ignoreSpawnTable] = ignoreSpawnTable;
            if (locationId.HasValue) sWO[(byte)SpawnedWorldObjectsColumns.locationId] = (int)locationId;
            else sWO[(byte)SpawnedWorldObjectsColumns.locationId]                     = DBNull.Value;

            sWO[(byte)SpawnedWorldObjectsColumns.lastUpdate] = DateTime.Now;
            sWO[(byte)SpawnedWorldObjectsColumns.status] = "active";
            _dataTables.SpawnedWorldObjectsDataTable.Rows.Add(sWO);
            _dataTables.SpawnedWorldObjectsDictionary.Add(spawnedWorldObjectId, sWO);
        }
        public DataRow PopulateSpawnedWorldObjectsBagsDataRow(DataRow sWOB, in Guid spawnedWorldObjectId, in Guid instancedItemId, int bagLocationId)
        {

            sWOB[(byte)SpawnedWorldObjectsBagsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            if(instancedItemId == Guid.Empty) sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = DBNull.Value;
            else sWOB[(byte)SpawnedWorldObjectsBagsColumns.instancedItemId] = instancedItemId;
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.bagLocationId] = bagLocationId;
            sWOB[(byte)SpawnedWorldObjectsBagsColumns.lastUpdate]    = DateTime.Now;
            return sWOB;
        }
        public void AddSpawnedWorldObjectsCurrencyDataRow(in Guid spawnedWorldObjectId, int amountGold, byte amountSilver,
            byte amountCopper, int tokenAdventuring, int tokenCrafting, int tokenGathering)
        {
            DataRow sWOC = _dataTables.SpawnedWorldObjectsCurrencyDataTable.NewRow();

            if (amountGold < 0) amountGold = 0;
            
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Gold] = amountGold;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Silver] = amountSilver;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.amount_Copper] = amountCopper;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_adventuring] = tokenAdventuring;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_crafting] = tokenCrafting;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.token_gathering] = tokenGathering;
            sWOC[(byte)SpawnedWorldObjectsCurrencyColumns.lastUpdate] = DateTime.Now;
            _dataTables.SpawnedWorldObjectsCurrencyDataTable.Rows.Add(sWOC);
            _dataTables.SpawnedWorldObjectsCurrencyDictionary.Add(spawnedWorldObjectId, sWOC);
        }
        public DataRow PopulateSpawnedWorldObjectsEquipmentDataRow(DataRow sWOE, in Guid spawnedWorldObjectId, byte equipmentLocationId, in Guid instancedItemId)
        {
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            if(instancedItemId == Guid.Empty) sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = DBNull.Value;
            else sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.instancedItemId] = instancedItemId;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.equipmentLocationId] = equipmentLocationId;
            sWOE[(byte)SpawnedWorldObjectsEquipmentColumns.lastUpdate]          = DateTime.Now;
            return sWOE;
        }

        #endregion
        
        #region DATA TABLE POPULATE DATA ROWS: HISTORY
        
        public void AddHistoryCharacterCollectedDataRow(int characterId, byte rarityId, string itemGlobalObjectCode, byte quantity)
        {
            DataRow hCC = _dataTables.HistoryCharacterCollectedDataTable.NewRow();
            hCC[(byte)HistoryCharacterCollectedColumns.characterId] = characterId;
            hCC[(byte)HistoryCharacterCollectedColumns.itemGlobalObject] = itemGlobalObjectCode;
            hCC[(byte)HistoryCharacterCollectedColumns.rarityId] = rarityId;
            hCC[(byte)HistoryCharacterCollectedColumns.quantity] = quantity;
            hCC[(byte)HistoryCharacterCollectedColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterCollectedDataTable.Rows.Add(hCC);
        }
        
        public void AddHistoryCharacterCombatDataRow(int characterId, int blocks,
            int blocked, int strikesReceived, int strikesGiven, int damageReceived, int damageGiven)
        {
            DataRow hCC = _dataTables.HistoryCharacterCombatDataTable.NewRow();
            hCC[(byte)HistoryCharacterCombatColumns.characterId] = characterId;
            hCC[(byte)HistoryCharacterCombatColumns.blocks] = blocks;
            hCC[(byte)HistoryCharacterCombatColumns.blocked] = blocked;
            hCC[(byte)HistoryCharacterCombatColumns.strikesReceived] = strikesReceived;
            hCC[(byte)HistoryCharacterCombatColumns.strikesGiven] = strikesGiven;
            hCC[(byte)HistoryCharacterCombatColumns.damageReceived] = damageReceived;
            hCC[(byte)HistoryCharacterCombatColumns.damageGiven] = damageGiven;
            hCC[(byte)HistoryCharacterCombatColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterCombatDataTable.Rows.Add(hCC);
        }
        
        public void AddHistoryCharacterCraftedDataRow(int characterId, byte rarityId, string itemGlobalObjectCode, byte quantity)
        {
            DataRow hCC = _dataTables.HistoryCharacterCraftedDataTable.NewRow();
            hCC[(byte)HistoryCharacterCraftedColumns.characterId] = characterId;
            hCC[(byte)HistoryCharacterCraftedColumns.rarityId] = rarityId;
            hCC[(byte)HistoryCharacterCraftedColumns.itemGlobalObject] = itemGlobalObjectCode;
            hCC[(byte)HistoryCharacterCraftedColumns.quantity] = quantity;
            hCC[(byte)HistoryCharacterCraftedColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterCraftedDataTable.Rows.Add(hCC);
        }
        
        public void AddHistoryCharacterDeathDataRow(int characterId, in Guid killedBySpawnedWorldId, int globalTierId, int globalRankId)
        {
            DataRow hCD = _dataTables.HistoryCharacterDeathsDataTable.NewRow();
            hCD[(byte)HistoryCharacterDeathsColumns.characterId] = characterId;
            hCD[(byte)HistoryCharacterDeathsColumns.killedBySpawnedWorldId] = killedBySpawnedWorldId;
            hCD[(byte)HistoryCharacterDeathsColumns.globalTierId] = globalTierId;
            hCD[(byte)HistoryCharacterDeathsColumns.globalRankId] = globalRankId;
            hCD[(byte)HistoryCharacterDeathsColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterDeathsDataTable.Rows.Add(hCD);
        }
        
        public void AddHistoryCharacterGatheredDataRow(int characterId, string gatherableGlobalObjectCode)
        {
            DataRow hCG = _dataTables.HistoryCharacterGatheredDataTable.NewRow();
            hCG[(byte)HistoryCharacterGatheredColumns.characterId] = characterId;
            hCG[(byte)HistoryCharacterGatheredColumns.gatherableGlobalObject] = gatherableGlobalObjectCode;
            hCG[(byte)HistoryCharacterGatheredColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterGatheredDataTable.Rows.Add(hCG);
        }
        public void AddHistoryCharacterKillsDataRow(int characterId, byte entityTierId, string entityGlobalObjectCode)
        {
            DataRow hCK = _dataTables.HistoryCharacterKillsDataTable.NewRow();
            hCK[(byte)HistoryCharacterKillsColumns.characterId] = characterId;
            //hCK[(byte)HistoryCharacterKillsColumns.] = entityTierId;
            hCK[(byte)HistoryCharacterKillsColumns.entityGlobalObject] = entityGlobalObjectCode;
            hCK[(byte)HistoryCharacterKillsColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterKillsDataTable.Rows.Add(hCK);
        }

        public void AddHistoryCharacterLootedDataRow(int characterId, string itemGlobalObjectCode, byte rarityId, byte quantity)
        {
            DataRow hCL = _dataTables.HistoryCharacterLootDataTable.NewRow();
            hCL[(byte)HistoryCharacterLootColumns.characterId] = characterId;
            hCL[(byte)HistoryCharacterLootColumns.itemGlobalObject] = itemGlobalObjectCode;
            hCL[(byte)HistoryCharacterLootColumns.itemGlobalRarityId] = rarityId;
            hCL[(byte)HistoryCharacterLootColumns.quantity] = quantity;
            hCL[(byte)HistoryCharacterLootColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterLootDataTable.Rows.Add(hCL);
        }
        
        public void AddHistoryCharacterQuestDataRow(int characterId, byte questTypeId, byte questTierId, byte questRankId)
        {
            DataRow hCQ = _dataTables.HistoryCharacterQuestsDataTable.NewRow();
            hCQ[(byte)HistoryCharacterQuestsColumns.characterId] = characterId;
            hCQ[(byte)HistoryCharacterQuestsColumns.questTypeId] = questTypeId;
            hCQ[(byte)HistoryCharacterQuestsColumns.questTierId] = questTierId;
            hCQ[(byte)HistoryCharacterQuestsColumns.questRankId] = questRankId;
            hCQ[(byte)HistoryCharacterQuestsColumns.lastUpdate] = DateTime.Now;
            _dataTables.HistoryCharacterQuestsDataTable.Rows.Add(hCQ);
        }
        public DataRow AddCharactersStatusEffectsDataRow(int characterId, string effectGroupGlobalObject, float remainingDuration, byte stacks)
        {
            DataRow cSE = _dataTables.CharactersStatusEffectsDataTable.NewRow();
            cSE[(byte)CharactersStatusEffectsColumns.characterId]             = characterId;
            cSE[(byte)CharactersStatusEffectsColumns.effectGroupGlobalObject] = effectGroupGlobalObject;
            cSE[(byte)CharactersStatusEffectsColumns.remainingDuration]       = remainingDuration;
            cSE[(byte)CharactersStatusEffectsColumns.stacks]                  = stacks;
            _dataTables.CharactersStatusEffectsDataTable.Rows.Add(cSE);
            return cSE;
        }

        public void AddHistoryCurrencyTransactionsDataRow(in Guid spawnedWorldObjectId, int amountGold, byte amountSilver, byte amountCopper, string description, int tokensAdventurer, int tokensCrafter, int tokensGatherer)
        {
            DataRow hCT = _dataTables.HistoryCurrencyTransactionsDataTable.NewRow();
            hCT[(byte)HistoryCurrencyTransactionsColumns.transactionDate] = DateTime.Now;
            hCT[(byte)HistoryCurrencyTransactionsColumns.spawnedWorldObjectId] = spawnedWorldObjectId;
            hCT[(byte)HistoryCurrencyTransactionsColumns.amount_Gold] = amountGold;
            hCT[(byte)HistoryCurrencyTransactionsColumns.amount_Silver] = amountSilver;
            hCT[(byte)HistoryCurrencyTransactionsColumns.amount_Copper] = amountCopper;
            hCT[(byte)HistoryCurrencyTransactionsColumns.description] = description;
            hCT[(byte)HistoryCurrencyTransactionsColumns.tokens_Adventurer] = tokensAdventurer;
            hCT[(byte)HistoryCurrencyTransactionsColumns.tokens_Gatherer] = tokensGatherer;
            hCT[(byte)HistoryCurrencyTransactionsColumns.tokens_Crafter] = tokensCrafter;
            _dataTables.HistoryCurrencyTransactionsDataTable.Rows.Add(hCT);
        }

        #endregion
    }
}
//#endif