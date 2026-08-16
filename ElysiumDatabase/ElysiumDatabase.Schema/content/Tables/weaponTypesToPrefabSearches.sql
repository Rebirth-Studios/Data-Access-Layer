CREATE TABLE [content].[weaponTypesToPrefabSearches] (
    [id]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]           VARCHAR (100) NOT NULL,
    [prefabSearch]   VARCHAR (100) NOT NULL,
    [prefabSearchId] SMALLINT      NOT NULL,
    CONSTRAINT [PK_weaponTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

