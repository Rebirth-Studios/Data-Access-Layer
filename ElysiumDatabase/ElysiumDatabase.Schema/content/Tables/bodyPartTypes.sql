CREATE TABLE [content].[bodyPartTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (255) NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [parentEnum]             VARCHAR (50)  NULL,
    CONSTRAINT [PK_bodyPartTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

