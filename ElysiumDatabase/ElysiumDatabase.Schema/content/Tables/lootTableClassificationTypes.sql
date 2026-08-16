CREATE TABLE [content].[lootTableClassificationTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [lootTableSubTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [lootTableSubTypes_lootTableTypes_lootTableTypeId_fk] FOREIGN KEY ([parentTypeId]) REFERENCES [content].[lootTableTypes] ([typeId])
);


GO

