CREATE TABLE [content].[scriptableMaterials] (
    [globalObject]                 VARCHAR (255)  NOT NULL,
    [materialDifficultyPoints]     INT            NOT NULL,
    [ingredientName]               VARCHAR (255)  NOT NULL,
    [materialMainTypeId]           TINYINT        NOT NULL,
    [materialClassificationTypeId] TINYINT        NOT NULL,
    [materialSubTypeId]            TINYINT        NOT NULL,
    [craftingMaterialTypeId]       SMALLINT       NULL,
    [description]                  VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D51C015312] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    FOREIGN KEY ([craftingMaterialTypeId]) REFERENCES [content].[craftingMaterialTypes] ([typeId]),
    CONSTRAINT [scriptableMaterials_materialSubTypes_materialSubTypeId_fk] FOREIGN KEY ([materialSubTypeId]) REFERENCES [content].[materialSubTypes] ([typeId]),
    CONSTRAINT [scriptableMaterials_materialTypes_materialTypeId_fk] FOREIGN KEY ([materialMainTypeId]) REFERENCES [content].[materialTypes] ([typeId]),
    CONSTRAINT [scriptableMaterials_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5AB532D5FD9A8AE3] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

