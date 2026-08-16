CREATE TABLE [content].[abilityRanks] (
    [abilityRankId]   INT            NOT NULL,
    [abilityRankName] VARCHAR (255)  NOT NULL,
    [description]     VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_abilityRanks] PRIMARY KEY CLUSTERED ([abilityRankId] ASC)
);


GO

