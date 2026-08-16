CREATE TABLE [content].[scriptableContainersVariations] (
    [id]                        SMALLINT IDENTITY (0, 1) NOT NULL,
    [variationId]               TINYINT  NULL,
    [containerTypeId]           TINYINT  NOT NULL,
    [containerImbuedTypeId]     TINYINT  NOT NULL,
    [containerQuantityTypeId]   TINYINT  NOT NULL,
    [containerRarityTypeId]     TINYINT  NOT NULL,
    [containerTypeName]         AS       ([dbo].[getContainerTypeName]([containerTypeId])),
    [containerImbuedTypeName]   AS       ([dbo].[getContainerImbuedTypeName]([containerImbuedTypeId])),
    [containerQuantityTypeName] AS       ([dbo].[getContainerQuantityTypeName]([containerQuantityTypeId])),
    [containerRarityTypeName]   AS       ([dbo].[getContainerRarityTypeName]([containerRarityTypeId])),
    CONSTRAINT [PK_scriptableContainersVariations] PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([containerImbuedTypeId]) REFERENCES [content].[containerImbuedTypes] ([typeId]),
    FOREIGN KEY ([containerQuantityTypeId]) REFERENCES [content].[containerQuantityTypes] ([typeId]),
    FOREIGN KEY ([containerRarityTypeId]) REFERENCES [content].[containerRarityTypes] ([typeId]),
    FOREIGN KEY ([containerTypeId]) REFERENCES [content].[containerTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__conta__63AF3E43] FOREIGN KEY ([containerTypeId]) REFERENCES [content].[containerTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__conta__64A3627C] FOREIGN KEY ([containerImbuedTypeId]) REFERENCES [content].[containerImbuedTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__conta__659786B5] FOREIGN KEY ([containerQuantityTypeId]) REFERENCES [content].[containerQuantityTypes] ([typeId]),
    CONSTRAINT [FK__scriptabl__conta__668BAAEE] FOREIGN KEY ([containerRarityTypeId]) REFERENCES [content].[containerRarityTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([containerTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([containerTypeId] ASC, [variationId] ASC),
    UNIQUE NONCLUSTERED ([containerTypeId] ASC, [variationId] ASC)
);


GO

