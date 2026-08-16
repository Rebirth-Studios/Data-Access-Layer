CREATE TABLE [ops].[_configGameObjectsTablesUsedBy] (
    [id]               SMALLINT      IDENTITY (1, 1) NOT NULL,
    [gameObjectType]   AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [sqlTableName]     VARCHAR (100) NOT NULL,
    [gameObjectTypeId] TINYINT       NOT NULL,
    CONSTRAINT [PK__configGameObjectsSheetsUsedBy] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

