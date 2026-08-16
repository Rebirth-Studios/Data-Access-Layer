CREATE TABLE [content].[statEffects] (
    [statEffectId]           INT             IDENTITY (1, 1) NOT NULL,
    [statEffectGlobalObject] VARCHAR (255)   NOT NULL,
    [statId]                 TINYINT         NOT NULL,
    [statTypeId]             TINYINT         NOT NULL,
    [statEffectAmount]       DECIMAL (18, 1) NOT NULL,
    [statEffectAmountTypeId] TINYINT         NOT NULL,
    CONSTRAINT [PK_statusEffects] PRIMARY KEY CLUSTERED ([statEffectId] ASC),
    CONSTRAINT [FK_statEffects_effects] FOREIGN KEY ([statEffectGlobalObject]) REFERENCES [content].[effects] ([globalObject]),
    CONSTRAINT [UQ__statEffe__C6BE644DE37E293E] UNIQUE NONCLUSTERED ([statEffectGlobalObject] ASC)
);


GO

