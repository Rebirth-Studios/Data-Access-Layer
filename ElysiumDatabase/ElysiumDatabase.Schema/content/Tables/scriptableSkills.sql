CREATE TABLE [content].[scriptableSkills] (
    [scriptableSkillId]     INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]          VARCHAR (255)  NOT NULL,
    [baseSkillGlobalObject] VARCHAR (255)  NOT NULL,
    [skillTypeId]           TINYINT        NOT NULL,
    [skillCategoryTypeId]   TINYINT        NOT NULL,
    [skillDifficultyTierId] TINYINT        NOT NULL,
    [skillDescription]      VARCHAR (1000) NOT NULL,
    [globalObjectName]      AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [skillDifficultyTier]   AS             ([dbo].[getSkillDifficultyTier]([skillDifficultyTierId])),
    [skillBase]             AS             ([dbo].[getGlobalObjectName]([baseSkillGlobalObject])),
    [skillType]             AS             ([dbo].[getSkillType]([skillTypeId])),
    [skillCategoryType]     AS             ([dbo].[getSkillCategoryType]([skillCategoryTypeId])),
    [experienceSkillBase]   AS             ([dbo].[getSkillExperienceSkillBase]([skillCategoryTypeId])),
    [experiencePlayerBase]  AS             ([dbo].[getSkillExperiencePlayerBase]([skillCategoryTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D5F1939F9B] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableSkills_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableSkills_scriptableSkills_globalObject_fk] FOREIGN KEY ([baseSkillGlobalObject]) REFERENCES [content].[scriptableSkills] ([globalObject]),
    CONSTRAINT [scriptableSkills_skillDifficultyTiers_skillDifficultyTierId_fk] FOREIGN KEY ([skillDifficultyTierId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [scriptableSkills_skillTypes_skillTypeId_fk] FOREIGN KEY ([skillTypeId]) REFERENCES [content].[skillTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5915FB728] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

