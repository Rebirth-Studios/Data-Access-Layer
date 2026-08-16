CREATE TABLE [runtime].[charactersStatsStaging] (
    [characterStatStagingId] INT             IDENTITY (1, 1) NOT NULL,
    [characterId]            INT             NOT NULL,
    [characterStatTypeId]    INT             NOT NULL,
    [characterStatStatusId]  INT             NOT NULL,
    [characterStatTierId]    INT             NOT NULL,
    [characterStatValue]     DECIMAL (18, 2) NOT NULL,
    [statId]                 INT             NOT NULL,
    [characterStat]          VARCHAR (255)   NOT NULL,
    [lastUpdate]             DATETIME        NOT NULL,
    [state]                  VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_charactersStatsStaging] PRIMARY KEY CLUSTERED ([characterStatStagingId] ASC)
);


GO

