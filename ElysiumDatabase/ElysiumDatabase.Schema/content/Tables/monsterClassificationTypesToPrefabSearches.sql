CREATE TABLE [content].[monsterClassificationTypesToPrefabSearches] (
    [id]                 SMALLINT      IDENTITY (1, 1) NOT NULL,
    [classificationType] VARCHAR (100) NOT NULL,
    [prefabSearch]       VARCHAR (50)  NULL,
    [prefabSearchId]     AS            ([dbo].[getPrefabSearchId]([prefabSearch])),
    CONSTRAINT [PK_monsterClassificationTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([classificationType] ASC)
);


GO

