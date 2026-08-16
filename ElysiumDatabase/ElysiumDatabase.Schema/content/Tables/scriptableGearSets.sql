CREATE TABLE [content].[scriptableGearSets] (
    [totalPieces]         TINYINT       NOT NULL,
    [gearSetGlobalObject] VARCHAR (255) NOT NULL,
    [globalObjectName]    AS            ([dbo].[getGlobalObjectName]([gearSetGlobalObject])),
    PRIMARY KEY CLUSTERED ([gearSetGlobalObject] ASC),
    CONSTRAINT [FK_scriptableGearSets_globalObjects] FOREIGN KEY ([gearSetGlobalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

