CREATE TABLE [content].[scriptablePrefabs] (
    [id]         INT            IDENTITY (0, 1) NOT NULL,
    [prefabName] VARCHAR (255)  NOT NULL,
    [prefabPath] VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_scriptablePrefabs] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

