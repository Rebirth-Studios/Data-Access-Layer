CREATE TABLE [content].[equipmentSlotTypes] (
    [typeId]                 TINYINT       NOT NULL,
    [type]                   VARCHAR (255) NOT NULL,
    [typeName]               VARCHAR (50)  NOT NULL,
    [description]            VARCHAR (255) NOT NULL,
    [parentTypeId]           TINYINT       NOT NULL,
    [childEnum]              VARCHAR (50)  NOT NULL,
    [globalObjectNamingType] SMALLINT      NOT NULL,
    [parentEnum]             VARCHAR (50)  NOT NULL,
    CONSTRAINT [equipmentLocations_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'- Used to Track which slot each type of equipment goes.', @level0type = N'SCHEMA', @level0name = N'content', @level1type = N'TABLE', @level1name = N'equipmentSlotTypes';


GO

