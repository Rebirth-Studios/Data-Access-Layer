CREATE TABLE [content].[scriptableEquipment] (
    [globalObject]          VARCHAR (255)  NOT NULL,
    [equipmentMainTypeId]   TINYINT        NOT NULL,
    [defense]               INT            NOT NULL,
    [skillGlobalObject]     VARCHAR (255)  NOT NULL,
    [gearsetGlobalObject]   VARCHAR (255)  NOT NULL,
    [equipmentDescription]  VARCHAR (1000) NOT NULL,
    [globalObjectName]      AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [skillGlobalObjectName] AS             ([dbo].[getGlobalObjectName]([skillGlobalObject])),
    [gearSet]               AS             ([dbo].[getGlobalObjectName]([gearsetGlobalObject])),
    [equipmentMainTypeName] AS             ([dbo].[getEquipmentTypeName]([equipmentMainTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D522AB6D14] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK__scriptabl__gears__497E63A7] FOREIGN KEY ([gearsetGlobalObject]) REFERENCES [content].[scriptableGearSets] ([gearSetGlobalObject]),
    CONSTRAINT [scriptableEquipment___fke] FOREIGN KEY ([equipmentMainTypeId]) REFERENCES [content].[equipmentTypes] ([typeId]),
    CONSTRAINT [scriptableEquipment_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableEquipment_scriptableSkills_globalObjectCode_fk] FOREIGN KEY ([skillGlobalObject]) REFERENCES [content].[scriptableSkills] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D51A180EAB] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

