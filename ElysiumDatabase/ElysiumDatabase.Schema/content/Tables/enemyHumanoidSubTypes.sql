CREATE TABLE [content].[enemyHumanoidSubTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (2000)  NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [enemyHumanoidSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [enemyHumanoidSubTypes_enemyHumanoidSubTypeId_uindex]
    ON [content].[enemyHumanoidSubTypes]([typeId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [enemyHumanoidSubTypes_enemyHumanoidSubType_uindex]
    ON [content].[enemyHumanoidSubTypes]([type] ASC);


GO

