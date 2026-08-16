

CREATE FUNCTION [dbo].[getStatEffectName](@statEffectAmount DECIMAL(18,1), @statEffectAmountTypeId TINYINT, @statId TINYINT, @statTypeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @statEffectName VARCHAR(255)
	DECLARE @statName VARCHAR(255)
	DECLARE @statTypeName VARCHAR(255)
	DECLARE @statEffectAmountType VARCHAR(255)
	DECLARE @posOrNeg VARCHAR(1)
	DECLARE @sign VARCHAR(5)

	SELECT @statName = statName
	FROM [content].[stats]
	WHERE statId = @statId AND statTypeId = @statTypeId;

	SELECT @statTypeName = typeName
	FROM [content].[statTypes]
	WHERE typeId = @statTypeId;

	SELECT @statEffectAmountType = typeName
	FROM [content].[effectAmountTypes]
	WHERE typeId = @statEffectAmountTypeId

	IF @statEffectAmountType = 'PercentageAdditive' SET @sign = '%'
	IF @statTypeName = 'Resistance' SET @sign = '%'

	SET @statEffectName = '';

	IF @statEffectAmount > 0 
		SET @posOrNeg = '+' --ELSE SET @posOrNeg = '-'
	ELSE 
		SET @posOrNeg = ''

	IF @sign IS NOT NULL 
		SET @statEffectName = @posOrNeg + CONVERT(VARCHAR, @statEffectAmount) + @sign + ' ' +  @statName
	ELSE 
		SET @statEffectName = @posOrNeg + CONVERT(VARCHAR, @statEffectAmount) + ' ' +  @statName

	SET @statEffectName = REPLACE(@statEffectName, '.0', '');
    RETURN @statEffectName
END

GO

