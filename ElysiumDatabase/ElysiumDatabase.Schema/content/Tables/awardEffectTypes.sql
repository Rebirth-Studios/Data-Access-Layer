CREATE TABLE [content].[awardEffectTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    [defaultValue]           VARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_awardTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

