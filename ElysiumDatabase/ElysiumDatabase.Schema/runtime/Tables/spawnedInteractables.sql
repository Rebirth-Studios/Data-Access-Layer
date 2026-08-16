CREATE TABLE [runtime].[spawnedInteractables] (
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    [interactableTypeId]   TINYINT          NOT NULL,
    CONSTRAINT [spawnedInteractables_primaryKey] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [FK_spawnedInteractables_spawnedWorldObjects] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId]),
    CONSTRAINT [spawnedInteractables_interactableTypes_interactableTypeId_fk] FOREIGN KEY ([interactableTypeId]) REFERENCES [content].[interactableTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_spawnedInteractables_spawnedWorldObjectId]
    ON [runtime].[spawnedInteractables]([spawnedWorldObjectId] ASC);


GO

