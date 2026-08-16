CREATE TABLE [content].[scriptableStructuresVillage] (
    [id]                      SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]            VARCHAR (255) NOT NULL,
    [villageStructureTypeId]  TINYINT       NOT NULL,
    [globalObjectName]        AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [villageStructureType]    AS            ([dbo].[getVillageStructureTypeName]([villageStructureTypeId])),
    [scriptableStructureName] AS            ([dbo].[getGlobalObjectName]([globalObject])),
    CONSTRAINT [PK_scriptableStructuresVillage] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [scriptableStructuresVillage_villageStructureTypes_villageStructureTypeId_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5F1317C3C] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

