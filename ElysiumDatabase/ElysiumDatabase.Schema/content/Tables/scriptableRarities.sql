CREATE TABLE [content].[scriptableRarities] (
    [typeId]                 TINYINT         NOT NULL,
    [type]                   VARCHAR (255)   NOT NULL,
    [typeName]               VARCHAR (255)   NOT NULL,
    [description]            VARCHAR (1000)  NOT NULL,
    [parentEnum]             VARCHAR (50)    NULL,
    [parentTypeId]           TINYINT         NULL,
    [childEnum]              VARCHAR (50)    NULL,
    [globalObjectNamingType] SMALLINT        NULL,
    [valueMultiplier]        DECIMAL (18, 2) NOT NULL,
    [rarityColor]            VARCHAR (255)   NOT NULL,
    [colorName]              VARCHAR (100)   NULL,
    CONSTRAINT [PK_scriptableRarities] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

