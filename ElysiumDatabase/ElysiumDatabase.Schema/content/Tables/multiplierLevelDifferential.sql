CREATE TABLE [content].[multiplierLevelDifferential] (
    [id]                      SMALLINT       IDENTITY (0, 1) NOT NULL,
    [experienceEventTypeId]   TINYINT        NOT NULL,
    [experienceTypeId]        TINYINT        NOT NULL,
    [levelDifferential]       SMALLINT       NOT NULL,
    [experienceMinMultiplier] DECIMAL (5, 2) NOT NULL,
    [experienceMaxMultiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_multiplierLevelDifferential] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

