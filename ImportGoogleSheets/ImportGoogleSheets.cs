using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;


namespace RebirthStudios.Editor
{
    public class ImportGoogleSheets
    {
        private static string conString = @"Data Source=localhost\ELYSIUM;User id=Elysium;Password=PoliceBox21;Initial Catalog=Elysium_DEV";

        private string buttonName = "Process All Sheets";
        private bool modeProcessAll = true;
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static SheetsService _service;
        public static string GoogleWorkbookName = "Objects";
        public static string SpreadsheetId = "1WqLY_2W-3U_r3vuZLBWgNRPpVxGZC3ro1nxjufpFifA";
        private static GoogleCredential _credential;
        //private BackgroundWorker backgroundWorker1;
        private bool toggle;
        private string test = "test";
        private bool userCancelled = false;


        private SqlConnection _sqlConnection ;
    
        public void ShowWindow()
        {
            Console.WriteLine("ShowWindow");
            
            InitializeComponent();
            BuildGoogleSheetsList();
            ImportSheets();
        }

        #region OdinFields


        private void ImportSheets()
        {
            //Console.WriteLine("ImportSheets");
            ClearProgress();
            backgroundWorker1_DoWork(this,null);
            toggle = !toggle;
        }
        private void CancelImport()
        {
            userCancelled = true;
            //backgroundWorker1.CancelAsync();
            toggle = !toggle;
        }
        
        public bool specificSheets;

        private void specificSheetsChange()
        {
            if (buttonName == "Process All Sheets")
            {
                modeProcessAll = false;
                buttonName = "Process Specific Sheets";
                BuildGoogleSheetsList();
            }
            else
            {
                modeProcessAll = true;
                buttonName = "Process All Sheets";
            }
            
        }
    
        private void RefreshSheets()
        {
            BuildGoogleSheetsList();
        }
        //[Button(ButtonSizes.Medium), GUIColor(0.905f, 0.435f, 0.317f)]
        private void Items()
        {
            GoogleSheetsToImport = new List<string>() { "globalObjects", "scriptableObjects", "scriptableItems", "scriptableEquipment", "scriptableArmor", "scriptableWeapons", "scriptableMaterials", "scriptableBags", "scriptableGatherables" };
        }
        private void WorldObjects()
        {
            GoogleSheetsToImport = new List<string>() { "globalObjects", "scriptableObjects", "scriptableWorldObjects", "scriptableNPCs", "scriptableMonsters","scriptableInteractables","scriptableEntities","scriptableEnemyHumanoids","scriptableContainers","scriptableAnimals" };
        }
        private void Effects()
        {
            GoogleSheetsToImport = new List<string>() { "globalObjects", "scriptableObjects", "effects", "effectGroups", 
                "effectsToEffectGroupsMapping","effectGroupsToObjectsMapping","effectGroupsToItemsMapping","unlockEffects",
                "statEffects","awardEffects", "experienceEffects"};
        }
        private void Quests()
        {
            GoogleSheetsToImport = new List<string>() { "globalObjects", "scriptableObjects", "scriptableQuests", "scriptableQuestlines", 
                "scriptableQuestExclusions","scriptableQuestObjectives","scriptableQuestlineQuestOrder","unlockEffects",
                "statEffects","awardEffects", "experienceEffects"};
        }
        private void Recipes()
        {
            GoogleSheetsToImport = new List<string>() { "globalObjects", "scriptableObjects", "scriptableRecipes", 
                "scriptableConsumables", "scriptableRecipeIngredients","unlockEffects","effectGroupsToItemsMapping"};
        }
        public List<string> GoogleSheetsToImport = new List<string>() { "globalObjectTypes", "globalObjectSubTypes", "globalObjects", "scriptableObjectTypes", "scriptableObjects", "scriptableItems" };

        private void BuildGoogleSheetsList()
        {
            //Console.WriteLine("BuildGoogleSheetsList");
            string GoogleWorkbookName = "Objects";
            string SpreadsheetId = "1WqLY_2W-3U_r3vuZLBWgNRPpVxGZC3ro1nxjufpFifA";
            var sheets = GetListOfSheets();

            GoogleSheetsToImport = new List<string>();
            foreach (var sheet in sheets)
            {
                GoogleSheetsToImport.Add(sheet);
                //Console.WriteLine($"sheet: {sheet}");
            }
        }

        public int SheetsProcessed;
        public int SheetsRemaining;
        public int SheetsSkipped;
    
    
        public string Status = "";

        public string LastImported = "";
        public string LastUpdate = "";
    
        public int warningCount;
        
        public string LastWarning;
    
        public int errorCount;
        public string LastError;

        public string skippedSheets;
    
        public string erroredSheets;
    
        #endregion
        //public List<string> skippedSheets = new List<string>();

    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _sqlConnection = new SqlConnection(conString);
            _sqlConnection.Open();
            
            //Console.WriteLine("Start Import");
            //SET VARIABLES
            //Status = ("Start ExecuteImportAll");
            LastUpdate = DateTime.Now.ToString("HH:mm:ss");

        
            //GET LIST OF SHEETS
            Status = ("Get list of google sheets");
            var sheetTitles = new List<string>();
            if (modeProcessAll) sheetTitles = GetListOfSheets();
            else sheetTitles = GoogleSheetsToImport;
        
            SheetsRemaining = sheetTitles.Count;
            Console.WriteLine($"SheetsRemaining: {SheetsRemaining}");
            //ORDER IMPORTS DUE TO FOREIGN KEYS
            Dictionary<int, List<string>> orderedSheets = OrderSheets(sheetTitles);
            var orders = orderedSheets.Keys.ToList();
            orders.Sort();
        
            List<string> ranges = new List<string>();
            foreach (var sheet in sheetTitles)
            {
                if(sheet.StartsWith("_") || sheet.StartsWith("ldm")) continue;
                ranges.Add(sheet);
            }
            Dictionary<string, DataTable> Sheets = GetDataFromGoogleSheet(ranges);

            foreach (var order in orders)
            {
                foreach (var sheet in orderedSheets[order])
                {
                    if (sheet.StartsWith("_")) continue;
                    if (userCancelled)
                    {
                        e.Cancel = true;
                        return;
                    }

                    Status     = "Processing: " + sheet;
                    LastUpdate = DateTime.Now.ToString("HH:mm:ss");
                    bool successProcessing                           = false;
                    if (Sheets.ContainsKey(sheet)) successProcessing = ProcessSheet(sheet, Sheets[sheet]);
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ERROR: Sheets doesn't contain {sheet}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (successProcessing)
                    {
                        SheetsProcessed++;
                    }
                    else
                    {
                        SheetsSkipped++;
                        if (SheetsSkipped == 0)
                        {
                            //skippedSheets = sheet.Key;
                        }
                        else
                        {
                            //skippedSheets = skippedSheets + ", " + sheet.Key;
                        }

                    }

                    SheetsRemaining--;
                    //backgroundWorker1.ReportProgress(0);
                    //Thread.Sleep(1500);

                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!userCancelled)
            {
                Status = ("Import Finished");
                toggle = !toggle;
            }
            
            else Status = ("Import Cancelled");
            LastUpdate = DateTime.Now.ToString("HH:mm:ss");
        }
    
        //[OnInspectorInit]
        private void InitializeComponent()
        {
            //Console.WriteLine("InitializeComponent");
            using (var stream = new FileStream($"vast-hash-319621-21781931ac2b.json", FileMode.Open, FileAccess.Read))
            {
                _credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
            // Create Google Sheets API service.
            _service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = GoogleWorkbookName,
            });

            //backgroundWorker1 = new BackgroundWorker();
            //backgroundWorker1.WorkerReportsProgress = true;
            //backgroundWorker1.WorkerSupportsCancellation = true;
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            //backgroundWorker1.ProgressChanged    += BackgroundWorker1_ProgressChanged;
        }

        void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Repaint();
        }

        private void ClearProgress()
        {
            try
            {
                Status = "";
                SheetsProcessed = 0;
                SheetsRemaining = 0;
                SheetsSkipped = 0;
                LastImported = "";
                LastUpdate = "";
                LastWarning = "";
                warningCount = 0;
                LastError = "";
                errorCount = 0;
                skippedSheets = "";
                erroredSheets = "";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error - ClearProgress: {e}");
                throw;
            }
        
        }

        #region ProcessCode
    
        private static Dictionary<int, List<string>> OrderSheets(List<string> sheetTitles)
        {
            Dictionary<int, List<string>> myDict = new Dictionary<int, List<string>>();

            foreach (var sheet in sheetTitles)
            {
                switch (sheet)
                {
                    //int level = 0;
                    case "aggregatedTypes":
                    case "abilityActivationTypes":
                    case "abilityDifficultyTiers":
                    case "abilityEffectTypes":
                    case "abilityRanks":
                    case "abilityTypes":
                    case "abilitySlotTypes":
                    case "abilityStatCostTypes":
                    case "adventuringQuestTypes":
                    case "animalTypes":
                    case "applicationTypes":
                    case "armorSlotTypes":
                    case "armorTypes":
                    case "attributeTypes":
                    case "attributePrimaryTypes":
                    case "attributeSecondaryTypes":
                    case "awardEffectTypes":
                    case "bagTypes":
                    case "bagSubTypes":
                    case "statBaseTypes":
                    case "bodyPartTypes":
                    case "statCalculatedTypes":
                    case "characterCreationStyleTypes":
                    case "conditionTypes":
                    case "consumableTypes":
                    case "containerTypes":
                    case "containerLocationTypes":
                    case "containerQuantityTypes":
                    case "containerRarityTypes":
                    case "costTypes":
                    case "craftingQuestTypes":
                    case "currentStatTypes":
                    case "damageReductionTypes":
                    case "dataAttributeTypes":
                    case "dungeonStructureTypes":
                    case "effectAmountTypes":
                    case "effectTypes":
                    case "effectMainTypes":
                    case "entityTypes":
                    case "entityCombatTypes":
                    case "entityDifficultyTypes":
                    case "entityImbuedTypes":
                    case "elementalTypes":
                    case "enemyHumanoidTypes":
                    case "enemyHumanoidStructureTypes":
                    case "equipmentLocations":
                    case "equipmentTypes":
                    case "equipmentSlotTypes":
                    case "experienceTypes":
                    case "experienceEffectTypes":
                    case "experienceEventTypes":
                    case "gameObjectTypes":
                    case "gatherableTypes":
                    case "gatherableImbuedTypes":
                    case "gatherableLocationTypes":
                    case "gatherableRaritiesTypes":
                    case "gatherableQuantityTypes":
                    case "gatheringQuestTypes":
                    case "gatherTypes":
                    case "genderTypes":
                    case "generalItemTypes":
                    case "ammunitionTypes":
                    case "globalFactions":
                    case "globalObjectSubTypes":
                    case "globalObjectTypes":   
                    case "globalRanks":
                    case "globalStats":
                    case "globalStatuses":
                    case "globalTiers":
                    case "globalSubTiers":
                    case "imbuedTypes":
                    case "interactableTypes":
                    case "itemSubTypes":
                    case "itemTypes":
                    case "jewelryTypes":
                    case "jewelrySlotTypes":
                    case "killTypes":
                    case "lootTypes":
                    case "lootTableTypes":
                    case "materialTypes":
                    case "missionTypes": 
                    case "missionAdventuringTypes": 
                    case "missionCraftingTypes": 
                    case "missionGatheringTypes": 
                    case "missionCategoryTypes": 
                    case "modifierTypes": 
                    case "monsterTypes": 
                    case "statMultiplierTypes": 
                    case "npcTypes": 
                    case "npcSubTypes": 
                    case "questCategoryTypes":
                    case "questObjectiveTypes":
                    case "questRankTypes":
                    case "questRankMainTypes":
                    case "questStatus":
                    case "questMainTiers":
                    case "questTiers":
                    case "questTypes":
                    case "questAdventuringTypes":
                    case "questCraftingTypes":
                    case "questGatheringTypes":
                    case "requirementTypes":
                    case "ruinStructureTypes":
                    case "resistanceTypes":
                    case "scriptableArmorTypeModifiers":
                    case "scriptableObjectTypes":
                    case "scriptableQualities":
                    case "scriptableRarities":
                    case "skillCategories":
                    case "skillDifficultyTiers":
                    case "skillRanks":
                    case "skillTypes":
                    case "socialTypes":
                    case "statEffectAmountTypes":
                    case "structureTypes":
                    case "structureMainTypes":
                    case "targetRestrictionTypes":
                    case "totalTypes":
                    case "unlockEffectTypes":
                    case "villageDefenseTypes":
                    case "villageStructureTypes":
                    case "weaponsBase":
                    case "weaponSlotTypes":
                    case "weaponTypes":
                    case "worldObjectTypes":
                    {
                        if(!myDict.ContainsKey(0)) myDict.Add(0, new List<string>());
                        myDict[0].Add(sheet);
                        break;
                    }
                    
                    case "lootTableMainTypes":
                    {
                        if(!myDict.ContainsKey(1)) myDict.Add(1, new List<string>());
                        myDict[1].Add(sheet);
                        break;
                    }case "consumableClassificationTypes":
                    case "monsterClassificationTypes": 
                    case "structureClassificationTypes":
                    case "npcClassificationTypes": 
                    case "containerClassificationTypes":
                    case "enemyHumanoidClassificationTypes":
                    case "gatherableClassificationTypes":
                    case "generalItemClassificationTypes":
                    case "materialClassificationTypes": 
                    case "animalClassificationTypes":
                    case "ammunitionClassificationTypes":
                    case "bagClassificationTypes":
                    {
                        if(!myDict.ContainsKey(2)) myDict.Add(2, new List<string>());
                        myDict[2].Add(sheet);
                        break;
                    }
                    case "ammunitionSubTypes":
                    case "consumableSubTypes":
                    case "containerSubTypes":
                    case "animalSubTypes":
                    case "effectSubTypes":
                    case "enemyHumanoidSubTypes":
                    case "gatherableSubTypes":
                    case "generalItemSubTypes":
                    case "materialSubTypes": 
                    case "monsterSubTypes": 
                    {
                        if(!myDict.ContainsKey(3)) myDict.Add(3, new List<string>());
                        myDict[3].Add(sheet);
                        break;
                    }
                
                    case "globalObjects":
                    case "statTypes":
                    case "statusEffects":
                    case "scriptableQualityModifiers":
                    case "scriptableRarityModifiers":
                    {
                        if(!myDict.ContainsKey(4)) myDict.Add(4, new List<string>());
                        myDict[4].Add(sheet);
                        break;
                    }
                    case "scriptableObjects":
                    {
                        if(!myDict.ContainsKey(5)) myDict.Add(5, new List<string>());
                        myDict[5].Add(sheet);
                        break;
                    }
                    case "scriptableAbilities":
                    case "scriptableAchievements":
                    case "scriptableTitles":
                    case "scriptableItems":
                    case "scriptableWorldObjects":
                    case "scriptableObjectLevels":
                    case "scriptableObjectRarities":
                    case "scriptableLootTables":
                    case "scriptableStructures":
                    case "scriptableTotals":
                    case "scriptableQuestlines":
                    case "scriptableSkills":
                    case "effects":
                    case "effectGroups":
                    {
                        if(!myDict.ContainsKey(6)) myDict.Add(6, new List<string>());
                        myDict[6].Add(sheet);
                        break;
                    }

                    case "scriptableAbilitiesRanks":
                    case "scriptableAmmunition":
                    case "scriptableArmorSets":
                    case "scriptableBags":
                    case "scriptableConsumables":
                    case "scriptableEntities":
                    case "scriptableEquipment":
                    case "scriptableGeneralItems":
                    case "scriptableInteractables":
                    case "scriptableItemRarities":
                    case "scriptableJewelry":
                    case "scriptableGearSets":
                    case "scriptableMaterials":
                    case "scriptableMilestones":
                    case "scriptableSpawnTables":
                    case "scriptableSkillsGatheringBonus":
                    case "scriptableStructuresDungeons":
                    case "scriptableStructuresEnemyHumanoids":
                    case "scriptableStructuresRanks":
                    case "scriptableStructuresRuins":
                    case "scriptableStructuresVillage":
                    case "scriptableStructuresDefenses":
                    case "scriptableTotalsCollect":
                    case "scriptableTotalsConsume":
                    case "scriptableTotalsCraft":
                    case "scriptableTotalsGather":
                    case "scriptableTotalsKill":
                    case "scriptableWeapons":
                    case "spawnablesToLootTables":
                    case "spawnablesToPrefabs":
                    {
                        if(!myDict.ContainsKey(7)) myDict.Add(7, new List<string>());
                        myDict[7].Add(sheet);
                        break;
                    }
                    case "scriptableAbilitiesRanksActivationCosts":
                    case "scriptableAnimals":
                    case "scriptableArmor":
                    case "scriptableContainers":
                    case "scriptableEnemyHumanoids":
                    case "scriptableEntitiesAttacks":
                    case "scriptableEquipmentRequirements":
                    case "scriptableGatherables":
                    case "scriptableMaterialModifiers":
                    case "scriptableMonsters":
                    case "scriptableNPCs":
                    case "scriptableRecipes":
                    case "scriptableStructuresUpgradeCosts":
                    case "scriptableStructuresUpgradeDetails":
                    case "scriptableStructuresVillageDefenses":
                    case "scriptableQuests":
                    {
                        if(!myDict.ContainsKey(8)) myDict.Add(8, new List<string>());
                        myDict[8].Add(sheet);
                        break;
                    }
                    case "scriptableRecipeIngredients":
                    case "scriptableQuestBoards":
                    case "scriptableQuestGivers":
                    case "scriptableVendors":
                    case "scriptableSpawnTableOptions":
                    case "scriptableRequirements":
                    case "scriptableLootTableDrops":
                    case "scriptableLootTableQuantities":
                    case "scriptableLootTableRarities":
                    case "scriptableLootTablesToLootTable":
                    {
                        if(!myDict.ContainsKey(9)) myDict.Add(9, new List<string>());
                        myDict[9].Add(sheet);
                        break;
                    }
                    case "abilityEvolutions":
                    case "abilityLevelsToObjectLevelsMapping":
                    case "abilityTiers":
                    case "adventurerTiers":
                    case "attributePoints":
                    case "awardEffects":
                    case "bodyPartMultipliers":
                    case "bodyPartPaths":
                    case "characterCreationOptions":
                    case "consumableTiers":
                    case "coreTiers":
                    case "dataAttributesToGlobalObjects":
                    case "effectGroupsToEffectGroupsMapping":
                    case "effectsToEffectGroupsMapping":
                    case "effectGroupsToGearSetsMapping":
                    case "effectGroupsToItemsMapping":
                    case "effectGroupsToObjectsMapping":
                    case "entityStats":
                    case "equipmentBase":
                    case "experienceEffects":
                    case "icons":
                    case "levelRequirements":
                    case "levelRequirementsAbilities":
                    case "levelRequirementsSkills":
                    case "missionObjectives":
                    case "missionObjectivesEntities":
                    case "missionRanks":
                    case "missionRewards":
                    case "potionTiers":
                    case "prefabs":
                    case "questDifficultyRanges":
                    case "scriptableVendorItems":
                    case "scriptableQuestExclusions":
                    case "scriptableQuestObjectives":
                    case "scriptableQuestlineQuestOrder":
                    case "skillDetails":
                    case "skillTiers":
                    case "spellTiers":
                    case "statEffects":
                    case "stats":
                    case "unlockEffects":
                    case "weaponsPositions":
                        if(!myDict.ContainsKey(10)) myDict.Add(10, new List<string>());
                        myDict[10].Add(sheet);
                        //Console.WriteLine($"4Add: {sheet}");
                        break;
                    case "googleSheetNames":
                    case "scriptableIcons":
                    case "scriptablePrefabs":
                    case "Sheet186":
                        break;
                    default:
                    {
                        if (!sheet.Contains("Search"))
                        {
                            Console.WriteLine($"ERROR: {sheet} is not supported.");
                        }
                        if(!myDict.ContainsKey(11)) myDict.Add(11, new List<string>());
                        myDict[11].Add(sheet);
                        //Console.WriteLine($"4Add: {sheet}");
                        break;
                    }
                }
            }

            return myDict;
        }
    
        private List<string> GetListOfSheets()
        {
            /*
        GoogleCredential credential;
        using (var stream = new FileStream("vast-hash-319621-21781931ac2b.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(Scopes);
        }

        // Create Google Sheets API service.
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = GoogleWorkbookName,
        });
        */
            

            var sheet_metadata = _service.Spreadsheets.Get(SpreadsheetId).Execute();
            var sheets = sheet_metadata.Sheets;
            var sheetTitles = new List<string>();
            foreach (var sheet in sheets)
            {
                if(sheet.Properties.Title.StartsWith("_") || sheet.Properties.Title.StartsWith("ldm")) continue;
                if(sheet.Properties.Title.Contains("Searches")) continue;
                sheetTitles.Add(sheet.Properties.Title);
                //var title = sheet.Properties.Title;
                //var sheet_id = sheet.Properties.SheetId;
            }
            return sheetTitles;
        }
    
        private bool ProcessSheet(string tableName, DataTable SheetData)
        {
            //Console.WriteLine($"Start ProcessSheet: {tableName}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            bool successProcessingSheet = false;
            //try
            {
                var recordsInGoogleSheet = SheetData.Rows.Count;
                if (tableName.StartsWith("_")) return false;
                //Console.WriteLine($"Made it past tableName StartsWith _");
                bool tableExists = checkTableExists(tableName);
                //Console.WriteLine($"tableExists: {tableExists}");
                if (tableExists == true) 
                {
                    string SaveStoredProc = "Save" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1);
                    string DeleteStoredProc = "Delete" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1);
                    string RestoreStoredProc = "Restore" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1);
                    string CountStoredProc = "Count" + tableName.Substring(0, 1).ToUpper() + tableName.Substring(1);
                
                    var stopWatch2 = new Stopwatch();
                    stopWatch2.Start();
                
                    //Delete Existing Temp Tables and Stored Procs, they will be re-generated
                    bool blnDeleteExisting = DeleteExisting(SaveStoredProc, tableName, DeleteStoredProc, conString, RestoreStoredProc, CountStoredProc);

                    //Create DeleteStoredProcedure
                    string DeleteQuery = GenerateSQLDeleteCommand(DeleteStoredProc, tableName);
                    bool blnCreateDeleteStoredProc = ExecuteQuery(DeleteQuery, conString);
                    stopWatch2.Stop();
                    //Console.WriteLine($"Delete Stored Proc - {tableName} took {stopWatch2.ElapsedMilliseconds}ms");
                
                    var stopGetGoogleColumnNames = new Stopwatch();
                    stopGetGoogleColumnNames.Start();
                    //Get Google Sheet Column Names
                    int recordsDataTable = SheetData.Rows.Count;
                    List<String> googleColumnNames = GetColumnNamesFromDataTable(SheetData);
                    //List<String> googleColumnNames = GetColumnNamesGoogleSheet(tableName, GoogleWorkbookName, SpreadsheetId);
                    stopGetGoogleColumnNames.Stop();
                    //Console.WriteLine($"stopGetGoogleColumnNames - {tableName} took {stopGetGoogleColumnNames.ElapsedMilliseconds}ms");
                
                    var stopWatch3 = new Stopwatch();
                    stopWatch3.Start();
                    //Get list of SQL columns and data types
                    string[] sqlColumns = getListSQLTableColumns(tableName, conString);
                    //Get list of columns that exist both in SQL and the google sheet
                    string[] sqlColumnMatches = getListColumnMatches(tableName, googleColumnNames, sqlColumns);
                    //Create list of Google Sheet Column Names and data types
                    string[] googleColumnsDataTypes = getListGoogleColumnsAndDataTypes(googleColumnNames, sqlColumns);
                    stopWatch3.Stop();
                    //Console.WriteLine($"stopWatch3 - {tableName} took {stopWatch3.ElapsedMilliseconds}ms");
                
                    //CREATE Temp Table for Import
                    var stopWatch4 = new Stopwatch();
                    stopWatch4.Start();
                    Dictionary<string, string> tmpTable = TempTableFields(googleColumnsDataTypes);
                    string baseQuery = "CREATE TYPE [dbo].[tmp" + tableName + "] AS TABLE(";
                    string query = GenerateSQLCommand(baseQuery, tmpTable);
                    //Console.WriteLine($"query: {query}");
                    bool blnTempTableCreated = CreateTempTable(query, conString);
                    //Console.WriteLine($"blnTempTableCreated: {blnTempTableCreated}");
                    //CREATE Temp Table for Restore Data
                    string baseRestoreQuery = "CREATE TYPE [dbo].[tmpRestore" + tableName + "] AS TABLE(";
                    string queryCreateRestoreTable = GenerateSQLRestoreCommand(baseRestoreQuery, sqlColumns);
                    bool blnTempRestoreTableCreated = CreateTempTable(queryCreateRestoreTable, conString);
                    //Console.WriteLine($"blnTempRestoreTableCreated: {blnTempRestoreTableCreated}");
                    //Generate SQL Command to Import (Save) GoogleSheets Data
                    string parameterTable = "@" + tableName + "Dtl";
                    string tmpTableName = "dbo.tmp" + tableName + " READONLY";
                    if (sqlColumnMatches.Length == 0) throw new NullReferenceException($"{tableName} has 0 matching columns");
                    string SaveQuery = GenerateSQLSaveCommand(SaveStoredProc, parameterTable, tmpTableName, tableName, sqlColumnMatches);
                    stopWatch4.Stop();
                    //Console.WriteLine($"stopWatch4 - {tableName} took {stopWatch4.ElapsedMilliseconds}ms");
                
                
                    var stopWatchRestoreProc = new Stopwatch();
                    stopWatchRestoreProc.Start();
                    //Generate SQL Command to Restore Data if error occurs
                    string parameterRestoreTable = "@" + tableName + "Dtl";
                    string tmpRestoreTableName = "dbo.tmpRestore" + tableName + " READONLY";
                    string RestoreQuery = GenerateSQLRestoreStoredProcedure(RestoreStoredProc, parameterRestoreTable, tmpRestoreTableName, tableName, sqlColumnMatches);
                    stopWatchRestoreProc.Stop();
                    //Console.WriteLine($"stopWatchRestoreProc - {tableName} took {stopWatchRestoreProc.ElapsedMilliseconds}ms");
                
                
                    //Create CountStoredProcedure
                    var stopWatchCountProc = new Stopwatch();
                    stopWatchCountProc.Start();
                    string countQuery = GenerateSQLCountCommand(CountStoredProc, tableName);
                    bool blnCountStpCreated = CreateCountStoredProc(countQuery, conString);
                    stopWatchCountProc.Stop();
                    //Console.WriteLine($"stopWatchCountProc - {tableName} took {stopWatchCountProc.ElapsedMilliseconds}ms");
                
                    var stopWatchBackupData = new Stopwatch();
                    stopWatchBackupData.Start();
                    string sqlRestoreQuery = GenerateSQLRestoreQuery(sqlColumns, tableName);
                    //BACKUP ORIGINAL DATA IN CASE OF ERROR
                    DataTable RestoredData = QueryRestoreData(conString, sqlRestoreQuery);
                    stopWatchBackupData.Stop();
                    //Console.WriteLine($"stopWatchBackupData - {tableName} took {stopWatchBackupData.ElapsedMilliseconds}ms");
                
                    bool blnSaveStoredProc = ExecuteQuery(SaveQuery, conString);
                    bool blnRestoreStoredProc = ExecuteQuery(RestoreQuery, conString);


                    //CREATE DATATABLE FOR GOOGLESHEET DATA
                    var stopWatchGetDataFromGoogle = new Stopwatch();
                    stopWatchGetDataFromGoogle.Start();
                    //DataTable SheetData = GetDataFromGoogleSheet(tableName, GoogleWorkbookName, SpreadsheetId, conString);
                    //int recordsDataTable = SheetData.Rows.Count;
                    stopWatchGetDataFromGoogle.Stop();
                    //Console.WriteLine($"stopWatchGetDataFromGoogle - {tableName} took {stopWatchGetDataFromGoogle.ElapsedMilliseconds}ms");
                
                
                    //Truncate SQL Table before importing data
                    var stopWatchTruncate = new Stopwatch();
                    stopWatchTruncate.Start();
                    DeleteOldData(DeleteStoredProc, tableName, conString);
                    stopWatchTruncate.Stop();
                    //Console.WriteLine($"Truncate - {tableName} took {stopWatchTruncate.ElapsedMilliseconds}ms");
                
                
                    //Execute Save Stored Procedure
                    var stopWatchSaveData = new Stopwatch();
                    stopWatchSaveData.Start();
                    bool success = SaveData(SheetData, SaveStoredProc, tableName, conString);
                    int recordCount = ExecuteCountQuery(CountStoredProc, conString);
                    stopWatchSaveData.Stop();
                    //Console.WriteLine($"Save Data - {tableName} took {stopWatchSaveData.ElapsedMilliseconds}ms");
                    if (success)
                    {
                        LastImported = (tableName + " - " + recordCount + " out of " + (recordsInGoogleSheet) + " records imported");
                    
                        //Check if records imported matches records in google sheet
                        if(recordCount != (recordsInGoogleSheet))
                        {
                            LastError = ("Table: " + tableName + "  Records imported (" + recordCount + ") does not match total records " + (recordsInGoogleSheet) + "  Check row " + (recordCount+1) + " in google sheets for error");
                            if (erroredSheets.Contains(tableName))
                            {
                            
                            }
                            else
                            {
                                erroredSheets = erroredSheets + ", " + tableName;
                                errorCount++;
                            }
                        }
                    }
                
                    successProcessingSheet = success;
                    if (!success)
                    {
                        //RESTORE ORIGINAL DATA
                        //GenerateSQLRestoreStoredProcedure()
                        if (RestoredData.Rows.Count > 0)
                        {
                            Console.WriteLine("Restoring " + RestoredData.Rows.Count + " rows to " + tableName + " table");
                            bool successRestore = RestoreData(RestoredData, RestoreStoredProc, tableName, conString);
                        }
                    }
                    else
                    {
                        UpdateTable(tableName); 
                    }
                
                    var stopWatchDeleteTables = new Stopwatch();
                    stopWatchDeleteTables.Start();
                    //Delete Existing Temp Tables and Stored Procs, they will be re-generated
                    DeleteExisting(SaveStoredProc, tableName, DeleteStoredProc, conString, RestoreStoredProc, CountStoredProc);
                    stopWatchDeleteTables.Stop();
                    //Console.WriteLine($"Delete Tables - {tableName} took {stopWatchDeleteTables.ElapsedMilliseconds}ms");
                }
                else
                {
                    LastWarning             = ("Google Sheet " + tableName + ": NO MATCHING SQL Table");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Warning:{LastWarning}");
                    Console.ForegroundColor =  ConsoleColor.White;
                    skippedSheets           += tableName + ",";
                    warningCount++;
                }
            }
        
        
            // //catch (Exception e)
            // {
            //     //string error = "Skipping Sheet " + tableName + " due to error - " + e.Message;
            //     //Console.WriteLine(error);
            //     LastError = "Skipping Sheet " + tableName + " due to error - " + e.Message;
            //     Console.WriteLine($"{LastError}");
            //     errorCount++;
            //     throw;
            // }

            stopWatch.Stop();
            //Console.WriteLine($"Process Sheet - {tableName} took {stopWatch.ElapsedMilliseconds}ms");
            return successProcessingSheet;
        }
    
        private Dictionary<string,DataTable> GetDataFromGoogleSheet(List<string> ranges)
        {
            Dictionary<string, DataTable> dataTables = new Dictionary<string, DataTable>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int CountRows = 0;
            /*
        GoogleCredential credential;
        using (var stream = new FileStream("vast-hash-319621-21781931ac2b.json", FileMode.Open, FileAccess.Read))
        {
            _credential = GoogleCredential.FromStream(stream)
                .CreateScoped(Scopes);
        }

        // Create Google Sheets API service.
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = _credential,
            ApplicationName = GoogleWorkbookName,
        });
        */
            SpreadsheetsResource.ValuesResource.BatchGetRequest request = _service.Spreadsheets.Values.BatchGet(SpreadsheetId);
            request.Ranges = ranges;

            var response = request.Execute();
            IList<ValueRange> sheets = response.ValueRanges;
            for (int i = 0; i < sheets.Count; i++)
            {
                var values = sheets[i].Values;
                var tableName = sheets[i].Range.Split('!')[0];
                try
                {
                    DataTable SheetData  = GenerateTableStructure(values, tableName, conString);
                
                    if (values.Count > 0)
                    {
                        for (int h = 1; h < values.Count; h++)
                        {
                            var row = values[h];
                            //int dropRate = Int32.Parse(row[4].ToString());
                            DataRow DR = SheetData.NewRow();
                            for (int j = 0; j < SheetData.Columns.Count; j++)
                            {
                                if (j >= row.Count)
                                  {
                                    
                                    Console.WriteLine($"{j}, {row.Count}");
                                    for (int k = 0; k < SheetData.Columns.Count; k++)
                                    {
                                        Console.WriteLine(SheetData.Columns[k].ColumnName);
                                    }
                                    Console.WriteLine(row[j-1]);
                                }
                                
                                if (row[j].ToString() == "#REF!")
                                    throw new Exception(
                                        $"Row {CountRows + 1}, Column {SheetData.Columns[j].ColumnName} contains contain #REF");
                                if (row[j].ToString() == "#N/A")
                                    throw new Exception(
                                        $"Row {CountRows + 1}, Column {SheetData.Columns[j].ColumnName} contains contain #N/A");

                                if (row[j].ToString() == "null") row[j] = "";
                                DR[j] = row[j];

                            }

                            SheetData.Rows.Add(DR);
                        }
                    
                    }

                    else
                    {
                        LastWarning = ("No data found:" + tableName);
                        warningCount++;
                    }

                    dataTables.Add(tableName, SheetData);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("Index was out of range") == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Exception - Sheet: {tableName} {e}");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        LastWarning = ("Method GetDataFromGoogleSheet: Google Sheet " + tableName +
                                       ":  BLANK field(s) on row " + (CountRows + 1) + ". Only first " +
                                       (CountRows - 1) + " will be imported");
                        erroredSheets = erroredSheets + ", " + tableName;
                        warningCount++;
                    }
                    else
                    {
                        LastError = ("Method GetDataFromGoogleSheet: Sheet: " + tableName + "  " + e.Message);
                        Console.WriteLine($"Sheet: " + tableName + $" Method GetDataFromGoogleSheet {(CountRows + 1)}: " + e.Message);
                        erroredSheets = erroredSheets + ", " + tableName;
                        errorCount++;
                    }
                }
            }


            stopWatch.Stop();
            Console.WriteLine($"GetDataFromGoogleSheet - took {stopWatch.ElapsedMilliseconds}ms");
            return dataTables;
        }
    
        private List<string> GetColumnNamesFromDataTable(DataTable tblGoogleData)
        {
            List<string> googleColumnNames = new List<string>();
            try
            {
                foreach(DataColumn column in tblGoogleData.Columns)
                {
                    googleColumnNames.Add(column.ColumnName);
                    //Console.WriteLine($"columnName:{tblGoogleData.TableName} - {column.ColumnName}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetColumnNamesGoogleSheet: {e.Message}");
                LastError = $"Error - GetColumnNamesGoogleSheet: {e}";
                errorCount++;
            }
            

            return googleColumnNames;
        }
    
        private List<string> GetColumnNamesGoogleSheet(string tableName)
        {
            List<string> googleColumnNames = new List<string>();
            //try
            {
            
                SpreadsheetsResource.ValuesResource.GetRequest request = _service.Spreadsheets.Values.Get(SpreadsheetId, $"{tableName}!1:1");
                request.ValueRenderOption = SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum.FORMATTEDVALUE;
                var response = request.Execute();
                IList<IList<object>> values = response.Values;

                //Add Google Sheet Column Names to string array
                //List<string> googleColumnNames = new List<string>();
                foreach (var p in values[0])
                {
                    googleColumnNames.Add(p.ToString());
                }
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"GetColumnNamesGoogleSheet: {e.Message}");
            //     LastError = $"Error - GetColumnNamesGoogleSheet: {e}";
            //     errorCount++;
            // }
            //

            return googleColumnNames;
        }
    
        private void DeleteOldData(string DeleteCommandName, string TableName, string conString)
        {
            //try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = new SqlConnection(conString);
                    _sqlConnection.Open();
                } 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection  = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = DeleteCommandName;
                    cmd.CommandText                                                       = "truncate_non_empty_table";
                    cmd.Parameters.Add("@TableToTruncate", SqlDbType.VarChar, 1000).Value = TableName;
                    //Open Connection
                    //Executing Procedure  
                    cmd.ExecuteNonQuery();

                    //Close Connection
                }
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"DeleteOldData: {e.Message}");
            //     LastError = $"Error - DeleteOldData: {e}";
            //     errorCount++;
            // }
            
        }
    
        private bool SaveData(DataTable GoogleData, string SaveCommandName, string TableName, string conString)
        {
            Boolean   success    = false;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            using (var cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection  = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = SaveCommandName;
                    //Parameter declaration    
                    cmd.Parameters.Add("@" + TableName + "Dtl", SqlDbType.Structured).Value = GoogleData;
                    //Parameter[1].ParameterName = "@Return_Value";
                    //Parameter[1].Direction = ParameterDirection.ReturnValue;
                    //Open Connection
                    //Executing Procedure  
                    cmd.ExecuteNonQuery();
                    success = true;
                    //LastImported = (TableName);
                }
                catch (SqlException e)
                {
                    if (e.Message.Contains("Cannot insert the value NULL") == true)
                    {
                        string columnName = e.Message.Substring(42);
                        int commaLocation = columnName.IndexOf(",");
                        columnName = columnName.Substring(0, commaLocation-1);
                        LastError = ("Google Sheet " + TableName + ": MISSING column " + columnName + " from google sheet " + TableName + ". No data will be imported");
                        erroredSheets = erroredSheets + ", " + TableName;
                        errorCount++;
                    }
                    else
                    {
                        Console.WriteLine("TableName:" + TableName);
                        erroredSheets = erroredSheets + ", " + TableName;
                        Console.WriteLine("SaveData: " + e.Message);
                        LastError = ("SaveData: " + e.Message);
                        errorCount++;
                    }
                    throw;
                }
                finally
                {
                    //Close Connection
                }
            }

            return success;
        }
    
        private bool RestoreData(DataTable RestoreData, string RestoreCommandName, string TableName, string conString)
        {
            Boolean   success    = false;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            using (var cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = _sqlConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = RestoreCommandName;   
                    cmd.Parameters.Add("@" + TableName + "Dtl", SqlDbType.Structured).Value = RestoreData;
                    //Open Connection
                    //Executing Procedure  
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"RestoreData: {e.Message}");
                    LastError = ($"Error - RestoreData: {e}");
                    errorCount++;
                }
                finally
                {
                    //Close Connection
                }
            }

            return success;
        }
    
        private bool checkStoredProcedureExists(string spName, string conString)
        {
            bool spExists = false;
            
            string query = "select * from sysobjects where type='P' and name ='" + spName + "'";
            
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = new SqlConnection(conString);
                    _sqlConnection.Open();
                }

                //Open Connection
                using (var cmd = new SqlCommand(query, _sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spExists = true;
                            break;
                        }
                    }
                }
                //Close Connection
                
            return spExists;
        }
        private bool checkTableExists(string tableName)
        {
            bool tableExists = false;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
                
            //if(_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
            string    query      = "select * from sysobjects where type='U' and name ='" + tableName + "'";
            //Open Connection
            
            using (var cmd = new SqlCommand(query, _sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableExists = true;
                        break;
                    }
                }
            }

            return tableExists;
        }
        private bool checkUserDefinedTableExists(string tableName, string conString)
        {
            bool spExists = false;
      
            string    query      = "Select * FROM SYS.table_types WHERE is_user_defined = 1 AND name = '" + tableName + "'";
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            //Open Connection
            using (var cmd = new SqlCommand(query, _sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spExists = true;
                        break;
                    }
                }
            }
           
        
            return spExists;
        }

        private bool UpdateTable(string tableName)
        {
            bool      querySuccess = false;
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            //Open Connection
            using (var cmd = new SqlCommand())
            {
                cmd.Connection                                                     = _sqlConnection;
                cmd.CommandType                                                    = CommandType.StoredProcedure;
                cmd.CommandText                                                    = "spUpdateTable";
                cmd.Parameters.Add("@tableName", SqlDbType.VarChar, 1000).Value = tableName;
                int qry = cmd.ExecuteNonQuery();
                if (qry == -1)
                {
                    querySuccess = true;
                }
            }
            //Close Connection

            return querySuccess;
        }
        private bool ExecuteQuery(string query, string conString)
        {
            //Console.WriteLine($"ExecuteQuery: {query}, {conString}");
            bool querySuccess = false;
            //Connection String
            
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            //Open Connection
            using (var cmd = new SqlCommand(query, _sqlConnection))
            {
                int qry = cmd.ExecuteNonQuery();
                if (qry == -1)
                {
                    querySuccess = true;
                }
            }

            return querySuccess;
        }
        private int ExecuteCountQuery(string query, string conString)
        {
            int queryCount = 0;
            //Connection String

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            
            using (var cmd = new SqlCommand())
            {
                cmd.Connection  = _sqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                // INPUT PARAMETERS
                // OUTPUT PARAMETERS
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                // EXECUTE Stored Procedure
                //try
                {
                    cmd.ExecuteNonQuery();
                    queryCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    //Console.WriteLine("ExecuteQueryCount: " + queryCount);
                }
                // catch (Exception e)
                // {
                //     LastError = ($"Error - ExecuteCountQuery - query: {query} {e}");
                //     errorCount++;
                //     Console.WriteLine($"ExecuteCountQuery: {e.Message}");
                //     throw;
                // }
               
            }
            
            //Close Connection

            return queryCount;
        }
        private string GenerateSQLCommand(string baseQuery, Dictionary<string, string> sql1)
        {
            string query = baseQuery;

            //try
            {
                foreach (var item in sql1)
                {
                    string strKey;
                    string strValues;

                    strKey = item.Key;
                    strValues = item.Value;
                    query = query + strValues + ", ";
                }
                query = query.Remove(query.Length - 2, 2);
                query = query + ")";
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"GenerateSQLCommand: {e.Message}");
            //     errorCount++;
            // }
            // //Console.WriteLine($"QUERY: {query}");
            return query;
        }
        private string GenerateSQLRestoreCommand(string baseQuery, string[] sqlMatches)
        {
            string query = baseQuery;

            try
            {
                foreach (var item in sqlMatches)
                {
                    var itemSplit = item.Split(',');

                    
                    var columnName = itemSplit[0];
                    var sqlDataType = itemSplit[1];
                    var length = itemSplit[2];
                    var combined = "";
                    if (sqlDataType == "varchar")
                    {
                        combined = columnName + " [varchar](" + length + ") NOT NULL";
                        //sqlDataType = " [varchar](255) NOT NULL";
                    }
                    if (sqlDataType == "int")
                    {
                        combined = columnName + " [int] NOT NULL";
                    }
                    if (sqlDataType == "decimal")
                    {
                        var NUMERIC_SCALE = itemSplit[3];
                        combined = columnName + " [decimal](" + length + "," + NUMERIC_SCALE + ") NOT NULL";
                    }
                    if (sqlDataType == "uniqueidentifier")
                    {
                        combined = columnName + " [uniqueidentifier] NOT NULL";
                    }
                    if (sqlDataType == "bit")
                    {
                        combined = columnName + " [bit] NOT NULL";
                    }
                    if (sqlDataType == "tinyint")
                    {
                        combined = columnName + " [tinyint] NOT NULL";
                    }
                    if (sqlDataType == "smallint")
                    {
                        combined = columnName + " [smallint] NOT NULL";
                    }

                    //string strKey = itemSplit[0];
                    //string strValues = itemSplit[0];


                    query = query + combined + ", ";
                }     

                

                query = query.Remove(query.Length - 2, 2);
                query = query + ")";
            }
            catch (Exception e)
            {
                Console.WriteLine($"GenerateSQLRestoreCommand: {e.Message}");
                errorCount++;
            }
            return query;
        }
        private string GenerateSQLDeleteCommand(string DeleteStoredProc, string tableName)
        {
            string DeleteQuery = "CREATE PROCEDURE [dbo].[" + DeleteStoredProc + "]" + Environment.NewLine + Environment.NewLine + "AS " + Environment.NewLine + "BEGIN" + Environment.NewLine + "   SET NOCOUNT ON " + Environment.NewLine;
            //try
            {
                DeleteQuery = DeleteQuery + Environment.NewLine;
                //DeleteQuery = DeleteQuery + "   TRUNCATE TABLE " + tableName + System.Environment.NewLine + System.Environment.NewLine;
                DeleteQuery = DeleteQuery + "   DELETE FROM " + tableName + Environment.NewLine + Environment.NewLine;
                DeleteQuery = DeleteQuery + "END" + Environment.NewLine;
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"GenerateSQLDeleteCommand: {e.Message}");
            // }
            
            return DeleteQuery;
        }
        private string GenerateSQLRestoreStoredProcedure(string StoredProcName, string parameterTable, string tmpTableName, string tableName, string[] sqlColumnMatches)
        {
            //Console.WriteLine($"GenerateSQLRestoreStoredProcedure: {tableName}");
            //Console.WriteLine(string.Join(",", sqlColumnMatches));
            string SaveQuery = "";
            //try
            {
                SaveQuery = "CREATE PROCEDURE [dbo].[" + StoredProcName + "]" + Environment.NewLine + "   " + parameterTable + " " + tmpTableName + Environment.NewLine + "AS " + Environment.NewLine + "BEGIN" + Environment.NewLine + "   SET NOCOUNT ON " + Environment.NewLine;
                SaveQuery = SaveQuery + Environment.NewLine;
                SaveQuery = SaveQuery + "   INSERT INTO dbo." + tableName + "(";
                //INSERT MATCHING COLUMNS HERE
                foreach (string sqlColName in sqlColumnMatches)
                {
                    var ColName = sqlColName.Split(',');
                    SaveQuery = SaveQuery + ColName[0] + ", ";
                }
                SaveQuery = SaveQuery.Remove(SaveQuery.Length - 2, 2);
                SaveQuery = SaveQuery + ")" + Environment.NewLine;
                SaveQuery = SaveQuery + "   SELECT ";
                //INSERT MATCHING COLUMNS HERE
                foreach (string sqlColName in sqlColumnMatches)
                {
                    var ColName = sqlColName.Split(',');
                    SaveQuery = SaveQuery + ColName[0] + ", ";
                }
                SaveQuery = SaveQuery.Remove(SaveQuery.Length - 2, 2);
                SaveQuery = SaveQuery + " FROM " + parameterTable + Environment.NewLine;
                SaveQuery = SaveQuery + "END";
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"GenerateSQLRestoreStoredProcedure: {e.Message}");
            //     errorCount++;
            // }

            return SaveQuery;
        }
        private string GenerateSQLSaveCommand(string SaveStoredProc, string parameterTable, string tmpTableName, string tableName, string[] sqlColumnMatches)
        {
            string SaveQuery = "";
            try
            {
                SaveQuery = "CREATE PROCEDURE [dbo].[" + SaveStoredProc + "]" + Environment.NewLine + "   " +
                            parameterTable + " " + tmpTableName + Environment.NewLine + "AS " + Environment.NewLine +
                            "BEGIN" + Environment.NewLine + "   SET NOCOUNT ON " + Environment.NewLine;
                SaveQuery = SaveQuery + Environment.NewLine;
                SaveQuery = SaveQuery + "   INSERT INTO dbo." + tableName + "(";
                //INSERT MATCHING COLUMNS HERE
                foreach (string sqlColName in sqlColumnMatches)
                {
                    SaveQuery = SaveQuery + sqlColName + ", ";
                }

                SaveQuery = SaveQuery.Remove(SaveQuery.Length - 2, 2);
                SaveQuery = SaveQuery + ")" + Environment.NewLine;
                SaveQuery = SaveQuery + "   SELECT ";
                //INSERT MATCHING COLUMNS HERE
                foreach (string sqlColName in sqlColumnMatches)
                {
                    SaveQuery = SaveQuery + sqlColName + ", ";
                }

                SaveQuery = SaveQuery.Remove(SaveQuery.Length - 2, 2);
                SaveQuery += " FROM " + parameterTable + Environment.NewLine + $"ORDER BY " + sqlColumnMatches[0] +
                             Environment.NewLine;
                SaveQuery = SaveQuery + "END";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            // catch (Exception e)
            // {
            //     LastError = ($"Error - GenerateSQLSaveCommand: {e}");
            //     errorCount++;
            // }
            
            return SaveQuery;
        }
        private bool CreateTempTable(string query, string conString)
        {
            bool spExists = false;
           
            //try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = new SqlConnection(conString);
                    _sqlConnection.Open();
                } 
                
                //Open Connection
                using (var cmd = new SqlCommand(query, _sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spExists = true;
                            break;
                        }
                    }
                }
                //Close Connection
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"CreateTempTable:  query:{query}  {e.Message} ");
            //     LastError = ($"Error - CreateTempTable: {e.Message}");
            //     errorCount++;
            //     return false;
            // }
            
            return spExists;
        }
        private bool DeleteExisting(string SaveStoredProc, string tableName, string DeleteStoredProc, string conString, string RestoreStoredProc, string CountStoredProc)
        {
            bool blnDeleted = false;
            bool DropSaveStoredProc = false;
            bool blnDropTempTable = false;
            bool blnDropTempRestoreTable = false;
            bool DropDeleteStoredProc = false;
            bool DropRestoreStoredProc = false;
            bool DropCountStoredProc = false;
            //CHECK IF EXISTS AND DELETE
            //Save Stored Proc
            bool spSave = checkStoredProcedureExists(SaveStoredProc, conString);
            if (spSave == true)
            {
                //Delete Existing Query
                string DropStoredProc = "DROP PROCEDURE " + SaveStoredProc;
                //Console.WriteLine("Delete:" + DropStoredProc);
                DropSaveStoredProc = ExecuteQuery(DropStoredProc, conString);
            }
            //Restore Stored Proc
            bool spRestore = checkStoredProcedureExists(RestoreStoredProc, conString);
            if (spRestore == true)
            {
                //Delete Existing Query
                string DropStoredProc = "DROP PROCEDURE " + RestoreStoredProc;
                //Console.WriteLine("Delete:" + DropStoredProc);
                DropRestoreStoredProc = ExecuteQuery(DropStoredProc, conString);
            }
            //Temp Import Table
            //     If exists, delete
            bool blnTempTableExists = checkUserDefinedTableExists("tmp" + tableName, conString);
            if (blnTempTableExists == true)
            {
                string DropTempTable = "DROP TYPE " + "tmp" + tableName;
                //Console.WriteLine("Delete:" + DropTempTable);
                blnDropTempTable = ExecuteQuery(DropTempTable, conString);
            }
            //Temp Restore Table
            //     If exists, delete
            bool blnTempRestoreTableExists = checkUserDefinedTableExists("tmpRestore" + tableName, conString);
            if (blnTempRestoreTableExists == true)
            {
                string DropTempRestoreTable = "DROP TYPE " + "tmpRestore" + tableName;
                //Console.WriteLine("Delete:" + DropTempRestoreTable);
                blnDropTempRestoreTable = ExecuteQuery(DropTempRestoreTable, conString);
            }
            //Delete Stored Proc
            bool spDelete = checkStoredProcedureExists(DeleteStoredProc, conString);
            if (spDelete == true)
            {
                //Delete Existing Query
                string DropStoredProc = "DROP PROCEDURE " + DeleteStoredProc;
                //Console.WriteLine("Delete:" + DropStoredProc);
                DropDeleteStoredProc = ExecuteQuery(DropStoredProc, conString);
            }
            //Count Stored Proc
            //try
            {
                bool spCount = checkStoredProcedureExists(CountStoredProc, conString);
                if (spCount == true)
                {
                    //Delete Existing Query
                    string DropStoredProc = "DROP PROCEDURE " + CountStoredProc;
                    //Console.WriteLine("Delete:" + DropStoredProc);
                    DropCountStoredProc = ExecuteQuery(DropStoredProc, conString);
                }
            }
            // catch (Exception e)
            // {
            //     LastError = ($"Method DeleteExisting: CountStoredProc Error - GenerateTableStructure: {e}");
            //     Console.WriteLine(LastError);
            //     errorCount++;
            // }
            
            if (((spSave == false) || ((spSave == true) && (DropSaveStoredProc == true))) && ((spDelete == false) || ((spDelete == true) && (DropDeleteStoredProc == true))))
            {
                if ((blnTempTableExists == false) || (blnDropTempTable == true))
                {
                    blnDeleted = false;
                }
            }
            return blnDeleted;
        }
        private DataTable GenerateTableStructure(IList<IList<object>> values, string tableName, string conString)
        {
            //Console.WriteLine(tableName);
            //CREATE C# DATATABLE
            DataTable SheetData = new DataTable();
            //Add Google Sheet Column Names to string array
            List<string> googleHeaders = new List<string>();
            //try
            {
                foreach (var p in values[0])
                {
                    googleHeaders.Add(p.ToString());
                }
                //Get list of SQL columns and data types
                string[] sqlColumns = getListSQLTableColumns(tableName, conString);
                //Get list of columns that exist both in SQL and the google sheet
                string[] sqlColumnMatches = getListColumnMatches(tableName, googleHeaders, sqlColumns);
                string[] googleColumnsDataTypes = getListGoogleColumnsAndDataTypes(googleHeaders, sqlColumns);

            
                DataColumn column = new DataColumn();
                string columnName;
                string columnDataType;
                //Loop through config file
                foreach (string line in googleColumnsDataTypes)
                {

                    string[] strValue = line.ToString().Split(',');
                    column = new DataColumn();
                    columnName = strValue[0];
                    column.ColumnName = columnName;
                    columnDataType = strValue[1];
                    switch (columnDataType)
                    {
                        case "string":
                            column.DataType = typeof(string);
                            break;
                        case "int":
                            column.DataType = typeof(int);
                            break;
                        case "float":
                            column.DataType = typeof(float);
                            break;
                        case "Guid":
                            column.DataType = typeof(Guid);
                            break;
                    }

                    SheetData.Columns.Add(column);
                }

                //Set Table Name
                SheetData.TableName = tableName;
            }
            // catch (Exception e)
            // {
            //     LastError = ($"Error - GenerateTableStructure: {e}");
            //     errorCount++;
            // }
       
            return SheetData;
        }
        private string[] getListSQLTableColumns(string tblName, string conString)
        {
            List<string> sqlColumns = new List<string>();
        
            //Query
            string query = "SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tblName + "'";

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Dispose();
                _sqlConnection = new SqlConnection(conString);
                _sqlConnection.Open();
            } 
            //Open Connection
            using (var cmd = new SqlCommand(query, _sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[1].ToString() == "decimal")
                        {
                            sqlColumns.Add(reader[0].ToString() + "," + reader[1].ToString() + "," + reader[3].ToString() + "," + reader[4].ToString());
                        }
                        else
                        {
                            sqlColumns.Add(reader[0].ToString() + "," + reader[1].ToString() + "," + reader[2].ToString());
                        }
                        
                    }
                }
            }
            //Close Connection
            return sqlColumns.ToArray();
        }
        private string[] getListColumnMatches(string tableName, List<string> tmpColumns, string[] sqlColumns)
        {
            List<string> sqlColumnMatches = new List<string>();

            //try
            {
                //Loop through dictionary
                foreach (var item in sqlColumns)
                {
                    string strValue;
                    strValue = item.ToString().Substring(0, item.ToString().IndexOf(","));
                    //Clean up

                    //If value in tmpColumns matches sqlColumns, add to list
                    foreach (string sqlColName in tmpColumns)
                    {

                        if (sqlColName == strValue)
                        {
                            sqlColumnMatches.Add(strValue);
                        }
                    }
                }
            }
            //if(sqlColumnMatches.Count == 0) throw new Exception($"No matching columns found for {tableName}");
            // catch (Exception e)
            // {
            //     Console.WriteLine($"getListColumnMatches: {e.Message}");
            // }
        
            return sqlColumnMatches.ToArray();
        }
        private string[] getListGoogleColumnsAndDataTypes(List<string> tmpColumns, string[] sqlColumns)
        {
            List<string> sqlColumnMatches = new List<string>();

            //try
            {
                foreach (var tmpColName in tmpColumns)
                {
                    bool matchfound = false;
                    foreach (string sqlColName in sqlColumns)
                    {
                        //string strValue;
                        //strValue = sqlColName.Message.Substring(0, sqlColName.Message.IndexOf(","));
                        string[] strValue = sqlColName.ToString().Split(',');

                        if (matchfound == false)
                        {
                            if (tmpColName == strValue[0])
                            {
                                if (strValue[1] == "varchar")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",string");
                                    matchfound = true;
                                }
                                else if (strValue[1] == "int")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",int");
                                    matchfound = true;
                                }
                                else if (strValue[1] == "decimal")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",float");
                                    matchfound = true;
                                }
                                // else if (strValue[1] == "float")
                                // {
                                //     sqlColumnMatches.Add(strValue[0] + ",float");
                                //     matchfound = true;
                                // }
                                else if (strValue[1] == "smallint")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",short");
                                    matchfound = true;
                                }
                                else if (strValue[1] == "uniqueidentifier")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",Guid");
                                    matchfound = true;
                                }
                                else if (strValue[1] == "tinyint")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",byte");
                                    matchfound = true;
                                }
                                else if (strValue[1] == "bit")
                                {
                                    sqlColumnMatches.Add(strValue[0] + ",bool");
                                    matchfound = true;
                                }
                                
                                else Console.WriteLine($"getListGoogleColumnsAndDataTypes: Missing Data Type: {strValue[1]}");
                                //matchfound = true;
                                //sqlColumnMatches.Add(strValue[0] + "," + str);

                            }
                        }
                    

                    }
                    if (matchfound == false)
                    {
                        sqlColumnMatches.Add(tmpColName + ",string");
                    }
                }
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"getListGoogleColumnsAndDataTypes: {e.Message}");
            // }
            // //Loop through dictionary
       
            return sqlColumnMatches.ToArray();
        }
        private Dictionary<string, string> TempTableFields(string[] values)
        {

            Dictionary<string, string> myDict = new Dictionary<string, string>();
            //Loop through config file

            //try
            {
                int iCount = 1;

                object test = values[0];

                foreach (var line in values)
                {
                    string columnName;
                    string sqlDataType = "";
                    string[] strValue = line.ToString().Split(',');
                    columnName = strValue[0];
                    sqlDataType = strValue[1];
                    if (sqlDataType == "string")
                    {
                        sqlDataType = " [varchar](1000) NOT NULL";
                    }
                    if (sqlDataType == "int")
                    {
                        sqlDataType = " [int] NOT NULL";
                    }
                    if (sqlDataType == "short")
                    {
                        sqlDataType = " [smallint] NOT NULL";
                    }
                    if (sqlDataType == "byte")
                    {
                        sqlDataType = " [tinyint] NOT NULL";
                    }
                    if (sqlDataType == "bool")
                    {
                        sqlDataType = " [bit] NOT NULL";
                    }
                    if (sqlDataType == "float")
                    {
                        sqlDataType = " [decimal](18,2) NOT NULL";
                    }
                    if (sqlDataType == "Guid")
                    {
                        sqlDataType = " [uniqueidentifier] NOT NULL";
                    }
                    //Console.WriteLine($"Datatype: {columnName}, {sqlDataType}");

                    myDict.Add(iCount.ToString(), columnName + sqlDataType);
                    iCount += 1;
                }
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"TempTableFields: {e.Message}");
            // }
            //
            return myDict;
        }
        private string GenerateSQLRestoreQuery(string[] sqlColumnMatches, string tableName)
        {
            string sqlQuery = "SELECT";

            foreach (string sqlFieldName in sqlColumnMatches)
            {
                var fieldName = sqlFieldName.Split(',');
                sqlQuery = sqlQuery + " " + (fieldName[0]) + ",";
            }


            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1);
            sqlQuery = sqlQuery + " FROM " + tableName;

            return sqlQuery;
        }
        private DataTable QueryRestoreData(string conString, string sqlBackupQuery)
        {
            var dataTable = new DataTable();
            using (_sqlConnection)
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = _sqlConnection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sqlBackupQuery;
                
                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
            
        }
    
        private string GenerateSQLCountCommand(string CountStoredProc, string tableName)
        {

            string CountQuery = "CREATE PROCEDURE [dbo].[" + CountStoredProc + "]  @RecordCount INT OUTPUT" + Environment.NewLine + Environment.NewLine + "AS " + Environment.NewLine + "BEGIN" + Environment.NewLine + "   SET NOCOUNT ON " + Environment.NewLine;
            CountQuery = CountQuery + Environment.NewLine;
            CountQuery = CountQuery + "   SELECT @RecordCount = COUNT(*) FROM " + tableName + Environment.NewLine + Environment.NewLine;
            CountQuery = CountQuery + "END" + Environment.NewLine;
            return CountQuery;
        }
    
        private bool CreateCountStoredProc(string query, string conString)
        {
            bool spExists = false;
           
            //try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = new SqlConnection(conString);
                    _sqlConnection.Open();
                } 
                //Open Connection
                using (var cmd = new SqlCommand(query, _sqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spExists = true;
                            break;
                        }
                    }
                }
                //Close Connection
            }
            // catch (Exception e)
            // {
            //     LastError = ("Error - CreateTempTable: {e}");
            //     errorCount++;
            // }
            //
            return spExists;
        }
    
        #endregion
    }
}

