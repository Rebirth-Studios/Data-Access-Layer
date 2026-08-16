CREATE TABLE [content].[qualityBonus] (
    [qualityId]    INT             NOT NULL,
    [quality]      VARCHAR (255)   NOT NULL,
    [qualityBonus] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_qualityBonus] PRIMARY KEY CLUSTERED ([qualityId] ASC)
);


GO

