CREATE TABLE [content].[scriptableEnemyHumanoids] (
    [globalObject]                      VARCHAR (255)  NOT NULL,
    [enemyHumanoidMainTypeId]           TINYINT        NOT NULL,
    [enemyHumanoidSubTypeId]            TINYINT        NOT NULL,
    [enemyHumanoidClassificationTypeId] TINYINT        NOT NULL,
    [description]                       VARCHAR (1000) NOT NULL,
    [globalObjectName]                  AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [mainTypeName]                      AS             ([dbo].[getEnemyHumanoidMainTypeName]([enemyHumanoidMainTypeId])),
    [classificationTypeName]            AS             ([dbo].[getEnemyHumanoidClassificationTypeName]([enemyHumanoidClassificationTypeId])),
    [subTypeName]                       AS             ([dbo].[getEnemyHumanoidSubTypeName]([enemyHumanoidSubTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D53A93E873] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableEnemyHumanoids_enemyHumanoidSubTypes_enemyHumanoidSubTypeId_fk] FOREIGN KEY ([enemyHumanoidSubTypeId]) REFERENCES [content].[enemyHumanoidSubTypes] ([typeId]),
    CONSTRAINT [scriptableEnemyHumanoids_enemyHumanoidTypes_enemyHumanoidTypeId_fk] FOREIGN KEY ([enemyHumanoidMainTypeId]) REFERENCES [content].[enemyHumanoidTypes] ([typeId]),
    CONSTRAINT [scriptableEnemyHumanoids_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5B35D8CC7] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

