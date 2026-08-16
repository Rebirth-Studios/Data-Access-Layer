CREATE TYPE [dbo].[tmpRestoreequipmentMaterialModifiers] AS TABLE (
    [materialId]               INT             NOT NULL,
    [material]                 VARCHAR (255)   NOT NULL,
    [globalObjectCode]         VARCHAR (255)   NOT NULL,
    [materialDifficultyPoints] INT             NOT NULL,
    [modifierDamage]           DECIMAL (18, 2) NOT NULL,
    [modifierDurability]       DECIMAL (18, 2) NOT NULL,
    [modifierWeight]           DECIMAL (18, 2) NOT NULL,
    [modifierManaCapacity]     DECIMAL (18, 2) NOT NULL,
    [modifierAttackSpeed]      DECIMAL (18, 2) NOT NULL,
    [modifierColorId]          INT             NOT NULL);


GO

