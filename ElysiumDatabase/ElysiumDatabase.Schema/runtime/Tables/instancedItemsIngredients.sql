CREATE TABLE [runtime].[instancedItemsIngredients] (
    [instancedItemId]        UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]             DATETIME         NOT NULL,
    [ingredientGlobalObject] VARCHAR (255)    NOT NULL,
    CONSTRAINT [instancedItemsIngredients_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([ingredientGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject])
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Used to track ingredients for instanced items to recalculate items stats dynamically', @level0type = N'SCHEMA', @level0name = N'runtime', @level1type = N'TABLE', @level1name = N'instancedItemsIngredients';


GO

