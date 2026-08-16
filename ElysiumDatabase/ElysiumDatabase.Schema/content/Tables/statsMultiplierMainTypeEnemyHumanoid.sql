CREATE TABLE [content].[statsMultiplierMainTypeEnemyHumanoid] (
    [id]         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [mainTypeId] TINYINT        NOT NULL,
    [statId]     TINYINT        NOT NULL,
    [statTypeId] TINYINT        NOT NULL,
    [multiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseEnemyHumanoidMainTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

