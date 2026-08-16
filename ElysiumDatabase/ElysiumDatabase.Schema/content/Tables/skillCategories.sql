CREATE TABLE [content].[skillCategories] (
    [skillCategoryId] TINYINT        NOT NULL,
    [skillCategory]   VARCHAR (255)  NOT NULL,
    [description]     VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_skillCategories] PRIMARY KEY CLUSTERED ([skillCategoryId] ASC)
);


GO

