CREATE TABLE [content].[skillCategoryTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (50)  NULL,
    [parentTypeId]           TINYINT       NULL,
    [childEnum]              VARCHAR (50)  NULL,
    [globalObjectNamingType] SMALLINT      NULL,
    [experienceBasePlayer]   INT           NULL,
    [experienceBaseSkill]    INT           NULL
);


GO

