CREATE TABLE [ops].[_updateTypes] (
    [updateTypeId]   TINYINT      IDENTITY (1, 1) NOT NULL,
    [updateType]     VARCHAR (50) NOT NULL,
    [updateTypeName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK__updateTypes] PRIMARY KEY CLUSTERED ([updateTypeId] ASC)
);


GO

