CREATE TABLE [content].[missionMainTiers] (
    [missionMainTierId]      TINYINT       NOT NULL,
    [missionMainTier]        VARCHAR (255) NOT NULL,
    [missionMainTierName]    VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentEnum]             VARCHAR (100) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    CONSTRAINT [PK_missionSubTiers] PRIMARY KEY CLUSTERED ([missionMainTierId] ASC)
);


GO

