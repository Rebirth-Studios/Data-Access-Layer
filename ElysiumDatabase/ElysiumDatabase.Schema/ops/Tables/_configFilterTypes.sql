CREATE TABLE [ops].[_configFilterTypes] (
    [id]              SMALLINT      IDENTITY (0, 1) NOT NULL,
    [sourceTypeName]  VARCHAR (255) NOT NULL,
    [sourceType]      VARCHAR (255) NOT NULL,
    [matchTypeName]   VARCHAR (255) NOT NULL,
    [matchType]       VARCHAR (255) NOT NULL,
    [matchColumnName] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_filterTypes] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

