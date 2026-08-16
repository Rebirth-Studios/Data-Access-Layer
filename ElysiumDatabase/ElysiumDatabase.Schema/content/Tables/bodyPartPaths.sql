CREATE TABLE [content].[bodyPartPaths] (
    [bodyPartPathId] INT            IDENTITY (1, 1) NOT NULL,
    [bodyPartTypeId] TINYINT        NOT NULL,
    [bodyPartPath]   VARCHAR (1000) NOT NULL,
    [globalObject]   VARCHAR (255)  NOT NULL,
    CONSTRAINT [PK_bodyPartPaths] PRIMARY KEY CLUSTERED ([bodyPartPathId] ASC),
    CONSTRAINT [bodyPartPaths_bodyPartTypes_bodyPartTypeId_fk] FOREIGN KEY ([bodyPartTypeId]) REFERENCES [content].[bodyPartTypes] ([typeId]),
    CONSTRAINT [bodyPartPaths_scriptableWorldObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [bodyPartPaths_globalObject_bodyPartTypeId_uindex]
    ON [content].[bodyPartPaths]([globalObject] ASC, [bodyPartTypeId] ASC, [bodyPartPath] ASC);


GO

