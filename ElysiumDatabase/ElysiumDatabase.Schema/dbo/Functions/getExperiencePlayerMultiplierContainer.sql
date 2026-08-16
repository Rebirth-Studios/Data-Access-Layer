CREATE FUNCTION [dbo].[getExperiencePlayerMultiplierContainer](@globalObject varchar(100))
RETURNS int
AS
BEGIN
    declare @experienceMultiplierPlayer INT
	declare @experienceMultiplierPlayerSub INT
	declare @experienceMultiplierPlayerClassification INT
	declare @experienceMultiplierPlayerMain INT
	SELECT @experienceMultiplierPlayerMain = ct.experienceMultiplierPlayer, @experienceMultiplierPlayerClassification = cct.experienceMultiplierPlayer, @experienceMultiplierPlayerSub = cst.experienceMultiplierPlayer
	FROM [content].[scriptableContainersSpawnable] scs
	JOIN [content].[scriptableContainers] sc ON scs.globalObject = sc.globalObject
	JOIN [content].[containerTypes] ct ON sc.containerMainTypeId = ct.typeId
	JOIN [content].[containerClassificationTypes] cct ON sc.containerClassificationTypeId = cct.typeId
	JOIN [content].[containerSubTypes] cst ON sc.containerSubTypeId = cst.typeId
	where scs.globalObject = @globalObject
	IF (@experienceMultiplierPlayerSub > 0) SET @experienceMultiplierPlayer = @experienceMultiplierPlayerSub
	ELSE IF (@experienceMultiplierPlayerClassification > 0) SET @experienceMultiplierPlayer = @experienceMultiplierPlayerClassification
	ELSE SET @experienceMultiplierPlayer = @experienceMultiplierPlayerMain

    RETURN @experienceMultiplierPlayer
END

GO

