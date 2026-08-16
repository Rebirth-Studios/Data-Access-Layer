CREATE TABLE [ops].[DB_Errors] (
    [ErrorID]         INT           IDENTITY (1, 1) NOT NULL,
    [UserName]        VARCHAR (100) NULL,
    [ErrorNumber]     INT           NULL,
    [ErrorState]      INT           NULL,
    [ErrorSeverity]   INT           NULL,
    [ErrorLine]       INT           NULL,
    [ErrorProcedure]  VARCHAR (MAX) NULL,
    [ErrorMessage]    VARCHAR (MAX) NULL,
    [ErrorDateTime]   DATETIME      NULL,
    [ParameterValues] VARCHAR (MAX) NULL,
    CONSTRAINT [DB_Errors_primaryKey] PRIMARY KEY CLUSTERED ([ErrorID] ASC)
);


GO

