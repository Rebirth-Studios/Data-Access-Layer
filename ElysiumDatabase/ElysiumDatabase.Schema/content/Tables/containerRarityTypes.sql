CREATE TABLE [content].[containerRarityTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (255)   NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [offsetRelativeLevelId]      TINYINT         NOT NULL,
    [additionalRarity]           TINYINT         NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    [experienceMultiplierSkill]  DECIMAL (18, 2) NOT NULL,
    [additionalSkillRequired]    TINYINT         NOT NULL,
    [displayName]                VARCHAR (100)   NOT NULL,
    CONSTRAINT [containerRarityTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

