


CREATE PROCEDURE [dbo].[spQuest_GetTiersRanks]

AS
BEGIN
	SET NOCOUNT ON;
	Select qtr.globalTierId As 'questTierId',questRankId,minDifficultyPoints,maxDifficultyPoints, gt.globalTierName As 'questTier'
	From [content].[questTiersRanks] qtr
	JOIN [content].[globalTiers] gt ON qtr.globalTierId = gt.globalTierId
	ORDER BY qtr.globalTierId, questRankId Asc
	RETURN 0
END

GO

