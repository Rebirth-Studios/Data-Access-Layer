CREATE TABLE [content].[scriptableJewelry] (
    [jewelrySlotTypeId]           TINYINT       NOT NULL,
    [jewelryClassificationTypeId] TINYINT       NULL,
    [globalObject]                VARCHAR (255) NOT NULL,
    [globalObjectName]            AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [jewelrySlotTypeName]         AS            ([dbo].[getJewelrySlotTypeName]([jewelrySlotTypeId])),
    [classificationTypeName]      AS            ([dbo].[getJewelryClassificationTypeName]([jewelryClassificationTypeId])),
    PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableJewelery_scriptableEquipment_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEquipment] ([globalObject]),
    CONSTRAINT [scriptableJewelry_jewelrySlotTypes_jewelrySlotTypeId_fk] FOREIGN KEY ([jewelrySlotTypeId]) REFERENCES [content].[jewelrySlotTypes] ([typeId]),
    CONSTRAINT [scriptableJewelry_jewelryTypes_jewelryTypeId_fk] FOREIGN KEY ([jewelryClassificationTypeId]) REFERENCES [content].[jewelryTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

