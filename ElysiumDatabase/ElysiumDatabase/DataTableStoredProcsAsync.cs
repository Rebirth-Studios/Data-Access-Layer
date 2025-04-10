// //#if SERVER
//
// using System;
// using System.Collections.Generic;
// using System.Numerics;
// using System.Reflection;
//
// namespace RebirthStudios.DataAccessLayer
// {
//     public class DataTableStoredProcsAsync
//     {
//         public static  ILogger        Logger { get; set; }
//         private static List<object[]> Storedprocs = new List<object[]>();
//         #region ASYNC: CHARACTERS
//
//         public static bool Character_AbilitiesAdd_Async(int characterId, string abilityGlobalObjectCode, ushort abilityId, int abilityExperience, byte logging, short processedRowId, Action<Guid, string, bool> callback)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_AbilitiesAdd(characterId, abilityGlobalObjectCode, abilityId, abilityExperience);
//                 });
//                 Storedprocs.Add(new object[] {"Character_AbilitiesAdd", characterId, abilityGlobalObjectCode, abilityExperience});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod()!;
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//
//             return success;
//         }
//         
//         public static bool Character_AbilitiesUpdate_Async(int characterId, string abilityGlobalObjectCode, ushort abilityId, int abilityExperience, byte logging, Action<Guid, ushort, uint, bool> callback)
//         {
//             bool success;
//
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_AbilitiesUpdate(characterId, abilityGlobalObjectCode, abilityId, abilityExperience);
//                 });
//                 Storedprocs.Add(new object[] {"Character_AbilitiesUpdate", characterId, abilityGlobalObjectCode, abilityExperience});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             
//             
//             return success;
//         }
//         
//         public static void Character_BagAdd_Async(Guid spawnedWorldObjectId, Guid instancedItemId,
//             byte bagLocationId, byte logging = 0, string addName = "")
//         {
//             try
//             {
//                 Logger.Log($"Character_BagAdd_Async: {addName} @ {bagLocationId}");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     //Character_BagAdd(spawnedWorldObjectId, instancedItemId, bagLocationId);
//                 });
//                 Storedprocs.Add(new object[] { "Character_BagAdd", spawnedWorldObjectId, instancedItemId, bagLocationId, 
//                      });
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void Character_BagRemove_Async(Guid spawnedWorldObjectId, byte bagIndex, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_BagRemove(spawnedWorldObjectId, bagIndex);
//                 });
//             
//                 Storedprocs.Add(new object[]{$"Character_BagRemove", spawnedWorldObjectId, bagIndex});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             
//         }
//         
//         public static void Character_BuybacksRemove_Async(int characterId, Guid instancedItemId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_BuybacksRemove(characterId, instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] { "Character_BuybacksRemove", characterId, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static bool Character_CurrencyUpdate_Async(Guid spawnedWorldObjectId, int goldChanged, byte silverChanged, 
//             byte copperChanged, short adventuringTokensChanged, short craftingTokensChanged, short gatheringTokensChanged, string description, 
//             byte logging, Action<Guid, int, short, short, short, short, short, bool> callback)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_CurrencyUpdate(spawnedWorldObjectId, goldChanged, silverChanged, copperChanged, 
//                         adventuringTokensChanged, craftingTokensChanged, gatheringTokensChanged, description);
//                 });
//                 Storedprocs.Add(new object[] {"Character_CurrencyUpdate", spawnedWorldObjectId, goldChanged, silverChanged, copperChanged, adventuringTokensChanged, craftingTokensChanged, gatheringTokensChanged, description});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//
//             return true;
//         }
//         
//         
//         public static void Character_EquipmentMove_Async(Guid characterId, byte fromSlotIndex, byte toSlotIndex,
//             byte logging = 0)
//         {
//             try
//             {
//                 Logger.LogError($"Character_EquipmentMove_Async: {characterId} | {fromSlotIndex} | {toSlotIndex}");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_EquipmentMove(characterId, fromSlotIndex, toSlotIndex);
//                 });
//                 Storedprocs.Add(new object[] {"Character_EquipmentMove", characterId, fromSlotIndex, toSlotIndex});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void Character_EquipmentRemove_Async(Guid characterId, byte equipmentSlotId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_EquipmentRemove(characterId, equipmentSlotId);
//                 });
//                 Storedprocs.Add(new object[]{"Character_EquipmentRemove", characterId,equipmentSlotId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void Character_InventoryAddItem_Async(Guid spawnedWorldObjectId, Guid instancedItemId, byte bagIndex,
//             byte slotIndex, byte logging, string adderName, Action<Guid, byte, byte, bool> callback)
//         {
//             try
//             {
//                 Logger.Log($"Character_InventoryAddItem_Async: {adderName} @ {slotIndex}");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryAddItem(spawnedWorldObjectId, instancedItemId, bagIndex, slotIndex);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryAddItem", spawnedWorldObjectId, instancedItemId, bagIndex, slotIndex});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static Guid Character_InventoryBagChangeLocation_Async( Guid spawnedWorldObjectId, byte fromBagIndex, byte toBagIndex, byte logging = 0)
//         {
//             Guid newGuid = Guid.NewGuid();
//             try
//             {
//                 Logger.LogError($"Character_InventoryBagChangeLocation_Async: {spawnedWorldObjectId}| {fromBagIndex}| {toBagIndex}");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryBagChangeLocation(spawnedWorldObjectId, fromBagIndex, toBagIndex);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryBagChangeLocation", spawnedWorldObjectId, fromBagIndex, toBagIndex});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             return newGuid;
//         }
//
//         public static void Character_InventoryEquip_Async(Guid characterId, byte equipmentSlotId, byte bagIndex, byte slotIndex, byte equipType, byte logging = 0)
//         {
//             try
//             {
//                 Logger.LogError($"Character_InventoryEquip_Async: {characterId}| {equipmentSlotId}| => {bagIndex} - {equipType}");
//                 Guid newGuid = Guid.NewGuid();
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryEquip(characterId, equipmentSlotId, bagIndex, slotIndex, equipType);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryEquip", characterId, equipmentSlotId, bagIndex, slotIndex, equipType, newGuid});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void Character_InventoryMergeStacks_Async(Guid fromSpawnedWorldObjectId, Guid toSpawnedWorldObjectId, 
//             byte fromBagIndex, byte fromSlotIndex, byte fromQuantity, byte toBagIndex, byte toSlotIndex, byte toQuantity, byte logging = 0)
//         {
//             try
//             {
//                 //Logger.LogError($"Character_InventoryMergeStacks_Async: {fromBagIndex}, {fromSlotIndex} | {fromQuantity} => {toBagIndex}, {toSlotIndex}| {toQuantity}");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryMergeStacks(fromSpawnedWorldObjectId, toSpawnedWorldObjectId, fromBagIndex, 
//                         fromSlotIndex, fromQuantity, toBagIndex, toSlotIndex, toQuantity);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryMergeStacks", fromSlotIndex, fromQuantity, toSlotIndex, toQuantity});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void Character_InventoryMove_Async(Guid fromSpawnedWorldObjectId, byte fromBagIndex, byte fromSlotIndex, 
//             Guid toSpawnedWorldObjectId, byte toBagIndex, byte toSlotIndex, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryMove(fromSpawnedWorldObjectId, fromBagIndex, fromSlotIndex, 
//                         toSpawnedWorldObjectId,toBagIndex, toSlotIndex);
//                 });
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             Storedprocs.Add(new object[] {"Character_InventoryMove", fromSpawnedWorldObjectId, fromBagIndex, fromSlotIndex, toSpawnedWorldObjectId, toBagIndex, toSlotIndex});
//     
//         }
//         
//         public static void Character_InventoryRemoveItem_Async(Guid spawnedWorldObjectId, Guid instancedItemId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryRemoveItem(spawnedWorldObjectId, instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryRemoveItem", spawnedWorldObjectId, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//         }
//         
//         public static Guid Character_InventorySplitStack_Async(Guid fromSpawnedWorldObjectId, Guid toSpawnedWorldObjectId, 
//             byte fromBagIndex, byte fromSlotIndex, byte fromQuantity, byte toBagIndex, byte toSlotIndex, byte toQuantity, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//             try
//             {
//                 Logger.LogError($"Character_InventorySplitStack_Async: {fromSlotIndex} | {fromQuantity} => {toSlotIndex} | {toQuantity}");
//                 Guid unused = Guid.NewGuid();
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventorySplitStack(fromSpawnedWorldObjectId, fromBagIndex, fromSlotIndex, 
//                         fromQuantity, toSpawnedWorldObjectId, toBagIndex, toSlotIndex, toQuantity, instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventorySplitStack", fromSpawnedWorldObjectId, toSpawnedWorldObjectId,
//                     fromBagIndex, fromSlotIndex, fromQuantity, toBagIndex, toSlotIndex, toQuantity, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             return instancedItemId;
//         }
//         
//         public static void Character_InventoryUpdateQuantity_Async(Guid instancedItemId, byte quantity, byte logging = 0)
//         {
//             try
//             {
//                 Logger.LogError($"Character_InventoryUpdateQuantity_Async");
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_InventoryUpdateQuantity(instancedItemId, quantity);
//                 });
//                 Storedprocs.Add(new object[] {"Character_InventoryUpdateQuantity", instancedItemId, quantity});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//         }
//         
//         public static void Character_MailClaimContents_Async(Guid mailId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailClaimContents(mailId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailClaimContents", mailId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             //return success;
//         }
//         
//         public static bool Character_MailClaimCurrency_Async(Guid mailId, byte logging = 0)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailClaimCurrency(mailId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailClaimCurrency", mailId});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             
//             return success;
//         }
//         
//         public static bool Character_MailDelete_Async(Guid mailId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailDelete(mailId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailDelete", mailId});
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             return false;
//         }
//         
//         public static bool Character_MailRead_Async(Guid mailId, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailRead(mailId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailRead", mailId});
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             return false;
//         }
//
//         public static bool Character_MailSendAttachments_Async(Guid mailId, Guid instancedItemId, byte slotIndex, long sendTime, byte logging = 0)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailSendAttachments(mailId, instancedItemId, slotIndex, sendTime);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailSendAttachments", mailId, instancedItemId, slotIndex, sendTime,
//                     });
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             
//             return success;
//         }
//
//         public static Guid Character_MailSend_Async(byte mailIndex, int senderCharacterId, string senderName, string mailSubject,
//             string mailBody, uint gold, byte silver, byte copper, bool currencyClaimed, bool contentsClaimed, bool unread,
//             int recipientCharacterId, long sendDateTime, long appearDateTime, long expireDateTime, byte logging = 0)
//         {
//             Guid mailId = Guid.NewGuid();
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailSend(mailId, mailIndex, senderCharacterId, senderName,
//                         mailSubject, mailBody, gold, silver, copper, currencyClaimed, contentsClaimed, unread, 
//                         recipientCharacterId, sendDateTime, appearDateTime, expireDateTime);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailSend", mailId, mailIndex, senderCharacterId, senderName, mailSubject,
//                     mailBody, gold, silver, copper, currencyClaimed, contentsClaimed, unread, recipientCharacterId,
//                     sendDateTime, appearDateTime, expireDateTime});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             return mailId;
//         }
//
//         public static bool Character_MailTakeAttachment_Async(Guid mailId, byte slotIndex, byte logging = 0)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MailTakeAttachment(mailId, slotIndex);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MailTakeAttachment", mailId, slotIndex});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             return success;
//         }
//         
//         public static void Character_MissionAbandoned_Async(int characterId, Guid missionIdBytes, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MissionAbandoned(characterId, missionIdBytes);
//                 });
//                 Storedprocs.Add(new object[] {"Character_MissionAbandoned", characterId, missionIdBytes});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//         }
//         
//         public static bool Character_MissionAccepted_Async(int characterId, Guid missionIdBytes, long acceptedDateTimeBinary,
//             byte logging, Action<Guid, bool> callback)
//         {
//             bool success = false;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_MissionAccepted(characterId, missionIdBytes);
//                 });
//                
//                 Storedprocs.Add(new object[] {"Character_MissionAccepted", characterId, missionIdBytes, acceptedDateTimeBinary});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             
//             return success;
//         }
//         
//         public static bool Character_MissionCompleted_Async(int characterId, Guid missionIdBytes, byte logging = 0)
//         {
//             QueueReader.ExecuteOnMainThread(() =>
//             {
//                 DataTableStoredProcs.Character_MissionCompleted(characterId, missionIdBytes);
//             });
//             Storedprocs.Add(new object[] {"Character_MissionCompleted", characterId, missionIdBytes});
//             return true;
//         }
//         
//         public static bool Character_RecipeAdd_Async(int characterId, string recipeGlobalObjectCode, byte logging, Action<Guid, ushort, ushort, bool> callback)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_RecipeAdd(characterId, recipeGlobalObjectCode);
//                 });
//                 Storedprocs.Add(new object[] {"Character_RecipeAdd", characterId, recipeGlobalObjectCode});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             return success;
//         }
//         
//         public static void Character_SaveExperience_Async(int characterId, int characterExperience, byte rankId, byte levelId, byte logging)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_SaveExperience(characterId, characterExperience, rankId, levelId);
//                 });
//                 Storedprocs.Add(new object[] {$"Character_SaveExperience", characterId, characterExperience, rankId, levelId, (short)Storedprocs.Count});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             //return success;
//         }
//         
//         public static void Character_SaveLocation_Async(Guid spawnedWorldObjectId, double coordinateX,
//             double coordinateY, double coordinateZ, int chunk, double rotationX, double rotationY, double rotationZ, byte logging)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_SaveLocation(spawnedWorldObjectId, coordinateX, coordinateY, coordinateZ,
//                         chunk, rotationX, rotationY, rotationZ);
//                 });
//                 Storedprocs.Add(new object[] {"Character_SaveLocation", spawnedWorldObjectId, coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY,rotationZ, Storedprocs.Count});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//         }
//         
//         public static bool Character_SkillsUpdate_Async(int characterId, string globalObjectCode, 
//             uint experienceAdded, byte characterSkillRankId, byte characterSkillLevelId, byte logging, Action<Guid, string, uint, bool> callback)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_SkillsUpdate(characterId, globalObjectCode, (int)experienceAdded, characterSkillRankId,
//                         characterSkillLevelId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_SkillsUpdate", characterId, globalObjectCode, experienceAdded, characterSkillRankId, characterSkillLevelId});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             
//             
//             return success;
//         }
//         
//         public static bool Character_SkillsAdd_Async(int characterId, string globalObjectCode, ushort skillId,
//             uint characterSkillExperience, byte characterSkillRankId, byte characterSkillLevelId, byte logging, Action<Guid, string, bool> callback)
//         {
//             bool success;
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_SkillsAdd(characterId, globalObjectCode,skillId, characterSkillExperience, characterSkillRankId, characterSkillLevelId);
//                 });
//                 Storedprocs.Add(new object[] {"Character_SkillsAdd", characterId, globalObjectCode, characterSkillExperience, characterSkillRankId, characterSkillLevelId});
//                 success = true;
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 success = false;
//             }
//             
//             return success;
//         }
//         
//         public static void Character_StatsUpdate_Async(int characterId, byte statTypeId, byte statId, float characterStatValue, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.Character_StatsUpdate( characterId, statTypeId, statId, characterStatValue);
//                 });
//                 Storedprocs.Add(new object[] {"Character_StatsUpdate", characterId, statTypeId, statId, characterStatValue});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         
//         #endregion
//
//         #region ASYNC: INSTANCED
//         public static Guid InstancedItems_ArmorCreate_Async(string globalObjectCode, byte rarityId, byte qualityId,
//             byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, 
//             Guid spawnedWorldObjectIdBytes, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_ArmorCreate(globalObjectCode, rarityId, qualityId, quantity,
//                         durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectIdBytes, 
//                         instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_ArmorCreate", globalObjectCode, rarityId, qualityId, 
//                     quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectIdBytes, instancedItemId,
//                     });
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             return instancedItemId;
//         }
//         
//         public static Guid InstancedItems_BagCreate_Async(string globalObjectCode, byte rarityId, byte qualityId, 
//             byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, byte bagSize,
//             Guid spawnedWorldObjectId, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_BagCreate(globalObjectCode, rarityId, qualityId, quantity,
//                         durabilityPercentage,wasCrafted, crafterName, wasLooted, bagSize, spawnedWorldObjectId, instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_BagCreate", globalObjectCode, rarityId, qualityId, quantity,
//                     durabilityPercentage, wasCrafted, crafterName, wasLooted, bagSize, spawnedWorldObjectId, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//            
//             return instancedItemId;
//         }
//
//         public static Guid InstancedItems_ConsumableCreate_Async(string globalObjectCode, byte rarityId, byte qualityId, 
//             byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, 
//             Guid spawnedWorldObjectIdBytes, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_ConsumableCreate(globalObjectCode, rarityId, qualityId, quantity,
//                         durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectIdBytes, 
//                         instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_ConsumableCreate", globalObjectCode, rarityId, qualityId, quantity, durabilityPercentage, spawnedWorldObjectIdBytes, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             return instancedItemId;
//         }
//         
//         public static void InstancedItems_DurabilityUpdate_Async(Guid instancedItemId,
//             float durabilityPercentage, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_DurabilityUpdate(instancedItemId, durabilityPercentage);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_DurabilityUpdate", instancedItemId, durabilityPercentage});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static Guid InstancedItems_GeneralItemCreate_Async( string globalObjectCode, byte rarityId, 
//             byte qualityId, byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, 
//             bool wasLooted, Guid spawnedWorldObjectId, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_GeneralItemCreate(globalObjectCode, rarityId, qualityId, quantity,
//                         durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_GeneralItemCreate", globalObjectCode, rarityId, qualityId, 
//                     quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//             
//             return instancedItemId;
//         }
//         
//         public static void InstancedItems_IngredientAdd_Async(Guid instancedItemId,string ingredientstring, byte logging = 0)
//         {
//             try
//             {
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.InstancedItems_IngredientAdd(instancedItemId, ingredientstring);
//                 });
//                 Storedprocs.Add(new object[] {"InstancedItems_IngredientAdd", instancedItemId, ingredientstring});
//             }
//             catch (Exception e)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//             }
//         }
//         
//         public static void InstancedItems_IsLooted_Async(Guid instancedItemId,
//             float durabilityPercentage, byte logging = 0)
//         {
//             QueueReader.ExecuteOnMainThread(() =>
//             {
//                 DataTableStoredProcs.InstancedItems_IsLooted(instancedItemId);
//             });
//             Storedprocs.Add(new object[] {"InstancedItems_IsLooted", instancedItemId, durabilityPercentage});
//         }
//         
//         public static Guid InstancedItems_MaterialCreate_Async(string globalObjectCode, byte rarityId, byte qualityId, 
//             byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted,
//             Guid spawnedWorldObjectId, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//             QueueReader.ExecuteOnMainThread(() =>
//             {
//                 DataTableStoredProcs.InstancedItems_MaterialCreate(globalObjectCode, rarityId, qualityId, quantity,
//                     durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId
//                     );
//             });
//             Storedprocs.Add(new object[] {"InstancedItems_MaterialCreate", globalObjectCode, rarityId, qualityId,
//                 quantity, durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId
//                 });
//             return instancedItemId;
//         }
//         
//         
//         
//         public static Guid InstancedItems_WeaponCreate_Async(string globalObjectCode, byte rarityId, byte qualityId, 
//             byte quantity, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted,
//             Guid spawnedWorldObjectId, byte logging = 0)
//         {
//             Guid instancedItemId = Guid.NewGuid();
//             QueueReader.ExecuteOnMainThread(() =>
//             {
//                 DataTableStoredProcs.InstancedItems_WeaponCreate(globalObjectCode, rarityId, qualityId, quantity,
//                     durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId);
//             });
//             Storedprocs.Add(new object[] {"InstancedItems_WeaponCreate", globalObjectCode, rarityId, qualityId, quantity, 
//                 durabilityPercentage, wasCrafted, crafterName, wasLooted, spawnedWorldObjectId, instancedItemId});
//             return instancedItemId;
//         }
//         
//         #endregion
//         
//         #region ASYNC: SPAWNED
//             public static Guid SpawnedWorldObjects_AnimalCreate_Async(string animalGlobalObjectCode,
//                 float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
//                 float rotationZ, byte rank, string variationId, bool ignoreSpawnTable, uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_AnimalCreate(animalGlobalObjectCode, coordinateX, coordinateY, 
//                             coordinateZ, chunk, rotationX, rotationY, rotationZ, 0,0,0, rank, variationId, ignoreSpawnTable, locationId, 
//                             spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_AnimalCreate", animalGlobalObjectCode, coordinateX, 
//                         coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, 
//                         rank, spawnedWorldObjectId});
//                    
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 return spawnedWorldObjectId;
//             }
//         
//             public static void SpawnedWorldObjects_AnimalDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_AnimalDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_AnimalDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 
//             }
//             
//             public static Guid SpawnedWorldObjects_ContainerCreate_Async(
//                 string containerGlobalObjectCode, float coordinateX, float coordinateY, float coordinateZ, int chunk,
//                 float rotationX, float rotationY, float rotationZ, byte rank, string variationId, bool ignoreSpawnTable, 
//                 uint locationId, byte logging, Action<Guid,bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//                 
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.SpawnedWorldObjects_ContainerCreate(containerGlobalObjectCode, coordinateX, coordinateY, coordinateZ, 
//                         chunk, rotationX, rotationY, rotationZ, 0,0,0, rank, variationId, ignoreSpawnTable, locationId, spawnedWorldObjectId);
//                 });
//                 Storedprocs.Add(new object[] {"SpawnedWorldObjects_ContainerCreate", containerGlobalObjectCode, coordinateX, 
//                     coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, rank, variationId, ignoreSpawnTable, locationId,
//                     spawnedWorldObjectId});
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_ContainerDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     Logger.LogError($"SpawnedWorldObjects_ContainerDelete_Async");
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_ContainerDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_ContainerDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//             }
//             
//             public static Guid SpawnedWorldObjects_EnemyHumanoidCreate_Async(
//                 string enemyHumanoidGlobalObjectCode, float coordinateX, float coordinateY, float coordinateZ, int chunk,
//                 float rotationX, float rotationY, float rotationZ, byte rank, string variationId, bool ignoreSpawnTable, 
//                 uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidCreate(enemyHumanoidGlobalObjectCode, coordinateX, 
//                             coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, 0,0,0, rank, variationId, ignoreSpawnTable, 
//                             locationId, spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_EnemyHumanoidCreate", enemyHumanoidGlobalObjectCode, 
//                         coordinateX, coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, 
//                         locationId, rank, spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_EnemyHumanoidDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 MethodBase method = MethodBase.GetCurrentMethod();
//                 try
//                 {
//                     Logger.LogError("SpawnedWorldObject_EnemyHumanoidDelete");
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_EnemyHumanoidDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_EnemyHumanoidDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//             }
//             
//             public static Guid SpawnedWorldObjects_GatherableCreate_Async(string interactableGlobalObjectCode, 
//                 float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
//                 float rotationZ, byte rank,string variationId, bool ignoreSpawnTable, uint locationId,  byte logging, Action<Guid, bool> callback)
//             {
//                 Logger.Log($"SpawnedWorldObjects_GatherableCreate: {interactableGlobalObjectCode} | {new Vector3(coordinateX, coordinateY, coordinateZ)}");
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_GatherableCreate(interactableGlobalObjectCode, coordinateX, 
//                             coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, 0,0,0, rank, variationId, ignoreSpawnTable, 
//                             locationId, spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_GatherableCreate", interactableGlobalObjectCode, coordinateX, 
//                         coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, rank, variationId, ignoreSpawnTable, 
//                         locationId, spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                
//                 
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_GatherableDelete_Async(Guid spawnedWorldObjectId, byte logging = 0, string adderName = "")
//             {
//                 try
//                 {
//                     Logger.LogError($"SpawnedWorldObject_GatherableDelete_Async: {adderName}");
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_GatherableDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_GatherableDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 
//             }
//             
//             public static Guid SpawnedWorldObjects_InteractableCreate_Async(string globalObjectId,
//                 float coordinateX, float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY,
//                 float rotationZ, byte rank, string variationId, bool ignoreSpawnTable, uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_InteractableCreate(globalObjectId, coordinateX, coordinateY,
//                             coordinateZ, chunk, rotationX, rotationY, rotationZ, 0,0,0,rank, variationId, ignoreSpawnTable, 
//                             locationId, spawnedWorldObjectId);
//                     });
//             
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_InteractableCreate", globalObjectId, coordinateX, 
//                         coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, 
//                         spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObject_InteractableDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_GatherableDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_InteractableDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//             }
//             
//             public static Guid SpawnedWorldObjects_MonsterCreate_Async(
//                 string monsterGlobalObjectCode, float coordinateX, float coordinateY, float coordinateZ, int chunk,
//                 float rotationX, float rotationY, float rotationZ, byte rank, string variationId, bool ignoreSpawnTable,  
//                 uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//                 QueueReader.ExecuteOnMainThread(() =>
//                 {
//                     DataTableStoredProcs.SpawnedWorldObjects_MonsterCreate(monsterGlobalObjectCode, coordinateX, 
//                         coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, 0,0,0,rank, variationId, 
//                         ignoreSpawnTable, locationId, spawnedWorldObjectId);
//                 });
//                 Storedprocs.Add(new object[]
//                 {
//                     "SpawnedWorldObjects_MonsterCreate", monsterGlobalObjectCode, coordinateX, 
//                     coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, rank, variationId, 
//                     ignoreSpawnTable, locationId, spawnedWorldObjectId
//                 });
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_MonsterDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_MonsterDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_MonsterDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 
//             }
//             
//             public static Guid SpawnedWorldObjects_NpcCreate_Async(
//                 string npcGlobalObjectCode, float coordinateX, float coordinateY, float coordinateZ, int chunk,
//                 float rotationX, float rotationY, float rotationZ, byte rank, string variationId, bool ignoreSpawnTable, 
//                 uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_NpcCreate(npcGlobalObjectCode, coordinateX, coordinateY, 
//                             coordinateZ, chunk, rotationX, rotationY, rotationZ,0,0,0, rank, variationId, ignoreSpawnTable,  
//                             locationId, spawnedWorldObjectId, 0);
//                     });
//                     Storedprocs.Add(new object[]
//                     {
//                         "SpawnedWorldObjects_NpcCreate", npcGlobalObjectCode, coordinateX, coordinateY,
//                         coordinateZ, chunk, rotationX, rotationY, rotationZ, variationId, ignoreSpawnTable, rank, 
//                         spawnedWorldObjectId
//                     });
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_NpcDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     Logger.LogError("SpawnedWorldObjects_NpcDelete_Async");
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_NpcDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_NpcDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//             }
//             
//             public static Guid SpawnedWorldObjects_VendorCreate_Async(
//                 string npcGlobalObjectCode, float coordinateX, float coordinateY, float coordinateZ, int chunk,
//                 float rotationX, float rotationY, float rotationZ, byte rank, string variationId, bool ignoreSpawnTable,  
//                 uint locationId, byte logging, Action<Guid, bool> callback)
//             {
//                 Guid spawnedWorldObjectId = Guid.NewGuid();
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_VendorCreate(npcGlobalObjectCode, coordinateX, coordinateY, coordinateZ, 
//                             chunk, rotationX, rotationY, rotationZ, 0,0,0,rank,variationId, ignoreSpawnTable, locationId, spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] { "SpawnedWorldObjects_VendorCreate", npcGlobalObjectCode, coordinateX, 
//                         coordinateY, coordinateZ, chunk, rotationX, rotationY, rotationZ, rank,variationId, ignoreSpawnTable, 
//                         locationId, spawnedWorldObjectId, 
//                          });
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 return spawnedWorldObjectId;
//             }
//             
//             public static void SpawnedWorldObjects_VendorDelete_Async(Guid spawnedWorldObjectId, byte logging = 0)
//             {
//                 try
//                 {
//                     Logger.LogError("SpawnedWorldObjects_VendorDelete_Async");
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_VendorDelete(spawnedWorldObjectId);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_VendorDelete", spawnedWorldObjectId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//             }
//             
//             public static void SpawnedWorldObjects_VendorsInventoryAddItem_Async(Guid spawnedWorldObjectId, string itemstring, 
//                 byte rarityId, byte currentStock, byte logging, Action<Guid, bool> callback)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_VendorsInventoryAddItem(spawnedWorldObjectId, itemstring, rarityId, 
//                             currentStock);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_VendorsInventoryAddItem", spawnedWorldObjectId, itemstring, rarityId, currentStock});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//             }
//             
//             public static void SpawnedWorldObjects_VendorUpdateQuantity_Async(Guid spawnedWorldObjectId, string itemstring, 
//                 byte rarityId, short amountChanged, byte logging, Action<Guid, bool> callback)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_VendorUpdateQuantity(spawnedWorldObjectId, itemstring, rarityId, 
//                             amountChanged);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_VendorUpdateQuantity", spawnedWorldObjectId, itemstring, rarityId, amountChanged});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                
//             }
//             
//             public static void SpawnedWorldObjects_VendorRestock_Async(Guid spawnedWorldObjectId, long lastRestockTime, 
//                 byte logging, Action<Guid, bool> callback)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                         DataTableStoredProcs.SpawnedWorldObjects_VendorRestock(spawnedWorldObjectId, lastRestockTime);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_VendorRestock", spawnedWorldObjectId, lastRestockTime.ToString("O", null)});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//                 
//                 
//             }
//             
//             public static void SpawnedWorldObjects_VendorBuyItem_Async(Guid vendorSpawnedWorldObjectId, int characterId, Guid instancedItemId,
//                 int goldChanged, short silverChanged, short copperChanged, short adventuringTokensChanged, short craftingTokensChanged,
//                 short gatheringTokensChanged, byte logging, Action<Guid, bool> callback)
//             {
//                 try
//                 {
//                     QueueReader.ExecuteOnMainThread(() =>
//                     {
//                     //     DataTableStoredProcs.SpawnedWorldObjects_VendorBuyItem( vendorSpawnedWorldObjectId, characterId, 
//                     //         instancedItemId,  goldChanged, silverChanged, copperChanged, adventuringTokensChanged,  
//                     //         craftingTokensChanged,  gatheringTokensChanged);
//                     });
//                     Storedprocs.Add(new object[] {"SpawnedWorldObjects_VendorSellItem", vendorSpawnedWorldObjectId, characterId, instancedItemId});
//                 }
//                 catch (Exception e)
//                 {
//                     MethodBase method = MethodBase.GetCurrentMethod();
//                     Logger.LogError($"SQL EXCEPTION ({method!.Name}) - {e}");
//                 }
//             }
//             #endregion
//     }
// }
//
// //#endif