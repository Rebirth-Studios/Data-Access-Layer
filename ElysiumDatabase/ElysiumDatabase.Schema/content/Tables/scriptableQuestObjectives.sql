CREATE TABLE [content].[scriptableQuestObjectives] (
    [scriptableQuestObjectivesId] INT           IDENTITY (1, 1) NOT NULL,
    [questGlobalObject]           VARCHAR (255) NOT NULL,
    [objectiveGlobalObject]       VARCHAR (255) NOT NULL,
    [objectiveTypeId]             TINYINT       NOT NULL,
    [requiredRankId]              TINYINT       NOT NULL,
    [requiredLevelId]             TINYINT       NOT NULL,
    [numRequired]                 SMALLINT      NOT NULL,
    [globalObjectName]            AS            ([dbo].[getGlobalObjectName]([questGlobalObject])),
    [objectiveName]               AS            ([dbo].[getGlobalObjectName]([objectiveGlobalObject])),
    [objectiveType]               AS            ([dbo].[getQuestObjectiveTypeName]([objectiveTypeId])),
    CONSTRAINT [PK_scriptableQuestObjectives] PRIMARY KEY CLUSTERED ([scriptableQuestObjectivesId] ASC),
    CONSTRAINT [FK_scriptableQuestObjectives_globalObjects] FOREIGN KEY ([objectiveGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [scriptableQuestObjectives_globalRanks_globalRankId_fk] FOREIGN KEY ([requiredRankId]) REFERENCES [content].[globalRanks] ([globalRankId]),
    CONSTRAINT [scriptableQuestObjectives_questObjectiveTypes_questObjectiveTypeId_fk] FOREIGN KEY ([objectiveTypeId]) REFERENCES [content].[questObjectiveTypes] ([typeId]),
    CONSTRAINT [scriptableQuestObjectives_scriptableQuests_questGlobalObject_fk] FOREIGN KEY ([questGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableQuestObjectives_questGlobalObject_objectiveGlobalObject_uindex]
    ON [content].[scriptableQuestObjectives]([questGlobalObject] ASC, [objectiveGlobalObject] ASC);


GO

