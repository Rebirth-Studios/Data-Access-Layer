CREATE TABLE [content].[statsMultiplierSubTypeAnimal] (
    [id]         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [subTypeId]  TINYINT        NOT NULL,
    [statId]     TINYINT        NOT NULL,
    [statTypeId] TINYINT        NOT NULL,
    [multiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseAnimalSubTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

