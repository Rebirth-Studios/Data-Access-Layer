CREATE TABLE [history].[historyCharacterCrafted] (
    [historyCharacterCraftedId] INT           IDENTITY (1, 1) NOT NULL,
    [characterId]               INT           NOT NULL,
    [rarityId]                  TINYINT       NOT NULL,
    [itemGlobalObject]          VARCHAR (255) NOT NULL,
    [quantity]                  TINYINT       NOT NULL,
    [lastUpdate]                DATETIME      NULL,
    CONSTRAINT [PK_historyCharacterCrafted] PRIMARY KEY CLUSTERED ([historyCharacterCraftedId] ASC),
    CONSTRAINT [historyCharacterCrafted_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [historyCharacterCrafted_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([itemGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [historyCharacterCrafted_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

