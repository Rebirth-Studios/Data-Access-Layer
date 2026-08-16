CREATE TABLE [content].[iconSearches] (
    [id]                        SMALLINT      IDENTITY (0, 1) NOT NULL,
    [iconSearchName]            VARCHAR (100) NOT NULL,
    [iconSearchType]            VARCHAR (50)  NOT NULL,
    [iconFolderPath]            VARCHAR (100) NOT NULL,
    [iconSearchString]          VARCHAR (50)  NOT NULL,
    [iconExclusionSearchString] VARCHAR (50)  NOT NULL,
    [description]               VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_iconSearches] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

