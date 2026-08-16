CREATE TABLE [content].[statsBaseTiers] (
    [id]               SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalTierId]     TINYINT        NOT NULL,
    [statId]           TINYINT        NOT NULL,
    [statTypeId]       TINYINT        NOT NULL,
    [statInitialValue] DECIMAL (5, 2) NOT NULL,
    [formatColumn]     BIT            NOT NULL,
    CONSTRAINT [PK_statsBaseTiers] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

