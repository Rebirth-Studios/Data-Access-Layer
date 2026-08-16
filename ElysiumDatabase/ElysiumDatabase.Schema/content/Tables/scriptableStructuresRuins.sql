CREATE TABLE [content].[scriptableStructuresRuins] (
    [id]                  SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]        VARCHAR (255) NOT NULL,
    [despawnTime]         SMALLINT      NOT NULL,
    [ruinStructureTypeId] TINYINT       NOT NULL,
    [globalObjectName]    AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [ruinStructureType]   AS            ([dbo].[getRuinStructureTypeName]([ruinStructureTypeId])),
    CONSTRAINT [PK_scriptableStructuresRuins] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresRuins_scriptableStructures] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [scriptableStructuresRuins_ruinStructureTypes_ruinStructureTypeId_fk] FOREIGN KEY ([ruinStructureTypeId]) REFERENCES [content].[ruinStructureTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5A6F51E61] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

