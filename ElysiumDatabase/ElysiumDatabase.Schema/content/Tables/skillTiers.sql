CREATE TABLE [content].[skillTiers] (
    [typeId]                           TINYINT         NOT NULL,
    [type]                             VARCHAR (255)   NOT NULL,
    [typeName]                         VARCHAR (255)   NOT NULL,
    [description]                      VARCHAR (255)   NOT NULL,
    [parentEnum]                       VARCHAR (50)    NOT NULL,
    [parentTypeId]                     TINYINT         NOT NULL,
    [childEnum]                        VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]           SMALLINT        NOT NULL,
    [skillDifficultyExperiencePenalty] DECIMAL (18, 2) NULL,
    CONSTRAINT [skillTiers_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

