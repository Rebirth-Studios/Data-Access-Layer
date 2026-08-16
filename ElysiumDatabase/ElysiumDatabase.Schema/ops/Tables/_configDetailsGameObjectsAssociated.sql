CREATE TABLE [ops].[_configDetailsGameObjectsAssociated] (
    [gameObjectType]             AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [associatedGameObjectType]   AS            ([dbo].[getGameObjectType]([associatedGameObjectTypeId])),
    [keyGameObjectType]          AS            ([dbo].[getGameObjectType]([keyGameObjectTypeId])),
    [keyGridViewName]            VARCHAR (100) NOT NULL,
    [filterValues]               VARCHAR (255) NOT NULL,
    [dataLevel]                  VARCHAR (100) NOT NULL,
    [enumName]                   VARCHAR (100) NOT NULL,
    [typePropertyName]           VARCHAR (100) NOT NULL,
    [typeControlName]            VARCHAR (100) NOT NULL,
    [gameObjectTypeId]           TINYINT       NOT NULL,
    [associatedGameObjectTypeId] TINYINT       NOT NULL,
    [keyGameObjectTypeId]        TINYINT       NOT NULL
);


GO

