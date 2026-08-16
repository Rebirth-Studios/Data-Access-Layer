CREATE TABLE [content].[scriptableContainersSpawnable] (
    [id]                        SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]              VARCHAR (255)  NOT NULL,
    [scriptableObjectLevel]     VARCHAR (255)  NOT NULL,
    [scriptableObjectSpawnable] VARCHAR (255)  NOT NULL,
    [containerTypeId]           TINYINT        NOT NULL,
    [variationId]               TINYINT        NOT NULL,
    [requiredPower]             TINYINT        NOT NULL,
    [maxToolPower]              TINYINT        NOT NULL,
    [width]                     DECIMAL (5, 2) NOT NULL,
    [height]                    DECIMAL (5, 2) NOT NULL,
    [displayName]               VARCHAR (255)  NOT NULL,
    CONSTRAINT [PK_scriptableContainersSpawnable] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__scriptabl__conta__70432B0D] FOREIGN KEY ([containerTypeId]) REFERENCES [content].[containerTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__scrip__63A849FE] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK__scriptabl__scrip__6F4F06D4] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [FK__scriptableContai__71374F46] FOREIGN KEY ([containerTypeId], [variationId]) REFERENCES [content].[scriptableContainersVariations] ([containerTypeId], [variationId]),
    CONSTRAINT [FK_scriptableContainersSpawnable_scriptableContainers] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableContainers] ([globalObject]),
    CONSTRAINT [UQ_ScriptableContainersSpawnable_ScriptableObjectSpawnable] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC)
);


GO

