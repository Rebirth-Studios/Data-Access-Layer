CREATE TABLE [ops].[_configNamesListViewRows] (
    [listViewRowId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [listViewRow]     VARCHAR (100) NOT NULL,
    [listViewRowName] VARCHAR (100) NOT NULL,
    [description]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesListViewRows] PRIMARY KEY CLUSTERED ([listViewRowId] ASC),
    UNIQUE NONCLUSTERED ([listViewRow] ASC)
);


GO

