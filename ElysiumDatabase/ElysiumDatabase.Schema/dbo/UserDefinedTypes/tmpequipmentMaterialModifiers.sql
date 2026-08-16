CREATE TYPE [dbo].[tmpequipmentMaterialModifiers] AS TABLE (
    [materialId]               INT           NOT NULL,
    [material]                 VARCHAR (255) NOT NULL,
    [globalObjectCode]         VARCHAR (255) NOT NULL,
    [materialDifficultyPoints] INT           NOT NULL,
    [modifierDamage]           FLOAT (53)    NOT NULL,
    [modifierDurability]       FLOAT (53)    NOT NULL,
    [modifierWeight]           FLOAT (53)    NOT NULL,
    [modifierManaCapacity]     FLOAT (53)    NOT NULL,
    [modifierAttackSpeed]      FLOAT (53)    NOT NULL,
    [modifierColorId]          INT           NOT NULL,
    [modifierDefense]          VARCHAR (255) NOT NULL);


GO

