CREATE TABLE [content].[unlockEffects] (
    [globalObject]       VARCHAR (255) NOT NULL,
    [unlockGlobalObject] VARCHAR (255) NOT NULL,
    [unlockEffectTypeId] TINYINT       NOT NULL,
    [unlockRankId]       TINYINT       NOT NULL,
    [unlockLevelId]      TINYINT       NOT NULL,
    [experienceGain]     INT           NOT NULL,
    CONSTRAINT [unlockEffects_pk] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [unlockEffects_effects  _globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [unlockEffects_globalRanks_globalRankId_fk] FOREIGN KEY ([unlockRankId]) REFERENCES [content].[globalRanks] ([globalRankId]),
    CONSTRAINT [unlockEffects_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([unlockGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject])
);


GO

