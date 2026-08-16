CREATE TABLE [content].[globalObjectSubTypes] (
    [typeId]                  TINYINT        NOT NULL,
    [type]                    VARCHAR (255)  NOT NULL,
    [typeName]                VARCHAR (255)  NOT NULL,
    [description]             VARCHAR (1000) NOT NULL,
    [parentEnum]              VARCHAR (50)   NULL,
    [parentTypeId]            TINYINT        NULL,
    [childEnum]               VARCHAR (50)   NULL,
    [globalObjectNamingType]  SMALLINT       NULL,
    [objectSubTypeNamePlural] VARCHAR (255)  NOT NULL,
    [objectTypeNamePlural]    VARCHAR (100)  NULL,
    [associatedTable]         VARCHAR (100)  NULL,
    CONSTRAINT [PK_globalObjectSubTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

