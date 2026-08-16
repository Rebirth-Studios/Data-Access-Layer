CREATE TABLE [content].[armorSlotTypesToPrefabSearches] (
    [id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]           VARCHAR (100) NOT NULL,
    [prefabSearchId] SMALLINT      NOT NULL,
    [prefabSearch]   AS            ([dbo].[getPrefabSearchName]([prefabSearchId])),
    CONSTRAINT [PK_armorSlotTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

