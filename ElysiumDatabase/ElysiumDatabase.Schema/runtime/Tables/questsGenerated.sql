CREATE TABLE [runtime].[questsGenerated] (
    [questId]            UNIQUEIDENTIFIER NOT NULL,
    [questTitle]         VARCHAR (1000)   NULL,
    [questTypeId]        INT              NOT NULL,
    [questTierId]        INT              NOT NULL,
    [Description]        VARCHAR (1000)   NOT NULL,
    [requiredProgress]   INT              NOT NULL,
    [currentProgress]    INT              NOT NULL,
    [questObjectiveCode] VARCHAR (255)    NOT NULL,
    [questRankId]        INT              NOT NULL,
    [questStatusId]      INT              NOT NULL,
    [questValue]         INT              NULL,
    [lastUpdate]         DATETIME         NOT NULL,
    CONSTRAINT [PK_questsGenerated] PRIMARY KEY CLUSTERED ([questId] ASC)
);


GO

