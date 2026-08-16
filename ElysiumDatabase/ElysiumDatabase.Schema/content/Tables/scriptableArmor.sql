CREATE TABLE [content].[scriptableArmor] (
    [armorClassificationTypeId] TINYINT       NOT NULL,
    [armorSlotTypeId]           TINYINT       NOT NULL,
    [armorPrefabPath]           VARCHAR (255) NOT NULL,
    [globalObject]              VARCHAR (255) NOT NULL,
    [globalObjectName]          AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [armorSlotTypeName]         AS            ([dbo].[getArmorSlotTypeName]([armorSlotTypeId])),
    [classificationTypeName]    AS            ([dbo].[getArmorClassificationTypeName]([armorClassificationTypeId])),
    PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableArmor_armorSlotTypes_armorSlotTypeId_fk] FOREIGN KEY ([armorSlotTypeId]) REFERENCES [content].[armorSlotTypes] ([typeId]),
    CONSTRAINT [scriptableArmor_armorTypes_armorTypeId_fk] FOREIGN KEY ([armorClassificationTypeId]) REFERENCES [content].[armorTypes] ([typeId]),
    CONSTRAINT [scriptableArmor_scriptableEquipment_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEquipment] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

