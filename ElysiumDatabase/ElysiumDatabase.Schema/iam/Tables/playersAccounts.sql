CREATE TABLE [identity].[playersAccounts] (
    [playerAccountId]      INT           IDENTITY (1, 1) NOT NULL,
    [steamId]              VARCHAR (64)  NOT NULL,
    [steamName]            VARCHAR (255) NOT NULL,
    [lastIpAddressOnLogin] VARCHAR (255) NOT NULL,
    [lastLoginTime]        DATETIME      NOT NULL,
    [isAdmin]              BIT           NULL,
    CONSTRAINT [PK_playerAccounts] PRIMARY KEY CLUSTERED ([playerAccountId] ASC),
    UNIQUE NONCLUSTERED ([steamId] ASC)
);


GO

