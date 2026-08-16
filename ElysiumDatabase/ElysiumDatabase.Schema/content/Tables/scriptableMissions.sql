CREATE TABLE [content].[scriptableMissions] (
    [missionGlobalObjectCode]             VARCHAR (255)  NOT NULL,
    [missionlineGlobalObjectCode]         VARCHAR (255)  NOT NULL,
    [missionCategoryTypeId]               TINYINT        NOT NULL,
    [missionTypeId]                       TINYINT        NOT NULL,
    [missionTierId]                       TINYINT        NOT NULL,
    [missionMainTierId]                   TINYINT        NOT NULL,
    [tierAvailableId]                     TINYINT        NOT NULL,
    [guaranteedLootTableGlobalObjectCode] VARCHAR (255)  NOT NULL,
    [optionalLootTableGlobalObjectCode]   VARCHAR (255)  NOT NULL,
    [npcGlobalObjectCode]                 VARCHAR (255)  NOT NULL,
    [missionStatusId]                     TINYINT        NOT NULL,
    [missionText]                         VARCHAR (1000) NOT NULL,
    [shareable]                           BIT            NOT NULL,
    [scriptableMissionId]                 INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_scriptableMissions] PRIMARY KEY CLUSTERED ([missionGlobalObjectCode] ASC)
);


GO

