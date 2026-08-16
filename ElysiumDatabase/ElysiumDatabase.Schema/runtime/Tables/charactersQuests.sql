CREATE TABLE [runtime].[charactersQuests] (
    [characterQuestId]  INT           IDENTITY (1, 1) NOT NULL,
    [characterId]       INT           NOT NULL,
    [questGlobalObject] VARCHAR (255) NOT NULL,
    [questStatusId]     TINYINT       NOT NULL,
    CONSTRAINT [PK_charactersQuests] PRIMARY KEY CLUSTERED ([characterQuestId] ASC),
    CONSTRAINT [charactersQuests_scriptableQuests_questGlobalObject_fk] FOREIGN KEY ([questGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject]),
    CONSTRAINT [FK_charactersQuests_characters1] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_charactersQuests_questStatus] FOREIGN KEY ([questStatusId]) REFERENCES [content].[questStatus] ([typeId])
);


GO

