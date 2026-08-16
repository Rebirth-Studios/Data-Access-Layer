CREATE TABLE [content].[scriptableAnimals] (
    [animalMainTypeId]           TINYINT       NOT NULL,
    [animalSubTypeId]            TINYINT       NOT NULL,
    [globalObject]               VARCHAR (255) NOT NULL,
    [animalClassificationTypeId] TINYINT       NOT NULL,
    [description]                VARCHAR (255) NOT NULL,
    [globalObjectName]           AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [mainTypeName]               AS            ([dbo].[getAnimalMainTypeName]([animalMainTypeId])),
    [classificationTypeName]     AS            ([dbo].[getAnimalClassificationTypeName]([animalClassificationTypeId])),
    [subTypeName]                AS            ([dbo].[getAnimalSubTypeName]([animalSubTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D412785774] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableAnimals_animalSubTypes_animalSubTypeId_fk] FOREIGN KEY ([animalSubTypeId]) REFERENCES [content].[animalSubTypes] ([typeId]),
    CONSTRAINT [scriptableAnimals_animalTypes_animalTypeId_fk] FOREIGN KEY ([animalMainTypeId]) REFERENCES [content].[animalTypes] ([typeId]),
    CONSTRAINT [scriptableAnimals_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D57AC593C9] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

