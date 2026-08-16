CREATE TABLE [content].[gatherableClassificationTypes] (
    [typeId]                     TINYINT        NOT NULL,
    [type]                       VARCHAR (255)  NOT NULL,
    [typeName]                   VARCHAR (255)  NOT NULL,
    [description]                VARCHAR (255)  NOT NULL,
    [parentEnum]                 VARCHAR (50)   NOT NULL,
    [parentTypeId]               TINYINT        NOT NULL,
    [childEnum]                  VARCHAR (50)   NOT NULL,
    [globalObjectNamingType]     SMALLINT       NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (5, 2) NULL,
    [experienceMultiplierSkill]  DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK__gatherab__C126AB16B9A01261] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [gatherableClassificationTypes_gatherableTypes_gatherableTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[gatherableTypes] ([typeId]),
    CONSTRAINT [UQ__gatherab__C126AB17EDAE859E] UNIQUE NONCLUSTERED ([typeId] ASC)
);


GO

