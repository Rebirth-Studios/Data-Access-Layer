CREATE TABLE [content].[scriptableStructuresUpgradeDetails] (
    [id]                           SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]                 VARCHAR (255) NOT NULL,
    [minVillageTierId]             TINYINT       NOT NULL,
    [upgradeStructureGlobalObject] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_scriptableStructuresUpgradeDetails] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresUpgradeDetails_scriptableStructures] FOREIGN KEY ([upgradeStructureGlobalObject]) REFERENCES [content].[scriptableStructures] ([globalObject]),
    CONSTRAINT [scriptableStructuresUpgradeDetails_globalTier_globalTierId_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject])
);


GO

