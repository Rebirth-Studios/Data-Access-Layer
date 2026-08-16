CREATE TABLE [content].[scriptableTotalsConsume] (
    [id]                          SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]                VARCHAR (255) NOT NULL,
    [consumeTypeId]               TINYINT       NOT NULL,
    [consumeRarityId]             TINYINT       NOT NULL,
    [consumeRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [dataAttributeTypeId]         TINYINT       NOT NULL,
    [consumeMainTypeId]           TINYINT       NOT NULL,
    [consumeClassificationTypeId] TINYINT       NOT NULL,
    [consumeSubTypeId]            TINYINT       NOT NULL,
    [consumeTierId]               TINYINT       NOT NULL,
    [globalObjectName]            AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [consumeRequiredObjectName]   AS            ([dbo].[getGlobalObjectName]([consumeRequiredGlobalObject])),
    [dataAttributeType]           AS            ([dbo].[getDataAttributeType]([dataAttributeTypeId])),
    [isImbued]                    AS            ([dbo].[getIsImbuedFromScriptableItems]([consumeRequiredGlobalObject])),
    [consumeMainType]             AS            ([dbo].[getConsumableMainTypeName]([consumeMainTypeId])),
    [consumeClassificationType]   AS            ([dbo].[getConsumableClassificationTypeName]([consumeClassificationTypeId])),
    [consumeSubType]              AS            ([dbo].[getConsumableSubTypeName]([consumeSubTypeId])),
    [consumeType]                 AS            ([dbo].[getItemTypeName]([consumeTypeId])),
    [consumeRarity]               AS            ([dbo].[getRarityType]([consumeRarityId])),
    [consumeTier]                 AS            ([dbo].[getGlobalTierName]([consumeTierId])),
    CONSTRAINT [PK_scriptableTotalsConsume] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableTotalsConsume_globalObjects] FOREIGN KEY ([consumeRequiredGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_scriptableTotalsConsume_scriptableTotals] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    CONSTRAINT [scriptableTotalsConsume_dataAttributeTypes_typeId_fk] FOREIGN KEY ([dataAttributeTypeId]) REFERENCES [content].[dataAttributeTypes] ([typeId]),
    CONSTRAINT [scriptableTotalsConsume_itemTypes_itemTypeId_fk] FOREIGN KEY ([consumeTypeId]) REFERENCES [content].[itemTypes] ([typeId]),
    CONSTRAINT [scriptableTotalsConsume_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([consumeRarityId]) REFERENCES [content].[scriptableRarities] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D55D4FAC12] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

