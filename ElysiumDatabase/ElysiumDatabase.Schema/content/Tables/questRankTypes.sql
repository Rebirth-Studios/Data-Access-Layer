CREATE TABLE [content].[questRankTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (20)  NOT NULL,
    [typeName]               VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL
);


GO

