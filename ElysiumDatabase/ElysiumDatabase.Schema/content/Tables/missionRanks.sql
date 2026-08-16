CREATE TABLE [content].[missionRanks] (
    [missionRankId]          TINYINT       NOT NULL,
    [missionRank]            VARCHAR (255) NOT NULL,
    [missionRankName]        VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [PK_missionRank] PRIMARY KEY CLUSTERED ([missionRankId] ASC),
    UNIQUE NONCLUSTERED ([missionRank] ASC)
);


GO

