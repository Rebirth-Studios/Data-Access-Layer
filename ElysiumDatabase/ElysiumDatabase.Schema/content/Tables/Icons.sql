CREATE TABLE [content].[Icons] (
    [iconId]       INT           IDENTITY (1, 1) NOT NULL,
    [rarityId]     TINYINT       NOT NULL,
    [globalObject] VARCHAR (255) NOT NULL,
    [iconName]     VARCHAR (255) NOT NULL,
    CONSTRAINT [FK_Icons_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    CONSTRAINT [Icons_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [Icons_globalObjectCode_rarityId_uindex]
    ON [content].[Icons]([globalObject] ASC, [rarityId] ASC);


GO

