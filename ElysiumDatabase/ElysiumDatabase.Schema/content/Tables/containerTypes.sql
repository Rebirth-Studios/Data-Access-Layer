CREATE TABLE [content].[containerTypes] (
    [typeId]                     TINYINT        NOT NULL,
    [type]                       VARCHAR (255)  NOT NULL,
    [typeName]                   VARCHAR (255)  NOT NULL,
    [description]                VARCHAR (1000) NOT NULL,
    [parentEnum]                 VARCHAR (50)   NOT NULL,
    [parentTypeId]               TINYINT        NOT NULL,
    [childEnum]                  VARCHAR (50)   NOT NULL,
    [globalObjectNamingType]     SMALLINT       NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (5, 2) NOT NULL,
    [experienceMultiplierSkill]  DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_containerTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

