CREATE TABLE [runtime].[instancedBags] (
    [slots]           TINYINT          NOT NULL,
    [lastUpdate]      DATETIME         NOT NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedBags_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedBags_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [instancedBags_instancedItemId_uindex]
    ON [runtime].[instancedBags]([instancedItemId] ASC);


GO

