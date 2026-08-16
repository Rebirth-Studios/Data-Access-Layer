CREATE TABLE [content].[scriptableAchievements] (
    [achievementId]          INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]           VARCHAR (255)  NOT NULL,
    [achievementFactionId]   TINYINT        NOT NULL,
    [achievementIsUnique]    BIT            NOT NULL,
    [achievementDescription] VARCHAR (1000) NOT NULL,
    [achievementTypeId]      TINYINT        NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D55F814625] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableAchievements_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableAchievements_globalFactions_factionId_fk] FOREIGN KEY ([achievementFactionId]) REFERENCES [content].[globalFactions] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5BF67A70D] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

