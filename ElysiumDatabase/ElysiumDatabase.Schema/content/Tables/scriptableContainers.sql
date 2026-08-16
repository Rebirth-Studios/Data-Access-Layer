CREATE TABLE [content].[scriptableContainers] (
    [globalObject]                  VARCHAR (255) NOT NULL,
    [containerMainTypeId]           TINYINT       NOT NULL,
    [containerClassificationTypeId] TINYINT       NULL,
    [containerSubTypeId]            TINYINT       NULL,
    [width]                         TINYINT       NOT NULL,
    [height]                        TINYINT       NOT NULL,
    [requiredWeaponTypeId]          TINYINT       NOT NULL,
    [requiredToolLevelId]           TINYINT       NOT NULL,
    [globalObjectName]              AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [requiredWeaponType]            AS            ([dbo].[getWeaponTypeName]([requiredWeaponTypeId])),
    [mainTypeName]                  AS            ([dbo].[getContainerMainTypeName]([containerMainTypeId])),
    [classificationTypeName]        AS            ([dbo].[getContainerClassificationTypeName]([containerClassificationTypeId])),
    [subTypeName]                   AS            ([dbo].[getContainerSubTypeName]([containerSubTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D447E18A56] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableContainers_containerTypes] FOREIGN KEY ([containerMainTypeId]) REFERENCES [content].[containerTypes] ([typeId]),
    CONSTRAINT [scriptableContainers_scriptableInteractables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableInteractables] ([globalObject]),
    CONSTRAINT [scriptableContainers_weaponsTypes_weaponTypeId_fk] FOREIGN KEY ([requiredWeaponTypeId]) REFERENCES [content].[weaponTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D50DAAC086] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

