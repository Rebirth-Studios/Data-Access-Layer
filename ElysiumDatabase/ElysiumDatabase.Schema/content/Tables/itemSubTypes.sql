CREATE TABLE [content].[itemSubTypes] (
    [typeId]                TINYINT       NOT NULL,
    [type]                  VARCHAR (255) NOT NULL,
    [typeName]              VARCHAR (255) NOT NULL,
    [itemSubTypeNamePlural] VARCHAR (255) NOT NULL,
    [itemTypeId]            TINYINT       NULL,
    CONSTRAINT [PK_itemSubTypes] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

