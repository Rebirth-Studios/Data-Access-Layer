CREATE TABLE [content].[iconTypesToSearches] (
    [id]         SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]       VARCHAR (255) NOT NULL,
    [iconSearch] VARCHAR (255) NOT NULL,
    [enumName]   VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_iconTypesToSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [typeToSearch] UNIQUE NONCLUSTERED ([type] ASC, [iconSearch] ASC, [enumName] ASC)
);


GO

