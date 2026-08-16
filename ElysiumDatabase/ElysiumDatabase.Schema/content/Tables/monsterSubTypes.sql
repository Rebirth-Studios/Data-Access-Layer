CREATE TABLE [content].[monsterSubTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (1000)  NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [monsterSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [monsterSubTypes_monsterTypes_monsterTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[monsterTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [monsterSubTypes_monsterSubType_uindex]
    ON [content].[monsterSubTypes]([type] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [monsterSubTypes_monsterSubTypeId_uindex]
    ON [content].[monsterSubTypes]([typeId] ASC);


GO

