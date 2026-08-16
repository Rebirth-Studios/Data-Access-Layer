CREATE PROCEDURE [dbo].[RestoreEquipmentMaterialModifiers]
   @equipmentMaterialModifiersDtl dbo.tmpRestoreequipmentMaterialModifiers READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO [content].[equipmentMaterialModifiers](materialId, material, globalObjectCode, materialDifficultyPoints, modifierDamage, modifierDurability, modifierWeight, modifierManaCapacity, modifierAttackSpeed, modifierColorId)
   SELECT materialId, material, globalObjectCode, materialDifficultyPoints, modifierDamage, modifierDurability, modifierWeight, modifierManaCapacity, modifierAttackSpeed, modifierColorId FROM @equipmentMaterialModifiersDtl
END

GO

