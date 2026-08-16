CREATE TABLE [content].[missionStatus] (
    [missionStatusId] TINYINT       NOT NULL,
    [missionStatus]   VARCHAR (255) NOT NULL,
    [description]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_missionStatus] PRIMARY KEY CLUSTERED ([missionStatusId] ASC)
);


GO

