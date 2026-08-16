CREATE TABLE [content].[enemyHumanoidTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (1000)  NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [enemyHumanoidTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [enemyHumanoidTypes_enemyHumanoidType_uindex]
    ON [content].[enemyHumanoidTypes]([type] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [enemyHumanoidTypes_enemyHumanoidTypeId_uindex]
    ON [content].[enemyHumanoidTypes]([typeId] ASC);


GO

