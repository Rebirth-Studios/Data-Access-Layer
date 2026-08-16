CREATE TABLE [content].[modifierTypesLevels] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (100) NOT NULL,
    [typeName]               VARCHAR (100) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (100) NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [PK_modifierTypesLevels] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__modifier__E3F852483E25159A] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

