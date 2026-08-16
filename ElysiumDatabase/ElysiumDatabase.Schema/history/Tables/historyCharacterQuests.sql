CREATE TABLE [history].[historyCharacterQuests] (
    [historyCharacterQuestId] INT      IDENTITY (1, 1) NOT NULL,
    [characterId]             INT      NOT NULL,
    [questTypeId]             INT      NOT NULL,
    [questTierId]             INT      NOT NULL,
    [questRankId]             INT      NOT NULL,
    [lastUpdate]              DATETIME NOT NULL,
    CONSTRAINT [PK_historyCharacterQuests] PRIMARY KEY CLUSTERED ([historyCharacterQuestId] ASC),
    CONSTRAINT [FK_historyCharacterQuests_historyCharacterQuests] FOREIGN KEY ([historyCharacterQuestId]) REFERENCES [history].[historyCharacterQuests] ([historyCharacterQuestId]),
    CONSTRAINT [historyCharacterQuests_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

