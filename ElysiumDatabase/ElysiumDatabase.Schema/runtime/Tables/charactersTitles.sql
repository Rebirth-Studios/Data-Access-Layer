CREATE TABLE [runtime].[charactersTitles] (
    [characterTitleId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]     VARCHAR (255) NOT NULL,
    [lastUpdated]      DATETIME      NOT NULL,
    [characterId]      INT           NOT NULL,
    CONSTRAINT [charactersTitles_primaryKey] PRIMARY KEY CLUSTERED ([characterTitleId] ASC),
    CONSTRAINT [charactersTitles_scriptableTitles_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableTitles] ([globalObject]),
    CONSTRAINT [FK_charactersTitles_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

