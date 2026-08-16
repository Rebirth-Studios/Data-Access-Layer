CREATE TABLE [content].[statsBaseLevels] (
    [id]           SMALLINT       IDENTITY (0, 1) NOT NULL,
    [levelId]      TINYINT        NOT NULL,
    [statId]       TINYINT        NOT NULL,
    [statTypeId]   TINYINT        NOT NULL,
    [multiplier]   DECIMAL (5, 2) NOT NULL,
    [formatColumn] BIT            NOT NULL,
    CONSTRAINT [PK_statsBaseLevels] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

