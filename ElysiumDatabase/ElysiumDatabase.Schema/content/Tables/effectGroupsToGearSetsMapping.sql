CREATE TABLE [content].[effectGroupsToGearSetsMapping] (
    [effectGroupsToArmorSetsMappingId] INT           IDENTITY (1, 1) NOT NULL,
    [gearSetGlobalObject]              VARCHAR (255) NOT NULL,
    [pieces]                           TINYINT       NOT NULL,
    [effectGroupGlobalObject]          VARCHAR (255) NOT NULL,
    [toolTipText]                      VARCHAR (255) NOT NULL,
    [scriptableObjectLevel]            VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_[effectGroupsToArmorSetsMapping] PRIMARY KEY CLUSTERED ([effectGroupsToArmorSetsMappingId] ASC),
    CONSTRAINT [effectGroupsToArmorSetsMapping_effectGroups_effectGroupGlobalObjectCode_fk] FOREIGN KEY ([effectGroupGlobalObject]) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject]),
    CONSTRAINT [effectGroupsToGearSetsMapping_scriptableGearSets_gearSetGlobalObject_fk] FOREIGN KEY ([gearSetGlobalObject]) REFERENCES [content].[scriptableGearSets] ([gearSetGlobalObject]),
    CONSTRAINT [FK_effectGroupsToGearSetsMapping_effectGroupsLevels] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[effectGroupsLevels] ([scriptableObjectLevel])
);


GO

