CREATE TABLE [content].[scriptableItemRarities] (
    [id]           SMALLINT       IDENTITY (0, 1) NOT NULL,
    [globalObject] VARCHAR (255)  NOT NULL,
    [rarityId]     TINYINT        NOT NULL,
    [description]  VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_scriptableItemRarities] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableItemRarities_scriptableItemRarities] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [UK_GlobalObject_RarityId] UNIQUE NONCLUSTERED ([globalObject] ASC, [rarityId] ASC)
);


GO

