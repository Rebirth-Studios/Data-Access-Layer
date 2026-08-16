CREATE TABLE [ops].[historyBatchProcessing] (
    [historyBatchProcessingId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [batchRowId]               INT           NOT NULL,
    [storedProcName]           VARCHAR (255) NOT NULL,
    [processDateTime]          DATETIME      NOT NULL,
    CONSTRAINT [PK_historyBatchProcessing] PRIMARY KEY CLUSTERED ([historyBatchProcessingId] ASC)
);


GO

