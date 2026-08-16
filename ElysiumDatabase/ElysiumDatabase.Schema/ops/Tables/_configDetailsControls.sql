CREATE TABLE [ops].[_configDetailsControls] (
    [tableName]             VARCHAR (100) NOT NULL,
    [controlName]           VARCHAR (100) NOT NULL,
    [controlType]           VARCHAR (50)  NOT NULL,
    [description]           VARCHAR (255) NOT NULL,
    [panelName]             VARCHAR (100) NOT NULL,
    [gridViewName]          VARCHAR (100) NOT NULL,
    [childControlTableName] VARCHAR (100) NOT NULL,
    [childControlName]      VARCHAR (100) NOT NULL,
    [hideSetName]           BIT           NOT NULL,
    [skipDropDownSourceSet] BIT           NOT NULL,
    [typeLevelId]           TINYINT       NOT NULL,
    [typeLevel]             AS            ([dbo].[getTypeLevel]([typeLevelId]))
);


GO

