CREATE TABLE [content].[statsMultiplierSubTypeMonster] (
    [id]         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [subTypeId]  TINYINT        NOT NULL,
    [statId]     TINYINT        NOT NULL,
    [statTypeId] TINYINT        NOT NULL,
    [multiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseMonsterSubTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

