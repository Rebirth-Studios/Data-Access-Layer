CREATE TABLE [content].[statsMultiplierImbuedType] (
    [id]                 SMALLINT       IDENTITY (0, 1) NOT NULL,
    [entityImbuedTypeId] TINYINT        NOT NULL,
    [statId]             TINYINT        NOT NULL,
    [statTypeId]         TINYINT        NOT NULL,
    [multiplier]         DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsMultiplierImbuedType] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

