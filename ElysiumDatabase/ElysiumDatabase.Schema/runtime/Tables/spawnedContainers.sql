CREATE TABLE [runtime].[spawnedContainers] (
    [lastUpdate]           DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [openedBefore]         BIT              NULL,
    CONSTRAINT [spawnedContainers_primaryKey] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedContainers_spawnedInteractables_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedInteractables] ([spawnedWorldObjectId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [spawnedContainers_spawnedWorldObjectId_uindex]
    ON [runtime].[spawnedContainers]([spawnedWorldObjectId] ASC);


GO

