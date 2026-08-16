CREATE TABLE [content].[scriptableObjectTypes] (
    [typeId]                   TINYINT       NOT NULL,
    [type]                     VARCHAR (255) NOT NULL,
    [typeName]                 VARCHAR (255) NOT NULL,
    [description]              VARCHAR (255) NULL,
    [parentEnum]               VARCHAR (50)  NULL,
    [parentTypeId]             TINYINT       NULL,
    [childEnum]                VARCHAR (50)  NULL,
    [globalObjectNamingType]   SMALLINT      NULL,
    [basePath]                 VARCHAR (255) NOT NULL,
    [baseScriptableObjectPath] VARCHAR (255) NOT NULL,
    [associatedTable]          VARCHAR (255) NULL,
    [pluralNameOverride]       VARCHAR (255) NULL,
    CONSTRAINT [PK_scriptableObjectTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

