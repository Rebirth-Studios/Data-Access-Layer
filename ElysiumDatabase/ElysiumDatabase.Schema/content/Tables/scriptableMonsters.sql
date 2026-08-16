CREATE TABLE [content].[scriptableMonsters] (
    [globalObject]                VARCHAR (255)  NOT NULL,
    [monsterMainTypeId]           TINYINT        NOT NULL,
    [monsterSubTypeId]            TINYINT        NOT NULL,
    [monsterClassificationTypeId] TINYINT        NOT NULL,
    [description]                 VARCHAR (1000) NOT NULL,
    [globalObjectName]            AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [mainTypeName]                AS             ([dbo].[getMonsterMainTypeName]([monsterMainTypeId])),
    [classificationTypeName]      AS             ([dbo].[getMonsterClassificationTypeName]([monsterClassificationTypeId])),
    [subTypeName]                 AS             ([dbo].[getMonsterSubTypeName]([monsterSubTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D4B44E9E15] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableMonsters_monsterSubTypes_monsterSubTypeId_fk] FOREIGN KEY ([monsterSubTypeId]) REFERENCES [content].[monsterSubTypes] ([typeId]),
    CONSTRAINT [scriptableMonsters_monsterTypes_monsterTypeId_fk] FOREIGN KEY ([monsterMainTypeId]) REFERENCES [content].[monsterTypes] ([typeId]),
    CONSTRAINT [scriptableMonsters_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D57C0E0CC7] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

