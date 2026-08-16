CREATE TABLE [ops].[_configDetailsNamingOverrides] (
    [mainGameObjectType]      AS            ([dbo].[getGameObjectType]([mainGameObjectTypeId])),
    [dataGameObjectType]      AS            ([dbo].[getGameObjectType]([dataGameObjectTypeId])),
    [globalObjectCodeString]  VARCHAR (100) NOT NULL,
    [globalObjectString]      VARCHAR (100) NOT NULL,
    [globalObjectName1String] VARCHAR (100) NOT NULL,
    [globalObjectName2String] VARCHAR (100) NOT NULL,
    [globalObjectNamingType]  VARCHAR (100) NOT NULL,
    [instanceNumber]          TINYINT       NOT NULL,
    [mainGameObjectTypeId]    TINYINT       NOT NULL,
    [dataGameObjectTypeId]    TINYINT       NOT NULL
);


GO

