CREATE TABLE [history].[historyCharacterCollected] (
    [historyCharacterCollectedId] INT           IDENTITY (1, 1) NOT NULL,
    [characterId]                 INT           NOT NULL,
    [rarityId]                    TINYINT       NOT NULL,
    [itemGlobalObject]            VARCHAR (255) NOT NULL,
    [quantity]                    TINYINT       NOT NULL,
    [lastUpdate]                  DATETIME      NULL,
    CONSTRAINT [historyCharacterCollected_pk] PRIMARY KEY CLUSTERED ([historyCharacterCollectedId] ASC),
    CONSTRAINT [FK_historyCharacterCollected_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_historyCharacterCollected_scriptableRarities] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId]),
    CONSTRAINT [historyCharacterCollected_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([itemGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject])
);


GO

