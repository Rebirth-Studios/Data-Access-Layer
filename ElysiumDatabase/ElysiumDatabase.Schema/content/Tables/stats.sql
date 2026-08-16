CREATE TABLE [content].[stats] (
    [statId]           TINYINT         NOT NULL,
    [statTypeId]       TINYINT         NOT NULL,
    [statStatusId]     TINYINT         NOT NULL,
    [statTierId]       TINYINT         NOT NULL,
    [statInitialValue] DECIMAL (18, 2) NOT NULL,
    [statDescription]  VARCHAR (1000)  NOT NULL,
    [statFactionId]    TINYINT         NOT NULL,
    [statIconId]       INT             NOT NULL,
    [stat]             VARCHAR (255)   NOT NULL,
    [statMinValue]     DECIMAL (18, 6) NOT NULL,
    [statMaxValue]     DECIMAL (18, 6) NOT NULL,
    [isEntityStat]     BIT             NOT NULL,
    [statTypeName]     AS              ([dbo].[getStatTypeName]([statTypeId])),
    [statName]         AS              ([dbo].[getStatName]([stat])),
    CONSTRAINT [stats_primaryKey] PRIMARY KEY CLUSTERED ([statId] ASC, [statTypeId] ASC),
    CONSTRAINT [FK_stats_statNames] FOREIGN KEY ([stat]) REFERENCES [content].[statNames] ([type])
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Holds all base player stats and calcs', @level0type = N'SCHEMA', @level0name = N'content', @level1type = N'TABLE', @level1name = N'stats';


GO

