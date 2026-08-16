CREATE TABLE [content].[scriptableBags] (
    [globalObject]            VARCHAR (255)  NOT NULL,
    [bagMainTypeId]           TINYINT        NOT NULL,
    [bagClassificationTypeId] TINYINT        NOT NULL,
    [bagSubTypeId]            TINYINT        NOT NULL,
    [slots]                   TINYINT        NOT NULL,
    [description]             VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D40BBCF5E3] PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableBags_bagTypes_bagTypeId_fk] FOREIGN KEY ([bagMainTypeId]) REFERENCES [content].[bagTypes] ([typeId]),
    CONSTRAINT [scriptableBags_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5F7369D80] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

