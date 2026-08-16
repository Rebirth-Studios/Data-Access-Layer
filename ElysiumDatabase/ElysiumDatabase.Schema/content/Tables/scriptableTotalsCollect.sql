CREATE TABLE [content].[scriptableTotalsCollect] (
    [scriptableTotalsCollectId]   INT           IDENTITY (1, 1) NOT NULL,
    [totalGlobalObject]           VARCHAR (255) NOT NULL,
    [collectRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [collectTypeId]               TINYINT       NOT NULL,
    [collectMainTypeId]           TINYINT       NOT NULL,
    [collectClassificationTypeId] TINYINT       NOT NULL,
    [collectSubTypeId]            TINYINT       NOT NULL,
    [collectRarityId]             TINYINT       NOT NULL,
    [collectTierId]               TINYINT       NOT NULL,
    [globalObjectName]            AS            ([dbo].[getGlobalObjectName]([totalGlobalObject])),
    [collectRequiredObjectName]   AS            ([dbo].[getGlobalObjectName]([collectRequiredGlobalObject])),
    [dataAttributeTypeId]         TINYINT       NULL,
    [isImbued]                    AS            ([dbo].[getIsImbuedFromScriptableItems]([collectRequiredGlobalObject])),
    [dataAttributeType]           AS            ([dbo].[getDataAttributeType]([dataAttributeTypeId])),
    [collectMainType]             AS            ([dbo].[getCollectMainTypeName]([collectTypeId],[collectMainTypeId])),
    [collectClassificationType]   AS            ([dbo].[getCollectClassificationTypeName]([collectTypeId],[collectMainTypeId],[collectClassificationTypeId])),
    [collectSubType]              AS            ([dbo].[getCollectSubTypeName]([collectTypeId],[collectSubTypeId])),
    [collectType]                 AS            ([dbo].[getItemTypeName]([collectTypeId])),
    [collectRarity]               AS            ([dbo].[getRarityType]([collectRarityId])),
    [CollectTier]                 AS            ([dbo].[getGlobalTierName]([collectTierId])),
    CONSTRAINT [PK__scriptab__2692B5ECE5FED4D0] PRIMARY KEY NONCLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [scriptableTotalsCollect_scriptableItems_globalObject_fk] FOREIGN KEY ([collectRequiredGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableTotalsCollect_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([collectRarityId]) REFERENCES [content].[scriptableRarities] ([typeId]),
    CONSTRAINT [scriptableTotalsCollect_scriptableTotals_totalGlobalObjectCode_fk] FOREIGN KEY ([totalGlobalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    CONSTRAINT [UQ__scriptab__2692B5EC4B2D962C] UNIQUE NONCLUSTERED ([totalGlobalObject] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableTotalsCollect_scriptableTotalsCollectId_uindex]
    ON [content].[scriptableTotalsCollect]([scriptableTotalsCollectId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableTotalsCollect_collectTypeId_collectMainTypeId_collectClassificationTypeId]
    ON [content].[scriptableTotalsCollect]([collectTypeId] ASC, [collectMainTypeId] ASC, [collectClassificationTypeId] ASC, [collectSubTypeId] ASC, [collectRarityId] ASC, [collectRequiredGlobalObject] ASC);


GO

