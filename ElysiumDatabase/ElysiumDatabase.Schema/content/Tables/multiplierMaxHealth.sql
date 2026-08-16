CREATE TABLE [content].[multiplierMaxHealth] (
    [id]                     SMALLINT       IDENTITY (0, 1) NOT NULL,
    [experienceEventTypeId]  TINYINT        NOT NULL,
    [percentageMaxHealthMin] SMALLINT       NOT NULL,
    [percentageMaxHealthMax] SMALLINT       NOT NULL,
    [experienceMultiplier]   DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_multiplierMaxHealth] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

