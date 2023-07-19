#define SQL_PROFILING 
    using System.Net.Sockets;   
    using System.Text;
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Diagnostics;
    using RebirthStudios.DataAccessLayer;
    using RebirthStudios.DataAccessLayer.Models;
    using RebirthStudios.Enums;
    using RebirthStudios.Enums.Items;

    public class Server_DataTableStoredProcs
        {
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        public static ILogger   _logger;
        public static bool   SOCKET_PROFILING_ENABLED = false;

    	public static byte[]? ScriptableMilestones_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableMilestones_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableMilestones_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableAchievements_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableAchievements_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableAchievements_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableAchievements_PreReqsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableAchievements_PreReqsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableAchievements_PreReqsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTitles_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTitles_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTitles_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTitles_PreReqsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTitles_PreReqsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTitles_PreReqsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetQuestLines(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetQuestLines()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetQuestLines took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetQuestLineOrder(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetQuestLineOrder()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetQuestLineOrder took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_LevelPrerequisitesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_LevelPrerequisitesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_LevelPrerequisitesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_PrerequisitesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_PrerequisitesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_PrerequisitesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetExclusions(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetExclusions()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetExclusions took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableMissions_GetMissionObjectives(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableMissions_GetMissionObjectives()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableMissions_GetMissionObjectives took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableMissions_GetMissionRanks(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableMissions_GetMissionRanks()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableMissions_GetMissionRanks took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetLevelObjectives(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetLevelObjectives()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetLevelObjectives took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetObjectives(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetObjectives()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetObjectives took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableQuests_GetStaticQuests(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableQuests_GetStaticQuests()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableQuests_GetStaticQuests took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableObjects_IconsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableObjects_IconsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableObjects_IconsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_StatsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_StatsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_StatsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_DroppedItemsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_DroppedItemsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_DroppedItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_MailBoxGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_MailBoxGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_MailBoxGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_BankGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_BankGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_BankGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_QuestBoardsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_QuestBoardsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_QuestBoardsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_AnimalsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_AnimalsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_AnimalsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_EnemyHumanoidsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_EnemyHumanoidsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_EnemyHumanoidsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_MonstersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_MonstersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_MonstersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_NpcsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_NpcsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_NpcsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_VendorsItemsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_VendorsItemsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_VendorsItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_VendorsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_VendorsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_VendorsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_QuestGiverQuestsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_QuestGiverQuestsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_QuestGiverQuestsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_QuestGiversGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_QuestGiversGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_QuestGiversGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_PlayersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_PlayersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_PlayersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_GatherablesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_GatherablesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_GatherablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_PrefabsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_PrefabsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_PrefabsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableWorldObjects_ContainersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableWorldObjects_ContainersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableWorldObjects_ContainersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnTables_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnTables_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnTables_OptionsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnTables_OptionsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnTables_OptionsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_AnimalsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_AnimalsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_AnimalsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_ContainersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_ContainersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_ContainersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_MailboxesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_MailboxesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_MailboxesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_BankGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_BankGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_BankGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_DroppedItemsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_DroppedItemsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_DroppedItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_EnemyHumanoidsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_EnemyHumanoidsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_GatherablesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_GatherablesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_GatherablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_MonstersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_MonstersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_MonstersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_NpcsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_NpcsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_NpcsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_QuestGiversGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_QuestGiversGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_QuestGiversGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorInventoriesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorInventoriesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorInventoriesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_AnimalCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_AnimalCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_AnimalCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_AnimalDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_AnimalDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_AnimalDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_ContainerCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_ContainerCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_ContainerCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_ContainerDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_ContainerDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_ContainerDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_EnemyHumanoidCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_EnemyHumanoidCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_EnemyHumanoidDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_EnemyHumanoidDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_GatherableCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_GatherableCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_GatherableCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_GatherableDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_GatherableDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_GatherableDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_InteractableCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_InteractableCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_InteractableCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_InteractableDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_InteractableDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_InteractableDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_MonsterCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_MonsterCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_MonsterCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_MonsterDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_MonsterDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_MonsterDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_NpcCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_NpcCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]), byte.Parse(data[17]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_NpcCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_NpcDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_NpcDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_NpcDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorSellItem(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorSellItem(Guid.Parse(data[0]), int.Parse(data[1]), Guid.Parse(data[2]), int.Parse(data[3]), byte.Parse(data[4]), byte.Parse(data[5]), short.Parse(data[6]), short.Parse(data[7]), short.Parse(data[8]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorSellItem took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorCreate(data[0], float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]), int.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), byte.Parse(data[11]), byte.Parse(data[12]), data[13], bool.Parse(data[14]), uint.Parse(data[15]), Guid.Parse(data[16]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorsInventoryAddItem(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorsInventoryAddItem(Guid.Parse(data[0]), data[1], byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorsInventoryAddItem took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorUpdateQuantity(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorUpdateQuantity(Guid.Parse(data[0]), data[1], byte.Parse(data[2]), short.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorUpdateQuantity took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorRestock(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorRestock(Guid.Parse(data[0]), long.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorRestock took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnedWorldObjects_VendorBuyItem(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnedWorldObjects_VendorBuyItem(Guid.Parse(data[0]), int.Parse(data[1]), Guid.Parse(data[2]), int.Parse(data[3]), short.Parse(data[4]), short.Parse(data[5]), short.Parse(data[6]), short.Parse(data[7]), short.Parse(data[8]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnedWorldObjects_VendorBuyItem took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnerLocations_Overwrite(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnerLocations_Overwrite(JsonConvert.DeserializeObject<List<LocationModel>>(data[0]), JsonConvert.DeserializeObject<List<LocationModel>>(data[1]), JsonConvert.DeserializeObject<List<LocationModel>>(data[2]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnerLocations_Overwrite took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnerLocations_LastDeath(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnerLocations_LastDeath(uint.Parse(data[0]), long.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnerLocations_LastDeath took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnerLocations_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnerLocations_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnerLocations_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SpawnerLocations_RespawnTimersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SpawnerLocations_RespawnTimersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SpawnerLocations_RespawnTimersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddCrafted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddCrafted(int.Parse(data[0]), byte.Parse(data[1]), data[2], byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddCrafted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddDeath(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddDeath(int.Parse(data[0]), Guid.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddDeath took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddGathered(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
             DataTableStoredProcs.Character_HistoryAddGathered(int.Parse(data[0]), data[1]);
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddGathered took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          


            return null;

        }
		public static byte[]? Character_HistoryAddKill(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddKill(int.Parse(data[0]), byte.Parse(data[1]), data[2])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddKill took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddLooted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddLooted(int.Parse(data[0]), data[1], byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddLooted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddQuest(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddQuest(int.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddQuest took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatusEffectsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatusEffectsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatusEffectsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatusEffectsAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatusEffectsAdd(int.Parse(data[0]), data[1], float.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatusEffectsAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatusEffectsUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatusEffectsUpdate(int.Parse(data[0]), data[1], float.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatusEffectsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatusEffectsRemove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatusEffectsRemove(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatusEffectsRemove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ArmorGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ArmorGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_Equipment_InstancedItems_EquipmentGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_Equipment_InstancedItems_EquipmentGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_Equipment_InstancedItems_EquipmentGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ArmorGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ArmorGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ArmorGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_BagsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_BagsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_BagsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_BagsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_BagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ConsumablesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ConsumablesGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ConsumablesGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ConsumablesGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ConsumablesGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_GeneralItemsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_GeneralItemsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_GeneralItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_GeneralItemsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_GeneralItemsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_GeneralItemsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_IngredientsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_IngredientsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_IngredientsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_IngredientsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_IngredientsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_IngredientsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_MaterialsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_MaterialsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_MaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_MaterialsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_MaterialsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_MaterialsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_WeaponsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_WeaponsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_WeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_WeaponsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_WeaponsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_WeaponsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_AmmunitionCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_AmmunitionCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_AmmunitionCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ArmorCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ArmorCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ArmorCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_BagCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_BagCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), byte.Parse(data[8]), Guid.Parse(data[9]), Guid.Parse(data[10]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_BagCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_ConsumableCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_ConsumableCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_ConsumableCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_GeneralItemCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_GeneralItemCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_GeneralItemCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_MaterialCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_MaterialCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_MaterialCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_WeaponCreate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_WeaponCreate(data[0], byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), float.Parse(data[4]), bool.Parse(data[5]), data[6], bool.Parse(data[7]), Guid.Parse(data[8]), Guid.Parse(data[9]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_WeaponCreate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_IngredientAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_IngredientAdd(Guid.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_IngredientAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_DurabilityUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_DurabilityUpdate(Guid.Parse(data[0]), float.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_DurabilityUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? InstancedItems_IsLooted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.InstancedItems_IsLooted(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.InstancedItems_IsLooted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Abilities_RanksGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Abilities_RanksGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Abilities_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Abilities_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Abilities_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Abilities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? AbilityExperienceRequired_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.AbilityExperienceRequired_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.AbilityExperienceRequired_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? AbilityDifficultyMultipliers_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.AbilityDifficultyMultipliers_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.AbilityDifficultyMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? AwardEffects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.AwardEffects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.AwardEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? BodyPartMultipliers_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.BodyPartMultipliers_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.BodyPartMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? BodyPartPaths_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.BodyPartPaths_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.BodyPartPaths_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ExperienceEffects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ExperienceEffects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ExperienceEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableObjects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableObjects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableObjects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LevelRequirement_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LevelRequirement_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LevelRequirement_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LevelRequirementSkills_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LevelRequirementSkills_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LevelRequirementSkills_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LootTables_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LootTables_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LootTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LootTables_DropsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LootTables_DropsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LootTables_DropsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LootTables_RaritiesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LootTables_RaritiesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LootTables_RaritiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LootTables_QuantitiesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LootTables_QuantitiesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LootTables_QuantitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Qualities_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Qualities_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Qualities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Qualities_ModifiersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Qualities_ModifiersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Qualities_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Rarities_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Rarities_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Rarities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Rarities_ModifiersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Rarities_ModifiersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Rarities_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Recipes_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Recipes_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Recipes_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Recipes_GetIngredients(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Recipes_GetIngredients()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Recipes_GetIngredients took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Recipes_GetProducts(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Recipes_GetProducts()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Recipes_GetProducts took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? StatEffects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.StatEffects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.StatEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SkillExperienceRequired_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SkillExperienceRequired_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SkillExperienceRequired_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? SkillDifficultyMultipliers_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.SkillDifficultyMultipliers_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.SkillDifficultyMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? StatusEffects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.StatusEffects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.StatusEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? StatusEffect_EffectsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.StatusEffect_EffectsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.StatusEffect_EffectsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Skills_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Skills_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Skills_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? UnlockEffects_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.UnlockEffects_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.UnlockEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? WeaponPositions_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.WeaponPositions_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.WeaponPositions_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_ArmorGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_ArmorGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_ArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_JeweleryGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_JeweleryGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_JeweleryGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_EquipmentRequirementsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_EquipmentRequirementsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_EquipmentRequirementsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_BagsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_BagsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_ConsumablesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_ConsumablesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_ConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableEntities_AbilitiesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableEntities_AbilitiesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableEntities_AbilitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_GeneralGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_GeneralGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_GeneralGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_MaterialsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_MaterialsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_MaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableMaterials_ModifiersGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableMaterials_ModifiersGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableMaterials_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableItems_WeaponsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableItems_WeaponsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableItems_WeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableInteractables_RanksGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableInteractables_RanksGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableInteractables_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableEntities_RanksGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableEntities_RanksGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableEntities_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_MilestonesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_MilestonesGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_MilestonesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_KillsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_KillsGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_KillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_GatherGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_GatherGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_GatherGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_CraftGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_CraftGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_CraftGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? ScriptableTotals_CollectGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.ScriptableTotals_CollectGetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.ScriptableTotals_CollectGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BagsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BagsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BagsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BagsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BuybacksGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BuybacksGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BuybacksGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_EquipmentGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_EquipmentGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_EquipmentGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_EquipmentGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_EquipmentGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_EquipmentGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryArmorGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryArmorGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryArmorGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryArmorGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryArmorGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryConsumablesGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryConsumablesGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryConsumablesGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryConsumablesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryConsumablesGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryGeneralItemsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryGeneralItemsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryGeneralItemsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryGeneralItemsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryGeneralItemsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryGeneralItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryMaterialsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryMaterialsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryMaterialsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryMaterialsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryMaterialsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryMaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryWeaponsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryWeaponsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryWeaponsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryWeaponsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryWeaponsGetList(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryWeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailAttachmentsGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailAttachmentsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailAttachmentsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailGetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MissionsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MissionsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MissionsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestsObjectivesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestsObjectivesGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestsObjectivesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_RecipesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_RecipesGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_RecipesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_SkillsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_SkillsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_SkillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_TitlesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_TitlesGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_TitlesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AchievementsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AchievementsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AchievementsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? PlayerAccount_Create(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.PlayerAccount_Create(data[0], data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.PlayerAccount_Create took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? PlayerAccount_ResetPassword(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.PlayerAccount_ResetPassword(data[0], data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.PlayerAccount_ResetPassword took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AbilitiesAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AbilitiesAdd(int.Parse(data[0]), data[1], ushort.Parse(data[2]), int.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AbilitiesAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AbilitiesUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AbilitiesUpdate(int.Parse(data[0]), data[1], ushort.Parse(data[2]), int.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AbilitiesUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AchievementsUnlock(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AchievementsUnlock(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AchievementsUnlock took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_Create(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_Create(int.Parse(data[0]), data[1], int.Parse(data[2]), float.Parse(data[3]), float.Parse(data[4]), float.Parse(data[5]), int.Parse(data[6]), float.Parse(data[7]), float.Parse(data[8]), float.Parse(data[9]), float.Parse(data[10]), float.Parse(data[11]), float.Parse(data[12]), int.Parse(data[13]), int.Parse(data[14]), int.Parse(data[15]), int.Parse(data[16]), int.Parse(data[17]), int.Parse(data[18]), data[19], data[20], data[21], data[22], float.Parse(data[23]), float.Parse(data[24]), float.Parse(data[25]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_Create took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BagAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BagAdd(Guid.Parse(data[0]), Guid.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BagAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BagRemove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BagRemove(Guid.Parse(data[0]), byte.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BagRemove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BuybacksAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BuybacksAdd(int.Parse(data[0]), Guid.Parse(data[1]), long.Parse(data[2]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BuybacksAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_BuybacksRemove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_BuybacksRemove(int.Parse(data[0]), Guid.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_BuybacksRemove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_CurrencyUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_CurrencyUpdate(Guid.Parse(data[0]), int.Parse(data[1]), short.Parse(data[2]), short.Parse(data[3]), short.Parse(data[4]), short.Parse(data[5]), short.Parse(data[6]), data[7])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_CurrencyUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_Delete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_Delete(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_Delete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_EquipmentMove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_EquipmentMove(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_EquipmentMove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_EquipmentRemove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_EquipmentRemove(Guid.Parse(data[0]), byte.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_EquipmentRemove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryAddItem(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryAddItem(Guid.Parse(data[0]), Guid.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryAddItem took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagChangeLocation(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagChangeLocation(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagChangeLocation took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagUnequip(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagUnequip(Guid.Parse(data[0]), byte.Parse(data[1]), Guid.Parse(data[2]), byte.Parse(data[3]), byte.Parse(data[4]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagUnequip took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagEquip(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagEquip(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), Guid.Parse(data[3]), byte.Parse(data[4]), byte.Parse(data[5]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagEquip took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryBagsSwap(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryBagsSwap(Guid.Parse(data[0]), byte.Parse(data[1]), Guid.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryBagsSwap took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryDeleteAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryDeleteAll(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryDeleteAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryEquip(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryEquip(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), byte.Parse(data[4]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryEquip took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryMergeStacks(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryMergeStacks(Guid.Parse(data[0]), Guid.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), byte.Parse(data[4]), byte.Parse(data[5]), byte.Parse(data[6]), byte.Parse(data[7]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryMergeStacks took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryMove(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryMove(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), Guid.Parse(data[3]), byte.Parse(data[4]), byte.Parse(data[5]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryMove took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryRemoveItem(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryRemoveItem(Guid.Parse(data[0]), Guid.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryRemoveItem took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventorySplitStack(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventorySplitStack(Guid.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]), Guid.Parse(data[4]), byte.Parse(data[5]), byte.Parse(data[6]), byte.Parse(data[7]), Guid.Parse(data[8]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventorySplitStack took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_InventoryUpdateQuantity(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_InventoryUpdateQuantity(Guid.Parse(data[0]), byte.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_InventoryUpdateQuantity took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailDelete(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailDelete(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailDelete took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailSend(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailSend(Guid.Parse(data[0]), byte.Parse(data[1]), int.Parse(data[2]), data[3], data[4], data[5], uint.Parse(data[6]), byte.Parse(data[7]), byte.Parse(data[8]), bool.Parse(data[9]), bool.Parse(data[10]), bool.Parse(data[11]), int.Parse(data[12]), long.Parse(data[13]), long.Parse(data[14]), long.Parse(data[15]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailSend took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailSendAttachments(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailSendAttachments(Guid.Parse(data[0]), Guid.Parse(data[1]), byte.Parse(data[2]), long.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailSendAttachments took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailTakeAttachment(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailTakeAttachment(Guid.Parse(data[0]), byte.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailTakeAttachment took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailClaimCurrency(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailClaimCurrency(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailClaimCurrency took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailClaimContents(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailClaimContents(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailClaimContents took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MailRead(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MailRead(Guid.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MailRead took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MissionAbandoned(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MissionAbandoned(int.Parse(data[0]), Guid.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MissionAbandoned took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MissionAccepted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MissionAccepted(int.Parse(data[0]), Guid.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MissionAccepted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_MissionCompleted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_MissionCompleted(int.Parse(data[0]), Guid.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_MissionCompleted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestAbandoned(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestAbandoned(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestAbandoned took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestAccepted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestAccepted(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestAccepted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestInsertObjectives(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestInsertObjectives(data[0], int.Parse(data[1]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestInsertObjectives took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestInsertUpdateObjectives(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestInsertUpdateObjectives(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestInsertUpdateObjectives took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestCompleted(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestCompleted(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestCompleted took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_QuestUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_QuestUpdate(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_QuestUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_RecipeAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_RecipeAdd(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_RecipeAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_SkillsAdd(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_SkillsAdd(int.Parse(data[0]), data[1], ushort.Parse(data[2]), int.Parse(data[3]), byte.Parse(data[4]), byte.Parse(data[5]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_SkillsAdd took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_SkillsUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_SkillsUpdate(int.Parse(data[0]), data[1], int.Parse(data[2]), byte.Parse(data[3]), byte.Parse(data[4]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_SkillsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_TitlesUnlock(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_TitlesUnlock(int.Parse(data[0]), data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_TitlesUnlock took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_SaveExperience(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_SaveExperience(int.Parse(data[0]), int.Parse(data[1]), byte.Parse(data[2]), byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_SaveExperience took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_SaveLocation(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_SaveLocation(Guid.Parse(data[0]), double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]), int.Parse(data[4]), double.Parse(data[5]), double.Parse(data[6]), double.Parse(data[7]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_SaveLocation took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_StatsUpdate(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_StatsUpdate(int.Parse(data[0]), byte.Parse(data[1]), byte.Parse(data[2]), float.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_StatsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryCollectedGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryCollectedGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryCollectedGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryCraftedGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryCraftedGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryCraftedGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryGatheredGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryGatheredGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryGatheredGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryKillsGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryKillsGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryKillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddCollected(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddCollected(int.Parse(data[0]), byte.Parse(data[1]), data[2], byte.Parse(data[3]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddCollected took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_HistoryAddCombat(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_HistoryAddCombat(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_HistoryAddCombat took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? CharacterCreationOptions_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.CharacterCreationOptions_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.CharacterCreationOptions_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? LastUpdatedTables_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.LastUpdatedTables_GetList()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.LastUpdatedTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? PlayerAccount_GetPassword(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.PlayerAccount_GetPassword(data[0], data[1])));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.PlayerAccount_GetPassword took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_GetAll(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_GetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_GetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_GetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_GetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_GetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_GetInfo(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_GetInfo(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_GetInfo took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AbilitiesGetList(string[] data)
        {


            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AbilitiesGetList(int.Parse(data[0]))));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AbilitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          

            return bytes;

        }
		public static byte[]? Character_AttributePointsGetAll(string[] data)
        {

		
            if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject( DataTableStoredProcs.Character_AttributePointsGetAll()));
            if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ServerSocket.Character_AttributePointsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
            if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();          
            
            return bytes;


        }

        }