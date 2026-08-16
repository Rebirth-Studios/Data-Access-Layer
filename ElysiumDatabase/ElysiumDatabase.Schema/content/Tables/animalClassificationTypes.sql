CREATE TABLE [content].[animalClassificationTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (255)   NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK__animalCl__8F3595846162F3A8] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__animalCl__8F359585F24B7354] UNIQUE NONCLUSTERED ([typeId] ASC)
);


GO

