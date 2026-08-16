CREATE TABLE [content].[generalItemTypes] (
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
    CONSTRAINT [generalItemTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [generalItemTypes_generalItemTypeId_uindex]
    ON [content].[generalItemTypes]([typeId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [generalItemTypes_generalItemType_uindex]
    ON [content].[generalItemTypes]([type] ASC);


GO

