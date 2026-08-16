CREATE TABLE [content].[genderTypes] (
    [typeId]                 TINYINT       IDENTITY (0, 1) NOT NULL,
    [type]                   VARCHAR (50)  NOT NULL,
    [typeName]               VARCHAR (250) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_genderTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

