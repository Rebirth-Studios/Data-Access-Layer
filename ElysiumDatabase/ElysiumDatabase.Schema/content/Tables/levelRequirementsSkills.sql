CREATE TABLE [content].[levelRequirementsSkills] (
    [rankId]             TINYINT NOT NULL,
    [levelId]            TINYINT NOT NULL,
    [minExperience]      INT     NOT NULL,
    [maxExperience]      INT     NOT NULL,
    [levelRequirementId] INT     IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [levelRequirementsSkills_pk] PRIMARY KEY CLUSTERED ([levelRequirementId] ASC),
    CONSTRAINT [CK_levelRequirementsSkills] CHECK ([minExperience]>=(0)),
    CONSTRAINT [CK_levelRequirementsSkills_1] CHECK ([maxExperience]>=(0))
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [levelRequirementsSkills_levelRequirementId_uindex]
    ON [content].[levelRequirementsSkills]([levelRequirementId] ASC);


GO

