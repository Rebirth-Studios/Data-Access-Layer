CREATE TABLE [ops].[_configSortFields] (
    [sortFieldId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [sortField]     VARCHAR (100) NOT NULL,
    [sortFieldName] VARCHAR (100) NOT NULL,
    [description]   VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configSortFields] PRIMARY KEY CLUSTERED ([sortFieldId] ASC)
);


GO

