using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using RebirthStudios.Enums;
using RebirthStudios.Enums.Abilities;
using RebirthStudios.Enums.Elements;
using RebirthStudios.Enums.Items;
using RebirthStudios.Enums.Items.Weapons;
using RebirthStudios.Enums.Skills;
using RebirthStudios.Enums.Stats;
using RebirthStudios.Enums.WorldObjects;
using RebirthStudios.ScriptableObjects;

namespace RebirthStudios.DataAccessLayer.Enums
{
    //#if UNITY_EDITOR && (!NET_STANDARD_2_1 || !NETSTANDARD2_1)
    /// <summary>
    /// WARNING ONLY WORKS IN EDITOR AND NOT IN BUILDS DUE TO CODE BEING COMPILED INTO ASSEMBLIES
    /// </summary>
    ///
    public static class EnumLoader
    {
        public static void CreateEnums(List<string> tables)
        {
            var files = Directory.GetFiles(sqlEnumDirectory, "*", SearchOption.AllDirectories);
            foreach (var dataTable in tables)
            {
                var first = files.FirstOrDefault(t => t.Contains(dataTable.ToLower()));

                //Debug.Log($"CreateEnums.{dataTable} vs {first}");
                if (first != default)
                {
                    continue;
                }

                var fileName = $"{$"{dataTable[0]}".ToUpper()}{dataTable[1..]}Columns";
                var t = File.CreateText($"{sqlEnumDirectory}/TableColumns/{fileName}.cs");
                //_logger.Log($"Creating {fileName}.cs");
                t.WriteLine($@"namespace RebirthStudios.DataAccessLayer.Enums.TableColumns
{{
    public enum {fileName} : byte
	{{

    }}
}}");
                t.Close();
            }
        }

        private static string gameEnumDirectory = "E:\\Users\\logan\\RiderProjects\\ElysiumDatabase\\ElysiumEnums\\Enums";
        private static string sqlEnumDirectory = "E:\\Users\\logan\\RiderProjects\\ElysiumDatabase\\ElysiumDatabas\\Enums";

        private static ILogger _logger;
        //[Conditional("UNITY_EDITOR")]
        public static void Initialize(ILogger logger, DataTables dataTables)
        {
            _logger = logger;
            _logger.Log("EnumLoader.Initialize");
            //LoadLayers();
            LoadTags();

            #region Table Columns

            List<DataTable> tables = dataTables._dataSet.Tables.Cast<DataTable>().ToList();
      
            CreateEnums(tables.Select(t => t.TableName).ToList());
            
            foreach (var table in tables)
            {
                Dictionary<int, EnumData> enumDatas = new Dictionary<int, EnumData>();
                byte                      i         = 0;
                foreach (DataColumn column in table.Columns)
                {
                    enumDatas.Add(i, new EnumData(column.ColumnName, null!, null!));
                    i++;
                }

                var properName = table.TableName[0].ToString().ToUpper() + table.TableName[1..] + "Columns";
                LoadSqlEnum(properName, enumDatas, false);
            }
            // LoadEnum<CharactersColumns>(, false);
            // LoadEnum<CharactersAbilitiesColumns>(, false);
            // LoadEnum<CharactersAchievementColumns>(, false);
            // LoadEnum<CharactersBuybacksColumns>(, false);
            // LoadEnum<CharactersMailColumns>(, false);
            // LoadEnum<CharactersMailAttachmentsColumns>(, false);
            // LoadEnum<CharactersMissionsColumns>(, false);
            // LoadEnum<CharactersQuestsColumns>(, false);
            // LoadEnum<CharactersQuestObjectivesColumns>(, false);
            // LoadEnum<CharactersRecipesColumns>(, false);
            // LoadEnum<CharactersSkillsColumns>(, false);
            // LoadEnum<CharactersSocialColumns>(, false);
            // LoadEnum<CharactersStatsColumns>(, false);
            // LoadEnum<CharactersTitlesColumns>(, false);
            //
            // LoadEnum<EffectGroupsColumns>(, false);
            // LoadEnum<EffectGroupsToGearSetMappingColumns>(, false);
            // LoadEnum<EffectGroupsToItemsMappingColumns>(, false);
            // LoadEnum<EffectGroupsToObjectsMappingColumns>(, false);
            // LoadEnum<EffectsColumns>(, false);
            // LoadEnum<EffectsToEffectGroupsMappingColumns>(, false);
            //
            // LoadEnum<EntityStatsColumns>(, false);
            // LoadEnum<EquipmentMaterialModifiersColumns>(, false);
            // LoadEnum<EquipmentRequirementGroupsColumns>(, false);
            // LoadEnum<ExperienceEffectsColumns>(, false);
            //
            // LoadEnum<GlobalFactions>(, false);
            // LoadEnum<GlobalObjectsColumns>(, false);
            // LoadEnum<GlobalRanksColumns>(, false);
            // LoadEnum<GlobalStatsColumns>(, false);
            // LoadEnum<GlobalStatusesColumns>(, false);
            // LoadEnum<GlobalTiersColumns>(, false);
            //
            // LoadEnum<HistoryCharacterCollectedColumns>(, false);
            // LoadEnum<HistoryCharacterCombatColumns>(, false);
            // LoadEnum<HistoryCharacterCraftedColumns>(, false);
            // LoadEnum<HistoryCharacterDeathsColumns>(, false);
            // LoadEnum<HistoryCharacterGatheredColumns>(, false);
            // LoadEnum<HistoryCharacterKillsColumns>(, false);
            // LoadEnum<HistoryCharacterLootColumns>(, false);
            // LoadEnum<HistoryCharacterQuestsColumns>(, false);
            // LoadEnum<HistoryCurrencyTransactionsColumns>(, false);
            //
            // LoadEnum<IconsColumns>(, false);
            // LoadEnum<InstancedAmmunitionColumns>(, false);
            // LoadEnum<InstancedArmorColumns>(, false);
            // LoadEnum<InstancedBagsColumns>(, false);
            // LoadEnum<InstancedConsumablesColumns>(, false);
            // LoadEnum<InstancedEquipmentColumns>(, false);
            // LoadEnum<InstancedGeneralItemsColumns>(, false);
            // LoadEnum<InstancedItemsColumns>(DataTableStoredProcs.Tables_InstanceItems_GetColumns(), false);
            // LoadEnum<InstancedItemsIngredientsColumns>(, false);
            // LoadEnum<InstancedMaterialsColumns>(, false);
            // LoadEnum<InstancedMissionsColumns>(, false);
            // LoadEnum<InstancedWeaponsColumns>(, false);
            //
            // LoadEnum<LevelRequirementsColumns>(, false);

            #endregion

            int index = 0;
            LoadEnum<ScriptableItems>(DataTableStoredProcs.ScriptableItems_GetList().Select(t => new EnumData(t.GlobalObject, null, null)).ToDictionary(data =>
            {
                index++;
                return index-1;
            }), false);
            LoadEnum<RarityTypes>(DataTableStoredProcs.RarityTypes_GetList());
            LoadEnum<QualityTypes>(DataTableStoredProcs.QualityTypes_GetList());

            LoadEnum<GlobalObjectTypes>(DataTableStoredProcs.GlobalObjectTypes_GetList());
            LoadEnum<GlobalStatusTypes>(DataTableStoredProcs.GlobalStatuses_GetList());
            LoadEnum<ScriptableObjectTypes>(DataTableStoredProcs.ScriptableObjectTypes_GetList());
            
            LoadEnum<BodyPartTypes>(DataTableStoredProcs.BodyPartTypes_GetList());
            
            LoadEnum<StatTypes>(DataTableStoredProcs.StatTypes_GetList());
            LoadEnum<AttributeTypes>(DataTableStoredProcs.AttributeTypes_GetList());
            LoadEnum<ElementalTypes>(DataTableStoredProcs.ElementalTypes_GetList());
            LoadEnum<BaseStatTypes>(DataTableStoredProcs.BaseStatTypes_GetList(), "Base");
            LoadEnum<StatMultiplierTypes>(DataTableStoredProcs.StatMultiplierTypes_GetList(), "StatMultiplier");
            LoadEnum<CalcStatTypes>(DataTableStoredProcs.CalcStatTypes_GetList(), "Calc");
            LoadEnum<CurrentStatTypes>(DataTableStoredProcs.CurrentStatTypes_GetList());

            LoadEnum<SkillTypes>(DataTableStoredProcs.SkillTypes_GetList());
            
            //0LoadEnum<StatTypes>(DataTableStoredProcs.UseEffectTypes_GetList());
            //LoadEnum<CostValueTypes>(DataTableStoredProcs.AbilityCostTypes_GetList());
            
            LoadEnum<EffectAmountType>(DataTableStoredProcs.EffectAmountTypes_GetList());
            LoadEnum<UseEffectType>(DataTableStoredProcs.UseEffectTypes_GetList());
            LoadEnum<ExperienceEffectType>(DataTableStoredProcs.ExperienceEffectTypes_GetList());
            LoadEnum<UnlockEffectType>(DataTableStoredProcs.UnlockEffectTypes_GetList());
            LoadEnum<AwardEffectType>(DataTableStoredProcs.AwardEffectTypes_GetList());

            LoadEnum<ApplicationTypes>(DataTableStoredProcs.ApplicationTypes_GetList());
            LoadEnum<AbilityTypes>(DataTableStoredProcs.AbilityTypes_GetList());
            LoadEnum<AbilityEffectTypes>(DataTableStoredProcs.AbilityEffectTypes_GetList());
            LoadEnum<AbilityActivationTypes>(DataTableStoredProcs.AbilityActivationTypes_GetList());
            LoadEnum<CostValueTypes>(DataTableStoredProcs.AbilityCostTypes_GetList());
            LoadEnum<ModifierTypes>(DataTableStoredProcs.ModifierTypes_GetList());

            // WORLD OBJECTS
            LoadEnum<WorldObjectTypes>(DataTableStoredProcs.WorldObjectTypes_GetList());
            LoadEnum<InteractableTypes>(DataTableStoredProcs.InteractableTypes_GetList());
            
            LoadEnum<GatherableTypes>(DataTableStoredProcs.GatherableTypes_GetList());
            LoadSubEnum<GatherableClassificationTypes>(DataTableStoredProcs.GatherableClassificationTypes_GetList(), typeof(GatherableTypes));
            LoadSubEnum<GatherableSubTypes>(DataTableStoredProcs.GatherableSubTypes_GetList(), typeof(GatherableClassificationTypes));
            
            LoadEnum<ContainerTypes>(DataTableStoredProcs.ContainerTypes_GetList());
            LoadEnum<EntityTypes>(DataTableStoredProcs.EntityTypes_GetList());
            
            LoadEnum<AnimalTypes>(DataTableStoredProcs.AnimalTypes_GetList());
            LoadSubEnum<AnimalClassificationTypes>(DataTableStoredProcs.AnimalClassificationTypes_GetList(), typeof(AnimalTypes));
            LoadSubEnum<AnimalSubTypes>(DataTableStoredProcs.AnimalSubTypes_GetList(), typeof(AnimalClassificationTypes));
            
            LoadEnum<EnemyHumanoidTypes>(DataTableStoredProcs.EnemyHumanoidTypes_GetList());
            LoadSubEnum<EnemyHumanoidClassificationTypes>(DataTableStoredProcs.EnemyHumanoidClassificationTypes_GetList(), typeof(EnemyHumanoidTypes));
            LoadSubEnum<EnemyHumanoidSubTypes>(DataTableStoredProcs.EnemyHumanoidSubTypes_GetList(), typeof(EnemyHumanoidClassificationTypes));
            
            LoadEnum<MonsterTypes>(DataTableStoredProcs.MonsterTypes_GetList());
            LoadSubEnum<MonsterClassificationTypes>(DataTableStoredProcs.MonsterClassificationTypes_GetList(), typeof(MonsterTypes));
            LoadSubEnum<MonsterSubTypes>(DataTableStoredProcs.MonsterSubTypes_GetList(), typeof(MonsterClassificationTypes));
            LoadEnum<NpcTypes>(DataTableStoredProcs.NpcTypes_GetList());

            // ITEMS
            LoadEnum<ItemTypes>(DataTableStoredProcs.ItemTypes_GetList());
            
            LoadEnum<BagTypes>(DataTableStoredProcs.ConsumableTypes_GetList());
            LoadSubEnum<BagClassificationTypes>(DataTableStoredProcs.ConsumableClassificationTypes_GetList(), typeof(BagTypes));
            LoadSubEnum<BagSubTypes>(DataTableStoredProcs.ConsumableSubTypes_GetList(), typeof(BagClassificationTypes));
            
            LoadEnum<ConsumableTypes>(DataTableStoredProcs.ConsumableTypes_GetList());
            LoadSubEnum<ConsumableClassificationTypes>(DataTableStoredProcs.ConsumableClassificationTypes_GetList(), typeof(ConsumableTypes));
            LoadSubEnum<ConsumableSubTypes>(DataTableStoredProcs.ConsumableSubTypes_GetList(), typeof(ConsumableClassificationTypes));
            
            LoadEnum<MaterialTypes>(DataTableStoredProcs.MaterialTypes_GetList());
            LoadSubEnum<MaterialClassificationTypes>(DataTableStoredProcs.MaterialClassificationTypes_GetList(), typeof(MaterialTypes));
            LoadSubEnum<MaterialSubTypes>(DataTableStoredProcs.MaterialSubTypes_GetList(), typeof(MaterialTypes));
            
            LoadEnum<GeneralItemTypes>(DataTableStoredProcs.GeneralItemTypes_GetList());
            LoadSubEnum<GeneralItemClassificationTypes>(DataTableStoredProcs.GeneralItemClassificationTypes_GetList(), typeof(GeneralItemTypes));
            LoadSubEnum<GeneralItemSubTypes>(DataTableStoredProcs.GeneralItemSubTypes_GetList(), typeof(GeneralItemClassificationTypes));
            
            LoadEnum<EquipmentTypes>(DataTableStoredProcs.EquipmentTypes_GetList());
            LoadEnum<EquipmentSlotTypes>(DataTableStoredProcs.EquipmentSlotTypes_GetList());
            LoadEnum<ArmorSlotTypes>(DataTableStoredProcs.ArmorSlotTypes_GetList());
            LoadEnum<ArmorTypes>(DataTableStoredProcs.ArmorTypes_GetList());
            LoadEnum<JeweleryTypes>(DataTableStoredProcs.JeweleryTypes_GetList());
            LoadEnum<WeaponSlotTypes>(DataTableStoredProcs.WeaponSlotTypes_GetList());
            LoadEnum<WeaponTypes>(DataTableStoredProcs.WeaponTypes_GetList());
          
            // LOOT TABLES
            LoadEnum<LootTableTypes>(DataTableStoredProcs.LootTableTypes_GetList());
            LoadSubEnum<LootTableSubTypes>(DataTableStoredProcs.LootTableSubTypes_GetList(), typeof(LootTableTypes));

            // QUESTS/MISSIONS
            LoadEnum<QuestCategoryTypes>(DataTableStoredProcs.QuestCategoryTypes_GetList());
            LoadEnum<AdventuringQuestTypes>(DataTableStoredProcs.AdventuringQuestTypes_GetList());
            LoadEnum<CraftingQuestTypes>(DataTableStoredProcs.CraftingQuestTypes_GetList());
            LoadEnum<GatheringQuestTypes>(DataTableStoredProcs.GatheringQuestTypes_GetList());
            LoadEnum<RequirementTypes>(DataTableStoredProcs.RequirementTypes_GetList());
            LoadEnum<QuestObjectiveTypes>(DataTableStoredProcs.QuestObjectiveTypes_GetList());
        }

        //[Conditional("UNITY_EDITOR")]
        private static void LoadEnum(string enumName, Dictionary<int, EnumData> enumData, string[] enumPaths, string replaceString = "", 
            bool includeMax = true, string enumAccessType = "public")
        {
            //Console.WriteLine($"LoadEnum: {enumName}");
            if (enumData.Count == 0)
            {
                _logger.LogError($"Enum {enumName} has no data");
                return;
            }
            string enumSize = enumData.Count < 256 ? "byte" : enumData.Count < 65536 ? "ushort" : "uint";
            if (enumPaths.Length > 0)
            {
                foreach (var enumPath in enumPaths)
                {
                    StreamReader reader = new StreamReader(enumPath);
                    string input = reader.ReadToEnd();
                    reader.Dispose();

                    int start = input.IndexOf("{", StringComparison.Ordinal);
                    int end = input.IndexOf("}", StringComparison.Ordinal);
                    string currentData = input.Substring(start + 1, end - start);
                    string newData = $"\n\t{enumAccessType} enum {enumName} : {enumSize}\n";
                    newData += "\t{\n";
                    foreach (var rarityType in enumData)
                    {
                        if(!string.IsNullOrEmpty(rarityType.Value.TypeName)) newData += $"\t\t[RebirthName(\"{rarityType.Value.TypeName}\")]\n";
                        if(!string.IsNullOrEmpty(rarityType.Value.TypeDescription)) newData += $"\t\t[RebirthDescription(\"{rarityType.Value.TypeDescription}\")]\n";
                        string replacedText;
                        if(replaceString != "") replacedText =  rarityType.Value.Type.Replace(replaceString, "");
                        else replacedText = rarityType.Value.Type;
                        newData      += $"\t\t{replacedText} = {rarityType.Key},\n";
                    }
                    if(includeMax) newData += $"\t\tMAX_VALUE = {enumData.Count},\n";

                    newData += "\t}";
                    using (StreamWriter writer = new StreamWriter(enumPath))
                    {
                        {
                            var output = input.Replace(currentData, newData);
                            writer.Write(output);
                        }
                        writer.Close();
                    }

                    reader.DiscardBufferedData();
                }
            }
            else _logger.LogError($"Could not load enum {enumName}.cs");
        }    
        
        [Conditional("UNITY_EDITOR")]
        private static void LoadSubEnum(string enumName, Dictionary<byte, SubEnumData> enumData, string[] enumPaths, Type parentEnum)
        {
            if (enumData.Count == 0)
            {
                _logger.LogError($"Enum {enumName} has no data");
                return;
            }
            if (enumPaths.Length > 0)
            {
                foreach (var enumPath in enumPaths)
                {
                    StreamReader reader = new StreamReader(enumPath);
                    string input = reader.ReadToEnd();
                    reader.Dispose();

                    int start = input.IndexOf("{", StringComparison.Ordinal);
                    int end = input.IndexOf("}", StringComparison.Ordinal);
                    string currentData = input.Substring(start + 1, end - start);
                    string newData = $"\n\t[RebirthChildEnumAttribute(typeof({parentEnum.Name}))]\n\tpublic enum {enumName} : byte\n";
                    newData += "\t{\n";
                    foreach (var rarityType in enumData)
                    {
                        if(!string.IsNullOrEmpty(rarityType.Value.TypeName)) newData += $"\t\t[RebirthName(\"{rarityType.Value.TypeName}\")]\n";
                        if(!string.IsNullOrEmpty(rarityType.Value.TypeDescription)) newData += $"\t\t[RebirthDescription(\"{rarityType.Value.TypeDescription}\")]\n";
                        if(rarityType.Value.SubTypeId > -1) newData += $"\t\t[RebirthSubType({rarityType.Value.SubTypeId})]\n";
                        newData += $"\t\t{rarityType.Value.Type} = {rarityType.Key},\n";
                    }

                    newData += "\t}";
                    using (StreamWriter writer = new StreamWriter(enumPath))
                    {
                        {
                            var output = input.Replace(currentData, newData);
                            writer.Write(output);
                        }
                        writer.Close();
                    }

                    reader.DiscardBufferedData();
                }
            }
            else _logger.LogError($"Could not load enum {enumName}.cs");
        }

        [Conditional("UNITY_EDITOR")]
        public static void LoadSmartEnum(string enumName, Dictionary<byte, string> enumData, string[] enumPaths)
        {
            if (enumPaths.Length > 0)
            {
                foreach (var enumPath in enumPaths)
                {
                    StreamReader reader = new StreamReader(enumPath);
                    string input = reader.ReadToEnd();
                    reader.Dispose();

                    int start = input.IndexOf("{", StringComparison.Ordinal);
                    int end = input.IndexOf("}", StringComparison.Ordinal);
                    string currentData = input.Substring(start + 1, end - start);
                    string newData = $"\tpublic class {enumName} : SmartEnum<{enumName}>\n\t";
                    newData += "{\n";
                    newData += "{\n";
                    foreach (var rarityType in enumData)
                    {
                        newData +=
                            $"\t\tpublic static readonly {enumName} {rarityType.Value} = new {enumName}(\"{rarityType.Value}\", {rarityType.Key}, \"description\");\n";
                    }

                    newData += "\t}";
                    using (StreamWriter writer = new StreamWriter(enumPath))
                    {
                        {
                            var output = input.Replace(currentData, newData);
                            writer.Write(output);
                        }
                        writer.Close();
                    }

                    reader.DiscardBufferedData();
                }
            }
            else _logger.LogError($"Could not load enum {enumName}.cs");
        }

        
        //[Conditional("UNITY_EDITOR")]
        private static void LoadEnum<TEnum>(Dictionary<int, EnumData> enumData, bool includeMax = true)
        {
            string enumName = typeof(TEnum).Name;

            string[] enumPaths = Directory.GetFiles(gameEnumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadEnum(enumName, enumData, enumPaths, "", includeMax);
        }
     
        //[Conditional("UNITY_EDITOR")]
        private static void LoadEnum(string enumName, Dictionary<int, EnumData> enumData, bool includeMax = true)
        {
            string[]   enumPaths = Directory.GetFiles(gameEnumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadEnum(enumName, enumData, enumPaths, null,includeMax);
        }     
        private static void LoadSqlEnum(string enumName, Dictionary<int, EnumData> enumData, bool includeMax = true)
        {
            string[]   enumPaths = Directory.GetFiles(sqlEnumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadEnum(enumName, enumData, enumPaths, "",includeMax, "public");
        }

     
        //[Conditional("UNITY_EDITOR")]
        private static void LoadEnum<TEnum>(Dictionary<int, EnumData> enumData, string replaceString)
        {
            string enumName = typeof(TEnum).Name;

            string[] enumPaths = Directory.GetFiles(gameEnumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadEnum(enumName, enumData, enumPaths, replaceString);
        }
        
        // [Conditional("UNITY_EDITOR")]
        private static void LoadSubEnum<TEnum>(Dictionary<byte, SubEnumData> enumData, Type parentType)
        {
            string enumName = typeof(TEnum).Name;

            string[] enumPaths = Directory.GetFiles(gameEnumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadSubEnum(enumName, enumData, enumPaths, parentType);

        }

        [Conditional("UNITY_EDITOR")]
        public static void LoadLayers()
        {
            #if UNITY_EDITOR
            Dictionary<byte, EnumData> layerNames=new Dictionary<byte, EnumData>();
            for(byte i=0;i<=31;i++) //user defined layers start with layer 8 and unity supports 31 layers
            {
                var layerN=LayerMask.LayerToName(i).Replace(" ", "_"); //get the name of the layer
                if (layerN.Length > 0) //only add the layer if it has been named (comment this line out if you want every layer)
                    layerNames.Add(i, new EnumData(layerN, "", ""));
            }

            string enumName = nameof(UnityLayers);

            string[] enumPaths = Directory.GetFiles(enumDirectory, $"{enumName}.cs", SearchOption.AllDirectories);

            LoadLayerEnum(enumName, layerNames, enumPaths);
            #endif
}
    
        [Conditional("UNITY_EDITOR")]
        private static void LoadLayerEnum(string enumName, Dictionary<byte, EnumData> enumData, string[] enumPaths)
        {
            if (enumData.Count == 0)
            {
                _logger.LogError($"Enum {enumName} has no data");
                return;
            }
            if (enumPaths.Length > 0)
            {
                foreach (var enumPath in enumPaths)
                {
                    StreamReader reader = new StreamReader(enumPath);
                    string input = reader.ReadToEnd();
                    reader.Dispose();

                    int start = input.IndexOf("{", StringComparison.Ordinal);
                    int end = input.IndexOf("}", StringComparison.Ordinal);
                    string currentData = input.Substring(start + 1, end - start);
                    string newData = $"\n\tpublic enum {enumName} : int\n";
                    newData += "\t{\n";
                    foreach (var rarityType in enumData)
                    {
                        newData += $"\t\t{rarityType.Value.Type} = {rarityType.Key},\n";
                    }

                    newData += "\t}";
                    using (StreamWriter writer = new StreamWriter(enumPath))
                    {
                        {
                            var output = input.Replace(currentData, newData);
                            writer.Write(output);
                        }
                        writer.Close();
                    }

                    reader.DiscardBufferedData();
                }
            }
            else _logger.LogError($"Could not load enum {enumName}.cs");
        }

        [Conditional("UNITY_EDITOR")]
        public static void LoadTags()
        {
            #if UNITY_EDITOR 
            Dictionary<byte, EnumData> layerNames=new Dictionary<byte, EnumData>();
            for(byte i=0;i<UnityEditorInternal.InternalEditorUtility.tags.Length;i++) //user defined layers start with layer 8 and unity supports 31 layers
            {
                var layerN=UnityEditorInternal.InternalEditorUtility.tags[i].Replace(" - ", "_").Replace(" ", "_"); //get the name of the layer
                if (layerN.Length > 0) //only add the layer if it has been named (comment this line out if you want every layer)
                    layerNames.Add(i, new EnumData(layerN, "", ""));
            }

            LoadEnum<UnityTags>(layerNames);
            #endif
}
    }
}