CREATE TABLE [content].[scriptableMilestones] (
    [scriptableMilestonesId]     INT           IDENTITY (1, 1) NOT NULL,
    [milestoneRequiredTotal]     INT           NULL,
    [milestoneGlobalObject]      VARCHAR (255) NOT NULL,
    [milestoneTotalGlobalObject] VARCHAR (255) NOT NULL,
    [globalObjectName]           AS            ([dbo].[getGlobalObjectName]([milestoneGlobalObject])),
    [milestoneTotalName]         AS            ([dbo].[getGlobalObjectName]([milestoneTotalGlobalObject])),
    PRIMARY KEY CLUSTERED ([milestoneGlobalObject] ASC),
    CONSTRAINT [scriptableMilestones_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([milestoneGlobalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableMilestones_scriptableTotals_totalGlobalObjectCode_fk] FOREIGN KEY ([milestoneTotalGlobalObject]) REFERENCES [content].[scriptableTotals] ([totalGlobalObject]),
    UNIQUE NONCLUSTERED ([milestoneGlobalObject] ASC)
);


GO

