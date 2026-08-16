CREATE TABLE [content].[scriptableAbilitiesLevels] (
    [globalObject]              AS             ([dbo].[getGlobalObjectFromScriptableObjectLevel]([scriptableObjectLevel])),
    [scriptableObjectLevel]     VARCHAR (255)  NOT NULL,
    [levelId]                   AS             ([dbo].[getLevelIdFromScriptableObjectLevel]([scriptableObjectLevel])),
    [experienceGain]            INT            NOT NULL,
    [requiresCombat]            BIT            NOT NULL,
    [movementRequired]          BIT            NOT NULL,
    [targetRestrictionTypeId]   TINYINT        NOT NULL,
    [cooldown]                  INT            NOT NULL,
    [maxStacks]                 TINYINT        NOT NULL,
    [activateWhileMoving]       BIT            NOT NULL,
    [activationTime]            DECIMAL (5, 2) NOT NULL,
    [scriptableObjectLevelName] AS             ([dbo].[getScriptableObjectLevelNameFromScriptableObjectLevel]([scriptableObjectLevel])),
    [globalObjectName]          AS             ([dbo].[getGlobalObjectNameUsingScriptableObjectLevel]([scriptableObjectLevel])),
    [targetRestrictionType]     AS             ([dbo].[getTargetRestrictionTypeName]([targetRestrictionTypeId])),
    CONSTRAINT [FK__scriptabl__scrip__34ED5B15] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [scriptableAbilitiesRanks_targetRestrictionTypes_targetRestrictionTypeId_fk] FOREIGN KEY ([targetRestrictionTypeId]) REFERENCES [content].[targetRestrictionTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5F32B1B345262ADC] UNIQUE NONCLUSTERED ([scriptableObjectLevel] ASC)
);


GO

