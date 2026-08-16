CREATE TABLE [content].[weaponTypesToIconSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearch]   VARCHAR (100) NOT NULL,
    [iconSearchId] SMALLINT      NOT NULL,
    CONSTRAINT [PK_weaponTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

