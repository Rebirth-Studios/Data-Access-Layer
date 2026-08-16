CREATE TABLE [content].[abilityActivationTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (100) NOT NULL,
    [typeName]               VARCHAR (100) NULL,
    [description]            VARCHAR (255) NULL,
    [parentEnum]             VARCHAR (100) NULL,
    [parentTypeId]           TINYINT       NULL,
    [childEnum]              VARCHAR (100) NULL,
    [globalObjectNamingType] SMALLINT      NULL,
    CONSTRAINT [abilityActivationTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

