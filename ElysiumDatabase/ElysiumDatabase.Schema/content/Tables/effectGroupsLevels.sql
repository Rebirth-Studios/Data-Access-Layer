CREATE TABLE [content].[effectGroupsLevels] (
    [effectGroupsLevelsId]    SMALLINT      IDENTITY (1, 1) NOT NULL,
    [effectGroupGlobalObject] VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]   VARCHAR (255) NOT NULL,
    [levelId]                 TINYINT       NOT NULL,
    CONSTRAINT [PK_effectGroupsLevels] PRIMARY KEY CLUSTERED ([effectGroupsLevelsId] ASC),
    CONSTRAINT [FK_effectGroupsLevels_effectGroups] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject]),
    CONSTRAINT [FK_effectGroupsLevels_scriptableObjectLevels] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [Unique_effectGroupGlobalObject_scriptableObjectLevel] UNIQUE NONCLUSTERED ([effectGroupGlobalObject] ASC, [scriptableObjectLevel] ASC),
    CONSTRAINT [Unique_scriptableObjectLevel] UNIQUE NONCLUSTERED ([scriptableObjectLevel] ASC)
);


GO

