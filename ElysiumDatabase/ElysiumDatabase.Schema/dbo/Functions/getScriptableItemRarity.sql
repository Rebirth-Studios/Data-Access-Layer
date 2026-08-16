CREATE FUNCTION [dbo].[getScriptableItemRarity](@globalObject VARCHAR(255), @rarityId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @scriptableItemRarity VARCHAR(255)
	

	SET @scriptableItemRarity = @globalObject + 'Rarity' + CONVERT(VARCHAR, @rarityId);

    RETURN @scriptableItemRarity
END

GO

