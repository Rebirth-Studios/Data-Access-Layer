CREATE TABLE [runtime].[instancedItems] (
    [instancedItemId]      UNIQUEIDENTIFIER NOT NULL,
    [itemTypeId]           TINYINT          NOT NULL,
    [maxStack]             TINYINT          NOT NULL,
    [quantity]             TINYINT          NOT NULL,
    [rarityId]             TINYINT          NOT NULL,
    [qualityId]            TINYINT          NOT NULL,
    [durabilityPercentage] DECIMAL (18, 2)  NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    [crafterName]          VARCHAR (255)    NOT NULL,
    [wasLooted]            BIT              NOT NULL,
    [wasCrafted]           BIT              NOT NULL,
    [status]               VARCHAR (255)    CONSTRAINT [DF__instanced__statu__35DCF99B] DEFAULT ('active') NOT NULL,
    [globalObject]         VARCHAR (255)    NOT NULL,
    [recipeGlobalObject]   VARCHAR (255)    NULL,
    CONSTRAINT [instancedItems_primaryKey] PRIMARY KEY CLUSTERED ([instancedItemId] ASC),
    CONSTRAINT [FK_instancedItems_scriptableRecipes] FOREIGN KEY ([recipeGlobalObject]) REFERENCES [content].[scriptableRecipes] ([globalObject])
);


GO

