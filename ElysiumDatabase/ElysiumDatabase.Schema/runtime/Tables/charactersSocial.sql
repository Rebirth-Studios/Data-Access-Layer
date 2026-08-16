CREATE TABLE [runtime].[charactersSocial] (
    [characterSocialId] INT      IDENTITY (1, 1) NOT NULL,
    [characterId]       INT      NOT NULL,
    [lastActionDate]    DATETIME NULL,
    [socialTypeId]      TINYINT  NOT NULL,
    [socialCharacterId] INT      NOT NULL,
    CONSTRAINT [PK_charactersSocial] PRIMARY KEY CLUSTERED ([characterSocialId] ASC),
    CONSTRAINT [charactersSocial_characters_characterId_fk] FOREIGN KEY ([socialCharacterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [charactersSocial_socialTypes_socialTypeId_fk] FOREIGN KEY ([socialTypeId]) REFERENCES [content].[socialTypes] ([typeId]),
    CONSTRAINT [FK_charactersSocial_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [IX_charactersSocial] UNIQUE NONCLUSTERED ([characterId] ASC, [socialCharacterId] ASC)
);


GO

