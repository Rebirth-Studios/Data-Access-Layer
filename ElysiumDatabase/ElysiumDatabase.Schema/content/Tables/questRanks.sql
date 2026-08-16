CREATE TABLE [content].[questRanks] (
    [questRankId]            TINYINT       NOT NULL,
    [questRank]              VARCHAR (255) NOT NULL,
    [questRankName]          VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [PK_questRank] PRIMARY KEY CLUSTERED ([questRankId] ASC),
    UNIQUE NONCLUSTERED ([questRank] ASC)
);


GO

