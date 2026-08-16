CREATE TABLE [runtime].[spawnedWorldObjects] (
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [worldObjectTypeId]    TINYINT          NOT NULL,
    [coordinateX]          DECIMAL (18, 8)  NOT NULL,
    [coordinateY]          DECIMAL (18, 8)  NOT NULL,
    [coordinateZ]          DECIMAL (18, 8)  NOT NULL,
    [chunk]                INT              NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    [rotationX]            DECIMAL (18, 8)  NOT NULL,
    [rotationY]            DECIMAL (18, 8)  NOT NULL,
    [rotationZ]            DECIMAL (18, 8)  NOT NULL,
    [globalTierId]         TINYINT          DEFAULT ((0)) NOT NULL,
    [globalRankId]         TINYINT          DEFAULT ((0)) NOT NULL,
    [variationId]          TINYINT          NULL,
    [ignoreSpawnTable]     BIT              CONSTRAINT [DF__spawnedWo__ignor__595B4002] DEFAULT ((0)) NULL,
    [locationId]           INT              NULL,
    [status]               VARCHAR (255)    NULL,
    [globalObject]         VARCHAR (255)    NULL,
    [scaleX]               DECIMAL (18, 8)  DEFAULT ((1)) NOT NULL,
    [scaleY]               DECIMAL (18, 8)  DEFAULT ((1)) NOT NULL,
    [scaleZ]               DECIMAL (18, 8)  DEFAULT ((1)) NOT NULL,
    [prefabId]             VARCHAR (255)    NOT NULL,
    CONSTRAINT [spawnedWorldObjects_primaryKey] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedWorldObjects_globalTiers_globalTierId_fk] FOREIGN KEY ([globalTierId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [spawnedWorldObjects_scriptableWorldObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject]),
    CONSTRAINT [spawnedWorldObjects_spawnerLocations_locationId_fk] FOREIGN KEY ([locationId]) REFERENCES [runtime].[spawnerLocations] ([locationId]),
    CONSTRAINT [spawnedWorldObjects_worldObjectTypes_worldObjectTypeId_fk] FOREIGN KEY ([worldObjectTypeId]) REFERENCES [content].[worldObjectTypes] ([typeId])
);


GO

