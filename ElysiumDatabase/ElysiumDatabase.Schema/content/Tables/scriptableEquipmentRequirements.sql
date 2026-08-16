CREATE TABLE [content].[scriptableEquipmentRequirements] (
    [equipmentRequirementId]          INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]                    VARCHAR (255)  NOT NULL,
    [statTypeId]                      TINYINT        NOT NULL,
    [statId]                          TINYINT        NOT NULL,
    [requiredAmount]                  SMALLINT       NOT NULL,
    [equipmentRequirementDescription] VARCHAR (1000) NOT NULL,
    [equipmentRequirement]            AS             ([dbo].[getEquipmentRequirement]([globalObject])) PERSISTED,
    CONSTRAINT [equipmentRequirements_primaryKey] PRIMARY KEY CLUSTERED ([equipmentRequirementId] ASC),
    CONSTRAINT [scriptableEquipmentRequirements_scriptableEquipment_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEquipment] ([globalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableEquipmentRequirements_globalObject_requiredStatTypeId_requiredStatId_uindex]
    ON [content].[scriptableEquipmentRequirements]([globalObject] ASC, [statTypeId] ASC, [statId] ASC);


GO

