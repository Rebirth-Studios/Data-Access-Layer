CREATE TABLE [runtime].[instancedAmmunition] (
    [lastUpdate]      DATETIME         NULL,
    [instancedItemId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [instancedAmmunition_pk] PRIMARY KEY CLUSTERED ([instancedItemId] ASC)
);


GO

