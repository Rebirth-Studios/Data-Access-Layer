CREATE TABLE [runtime].[spawnedVendors] (
    [lastRestockTime]      DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [spawnedVendors_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedVendors_spawnedNPCs_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedNPCs] ([spawnedWorldObjectId])
);


GO

