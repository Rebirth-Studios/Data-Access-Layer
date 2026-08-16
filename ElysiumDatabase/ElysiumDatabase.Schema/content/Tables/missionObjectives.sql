CREATE TABLE [content].[missionObjectives] (
    [id]                      SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject]            VARCHAR (255)  NOT NULL,
    [rarityId]                TINYINT        NOT NULL,
    [missionDifficultyPoints] DECIMAL (6, 2) NOT NULL,
    [missionCategoryTypeId]   TINYINT        NOT NULL,
    [missionTypeId]           TINYINT        NOT NULL,
    [missionTierId]           TINYINT        NOT NULL,
    [missionMainTierId]       TINYINT        NOT NULL,
    [requirementTypeId]       TINYINT        NOT NULL,
    CONSTRAINT [PK_missionObjectives] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_missionObjectives_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [missionObjectives_missionCategoryTypes_typeId_fk] FOREIGN KEY ([missionCategoryTypeId]) REFERENCES [content].[missionCategoryTypes] ([typeId]),
    CONSTRAINT [missionObjectives_missionMainTiers_missionMainTierId_fk] FOREIGN KEY ([missionMainTierId]) REFERENCES [content].[missionMainTiers] ([missionMainTierId]),
    CONSTRAINT [missionObjectives_missionTiers_missionTierId_fk] FOREIGN KEY ([missionTierId]) REFERENCES [content].[missionTiers] ([missionTierId]),
    CONSTRAINT [missionObjectives_missionTypes_typeId_fk] FOREIGN KEY ([missionTypeId]) REFERENCES [content].[missionTypes] ([typeId]),
    CONSTRAINT [missionObjectives_requirementTypes_requirementTypeId_fk] FOREIGN KEY ([requirementTypeId]) REFERENCES [content].[requirementTypes] ([typeId]),
    CONSTRAINT [missionObjectives_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

