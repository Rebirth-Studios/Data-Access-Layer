CREATE TABLE [runtime].[instancedArmor] (
    [lastUpdate]      DATETIME         NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedArmor_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedArmor_instancedEquipment] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedEquipment] ([instancedItemId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedArmor_instancedItemId_uindex]
    ON [runtime].[instancedArmor]([instancedItemId] ASC);


GO

