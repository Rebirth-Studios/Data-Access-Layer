CREATE TYPE [dbo].[tmprecipeIngredients] AS TABLE (
    [globalObjectName]           VARCHAR (255) NOT NULL,
    [globalObjectCode]           VARCHAR (255) NOT NULL,
    [ingredientSlotId]           INT           NOT NULL,
    [ingredientName]             VARCHAR (255) NOT NULL,
    [ingredientGlobalObjectCode] VARCHAR (255) NOT NULL,
    [ingredientWeight]           INT           NOT NULL,
    [quantity]                   INT           NOT NULL);


GO

