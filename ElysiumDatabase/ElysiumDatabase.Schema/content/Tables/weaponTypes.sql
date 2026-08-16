CREATE TABLE [content].[weaponTypes] (
    [typeId]                    TINYINT         NOT NULL,
    [type]                      VARCHAR (255)   NOT NULL,
    [typeName]                  VARCHAR (255)   NOT NULL,
    [description]               VARCHAR (255)   NOT NULL,
    [parentTypeId]              TINYINT         NOT NULL,
    [childEnum]                 VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]    SMALLINT        NOT NULL,
    [weaponSkill]               VARCHAR (50)    NOT NULL,
    [experienceMultiplierSkill] DECIMAL (18, 2) NOT NULL,
    [parentEnum]                VARCHAR (50)    NOT NULL,
    CONSTRAINT [mainHandTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [mainHandTypes_mainHandTypeId_uindex]
    ON [content].[weaponTypes]([typeId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [mainHandTypes_mainHandType_uindex]
    ON [content].[weaponTypes]([type] ASC);


GO

