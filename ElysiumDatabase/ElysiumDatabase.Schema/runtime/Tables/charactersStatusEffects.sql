CREATE TABLE [runtime].[charactersStatusEffects] (
    [characterId]             INT           NOT NULL,
    [effectGroupGlobalObject] VARCHAR (255) NOT NULL,
    [remainingDuration]       FLOAT (53)    NOT NULL,
    [stacks]                  TINYINT       NOT NULL,
    CONSTRAINT [charactersStatusEffects_characters_characterId_fk] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [charactersStatusEffects_effectGroups_effectGroupGlobalObject_fk] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [charactersStatusEffects_characterId_effectGroupGlobalObject_uindex]
    ON [runtime].[charactersStatusEffects]([characterId] ASC, [effectGroupGlobalObject] ASC);


GO

