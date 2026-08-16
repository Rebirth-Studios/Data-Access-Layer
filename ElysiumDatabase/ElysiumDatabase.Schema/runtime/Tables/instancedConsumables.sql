CREATE TABLE [runtime].[instancedConsumables] (
    [lastUpdate]      DATETIME         NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedConsumables_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedConsumables_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedConsumables_instancedItemId_uindex]
    ON [runtime].[instancedConsumables]([instancedItemId] ASC);


GO

