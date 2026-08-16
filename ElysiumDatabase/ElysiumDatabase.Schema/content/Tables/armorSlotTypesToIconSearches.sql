CREATE TABLE [content].[armorSlotTypesToIconSearches] (
    [id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [type]         VARCHAR (100) NOT NULL,
    [iconSearchId] SMALLINT      NOT NULL,
    [iconSearch]   AS            ([dbo].[getIconSearchName]([iconSearchId])),
    CONSTRAINT [PK_armorSlotTypesToIconSearches] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

