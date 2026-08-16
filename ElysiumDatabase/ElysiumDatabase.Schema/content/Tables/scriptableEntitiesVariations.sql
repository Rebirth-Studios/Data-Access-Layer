CREATE TABLE [content].[scriptableEntitiesVariations] (
    [id]                       SMALLINT IDENTITY (0, 1) NOT NULL,
    [variationId]              TINYINT  NOT NULL,
    [entityTypeId]             TINYINT  NOT NULL,
    [entityImbuedTypeId]       TINYINT  NOT NULL,
    [entityDifficultyTypeId]   TINYINT  NOT NULL,
    [entityTypeName]           AS       ([dbo].[getEntityTypeName]([entityTypeId])),
    [entityImbuedTypeName]     AS       ([dbo].[getEntityImbuedTypeName]([entityImbuedTypeId])),
    [entityDifficultyTypeName] AS       ([dbo].[getEntityDifficultyTypeName]([entityDifficultyTypeId])),
    CONSTRAINT [PK_scriptableEntitiesVariations] PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([entityDifficultyTypeId]) REFERENCES [content].[entityDifficultyTypes] ([typeId]),
    FOREIGN KEY ([entityImbuedTypeId]) REFERENCES [content].[entityImbuedTypes] ([typeId]),
    FOREIGN KEY ([entityTypeId]) REFERENCES [content].[entityTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__entit__5B19F842] FOREIGN KEY ([entityTypeId]) REFERENCES [content].[entityTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__entit__5C0E1C7B] FOREIGN KEY ([entityImbuedTypeId]) REFERENCES [content].[entityImbuedTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__entit__5D0240B4] FOREIGN KEY ([entityDifficultyTypeId]) REFERENCES [content].[entityDifficultyTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([entityTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([entityTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([entityTypeId] ASC, [variationId] ASC)
);


GO

