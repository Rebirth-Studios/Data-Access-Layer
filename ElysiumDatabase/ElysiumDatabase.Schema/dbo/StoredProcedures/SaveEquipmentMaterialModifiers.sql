CREATE PROCEDURE [dbo].[SaveEquipmentMaterialModifiers]
   @equipmentMaterialModifiersDtl dbo.tmpequipmentMaterialModifiers READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO [content].[equipmentMaterialModifiers](materialId, material, globalObjectCode, materialDifficultyPoints, modifierDamage, modifierDurability, modifierWeight, modifierManaCapacity, modifierAttackSpeed, modifierColorId)
   SELECT materialId, material, globalObjectCode, materialDifficultyPoints, modifierDamage, modifierDurability, modifierWeight, modifierManaCapacity, modifierAttackSpeed, modifierColorId FROM @equipmentMaterialModifiersDtl
END

GO

