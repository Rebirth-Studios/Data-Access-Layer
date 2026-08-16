CREATE TABLE [runtime].[instancedMissions] (
    [characterQuestId]               INT            IDENTITY (1, 1) NOT NULL,
    [characterQuestTitle]            VARCHAR (1000) NOT NULL,
    [characterQuestTypeId]           INT            NOT NULL,
    [characterQuestTierId]           INT            NOT NULL,
    [characterQuestDescription]      VARCHAR (1000) NOT NULL,
    [characterQuestRequiredProgress] INT            NOT NULL,
    [characterQuestCurrentProgress]  INT            NOT NULL,
    [characterQuestObjectiveId]      INT            NULL,
    [characterQuestRankId]           INT            NOT NULL,
    [characterQuestStatusId]         INT            NOT NULL,
    [characterQuestValue]            INT            NOT NULL,
    [characterQuestObjective]        VARCHAR (255)  NOT NULL,
    [lastUpdated]                    DATETIME       NOT NULL,
    [characterId]                    INT            NOT NULL,
    CONSTRAINT [charactersQuests_primaryKey] PRIMARY KEY CLUSTERED ([characterQuestId] ASC),
    CONSTRAINT [FK_charactersQuests_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

