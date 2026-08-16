CREATE TABLE [history].[historyCharacterDeaths] (
    [historyCharacterDeathId] INT              IDENTITY (1, 1) NOT NULL,
    [characterId]             INT              NOT NULL,
    [killedBySpawnedWorldId]  UNIQUEIDENTIFIER NOT NULL,
    [globalTierId]            TINYINT          NOT NULL,
    [globalRankId]            TINYINT          NOT NULL,
    [lastUpdate]              DATETIME         NOT NULL,
    CONSTRAINT [PK_historyCharacterDeaths] PRIMARY KEY CLUSTERED ([historyCharacterDeathId] ASC),
    CONSTRAINT [historyCharacterDeaths_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [historyCharacterDeaths_globalRanks_globalRankId_fk] FOREIGN KEY ([globalRankId]) REFERENCES [content].[globalRanks] ([globalRankId]),
    CONSTRAINT [historyCharacterDeaths_globalTiers_globalTierId_fk] FOREIGN KEY ([globalTierId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [historyCharacterDeaths_spawnedWorldObjects_spawnedWorldObjectId_fk] FOREIGN KEY ([killedBySpawnedWorldId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

