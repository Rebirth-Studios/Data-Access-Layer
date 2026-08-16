CREATE TABLE [content].[bodyPartMultipliers] (
    [bodyPartMultiplierId] INT             IDENTITY (1, 1) NOT NULL,
    [bodyPartTypeId]       TINYINT         NOT NULL,
    [multiplierValue]      DECIMAL (18, 2) NOT NULL,
    [globalObject]         VARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_bodyPartMultipliers] PRIMARY KEY CLUSTERED ([bodyPartMultiplierId] ASC),
    CONSTRAINT [bodyPartMultipliers_bodyPartTypes_bodyPartTypeId_fk] FOREIGN KEY ([bodyPartTypeId]) REFERENCES [content].[bodyPartTypes] ([typeId]),
    CONSTRAINT [bodyPartMultipliers_scriptableWorldObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [bodyPartMultipliers_globalObject_bodyPartTypeId_uindex]
    ON [content].[bodyPartMultipliers]([globalObject] ASC, [bodyPartTypeId] ASC);


GO

