CREATE TABLE [content].[killTypes] (
    [typeId]                 INT            NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [PK_killTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Possible Kill Types for Party States', @level0type = N'SCHEMA', @level0name = N'content', @level1type = N'TABLE', @level1name = N'killTypes';


GO

EXECUTE sp_addextendedproperty @name = N'description', @value = N'Stored Possible Kill Types for Party State', @level0type = N'SCHEMA', @level0name = N'content', @level1type = N'TABLE', @level1name = N'killTypes';


GO

