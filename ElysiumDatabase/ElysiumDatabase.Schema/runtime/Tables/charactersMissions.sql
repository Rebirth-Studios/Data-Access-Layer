CREATE TABLE [runtime].[charactersMissions] (
    [charactersMissionsId]    INT           IDENTITY (1, 1) NOT NULL,
    [characterId]             INT           NOT NULL,
    [missionGlobalObjectCode] VARCHAR (255) NOT NULL,
    [missionStatusId]         TINYINT       NOT NULL,
    CONSTRAINT [PK_charactersMissions] PRIMARY KEY CLUSTERED ([charactersMissionsId] ASC),
    CONSTRAINT [FK_charactersMissions_characters1] FOREIGN KEY ([characterId]) REFERENCES [runtime].[characters] ([characterId]),
    CONSTRAINT [FK_charactersMissions_MissionStatus] FOREIGN KEY ([missionStatusId]) REFERENCES [content].[missionStatus] ([missionStatusId]),
    CONSTRAINT [FK_charactersMissions_scriptableMissions] FOREIGN KEY ([missionGlobalObjectCode]) REFERENCES [content].[scriptableMissions] ([missionGlobalObjectCode])
);


GO

