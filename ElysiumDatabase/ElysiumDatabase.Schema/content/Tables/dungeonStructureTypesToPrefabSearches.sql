CREATE TABLE [content].[dungeonStructureTypesToPrefabSearches] (
    [id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]           VARCHAR (100) NOT NULL,
    [prefabSearchId] SMALLINT      NOT NULL,
    [prefabSearch]   AS            ([dbo].[getPrefabSearchName]([prefabSearchId])),
    CONSTRAINT [PK_dungeonStructureTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

