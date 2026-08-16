CREATE TABLE [content].[statsMultiplierClassificationTypeEnemyHumanoid] (
    [id]                   SMALLINT       IDENTITY (0, 1) NOT NULL,
    [classificationTypeId] TINYINT        NOT NULL,
    [statId]               TINYINT        NOT NULL,
    [statTypeId]           TINYINT        NOT NULL,
    [multiplier]           DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseEnemyHumanoidClassificationTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

