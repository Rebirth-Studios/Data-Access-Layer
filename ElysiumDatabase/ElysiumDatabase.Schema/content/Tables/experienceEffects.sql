CREATE TABLE [content].[experienceEffects] (
    [experienceEffectId]           INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]                 VARCHAR (255) NOT NULL,
    [experienceEffectTypeId]       TINYINT       NOT NULL,
    [experienceGain]               INT           NOT NULL,
    [minTierId]                    TINYINT       NOT NULL,
    [maxTierId]                    TINYINT       NOT NULL,
    [experienceEffectGlobalObject] VARCHAR (255) NOT NULL,
    [effectAmountTypeId]           TINYINT       NOT NULL,
    CONSTRAINT [experienceEffects_pk] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [experienceEffects_effects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [experienceEffects_experienceEffectTypes_experienceEffectTypeId_fk] FOREIGN KEY ([experienceEffectTypeId]) REFERENCES [content].[experienceEffectTypes] ([typeId]),
    CONSTRAINT [FK_experienceEffects_globalObjects] FOREIGN KEY ([experienceEffectGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

