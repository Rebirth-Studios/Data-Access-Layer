CREATE TABLE [content].[skillDifficultyTiers] (
    [skillDifficultyTierId]            TINYINT         NOT NULL,
    [skillDifficultyTier]              VARCHAR (50)    NOT NULL,
    [skillDifficultyTierName]          VARCHAR (50)    NULL,
    [description]                      VARCHAR (255)   NULL,
    [parentEnum]                       VARCHAR (50)    NULL,
    [parentTypeId]                     TINYINT         NULL,
    [childEnum]                        VARCHAR (50)    NULL,
    [globalObjectNamingType]           SMALLINT        NULL,
    [skillDifficultyExperiencePenalty] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_skillDifficultyTiers] PRIMARY KEY CLUSTERED ([skillDifficultyTierId] ASC)
);


GO

