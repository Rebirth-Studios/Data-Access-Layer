CREATE TABLE [content].[typeLevels] (
    [typeId]      TINYINT        NOT NULL,
    [type]        VARCHAR (255)  NOT NULL,
    [typeName]    VARCHAR (255)  NULL,
    [description] VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_typeLevels] PRIMARY KEY CLUSTERED ([typeId] ASC)
);


GO

