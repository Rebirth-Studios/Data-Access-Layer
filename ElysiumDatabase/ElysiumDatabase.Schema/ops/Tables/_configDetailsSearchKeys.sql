CREATE TABLE [ops].[_configDetailsSearchKeys] (
    [gameObjectType]             AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [tableName]                  VARCHAR (100) NOT NULL,
    [rowGameObjectType]          AS            ([dbo].[getGameObjectType]([rowGameObjectTypeId])),
    [rowNumber]                  TINYINT       NOT NULL,
    [exclude]                    BIT           NOT NULL,
    [keyNumber]                  TINYINT       NOT NULL,
    [searchKeyColumnOverride]    VARCHAR (255) NOT NULL,
    [loadOrder]                  TINYINT       NOT NULL,
    [gameObjectTypeId]           TINYINT       NOT NULL,
    [rowGameObjectTypeId]        TINYINT       NOT NULL,
    [updateTypeOverride]         VARCHAR (50)  NOT NULL,
    [removeWhenAdding]           BIT           NOT NULL,
    [associatedGameObjectType]   AS            ([dbo].[getGameObjectType]([associatedGameObjectTypeId])),
    [associatedGameObjectTypeId] TINYINT       NOT NULL,
    [searchKeyColumn]            AS            ([dbo].[getSearchKeyColumn]([tableName]))
);


GO

