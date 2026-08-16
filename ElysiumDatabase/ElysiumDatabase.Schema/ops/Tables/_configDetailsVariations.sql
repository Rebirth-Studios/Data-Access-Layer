CREATE TABLE [ops].[_configDetailsVariations] (
    [gameObjectType]        AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [gameObjectTypeId]      TINYINT       NOT NULL,
    [variationType]         VARCHAR (100) NOT NULL,
    [sqlTableNameSpawnable] VARCHAR (100) NOT NULL,
    [sqlTableNameVariation] VARCHAR (100) NOT NULL
);


GO

