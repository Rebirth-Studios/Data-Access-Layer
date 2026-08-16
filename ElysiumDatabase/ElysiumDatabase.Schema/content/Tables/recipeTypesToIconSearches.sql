CREATE TABLE [content].[recipeTypesToIconSearches] (
    [id]         SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]       VARCHAR (100) NOT NULL,
    [iconSearch] VARCHAR (50)  NULL,
    CONSTRAINT [PK_recipeTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

