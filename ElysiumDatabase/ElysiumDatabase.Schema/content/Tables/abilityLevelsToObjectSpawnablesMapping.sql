CREATE TABLE [content].[abilityLevelsToObjectSpawnablesMapping] (
    [abilityRanksToObjectRanksMappingId] INT           IDENTITY (1, 1) NOT NULL,
    [abilityScriptableObjectLevel]       VARCHAR (255) NOT NULL,
    [abilityNumber]                      TINYINT       NOT NULL,
    [scriptableObjectSpawnable]          VARCHAR (255) NOT NULL,
    [abilityGlobalObject]                VARCHAR (255) NOT NULL,
    [globalObject]                       VARCHAR (255) NOT NULL,
    CONSTRAINT [abilityRanksToObjectRanksMapping_pk] PRIMARY KEY CLUSTERED ([abilityRanksToObjectRanksMappingId] ASC),
    CONSTRAINT [FK__abilityLe__abili__48F453C2] FOREIGN KEY ([abilityScriptableObjectLevel]) REFERENCES [content].[scriptableAbilitiesLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK__abilityLe__scrip__442F9EA5] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [FK_abilityLevelsToObjectSpawnablesMapping_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_abilityLevelsToObjectSpawnablesMapping_scriptableAbilities] FOREIGN KEY ([abilityGlobalObject]) REFERENCES [content].[scriptableAbilities] ([globalObject])
);


GO

