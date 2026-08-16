CREATE TABLE [content].[scriptableNPCS] (
    [id]                      SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]            VARCHAR (255)  NOT NULL,
    [npcMainTypeId]           TINYINT        NOT NULL,
    [npcClassificationTypeId] TINYINT        NOT NULL,
    [npcSubTypeId]            TINYINT        NOT NULL,
    [description]             VARCHAR (1000) NOT NULL,
    [globalObjectName]        AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [mainTypeName]            AS             ([dbo].[getNpcMainTypeName]([npcMainTypeId])),
    [classificationTypeName]  AS             ([dbo].[getNpcClassificationTypeName]([npcClassificationTypeId])),
    [subTypeName]             AS             ([dbo].[getNpcSubTypeName]([npcSubTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D4C1EB660E] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [scriptableNPCS_npcTypes_npcTypeId_fk] FOREIGN KEY ([npcMainTypeId]) REFERENCES [content].[npcTypes] ([typeId]),
    CONSTRAINT [scriptableNPCS_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D59BCBC46F] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

