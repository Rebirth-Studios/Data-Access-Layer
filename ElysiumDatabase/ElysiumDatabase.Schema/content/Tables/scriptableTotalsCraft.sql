CREATE TABLE [content].[scriptableTotalsCraft] (
    [craftTypeId]               TINYINT       NOT NULL,
    [craftMainTypeId]           TINYINT       NOT NULL,
    [craftRarityId]             TINYINT       NOT NULL,
    [craftClassificationTypeId] TINYINT       NOT NULL,
    [craftSubTypeId]            TINYINT       NOT NULL,
    [totalGlobalObject]         VARCHAR (255) NOT NULL,
    [craftRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [dataAttributeTypeId]       TINYINT       NOT NULL,
    [craftTierId]               TINYINT       NOT NULL,
    [isImbued]                  BIT           NOT NULL,
    CONSTRAINT [PK__scriptab__2692B5EDC3801263] PRIMARY KEY CLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [scriptableTotalsCraft_itemTypes_itemTypeId_fk] FOREIGN KEY ([craftTypeId]) REFERENCES [content].[itemTypes] ([typeId]),
    CONSTRAINT [scriptableTotalsCraft_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([craftRequiredGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableTotalsCraft_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([craftRarityId]) REFERENCES [content].[scriptableRarities] ([typeId]),
    CONSTRAINT [scriptableTotalsCraft_scriptableTotals_totalGlobalObjectCode_fk] FOREIGN KEY ([totalGlobalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    CONSTRAINT [UQ__scriptab__2692B5ECE983FEFA] UNIQUE NONCLUSTERED ([totalGlobalObject] ASC)
);


GO

