CREATE TABLE [content].[entityImbuedTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (1000)  NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [offsetRelativeLevelId]      TINYINT         NOT NULL,
    [additionalRarity]           TINYINT         NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    [displayName]                VARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_entityImbuedTypes] PRIMARY KEY CLUSTERED ([typeId] ASC),
    UNIQUE NONCLUSTERED ([type] ASC)
);


GO

