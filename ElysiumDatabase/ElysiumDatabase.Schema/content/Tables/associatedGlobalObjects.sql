CREATE TABLE [content].[associatedGlobalObjects] (
    [id]                         SMALLINT      IDENTITY (1, 1) NOT NULL,
    [mainGameObjectTypeId]       TINYINT       NOT NULL,
    [globalObject]               VARCHAR (255) NOT NULL,
    [associatedGameObjectTypeId] TINYINT       NOT NULL,
    [associatedGlobalObject]     VARCHAR (255) NOT NULL,
    [keyNumber]                  TINYINT       NOT NULL,
    CONSTRAINT [PK_associatedGlobalObjects] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [associatedGlobalObjects_globalObjects_globalObject] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [FK_associatedGlobalObjects_globalObjects] FOREIGN KEY ([associatedGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

