CREATE TABLE [ops].[_configGameObjectExtraPanels] (
    [id]               TINYINT       IDENTITY (1, 1) NOT NULL,
    [gameObjectType]   AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [1]                VARCHAR (100) NOT NULL,
    [2]                VARCHAR (100) NOT NULL,
    [3]                VARCHAR (100) NOT NULL,
    [4]                VARCHAR (100) NOT NULL,
    [5]                VARCHAR (100) NOT NULL,
    [6]                VARCHAR (100) NOT NULL,
    [7]                VARCHAR (100) NOT NULL,
    [8]                VARCHAR (100) NOT NULL,
    [9]                VARCHAR (100) NOT NULL,
    [10]               VARCHAR (100) NOT NULL,
    [gameObjectTypeId] TINYINT       NOT NULL,
    CONSTRAINT [PK__configGameObjectExtraPanels] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

