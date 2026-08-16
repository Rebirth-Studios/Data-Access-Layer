CREATE TABLE [content].[weaponsPositions] (
    [weaponSlotTypeId] TINYINT         NOT NULL,
    [positionX]        DECIMAL (18, 8) NOT NULL,
    [positionY]        DECIMAL (18, 8) NOT NULL,
    [positionZ]        DECIMAL (18, 8) NOT NULL,
    [rotationX]        DECIMAL (18, 8) NOT NULL,
    [rotationY]        DECIMAL (18, 8) NOT NULL,
    [rotationZ]        DECIMAL (18, 8) NOT NULL,
    [globalObject]     VARCHAR (255)   NOT NULL,
    CONSTRAINT [weaponsPositions_equipmentLocations_equipmentLocationId_fk] FOREIGN KEY ([weaponSlotTypeId]) REFERENCES [content].[equipmentSlotTypes] ([typeId]),
    CONSTRAINT [weaponsPositions_scriptableWeapons_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWeapons] ([globalObject])
);


GO

