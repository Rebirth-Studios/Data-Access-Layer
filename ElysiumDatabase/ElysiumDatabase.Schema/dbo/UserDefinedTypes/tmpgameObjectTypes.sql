CREATE TYPE [dbo].[tmpgameObjectTypes] AS TABLE (
    [gameObjectTypeId]       VARCHAR (1000) NOT NULL,
    [gameObjectType]         VARCHAR (1000) NOT NULL,
    [gameObjectTypeName]     VARCHAR (1000) NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (1000) NOT NULL,
    [parentType]             VARCHAR (1000) NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (1000) NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    [unitTestScenarioMethod] VARCHAR (1000) NOT NULL);


GO

