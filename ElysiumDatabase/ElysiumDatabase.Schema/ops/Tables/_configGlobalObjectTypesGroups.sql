CREATE TABLE [ops].[_configGlobalObjectTypesGroups] (
    [id]                   TINYINT       IDENTITY (1, 1) NOT NULL,
    [globalObjectType]     VARCHAR (100) NOT NULL,
    [globalObjectSubType]  VARCHAR (100) NOT NULL,
    [scriptableObjectType] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__configGlobalObjectTypesGroups] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

