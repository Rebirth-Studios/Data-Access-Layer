CREATE TABLE [content].[missionRewards] (
    [id]                   SMALLINT       IDENTITY (0, 1) NOT NULL,
    [missionTypeId]        TINYINT        NOT NULL,
    [missionTierId]        TINYINT        NOT NULL,
    [missionMainTierId]    TINYINT        NOT NULL,
    [missionRankId]        TINYINT        NOT NULL,
    [minItemChance]        DECIMAL (5, 2) NOT NULL,
    [maxMultiplier]        DECIMAL (5, 2) NOT NULL,
    [minItemsAwarded]      TINYINT        NOT NULL,
    [maxItemsAwardedBonus] TINYINT        NOT NULL,
    [coreReward]           VARCHAR (100)  NOT NULL,
    [rarityId]             TINYINT        NOT NULL,
    CONSTRAINT [PK_missionRewards] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [missionRewards_missionMainTiers_missionMainTierId_fk] FOREIGN KEY ([missionMainTierId]) REFERENCES [content].[missionMainTiers] ([missionMainTierId]),
    CONSTRAINT [missionRewards_missionRanks_typeId_fk] FOREIGN KEY ([missionRankId]) REFERENCES [content].[missionRanks] ([missionRankId]),
    CONSTRAINT [missionRewards_missionTiers_missionTierId_fk] FOREIGN KEY ([missionTierId]) REFERENCES [content].[missionTiers] ([missionTierId]),
    CONSTRAINT [missionRewards_missionTypes_typeId_fk] FOREIGN KEY ([missionTypeId]) REFERENCES [content].[missionTypes] ([typeId]),
    CONSTRAINT [missionRewards_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

