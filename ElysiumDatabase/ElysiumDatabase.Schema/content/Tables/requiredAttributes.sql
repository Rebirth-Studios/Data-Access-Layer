CREATE TABLE [content].[requiredAttributes] (
    [requiredAttributeId]          INT            NOT NULL,
    [requiredAttribute]            VARCHAR (255)  NOT NULL,
    [statId]                       INT            NOT NULL,
    [statTypeId]                   INT            NOT NULL,
    [requiredAttributeAmount]      INT            NULL,
    [requiredAttributeDescription] VARCHAR (1000) NULL,
    CONSTRAINT [PK_itemRequirementAttributes] PRIMARY KEY CLUSTERED ([requiredAttributeId] ASC)
);


GO

