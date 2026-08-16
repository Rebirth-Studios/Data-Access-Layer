CREATE TABLE [content].[craftingMaterialTypes] (
    [typeId]                 SMALLINT      NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [namePlural]             VARCHAR (50)  NOT NULL,
    [materialCategory]       VARCHAR (50)  NOT NULL,
    [alloyOnly]              BIT           NOT NULL,
    CONSTRAINT [craftingMaterialTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__crafting__E3F85248D20AACAE] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

