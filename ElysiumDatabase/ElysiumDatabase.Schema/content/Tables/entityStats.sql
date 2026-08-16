CREATE TABLE [content].[entityStats] (
    [globalObject]              VARCHAR (255)   NOT NULL,
    [scriptableObjectSpawnable] VARCHAR (255)   NOT NULL,
    [statId]                    TINYINT         NOT NULL,
    [statTypeId]                TINYINT         NOT NULL,
    [statInitialValue]          DECIMAL (18, 2) NOT NULL,
    [isCustom]                  BIT             NOT NULL,
    [levelId]                   TINYINT         NOT NULL,
    CONSTRAINT [entityStats_scriptableEntities_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableEntities] ([globalObject]),
    CONSTRAINT [FK__entitySta__scrip__71F66955] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [UQ_entityStats_scriptableObjectSpawnable_statTypeId_statId] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC, [statTypeId] ASC, [statId] ASC)
);


GO

CREATE NONCLUSTERED INDEX [_dta_index_entityStats_5_1879974115__K1_K3_K4_K2_5_6]
    ON [content].[entityStats]([globalObject] ASC, [statId] ASC, [statTypeId] ASC, [scriptableObjectSpawnable] ASC)
    INCLUDE([statInitialValue], [isCustom]);


GO

CREATE CLUSTERED INDEX [IX_entityStats]
    ON [content].[entityStats]([globalObject] ASC);


GO

