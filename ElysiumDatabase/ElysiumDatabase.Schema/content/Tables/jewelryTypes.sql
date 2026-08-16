CREATE TABLE [content].[jewelryTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NOT NULL,
    [description]            VARCHAR (255) NULL,
    [parentEnum]             VARCHAR (50)  NULL,
    [parentTypeId]           TINYINT       NULL,
    [childEnum]              VARCHAR (50)  NULL,
    [globalObjectNamingType] SMALLINT      NULL,
    PRIMARY KEY CLUSTERED ([typeId] ASC),
    UNIQUE NONCLUSTERED ([type] ASC),
    UNIQUE NONCLUSTERED ([typeId] ASC)
);


GO

