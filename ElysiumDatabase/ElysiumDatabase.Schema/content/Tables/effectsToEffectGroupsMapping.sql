CREATE TABLE [content].[effectsToEffectGroupsMapping] (
    [effectsToEffectGroupsMappingId] INT           IDENTITY (1, 1) NOT NULL,
    [effectGlobalObject]             VARCHAR (255) NOT NULL,
    [effectGroupGlobalObject]        VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]          VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_effectsToEffectGroupsMapping] PRIMARY KEY CLUSTERED ([effectsToEffectGroupsMappingId] ASC),
    CONSTRAINT [FK_effectsToEffectGroupsMapping_effects] FOREIGN KEY ([effectGlobalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [FK_effectsToEffectGroupsMapping_globalObjects] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_effectsToEffectGroupsMapping_scriptableObjectLevels] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [Unique_effectsToEffectGroupsMapping] UNIQUE NONCLUSTERED ([effectGlobalObject] ASC, [effectGroupGlobalObject] ASC, [scriptableObjectLevel] ASC)
);


GO

