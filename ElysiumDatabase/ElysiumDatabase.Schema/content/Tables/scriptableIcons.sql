CREATE TABLE [content].[scriptableIcons] (
    [id]       INT            IDENTITY (0, 1) NOT NULL,
    [iconName] VARCHAR (255)  NOT NULL,
    [iconPath] VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_scriptableIcons] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

