CREATE TABLE [ops].[_configUnitTest] (
    [id]               SMALLINT      IDENTITY (1, 1) NOT NULL,
    [gameObjectType]   AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [tableName]        VARCHAR (100) NOT NULL,
    [columnName]       VARCHAR (100) NOT NULL,
    [expectedValue]    VARCHAR (100) NOT NULL,
    [renamedValue]     VARCHAR (100) NOT NULL,
    [gridViewName]     VARCHAR (100) NOT NULL,
    [rowNumber]        SMALLINT      NOT NULL,
    [gameObjectTypeId] TINYINT       NOT NULL,
    [unitTestNumber]   TINYINT       NOT NULL,
    CONSTRAINT [PK__configUnitTest] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

