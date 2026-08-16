CREATE TABLE [ops].[_configDetailsSearchKeysAssociated] (
    [mainGameObjectType]   AS            ([dbo].[getGameObjectType]([mainGameObjectTypeId])),
    [tableName]            VARCHAR (100) NOT NULL,
    [rowGameObjectType]    AS            ([dbo].[getGameObjectType]([rowGameObjectTypeId])),
    [keyNumber]            TINYINT       NOT NULL,
    [mainGameObjectTypeId] TINYINT       NOT NULL,
    [rowGameObjectTypeId]  TINYINT       NOT NULL
);


GO

