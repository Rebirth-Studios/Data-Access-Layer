CREATE TABLE [content].[weaponsBase] (
    [weaponBase]         VARCHAR (255)   NOT NULL,
    [maxDurability]      DECIMAL (18, 2) NOT NULL,
    [minDamage]          DECIMAL (18, 2) NOT NULL,
    [maxDamage]          DECIMAL (18, 2) NOT NULL,
    [attackSpeed]        DECIMAL (18, 2) NOT NULL,
    [length]             DECIMAL (18, 2) NOT NULL,
    [manaCapacity]       DECIMAL (18, 2) NOT NULL,
    [weaponTypeId]       INT             NOT NULL,
    [weaponSlotId]       INT             NOT NULL,
    [damageTypeId]       INT             NOT NULL,
    [weaponBaseName]     VARCHAR (255)   NULL,
    [weaponSkill]        VARCHAR (100)   NULL,
    [weaponTypeName]     AS              ([dbo].[getWeaponTypeName]([weaponTypeId])),
    [weaponSlotTypeName] AS              ([dbo].[getWeaponSlotTypeName]([weaponSlotId])),
    [weaponSlot]         AS              ([dbo].[getWeaponSlotType]([weaponSlotId])),
    CONSTRAINT [weaponsBase_pk] PRIMARY KEY CLUSTERED ([weaponBase] ASC)
);


GO

