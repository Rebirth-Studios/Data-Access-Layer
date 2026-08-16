CREATE TABLE [content].[missionObjectivesEntities] (
    [id]                      SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]            VARCHAR (255) NOT NULL,
    [missionDifficultyPoints] SMALLINT      NOT NULL,
    [missionCategoryTypeId]   TINYINT       NOT NULL,
    [missionTypeId]           TINYINT       NOT NULL,
    [missionObjectiveId]      TINYINT       NOT NULL,
    [missionTierId]           TINYINT       NOT NULL,
    [missionMainTierId]       TINYINT       NOT NULL,
    [requirementTypeId]       TINYINT       NOT NULL,
    CONSTRAINT [PK_missionObjectivesEntities] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_missionObjectivesEntities_scriptableEntities] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [missionObjectivesEntities_missionCategoryTypes_typeId_fk] FOREIGN KEY ([missionCategoryTypeId]) REFERENCES [content].[missionCategoryTypes] ([typeId]),
    CONSTRAINT [missionObjectivesEntities_missionMainTiers_missionMainTierId_fk] FOREIGN KEY ([missionMainTierId]) REFERENCES [content].[missionMainTiers] ([missionMainTierId]),
    CONSTRAINT [missionObjectivesEntities_missionTiers_missionTierId_fk] FOREIGN KEY ([missionTierId]) REFERENCES [content].[missionTiers] ([missionTierId]),
    CONSTRAINT [missionObjectivesEntities_missionTypes_typeId_fk] FOREIGN KEY ([missionTypeId]) REFERENCES [content].[missionTypes] ([typeId]),
    CONSTRAINT [missionObjectivesEntities_requirementTypes_requirementTypeId_fk] FOREIGN KEY ([requirementTypeId]) REFERENCES [content].[requirementTypes] ([typeId])
);


GO

