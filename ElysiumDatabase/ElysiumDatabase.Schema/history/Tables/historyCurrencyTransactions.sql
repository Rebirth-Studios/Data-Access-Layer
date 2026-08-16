CREATE TABLE [history].[historyCurrencyTransactions] (
    [historyCurrencyTransactionId] INT              IDENTITY (1, 1) NOT NULL,
    [transactionDate]              DATETIME         NOT NULL,
    [amount_Gold]                  INT              NOT NULL,
    [amount_Silver]                SMALLINT         NOT NULL,
    [amount_Copper]                SMALLINT         NOT NULL,
    [description]                  VARCHAR (255)    NOT NULL,
    [tokens_Adventurer]            SMALLINT         NULL,
    [tokens_Gatherer]              SMALLINT         NULL,
    [tokens_Crafter]               SMALLINT         NULL,
    [spawnedWorldObjectId]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_historyCurrencyTransactions] PRIMARY KEY CLUSTERED ([historyCurrencyTransactionId] ASC),
    CONSTRAINT [historyCurrencyTransactions_spawnedWorldObjects_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

