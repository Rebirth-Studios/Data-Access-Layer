CREATE TABLE [content].[questTiersRanksRewards] (
    [questTypeId]          TINYINT         NOT NULL,
    [questTierId]          TINYINT         NOT NULL,
    [questRankId]          TINYINT         NOT NULL,
    [questRankName]        VARCHAR (255)   NOT NULL,
    [minItemChance]        DECIMAL (18, 2) NOT NULL,
    [maxMultiplier]        DECIMAL (18, 2) NOT NULL,
    [minItemsAwarded]      DECIMAL (18, 2) NOT NULL,
    [maxItemsAwardedBonus] DECIMAL (18, 2) NOT NULL,
    [coreRewardId]         VARCHAR (255)   NOT NULL,
    [rarityId]             TINYINT         NOT NULL,
    CONSTRAINT [PK_questTiersRanksRewards] PRIMARY KEY CLUSTERED ([questTypeId] ASC, [questTierId] ASC, [questRankId] ASC)
);


GO

