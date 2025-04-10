//#if SERVER

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RebirthStudios.DataAccessLayer;

public class QueueReader
{
    public static  ILogger Logger { get;  set; }
    private static string  folderPath = "C:/Users/ericr/AppData/LocalLow/Rebirth Studios/Elysium";
    
    private static int            waitTime     = 60;
    private static string         fullFileName = "";
    public static  string         fileName     = "";
    private static string[]       filePaths;
    private static List<object[]> lines = new List<object[]>();
    private static int            currentFileNumber;
    public static  int            batchRecordsRemaining;
    public static  int            batchTotalRecords;
    public static  int            batchRecordsSkipped;
    public static  int            batchErrors;
    public static  int            batchFilesRemaining;
    public static  int            totalFilesProcessed;
    public static  double         totalSkipped;
    public static  string         status = "";

    private static Thread _queueThread;

    private static DataTables _dataTables;
    public static void Init(DataTableStoredProcs dataTableStoredProcs)
    {
        _dataTables = dataTableStoredProcs._dataTables;
        
        //folderPath  = Application.persistentDataPath;
        _queueThread?.Abort();
        ClearProcessedFiles();
        _queueThread = new Thread(QueueThread);
        _queueThread.Start();
    }

    public static readonly List<Action> executeOnMainThread = new List<Action>();
    private static readonly List<Action> executeCopiedOnMainThread = new List<Action>();
    private static bool actionToExecuteOnMainThread = false;


    /// <summary>Sets an action to be executed on the main thread.</summary>
    /// <param name="_action">The action to be executed on the main thread.</param>
    public static void ExecuteOnMainThread(Action _action)
    {
        if (_action == null)
        {
            Logger.Log("No action to execute on main thread!");
            return;
        }

        lock (executeOnMainThread)
        {
            executeOnMainThread.Add(_action);
            actionToExecuteOnMainThread = true;
        }
    }

    public static void UpdateMain()
    {
        if (actionToExecuteOnMainThread)
        {
            executeCopiedOnMainThread.Clear();
            lock (executeOnMainThread)
            {
                executeCopiedOnMainThread.AddRange(executeOnMainThread);
                executeOnMainThread.Clear();
                actionToExecuteOnMainThread = false;
            }

            for (int i = 0; i < executeCopiedOnMainThread.Count; i++)
            {
                executeCopiedOnMainThread[i]();
            }
        }
    }

    public static void OnApplicationQuit()
    {
        _queueThread?.Abort();
    }

    private static void QueueThread()
    {
        try
        {
            Console.WriteLine($"Queue thread starter. Running at 1 ticks per minute.");
            DateTime nextLoop = DateTime.Now;
            Thread.Sleep(15);
            while (true)
            {
                UpdateMain(); 
                _dataTables.ProcessSqlUpdates();
                
                nextLoop = nextLoop.AddSeconds(.2f);
                if (nextLoop > DateTime.Now) Thread.Sleep(nextLoop - DateTime.Now);
            }    
        }
        catch (Exception e)
        {
            Logger.LogException(e);
            _queueThread?.Abort();
        }
    }

    private static void ClearProcessedFiles()
    {
        var processedFilePaths = Directory.GetFiles(folderPath, "*.processed", SearchOption.TopDirectoryOnly);
        foreach (var file in processedFilePaths) File.Delete(file);
    }

    private static void ClearBatchProgress()
    {
        try
        {
            currentFileNumber = 0;
            fileName = "";

            batchTotalRecords = 0;
            batchFilesRemaining = 0;
            fullFileName = "";
        }
        catch (Exception e)
        {
            Logger.LogError(e.ToString());
        }
    }

    private static void StartProcessingUpdates()
    {
        try
        {
            ClearBatchProgress();
            filePaths = Directory.GetFiles(folderPath, "*.json", SearchOption.TopDirectoryOnly);
            batchFilesRemaining = filePaths.Length;
            batchTotalRecords = 0;
            foreach (var filePathCount in filePaths) batchTotalRecords += File.ReadAllLines(filePathCount).Length;

            batchRecordsRemaining = batchTotalRecords;
            if (batchRecordsRemaining > 0) ProcessNextFile();
            else NoFiles();
        }
        catch (Exception e)
        {
            Logger.LogError($"{MethodBase.GetCurrentMethod()}: {e}");
        }
    }

    private static void NoFiles()
    {
        fileName = "";
        currentFileNumber = 0;
        status = ($"Waiting {waitTime} seconds before checking again");
    }

    private static void ProcessNextFile()
    {
        //FileName = (filePaths[currentFileNumber]);
        try
        {
            batchFilesRemaining--;
            fullFileName = (filePaths[currentFileNumber]);
            fileName = Path.GetFileName(fullFileName);
            lines = JsonConvert.DeserializeObject<List<object[]>>(File.ReadAllText(filePaths[currentFileNumber], Encoding.UTF8));

            status = "Processing File";
            Logger.Log("Processing File: " + filePaths[currentFileNumber]);
            //ProcessSheets();
        }
        catch (Exception e)
        {
            Logger.LogError($"ERROR - ProcessNextFile: {e}");
            Thread.ResetAbort();
        }
    }

    private static void ProcessSheets()
    {
        foreach (var storedProcedure in lines)
        {
            //Handles the user clicking cancel
            try
            {
                /*
                switch (storedProcedure[0])
                {
                    case "Character_SaveExperience":
                    {
                        DataTableStoredProcs.Character_SaveExperience(Guid.Parse((string) storedProcedure[1]),
                            (int) (long)storedProcedure[2], (byte) (long)storedProcedure[3], (byte) (long)storedProcedure[4]);
                        break;
                    }
                    case "Character_SaveLocation":
                    {
                        DataTableStoredProcs.Character_SaveLocation(Guid.Parse((string) storedProcedure[1]),
                            (float) (double) storedProcedure[2],
                            (float) (double) storedProcedure[3], (float) (double) storedProcedure[4], (int) (long)storedProcedure[5],
                            (float) (double) storedProcedure[6], (float) (double) storedProcedure[7], (float) (double) storedProcedure[8]);
                        break;
                    }
                    case "Character_StatUpdate":
                    {
                        DataTableStoredProcs.Character_StatsUpdate(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (float) (double) storedProcedure[4]);
                        break;
                    }
                    case "Character_BagAdd":
                    {
                        DataTableStoredProcs.Character_BagAdd(Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (byte) (long)storedProcedure[3], (byte) storedProcedure[4]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"Character_BagAdd - {returnedValue}"));
                        break;
                    }
                    case "Character_BagRemove":
                    {
                        DataTableStoredProcs.Character_BagRemove(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"Character_BagRemove - {returnedValue}"));
                        break;
                    }

                    case "Character_EquipmentMove":
                    {
                        DataTableStoredProcs.Character_EquipmentMove(Guid.Parse((string) storedProcedure[1]), 
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_InventoryAddItem":
                        DataTableStoredProcs.Character_InventoryAddItem(Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (byte) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4]);
                        break;
                    case "Character_InventoryEquip":
                    {
                        DataTableStoredProcs.Character_InventoryEquip(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (byte) (long)storedProcedure[5]);
                        break;
                    }
                    case "Character_InventoryMove":
                    {
                        DataTableStoredProcs.Character_InventoryMove(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            Guid.Parse((string) storedProcedure[4]), (byte) (long)storedProcedure[5],
                            (byte) (long)storedProcedure[6]);
                        break;
                    }
                    case "Character_InventoryBagChangeLocation":
                    {
                        DataTableStoredProcs.Character_InventoryBagChangeLocation(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_InventoryBagEquip":
                    {
                        DataTableStoredProcs.Character_InventoryBagEquip(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (byte) (long)storedProcedure[5]);
                        break;
                    }
                    case "Character_InventoryUpdateQuantity":
                    {
                        DataTableStoredProcs.Character_InventoryUpdateQuantity(Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2]);
                        break;
                    }
                    case "Character_InventorySplitStack":
                    {
                        DataTableStoredProcs.Character_InventorySplitStack(Guid.Parse((string) storedProcedure[2]), 
                            (byte) (long)storedProcedure[3], (byte) (long)storedProcedure[4],
                            (byte) (long)storedProcedure[5], Guid.Parse((string) storedProcedure[6]), 
                            (byte) (long)storedProcedure[7], (byte) (long)storedProcedure[8], 
                            (byte) (long)storedProcedure[9], Guid.Parse((string) storedProcedure[10]));
                        break;
                    }
                    case "Character_InventoryMergeStacks":
                    {
                        DataTableStoredProcs.Character_InventoryMergeStacks(
                            (byte) (long)storedProcedure[1], (byte) (long)storedProcedure[2],
                            (byte) (long)storedProcedure[3], (byte) (long)storedProcedure[4],
                            (byte) (long)storedProcedure[5], (byte) (long)storedProcedure[6],
                            (byte) (long)storedProcedure[7], (short) (long)storedProcedure[8]);
                        break;
                    }
                    case "Character_InventoryRemoveItem":
                        DataTableStoredProcs.Character_InventoryRemoveItem(conString, Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (byte) (long)storedProcedure[3], (short) (long)storedProcedure[4]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"Character_InventoryRemoveItem - {returnedValue}"));
                        break;
                    case "Character_AbilitiesAdd":
                        DataTableStoredProcs.Character_AbilitiesAdd(conString, Guid.Parse((string) storedProcedure[1]),
                            (string)storedProcedure[2], 0, (int) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5], null);
                        break;
                    case "Character_AbilitiesUpdate":
                        DataTableStoredProcs.Character_AbilitiesUpdate(conString, Guid.Parse((string) storedProcedure[1]),
                            (string)storedProcedure[2], 0, (int)(long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5], null);
                        break;

                    case "Character_SkillsAdd":
                        DataTableStoredProcs.Character_SkillsAdd(Guid.Parse((string) storedProcedure[1]),
                            (string)storedProcedure[2], 0, (int) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (byte) (long)storedProcedure[5]);
                        break;

                    case "Character_SkillsUpdate":
                        DataTableStoredProcs.Character_SkillsUpdate(conString, Guid.Parse((string) storedProcedure[1]),
                            (string)storedProcedure[2], (int) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (byte) (long)storedProcedure[5],
                            (byte) (long)storedProcedure[6], (short) (long)storedProcedure[7], null);
                        break;
                    case "Character_CurrencyUpdate":
                    {
                        DataTableStoredProcs.Character_CurrencyUpdate(conString,
                            Guid.Parse((string) storedProcedure[1]), (int) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5], (short) (long)storedProcedure[6],
                            (short) (long)storedProcedure[7], (string)storedProcedure[8], (byte) (long)storedProcedure[9],
                            (short) (long)storedProcedure[10], null);
                        break;
                    }
                    case "Character_RecipeAdd":
                    {
                        DataTableStoredProcs.Character_RecipeAdd(conString, Guid.Parse((string) storedProcedure[1]),
                            0, (string)storedProcedure[3], 0,
                            (byte) (long) storedProcedure[3], (short) (long)storedProcedure[4], null);
                        break;
                    }
                    case "Character_MailSend":
                    {
                        var success = DataTableStoredProcs.Character_MailSend(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], Guid.Parse((string) storedProcedure[3]),
                            (string)storedProcedure[4], (string)storedProcedure[5],
                            (string)storedProcedure[6], (int) (long)storedProcedure[7], (byte) (long)storedProcedure[8],
                            (byte) (long)storedProcedure[9], (bool) storedProcedure[10],
                            (bool) storedProcedure[11],
                            (bool) storedProcedure[12], Guid.Parse((string) storedProcedure[13]),
                            (DateTime)storedProcedure[14], (DateTime)storedProcedure[15],
                            (DateTime)storedProcedure[16], (byte) (long)storedProcedure[17], (short) (long)storedProcedure[18]);
                        Logger.Log($"Character_MailSend: {success}");
                        break;
                    }

                    case "Character_MailSendAttachments":
                    {
                        DataTableStoredProcs.Character_MailSendAttachments(conString, Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (byte) (long)storedProcedure[3],
                            (DateTime)storedProcedure[4], (byte) (long)storedProcedure[5], (short) (long)storedProcedure[6]);
                        break;
                    }
                    case "Character_MailTakeAttachment":
                    {
                        DataTableStoredProcs.Character_MailTakeAttachment(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5]);
                        break;
                    }
                    case "Character_MailClaimCurrency":
                    {
                        DataTableStoredProcs.Character_MailClaimCurrency(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_MailClaimContents":
                    {
                        DataTableStoredProcs.Character_MailClaimContents(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_MailDelete":
                    {
                        DataTableStoredProcs.Character_MailDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_MailRead":
                    {
                        DataTableStoredProcs.Character_MailRead(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    }
                    case "Character_MissionAccepted":
                    {
                        DataTableStoredProcs.Character_MissionAccepted(conString, Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (DateTime)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5], null);
                        break;
                    }
                    case "Character_MissionAbandoned":
                    {
                        DataTableStoredProcs.Character_MissionAbandoned(conString, Guid.Parse((string) storedProcedure[1]),
                            Guid.Parse((string) storedProcedure[2]), (byte) (long)storedProcedure[3], 
                            (short) (long)storedProcedure[4]);
                        break;
                    }
                    case "Character_QuestAccepted":
                    {
                        DataTableStoredProcs.Character_QuestAccepted(conString, Guid.Parse((string) storedProcedure[1]),
                            (string) storedProcedure[2], (ushort) storedProcedure[3],
                            (byte) (long)storedProcedure[4], (short) (long)storedProcedure[5], null);
                        break;
                    }
                    case "Character_QuestAbandoned":
                    {
                        StoredProcs.Character_QuestAbandoned(conString, Guid.Parse((string) storedProcedure[1]),
                            (string) storedProcedure[2], (ushort) storedProcedure[3], (byte) (long)storedProcedure[4], 
                            (short) (long)storedProcedure[5]);
                        break;
                    }
                    case "SpawnedWorldObjects_AnimalCreate":
                        StoredProcs.SpawnedWorldObjects_AnimalCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3], (float) (double) storedProcedure[4],
                            (int) (long)storedProcedure[5], (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9], 
                            (bool) storedProcedure[10], (byte) (long)storedProcedure[11],
                            Guid.Parse((string) storedProcedure[12]), (byte) (long)storedProcedure[13], (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_AnimalCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_AnimalDelete":
                        StoredProcs.SpawnedWorldObjects_AnimalDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_AnimalDelete - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_EnemyHumanoidCreate":
                        StoredProcs.SpawnedWorldObjects_EnemyHumanoidCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3],
                            (float) (double) storedProcedure[4], (int) (long)storedProcedure[5],
                            (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9],
                            (bool) storedProcedure[10], (byte) (long)storedProcedure[11],
                            Guid.Parse((string) storedProcedure[12]), (byte) (long)storedProcedure[13],
                            (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_EnemyHumanoidDelete":
                        StoredProcs.SpawnedWorldObjects_EnemyHumanoidDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidDelete - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_MonsterCreate":
                        StoredProcs.SpawnedWorldObjects_MonsterCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3],
                            (float) (double) storedProcedure[4], (int) (long)storedProcedure[5],
                            (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9],
                            (bool) storedProcedure[10], (byte) (long)storedProcedure[11],
                            Guid.Parse((string) storedProcedure[12]), (byte) (long)storedProcedure[13],
                            (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_MonsterDelete":
                        StoredProcs.SpawnedWorldObjects_MonsterDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidDelete - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_NpcCreate":
                        var v1 = (string)storedProcedure[1];
                        var v2 = (float) (double) storedProcedure[2];
                        var v3 = (float) (double) storedProcedure[3];
                        var v4 = (float) (double) storedProcedure[4];
                        var v5 = (int) (long)storedProcedure[5];
                        var v6 = (float) (double) storedProcedure[6];
                        var v7 = (float) (double) storedProcedure[7];
                        var v8 = (float) (double) storedProcedure[8];
                        
                        var v9 = storedProcedure[9];
                        Logger.Log(storedProcedure[10] + "," + storedProcedure[10].GetType());
                        var v10 = (bool)storedProcedure[10];
                        var v11 = (byte) (long)storedProcedure[11];
                        Logger.Log(storedProcedure[12] + "," + storedProcedure[12].GetType());
                        var v12 = Guid.Parse((string) storedProcedure[12]);
                        var v13 = (byte) (long)storedProcedure[13];
                        var v14 = (short) (long)storedProcedure[14];
                        
                        StoredProcs.SpawnedWorldObjects_NpcCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3], (float) (double) storedProcedure[4],
                            (int) (long)storedProcedure[5], (float) (double) storedProcedure[6], (float) (double) storedProcedure[7], 
                            (float) (double) storedProcedure[8], (string) storedProcedure[9],
                            (bool) storedProcedure[10], (byte) (long)storedProcedure[11], (byte)(long) storedProcedure[12], 
                            Guid.Parse((string) storedProcedure[13]), (byte) (long)storedProcedure[14], (short) (long)storedProcedure[15], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_NpcDelete":
                        StoredProcs.SpawnedWorldObjects_NpcDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_EnemyHumanoidDelete - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_GatherableCreate":
                        StoredProcs.SpawnedWorldObjects_GatherableCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3], (float) (double) storedProcedure[4],
                            (int) (long)storedProcedure[5], (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9], 
                            (bool) storedProcedure[10],
                            (byte) (long)storedProcedure[11], Guid.Parse((string) storedProcedure[12]),
                            (byte) (long)storedProcedure[13], (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_GatherableCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_GatherableDelete":

                        var v_1 = Guid.Parse((string) storedProcedure[1]);
                        var v_2 = (byte)(long)storedProcedure[2];
                        var v_3 = (short) (long)storedProcedure[3];
                        StoredProcs.SpawnedWorldObjects_GatherableDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    case "SpawnedWorldObjects_ContainerCreate":
                        StoredProcs.SpawnedWorldObjects_ContainerCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3], (float) (double) storedProcedure[4],
                            (int) (long)storedProcedure[5], (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9], 
                            (bool) storedProcedure[10],
                            (byte) (long)storedProcedure[11], Guid.Parse((string) storedProcedure[12]),
                            (byte) (long)storedProcedure[13], (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_ContainerCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_ContainerDelete":
                        StoredProcs.SpawnedWorldObjects_ContainerDelete(conString, Guid.Parse((string) storedProcedure[1]),
                            (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_ContainerDelete - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_InteractableCreate":
                        StoredProcs.SpawnedWorldObjects_InteractableCreate(conString, (string)storedProcedure[1],
                            (float) (double) storedProcedure[2], (float) (double) storedProcedure[3],
                            (float) (double) storedProcedure[4], (int) (long)storedProcedure[5],
                            (float) (double) storedProcedure[6], (float) (double) storedProcedure[7],
                            (float) (double) storedProcedure[8], (string) storedProcedure[9],
                            (bool) storedProcedure[10], (byte) (long)storedProcedure[11],
                            Guid.Parse((string) storedProcedure[12]), (byte) (long)storedProcedure[13],
                            (short) (long)storedProcedure[14], null);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"SpawnedWorldObjects_InteractableCreate - {returnedValue}"));
                        break;
                    case "SpawnedWorldObjects_InteractableDelete":
                        StoredProcs.SpawnedWorldObjects_InteractableDelete(conString,
                            Guid.Parse((string) storedProcedure[1]), (byte) (long)storedProcedure[2], (short) (long)storedProcedure[3]);
                        break;
                    case "InstancedItems_ArmorCreate":
                        StoredProcs.InstancedItems_ArmorCreate(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3], 
                            (byte) (long)storedProcedure[4], (float) (double) storedProcedure[5],
                            (bool) storedProcedure[6], (string) storedProcedure[7], (bool) storedProcedure[8],
                            Guid.Parse((string) storedProcedure[9]), Guid.Parse((string) storedProcedure[10]), 
                            (byte) (long)storedProcedure[11], (short) (long)storedProcedure[12]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"InstancedItems_ArmorCreateCustom - {returnedValue}"));
                        break;
                    case "InstancedItems_BagCreate":
                        StoredProcs.InstancedItems_BagCreate(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3], 
                            (byte) (long)storedProcedure[4], (float) (double) storedProcedure[5], (bool) storedProcedure[7], 
                            (string) storedProcedure[8], (bool) storedProcedure[9], (short) (long)storedProcedure[10], 
                            Guid.Parse((string) storedProcedure[11]), Guid.Parse((string) storedProcedure[12]),
                            (byte) (long)storedProcedure[13], (short) (long)storedProcedure[14]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"InstancedItems_BagCreate - {returnedValue}"));
                        break;
                    case "InstancedItems_ConsumableCreate":
                        StoredProcs.InstancedItems_ConsumableCreate(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3], 
                            (byte) (long)storedProcedure[4], (float) (double) storedProcedure[5], 
                            (bool) storedProcedure[6], (string) storedProcedure[7], (bool) storedProcedure[8],
                            Guid.Parse((string) storedProcedure[9]), Guid.Parse((string) storedProcedure[10]),
                            (byte) (long)storedProcedure[11], (short) (long)storedProcedure[12]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"InstancedItems_ConsumableCreate - {returnedValue}"));
                        break;
                    case "InstancedItems_MaterialCreate":
                        StoredProcs.InstancedItems_MaterialCreate(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3], 
                            (byte) (long)storedProcedure[4], (float) (double) storedProcedure[5], 
                            (bool) storedProcedure[6], (string) storedProcedure[7], 
                            (bool) storedProcedure[8], Guid.Parse((string) storedProcedure[9]), 
                            Guid.Parse((string) storedProcedure[10]), (byte) (long)storedProcedure[11], 
                            (short) (long)storedProcedure[12]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"InstancedItems_MaterialCreate - {returnedValue}"));
                        break;
                    case "InstancedItems_WeaponCreate":
                        StoredProcs.InstancedItems_WeaponCreate(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3], (byte) (long)storedProcedure[4],
                            (float) (double) storedProcedure[5], (bool) storedProcedure[6], (string) storedProcedure[7], 
                            (bool) storedProcedure[8],Guid.Parse((string) storedProcedure[9]),
                            Guid.Parse((string) storedProcedure[10]), (byte) (long)storedProcedure[11],
                            (short) (long)storedProcedure[12]);
                        //Logger.Log(ColoredLogging.GetMessage(ColoredLoggingTypes.SQLStopWatch, $"InstancedItems_WeaponCreateCustom - {returnedValue}"));
                        break;
                    case "InstancedItems_DurabilityUpdate":
                        StoredProcs.InstancedItems_DurabilityUpdate(conString,
                            Guid.Parse((string) storedProcedure[1]), (float) (double) storedProcedure[2],
                            (byte) (long)storedProcedure[3], (short) (long)storedProcedure[4]);
                        break;
                    case "InstancedItems_IngredientAdd":
                    {
                        StoredProcs.InstancedItems_IngredientAdd(conString, Guid.Parse((string) storedProcedure[1]),
                            (string)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (short) (long)storedProcedure[4]);
                        break;
                    }
                    case "Quest_Add":
                    {
                        StoredProcs.Quest_AddGuid(conString, (string)storedProcedure[1],
                            (byte) (long)storedProcedure[2], (byte) (long)storedProcedure[3],
                            (byte) (long)storedProcedure[4], (string)storedProcedure[5],
                            (string)storedProcedure[6], (int) (long)storedProcedure[7],
                            (int) (long)storedProcedure[8], (int) (long)storedProcedure[9],
                            Guid.Parse((string) storedProcedure[10]), (byte) (long)storedProcedure[11],
                            (short) (long)storedProcedure[12], null);
                        break;
                    }
                    default:
                        Logger.LogError($"UNHANDLED: {storedProcedure[0]}");
                        batchRecordsSkipped++;
                        totalSkipped++;
                        break;
                }
                */
            }
            catch (Exception exception)
            {
                Logger.LogError($"ERROR - {storedProcedure[0]}: {exception}, {exception.TargetSite}");
                foreach (var value in exception.Data)
                {
                    Logger.LogError(value.ToString());
                }
            }
        }

        try
        {
            if (fileName != "")
            {
                var splitName = fullFileName.Replace(".done", "");
                File.Move(fullFileName, splitName + ".processed");
                currentFileNumber++; //Increment file number
                totalFilesProcessed++;
            }

            //Logger.Log($"!userCancelled - currentFileNumber:{currentFileNumber}, filePaths.Count:{filePaths.Count}");   
            if (currentFileNumber <= (filePaths.Length - 1)) ProcessNextFile();
            else NoFiles();
        }
        catch (Exception exception)
        {
            Logger.LogError($"ERROR - ProcessNextFile: {exception}");
        }
    }
}

//#endif