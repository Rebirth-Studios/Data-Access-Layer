CREATE TABLE [content].[scriptableItemEffects] (
    [id]                 INT            IDENTITY (0, 1) NOT NULL,
    [globalObject]       VARCHAR (255)  NOT NULL,
    [rarityId]           TINYINT        NOT NULL,
    [effectGlobalObject] VARCHAR (255)  NOT NULL,
    [description]        VARCHAR (1000) NOT NULL,
    [levelId]            TINYINT        NOT NULL,
    CONSTRAINT [PK__scriptableItemEffects] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_scriptableItemEffects_effects] FOREIGN KEY ([effectGlobalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [FK_scriptableItemEffects_scriptableItemRarities] FOREIGN KEY ([globalObject], [rarityId]) REFERENCES [content].[scriptableItemRarities] ([globalObject], [rarityId])
);


GO

