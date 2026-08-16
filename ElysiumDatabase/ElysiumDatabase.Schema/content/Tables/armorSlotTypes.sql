CREATE TABLE [content].[armorSlotTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NULL,
    [description]            VARCHAR (255)  NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    [armorPenaltyPercentage] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [armorSlotTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

