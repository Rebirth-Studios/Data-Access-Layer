


CREATE PROCEDURE [dbo].[spQuestTypes_GetList]

AS
BEGIN
	SET NOCOUNT ON;
	Select questType,gS.status,qT.questStatusId,questTypeDescription,questTypeId
	From [content].[questTypes] qT
	JOIN [content].[globalStatuses] gS ON qT.questStatusId = gS.statusId
	Order by questType
	RETURN 0
END

GO

