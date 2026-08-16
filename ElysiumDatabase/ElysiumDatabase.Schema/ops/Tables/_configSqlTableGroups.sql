CREATE TABLE [ops].[_configSqlTableGroups] (
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
    [11]               VARCHAR (100) NOT NULL,
    [12]               VARCHAR (100) NOT NULL,
    [13]               VARCHAR (100) NOT NULL,
    [14]               VARCHAR (100) NOT NULL,
    [15]               VARCHAR (100) NOT NULL,
    [16]               VARCHAR (100) NOT NULL,
    [17]               VARCHAR (100) NOT NULL,
    [18]               VARCHAR (100) NOT NULL,
    [19]               VARCHAR (100) NOT NULL,
    [20]               VARCHAR (100) NOT NULL,
    [gameObjectTypeId] TINYINT       NOT NULL,
    CONSTRAINT [PK__configGoogleSheetGroups] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

