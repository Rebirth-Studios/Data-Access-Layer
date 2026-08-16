CREATE TABLE [runtime].[charactersQuestsObjectives] (
    [charactersQuestObjectivesId] INT           IDENTITY (1, 1) NOT NULL,
    [questGlobalObject]           VARCHAR (255) NOT NULL,
    [objectiveGlobalObject]       VARCHAR (255) NOT NULL,
    [numRequired]                 SMALLINT      NOT NULL,
    [currentProgress]             SMALLINT      NOT NULL,
    [characterId]                 INT           NOT NULL,
    CONSTRAINT [PK_charactersQuestsObjectives] PRIMARY KEY CLUSTERED ([charactersQuestObjectivesId] ASC),
    CONSTRAINT [charactersQuestsObjectives___fkc] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_charactersQuestsObjectives_charactersQuestsObjectives] FOREIGN KEY ([charactersQuestObjectivesId]) REFERENCES [runtime].[charactersQuestsObjectives] ([charactersQuestObjectivesId]),
    CONSTRAINT [FK_charactersQuestsObjectives_charactersQuestsObjectives1] FOREIGN KEY ([charactersQuestObjectivesId]) REFERENCES [runtime].[charactersQuestsObjectives] ([charactersQuestObjectivesId]),
    CONSTRAINT [FK_charactersQuestsObjectives_globalObjects] FOREIGN KEY ([objectiveGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_charactersQuestsObjectives_scriptableQuests] FOREIGN KEY ([questGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject])
);


GO

