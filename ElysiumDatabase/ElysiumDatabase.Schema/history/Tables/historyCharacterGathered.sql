CREATE TABLE [history].[historyCharacterGathered] (
    [historyCharacterGatheredId] INT           IDENTITY (1, 1) NOT NULL,
    [characterId]                INT           NOT NULL,
    [lastUpdate]                 DATETIME      NOT NULL,
    [gatherableGlobalObject]     VARCHAR (255) NOT NULL,
    [rankId]                     TINYINT       NOT NULL,
    [variationId]                TINYINT       NOT NULL,
    CONSTRAINT [PK_historyCharacterGathering] PRIMARY KEY CLUSTERED ([historyCharacterGatheredId] ASC),
    CONSTRAINT [historyCharacterGathered_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [historyCharacterGathered_scriptableGatherables_globalObjectCode_fk] FOREIGN KEY ([gatherableGlobalObject]) REFERENCES [content].[scriptableGatherables] ([globalObject])
);


GO

