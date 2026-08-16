CREATE TABLE [runtime].[spawnedWorldObjectsCurrency] (
    [spawnedWorldObjectsCurrencyId] INT              IDENTITY (1, 1) NOT NULL,
    [lastUpdate]                    DATETIME         NOT NULL,
    [spawnedWorldObjectId]          UNIQUEIDENTIFIER NOT NULL,
    [amount_Gold]                   INT              NOT NULL,
    [amount_Silver]                 TINYINT          NOT NULL,
    [amount_Copper]                 TINYINT          NOT NULL,
    [token_adventuring]             INT              NOT NULL,
    [token_crafting]                INT              NOT NULL,
    [token_gathering]               INT              NOT NULL,
    CONSTRAINT [charactersCurrency_primaryKey] PRIMARY KEY CLUSTERED ([spawnedWorldObjectsCurrencyId] ASC),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency] CHECK ([amount_Gold]>=(0)),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency_1] CHECK ([amount_Silver]>=(0)),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency_2] CHECK ([amount_Copper]>=(0)),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency_3] CHECK ([token_adventuring]>=(0) AND [token_adventuring]<=(65535)),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency_4] CHECK ([token_crafting]>=(0) AND [token_crafting]<=(65535)),
    CONSTRAINT [CK_spawnedWorldObjectsCurrency_5] CHECK ([token_gathering]>=(0) AND [token_gathering]<=(65535)),
    CONSTRAINT [FK_charactersCurrency_spawnedWorldObjects] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

