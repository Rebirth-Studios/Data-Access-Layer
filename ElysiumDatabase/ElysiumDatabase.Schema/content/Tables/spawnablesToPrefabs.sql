CREATE TABLE [content].[spawnablesToPrefabs] (
    [globalObject]              VARCHAR (255)  NOT NULL,
    [scriptableObjectSpawnable] VARCHAR (255)  NOT NULL,
    [prefabPath]                VARCHAR (1000) NOT NULL,
    [levelId]                   TINYINT        NOT NULL,
    [variationId]               TINYINT        NOT NULL,
    CONSTRAINT [FK__spawnable__globa__66B9C0D3] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [FK__spawnable__scrip__67ADE50C] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable])
);


GO

