CREATE TABLE [content].[ammunitionTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    [namePlural]             VARCHAR (50)   NOT NULL,
    [minRarityId]            TINYINT        NOT NULL,
    [maxRarityId]            TINYINT        NOT NULL,
    [minImbuedRarityId]      TINYINT        NOT NULL,
    [maxImbuedRarityId]      TINYINT        NOT NULL,
    [useQualityName]         BIT            NOT NULL,
    CONSTRAINT [ammunitionTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__ammuniti__CFAB28D1BC35977E] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

