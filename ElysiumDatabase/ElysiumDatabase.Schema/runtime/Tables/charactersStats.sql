CREATE TABLE [runtime].[charactersStats] (
    [characterStatId]          INT             IDENTITY (1, 1) NOT NULL,
    [characterStatTypeId]      TINYINT         NOT NULL,
    [characterStatStatusId]    TINYINT         NOT NULL,
    [characterStatTierId]      TINYINT         NOT NULL,
    [characterStatValue]       DECIMAL (18, 2) NOT NULL,
    [characterStatDescription] VARCHAR (1000)  NOT NULL,
    [characterStatIconId]      TINYINT         NOT NULL,
    [statId]                   TINYINT         NOT NULL,
    [characterStat]            VARCHAR (255)   NOT NULL,
    [lastUpdate]               DATETIME        NOT NULL,
    [characterId]              INT             NOT NULL,
    [minValue]                 FLOAT (53)      NULL,
    [maxValue]                 FLOAT (53)      NULL,
    CONSTRAINT [charactersStats_primaryKey] PRIMARY KEY CLUSTERED ([characterStatId] ASC),
    CONSTRAINT [FK_charactersStats_characters] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [charactersStats_UQ] UNIQUE NONCLUSTERED ([characterId] ASC, [statId] ASC, [characterStatTypeId] ASC),
    CONSTRAINT [charactersStats_UQ_8] UNIQUE NONCLUSTERED ([characterId] ASC, [characterStatId] ASC, [characterStatTypeId] ASC)
);


GO

