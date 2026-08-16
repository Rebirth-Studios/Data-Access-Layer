


CREATE PROCEDURE [dbo].[spQuest_GetRewards]

AS
BEGIN
	SET NOCOUNT ON;
	Select qR.questRewardsId, qT.questType, qr.questTypeId, gT.adventurerTierName, questRewardTierId, questRewardItemCode, quantity, gT.globalRarityName, rarityId
	From questRewards qR
	JOIN [content].[questTypes] qT ON qR.questTypeId = qT.questTypeId
	JOIN [content].[globalTiers] gT On qR.rarityId = gT.globalTierId
	Order by questTypeId, questRewardTierId
	RETURN 0
END

GO

