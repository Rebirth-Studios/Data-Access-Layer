CREATE TABLE [history].[historyCharacterKills] (
    [historyCharacterKillId] INT           IDENTITY (1, 1) NOT NULL,
    [characterId]            INT           NOT NULL,
    [lastUpdate]             DATETIME      NOT NULL,
    [entityGlobalObject]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_historyCharacterKills] PRIMARY KEY CLUSTERED ([historyCharacterKillId] ASC),
    CONSTRAINT [FK_historyCharacterKills_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_historyCharacterKills_scriptableEntities] FOREIGN KEY ([entityGlobalObject]) REFERENCES [content].[scriptableEntities] ([globalObject])
);


GO

