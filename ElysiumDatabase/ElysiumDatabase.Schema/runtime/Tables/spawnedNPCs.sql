CREATE TABLE [runtime].[spawnedNPCs] (
    [lastUpdate]           DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [npcTypeId]            TINYINT          NOT NULL,
    CONSTRAINT [spawnedNPCs_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedNPCs_npcTypes_npcTypeId_fk] FOREIGN KEY ([npcTypeId]) REFERENCES [content].[npcTypes] ([typeId]),
    CONSTRAINT [spawnedNPCs_spawnedEntities_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedEntities] ([spawnedWorldObjectId])
);


GO

