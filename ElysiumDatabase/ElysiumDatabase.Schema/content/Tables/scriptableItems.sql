CREATE TABLE [content].[scriptableItems] (
    [scriptableItemId]       INT             IDENTITY (0, 1) NOT NULL,
    [globalObject]           VARCHAR (255)   NOT NULL,
    [itemTypeId]             TINYINT         NOT NULL,
    [itemWeight]             DECIMAL (18, 2) NOT NULL,
    [itemValueGold]          INT             CONSTRAINT [DF__scriptabl__goldV__558AAF1E] DEFAULT ((0)) NOT NULL,
    [itemValueSilver]        TINYINT         NOT NULL,
    [itemValueCopper]        TINYINT         CONSTRAINT [DF__scriptabl__coppe__5772F790] DEFAULT ((0)) NOT NULL,
    [itemStackMax]           TINYINT         NOT NULL,
    [itemDurabilityMax]      INT             NOT NULL,
    [itemManaCapacity]       INT             NOT NULL,
    [itemQualityBaseId]      TINYINT         NOT NULL,
    [itemQualityMaxId]       TINYINT         NOT NULL,
    [isImbued]               BIT             NOT NULL,
    [isSoulBound]            BIT             NOT NULL,
    [itemDescription]        VARCHAR (1000)  NOT NULL,
    [craftingMaterialTypeId] TINYINT         NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D552698772] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableItems_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableItems_itemTypes_itemTypeId_fk] FOREIGN KEY ([itemTypeId]) REFERENCES [content].[itemTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D531638D7E] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

