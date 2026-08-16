CREATE TABLE [content].[ruinStructureTypesToPrefabSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearch]   VARCHAR (100) NOT NULL,
    [iconSearchId] SMALLINT      NOT NULL,
    CONSTRAINT [PK_ruinStructureTypesToPrefabSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

