CREATE TABLE [content].[ContainerRarity] (
    [id]                               SMALLINT   NOT NULL,
    [containerImbuedTypeId]            TINYINT    NOT NULL,
    [offsetRelativeLevelIdImbued]      NCHAR (10) NULL,
    [additionalRarityImbued]           NCHAR (10) NULL,
    [additionalSkillRequiredImbued]    NCHAR (10) NULL,
    [experienceMultiplierPlayerImbued] NCHAR (10) NULL,
    [experienceMultiplierSkillImbued]  NCHAR (10) NULL,
    CONSTRAINT [PK_ContainerRarity] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

