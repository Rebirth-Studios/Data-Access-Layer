CREATE TABLE [content].[scriptableObjectRarities] (
    [id]           SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject] VARCHAR (255) NOT NULL,
    [rarityId]     TINYINT       NOT NULL,
    CONSTRAINT [PK_scriptableObjectRarities] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableObjectRarities_scriptableObjectRarities] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject])
);


GO

