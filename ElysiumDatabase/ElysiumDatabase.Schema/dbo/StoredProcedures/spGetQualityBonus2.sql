



Create PROCEDURE [dbo].[spGetQualityBonus2]
	-- Add the parameters for the stored procedure here
	@qualityPoints int,
	@qualityBonus int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	Select @qualityBonus = qbt.qualityBonus FROM qualityBonusTable qbt WHERE @qualityPoints >= qbt.qualityMinPoints And @qualityPoints <= qbt.qualityMaxPoints
	
	RETURN 0
END

GO

