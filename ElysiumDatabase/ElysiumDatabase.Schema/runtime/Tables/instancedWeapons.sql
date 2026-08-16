CREATE TABLE [runtime].[instancedWeapons] (
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]      DATETIME         NOT NULL,
    CONSTRAINT [instancedWeapons_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedWeapons_instancedEquipment] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedEquipment] ([instancedItemId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedWeapons_instancedItemId_uindex]
    ON [runtime].[instancedWeapons]([instancedItemId] ASC);


GO

