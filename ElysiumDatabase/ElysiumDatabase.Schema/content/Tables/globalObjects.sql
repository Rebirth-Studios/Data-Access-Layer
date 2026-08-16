CREATE TABLE [content].[globalObjects] (
    [globalObjectCode]       VARCHAR (255) NOT NULL,
    [globalObject]           VARCHAR (255) NOT NULL,
    [globalObjectName]       VARCHAR (255) NOT NULL,
    [globalObjectNamePlural] VARCHAR (255) NOT NULL,
    [globalObjectTypeId]     TINYINT       NOT NULL,
    [globalObjectSubTypeId]  TINYINT       NOT NULL,
    [scriptableObjectTypeId] TINYINT       NOT NULL,
    [globalTierId]           TINYINT       NOT NULL,
    [statusId]               TINYINT       NOT NULL,
    [specialEventTypeId]     TINYINT       NOT NULL,
    [globalSubTierId]        TINYINT       NOT NULL,
    [customName]             BIT           NOT NULL,
    CONSTRAINT [PK_globalObjects] PRIMARY KEY CLUSTERED ([globalObjectCode] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalObjects_globalObject_uindex]
    ON [content].[globalObjects]([globalObject] ASC);


GO

CREATE NONCLUSTERED INDEX [_dta_index_globalObjects_5_1330103779__K2_K1_K8_3]
    ON [content].[globalObjects]([globalObject] ASC, [globalObjectCode] ASC, [globalTierId] ASC)
    INCLUDE([globalObjectName]);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalObjects_globalObjectNamePlural_uindex]
    ON [content].[globalObjects]([globalObjectNamePlural] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [globalObjects_globalObjectName_uindex]
    ON [content].[globalObjects]([globalObjectName] ASC);


GO

CREATE STATISTICS [_dta_stat_508629742_8_2]
    ON [content].[globalObjects]([globalTierId], [globalObject]);


GO

