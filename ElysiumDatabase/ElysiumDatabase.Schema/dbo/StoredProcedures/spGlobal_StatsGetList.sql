





CREATE PROCEDURE [dbo].[spGlobal_StatsGetList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	SET NOCOUNT ON;

	Select gS.globalStatId, gS.globalStat, sT.statType, gStat.status, gS.statValue, gS.statDescription 
	FROM [content].[globalStats] gS
	JOIN [content].[statTypes] sT ON gS.statTypeId = sT.statTypeId
	JOIN [content].[stats] ON gS.globalStatId = stats.statId AND gS.statTypeId = stats.statTypeId
	JOIN [content].[globalStatuses] gStat ON gS.statStatusId = gStat.statusId
	RETURN 0
END

GO

