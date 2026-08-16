CREATE TABLE [content].[bagClassificationTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
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
    [description]            VARCHAR (1000) NOT NULL
);


GO

