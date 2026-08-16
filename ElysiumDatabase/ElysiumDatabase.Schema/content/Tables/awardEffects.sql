CREATE TABLE [content].[awardEffects] (
    [globalObject]      VARCHAR (255) NOT NULL,
    [awardGlobalObject] VARCHAR (255) NOT NULL,
    [awardEffectTypeId] TINYINT       NOT NULL,
    CONSTRAINT [awardEffects_pk] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [awardEffects_awardEffectTypes_awardEffectTypeId_fk] FOREIGN KEY ([awardEffectTypeId]) REFERENCES [content].[awardEffectTypes] ([typeId]),
    CONSTRAINT [awardEffects_effects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [awardEffects_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([awardGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject])
);


GO

