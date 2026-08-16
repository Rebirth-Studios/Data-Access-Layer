



CREATE PROCEDURE [dbo].[spTruncateDataForLoad]
	-- Add the parameters for the stored procedure here
	@updateCode bit OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @updateCode = 0

	-- Insert statements for procedure here
	Truncate Table [content].[globalObjects]
	Truncate Table [content].[globalTiers]
	Truncate Table lootDropRate
	Truncate Table lootRarityRate
	Truncate Table [content].[questTypes]
	Truncate Table [content].[questTiersRanks]
	Truncate Table questObjectives
	Truncate Table [content].[questTiersRanksRewards]
	Truncate Table questRewards
	Truncate Table questObjectives
	SET @updateCode = 1
END

GO

