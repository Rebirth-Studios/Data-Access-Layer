CREATE TABLE [content].[skillRanks] (
    [typeId]                 INT            NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    [minLevel]               SMALLINT       NOT NULL,
    [maxLevel]               SMALLINT       NOT NULL,
    CONSTRAINT [PK_skillTiers] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

