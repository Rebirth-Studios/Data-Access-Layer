CREATE TABLE [runtime].[charactersBuyBacks] (
    [instancedBuyBackId] INT              IDENTITY (1, 1) NOT NULL,
    [instancedItemId]    UNIQUEIDENTIFIER NULL,
    [soldDate]           DATETIME         NULL,
    [characterId]        INT              NOT NULL,
    CONSTRAINT [PK_characterBuyBacks] PRIMARY KEY CLUSTERED ([instancedBuyBackId] ASC),
    CONSTRAINT [charactersBuyBacks_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_instancedBuyBacks_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId])
);


GO

