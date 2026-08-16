CREATE TABLE [ops].[_configNamesListViews] (
    [listViewId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [listView]     VARCHAR (100) NOT NULL,
    [listViewName] VARCHAR (100) NOT NULL,
    [description]  VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesListViews] PRIMARY KEY CLUSTERED ([listViewId] ASC),
    UNIQUE NONCLUSTERED ([listView] ASC)
);


GO

