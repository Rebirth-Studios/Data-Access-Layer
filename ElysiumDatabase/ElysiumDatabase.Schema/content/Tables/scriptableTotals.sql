CREATE TABLE [content].[scriptableTotals] (
    [totalTypeId]       TINYINT       NOT NULL,
    [totalGlobalObject] VARCHAR (255) NOT NULL,
    [scriptableTotalId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObjectName]  AS            ([dbo].[getGlobalObjectName]([totalGlobalObject])),
    [totalTypeName]     AS            ([dbo].[getTotalTypeName]([totalTypeId])),
    PRIMARY KEY NONCLUSTERED ([totalGlobalObject] ASC),
    CONSTRAINT [scriptableTotals_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([totalGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableTotals_totalTypes_totalTypeId_fk] FOREIGN KEY ([totalTypeId]) REFERENCES [content].[totalTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([totalGlobalObject] ASC)
);


GO

