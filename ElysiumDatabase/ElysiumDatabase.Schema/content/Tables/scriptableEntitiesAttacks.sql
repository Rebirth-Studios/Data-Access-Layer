CREATE TABLE [content].[scriptableEntitiesAttacks] (
    [id]                 SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]       VARCHAR (255) NOT NULL,
    [variationId]        TINYINT       NOT NULL,
    [abilityNumber]      TINYINT       NOT NULL,
    [attackGlobalObject] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_scriptableEntitiesAttacks] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableEntitiesAttacks_scriptableAbilities] FOREIGN KEY ([attackGlobalObject]) REFERENCES [content].[scriptableAbilities] ([globalObject]),
    CONSTRAINT [FK_scriptableEntitiesAttacks_scriptableEntitiesAttacks] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [UQ__scriptab__39F0CB858DC810E3] UNIQUE NONCLUSTERED ([globalObject] ASC, [variationId] ASC, [abilityNumber] ASC)
);


GO

