CREATE TABLE [content].[scriptableEntities] (
    [scriptableEntityId] INT           IDENTITY (0, 1) NOT NULL,
    [entityTypeId]       TINYINT       NOT NULL,
    [globalObject]       VARCHAR (255) NOT NULL,
    PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableEntities_entityTypes_entityTypeId_fk] FOREIGN KEY ([entityTypeId]) REFERENCES [content].[entityTypes] ([typeId]),
    CONSTRAINT [scriptableEntities_scriptableWorldObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

