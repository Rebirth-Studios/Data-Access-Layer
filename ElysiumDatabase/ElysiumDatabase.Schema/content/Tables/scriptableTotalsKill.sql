CREATE TABLE [content].[scriptableTotalsKill] (
    [scriptableTotalsKillId]   INT           IDENTITY (1, 1) NOT NULL,
    [killTypeId]               TINYINT       NOT NULL,
    [killMainTypeId]           TINYINT       NOT NULL,
    [killClassificationTypeId] TINYINT       NOT NULL,
    [killSubTypeId]            TINYINT       NOT NULL,
    [totalGlobalObject]        VARCHAR (255) NOT NULL,
    [killRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [dataAttributeTypeId]      TINYINT       NOT NULL,
    [imbuedTypeId]             TINYINT       NOT NULL,
    [difficultyTypeId]         TINYINT       NOT NULL,
    [killTierId]               TINYINT       NOT NULL,
    CONSTRAINT [PK__scriptab__2692B5ECA3577CAF] PRIMARY KEY NONCLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [scriptableTotalsKill_entityTypes_entityTypeId_fk] FOREIGN KEY ([killTypeId]) REFERENCES [content].[entityTypes] ([typeId]),
    CONSTRAINT [scriptableTotalsKill_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([killRequiredGlobalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [scriptableTotalsKill_scriptableTotals_totalGlobalObjectCode_fk] FOREIGN KEY ([totalGlobalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    CONSTRAINT [UQ__scriptab__2692B5ECE4983A63] UNIQUE NONCLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [UQ__scriptab__87338426075064AC] UNIQUE NONCLUSTERED ([scriptableTotalsKillId] ASC)
);


GO

