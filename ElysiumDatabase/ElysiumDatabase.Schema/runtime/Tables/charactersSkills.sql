CREATE TABLE [runtime].[charactersSkills] (
    [characterSkillId]         INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]             VARCHAR (255) NOT NULL,
    [characterSkillExperience] INT           NOT NULL,
    [lastUpdated]              DATETIME      NOT NULL,
    [characterId]              INT           NOT NULL,
    CONSTRAINT [charactersSkills_primaryKey] PRIMARY KEY CLUSTERED ([characterSkillId] ASC),
    CONSTRAINT [charactersSkills_scriptableSkills_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableSkills] ([globalObject]),
    CONSTRAINT [FK_charactersSkills_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [charactersSkills_globalObject_characterId_uindex]
    ON [runtime].[charactersSkills]([globalObject] ASC, [characterId] ASC);


GO

