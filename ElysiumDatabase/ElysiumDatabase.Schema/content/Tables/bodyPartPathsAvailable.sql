CREATE TABLE [content].[bodyPartPathsAvailable] (
    [bodyPartPathAvailableId] INT            IDENTITY (1, 1) NOT NULL,
    [bodyPartTypeId]          TINYINT        NOT NULL,
    [bodyPartPath]            VARCHAR (1000) NOT NULL,
    [bodyPartType]            AS             ([dbo].[getBodyPartType]([bodyPartTypeId])),
    [description]             VARCHAR (255)  NOT NULL,
    CONSTRAINT [PK_bodyPartPathsAvailable] PRIMARY KEY CLUSTERED ([bodyPartPathAvailableId] ASC),
    CONSTRAINT [bodyPartPathsAvailable_bodyPartTypes_bodyPartTypeId_fk] FOREIGN KEY ([bodyPartTypeId]) REFERENCES [content].[bodyPartTypes] ([typeId]),
    CONSTRAINT [UQ_bodyPartPath] UNIQUE NONCLUSTERED ([bodyPartPath] ASC)
);


GO

