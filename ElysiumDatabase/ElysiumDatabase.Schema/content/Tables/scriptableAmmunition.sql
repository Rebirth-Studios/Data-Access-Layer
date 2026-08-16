CREATE TABLE [content].[scriptableAmmunition] (
    [globalObject]                   VARCHAR (255)  NOT NULL,
    [ammunitionMainTypeId]           TINYINT        NOT NULL,
    [ammunitionClassificationTypeId] TINYINT        NOT NULL,
    [ammunitionSubTypeId]            TINYINT        NOT NULL,
    [description]                    VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D4BA94E895] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableAmmunition_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D50A7C2BEA] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

