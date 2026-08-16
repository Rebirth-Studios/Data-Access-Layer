CREATE TABLE [content].[scriptableMaterialModifiers] (
    [scriptableMaterialModifierId] INT             IDENTITY (1, 1) NOT NULL,
    [globalObject]                 VARCHAR (255)   NOT NULL,
    [globalObjectName]             AS              ([dbo].[getGlobalObjectName]([globalObject])),
    [modifierTypeId]               TINYINT         NOT NULL,
    [modifierMultiplier]           DECIMAL (18, 2) NOT NULL,
    [craftingMaterialTypeId]       SMALLINT        NOT NULL,
    [craftingMaterialTypeName]     AS              ([dbo].[getCraftingMaterialTypeName]([craftingMaterialTypeId])),
    [modifierTypeName]             AS              ([dbo].[getModifierTypeName]([modifierTypeId])),
    CONSTRAINT [PK_scriptableMaterialModifiers] PRIMARY KEY CLUSTERED ([scriptableMaterialModifierId] ASC),
    CONSTRAINT [FK__scriptabl__craft__207C4E14] FOREIGN KEY ([craftingMaterialTypeId]) REFERENCES [content].[craftingMaterialTypes] ([typeId]),
    CONSTRAINT [scriptableMaterialModifiers_modifierTypes_materialModifierTypeId_fk] FOREIGN KEY ([modifierTypeId]) REFERENCES [content].[modifierTypes] ([typeId]),
    CONSTRAINT [scriptableMaterialModifiers_scriptableMaterials_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableMaterials] ([globalObject])
);


GO

