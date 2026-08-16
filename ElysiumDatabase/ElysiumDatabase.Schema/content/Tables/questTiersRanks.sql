CREATE TABLE [content].[questTiersRanks] (
    [globalTierId]        TINYINT NOT NULL,
    [questRankId]         TINYINT NOT NULL,
    [minDifficultyPoints] INT     NOT NULL,
    [maxDifficultyPoints] INT     NOT NULL,
    CONSTRAINT [PK_questTiersRanks] PRIMARY KEY CLUSTERED ([globalTierId] ASC, [questRankId] ASC)
);


GO

