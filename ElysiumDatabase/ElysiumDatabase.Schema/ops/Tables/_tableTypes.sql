CREATE TABLE [ops].[_tableTypes] (
    [tableTypeId]            TINYINT       IDENTITY (0, 1) NOT NULL,
    [tableType]              VARCHAR (100) NOT NULL,
    [tableTypeName]          VARCHAR (100) NOT NULL,
    [description]            VARCHAR (255) NULL,
    [parentEnum]             VARCHAR (50)  NULL,
    [parentTypeId]           TINYINT       NULL,
    [childEnum]              VARCHAR (50)  NULL,
    [globalObjectNamingType] SMALLINT      NULL,
    CONSTRAINT [PK__sheetTypes] PRIMARY KEY CLUSTERED ([tableTypeId] ASC),
    CONSTRAINT [UQ___tableTy__DAED0F92BE3EAB91] UNIQUE NONCLUSTERED ([tableTypeName] ASC)
);


GO

