CREATE TABLE [content].[globalFactions] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (100)  NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NULL,
    [parentTypeId]           TINYINT        NULL,
    [childEnum]              VARCHAR (50)   NULL,
    [globalObjectNamingType] SMALLINT       NULL,
    CONSTRAINT [globalFactions_pk] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalFactions_factionId_uindex]
    ON [content].[globalFactions]([typeId] ASC);


GO

