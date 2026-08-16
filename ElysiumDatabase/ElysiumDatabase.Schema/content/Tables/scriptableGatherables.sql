CREATE TABLE [content].[scriptableGatherables] (
    [globalObject]                         VARCHAR (255) NOT NULL,
    [gatherTypeId]                         TINYINT       NOT NULL,
    [gatherableTypeId]                     TINYINT       NOT NULL,
    [gatherableClassificationTypeId]       TINYINT       NOT NULL,
    [gatherableSubTypeId]                  TINYINT       NOT NULL,
    [requiredWeaponTypeId]                 TINYINT       NOT NULL,
    [requiredPower]                        TINYINT       NOT NULL,
    [maxToolPower]                         TINYINT       NOT NULL,
    [craftingMaterialTypeId]               TINYINT       NOT NULL,
    [associatedMaterialGlobalObject]       VARCHAR (255) NOT NULL,
    [associatedMaterialImbuedGlobalObject] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D553E5E4CA] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableGatherables_scriptableMaterials] FOREIGN KEY ([associatedMaterialGlobalObject]) REFERENCES [content].[scriptableMaterials] ([globalObject]),
    CONSTRAINT [FK_scriptableGatherables_scriptableMaterials1] FOREIGN KEY ([associatedMaterialImbuedGlobalObject]) REFERENCES [content].[scriptableMaterials] ([globalObject]),
    CONSTRAINT [scriptableGatherables_gatherableTypes_gatherableTypeId_fk] FOREIGN KEY ([gatherableTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [scriptableGatherables_gatherTypes_gatherTypeId_fk] FOREIGN KEY ([gatherTypeId]) REFERENCES [content].[gatherTypes] ([typeId]),
    CONSTRAINT [scriptableGatherables_scriptableInteractables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableInteractables] ([globalObject]),
    CONSTRAINT [scriptableGatherables_weaponsTypes_weaponTypeId_fk] FOREIGN KEY ([requiredWeaponTypeId]) REFERENCES [content].[weaponTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D59652EA44] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

