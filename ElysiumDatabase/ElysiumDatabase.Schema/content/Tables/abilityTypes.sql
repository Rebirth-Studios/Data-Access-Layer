CREATE TABLE [content].[abilityTypes] (
    [typeId]                 TINYINT        IDENTITY (0, 1) NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NULL,
    [description]            VARCHAR (1000) NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [PK_abilityTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

