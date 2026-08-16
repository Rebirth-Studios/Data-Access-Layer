CREATE TABLE [content].[scriptableGatherablesVariations] (
    [id]                         SMALLINT IDENTITY (0, 1) NOT NULL,
    [variationId]                TINYINT  NULL,
    [gatherableTypeId]           TINYINT  NOT NULL,
    [gatherableImbuedTypeId]     TINYINT  NOT NULL,
    [gatherableQuantityTypeId]   TINYINT  NOT NULL,
    [gatherableLocationTypeId]   TINYINT  NOT NULL,
    [gatherableTypeName]         AS       ([dbo].[getGatherableTypeName]([gatherableTypeId])),
    [gatherableImbuedTypeName]   AS       ([dbo].[getGatherableImbuedTypeName]([gatherableImbuedTypeId])),
    [gatherableQuantityTypeName] AS       ([dbo].[getGatherableQuantityTypeName]([gatherableQuantityTypeId])),
    [gatherableLocationTypeName] AS       ([dbo].[getGatherableLocationTypeName]([gatherableLocationTypeId])),
    CONSTRAINT [PK_scriptableGatherablesVariations] PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([gatherableImbuedTypeId]) REFERENCES [content].[gatherableImbuedTypes] ([typeId]),
    FOREIGN KEY ([gatherableLocationTypeId]) REFERENCES [content].[gatherableLocationTypes] ([typeId]),
    FOREIGN KEY ([gatherableQuantityTypeId]) REFERENCES [content].[gatherableQuantityTypes] ([typeId]),
    FOREIGN KEY ([gatherableTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__gathe__6D38A87D] FOREIGN KEY ([gatherableTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__gathe__6E2CCCB6] FOREIGN KEY ([gatherableImbuedTypeId]) REFERENCES [content].[gatherableImbuedTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__gathe__6F20F0EF] FOREIGN KEY ([gatherableQuantityTypeId]) REFERENCES [content].[gatherableQuantityTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__gathe__70151528] FOREIGN KEY ([gatherableLocationTypeId]) REFERENCES [content].[gatherableLocationTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([gatherableTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([gatherableTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([gatherableTypeId] ASC, [variationId] ASC)
);


GO

