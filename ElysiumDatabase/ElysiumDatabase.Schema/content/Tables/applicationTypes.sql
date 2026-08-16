CREATE TABLE [content].[applicationTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NULL,
    [description]            VARCHAR (255) NULL,
    [parentEnum]             VARCHAR (50)  NULL,
    [parentTypeId]           TINYINT       NULL,
    [childEnum]              VARCHAR (50)  NULL,
    [globalObjectNamingType] SMALLINT      NULL,
    CONSTRAINT [applicationTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

