CREATE TABLE [content].[globalRanks] (
    [globalRankId]       TINYINT       NOT NULL,
    [globalRankName]     VARCHAR (255) NOT NULL,
    [adventurerRankName] VARCHAR (255) NOT NULL,
    [skillRankName]      VARCHAR (255) NOT NULL,
    [abilityRankName]    VARCHAR (255) NOT NULL,
    [spellRankName]      VARCHAR (255) NOT NULL,
    [coreRankName]       VARCHAR (255) NOT NULL,
    [questRankName]      VARCHAR (255) NOT NULL,
    [globalRank]         VARCHAR (255) NOT NULL,
    CONSTRAINT [globalRanks_pk] PRIMARY KEY CLUSTERED ([globalRankId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalRanks_globalRankId_uindex]
    ON [content].[globalRanks]([globalRankId] ASC);


GO

