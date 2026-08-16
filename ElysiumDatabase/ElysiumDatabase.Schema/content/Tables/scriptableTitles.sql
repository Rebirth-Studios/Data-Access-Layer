CREATE TABLE [content].[scriptableTitles] (
    [titleId]          INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]     VARCHAR (255)  NOT NULL,
    [titleFactionId]   TINYINT        NOT NULL,
    [isUpgradable]     BIT            NOT NULL,
    [isUnique]         BIT            NOT NULL,
    [description]      VARCHAR (1000) NOT NULL,
    [titleName]        AS             ([dbo].[getTitleName]([globalObject])),
    [globalObjectName] AS             ([dbo].[getGlobalObjectName]([globalObject])),
    [titleFaction]     AS             ([dbo].[getFactionType]([titleFactionId])),
    CONSTRAINT [PK__scriptab__5AB532D593EEDB59] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableTitles_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5F6A3D564] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

