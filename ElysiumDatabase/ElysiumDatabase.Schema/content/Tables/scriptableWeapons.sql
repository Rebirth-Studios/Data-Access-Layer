CREATE TABLE [content].[scriptableWeapons] (
    [weaponClassificationTypeId] TINYINT         NOT NULL,
    [weaponSlotId]               TINYINT         NOT NULL,
    [damageTypeId]               TINYINT         NOT NULL,
    [minDamage]                  DECIMAL (18, 2) NOT NULL,
    [maxDamage]                  DECIMAL (18, 2) NOT NULL,
    [length]                     DECIMAL (18, 2) NOT NULL,
    [toolPower]                  SMALLINT        NOT NULL,
    [globalObject]               VARCHAR (255)   NOT NULL,
    [attackSpeedOverride]        DECIMAL (5, 2)  NOT NULL,
    [attackSpeed]                AS              ([dbo].[getWeaponSpeed]([globalObject],[weaponClassificationTypeId])),
    [globalObjectName]           AS              ([dbo].[getGlobalObjectName]([globalObject])),
    [damageType]                 AS              ([dbo].[getElementalTypeName]([damageTypeId])),
    [weaponSlotTypeName]         AS              ([dbo].[getWeaponSlotTypeName]([weaponSlotId])),
    [classificationTypeName]     AS              ([dbo].[getWeaponClassificationTypeName]([weaponClassificationTypeId])),
    [weaponBase]                 AS              ([dbo].[getWeaponBase]([weaponClassificationTypeId],[globalObject])),
    CONSTRAINT [PK__scriptab__5AB532D52F540F98] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableWeapons_damageTypes_damageTypeId_fk] FOREIGN KEY ([damageTypeId]) REFERENCES [content].[elementalTypes] ([typeId]),
    CONSTRAINT [scriptableWeapons_scriptableEquipment_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEquipment] ([globalObject]),
    CONSTRAINT [scriptableWeapons_weaponsSlots_weaponSlotId_fk] FOREIGN KEY ([weaponSlotId]) REFERENCES [content].[weaponSlotTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5E306C0DC] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

