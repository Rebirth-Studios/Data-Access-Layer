CREATE FUNCTION [dbo].[getExperiencePlayerMultiplierGatherable](@globalObject varchar(100))
RETURNS int
AS
BEGIN
    DECLARE @experienceMultiplierPlayer INT
	DECLARE @experienceMultiplierPlayerSub INT
	DECLARE @experienceMultiplierPlayerClassification INT
	DECLARE @experienceMultiplierPlayerMain INT

	SELECT @experienceMultiplierPlayerMain = ct.experienceMultiplierPlayer, @experienceMultiplierPlayerClassification = cct.experienceMultiplierPlayer, @experienceMultiplierPlayerSub = cst.experienceMultiplierPlayer
	FROM [content].[scriptableGatherablesSpawnable] scs
	JOIN [content].[scriptableGatherables] sc ON scs.globalObject = sc.globalObject
	JOIN [content].[gatherableTypes] ct ON sc.gatherableTypeId = ct.typeId
	JOIN [content].[gatherableClassificationTypes] cct ON sc.gatherableClassificationTypeId = cct.typeId
	JOIN [content].[gatherableSubTypes] cst ON sc.gatherableSubTypeId = cst.typeId
	where scs.globalObject = @globalObject
	IF (@experienceMultiplierPlayerSub > 0) SET @experienceMultiplierPlayer = @experienceMultiplierPlayerSub
	ELSE IF (@experienceMultiplierPlayerClassification > 0) SET @experienceMultiplierPlayer = @experienceMultiplierPlayerClassification
	ELSE SET @experienceMultiplierPlayer = @experienceMultiplierPlayerMain

    RETURN @experienceMultiplierPlayer
END

GO

