CREATE TABLE [ops].[_configDetailsTypeLevels] (
    [sqlTableName]                   VARCHAR (100) NOT NULL,
    [sqlTableNameId]                 SMALLINT      NOT NULL,
    [upperType]                      VARCHAR (100) NOT NULL,
    [upperTypePropertyName]          VARCHAR (100) NOT NULL,
    [upperTypeControlName]           VARCHAR (100) NOT NULL,
    [mainType]                       VARCHAR (100) NOT NULL,
    [mainTypePropertyName]           VARCHAR (100) NOT NULL,
    [mainTypeControlName]            VARCHAR (100) NOT NULL,
    [classificationType]             VARCHAR (100) NOT NULL,
    [classificationTypePropertyName] VARCHAR (100) NOT NULL,
    [classificationTypeControlName]  VARCHAR (100) NOT NULL,
    [subType]                        VARCHAR (100) NOT NULL,
    [subTypePropertyName]            VARCHAR (100) NOT NULL,
    [subTypeControlName]             VARCHAR (100) NOT NULL
);


GO

