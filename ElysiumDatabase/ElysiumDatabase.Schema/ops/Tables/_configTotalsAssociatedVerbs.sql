CREATE TABLE [ops].[_configTotalsAssociatedVerbs] (
    [id]                      SMALLINT      IDENTITY (1, 1) NOT NULL,
    [verb]                    VARCHAR (100) NOT NULL,
    [totalType]               VARCHAR (100) NOT NULL,
    [totalTypeValue]          VARCHAR (100) NOT NULL,
    [upperType]               VARCHAR (100) NOT NULL,
    [upperTypeValue]          VARCHAR (100) NOT NULL,
    [mainType]                VARCHAR (100) NOT NULL,
    [mainTypeValue]           VARCHAR (100) NOT NULL,
    [classificationType]      VARCHAR (100) NOT NULL,
    [classificationTypeValue] VARCHAR (100) NOT NULL,
    [subType]                 VARCHAR (100) NOT NULL,
    [subTypeValue]            VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__configTotalsAssociatedVerbs] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

