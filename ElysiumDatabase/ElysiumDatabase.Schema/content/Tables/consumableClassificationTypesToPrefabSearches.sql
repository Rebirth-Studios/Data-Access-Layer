CREATE TABLE [content].[consumableClassificationTypesToPrefabSearches] (
    [id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]           VARCHAR (100) NOT NULL,
    [prefabSearch]   VARCHAR (100) NOT NULL,
    [prefabSearchId] AS            ([dbo].[getPrefabSearchId]([prefabSearch])),
    CONSTRAINT [PK_consumableClassificationTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

