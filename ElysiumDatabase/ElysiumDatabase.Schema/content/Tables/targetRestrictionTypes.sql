CREATE TABLE [content].[targetRestrictionTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL,
    CONSTRAINT [targetRestrictionTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

