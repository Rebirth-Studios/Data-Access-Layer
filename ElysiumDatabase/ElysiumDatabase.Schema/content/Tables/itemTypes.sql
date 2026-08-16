CREATE TABLE [content].[itemTypes] (
    [typeId]                           TINYINT        NOT NULL,
    [type]                             VARCHAR (255)  NOT NULL,
    [typeName]                         VARCHAR (255)  NOT NULL,
    [description]                      VARCHAR (1000) NOT NULL,
    [parentEnum]                       VARCHAR (50)   NOT NULL,
    [parentTypeId]                     TINYINT        NOT NULL,
    [childEnum]                        VARCHAR (50)   NOT NULL,
    [globalObjectNamingType]           SMALLINT       NOT NULL,
    [experienceSkillMultiplierImbued]  DECIMAL (5, 2) NULL,
    [experiencePlayerMultiplierImbued] DECIMAL (5, 2) NULL,
    CONSTRAINT [itemTypes_primaryKey] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

