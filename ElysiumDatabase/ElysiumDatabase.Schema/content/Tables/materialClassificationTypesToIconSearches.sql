CREATE TABLE [content].[materialClassificationTypesToIconSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearch]   VARCHAR (100) NOT NULL,
    [iconSearchId] AS            ([dbo].[getIconSearchId]([iconSearch])),
    CONSTRAINT [PK_materialClassificationTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

