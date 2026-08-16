CREATE TABLE [content].[scriptableStructuresLevels] (
    [id]                        SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]              VARCHAR (255)  NOT NULL,
    [scriptableObjectLevel]     VARCHAR (255)  NOT NULL,
    [spawnerPercentSpawned]     DECIMAL (5, 2) NOT NULL,
    [respawnTime]               SMALLINT       NOT NULL,
    [levelId]                   AS             ([dbo].[getLevelIdFromScriptableObjectLevel]([scriptableObjectLevel])),
    [globalObjectName]          AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [scriptableObjectLevelName] AS             ([dbo].[getScriptableObjectLevelNameFromScriptableObjectLevel]([scriptableObjectLevel])),
    CONSTRAINT [PK_scriptableStructuresLevels] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresLevels_scriptableObjectLevels] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK_scriptableStructuresLevels_scriptableStructures] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject])
);


GO

