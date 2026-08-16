
CREATE PROCEDURE [dbo].[spQuest_GetTiersRanksRewards]

AS
BEGIN
	SET NOCOUNT ON;
	Select questTypeId, questTierId, questRankId, questRankName, minItemChance, maxMultiplier, minItemsAwarded, maxItemsAwardedBonus, coreRewardId, rarityId
	From [content].[questTiersRanksRewards] 
	Order by questTypeId, questTierId, questRankId
	RETURN 0
END

GO

