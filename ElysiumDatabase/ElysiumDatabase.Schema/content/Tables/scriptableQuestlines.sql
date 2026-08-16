CREATE TABLE [content].[scriptableQuestlines] (
    [questlineGlobalObject] VARCHAR (255) NOT NULL,
    [globalObjectName]      AS            ([dbo].[getGlobalObjectName]([questlineGlobalObject])),
    PRIMARY KEY NONCLUSTERED ([questlineGlobalObject] ASC),
    CONSTRAINT [scriptableQuestlines_scriptableObjects_globalObject_fk] FOREIGN KEY ([questlineGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    UNIQUE NONCLUSTERED ([questlineGlobalObject] ASC)
);


GO

