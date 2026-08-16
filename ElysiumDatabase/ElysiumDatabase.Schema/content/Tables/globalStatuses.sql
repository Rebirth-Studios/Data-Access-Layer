CREATE TABLE [content].[globalStatuses] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [globalStatuses_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalStatuses_statusId_uindex]
    ON [content].[globalStatuses]([typeId] ASC);


GO

