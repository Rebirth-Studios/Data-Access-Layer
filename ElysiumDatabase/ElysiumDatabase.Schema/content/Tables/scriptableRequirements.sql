CREATE TABLE [content].[scriptableRequirements] (
    [scriptableRequirementId] INT           IDENTITY (1, 1) NOT NULL,
    [requiredForGlobalObject] VARCHAR (255) NOT NULL,
    [requirementGlobalObject] VARCHAR (255) NOT NULL,
    [requiredForTypeId]       TINYINT       NOT NULL,
    [requirementTypeId]       TINYINT       NOT NULL,
    [requirementRankId]       TINYINT       NOT NULL,
    [requirementLevelId]      TINYINT       NOT NULL,
    [numRequired]             SMALLINT      CONSTRAINT [DF__scriptabl__numRe__38B96646] DEFAULT ((0)) NOT NULL,
    [globalObject]            AS            ([dbo].[globalObjectAlias]([requiredForGlobalObject])),
    [requiredFor]             AS            ([dbo].[getGlobalObjectName]([requiredForGlobalObject])),
    [requirement]             AS            ([dbo].[getGlobalObjectName]([requirementGlobalObject])),
    [requiredForType]         AS            ([dbo].[getRequirementTypeName]([requiredForTypeId])),
    [requirementType]         AS            ([dbo].[getRequirementTypeName]([requirementTypeId])),
    CONSTRAINT [scriptableRequirements_pk] PRIMARY KEY CLUSTERED ([scriptableRequirementId] ASC),
    CONSTRAINT [scriptableRequirements_globalRanks_globalRankId_fk] FOREIGN KEY ([requirementRankId]) REFERENCES [content].[globalRanks] ([globalRankId]),
    CONSTRAINT [scriptableRequirements_requirementTypes_requirementTypeId_fk] FOREIGN KEY ([requirementTypeId]) REFERENCES [content].[requirementTypes] ([typeId]),
    CONSTRAINT [scriptableRequirements_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([requiredForGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [scriptableRequirements_scriptableObjects_globalObjectCode_fk_2] FOREIGN KEY ([requirementGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableRequirements_scriptableRequirementId_uindex]
    ON [content].[scriptableRequirements]([scriptableRequirementId] ASC);


GO

