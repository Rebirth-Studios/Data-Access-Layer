CREATE TABLE [content].[materialSubTypes] (
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
    CONSTRAINT [materialSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [materialSubTypes_materialTypes_materialTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[materialTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [materialSubTypes_materialSubType_uindex]
    ON [content].[materialSubTypes]([type] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [materialSubTypes_materialSubTypeId_uindex]
    ON [content].[materialSubTypes]([typeId] ASC);


GO

