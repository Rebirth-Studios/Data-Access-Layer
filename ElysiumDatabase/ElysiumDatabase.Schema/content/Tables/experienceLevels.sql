CREATE TABLE [content].[experienceLevels] (
    [id]                         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [levelId]                    TINYINT        NOT NULL,
    [experienceMultiplierPlayer] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_experienceLevels] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

