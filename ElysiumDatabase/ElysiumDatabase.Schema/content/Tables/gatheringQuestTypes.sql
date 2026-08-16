CREATE TABLE [content].[gatheringQuestTypes] (
    [typeId]      TINYINT        NOT NULL,
    [type]        VARCHAR (255)  NOT NULL,
    [typeName]    VARCHAR (255)  NOT NULL,
    [description] VARCHAR (1000) NOT NULL,
    CONSTRAINT [gatheringQuestTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [gatheringQuestTypes_gatheringQuestTypeId_uindex]
    ON [content].[gatheringQuestTypes]([typeId] ASC);


GO

