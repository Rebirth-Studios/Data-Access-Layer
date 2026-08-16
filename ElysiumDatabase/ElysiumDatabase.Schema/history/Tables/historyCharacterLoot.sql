CREATE TABLE [history].[historyCharacterLoot] (
    [historyCharacterLootId] INT           IDENTITY (1, 1) NOT NULL,
    [characterId]            INT           NOT NULL,
    [lastUpdate]             DATETIME      NOT NULL,
    [itemGlobalObject]       VARCHAR (255) NOT NULL,
    [itemGlobalRarityId]     TINYINT       NOT NULL,
    [quantity]               INT           NOT NULL,
    CONSTRAINT [PK_historyCharacterLoot] PRIMARY KEY CLUSTERED ([historyCharacterLootId] ASC),
    CONSTRAINT [FK_historyCharacterLoot_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_historyCharacterLoot_historyCharacterLoot] FOREIGN KEY ([historyCharacterLootId]) REFERENCES [history].[historyCharacterLoot] ([historyCharacterLootId]),
    CONSTRAINT [FK_historyCharacterLoot_scriptableRarities] FOREIGN KEY ([itemGlobalRarityId]) REFERENCES [content].[scriptableRarities] ([typeId]),
    CONSTRAINT [historyCharacterLoot_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([itemGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject])
);


GO

