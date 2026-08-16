CREATE TABLE [content].[attributePrimaryTypes] (
    [typeId]                 TINYINT        NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    CONSTRAINT [attributePrimaryTypes_pk] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [UQ__attribut__E3F852483B522943] UNIQUE NONCLUSTERED ([type] ASC)
);


GO

