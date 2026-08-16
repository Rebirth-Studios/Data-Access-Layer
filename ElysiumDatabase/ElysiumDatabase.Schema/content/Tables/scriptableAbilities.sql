CREATE TABLE [content].[scriptableAbilities] (
    [scriptableAbilityId]     INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]            VARCHAR (255)  NOT NULL,
    [abilitySlotTypeId]       TINYINT        NOT NULL,
    [abilityActivationTypeId] TINYINT        NOT NULL,
    [abilityFactionId]        TINYINT        NOT NULL,
    [abilityDifficultyTierId] TINYINT        NOT NULL,
    [abilityTypeId]           TINYINT        NOT NULL,
    [abilityDescription]      VARCHAR (1000) NOT NULL,
    [abilityDifficultyTier]   AS             ([dbo].[getAbilityDifficultyTier]([abilityDifficultyTierId])),
    [globalObjectName]        AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [abilityType]             AS             ([dbo].[getAbilityType]([abilityTypeId])),
    [abilitySlotType]         AS             ([dbo].[getAbilitySlotType]([abilitySlotTypeId])),
    [abilityActivationType]   AS             ([dbo].[getAbilityActivationType]([abilityActivationTypeId])),
    [abilityFaction]          AS             ([dbo].[getFactionType]([abilityFactionId])),
    CONSTRAINT [PK__scriptab__5AB532D5F5DD719B] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    FOREIGN KEY ([abilitySlotTypeId]) REFERENCES [content].[abilitySlotTypes] ([typeId]),
    FOREIGN KEY ([abilityTypeId]) REFERENCES [content].[abilityTypes] ([typeId]),
    CONSTRAINT [FK_scriptableAbilities_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableAbilities___fka] FOREIGN KEY ([abilityDifficultyTierId]) REFERENCES [content].[abilityDifficultyTiers] ([abilityDifficultyTierId]),
    CONSTRAINT [scriptableAbilities___fkf] FOREIGN KEY ([abilityFactionId]) REFERENCES [content].[globalFactions] ([typeId]),
    CONSTRAINT [scriptableAbilities_abilityActivationTypes_abilityActivationTypeId_fk] FOREIGN KEY ([abilityActivationTypeId]) REFERENCES [content].[abilityActivationTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D59F99A946] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

