CREATE TABLE [content].[scriptableStructuresEnemyHumanoids] (
    [id]                           SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]                 VARCHAR (255) NOT NULL,
    [enemyHumanoidStructureTypeId] TINYINT       NOT NULL,
    [globalObjectName]             AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [enemyHumanoidStructureType]   AS            ([dbo].[getEnemyHumanoidStructureTypeName]([enemyHumanoidStructureTypeId])),
    CONSTRAINT [PK_scriptableStructuresEnemyHumanoids] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresEnemyHumanoids_scriptableStructuresEnemyHumanoids] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [scriptableStructuresEnemyHumanoids_enemyHumanoidStructureTypes_enemyHumanoidStructureTypeId_fk] FOREIGN KEY ([enemyHumanoidStructureTypeId]) REFERENCES [content].[enemyHumanoidStructureTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5FDDD27C2] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

