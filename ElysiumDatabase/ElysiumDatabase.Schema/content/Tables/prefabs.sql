CREATE TABLE [content].[prefabs] (
    [prefabId]     INT           IDENTITY (1, 1) NOT NULL,
    [globalObject] VARCHAR (255) NOT NULL,
    [prefabName]   VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_prefabs] PRIMARY KEY CLUSTERED ([prefabId] ASC),
    CONSTRAINT [FK_prefabs_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

