CREATE TABLE [content].[adventurerTiers] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    CONSTRAINT [adventurerTiers_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__adventur__E3F85248EE8EEDAB] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

