CREATE TABLE [content].[statsMultiplierEntities] (
    [id]                           SMALLINT       IDENTITY (0, 1) NOT NULL,
    [entityTypeId]                 TINYINT        NOT NULL,
    [statTypeId]                   TINYINT        NOT NULL,
    [statId]                       TINYINT        NOT NULL,
    [mainTypeId]                   TINYINT        NOT NULL,
    [classificationTypeId]         TINYINT        NOT NULL,
    [subTypeId]                    TINYINT        NOT NULL,
    [multiplierMainType]           DECIMAL (5, 2) NOT NULL,
    [multiplierClassificationType] DECIMAL (5, 2) NOT NULL,
    [multiplierSubType]            DECIMAL (5, 2) NOT NULL,
    [multiplier]                   AS             (case when [multiplierSubType]>(0) then [multiplierSubType] when [multiplierClassificationType]>(0) then [multiplierClassificationType] else [multiplierMainType] end) PERSISTED NOT NULL,
    CONSTRAINT [PK_statsBaseTypeMultiplier] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

CREATE NONCLUSTERED INDEX [_dta_index_statsMultiplierEntities_5_773210196__K6_K5_K7_K4_K3_K2_11]
    ON [content].[statsMultiplierEntities]([classificationTypeId] ASC, [mainTypeId] ASC, [subTypeId] ASC, [statId] ASC, [statTypeId] ASC, [entityTypeId] ASC)
    INCLUDE([multiplier]);


GO

CREATE STATISTICS [_dta_stat_773210196_5_6_7_2_4]
    ON [content].[statsMultiplierEntities]([mainTypeId], [classificationTypeId], [subTypeId], [entityTypeId], [statId]);


GO

CREATE STATISTICS [_dta_stat_773210196_2_4_3]
    ON [content].[statsMultiplierEntities]([entityTypeId], [statId], [statTypeId]);


GO

CREATE STATISTICS [_dta_stat_773210196_5_2_4_3_6]
    ON [content].[statsMultiplierEntities]([mainTypeId], [entityTypeId], [statId], [statTypeId], [classificationTypeId]);


GO

CREATE STATISTICS [_dta_stat_773210196_7_2_4_3_5_6]
    ON [content].[statsMultiplierEntities]([subTypeId], [entityTypeId], [statId], [statTypeId], [mainTypeId], [classificationTypeId]);


GO

CREATE STATISTICS [_dta_stat_773210196_4_3_6_5_7]
    ON [content].[statsMultiplierEntities]([statId], [statTypeId], [classificationTypeId], [mainTypeId], [subTypeId]);


GO

CREATE STATISTICS [_dta_stat_773210196_6_5_7_3_2]
    ON [content].[statsMultiplierEntities]([classificationTypeId], [mainTypeId], [subTypeId], [statTypeId], [entityTypeId]);


GO

CREATE STATISTICS [_dta_stat_773210196_2_6_5]
    ON [content].[statsMultiplierEntities]([entityTypeId], [classificationTypeId], [mainTypeId]);


GO

