CREATE TABLE [content].[containerSubTypes] (
    [typeId]                     TINYINT        NOT NULL,
    [type]                       VARCHAR (255)  NOT NULL,
    [typeName]                   VARCHAR (255)  NOT NULL,
    [description]                VARCHAR (255)  NOT NULL,
    [parentEnum]                 VARCHAR (50)   NOT NULL,
    [parentTypeId]               TINYINT        NOT NULL,
    [childEnum]                  VARCHAR (50)   NOT NULL,
    [globalObjectNamingType]     SMALLINT       NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (5, 2) NOT NULL,
    [experienceMultiplierSkill]  DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [UQ__containe__5E7CBB9B2621736B] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

