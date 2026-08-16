CREATE TABLE [content].[scriptableLevelModifiers] (
    [id]                     SMALLINT       IDENTITY (0, 1) NOT NULL,
    [scriptableObjectTypeId] TINYINT        NOT NULL,
    [levelId]                TINYINT        NOT NULL,
    [modifierTypeId]         TINYINT        NOT NULL,
    [modifierMultiplier]     DECIMAL (5, 2) NOT NULL,
    [additional]             TINYINT        NOT NULL,
    CONSTRAINT [PK_scriptableLevelModifiers] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

