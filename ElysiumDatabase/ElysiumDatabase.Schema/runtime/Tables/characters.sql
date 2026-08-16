CREATE TABLE [runtime].[characters] (
    [characterId]          INT              IDENTITY (1, 1) NOT NULL,
    [playerAccountId]      INT              NOT NULL,
    [characterTierId]      TINYINT          NOT NULL,
    [characterRankId]      TINYINT          NOT NULL,
    [characterModelId]     INT              NULL,
    [characterFactionId]   TINYINT          NOT NULL,
    [characterExperience]  INT              NOT NULL,
    [dateTimeCreated]      DATETIME         NOT NULL,
    [characterName]        VARCHAR (12)     NOT NULL,
    [lastUpdated]          DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [gender]               TINYINT          CONSTRAINT [DF__character__gende__4FD1D5C8] DEFAULT ((1)) NOT NULL,
    [face]                 TINYINT          CONSTRAINT [DF__characters__face__50C5FA01] DEFAULT ((1)) NOT NULL,
    [eyebrows]             TINYINT          CONSTRAINT [DF__character__eyebr__51BA1E3A] DEFAULT ((1)) NOT NULL,
    [hair]                 TINYINT          CONSTRAINT [DF__characters__hair__52AE4273] DEFAULT ((1)) NOT NULL,
    [facialHair]           TINYINT          CONSTRAINT [DF__character__facia__53A266AC] DEFAULT ((1)) NOT NULL,
    [eyeColor]             VARCHAR (7)      NOT NULL,
    [hairColor]            VARCHAR (7)      NOT NULL,
    [skinColor]            VARCHAR (7)      NOT NULL,
    [race]                 TINYINT          CONSTRAINT [DF__characters__race__54968AE5] DEFAULT ((0)) NOT NULL,
    [stubbleColor]         VARCHAR (7)      NOT NULL,
    [status]               VARCHAR (50)     NOT NULL,
    [spawnCoordinateX]     DECIMAL (18, 2)  NOT NULL,
    [spawnCoordinateY]     DECIMAL (18, 2)  NOT NULL,
    [spawnCoordinateZ]     DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [characters_primaryKey] PRIMARY KEY CLUSTERED ([characterId] ASC),
    CONSTRAINT [characters_globalTiers_globalTierId_fk] FOREIGN KEY ([characterTierId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [characters_playersAccounts_playerAccountId_fk] FOREIGN KEY ([playerAccountId]) REFERENCES [iam].[playersAccounts] ([playerAccountId]),
    CONSTRAINT [characters_spawnedWorldObjects_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

