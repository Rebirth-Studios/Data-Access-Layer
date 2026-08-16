CREATE TABLE [content].[prefabTypesToSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (255) NOT NULL,
    [prefabSearch] VARCHAR (255) NOT NULL,
    [enumName]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_prefabTypesToSearches] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [prefabTypeToSearch] UNIQUE NONCLUSTERED ([type] ASC, [prefabSearch] ASC, [enumName] ASC)
);


GO

