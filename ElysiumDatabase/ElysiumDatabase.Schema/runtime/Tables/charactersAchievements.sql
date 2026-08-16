CREATE TABLE [runtime].[charactersAchievements] (
    [characterAchievementId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]           VARCHAR (255) NOT NULL,
    [lastUpdated]            DATETIME      NOT NULL,
    [characterId]            INT           NOT NULL,
    CONSTRAINT [charactersAchievements_primaryKey] PRIMARY KEY CLUSTERED ([characterAchievementId] ASC),
    CONSTRAINT [charactersAchievements_scriptableAchievements_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableAchievements] ([globalObject]),
    CONSTRAINT [FK_charactersAchievements_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [charactersAchievements_characterId_globalObject_uindex]
    ON [runtime].[charactersAchievements]([characterId] ASC, [globalObject] ASC);


GO

