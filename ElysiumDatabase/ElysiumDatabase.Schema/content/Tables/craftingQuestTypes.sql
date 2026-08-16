CREATE TABLE [content].[craftingQuestTypes] (
    [typeId]      TINYINT        NOT NULL,
    [type]        VARCHAR (255)  NOT NULL,
    [typeName]    VARCHAR (255)  NOT NULL,
    [description] VARCHAR (1000) NOT NULL,
    CONSTRAINT [craftingQuestTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [craftingQuestTypes_craftingQuestTypeId_uindex]
    ON [content].[craftingQuestTypes]([typeId] ASC);


GO

