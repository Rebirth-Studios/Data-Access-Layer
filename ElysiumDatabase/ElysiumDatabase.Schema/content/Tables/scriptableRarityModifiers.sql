CREATE TABLE [content].[scriptableRarityModifiers] (
    [rarityId]                   TINYINT        NOT NULL,
    [modifierTypeId]             TINYINT        NOT NULL,
    [modifierMultiplier]         DECIMAL (5, 2) NOT NULL,
    [scriptableRarityModifierId] INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_scriptableRarityModifiers] PRIMARY KEY CLUSTERED ([scriptableRarityModifierId] ASC),
    CONSTRAINT [scriptableRarityModifiers_modifierTypes_materialModifierTypeId_fk] FOREIGN KEY ([modifierTypeId]) REFERENCES [content].[modifierTypes] ([typeId]),
    CONSTRAINT [scriptableRarityModifiers_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

