CREATE TABLE [content].[lootTableTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [PK_lootTableTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

