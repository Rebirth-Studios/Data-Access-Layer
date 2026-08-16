CREATE TABLE [content].[scriptableQuestlineQuestOrder] (
    [scriptableQuestlineQuestOrderId] INT           IDENTITY (1, 1) NOT NULL,
    [questlineGlobalObject]           VARCHAR (255) NOT NULL,
    [questGlobalObject]               VARCHAR (255) NOT NULL,
    [orderNum]                        TINYINT       NOT NULL,
    [globalObjectName]                AS            ([dbo].[getGlobalObjectName]([questlineGlobalObject])),
    CONSTRAINT [PK_scriptableQuestlineQuestOrder] PRIMARY KEY CLUSTERED ([scriptableQuestlineQuestOrderId] ASC),
    CONSTRAINT [scriptableQuestlineQuestOrder_scriptableQuestlines_questlineGlobalObject_fk] FOREIGN KEY ([questlineGlobalObject]) REFERENCES [content].[scriptableQuestlines] ([questlineGlobalObject]),
    CONSTRAINT [scriptableQuestlineQuestOrder_scriptableQuests_questGlobalObject_fk] FOREIGN KEY ([questGlobalObject]) REFERENCES [content].[scriptableQuests] ([questGlobalObject])
);


GO

