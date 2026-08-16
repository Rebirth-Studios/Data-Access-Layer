CREATE TABLE [content].[scriptableConsumables] (
    [globalObject]                   VARCHAR (255)  NOT NULL,
    [consumableMainTypeId]           TINYINT        NOT NULL,
    [consumableClassificationTypeId] TINYINT        NOT NULL,
    [consumableSubTypeId]            TINYINT        NOT NULL,
    [description]                    VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D4AABA0AC7] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableConsumables_consumableSubTypes_consumableSubTypeId_fk] FOREIGN KEY ([consumableSubTypeId]) REFERENCES [content].[consumableSubTypes] ([typeId]),
    CONSTRAINT [scriptableConsumables_consumableTypes_consumableTypeId_fk] FOREIGN KEY ([consumableMainTypeId]) REFERENCES [content].[consumableTypes] ([typeId]),
    CONSTRAINT [scriptableConsumables_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D56D8A21CB] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

