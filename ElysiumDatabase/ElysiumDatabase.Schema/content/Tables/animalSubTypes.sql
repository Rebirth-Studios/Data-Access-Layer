CREATE TABLE [content].[animalSubTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (1000)  NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [animalSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [animalSubTypes_animalTypes_animalTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[animalTypes] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [animalSubTypes_animalSubType_uindex]
    ON [content].[animalSubTypes]([type] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [animalSubTypes_animalSubTypeId_uindex]
    ON [content].[animalSubTypes]([typeId] ASC);


GO

