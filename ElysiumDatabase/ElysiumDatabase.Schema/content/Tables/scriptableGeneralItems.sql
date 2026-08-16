CREATE TABLE [content].[scriptableGeneralItems] (
    [scriptableGeneralId]             INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]                    VARCHAR (255)  NOT NULL,
    [generalItemMainTypeId]           TINYINT        NOT NULL,
    [generalItemClassificationTypeId] TINYINT        NOT NULL,
    [generalItemSubTypeId]            TINYINT        NOT NULL,
    [generalItemDescription]          VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D5464F0A4E] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableGeneralItems_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableGeneralItems_generalItemTypes_generalItemTypeId_fk] FOREIGN KEY ([generalItemMainTypeId]) REFERENCES [content].[generalItemTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D53E79E04C] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

