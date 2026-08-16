CREATE TABLE [content].[scriptableStructuresVillageDefenses] (
    [id]                   SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]         VARCHAR (255) NOT NULL,
    [villageDefenseTypeId] TINYINT       NOT NULL,
    [globalObjectName]     AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [villageDefenseType]   AS            ([dbo].[getVillageDefenseStructureTypeName]([villageDefenseTypeId])),
    CONSTRAINT [PK_scriptableStructuresVillageDefenses] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [scriptableStructuresVillageDefenses_villageDefenseTypes_villageDefenseTypeId_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5A85BE967] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

