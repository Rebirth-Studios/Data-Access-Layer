CREATE TABLE [content].[npcClassificationTypes] (
    [typeId]                     TINYINT         NOT NULL,
    [type]                       VARCHAR (255)   NOT NULL,
    [typeName]                   VARCHAR (255)   NOT NULL,
    [description]                VARCHAR (255)   NOT NULL,
    [parentEnum]                 VARCHAR (50)    NOT NULL,
    [parentTypeId]               TINYINT         NOT NULL,
    [childEnum]                  VARCHAR (50)    NOT NULL,
    [globalObjectNamingType]     SMALLINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK__npcClass__19A3D25991E83870] PRIMARY KEY CLUSTERED ([type] ASC),
    CONSTRAINT [UQ__npcClass__093F83F2AE67E00B] UNIQUE NONCLUSTERED ([typeName] ASC),
    CONSTRAINT [UQ__npcClass__19A3D2587C97FF75] UNIQUE NONCLUSTERED ([type] ASC),
    CONSTRAINT [UQ__npcClass__9CB15922D4E2F383] UNIQUE NONCLUSTERED ([typeId] ASC)
);


GO

