CREATE TABLE [content].[levelRequirementsAbilities] (
    [rankId]             TINYINT NOT NULL,
    [levelId]            TINYINT NOT NULL,
    [minExperience]      INT     NOT NULL,
    [maxExperience]      INT     NOT NULL,
    [levelRequirementId] INT     IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [levelRequirementsAbilities_pk] PRIMARY KEY CLUSTERED ([levelRequirementId] ASC),
    CONSTRAINT [CK_levelRequirementsAbilities] CHECK ([minExperience]>=(0)),
    CONSTRAINT [CK_levelRequirementsAbilities_1] CHECK ([maxExperience]>=(0))
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [levelRequirementsAbilities_levelRequirementId_uindex]
    ON [content].[levelRequirementsAbilities]([levelRequirementId] ASC);


GO

