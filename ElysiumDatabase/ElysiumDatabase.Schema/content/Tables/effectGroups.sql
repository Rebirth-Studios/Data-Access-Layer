CREATE TABLE [content].[effectGroups] (
    [effectGroupId]                   INT             IDENTITY (1, 1) NOT NULL,
    [effectGroupGlobalObject]         VARCHAR (255)   NOT NULL,
    [damageCancels]                   BIT             NOT NULL,
    [duration]                        INT             NOT NULL,
    [applicationTypeId]               TINYINT         NOT NULL,
    [numTimesApplied]                 SMALLINT        NOT NULL,
    [timeBetweenApplications]         DECIMAL (16, 2) NOT NULL,
    [removeWhenEffectEnds]            BIT             NOT NULL,
    [maxStacks]                       SMALLINT        NOT NULL,
    [description]                     VARCHAR (1000)  NOT NULL,
    [effectGroupTypeId]               TINYINT         NOT NULL,
    [effectGroupClassificationTypeId] TINYINT         NOT NULL,
    CONSTRAINT [PK__effectGr__A3B4C7D2EA7A3E51] PRIMARY KEY NONCLUSTERED ([effectGroupGlobalObject] ASC),
    CONSTRAINT [effectGroups_applicationTypes_applicationTypeId_fk] FOREIGN KEY ([applicationTypeId]) REFERENCES [content].[applicationTypes] ([typeId]),
    CONSTRAINT [effectGroups_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [UQ__effectGr__A3B4C7D2535799A6] UNIQUE NONCLUSTERED ([effectGroupGlobalObject] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [effectGroups_effectGroupId_uindex]
    ON [content].[effectGroups]([effectGroupId] ASC);


GO

