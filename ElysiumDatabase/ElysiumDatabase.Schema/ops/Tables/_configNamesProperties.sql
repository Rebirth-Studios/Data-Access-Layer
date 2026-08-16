CREATE TABLE [ops].[_configNamesProperties] (
    [propertyId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [property]     VARCHAR (100) NOT NULL,
    [propertyName] VARCHAR (100) NOT NULL,
    [description]  VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesProperties] PRIMARY KEY CLUSTERED ([propertyId] ASC),
    UNIQUE NONCLUSTERED ([property] ASC)
);


GO

