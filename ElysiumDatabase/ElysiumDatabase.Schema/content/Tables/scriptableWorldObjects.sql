CREATE TABLE [content].[scriptableWorldObjects] (
    [scriptableWorldObjectId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]            VARCHAR (255) NOT NULL,
    [worldObjectTypeId]       TINYINT       NOT NULL,
    [isImmortal]              BIT           NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D5048A8EEE] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableWorldObjects_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableWorldObjects_worldObjectTypes_worldObjectTypeId_fk] FOREIGN KEY ([worldObjectTypeId]) REFERENCES [content].[worldObjectTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D57E7B15BB] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [scriptableWorldObjects_scriptableWorldObjectId_uindex]
    ON [content].[scriptableWorldObjects]([scriptableWorldObjectId] ASC);


GO

