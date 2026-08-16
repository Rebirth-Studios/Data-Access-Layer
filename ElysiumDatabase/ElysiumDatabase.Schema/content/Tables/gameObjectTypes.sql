CREATE TABLE [content].[gameObjectTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (100) NOT NULL,
    [typeName]               VARCHAR (100) NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (100) NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [unitTestScenarioMethod] VARCHAR (100) NOT NULL,
    [defaultValue]           VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__gameObjectTypes] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ___gameObj__B94FCF0B13599A5E] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

