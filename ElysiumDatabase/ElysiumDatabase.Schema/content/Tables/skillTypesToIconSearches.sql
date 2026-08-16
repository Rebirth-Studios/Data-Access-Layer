CREATE TABLE [content].[skillTypesToIconSearches] (
    [id]           TINYINT       IDENTITY (0, 1) NOT NULL,
    [type]         VARCHAR (255) NOT NULL,
    [iconSearch]   VARCHAR (255) NOT NULL,
    [iconSearchId] SMALLINT      NOT NULL,
    CONSTRAINT [PK_skillTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

