CREATE TABLE [content].[characterCreationOptions] (
    [styleId]      TINYINT       NOT NULL,
    [styleName]    VARCHAR (255) NOT NULL,
    [styleTypeId]  TINYINT       NOT NULL,
    [genderTypeId] TINYINT       NOT NULL,
    [stylePath]    VARCHAR (255) NOT NULL,
    CONSTRAINT [characterCreationOptions_characterCreationStyleTypes_characterStyleTypeId_fk] FOREIGN KEY ([styleTypeId]) REFERENCES [content].[characterCreationStyleTypes] ([typeId])
);


GO

