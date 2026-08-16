CREATE TABLE [ops].[_configNamesGridViews] (
    [gridViewId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [gridView]     VARCHAR (100) NOT NULL,
    [gridViewName] VARCHAR (100) NOT NULL,
    [description]  VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesGridViews] PRIMARY KEY CLUSTERED ([gridViewId] ASC)
);


GO

