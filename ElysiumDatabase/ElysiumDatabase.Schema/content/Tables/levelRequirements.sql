CREATE TABLE [content].[levelRequirements] (
    [rankId]             TINYINT NOT NULL,
    [levelId]            TINYINT NOT NULL,
    [minExperience]      INT     NOT NULL,
    [maxExperience]      INT     NOT NULL,
    [levelRequirementId] INT     IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [levelRequirements_pk] PRIMARY KEY CLUSTERED ([levelRequirementId] ASC),
    CONSTRAINT [CK_levelRequirements] CHECK ([minExperience]>=(0)),
    CONSTRAINT [CK_levelRequirements_1] CHECK ([maxExperience]>=(0))
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [levelRequirements_levelRequirementId_uindex]
    ON [content].[levelRequirements]([levelRequirementId] ASC);


GO

