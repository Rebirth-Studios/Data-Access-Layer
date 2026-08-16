CREATE TABLE [ops].[_configNamesPanels] (
    [panelId]     SMALLINT      IDENTITY (1, 1) NOT NULL,
    [panel]       VARCHAR (100) NOT NULL,
    [panelName]   VARCHAR (100) NOT NULL,
    [description] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesPanels] PRIMARY KEY CLUSTERED ([panelId] ASC),
    UNIQUE NONCLUSTERED ([panel] ASC)
);


GO

