CREATE TABLE [runtime].[spawnerLocations] (
    [locationId]       INT             IDENTITY (1, 1) NOT NULL,
    [positionX]        DECIMAL (16, 6) NOT NULL,
    [positionY]        DECIMAL (18, 6) NULL,
    [positionZ]        DECIMAL (18, 6) NULL,
    [rotationX]        DECIMAL (18, 6) NOT NULL,
    [rotationY]        DECIMAL (18, 6) NULL,
    [rotationZ]        DECIMAL (18, 6) NULL,
    [chunk]            INT             NULL,
    [variationId]      TINYINT         NOT NULL,
    [ignoreSpawnTable] BIT             NULL,
    [rankId]           TINYINT         NOT NULL,
    [spawnerTypeId]    TINYINT         NULL,
    [lastDeathTime]    DATETIME        DEFAULT (NULL) NULL,
    [globalObject]     VARCHAR (255)   NOT NULL,
    [scaleX]           DECIMAL (18, 6) NULL,
    [scaleY]           DECIMAL (18, 6) NULL,
    [scaleZ]           DECIMAL (18, 6) NULL,
    [prefabId]         VARCHAR (255)   NOT NULL,
    PRIMARY KEY CLUSTERED ([locationId] ASC),
    CONSTRAINT [FK_spawnerLocations_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    UNIQUE NONCLUSTERED ([locationId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [spawnerLocations_positionX_positionY_positionZ_uindex]
    ON [runtime].[spawnerLocations]([positionX] ASC, [positionY] ASC, [positionZ] ASC);


GO

