CREATE TABLE [content].[effectGroupsToObjectsMapping] (
    [effectGroupsToObjectsMappingId]  INT           IDENTITY (1, 1) NOT NULL,
    [effectGroupGlobalObject]         VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]           VARCHAR (255) NOT NULL,
    [levelId]                         TINYINT       NOT NULL,
    [associatedScriptableObjectLevel] VARCHAR (255) NOT NULL,
    [abilityGlobalObject]             VARCHAR (255) NOT NULL,
    CONSTRAINT [effectGroupsToObjectsMapping_pk] PRIMARY KEY CLUSTERED ([effectGroupsToObjectsMappingId] ASC),
    CONSTRAINT [effectGroupsToObjectsMapping_effectGroups_globalObject_fk] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject]),
    CONSTRAINT [FK__effectGro__scrip__62B425C5] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK_effectGroupsToObjectsMapping_scriptableAbilities] FOREIGN KEY ([abilityGlobalObject]) REFERENCES [content].[scriptableAbilities] ([globalObject]),
    CONSTRAINT [FK_effectGroupsToObjectsMapping_scriptableObjectLevels] FOREIGN KEY ([associatedScriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [effectGroupsToObjectsMapping_effectGroupsToObjectsMappingId_uindex]
    ON [content].[effectGroupsToObjectsMapping]([effectGroupsToObjectsMappingId] ASC);


GO

