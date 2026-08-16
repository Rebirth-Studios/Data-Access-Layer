CREATE TABLE [content].[equipmentBase] (
    [id]                SMALLINT      IDENTITY (0, 1) NOT NULL,
    [equipmentBase]     VARCHAR (100) NOT NULL,
    [equipmentBaseName] VARCHAR (100) NOT NULL,
    [equipmentTypeId]   TINYINT       NOT NULL,
    [equipmentSkill]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_equipmentBase] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [equipmentBase_equipmentType_equipmentTypeId_fk] FOREIGN KEY ([equipmentTypeId]) REFERENCES [content].[equipmentTypes] ([typeId]),
    UNIQUE NONCLUSTERED ([equipmentBase] ASC)
);


GO

