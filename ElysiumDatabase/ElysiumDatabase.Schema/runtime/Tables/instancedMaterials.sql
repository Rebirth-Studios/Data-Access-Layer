CREATE TABLE [runtime].[instancedMaterials] (
    [lastUpdate]      DATETIME         NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedMaterials_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedMaterials_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedMaterials_instancedItemId_uindex]
    ON [runtime].[instancedMaterials]([instancedItemId] ASC);


GO

