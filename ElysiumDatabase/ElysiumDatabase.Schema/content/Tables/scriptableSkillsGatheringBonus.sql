CREATE TABLE [content].[scriptableSkillsGatheringBonus] (
    [scriptableSkillsGatheringBonusId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]                     VARCHAR (255) NOT NULL,
    [skillLevel]                       TINYINT       NOT NULL,
    [quantityBonus]                    TINYINT       NOT NULL,
    [rarityBonus]                      TINYINT       NOT NULL,
    [globalObjectName]                 AS            ([dbo].[getGlobalObjectName]([globalObject])),
    CONSTRAINT [PK_scriptableSkillsGatheringBonus] PRIMARY KEY CLUSTERED ([scriptableSkillsGatheringBonusId] ASC),
    CONSTRAINT [scriptableSkillsGatheringBonus_scriptableSkills_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableSkills] ([globalObject])
);


GO

CREATE NONCLUSTERED INDEX [scriptableSkillsGatheringBonus_globalObjectCode_skillLevel_index]
    ON [content].[scriptableSkillsGatheringBonus]([globalObject] ASC, [skillLevel] ASC);


GO

