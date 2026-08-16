CREATE TYPE [dbo].[tmpRestorerecipeIngredients] AS TABLE (
    [recipeIngredientId]         INT           NOT NULL,
    [globalObjectCode]           VARCHAR (255) NOT NULL,
    [ingredientSlotId]           INT           NOT NULL,
    [globalObjectName]           VARCHAR (255) NOT NULL,
    [ingredientGlobalObjectCode] VARCHAR (255) NOT NULL,
    [ingredientName]             VARCHAR (255) NOT NULL,
    [ingredientWeight]           INT           NOT NULL,
    [quantity]                   INT           NOT NULL);


GO

