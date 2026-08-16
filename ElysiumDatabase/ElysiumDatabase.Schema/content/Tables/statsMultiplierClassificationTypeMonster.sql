CREATE TABLE [content].[statsMultiplierClassificationTypeMonster] (
    [id]                   SMALLINT       IDENTITY (0, 1) NOT NULL,
    [classificationTypeId] TINYINT        NOT NULL,
    [statId]               TINYINT        NOT NULL,
    [statTypeId]           TINYINT        NOT NULL,
    [multiplier]           DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseMonsterClassificationTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

