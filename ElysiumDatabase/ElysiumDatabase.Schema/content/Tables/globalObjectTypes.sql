CREATE TABLE [content].[globalObjectTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    [objectTypeNamePlural]   VARCHAR (50)   NOT NULL,
    [basePath]               VARCHAR (255)  NOT NULL,
    [associatedTable]        VARCHAR (50)   NULL,
    CONSTRAINT [PK_globalObjectTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

