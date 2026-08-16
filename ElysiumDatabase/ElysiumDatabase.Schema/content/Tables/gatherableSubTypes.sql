CREATE TABLE [content].[gatherableSubTypes] (
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
    [requiredSkillBase]          DECIMAL (5, 2) NOT NULL,
    [parentTypeName]             VARCHAR (50)   NOT NULL,
    [metalTypeName]              VARCHAR (50)   NOT NULL,
    CONSTRAINT [gatherableSubTypes_gatherableClassificationTypes_gatherableClassificationTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[gatherableClassificationTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [gatherableSubTypes_gatherableSubTypeId_uindex]
    ON [content].[gatherableSubTypes]([typeId] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [gatherableSubTypes_gatherableSubType_uindex]
    ON [content].[gatherableSubTypes]([type] ASC);


GO

