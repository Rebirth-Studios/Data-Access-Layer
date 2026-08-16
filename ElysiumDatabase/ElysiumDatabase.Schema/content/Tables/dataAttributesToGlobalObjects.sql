CREATE TABLE [content].[dataAttributesToGlobalObjects] (
    [globalObject]        VARCHAR (255) NOT NULL,
    [dataAttributeTypeId] TINYINT       NOT NULL,
    CONSTRAINT [FK_dataAttributesToGlobalObjects_globalObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[globalObjects] ([globalObject])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [dataAttributesToGlobalObjects_globalObject_dataAttributeTypeId_uindex]
    ON [content].[dataAttributesToGlobalObjects]([globalObject] ASC, [dataAttributeTypeId] ASC);


GO

