CREATE TABLE [content].[effectGroupsToItemsMapping] (
    [effectGroupsToItemsMappingId] INT           IDENTITY (1, 1) NOT NULL,
    [effectGroupGlobalObject]      VARCHAR (255) NOT NULL,
    [itemGlobalObject]             VARCHAR (255) NOT NULL,
    [rarityId]                     TINYINT       NOT NULL,
    [levelId]                      TINYINT       NOT NULL,
    CONSTRAINT [effectGroupsToItemsMapping_pk] PRIMARY KEY CLUSTERED ([effectGroupsToItemsMappingId] ASC),
    CONSTRAINT [FK_effectGroupsToItemsMapping_effectGroups] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject]),
    CONSTRAINT [FK_effectGroupsToItemsMapping_scriptableItemRarities] FOREIGN KEY ([itemGlobalObject], [rarityId]) REFERENCES [content].[scriptableItemRarities] ([globalObject], [rarityId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [effectGroupsToItemsMapping_effectGroupsToItemsMappingId_uindex]
    ON [content].[effectGroupsToItemsMapping]([effectGroupsToItemsMappingId] ASC);


GO

