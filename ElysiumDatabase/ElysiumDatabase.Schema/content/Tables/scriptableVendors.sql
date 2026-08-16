CREATE TABLE [content].[scriptableVendors] (
    [restockInterval]  INT           NOT NULL,
    [globalObject]     VARCHAR (255) NOT NULL,
    [globalObjectName] AS            ([dbo].[getGlobalObjectName]([globalObject])),
    PRIMARY KEY CLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableVendors_scriptableNPCS_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableNPCS] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

