CREATE TABLE [runtime].[charactersMail] (
    [charactersMailId]        UNIQUEIDENTIFIER NOT NULL,
    [autoDeleteDateTime]      DATETIME         NOT NULL,
    [appearDateTime]          DATETIME         NOT NULL,
    [sentDateTime]            DATETIME         NOT NULL,
    [mailSubject]             VARCHAR (255)    NOT NULL,
    [mailBody]                VARCHAR (1000)   NOT NULL,
    [deletedbyPlayerDateTime] DATETIME         NULL,
    [senderName]              VARCHAR (255)    NOT NULL,
    [sentGold]                INT              NULL,
    [sentSilver]              TINYINT          NULL,
    [sentCopper]              TINYINT          NULL,
    [currencyClaimed]         BIT              NULL,
    [contentsClaimed]         BIT              NULL,
    [unread]                  BIT              NULL,
    [mailIndex]               TINYINT          NULL,
    [senderCharacterId]       INT              NULL,
    [recipientCharacterId]    INT              NOT NULL,
    CONSTRAINT [PK_charactersMail] PRIMARY KEY CLUSTERED ([charactersMailId] ASC)
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'One to many relationship with charactersMailAttachments table', @level0type = N'SCHEMA', @level0name = N'runtime', @level1type = N'TABLE', @level1name = N'charactersMail';


GO

