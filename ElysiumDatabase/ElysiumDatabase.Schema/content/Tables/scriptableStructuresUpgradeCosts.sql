CREATE TABLE [content].[scriptableStructuresUpgradeCosts] (
    [id]                         SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]               VARCHAR (255) NOT NULL,
    [objectRequiredGlobalObject] VARCHAR (255) NOT NULL,
    [amountRequired]             SMALLINT      NOT NULL,
    [globalObjectName]           AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [objectRequiredName]         AS            ([dbo].[getGlobalObjectName]([objectRequiredGlobalObject])),
    CONSTRAINT [PK_scriptableStructuresUpgradeCosts] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableStructuresUpgradeCosts_globalObjects] FOREIGN KEY ([objectRequiredGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_scriptableStructuresUpgradeCosts_scriptableStructures] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableStructures] ([globalObject])
);


GO

