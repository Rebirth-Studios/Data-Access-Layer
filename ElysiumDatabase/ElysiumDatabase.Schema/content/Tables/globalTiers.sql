CREATE TABLE [content].[globalTiers] (
    [typeId]                 TINYINT         NOT NULL,
    [type]                   VARCHAR (255)   NOT NULL,
    [typeName]               VARCHAR (255)   NOT NULL,
    [description]            VARCHAR (255)   NOT NULL,
    [parentEnum]             VARCHAR (50)    NOT NULL,
    [parentTypeId]           TINYINT         NOT NULL,
    [childEnum]              VARCHAR (50)    NOT NULL,
    [globalObjectNamingType] SMALLINT        NOT NULL,
    [experienceInitialValue] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [globalTiers_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [Uni_globalName] UNIQUE NONCLUSTERED ([typeName] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalTiers_globalTierId_uindex]
    ON [content].[globalTiers]([typeId] ASC);


GO

