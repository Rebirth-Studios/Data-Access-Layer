using System.Net.Sockets;
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Threading;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using RebirthStudios.DataAccessLayer;
    using RebirthStudios.DataAccessLayer.Models;
    using RebirthStudios.Enums;
    using RebirthStudios.Enums.Items;

    public class Client_DataTableStoredProcs
        {
        public static Socket _socket;
        public static byte[] _buffer;
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        public static ILogger   _logger;
        public static bool   SOCKET_PROFILING_ENABLED = false;
        public static bool   SOCKET_DEBUGGING_ENABLED = false;
    	public static Dictionary<string,MilestoneModel> ScriptableMilestones_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableMilestones_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableMilestones_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableMilestones_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,MilestoneModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableMilestones_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,AchievementModel> ScriptableAchievements_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableAchievements_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableAchievements_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableAchievements_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,AchievementModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableAchievements_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>> ScriptableAchievements_PreReqsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableAchievements_PreReqsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableAchievements_PreReqsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableAchievements_PreReqsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableAchievements_PreReqsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,TitleModel> ScriptableTitles_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTitles_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTitles_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTitles_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,TitleModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTitles_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>> ScriptableTitles_PreReqsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTitles_PreReqsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTitles_PreReqsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTitles_PreReqsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTitles_PreReqsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<QuestLineModel> ScriptableQuests_GetQuestLines()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetQuestLines|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetQuestLines: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetQuestLines({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<QuestLineModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetQuestLines took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<string>>> ScriptableQuests_GetQuestLineOrder()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetQuestLineOrder|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetQuestLineOrder: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetQuestLineOrder({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<string>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetQuestLineOrder took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<LevelObjectiveModel>>> ScriptableQuests_LevelPrerequisitesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_LevelPrerequisitesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_LevelPrerequisitesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_LevelPrerequisitesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<LevelObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_LevelPrerequisitesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>> ScriptableQuests_PrerequisitesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_PrerequisitesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_PrerequisitesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_PrerequisitesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_PrerequisitesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<ushort>> ScriptableQuests_GetExclusions()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetExclusions|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetExclusions: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetExclusions({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<ushort>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetExclusions took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<QuestObjectivesModel> ScriptableMissions_GetMissionObjectives()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableMissions_GetMissionObjectives|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableMissions_GetMissionObjectives: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableMissions_GetMissionObjectives({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<QuestObjectivesModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableMissions_GetMissionObjectives took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<QuestRankTypes,MissionRankModel> ScriptableMissions_GetMissionRanks()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableMissions_GetMissionRanks|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableMissions_GetMissionRanks: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableMissions_GetMissionRanks({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<QuestRankTypes,MissionRankModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableMissions_GetMissionRanks took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<LevelObjectiveModel>>> ScriptableQuests_GetLevelObjectives()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetLevelObjectives|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetLevelObjectives: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetLevelObjectives({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<LevelObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetLevelObjectives took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>> ScriptableQuests_GetObjectives()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetObjectives|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetObjectives: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetObjectives({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<QuestObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetObjectives took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,StaticQuestModel> ScriptableQuests_GetStaticQuests()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableQuests_GetStaticQuests|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableQuests_GetStaticQuests: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableQuests_GetStaticQuests({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,StaticQuestModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableQuests_GetStaticQuests took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<RarityTypes,string>> ScriptableObjects_IconsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableObjects_IconsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableObjects_IconsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableObjects_IconsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<RarityTypes,string>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableObjects_IconsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<StatModel>>> ScriptableWorldObjects_StatsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_StatsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_StatsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_StatsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<StatModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_StatsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<InteractableModel> ScriptableWorldObjects_DroppedItemsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_DroppedItemsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_DroppedItemsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_DroppedItemsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<InteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_DroppedItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<InteractableModel> ScriptableWorldObjects_MailBoxGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_MailBoxGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_MailBoxGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_MailBoxGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<InteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_MailBoxGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<InteractableModel> ScriptableWorldObjects_BankGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_BankGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_BankGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_BankGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<InteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_BankGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<QuestBoardModel> ScriptableWorldObjects_QuestBoardsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_QuestBoardsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_QuestBoardsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_QuestBoardsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<QuestBoardModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_QuestBoardsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,AnimalModel> ScriptableWorldObjects_AnimalsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_AnimalsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_AnimalsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_AnimalsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,AnimalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_AnimalsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,EnemyHumanoidModel> ScriptableWorldObjects_EnemyHumanoidsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_EnemyHumanoidsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_EnemyHumanoidsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_EnemyHumanoidsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,EnemyHumanoidModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_EnemyHumanoidsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,MonsterModel> ScriptableWorldObjects_MonstersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_MonstersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_MonstersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_MonstersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,MonsterModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_MonstersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,EntityModel> ScriptableWorldObjects_NpcsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_NpcsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_NpcsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_NpcsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,EntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_NpcsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<VendorItemModel>> ScriptableWorldObjects_VendorsItemsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_VendorsItemsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_VendorsItemsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_VendorsItemsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<VendorItemModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_VendorsItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,VendorModel> ScriptableWorldObjects_VendorsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_VendorsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_VendorsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_VendorsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,VendorModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_VendorsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<string>> ScriptableWorldObjects_QuestGiverQuestsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_QuestGiverQuestsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_QuestGiverQuestsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_QuestGiverQuestsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_QuestGiverQuestsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,EntityModel> ScriptableWorldObjects_QuestGiversGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_QuestGiversGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_QuestGiversGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_QuestGiversGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,EntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_QuestGiversGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<EntityModel> ScriptableWorldObjects_PlayersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_PlayersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_PlayersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_PlayersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<EntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_PlayersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<GatherableModel> ScriptableWorldObjects_GatherablesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_GatherablesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_GatherablesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_GatherablesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<GatherableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_GatherablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<string>> ScriptableWorldObjects_PrefabsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_PrefabsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_PrefabsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_PrefabsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_PrefabsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ContainerModel> ScriptableWorldObjects_ContainersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableWorldObjects_ContainersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableWorldObjects_ContainersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableWorldObjects_ContainersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ContainerModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableWorldObjects_ContainersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnTableModel> SpawnTables_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnTables_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnTables_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnTables_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnTableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<SpawnTableOption>> SpawnTables_OptionsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnTables_OptionsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnTables_OptionsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnTables_OptionsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<SpawnTableOption>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnTables_OptionsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEntityModel> SpawnedWorldObjects_AnimalsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_AnimalsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_AnimalsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_AnimalsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_AnimalsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedContainerModel> SpawnedWorldObjects_ContainersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_ContainersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_ContainersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_ContainersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedContainerModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_ContainersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedInteractableModel> SpawnedWorldObjects_MailboxesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_MailboxesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_MailboxesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_MailboxesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedInteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_MailboxesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedInteractableModel> SpawnedWorldObjects_BankGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_BankGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_BankGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_BankGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedInteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_BankGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedInteractableModel> SpawnedWorldObjects_DroppedItemsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_DroppedItemsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_DroppedItemsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_DroppedItemsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedInteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_DroppedItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEntityModel> SpawnedWorldObjects_EnemyHumanoidsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_EnemyHumanoidsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_EnemyHumanoidsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedInteractableModel> SpawnedWorldObjects_GatherablesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_GatherablesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_GatherablesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_GatherablesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedInteractableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_GatherablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEntityModel> SpawnedWorldObjects_MonstersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_MonstersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_MonstersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_MonstersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_MonstersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEntityModel> SpawnedWorldObjects_NpcsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_NpcsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_NpcsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_NpcsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_NpcsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEntityModel> SpawnedWorldObjects_QuestGiversGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_QuestGiversGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_QuestGiversGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_QuestGiversGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEntityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_QuestGiversGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedVendorModel> SpawnedWorldObjects_VendorsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedVendorModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<VendorInventoryData> SpawnedWorldObjects_VendorInventoriesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorInventoriesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorInventoriesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorInventoriesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<VendorInventoryData>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorInventoriesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_AnimalCreate(string animalGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_AnimalCreate|{animalGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_AnimalCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_AnimalCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_AnimalCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_AnimalDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_AnimalDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_AnimalDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_AnimalDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_AnimalDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_ContainerCreate(string interactableGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_ContainerCreate|{interactableGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_ContainerCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_ContainerCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_ContainerCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_ContainerDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_ContainerDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_ContainerDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_ContainerDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_ContainerDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_EnemyHumanoidCreate(string enemyHumanoidGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_EnemyHumanoidCreate|{enemyHumanoidGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_EnemyHumanoidCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_EnemyHumanoidDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_EnemyHumanoidDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_EnemyHumanoidDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_EnemyHumanoidDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_GatherableCreate(string interactableGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_GatherableCreate|{interactableGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_GatherableCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_GatherableCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_GatherableCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_GatherableDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_GatherableDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_GatherableDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_GatherableDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_GatherableDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_InteractableCreate(string globalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_InteractableCreate|{globalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_InteractableCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_InteractableCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_InteractableCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_InteractableDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_InteractableDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_InteractableDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_InteractableDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_InteractableDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_MonsterCreate(string monsterGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_MonsterCreate|{monsterGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_MonsterCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_MonsterCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_MonsterCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_MonsterDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_MonsterDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_MonsterDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_MonsterDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_MonsterDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_NpcCreate(string npcGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId, byte npcTypeId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_NpcCreate|{npcGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}|{npcTypeId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_NpcCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_NpcCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_NpcCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_NpcDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_NpcDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_NpcDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_NpcDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_NpcDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorSellItem(Guid vendorSpawnedWorldObjectId, int characterId, Guid instancedItemId, int priceGold, byte priceSilver, byte priceCopper, short priceTokenAdventuring, short priceTokenGathering, short priceTokenCrafting)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorSellItem|{vendorSpawnedWorldObjectId}|{characterId}|{instancedItemId}|{priceGold}|{priceSilver}|{priceCopper}|{priceTokenAdventuring}|{priceTokenGathering}|{priceTokenCrafting}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorSellItem: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorSellItem({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorSellItem took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Tuple<bool,string> SpawnedWorldObjects_VendorCreate(string npcGlobalObject, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, byte rank, byte variationId, string prefabId, bool ignoreSpawnTable, uint locationId, Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorCreate|{npcGlobalObject}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{rank}|{variationId}|{prefabId}|{ignoreSpawnTable}|{locationId}|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<bool,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorDelete(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorDelete|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorsInventoryAddItem(Guid spawnedWorldObjectId, string itemGlobalObject, byte rarityId, byte currentStock)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorsInventoryAddItem|{spawnedWorldObjectId}|{itemGlobalObject}|{rarityId}|{currentStock}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorsInventoryAddItem: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorsInventoryAddItem({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorsInventoryAddItem took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorUpdateQuantity(Guid spawnedWorldObjectId, string itemGlobalObject, byte rarityId, short amountChanged)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorUpdateQuantity|{spawnedWorldObjectId}|{itemGlobalObject}|{rarityId}|{amountChanged}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorUpdateQuantity: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorUpdateQuantity({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorUpdateQuantity took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorRestock(Guid spawnedWorldObjectId, long lastRestockTimeBinary)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorRestock|{spawnedWorldObjectId}|{lastRestockTimeBinary}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorRestock: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorRestock({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorRestock took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnedWorldObjects_VendorBuyItem(Guid vendorSpawnedWorldObjectId, int characterId, Guid instancedItemId, int goldChanged, short silverChanged, short copperChanged, short adventuringTokensChanged, short craftingTokensChanged, short gatheringTokensChanged)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnedWorldObjects_VendorBuyItem|{vendorSpawnedWorldObjectId}|{characterId}|{instancedItemId}|{goldChanged}|{silverChanged}|{copperChanged}|{adventuringTokensChanged}|{craftingTokensChanged}|{gatheringTokensChanged}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnedWorldObjects_VendorBuyItem: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnedWorldObjects_VendorBuyItem({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnedWorldObjects_VendorBuyItem took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnerLocations_Overwrite(List<LocationModel> interactableLocations, List<LocationModel> entityLocations, List<LocationModel> itemLocations)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnerLocations_Overwrite|{JsonConvert.SerializeObject(interactableLocations)}|{JsonConvert.SerializeObject(entityLocations)}|{JsonConvert.SerializeObject(itemLocations)}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnerLocations_Overwrite: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnerLocations_Overwrite({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnerLocations_Overwrite took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool SpawnerLocations_LastDeath(uint locationId, long respawnTimeBinary)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnerLocations_LastDeath|{locationId}|{respawnTimeBinary}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnerLocations_LastDeath: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnerLocations_LastDeath({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnerLocations_LastDeath took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<string,List<LocationModel>>> SpawnerLocations_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnerLocations_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnerLocations_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnerLocations_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<string,List<LocationModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnerLocations_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<uint,long>> SpawnerLocations_RespawnTimersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SpawnerLocations_RespawnTimersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SpawnerLocations_RespawnTimersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SpawnerLocations_RespawnTimersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<uint,long>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SpawnerLocations_RespawnTimersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddCrafted(int characterId, byte rarityId, string itemGlobalObject, byte quantity)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddCrafted|{characterId}|{rarityId}|{itemGlobalObject}|{quantity}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddCrafted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddCrafted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddCrafted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddDeath(int characterId, Guid killedBySpawnedWorldId, int globalTierId, int globalRankId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddDeath|{characterId}|{killedBySpawnedWorldId}|{globalTierId}|{globalRankId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddDeath: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddDeath({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddDeath took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static void Character_HistoryAddGathered(int characterId, string gatherableGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddGathered|{characterId}|{gatherableGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddGathered: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);



                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddGathered took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 


        }
            catch(SocketException e)
        {
                _logger.LogException(e);

        }


        }
		public static bool Character_HistoryAddKill(int characterId, byte entityTierId, string entityGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddKill|{characterId}|{entityTierId}|{entityGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddKill: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddKill({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddKill took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddLooted(int characterId, string itemGlobalObject, byte rarityId, byte quantity)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddLooted|{characterId}|{itemGlobalObject}|{rarityId}|{quantity}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddLooted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddLooted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddLooted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddQuest(int characterId, byte questTypeId, byte questTierId, byte questRankId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddQuest|{characterId}|{questTypeId}|{questTierId}|{questRankId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddQuest: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddQuest({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddQuest took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CharacterStatusEffectData> Character_StatusEffectsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatusEffectsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatusEffectsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatusEffectsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CharacterStatusEffectData>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatusEffectsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_StatusEffectsAdd(int characterId, string effectGroupGlobalObject, float remainingDuration, byte stacks)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatusEffectsAdd|{characterId}|{effectGroupGlobalObject}|{remainingDuration}|{stacks}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatusEffectsAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatusEffectsAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatusEffectsAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_StatusEffectsUpdate(int characterId, string effectGroupGlobalObject, float remainingDuration, byte stacks)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatusEffectsUpdate|{characterId}|{effectGroupGlobalObject}|{remainingDuration}|{stacks}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatusEffectsUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatusEffectsUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatusEffectsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_StatusEffectsRemove(int characterId, string effectGroupGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatusEffectsRemove|{characterId}|{effectGroupGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatusEffectsRemove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatusEffectsRemove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatusEffectsRemove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEquipmentModel> InstancedItems_ArmorGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ArmorGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ArmorGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ArmorGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEquipmentModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEquipmentModel> Character_Equipment_InstancedItems_EquipmentGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_Equipment_InstancedItems_EquipmentGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_Equipment_InstancedItems_EquipmentGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_Equipment_InstancedItems_EquipmentGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEquipmentModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_Equipment_InstancedItems_EquipmentGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEquipmentModel> InstancedItems_ArmorGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ArmorGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ArmorGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ArmorGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEquipmentModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ArmorGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedBagModel> InstancedItems_BagsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_BagsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_BagsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_BagsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedBagModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedBagModel> InstancedItems_BagsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_BagsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_BagsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_BagsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedBagModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_BagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_ConsumablesGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ConsumablesGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ConsumablesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ConsumablesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_ConsumablesGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ConsumablesGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ConsumablesGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ConsumablesGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ConsumablesGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_GeneralItemsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_GeneralItemsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_GeneralItemsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_GeneralItemsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_GeneralItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_GeneralItemsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_GeneralItemsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_GeneralItemsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_GeneralItemsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_GeneralItemsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,List<IngredientModel>> InstancedItems_IngredientsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_IngredientsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_IngredientsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_IngredientsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,List<IngredientModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_IngredientsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,List<IngredientModel>> InstancedItems_IngredientsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_IngredientsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_IngredientsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_IngredientsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,List<IngredientModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_IngredientsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_MaterialsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_MaterialsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_MaterialsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_MaterialsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_MaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedItemModel> InstancedItems_MaterialsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_MaterialsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_MaterialsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_MaterialsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_MaterialsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEquipmentModel> InstancedItems_WeaponsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_WeaponsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_WeaponsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_WeaponsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEquipmentModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_WeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<SpawnedEquipmentModel> InstancedItems_WeaponsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_WeaponsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_WeaponsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_WeaponsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<SpawnedEquipmentModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_WeaponsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_AmmunitionCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_AmmunitionCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_AmmunitionCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_AmmunitionCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_AmmunitionCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_ArmorCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ArmorCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ArmorCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ArmorCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ArmorCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_BagCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, byte bagSize, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_BagCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{bagSize}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_BagCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_BagCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_BagCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_ConsumableCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_ConsumableCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_ConsumableCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_ConsumableCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_ConsumableCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_GeneralItemCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_GeneralItemCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_GeneralItemCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_GeneralItemCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_GeneralItemCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_MaterialCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_MaterialCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_MaterialCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_MaterialCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_MaterialCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_WeaponCreate(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_WeaponCreate|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_WeaponCreate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_WeaponCreate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_WeaponCreate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_IngredientAdd(Guid instancedItemId, string ingredientGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_IngredientAdd|{instancedItemId}|{ingredientGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_IngredientAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_IngredientAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_IngredientAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_DurabilityUpdate(Guid instancedItemId, float durabilityPercentage)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_DurabilityUpdate|{instancedItemId}|{durabilityPercentage}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_DurabilityUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_DurabilityUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_DurabilityUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool InstancedItems_IsLooted(Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_IsLooted|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_IsLooted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_IsLooted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_IsLooted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		private static bool InstancedItems_SplitCreateGuid(string globalObject, byte rarityId, byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"InstancedItems_SplitCreateGuid|{globalObject}|{rarityId}|{qualityId}|{quantity}|{durabilityPercentage}|{wasCrafted}|{crafterName}|{wasLooted}|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.InstancedItems_SplitCreateGuid: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.InstancedItems_SplitCreateGuid({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"InstancedItems_SplitCreateGuid took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<AbilityRankModel>> Abilities_RanksGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Abilities_RanksGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Abilities_RanksGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Abilities_RanksGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<AbilityRankModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Abilities_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,AbilityModel> Abilities_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Abilities_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Abilities_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Abilities_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,AbilityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Abilities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,LevelModel>> AbilityExperienceRequired_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"AbilityExperienceRequired_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.AbilityExperienceRequired_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.AbilityExperienceRequired_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,LevelModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"AbilityExperienceRequired_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,float> AbilityDifficultyMultipliers_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"AbilityDifficultyMultipliers_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.AbilityDifficultyMultipliers_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.AbilityDifficultyMultipliers_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,float>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"AbilityDifficultyMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<AwardEffectModel>> AwardEffects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"AwardEffects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.AwardEffects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.AwardEffects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<AwardEffectModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"AwardEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<BodyPartMultiplierModel>> BodyPartMultipliers_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"BodyPartMultipliers_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.BodyPartMultipliers_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.BodyPartMultipliers_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<BodyPartMultiplierModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"BodyPartMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<BodyPartPathModel>> BodyPartPaths_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"BodyPartPaths_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.BodyPartPaths_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.BodyPartPaths_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<BodyPartPathModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"BodyPartPaths_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<ExperienceEffectModel>> ExperienceEffects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ExperienceEffects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ExperienceEffects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ExperienceEffects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<ExperienceEffectModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ExperienceEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableObjectModel> ScriptableObjects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableObjects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableObjects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableObjects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableObjectModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableObjects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableObjectModel> ScriptableItems_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableObjectModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,LevelModel>> LevelRequirement_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LevelRequirement_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LevelRequirement_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LevelRequirement_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,LevelModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LevelRequirement_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,LevelModel>> LevelRequirementSkills_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LevelRequirementSkills_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LevelRequirementSkills_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LevelRequirementSkills_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,LevelModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LevelRequirementSkills_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,LootTableModel> LootTables_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LootTables_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LootTables_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LootTables_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,LootTableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LootTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<LootTableDropModel>> LootTables_DropsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LootTables_DropsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LootTables_DropsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LootTables_DropsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<LootTableDropModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LootTables_DropsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<string,List<LootTableRarityModel>>> LootTables_RaritiesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LootTables_RaritiesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LootTables_RaritiesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LootTables_RaritiesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,List<LootTableRarityModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LootTables_RaritiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<string,List<LootTableQuantityModel>>> LootTables_QuantitiesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LootTables_QuantitiesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LootTables_QuantitiesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LootTables_QuantitiesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,List<LootTableQuantityModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LootTables_QuantitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<QualityModel> Qualities_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Qualities_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Qualities_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Qualities_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<QualityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Qualities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,List<ModifierModel>> Qualities_ModifiersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Qualities_ModifiersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Qualities_ModifiersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Qualities_ModifiersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,List<ModifierModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Qualities_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<RarityModel> Rarities_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Rarities_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Rarities_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Rarities_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<RarityModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Rarities_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,List<ModifierModel>> Rarities_ModifiersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Rarities_ModifiersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Rarities_ModifiersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Rarities_ModifiersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,List<ModifierModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Rarities_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,RecipeModel> Recipes_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Recipes_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Recipes_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Recipes_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,RecipeModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Recipes_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<RecipeIngredientModel>>> Recipes_GetIngredients()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Recipes_GetIngredients|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Recipes_GetIngredients: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Recipes_GetIngredients({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<RecipeIngredientModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Recipes_GetIngredients took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,RecipeProductModel> Recipes_GetProducts()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Recipes_GetProducts|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Recipes_GetProducts: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Recipes_GetProducts({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,RecipeProductModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Recipes_GetProducts took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<ushort>> StatEffects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"StatEffects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.StatEffects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.StatEffects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<ushort>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"StatEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,LevelModel>> SkillExperienceRequired_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SkillExperienceRequired_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SkillExperienceRequired_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SkillExperienceRequired_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,LevelModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SkillExperienceRequired_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,float> SkillDifficultyMultipliers_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"SkillDifficultyMultipliers_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.SkillDifficultyMultipliers_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.SkillDifficultyMultipliers_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,float>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"SkillDifficultyMultipliers_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<ushort,StatusEffectModel> StatusEffects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"StatusEffects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.StatusEffects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.StatusEffects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<ushort,StatusEffectModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"StatusEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<StatEffectModel>> StatusEffect_EffectsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"StatusEffect_EffectsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.StatusEffect_EffectsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.StatusEffect_EffectsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<StatEffectModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"StatusEffect_EffectsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,SkillModel> Skills_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Skills_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Skills_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Skills_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,SkillModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Skills_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<UnlockEffectModel>> UnlockEffects_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"UnlockEffects_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.UnlockEffects_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.UnlockEffects_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<UnlockEffectModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"UnlockEffects_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<WeaponPositionModel>> WeaponPositions_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"WeaponPositions_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.WeaponPositions_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.WeaponPositions_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<WeaponPositionModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"WeaponPositions_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableArmorModel> ScriptableItems_ArmorGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_ArmorGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_ArmorGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_ArmorGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableArmorModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_ArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableJeweleryModel> ScriptableItems_JeweleryGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_JeweleryGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_JeweleryGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_JeweleryGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableJeweleryModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_JeweleryGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<EquipmentRequirementModel>> ScriptableItems_EquipmentRequirementsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_EquipmentRequirementsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_EquipmentRequirementsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_EquipmentRequirementsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<EquipmentRequirementModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_EquipmentRequirementsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableBagModel> ScriptableItems_BagsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_BagsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_BagsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_BagsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableBagModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableConsumableModel> ScriptableItems_ConsumablesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_ConsumablesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_ConsumablesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_ConsumablesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableConsumableModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_ConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,Dictionary<byte,List<EntityAbilityRank>>> ScriptableEntities_AbilitiesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableEntities_AbilitiesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableEntities_AbilitiesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableEntities_AbilitiesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<byte,List<EntityAbilityRank>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableEntities_AbilitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableGeneralItemModel> ScriptableItems_GeneralGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_GeneralGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_GeneralGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_GeneralGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableGeneralItemModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_GeneralGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableMaterialModel> ScriptableItems_MaterialsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_MaterialsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_MaterialsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_MaterialsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableMaterialModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_MaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<ModifierModel>> ScriptableMaterials_ModifiersGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableMaterials_ModifiersGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableMaterials_ModifiersGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableMaterials_ModifiersGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<ModifierModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableMaterials_ModifiersGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ScriptableWeaponModel> ScriptableItems_WeaponsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableItems_WeaponsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableItems_WeaponsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableItems_WeaponsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ScriptableWeaponModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableItems_WeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<RankModel>> ScriptableInteractables_RanksGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableInteractables_RanksGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableInteractables_RanksGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableInteractables_RanksGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<RankModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableInteractables_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,List<RankModel>> ScriptableEntities_RanksGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableEntities_RanksGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableEntities_RanksGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableEntities_RanksGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,List<RankModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableEntities_RanksGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,TotalModel> ScriptableTotals_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,TotalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<ushort,List<ushort>> ScriptableTotals_MilestonesGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_MilestonesGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_MilestonesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_MilestonesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<ushort,List<ushort>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_MilestonesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<KillTotalModel> ScriptableTotals_KillsGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_KillsGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_KillsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_KillsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<KillTotalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_KillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<GatherTotalModel> ScriptableTotals_GatherGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_GatherGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_GatherGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_GatherGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<GatherTotalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_GatherGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CraftTotalModel> ScriptableTotals_CraftGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_CraftGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_CraftGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_CraftGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CraftTotalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_CraftGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CollectTotalModel> ScriptableTotals_CollectGetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"ScriptableTotals_CollectGetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.ScriptableTotals_CollectGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.ScriptableTotals_CollectGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CollectTotalModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"ScriptableTotals_CollectGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static CharacterBagModel[] Character_BagsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BagsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BagsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BagsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<CharacterBagModel[]>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CharacterBagsData> Character_BagsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BagsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BagsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BagsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CharacterBagsData>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<BuybackModel> Character_BuybacksGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BuybacksGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BuybacksGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BuybacksGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<BuybackModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BuybacksGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CharacterEquipmentData> Character_EquipmentGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_EquipmentGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_EquipmentGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_EquipmentGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CharacterEquipmentData>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_EquipmentGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static CharacterEquipmentData Character_EquipmentGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_EquipmentGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_EquipmentGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_EquipmentGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<CharacterEquipmentData>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_EquipmentGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryArmorGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryArmorGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryArmorGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryArmorGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryArmorGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryArmorGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryArmorGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryArmorGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryArmorGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryArmorGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryBagsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryBagsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryConsumablesGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryConsumablesGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryConsumablesGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryConsumablesGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryConsumablesGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryConsumablesGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryConsumablesGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryConsumablesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryConsumablesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryConsumablesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryGeneralItemsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryGeneralItemsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryGeneralItemsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryGeneralItemsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryGeneralItemsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryGeneralItemsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryGeneralItemsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryGeneralItemsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryGeneralItemsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryGeneralItemsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryMaterialsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryMaterialsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryMaterialsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryMaterialsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryMaterialsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryMaterialsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryMaterialsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryMaterialsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryMaterialsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryMaterialsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>> Character_InventoryWeaponsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryWeaponsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryWeaponsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryWeaponsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,Dictionary<byte,Dictionary<byte,Guid>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryWeaponsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,Guid>> Character_InventoryWeaponsGetList(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryWeaponsGetList|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryWeaponsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryWeaponsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,Guid>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryWeaponsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<Guid,List<MailContentModel>> Character_MailAttachmentsGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailAttachmentsGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailAttachmentsGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailAttachmentsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<Guid,List<MailContentModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailAttachmentsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<int,List<MailModel>> Character_MailGetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailGetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailGetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<int,List<MailModel>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,string> Character_MissionsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MissionsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MissionsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MissionsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MissionsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,List<ushort>> Character_QuestsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,List<ushort>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<ushort,Dictionary<byte,List<QuestObjectiveModel>>> Character_QuestsObjectivesGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestsObjectivesGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestsObjectivesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestsObjectivesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<ushort,Dictionary<byte,List<QuestObjectiveModel>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestsObjectivesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<string> Character_RecipesGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_RecipesGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_RecipesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_RecipesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<string>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_RecipesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,int> Character_SkillsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_SkillsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_SkillsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_SkillsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,int>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_SkillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ushort> Character_TitlesGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_TitlesGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_TitlesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_TitlesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ushort>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_TitlesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<ushort> Character_AchievementsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_AchievementsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_AchievementsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AchievementsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<ushort>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AchievementsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<StatModel> Character_StatsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<StatModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static int PlayerAccount_Create(string userName, string password)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"PlayerAccount_Create|{userName}|{password}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.PlayerAccount_Create: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.PlayerAccount_Create({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<int>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"PlayerAccount_Create took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static int PlayerAccount_ResetPassword(string userName, string password)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"PlayerAccount_ResetPassword|{userName}|{password}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.PlayerAccount_ResetPassword: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.PlayerAccount_ResetPassword({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<int>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"PlayerAccount_ResetPassword took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_AbilitiesAdd(int characterId, string abilityGlobalObject, ushort abilityId, int abilityExperience)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_AbilitiesAdd|{characterId}|{abilityGlobalObject}|{abilityId}|{abilityExperience}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_AbilitiesAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AbilitiesAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AbilitiesAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_AbilitiesUpdate(int characterId, string abilityGlobalObject, ushort abilityId, int abilityExperience)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_AbilitiesUpdate|{characterId}|{abilityGlobalObject}|{abilityId}|{abilityExperience}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_AbilitiesUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AbilitiesUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AbilitiesUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_AchievementsUnlock(int characterId, string achievementGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_AchievementsUnlock|{characterId}|{achievementGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_AchievementsUnlock: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AchievementsUnlock({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AchievementsUnlock took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static int Character_Create(int playerAccountId, string characterName, int characterFactionId, float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ, int race, int gender, int face, int eyebrows, int hair, int facialHair, string skinColor, string eyeColor, string hairColor, string stubbleColor, float spawnLocationX, float spawnLocationY, float spawnLocationZ)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_Create|{playerAccountId}|{characterName}|{characterFactionId}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}|{scaleX}|{scaleY}|{scaleZ}|{race}|{gender}|{face}|{eyebrows}|{hair}|{facialHair}|{skinColor}|{eyeColor}|{hairColor}|{stubbleColor}|{spawnLocationX}|{spawnLocationY}|{spawnLocationZ}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_Create: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_Create({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<int>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_Create took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_BagAdd(Guid spawnedWorldObjectId, Guid instancedItemId, byte bagLocationId, byte bagSize)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BagAdd|{spawnedWorldObjectId}|{instancedItemId}|{bagLocationId}|{bagSize}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BagAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BagAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BagAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_BagRemove(Guid spawnedWorldObjectId, byte bagIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BagRemove|{spawnedWorldObjectId}|{bagIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BagRemove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BagRemove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BagRemove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_BuybacksAdd(int characterId, Guid instancedItemId, long soldDateTimeBinary)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BuybacksAdd|{characterId}|{instancedItemId}|{soldDateTimeBinary}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BuybacksAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BuybacksAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BuybacksAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_BuybacksRemove(int characterId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_BuybacksRemove|{characterId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_BuybacksRemove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_BuybacksRemove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_BuybacksRemove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		private static Tuple<ushort,byte,byte,long> Money_Calculate(int goldCoins, short silverCoins, short copperCoins)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Money_Calculate|{goldCoins}|{silverCoins}|{copperCoins}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Money_Calculate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Money_Calculate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<ushort,byte,byte,long>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Money_Calculate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		private static Tuple<ushort,byte,byte,long> Money_Calculate(long totalCurrency)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Money_Calculate|{totalCurrency}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Money_Calculate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Money_Calculate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Tuple<ushort,byte,byte,long>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Money_Calculate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_CurrencyUpdate(Guid spawnedWorldObjectId, int goldCost, short silverCost, short copperCost, short adventuringTokensCost, short craftingTokensCost, short gatheringTokensCost, string description)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_CurrencyUpdate|{spawnedWorldObjectId}|{goldCost}|{silverCost}|{copperCost}|{adventuringTokensCost}|{craftingTokensCost}|{gatheringTokensCost}|{description}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_CurrencyUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_CurrencyUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_CurrencyUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static string Character_Delete(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_Delete|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_Delete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_Delete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<string>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_Delete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_EquipmentMove(Guid spawnedWorldObjectId, byte fromSlotIndex, byte toSlotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_EquipmentMove|{spawnedWorldObjectId}|{fromSlotIndex}|{toSlotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_EquipmentMove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_EquipmentMove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_EquipmentMove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_EquipmentRemove(Guid spawnedWorldObjectId, byte equipmentSlotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_EquipmentRemove|{spawnedWorldObjectId}|{equipmentSlotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_EquipmentRemove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_EquipmentRemove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_EquipmentRemove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryAddItem(Guid spawnedWorldObjectId, Guid instancedItemId, byte bagIndex, byte slotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryAddItem|{spawnedWorldObjectId}|{instancedItemId}|{bagIndex}|{slotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryAddItem: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryAddItem({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryAddItem took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryBagChangeLocation(Guid spawnedWorldObjectId, byte fromBagIndex, byte toBagIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagChangeLocation|{spawnedWorldObjectId}|{fromBagIndex}|{toBagIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagChangeLocation: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagChangeLocation({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagChangeLocation took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryBagUnequip(Guid fromSpawnedWorldObjectId, byte fromBagIndex, Guid toSpawnedObjectId, byte toBagIndex, byte toSlotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagUnequip|{fromSpawnedWorldObjectId}|{fromBagIndex}|{toSpawnedObjectId}|{toBagIndex}|{toSlotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagUnequip: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagUnequip({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagUnequip took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryBagEquip(Guid fromSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, Guid toSpawnedObjectId, byte toBagIndex, byte bagSize)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagEquip|{fromSpawnedWorldObjectId}|{fromBagIndex}|{fromSlotIndex}|{toSpawnedObjectId}|{toBagIndex}|{bagSize}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagEquip: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagEquip({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagEquip took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryBagsSwap(Guid fromSpawnedObjectId, byte fromBagIndex, Guid toSpawnedObjectId, byte toBagIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryBagsSwap|{fromSpawnedObjectId}|{fromBagIndex}|{toSpawnedObjectId}|{toBagIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryBagsSwap: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryBagsSwap({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryBagsSwap took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryDeleteAll(Guid spawnedWorldObjectId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryDeleteAll|{spawnedWorldObjectId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryDeleteAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryDeleteAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryDeleteAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryEquip(Guid spawnedWorldObjectId, byte equipmentSlotId, byte bagIndex, byte slotIndex, byte equipType)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryEquip|{spawnedWorldObjectId}|{equipmentSlotId}|{bagIndex}|{slotIndex}|{equipType}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryEquip: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryEquip({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryEquip took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryMergeStacks(Guid fromSpawnedWorldObjectId, Guid toSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, byte fromQuantity, byte toBagIndex, byte toSlotIndex, byte toQuantity)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryMergeStacks|{fromSpawnedWorldObjectId}|{toSpawnedWorldObjectId}|{fromBagIndex}|{fromSlotIndex}|{fromQuantity}|{toBagIndex}|{toSlotIndex}|{toQuantity}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryMergeStacks: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryMergeStacks({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryMergeStacks took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryMove(Guid fromSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, Guid toSpawnedWorldObjectId, byte toBagIndex, byte toSlotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryMove|{fromSpawnedWorldObjectId}|{fromBagIndex}|{fromSlotIndex}|{toSpawnedWorldObjectId}|{toBagIndex}|{toSlotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryMove: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryMove({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryMove took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryRemoveItem(Guid spawnedWorldObjectId, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryRemoveItem|{spawnedWorldObjectId}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryRemoveItem: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryRemoveItem({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryRemoveItem took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		private static bool Character_InventorySpawn(Guid spawnedWorldObjectId, byte bagIndex, byte slotIndex, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventorySpawn|{spawnedWorldObjectId}|{bagIndex}|{slotIndex}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventorySpawn: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventorySpawn({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventorySpawn took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventorySplitStack(Guid fromSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, byte fromQuantity, Guid toSpawnedWorldObjectId, byte toBagIndex, byte toSlotIndex, byte toQuantity, Guid instancedItemId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventorySplitStack|{fromSpawnedWorldObjectId}|{fromBagIndex}|{fromSlotIndex}|{fromQuantity}|{toSpawnedWorldObjectId}|{toBagIndex}|{toSlotIndex}|{toQuantity}|{instancedItemId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventorySplitStack: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventorySplitStack({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventorySplitStack took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_InventoryUpdateQuantity(Guid instancedItemId, byte quantity)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_InventoryUpdateQuantity|{instancedItemId}|{quantity}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_InventoryUpdateQuantity: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_InventoryUpdateQuantity({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_InventoryUpdateQuantity took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailDelete(Guid mailId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailDelete|{mailId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailDelete: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailDelete({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailDelete took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailSend(Guid mailId, byte mailIndex, int senderCharacterId, string senderName, string mailSubject, string mailBody, uint gold, byte silver, byte copper, bool currencyClaimed, bool contentsClaimed, bool unread, int recipientCharacterId, long sentDateTimeBinary, long appearDateTimeBinary, long deleteDateTimeBinary)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailSend|{mailId}|{mailIndex}|{senderCharacterId}|{senderName}|{mailSubject}|{mailBody}|{gold}|{silver}|{copper}|{currencyClaimed}|{contentsClaimed}|{unread}|{recipientCharacterId}|{sentDateTimeBinary}|{appearDateTimeBinary}|{deleteDateTimeBinary}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailSend: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailSend({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailSend took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailSendAttachments(Guid mailId, Guid instancedItemId, byte slotIndex, long sentDateTimeBinary)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailSendAttachments|{mailId}|{instancedItemId}|{slotIndex}|{sentDateTimeBinary}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailSendAttachments: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailSendAttachments({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailSendAttachments took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailTakeAttachment(Guid mailId, byte slotIndex)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailTakeAttachment|{mailId}|{slotIndex}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailTakeAttachment: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailTakeAttachment({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailTakeAttachment took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailClaimCurrency(Guid mailId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailClaimCurrency|{mailId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailClaimCurrency: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailClaimCurrency({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailClaimCurrency took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailClaimContents(Guid mailId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailClaimContents|{mailId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailClaimContents: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailClaimContents({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailClaimContents took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MailRead(Guid mailId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MailRead|{mailId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MailRead: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MailRead({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MailRead took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MissionAbandoned(int characterId, Guid missionId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MissionAbandoned|{characterId}|{missionId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MissionAbandoned: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MissionAbandoned({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MissionAbandoned took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MissionAccepted(int characterId, Guid missionId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MissionAccepted|{characterId}|{missionId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MissionAccepted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MissionAccepted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MissionAccepted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_MissionCompleted(int characterId, Guid missionId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_MissionCompleted|{characterId}|{missionId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_MissionCompleted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_MissionCompleted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_MissionCompleted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestAbandoned(int characterId, string questGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestAbandoned|{characterId}|{questGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestAbandoned: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestAbandoned({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestAbandoned took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestAccepted(int characterId, string questGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestAccepted|{characterId}|{questGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestAccepted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestAccepted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestAccepted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestInsertObjectives(string questGlobalObject, int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestInsertObjectives|{questGlobalObject}|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestInsertObjectives: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestInsertObjectives({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestInsertObjectives took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestInsertUpdateObjectives(int characterId, string questGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestInsertUpdateObjectives|{characterId}|{questGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestInsertUpdateObjectives: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestInsertUpdateObjectives({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestInsertUpdateObjectives took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestCompleted(int characterId, string questGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestCompleted|{characterId}|{questGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestCompleted: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestCompleted({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestCompleted took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_QuestUpdate(int characterId, string questGlobalObject, string objectiveGlobalObject, int currentProgress)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_QuestUpdate|{characterId}|{questGlobalObject}|{objectiveGlobalObject}|{currentProgress}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_QuestUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_QuestUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_QuestUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_RecipeAdd(int characterId, string recipeGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_RecipeAdd|{characterId}|{recipeGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_RecipeAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_RecipeAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_RecipeAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_SkillsAdd(int characterId, string globalObject, ushort skillId, int characterSkillExperience, byte characterSkillRankId, byte characterSkillLevelId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_SkillsAdd|{characterId}|{globalObject}|{skillId}|{characterSkillExperience}|{characterSkillRankId}|{characterSkillLevelId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_SkillsAdd: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_SkillsAdd({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_SkillsAdd took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_SkillsUpdate(int characterId, string globalObject, int experienceAdded, byte characterSkillRankId, byte characterSkillLevelId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_SkillsUpdate|{characterId}|{globalObject}|{experienceAdded}|{characterSkillRankId}|{characterSkillLevelId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_SkillsUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_SkillsUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_SkillsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_TitlesUnlock(int characterId, string titleGlobalObject)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_TitlesUnlock|{characterId}|{titleGlobalObject}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_TitlesUnlock: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_TitlesUnlock({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_TitlesUnlock took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_SaveExperience(int characterId, int characterExperience, byte rankId, byte levelId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_SaveExperience|{characterId}|{characterExperience}|{rankId}|{levelId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_SaveExperience: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_SaveExperience({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_SaveExperience took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_SaveLocation(Guid spawnedWorldObjectId, Double coordinateX, Double coordinateY, Double coordinateZ, int chunk, Double rotationX, Double rotationY, Double rotationZ)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_SaveLocation|{spawnedWorldObjectId}|{coordinateX}|{coordinateY}|{coordinateZ}|{chunk}|{rotationX}|{rotationY}|{rotationZ}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_SaveLocation: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_SaveLocation({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_SaveLocation took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_StatsUpdate(int characterId, byte statTypeId, byte statId, float characterStatValue)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_StatsUpdate|{characterId}|{statTypeId}|{statId}|{characterStatValue}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_StatsUpdate: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_StatsUpdate({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_StatsUpdate took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CollectedHistoryModel> Character_HistoryCollectedGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryCollectedGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryCollectedGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryCollectedGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CollectedHistoryModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryCollectedGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<CraftedHistoryModel> Character_HistoryCraftedGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryCraftedGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryCraftedGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryCraftedGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<CraftedHistoryModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryCraftedGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<GatheredHistoryModel> Character_HistoryGatheredGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryGatheredGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryGatheredGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryGatheredGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<GatheredHistoryModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryGatheredGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static List<KillHistoryModel> Character_HistoryKillsGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryKillsGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryKillsGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryKillsGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<List<KillHistoryModel>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryKillsGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddCollected(int characterId, byte rarityId, string itemGlobalObject, byte quantity)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddCollected|{characterId}|{rarityId}|{itemGlobalObject}|{quantity}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddCollected: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddCollected({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddCollected took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static bool Character_HistoryAddCombat(int characterId, int blocks, int blocked, int strikesReceived, int strikesGiven, int damageReceived, int damageGiven)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_HistoryAddCombat|{characterId}|{blocks}|{blocked}|{strikesReceived}|{strikesGiven}|{damageReceived}|{damageGiven}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_HistoryAddCombat: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_HistoryAddCombat({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<bool>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_HistoryAddCombat took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,List<CharacterCreationOption>>> CharacterCreationOptions_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"CharacterCreationOptions_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.CharacterCreationOptions_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.CharacterCreationOptions_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,List<CharacterCreationOption>>>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"CharacterCreationOptions_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,long> LastUpdatedTables_GetList()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"LastUpdatedTables_GetList|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.LastUpdatedTables_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.LastUpdatedTables_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,long>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"LastUpdatedTables_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static PlayerAccountRequestResponse PlayerAccount_GetPassword(string userName, string password)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"PlayerAccount_GetPassword|{userName}|{password}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.PlayerAccount_GetPassword: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.PlayerAccount_GetPassword({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<PlayerAccountRequestResponse>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"PlayerAccount_GetPassword took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,int> Character_GetAll()
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_GetAll|" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_GetAll: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_GetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,int>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_GetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static CharacterModel[] Character_GetList(int playerAccountId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_GetList|{playerAccountId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_GetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_GetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<CharacterModel[]>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_GetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static CharacterModel Character_GetInfo(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_GetInfo|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_GetInfo: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_GetInfo({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<CharacterModel>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_GetInfo took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<string,int> Character_AbilitiesGetList(int characterId)
        {


            try
        {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();

                var requestBytes = Encoding.ASCII.GetBytes($"Character_AbilitiesGetList|{characterId}" + "|EOL|");

                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
        {
                    _logger.LogError($"ClientSocket.Character_AbilitiesGetList: Buffer too small. {bytesReceived} bytes received.");
        }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AbilitiesGetList({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<string,int>>(stringValue)!;

                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AbilitiesGetList took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 

                return json;
        }
            catch(SocketException e)
        {
                _logger.LogException(e);
                return default!;
        }


        }
		public static Dictionary<byte,Dictionary<byte,byte>> Character_AttributePointsGetAll()
        {

		
            try
                {
                if(SOCKET_PROFILING_ENABLED) stopwatch.Restart();
                
                var requestBytes = Encoding.ASCII.GetBytes($"Character_AttributePointsGetAll|" + "|EOL|");
                
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);

                var bytesSent = _socket.Send(requestBytes, SocketFlags.None);
                if(!_socket.Connected) _socket.Connect(_socket.RemoteEndPoint);
                int bytesReceived = 0;
                bytesReceived = _socket.Receive(_buffer, SocketFlags.None);
                if (bytesReceived >= _buffer.Length)
                    {
                    _logger.LogError($"ClientSocket.Character_AttributePointsGetAll: Buffer too small. {bytesReceived} bytes received.");
                    }
                var stringValue = Encoding.UTF8.GetString(_buffer[0..bytesReceived]);
                if(SOCKET_DEBUGGING_ENABLED) _logger.LogDebug($"ClientSocket.Character_AttributePointsGetAll({bytesReceived}): {stringValue}");  
                var json = JsonConvert.DeserializeObject<Dictionary<byte,Dictionary<byte,byte>>>(stringValue)!;
                
                if(SOCKET_PROFILING_ENABLED) _logger.LogProfiling($"Character_AttributePointsGetAll took {stopwatch.ElapsedTicks/10000f}ms");
                if(SOCKET_PROFILING_ENABLED) stopwatch.Stop();                 
                
                return json;
            }
            catch(SocketException e)
            {
                _logger.LogException(e);
                return default!;
            }



        }

        }