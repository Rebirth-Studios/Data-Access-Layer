CREATE TABLE [content].[scriptableQualities] (
    [typeId]                 TINYINT         NOT NULL,
    [type]                   VARCHAR (255)   NULL,
    [typeName]               VARCHAR (255)   NOT NULL,
    [description]            VARCHAR (1000)  NOT NULL,
    [parentEnum]             VARCHAR (50)    NULL,
    [parentTypeId]           TINYINT         NULL,
    [childEnum]              VARCHAR (50)    NULL,
    [globalObjectNamingType] SMALLINT        NULL,
    [valueMultiplier]        DECIMAL (18, 2) NOT NULL,
    [IsImbued]               BIT             NULL,
    CONSTRAINT [PK_scriptableQualities] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

