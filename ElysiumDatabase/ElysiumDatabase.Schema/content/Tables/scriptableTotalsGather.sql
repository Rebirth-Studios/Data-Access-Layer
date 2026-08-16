CREATE TABLE [content].[scriptableTotalsGather] (
    [gatherMainTypeId]           TINYINT       NOT NULL,
    [gatherClassificationTypeId] TINYINT       NOT NULL,
    [gatherSubTypeId]            TINYINT       NOT NULL,
    [totalGlobalObject]          VARCHAR (255) NOT NULL,
    [gatherRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [imbuedTypeId]               TINYINT       NOT NULL,
    [dataAttributeTypeId]        TINYINT       NOT NULL,
    [gatherTypeId]               TINYINT       NOT NULL,
    [locationTypeId]             TINYINT       NOT NULL,
    [quantityTypeId]             TINYINT       NOT NULL,
    [gatherTierId]               TINYINT       NOT NULL,
    CONSTRAINT [PK__scriptab__2692B5ED4389D8CC] PRIMARY KEY CLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [scriptableTotalsGather_gatherableTypes_gatherableTypeId_fk] FOREIGN KEY ([gatherMainTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [scriptableTotalsGather_scriptableInteractables_globalObjectCode_fk] FOREIGN KEY ([gatherRequiredGlobalObject]) REFERENCES [content].[scriptableInteractables] ([globalObject]),
    CONSTRAINT [scriptableTotalsGather_scriptableTotals_totalGlobalObjectCode_fk] FOREIGN KEY ([totalGlobalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    CONSTRAINT [UQ__scriptab__2692B5ECB3E048CC] UNIQUE NONCLUSTERED ([totalGlobalObject] ASC)
);


GO

