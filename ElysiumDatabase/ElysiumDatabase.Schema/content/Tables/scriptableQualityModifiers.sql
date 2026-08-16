CREATE TABLE [content].[scriptableQualityModifiers] (
    [qualityId]                   TINYINT        NOT NULL,
    [modifierTypeId]              TINYINT        NOT NULL,
    [modifierMultiplier]          DECIMAL (5, 2) NOT NULL,
    [scriptableQualityModifierId] INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_scriptableQualityModifiers] PRIMARY KEY CLUSTERED ([scriptableQualityModifierId] ASC),
    CONSTRAINT [scriptableQualityModifiers_modifierTypes_materialModifierTypeId_fk] FOREIGN KEY ([modifierTypeId]) REFERENCES [content].[modifierTypes] ([typeId]),
    CONSTRAINT [scriptableQualityModifiers_scriptableQualities_scriptableQualityId_fk] FOREIGN KEY ([qualityId]) REFERENCES [content].[scriptableQualities] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableQualityModifiers_qualityId_modifierTypeId_uindex]
    ON [content].[scriptableQualityModifiers]([qualityId] ASC, [modifierTypeId] ASC);


GO

