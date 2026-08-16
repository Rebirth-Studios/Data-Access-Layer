CREATE TABLE [content].[questDifficultyRanges] (
    [questDifficultyRangeId] SMALLINT NOT NULL,
    [questTierId]            TINYINT  NOT NULL,
    [questMainTierId]        TINYINT  NOT NULL,
    [questRankId]            TINYINT  NOT NULL,
    [minDifficultyPoints]    SMALLINT NOT NULL,
    [maxDifficultyPoints]    SMALLINT NOT NULL,
    CONSTRAINT [PK_questDifficultyRanges] PRIMARY KEY CLUSTERED ([questDifficultyRangeId] ASC),
    CONSTRAINT [questDifficultyRanges_questMainTiers_questMainTierId_fk] FOREIGN KEY ([questMainTierId]) REFERENCES [content].[questMainTiers] ([typeId]),
    CONSTRAINT [questDifficultyRanges_questTiers_questTierId_fk] FOREIGN KEY ([questTierId]) REFERENCES [content].[questTiers] ([typeId])
);


GO

