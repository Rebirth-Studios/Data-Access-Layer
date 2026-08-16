CREATE TABLE [content].[scriptableObjects] (
    [globalObject]           VARCHAR (255) NOT NULL,
    [scriptableObjectTypeId] TINYINT       NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D5CCE42A42] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableObjects_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_scriptableObjects_scriptableObjectTypes] FOREIGN KEY ([scriptableObjectTypeId]) REFERENCES [content].[scriptableObjectTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5A25C5E1B] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

