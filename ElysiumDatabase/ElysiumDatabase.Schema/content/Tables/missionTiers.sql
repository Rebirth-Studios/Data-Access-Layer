CREATE TABLE [content].[missionTiers] (
    [missionTierId]          TINYINT       NOT NULL,
    [missionTier]            VARCHAR (255) NOT NULL,
    [missionTierName]        VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [PK_missionTiers] PRIMARY KEY CLUSTERED ([missionTierId] ASC)
);


GO

