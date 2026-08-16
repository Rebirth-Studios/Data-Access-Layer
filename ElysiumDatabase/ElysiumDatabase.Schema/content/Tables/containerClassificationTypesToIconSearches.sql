CREATE TABLE [content].[containerClassificationTypesToIconSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearch]   VARCHAR (50)  NULL,
    [iconSearchId] AS            ([dbo].[getIconSearchId]([iconSearch])),
    CONSTRAINT [PK_containerClassificationTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

