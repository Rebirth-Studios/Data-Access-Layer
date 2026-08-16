CREATE TABLE [runtime].[charactersMailAttachments] (
    [charactersMailAttachmentId] INT              IDENTITY (1, 1) NOT NULL,
    [charactersMailId]           UNIQUEIDENTIFIER NOT NULL,
    [instancedItemId]            UNIQUEIDENTIFIER NOT NULL,
    [sentDateTime]               DATETIME         NOT NULL,
    [takenbyPlayerDateTime]      DATETIME         NULL,
    [slotIndex]                  TINYINT          NULL,
    CONSTRAINT [PK_charactersMailAttachments] PRIMARY KEY CLUSTERED ([charactersMailAttachmentId] ASC),
    CONSTRAINT [charactersMailAttachments_instancedItems_instancedItemId_fk] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId]),
    CONSTRAINT [FK_charactersMailAttachments_charactersMail] FOREIGN KEY ([charactersMailId]) REFERENCES [runtime].[charactersMail] ([charactersMailId])
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Many to One relationship with charactersMail table', @level0type = N'SCHEMA', @level0name = N'runtime', @level1type = N'TABLE', @level1name = N'charactersMailAttachments';


GO

