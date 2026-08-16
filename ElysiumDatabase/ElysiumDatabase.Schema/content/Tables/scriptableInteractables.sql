CREATE TABLE [content].[scriptableInteractables] (
    [id]                                    SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]                          VARCHAR (255) NOT NULL,
    [interactableTypeId]                    TINYINT       NOT NULL,
    [interactableRequiredSkillGlobalObject] VARCHAR (255) NOT NULL,
    [interactableRequiredSkillTierId]       TINYINT       NOT NULL,
    [interactableRequiredSkillRankId]       TINYINT       NOT NULL,
    [requiredSkillLevelId]                  SMALLINT      NOT NULL,
    [interactableHealth]                    INT           NOT NULL,
    [globalObjectName]                      AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [interactableRequiredSkillName]         AS            ([dbo].[getGlobalObjectName]([interactableRequiredSkillGlobalObject])),
    [interactableRequiredSkillTierName]     AS            ([dbo].[getSkillTierName]([interactableRequiredSkillTierId])),
    [interactableTypeName]                  AS            ([dbo].[getInteractableTypeName]([interactableTypeId])),
    [interactableRequiredSkillRankName]     AS            ([dbo].[getSkillRankName]([interactableRequiredSkillRankId])),
    CONSTRAINT [scriptableInteractables_interactableTypes_interactableTypeId_fk] FOREIGN KEY ([interactableTypeId]) REFERENCES [content].[interactableTypes] ([typeId]),
    CONSTRAINT [scriptableInteractables_scriptableSkills_globalObject_fk] FOREIGN KEY ([interactableRequiredSkillGlobalObject]) REFERENCES [content].[scriptableSkills] ([globalObject]),
    CONSTRAINT [scriptableInteractables_scriptableWorldObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D58649FAAA] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

