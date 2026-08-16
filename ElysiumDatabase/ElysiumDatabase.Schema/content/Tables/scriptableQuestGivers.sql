CREATE TABLE [content].[scriptableQuestGivers] (
    [id]               SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]     VARCHAR (255)  NOT NULL,
    [description]      VARCHAR (1000) NOT NULL,
    [globalObjectName] AS             ([dbo].[getGlobalObjectName]([globalObject])),
    CONSTRAINT [PK_scriptableQuestGivers] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableQuestGivers_scriptableNPCS] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableNPCS] ([globalObject])
);


GO

