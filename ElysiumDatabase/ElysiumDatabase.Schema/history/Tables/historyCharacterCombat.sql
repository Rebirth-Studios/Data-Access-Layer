CREATE TABLE [history].[historyCharacterCombat] (
    [historyCharacterCombatId] INT      IDENTITY (1, 1) NOT NULL,
    [characterId]              INT      NOT NULL,
    [blocks]                   INT      NOT NULL,
    [blocked]                  INT      NOT NULL,
    [strikesReceived]          INT      NOT NULL,
    [strikesGiven]             INT      NOT NULL,
    [damageReceived]           INT      NOT NULL,
    [damageGiven]              INT      NOT NULL,
    [lastUpdate]               DATETIME NOT NULL,
    CONSTRAINT [PK_historyCharacterCombat] PRIMARY KEY CLUSTERED ([historyCharacterCombatId] ASC),
    CONSTRAINT [FK_historyCharacterCombat_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

