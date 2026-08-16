CREATE TABLE [runtime].[instancedEquipment] (
    [equipmentTypeId] TINYINT          NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]      DATETIME         NOT NULL,
    CONSTRAINT [instancedEquipment_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedEquipment_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId]),
    CONSTRAINT [instancedEquipment_equipmentTypes_equipmentTypeId_fk] FOREIGN KEY ([equipmentTypeId]) REFERENCES [content].[equipmentTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedEquipment_instancedItemId_uindex]
    ON [runtime].[instancedEquipment]([instancedItemId] ASC);


GO

