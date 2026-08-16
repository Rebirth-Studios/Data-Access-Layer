CREATE TABLE [content].[equipmentRequirementGroups] (
    [equipmentRequirementGroupId]     INT            IDENTITY (1, 1) NOT NULL,
    [requiredAttributeId]             INT            NOT NULL,
    [equipmentRequirementDescription] VARCHAR (1000) NOT NULL,
    [equipmentRequirementId]          INT            NULL,
    CONSTRAINT [PK_itemRequirementGroups] PRIMARY KEY CLUSTERED ([equipmentRequirementGroupId] ASC)
);


GO

