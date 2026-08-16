CREATE TABLE [content].[prefabSearches] (
    [id]                          SMALLINT      IDENTITY (0, 1) NOT NULL,
    [prefabSearchName]            VARCHAR (100) NOT NULL,
    [prefabSearchType]            VARCHAR (50)  NOT NULL,
    [prefabFolderPath]            VARCHAR (100) NOT NULL,
    [prefabSearchString]          VARCHAR (50)  NOT NULL,
    [prefabExclusionSearchString] VARCHAR (255) NOT NULL,
    [description]                 VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_prefabSearches] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

