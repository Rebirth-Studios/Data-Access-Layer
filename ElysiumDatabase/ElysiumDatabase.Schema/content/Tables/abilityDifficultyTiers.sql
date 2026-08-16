CREATE TABLE [content].[abilityDifficultyTiers] (
    [abilityDifficultyTierId]            TINYINT         NOT NULL,
    [abilityDifficultyTier]              VARCHAR (50)    NOT NULL,
    [abilityDifficultyTierName]          VARCHAR (50)    NULL,
    [description]                        VARCHAR (255)   NULL,
    [parentEnum]                         VARCHAR (50)    NULL,
    [parentTypeId]                       TINYINT         NULL,
    [childEnum]                          VARCHAR (50)    NULL,
    [globalObjectNamingType]             SMALLINT        NULL,
    [abilityDifficultyExperiencePenalty] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_abilityDifficultyTiers] PRIMARY KEY CLUSTERED ([abilityDifficultyTierId] ASC)
);


GO

