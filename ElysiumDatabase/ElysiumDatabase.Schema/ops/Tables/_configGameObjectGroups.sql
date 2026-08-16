CREATE TABLE [ops].[_configGameObjectGroups] (
    [id]               TINYINT IDENTITY (1, 1) NOT NULL,
    [gameObjectType]   AS      ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [1]                AS      ([dbo].[getGameObjectType]([1Id])),
    [2]                AS      ([dbo].[getGameObjectType]([2Id])),
    [3]                AS      ([dbo].[getGameObjectType]([3Id])),
    [gameObjectTypeId] TINYINT NOT NULL,
    [1Id]              TINYINT NOT NULL,
    [2Id]              TINYINT NOT NULL,
    [3Id]              TINYINT NOT NULL,
    CONSTRAINT [PK__configGameObjectGroups] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

