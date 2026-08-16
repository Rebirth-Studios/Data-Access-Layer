CREATE TABLE [content].[effects] (
    [globalObject]     VARCHAR (255) NOT NULL,
    [effectTypeId]     TINYINT       NOT NULL,
    [effectType]       AS            ([dbo].[getEffectType]([effectTypeId])),
    [globalObjectName] AS            ([dbo].[getGlobalObjectName]([globalObject])),
    CONSTRAINT [effects_effectTypes_effectTypeId_fk] FOREIGN KEY ([effectTypeId]) REFERENCES [content].[effectTypes] ([typeId]),
    CONSTRAINT [FK_effects_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

