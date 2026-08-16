CREATE TABLE [content].[scriptableEntitiesSpawnable] (
    [id]                        SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]              VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]     VARCHAR (255) NOT NULL,
    [scriptableObjectSpawnable] VARCHAR (255) NOT NULL,
    [variationId]               TINYINT       NOT NULL,
    [entityIsStunnable]         BIT           NOT NULL,
    [entityCombatTypeId]        TINYINT       NOT NULL,
    [entityTypeId]              TINYINT       NOT NULL,
    [displayName]               VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_scriptableEntitiesSpawnable] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__scriptabl__entit__78D8710E] FOREIGN KEY ([entityTypeId]) REFERENCES [content].[entityTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__globa__75FC0463] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK__scriptabl__scrip__649C6E37] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK__scriptabl__scrip__73DEB1C7] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [FK__scriptableEntiti__79CC9547] FOREIGN KEY ([entityTypeId], [variationId]) REFERENCES [content].[scriptableEntitiesVariations] ([entityTypeId], [variationId]),
    CONSTRAINT [UQ_ScriptableEntitiesSpawnable_ScriptableObjectSpawnable] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC)
);


GO

