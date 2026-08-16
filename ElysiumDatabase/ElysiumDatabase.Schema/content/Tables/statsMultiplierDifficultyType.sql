CREATE TABLE [content].[statsMultiplierDifficultyType] (
    [id]                     SMALLINT       IDENTITY (0, 1) NOT NULL,
    [entityDifficultyTypeId] TINYINT        NOT NULL,
    [statId]                 TINYINT        NOT NULL,
    [statTypeId]             TINYINT        NOT NULL,
    [multiplier]             DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsMultiplierDifficultyType] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

