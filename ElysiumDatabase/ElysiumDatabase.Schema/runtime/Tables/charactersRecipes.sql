CREATE TABLE [runtime].[charactersRecipes] (
    [characterRecipeId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]      VARCHAR (255) NOT NULL,
    [lastUpdate]        DATETIME      NOT NULL,
    [characterId]       INT           NOT NULL,
    CONSTRAINT [charactersRecipes_primaryKey] PRIMARY KEY CLUSTERED ([characterRecipeId] ASC),
    CONSTRAINT [charactersRecipes_scriptableRecipes_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableRecipes] ([globalObject]),
    CONSTRAINT [FK_charactersRecipes_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [charactersRecipes_globalObject_characterId_uindex]
    ON [runtime].[charactersRecipes]([globalObject] ASC, [characterId] ASC);


GO

