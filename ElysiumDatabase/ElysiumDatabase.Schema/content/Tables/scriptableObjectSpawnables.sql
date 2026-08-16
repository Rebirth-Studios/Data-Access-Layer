CREATE TABLE [content].[scriptableObjectSpawnables] (
    [id]                            SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]                  VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]         VARCHAR (255) NOT NULL,
    [variationId]                   TINYINT       NOT NULL,
    [scriptableObjectSpawnable]     VARCHAR (255) NOT NULL,
    [scriptableObjectSpawnableName] VARCHAR (255) NOT NULL,
    [levelId]                       TINYINT       NOT NULL,
    CONSTRAINT [PK_scriptableObjectSpawnables] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__scriptabl__globa__76C212B7] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK__scriptabl__scrip__77B636F0] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [UQ__scriptab__5F32B1B345B2CF57] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC),
    CONSTRAINT [UQ__scriptab__6ADA9D13532B4F2E] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC)
);


GO

CREATE NONCLUSTERED INDEX [_dta_index_scriptableObjectSpawnables_5_701177539__K5_K4_3_6]
    ON [content].[scriptableObjectSpawnables]([scriptableObjectSpawnable] ASC, [variationId] ASC)
    INCLUDE([scriptableObjectLevel], [scriptableObjectSpawnableName]);


GO

