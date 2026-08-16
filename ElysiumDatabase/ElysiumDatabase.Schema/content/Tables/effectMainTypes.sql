CREATE TABLE [content].[effectMainTypes] (
    [typeId]                 INT            NOT NULL,
    [type]                   VARCHAR (255)  NOT NULL,
    [typeName]               VARCHAR (255)  NOT NULL,
    [description]            VARCHAR (1000) NOT NULL,
    [parentEnum]             VARCHAR (50)   NOT NULL,
    [effectTypeId]           TINYINT        NOT NULL,
    [childEnum]              VARCHAR (50)   NOT NULL,
    [globalObjectNamingType] SMALLINT       NOT NULL,
    [parentTypeId]           TINYINT        NOT NULL,
    CONSTRAINT [PK_effectSubTypes] PRIMARY KEY CLUSTERED ([typeId] ASC),
    CONSTRAINT [effectSubTypes_effectTypes_effectTypeId_fk] FOREIGN KEY ([effectTypeId]) REFERENCES [content].[effectTypes] ([typeId])
);


GO

