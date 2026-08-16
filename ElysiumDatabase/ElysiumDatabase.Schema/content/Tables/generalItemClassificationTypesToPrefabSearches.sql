CREATE TABLE [content].[generalItemClassificationTypesToPrefabSearches] (
    [id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]           VARCHAR (100) NOT NULL,
    [prefabSearch]   VARCHAR (50)  NULL,
    [prefabSearchId] AS            ([dbo].[getPrefabSearchId]([prefabSearch])),
    CONSTRAINT [PK_generalItemClassificationTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

