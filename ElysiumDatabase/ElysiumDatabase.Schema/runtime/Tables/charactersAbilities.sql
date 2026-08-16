CREATE TABLE [runtime].[charactersAbilities] (
    [characterAbilityId]         INT           IDENTITY (1, 1) NOT NULL,
    [characterAbilityExperience] INT           NOT NULL,
    [lastUpdated]                DATETIME      NOT NULL,
    [globalObject]               VARCHAR (255) NOT NULL,
    [characterId]                INT           NOT NULL,
    CONSTRAINT [charactersAbilities_primaryKey] PRIMARY KEY CLUSTERED ([characterAbilityId] ASC),
    CONSTRAINT [charactersAbilities_scriptableAbilities_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableAbilities] ([globalObject]),
    CONSTRAINT [FK_charactersAbilities_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

