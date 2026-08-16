CREATE TABLE [runtime].[spawnedGatherables] (
    [lastUpdate]           DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [spawnedGatherables_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedGatherables_spawnedInteractables_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedInteractables] ([spawnedWorldObjectId])
);


GO

