CREATE TABLE [content].[armorTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NULL,
    [description]            VARCHAR (1000) NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    [armorSkill]             VARCHAR (100)  NULL,
    CONSTRAINT [armorTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

