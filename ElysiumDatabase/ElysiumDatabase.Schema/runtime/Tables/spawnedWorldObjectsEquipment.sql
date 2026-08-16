CREATE TABLE [runtime].[spawnedWorldObjectsEquipment] (
    [spawnedWorldObjectsEquipmentId] INT              IDENTITY (1, 1) NOT NULL,
    [instancedItemId]                UNIQUEIDENTIFIER NULL,
    [spawnedWorldObjectId]           UNIQUEIDENTIFIER NOT NULL,
    [equipmentLocationId]            TINYINT          NOT NULL,
    [lastUpdate]                     DATETIME         NOT NULL,
    CONSTRAINT [FK_spawnedWorldObjects_spawnedWorldObjects] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId]),
    CONSTRAINT [spawnedWorldObjectsEquipment_equipmentLocations_equipmentLocationId_fk] FOREIGN KEY ([equipmentLocationId]) REFERENCES [content].[equipmentSlotTypes] ([typeId]),
    CONSTRAINT [spawnedWorldObjectsEquipment_instancedItems_instancedItemId_fk] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId]),
    CONSTRAINT [spawnedWorldObjectsEquipment_pk] UNIQUE NONCLUSTERED ([spawnedWorldObjectId] ASC, [equipmentLocationId] ASC),
    CONSTRAINT [spawnedWorldObjectsEquipment_primaryKey] UNIQUE CLUSTERED ([spawnedWorldObjectsEquipmentId] ASC)
);


GO

