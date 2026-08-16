CREATE TABLE [content].[generalItemSubTypes] (
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
    [useQualityName]         BIT            NOT NULL
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [generalItemSubTypes_generalItemSubType_uindex]
    ON [content].[generalItemSubTypes]([type] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [generalItemSubTypes_generalItemSubTypeId_uindex]
    ON [content].[generalItemSubTypes]([typeId] ASC);


GO

