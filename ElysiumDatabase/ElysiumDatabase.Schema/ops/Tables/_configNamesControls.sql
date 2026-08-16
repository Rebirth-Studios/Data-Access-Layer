CREATE TABLE [ops].[_configNamesControls] (
    [controlId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [control]     VARCHAR (100) NOT NULL,
    [controlName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__configNamesControls] PRIMARY KEY CLUSTERED ([controlId] ASC),
    UNIQUE NONCLUSTERED ([control] ASC),
    UNIQUE NONCLUSTERED ([controlName] ASC)
);


GO

