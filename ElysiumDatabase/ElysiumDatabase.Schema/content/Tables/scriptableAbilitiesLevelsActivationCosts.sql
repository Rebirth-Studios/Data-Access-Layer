CREATE TABLE [content].[scriptableAbilitiesLevelsActivationCosts] (
    [scriptableAbilitiesRanksActivationCostId] INT             IDENTITY (1, 1) NOT NULL,
    [cost]                                     INT             NOT NULL,
    [costTypeId]                               TINYINT         NOT NULL,
    [statTypeId]                               TINYINT         NOT NULL,
    [statId]                                   TINYINT         NOT NULL,
    [costTimes]                                INT             NOT NULL,
    [timeBetweenCosts]                         DECIMAL (18, 2) NOT NULL,
    [scriptableObjectLevel]                    VARCHAR (255)   NOT NULL,
    [currentStatTypeId]                        TINYINT         NOT NULL,
    [globalObject]                             VARCHAR (255)   NOT NULL,
    [levelId]                                  TINYINT         NOT NULL,
    CONSTRAINT [PK_scriptableAbilitiesRanksActivationCosts] PRIMARY KEY CLUSTERED ([scriptableAbilitiesRanksActivationCostId] ASC),
    CONSTRAINT [FK__scriptabl__scrip__35E17F4E] FOREIGN KEY ([scriptableObjectLevel]) REFERENCES [content].[scriptableObjectLevels] ([scriptableObjectLevel]),
    CONSTRAINT [FK_scriptableAbilitiesLevelsActivationCosts_scriptableAbilities] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableAbilities] ([globalObject]),
    CONSTRAINT [scriptableAbilitiesRanksActivationCosts_costTypes_costTypeId_fk] FOREIGN KEY ([costTypeId]) REFERENCES [content].[costTypes] ([typeId])
);


GO

