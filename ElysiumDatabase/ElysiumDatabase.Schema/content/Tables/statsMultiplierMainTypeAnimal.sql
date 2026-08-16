CREATE TABLE [content].[statsMultiplierMainTypeAnimal] (
    [id]         SMALLINT       IDENTITY (0, 1) NOT NULL,
    [mainTypeId] TINYINT        NOT NULL,
    [statId]     TINYINT        NOT NULL,
    [statTypeId] TINYINT        NOT NULL,
    [multiplier] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_statsBaseAnimalMainTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

