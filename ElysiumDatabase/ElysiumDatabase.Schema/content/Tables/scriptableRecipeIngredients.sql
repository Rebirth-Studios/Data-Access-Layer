CREATE TABLE [content].[scriptableRecipeIngredients] (
    [recipeIngredientId]     INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]           VARCHAR (255) NOT NULL,
    [ingredientGlobalObject] VARCHAR (255) NOT NULL,
    [ingredientSlotId]       TINYINT       NOT NULL,
    [primaryIngredient]      BIT           NOT NULL,
    [ingredientWeight]       TINYINT       NOT NULL,
    [quantity]               TINYINT       NOT NULL,
    [globalObjectName]       AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [ingredientName]         AS            ([dbo].[getGlobalObjectName]([ingredientGlobalObject])),
    CONSTRAINT [PK_recipeIngredients] PRIMARY KEY CLUSTERED ([recipeIngredientId] ASC),
    CONSTRAINT [scriptableRecipeIngredients_scriptableItems_globalObjectCode_fk] FOREIGN KEY ([ingredientGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableRecipeIngredients_scriptableRecipes_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableRecipes] ([globalObject]),
    CONSTRAINT [scriptableRecipeIngredients_globalObject_ingredientGlobalObject] UNIQUE NONCLUSTERED ([globalObject] ASC, [ingredientGlobalObject] ASC)
);


GO

