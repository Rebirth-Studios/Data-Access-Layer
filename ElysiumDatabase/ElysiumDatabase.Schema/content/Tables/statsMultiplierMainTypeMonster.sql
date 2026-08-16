CREATE TABLE [content].[statsMultiplierMainTypeMonster] (
    [id]         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [mainTypeId] TINYINT        NOT NULL,
    [statId]     TINYINT        NOT NULL,
    [statTypeId] TINYINT        NOT NULL,
    [multiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseMonsterMainTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

