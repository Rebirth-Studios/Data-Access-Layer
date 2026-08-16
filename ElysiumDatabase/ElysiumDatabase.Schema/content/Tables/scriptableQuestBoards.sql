CREATE TABLE [content].[scriptableQuestBoards] (
    [questBoardTypeId]   TINYINT       NOT NULL,
    [globalObject]       VARCHAR (255) NOT NULL,
    [globalObjectName]   AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [questBoardTypeName] AS            ([dbo].[getQuestBoardTypeName]([questBoardTypeId])),
    PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableQuestBoards_questCategoryTypes_questCategoryTypeId_fk] FOREIGN KEY ([questBoardTypeId]) REFERENCES [content].[questBoardTypes] ([typeId]),
    CONSTRAINT [scriptableQuestBoards_scriptableInteractables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableInteractables] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

