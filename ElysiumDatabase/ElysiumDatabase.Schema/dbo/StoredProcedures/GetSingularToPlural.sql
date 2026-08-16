
CREATE PROCEDURE [dbo].[GetSingularToPlural]
	@Player_Id int output
AS

	Select Singular, Plural
	From SingularToPlural 
	RETURN 0

GO

