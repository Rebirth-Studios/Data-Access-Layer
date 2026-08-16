CREATE TABLE [content].[statNames] (
    [typeId]                 TINYINT       IDENTITY (0, 1) NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (255) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [statNames_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [constraint_statNames_typeName] UNIQUE NONCLUSTERED ([typeName] ASC),
    CONSTRAINT [UQ__statName__E3F852488D69FE42] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

