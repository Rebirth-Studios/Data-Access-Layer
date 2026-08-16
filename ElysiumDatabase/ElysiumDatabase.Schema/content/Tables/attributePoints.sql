CREATE TABLE [content].[attributePoints] (
    [attributePointsId]    INT     NOT NULL,
    [tierId]               TINYINT NOT NULL,
    [rankId]               TINYINT NOT NULL,
    [attributePointsValue] TINYINT NOT NULL,
    CONSTRAINT [PK_attributePoints] PRIMARY KEY CLUSTERED ([attributePointsId] ASC)
);


GO

