CREATE TABLE [content].[consumableSubTypes] (
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
    CONSTRAINT [consumableSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [consumableSubTypes_consumableTypes_consumableTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[consumableClassificationTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [consumableSubTypes_consumableSubTypeId_uindex]
    ON [content].[consumableSubTypes]([typeId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [consumableSubTypes_consumableSubType_uindex]
    ON [content].[consumableSubTypes]([type] ASC);


GO

