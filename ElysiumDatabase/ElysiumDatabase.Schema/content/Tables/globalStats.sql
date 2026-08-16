CREATE TABLE [content].[globalStats] (
    [globalStatId]    INT             NOT NULL,
    [statTypeId]      INT             NOT NULL,
    [statStatusId]    INT             NOT NULL,
    [statTierId]      INT             NOT NULL,
    [statValue]       DECIMAL (18, 2) NOT NULL,
    [statDescription] VARCHAR (1000)  NOT NULL,
    [statFactionId]   INT             NOT NULL,
    [statIconId]      INT             NOT NULL,
    [globalStat]      VARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_globalStats] PRIMARY KEY CLUSTERED ([globalStatId] ASC)
);


GO

