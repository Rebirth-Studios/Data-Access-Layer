CREATE TABLE [content].[jewelryTypesToIconSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearch]   VARCHAR (50)  NULL,
    [iconSearchId] AS            ([dbo].[getIconSearchId]([iconSearch])),
    CONSTRAINT [PK_jewelryTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

