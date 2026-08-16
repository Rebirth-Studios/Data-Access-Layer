CREATE TABLE [runtime].[instancedGeneralItems] (
    [lastUpdate]      DATETIME         NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedGeneralItems_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedGeneralItems_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId])
);


GO

