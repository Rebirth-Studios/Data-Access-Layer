CREATE TABLE [content].[scriptableStructuresDungeons] (
    [id]                     SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]           VARCHAR (255) NOT NULL,
    [dungeonStructureTypeId] TINYINT       NOT NULL,
    [globalObjectName]       AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [dungeonStructureType]   AS            ([dbo].[getDungeonStructureTypeName]([dungeonStructureTypeId])),
    CONSTRAINT [PK_scriptableStructuresDungeons] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresDungeons_scriptableStructures] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [scriptableStructuresDungeons_dungeonStructureTypes_dungeonStructureTypeId_fk] FOREIGN KEY ([dungeonStructureTypeId]) REFERENCES [content].[dungeonStructureTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5F4822809] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

