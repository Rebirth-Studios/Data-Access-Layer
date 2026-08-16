CREATE TABLE [content].[scriptableGatherablesSpawnable] (
    [id]                        SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]              VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]     VARCHAR (255) NOT NULL,
    [scriptableObjectSpawnable] VARCHAR (255) NOT NULL,
    [gatherableTypeId]          TINYINT       NOT NULL,
    [variationId]               TINYINT       NOT NULL,
    [requiredPower]             TINYINT       NOT NULL,
    [maxToolPower]              TINYINT       NOT NULL,
    [displayName]               VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_scriptableGatherablesSpawnable] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__scriptabl__gathe__0261DB48] FOREIGN KEY ([gatherableTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__globa__7F856E9D] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK__scriptabl__scrip__007992D6] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK__scriptabl__scrip__016DB70F] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [FK__scriptableGather__0355FF81] FOREIGN KEY ([gatherableTypeId], [variationId]) REFERENCES [content].[scriptableGatherablesVariations] ([gatherableTypeId], [variationId]),
    CONSTRAINT [UQ_ScriptableGatherablesSpawnable_ScriptableObjectSpawnable] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC)
);


GO

