CREATE TABLE [content].[scriptableStructures] (
    [id]               SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]     VARCHAR (255)  NOT NULL,
    [structureTypeId]  TINYINT        NOT NULL,
    [playerUpgradable] BIT            NOT NULL,
    [autoUpgrades]     BIT            NOT NULL,
    [tierAvailableId]  TINYINT        NOT NULL,
    [description]      VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_scriptableStructures] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructures_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableStructures_structureTypes_structureTypeId_fk] FOREIGN KEY ([structureTypeId]) REFERENCES [content].[structureTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5622C1C8C] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

