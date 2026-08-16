CREATE TABLE [content].[scriptableQuestExclusions] (
    [scriptableQuestExclusionsId] INT           IDENTITY (1, 1) NOT NULL,
    [questGlobalObject]           VARCHAR (255) NOT NULL,
    [excludedQuestGlobalObject]   VARCHAR (255) NOT NULL,
    [globalObjectName]            AS            ([dbo].[getGlobalObjectName]([questGlobalObject])),
    [excludedQuestName]           AS            ([dbo].[getGlobalObjectName]([excludedQuestGlobalObject])),
    CONSTRAINT [PK_scriptableQuestExclusions] PRIMARY KEY CLUSTERED ([scriptableQuestExclusionsId] ASC),
    CONSTRAINT [scriptableQuestExclusions_scriptableQuests_questGlobalObject_fk] FOREIGN KEY ([questGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject]),
    CONSTRAINT [scriptableQuestExclusions_scriptableQuests_questGlobalObject_fk_2] FOREIGN KEY ([excludedQuestGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject])
);


GO

