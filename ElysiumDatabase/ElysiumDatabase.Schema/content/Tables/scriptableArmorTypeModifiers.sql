CREATE TABLE [content].[scriptableArmorTypeModifiers] (
    [scriptableArmorTypeModifierId] INT             IDENTITY (1, 1) NOT NULL,
    [armorTypeId]                   TINYINT         NOT NULL,
    [modifierTypeId]                TINYINT         NOT NULL,
    [modifierMultiplier]            DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_scriptableArmorTypeModifiers] PRIMARY KEY CLUSTERED ([scriptableArmorTypeModifierId] ASC),
    CONSTRAINT [scriptableArmorTypeModifiers_armorTypes_armorTypeId_fk] FOREIGN KEY ([armorTypeId]) REFERENCES [content].[armorTypes] ([typeId])
);


GO

