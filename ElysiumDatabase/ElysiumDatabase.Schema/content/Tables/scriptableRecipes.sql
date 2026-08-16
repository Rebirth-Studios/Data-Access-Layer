CREATE TABLE [content].[scriptableRecipes] (
    [id]                                    SMALLINT        IDENTITY (1, 1) NOT NULL,
    [globalObject]                          VARCHAR (255)   NOT NULL,
    [requiredSkillGlobalObject]             VARCHAR (255)   NOT NULL,
    [productGlobalObject]                   VARCHAR (255)   NOT NULL,
    [recipeDifficultyTierId]                TINYINT         NOT NULL,
    [requiredContainerTypeId]               TINYINT         NOT NULL,
    [requiredContainerClassificationTypeId] TINYINT         NOT NULL,
    [productQuantity]                       TINYINT         NOT NULL,
    [dynamicRecipe]                         BIT             NOT NULL,
    [craftDuration]                         DECIMAL (18, 2) NOT NULL,
    [minimumSkillRankId]                    TINYINT         NOT NULL,
    [minimumSkillLevelId]                   SMALLINT        NOT NULL,
    [isImbued]                              AS              ([dbo].[getIsImbuedFromScriptableItems]([productGlobalObject])),
    [ExperienceImbuedMultiplierRecipe]      DECIMAL (5, 2)  NOT NULL,
    [experienceSkillMultiplierRecipe]       DECIMAL (5, 2)  NOT NULL,
    [experiencePlayerMultiplierRecipe]      DECIMAL (5, 2)  NOT NULL,
    [experienceSkillTotal]                  AS              ([dbo].[getExperienceSkillTotalRecipe]([globalObject],[productGlobalObject])),
    [experiencePlayerTotal]                 AS              ([dbo].[getExperiencePlayerTotalRecipe]([globalObject],[productGlobalObject])),
    [recipeDescription]                     VARCHAR (1000)  NOT NULL,
    [globalObjectName]                      AS              ([dbo].[getGlobalObjectName]([globalObject])),
    [requiredSkillGlobalObjectName]         AS              ([dbo].[getGlobalObjectName]([requiredSkillGlobalObject])),
    [productGlobalObjectName]               AS              ([dbo].[getGlobalObjectName]([productGlobalObject])),
    [requiredContainerClassificationType]   AS              ([dbo].[getContainerClassificationTypeName]([requiredContainerClassificationTypeId])),
    [recipeDifficultyTier]                  AS              ([dbo].[getGlobalTierName]([recipeDifficultyTierId])),
    [minimumSkillRankName]                  AS              ([dbo].[getSkillRankName]([minimumSkillRankId])),
    [requiredContainerType]                 AS              ([dbo].[getContainerMainTypeName]([requiredContainerTypeId])),
    CONSTRAINT [PK__scriptab__5AB532D50BFF2FE3] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableRecipes_scriptableItems] FOREIGN KEY ([productGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [FK_scriptableRecipes_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableRecipes_globalTiers_globalTierId_fk] FOREIGN KEY ([recipeDifficultyTierId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [scriptableRecipes_scriptableSkills_globalObject_fk] FOREIGN KEY ([requiredSkillGlobalObject]) REFERENCES [content].[scriptableSkills] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D537093F24] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

