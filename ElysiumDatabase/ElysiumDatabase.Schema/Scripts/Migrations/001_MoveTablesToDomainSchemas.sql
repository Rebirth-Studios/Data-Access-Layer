-- One-time, data-preserving migration from dbo to the domain schemas.
--
-- IMPORTANT:
--   1. Back up the database and test this script on a disposable copy first.
--   2. Run this script as a separate step immediately before publishing the DACPAC.
--   3. Do not add this file to Pre-Deployment.sql. DacFx calculates its deployment
--      plan before pre-deployment scripts run, so it could still plan destructive
--      drop-and-create operations for these schema moves.
--
-- Tables transferred: 452 (content: 352, runtime: 44, history: 9, identity: 1, ops: 46).

SET XACT_ABORT ON;
SET NOCOUNT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    IF SCHEMA_ID(N'content') IS NULL
        EXEC(N'CREATE SCHEMA [content] AUTHORIZATION [dbo]');
    IF SCHEMA_ID(N'runtime') IS NULL
        EXEC(N'CREATE SCHEMA [runtime] AUTHORIZATION [dbo]');
    IF SCHEMA_ID(N'history') IS NULL
        EXEC(N'CREATE SCHEMA [history] AUTHORIZATION [dbo]');
    IF SCHEMA_ID(N'identity') IS NULL
        EXEC(N'CREATE SCHEMA [identity] AUTHORIZATION [dbo]');
    IF SCHEMA_ID(N'ops') IS NULL
        EXEC(N'CREATE SCHEMA [ops] AUTHORIZATION [dbo]');
    IF SCHEMA_ID(N'api') IS NULL
        EXEC(N'CREATE SCHEMA [api] AUTHORIZATION [dbo]');

    IF OBJECT_ID(N'[dbo].[abilityActivationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityActivationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityActivationTypes: content.abilityActivationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityActivationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[abilityDifficultyTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityDifficultyTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityDifficultyTiers: content.abilityDifficultyTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityDifficultyTiers];
    END;

    IF OBJECT_ID(N'[dbo].[abilityEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityEffectTypes: content.abilityEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[abilityLevelsToObjectSpawnablesMapping]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityLevelsToObjectSpawnablesMapping]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityLevelsToObjectSpawnablesMapping: content.abilityLevelsToObjectSpawnablesMapping already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityLevelsToObjectSpawnablesMapping];
    END;

    IF OBJECT_ID(N'[dbo].[abilityRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityRanks: content.abilityRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityRanks];
    END;

    IF OBJECT_ID(N'[dbo].[abilitySlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilitySlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilitySlotTypes: content.abilitySlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilitySlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[abilityTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityTiers: content.abilityTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityTiers];
    END;

    IF OBJECT_ID(N'[dbo].[abilityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityTypes: content.abilityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[abilityTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[abilityTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.abilityTypesToIconSearches: content.abilityTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[abilityTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[achievementTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[achievementTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.achievementTypes: content.achievementTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[achievementTypes];
    END;

    IF OBJECT_ID(N'[dbo].[adventurerTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[adventurerTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.adventurerTiers: content.adventurerTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[adventurerTiers];
    END;

    IF OBJECT_ID(N'[dbo].[adventuringQuestTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[adventuringQuestTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.adventuringQuestTypes: content.adventuringQuestTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[adventuringQuestTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ammunitionClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ammunitionClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ammunitionClassificationTypes: content.ammunitionClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ammunitionClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ammunitionSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ammunitionSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ammunitionSubTypes: content.ammunitionSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ammunitionSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ammunitionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ammunitionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ammunitionTypes: content.ammunitionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ammunitionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[animalClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[animalClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.animalClassificationTypes: content.animalClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[animalClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[animalClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[animalClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.animalClassificationTypesToIconSearches: content.animalClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[animalClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[animalClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[animalClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.animalClassificationTypesToPrefabSearches: content.animalClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[animalClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[animalSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[animalSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.animalSubTypes: content.animalSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[animalSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[animalTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[animalTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.animalTypes: content.animalTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[animalTypes];
    END;

    IF OBJECT_ID(N'[dbo].[applicationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[applicationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.applicationTypes: content.applicationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[applicationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[armorSlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[armorSlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.armorSlotTypes: content.armorSlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[armorSlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[armorSlotTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[armorSlotTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.armorSlotTypesToIconSearches: content.armorSlotTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[armorSlotTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[armorSlotTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[armorSlotTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.armorSlotTypesToPrefabSearches: content.armorSlotTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[armorSlotTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[armorTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[armorTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.armorTypes: content.armorTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[armorTypes];
    END;

    IF OBJECT_ID(N'[dbo].[associatedGlobalObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[associatedGlobalObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.associatedGlobalObjects: content.associatedGlobalObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[associatedGlobalObjects];
    END;

    IF OBJECT_ID(N'[dbo].[attributePoints]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[attributePoints]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.attributePoints: content.attributePoints already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[attributePoints];
    END;

    IF OBJECT_ID(N'[dbo].[attributePrimaryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[attributePrimaryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.attributePrimaryTypes: content.attributePrimaryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[attributePrimaryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[attributeSecondaryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[attributeSecondaryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.attributeSecondaryTypes: content.attributeSecondaryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[attributeSecondaryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[attributeTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[attributeTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.attributeTypes: content.attributeTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[attributeTypes];
    END;

    IF OBJECT_ID(N'[dbo].[awardEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[awardEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.awardEffects: content.awardEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[awardEffects];
    END;

    IF OBJECT_ID(N'[dbo].[awardEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[awardEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.awardEffectTypes: content.awardEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[awardEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[bagClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bagClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bagClassificationTypes: content.bagClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bagClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[bagSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bagSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bagSubTypes: content.bagSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bagSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[bagTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bagTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bagTypes: content.bagTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bagTypes];
    END;

    IF OBJECT_ID(N'[dbo].[bagTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bagTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bagTypesToIconSearches: content.bagTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bagTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[bagTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bagTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bagTypesToPrefabSearches: content.bagTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bagTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[bodyPartMultipliers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bodyPartMultipliers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bodyPartMultipliers: content.bodyPartMultipliers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bodyPartMultipliers];
    END;

    IF OBJECT_ID(N'[dbo].[bodyPartPaths]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bodyPartPaths]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bodyPartPaths: content.bodyPartPaths already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bodyPartPaths];
    END;

    IF OBJECT_ID(N'[dbo].[bodyPartPathsAvailable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bodyPartPathsAvailable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bodyPartPathsAvailable: content.bodyPartPathsAvailable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bodyPartPathsAvailable];
    END;

    IF OBJECT_ID(N'[dbo].[bodyPartTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[bodyPartTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.bodyPartTypes: content.bodyPartTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[bodyPartTypes];
    END;

    IF OBJECT_ID(N'[dbo].[characterCreationOptions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[characterCreationOptions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.characterCreationOptions: content.characterCreationOptions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[characterCreationOptions];
    END;

    IF OBJECT_ID(N'[dbo].[characterCreationStyleTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[characterCreationStyleTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.characterCreationStyleTypes: content.characterCreationStyleTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[characterCreationStyleTypes];
    END;

    IF OBJECT_ID(N'[dbo].[conditionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[conditionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.conditionTypes: content.conditionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[conditionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[consumableClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableClassificationTypes: content.consumableClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[consumableClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableClassificationTypesToIconSearches: content.consumableClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[consumableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableClassificationTypesToPrefabSearches: content.consumableClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[consumableSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableSubTypes: content.consumableSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[consumableTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableTiers: content.consumableTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableTiers];
    END;

    IF OBJECT_ID(N'[dbo].[consumableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[consumableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.consumableTypes: content.consumableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[consumableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[containerClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerClassificationTypes: content.containerClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[containerClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerClassificationTypesToIconSearches: content.containerClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[containerClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerClassificationTypesToPrefabSearches: content.containerClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[containerImbuedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerImbuedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerImbuedTypes: content.containerImbuedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerImbuedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[containerQuantityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerQuantityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerQuantityTypes: content.containerQuantityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerQuantityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ContainerRarity]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ContainerRarity]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ContainerRarity: content.ContainerRarity already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ContainerRarity];
    END;

    IF OBJECT_ID(N'[dbo].[containerRarityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerRarityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerRarityTypes: content.containerRarityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerRarityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[containerSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerSubTypes: content.containerSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[containerTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[containerTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.containerTypes: content.containerTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[containerTypes];
    END;

    IF OBJECT_ID(N'[dbo].[coreTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[coreTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.coreTiers: content.coreTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[coreTiers];
    END;

    IF OBJECT_ID(N'[dbo].[costTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[costTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.costTypes: content.costTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[costTypes];
    END;

    IF OBJECT_ID(N'[dbo].[craftingMaterialTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[craftingMaterialTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.craftingMaterialTypes: content.craftingMaterialTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[craftingMaterialTypes];
    END;

    IF OBJECT_ID(N'[dbo].[craftingQuestTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[craftingQuestTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.craftingQuestTypes: content.craftingQuestTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[craftingQuestTypes];
    END;

    IF OBJECT_ID(N'[dbo].[currentStatTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[currentStatTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.currentStatTypes: content.currentStatTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[currentStatTypes];
    END;

    IF OBJECT_ID(N'[dbo].[damageReductionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[damageReductionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.damageReductionTypes: content.damageReductionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[damageReductionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[damageTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[damageTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.damageTypes: content.damageTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[damageTypes];
    END;

    IF OBJECT_ID(N'[dbo].[dataAttributesToGlobalObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[dataAttributesToGlobalObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.dataAttributesToGlobalObjects: content.dataAttributesToGlobalObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[dataAttributesToGlobalObjects];
    END;

    IF OBJECT_ID(N'[dbo].[dataAttributeTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[dataAttributeTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.dataAttributeTypes: content.dataAttributeTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[dataAttributeTypes];
    END;

    IF OBJECT_ID(N'[dbo].[dungeonStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[dungeonStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.dungeonStructureTypes: content.dungeonStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[dungeonStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[dungeonStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[dungeonStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.dungeonStructureTypesToPrefabSearches: content.dungeonStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[dungeonStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[effectAmountTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectAmountTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectAmountTypes: content.effectAmountTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectAmountTypes];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupClassificationTypes: content.effectGroupClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroups: content.effectGroups already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroups];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupsLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupsLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupsLevels: content.effectGroupsLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupsLevels];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupsToGearSetsMapping]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupsToGearSetsMapping]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupsToGearSetsMapping: content.effectGroupsToGearSetsMapping already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupsToGearSetsMapping];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupsToItemsMapping]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupsToItemsMapping]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupsToItemsMapping: content.effectGroupsToItemsMapping already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupsToItemsMapping];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupsToObjectsMapping]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupsToObjectsMapping]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupsToObjectsMapping: content.effectGroupsToObjectsMapping already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupsToObjectsMapping];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupTypes: content.effectGroupTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupTypes];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupTypesToIconSearches: content.effectGroupTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[effectMainTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectMainTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectMainTypes: content.effectMainTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectMainTypes];
    END;

    IF OBJECT_ID(N'[dbo].[effects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effects: content.effects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effects];
    END;

    IF OBJECT_ID(N'[dbo].[effectsToEffectGroupsMapping]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectsToEffectGroupsMapping]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectsToEffectGroupsMapping: content.effectsToEffectGroupsMapping already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectsToEffectGroupsMapping];
    END;

    IF OBJECT_ID(N'[dbo].[effectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectTypes: content.effectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[elementalTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[elementalTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.elementalTypes: content.elementalTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[elementalTypes];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidClassificationTypes: content.enemyHumanoidClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidClassificationTypesToIconSearches: content.enemyHumanoidClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidClassificationTypesToPrefabSearches: content.enemyHumanoidClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidStructuresClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidStructuresClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidStructuresClassificationTypesToPrefabSearches: content.enemyHumanoidStructuresClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidStructuresClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidStructureTypes: content.enemyHumanoidStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidStructureTypesToPrefabSearches: content.enemyHumanoidStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidSubTypes: content.enemyHumanoidSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidTypes: content.enemyHumanoidTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidTypes];
    END;

    IF OBJECT_ID(N'[dbo].[entityCombatTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityCombatTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityCombatTypes: content.entityCombatTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityCombatTypes];
    END;

    IF OBJECT_ID(N'[dbo].[entityDifficultyTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityDifficultyTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityDifficultyTypes: content.entityDifficultyTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityDifficultyTypes];
    END;

    IF OBJECT_ID(N'[dbo].[entityImbuedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityImbuedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityImbuedTypes: content.entityImbuedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityImbuedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[entityStats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityStats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityStats: content.entityStats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityStats];
    END;

    IF OBJECT_ID(N'[dbo].[entityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityTypes: content.entityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentBase]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentBase]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentBase: content.equipmentBase already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentBase];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentMaterialModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentMaterialModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentMaterialModifiers: content.equipmentMaterialModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentMaterialModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentRequirementGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentRequirementGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentRequirementGroups: content.equipmentRequirementGroups already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentRequirementGroups];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentSlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentSlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentSlotTypes: content.equipmentSlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentSlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentTypes: content.equipmentTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEffects: content.experienceEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEffects];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEffectTypes: content.experienceEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEventTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEventTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEventTypes: content.experienceEventTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEventTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceLevels: content.experienceLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceLevels];
    END;

    IF OBJECT_ID(N'[dbo].[experienceTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceTypes: content.experienceTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gameObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gameObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gameObjectTypes: content.gameObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gameObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypes: content.gatherableClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypesToIconSearches: content.gatherableClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypesToPrefabSearches: content.gatherableClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableImbuedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableImbuedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableImbuedTypes: content.gatherableImbuedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableImbuedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableLocationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableLocationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableLocationTypes: content.gatherableLocationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableLocationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableQuantityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableQuantityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableQuantityTypes: content.gatherableQuantityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableQuantityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableSubTypes: content.gatherableSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableTypes: content.gatherableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatheringQuestTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatheringQuestTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatheringQuestTypes: content.gatheringQuestTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatheringQuestTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherTypes: content.gatherTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherTypes];
    END;

    IF OBJECT_ID(N'[dbo].[genderTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[genderTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.genderTypes: content.genderTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[genderTypes];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypes: content.generalItemClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypesToIconSearches: content.generalItemClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypesToPrefabSearches: content.generalItemClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemSubTypes: content.generalItemSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemTypes: content.generalItemTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemTypes];
    END;

    IF OBJECT_ID(N'[dbo].[globalFactions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalFactions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalFactions: content.globalFactions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalFactions];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjects: content.globalObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjects];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjectSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjectSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjectSubTypes: content.globalObjectSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjectSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjectTypes: content.globalObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[globalRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalRanks: content.globalRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalRanks];
    END;

    IF OBJECT_ID(N'[dbo].[globalStats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalStats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalStats: content.globalStats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalStats];
    END;

    IF OBJECT_ID(N'[dbo].[globalStatuses]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalStatuses]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalStatuses: content.globalStatuses already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalStatuses];
    END;

    IF OBJECT_ID(N'[dbo].[globalSubTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalSubTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalSubTiers: content.globalSubTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalSubTiers];
    END;

    IF OBJECT_ID(N'[dbo].[globalTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalTiers: content.globalTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalTiers];
    END;

    IF OBJECT_ID(N'[dbo].[Icons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[Icons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.Icons: content.Icons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[Icons];
    END;

    IF OBJECT_ID(N'[dbo].[iconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[iconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.iconSearches: content.iconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[iconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[iconTypesToSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[iconTypesToSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.iconTypesToSearches: content.iconTypesToSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[iconTypesToSearches];
    END;

    IF OBJECT_ID(N'[dbo].[interactableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[interactableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.interactableTypes: content.interactableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[interactableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[interactableTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[interactableTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.interactableTypesToPrefabSearches: content.interactableTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[interactableTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[itemSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[itemSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.itemSubTypes: content.itemSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[itemSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[itemTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[itemTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.itemTypes: content.itemTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[itemTypes];
    END;

    IF OBJECT_ID(N'[dbo].[jewelrySlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelrySlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelrySlotTypes: content.jewelrySlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelrySlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypes: content.jewelryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypesToIconSearches: content.jewelryTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypesToPrefabSearches: content.jewelryTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[killTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[killTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.killTypes: content.killTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[killTypes];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirements: content.levelRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirementsAbilities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirementsAbilities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirementsAbilities: content.levelRequirementsAbilities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirementsAbilities];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirementsSkills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirementsSkills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirementsSkills: content.levelRequirementsSkills already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirementsSkills];
    END;

    IF OBJECT_ID(N'[dbo].[lootTableClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTableClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTableClassificationTypes: content.lootTableClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTableClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[lootTableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTableTypes: content.lootTableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[lootTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTypes: content.lootTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypes: content.materialClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypesToIconSearches: content.materialClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypesToPrefabSearches: content.materialClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[materialSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialSubTypes: content.materialSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialTypes: content.materialTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionAdventuringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionAdventuringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionAdventuringTypes: content.missionAdventuringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionAdventuringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionCategoryTypes: content.missionCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionCraftingTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionCraftingTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionCraftingTypes: content.missionCraftingTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionCraftingTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionGatheringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionGatheringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionGatheringTypes: content.missionGatheringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionGatheringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionMainTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionMainTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionMainTiers: content.missionMainTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionMainTiers];
    END;

    IF OBJECT_ID(N'[dbo].[missionObjectives]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionObjectives]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionObjectives: content.missionObjectives already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionObjectives];
    END;

    IF OBJECT_ID(N'[dbo].[missionObjectivesEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionObjectivesEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionObjectivesEntities: content.missionObjectivesEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionObjectivesEntities];
    END;

    IF OBJECT_ID(N'[dbo].[missionRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionRanks: content.missionRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionRanks];
    END;

    IF OBJECT_ID(N'[dbo].[missionRewards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionRewards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionRewards: content.missionRewards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionRewards];
    END;

    IF OBJECT_ID(N'[dbo].[missionStatus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionStatus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionStatus: content.missionStatus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionStatus];
    END;

    IF OBJECT_ID(N'[dbo].[missionTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionTiers: content.missionTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionTiers];
    END;

    IF OBJECT_ID(N'[dbo].[missionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionTypes: content.missionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[modifierTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[modifierTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.modifierTypes: content.modifierTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[modifierTypes];
    END;

    IF OBJECT_ID(N'[dbo].[modifierTypesLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[modifierTypesLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.modifierTypesLevels: content.modifierTypesLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[modifierTypesLevels];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypes: content.monsterClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypesToIconSearches: content.monsterClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypesToPrefabSearches: content.monsterClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[monsterSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterSubTypes: content.monsterSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[monsterTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterTypes: content.monsterTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterTypes];
    END;

    IF OBJECT_ID(N'[dbo].[multiplierLevelDifferential]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[multiplierLevelDifferential]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.multiplierLevelDifferential: content.multiplierLevelDifferential already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[multiplierLevelDifferential];
    END;

    IF OBJECT_ID(N'[dbo].[multiplierMaxHealth]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[multiplierMaxHealth]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.multiplierMaxHealth: content.multiplierMaxHealth already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[multiplierMaxHealth];
    END;

    IF OBJECT_ID(N'[dbo].[npcClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcClassificationTypes: content.npcClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[npcSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcSubTypes: content.npcSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[npcTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcTypes: content.npcTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcTypes];
    END;

    IF OBJECT_ID(N'[dbo].[npcTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcTypesToIconSearches: content.npcTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[npcTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcTypesToPrefabSearches: content.npcTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[potionTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[potionTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.potionTiers: content.potionTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[potionTiers];
    END;

    IF OBJECT_ID(N'[dbo].[prefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabs: content.prefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabs];
    END;

    IF OBJECT_ID(N'[dbo].[prefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabSearches: content.prefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[prefabTypesToSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabTypesToSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabTypesToSearches: content.prefabTypesToSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabTypesToSearches];
    END;

    IF OBJECT_ID(N'[dbo].[qualityBonus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[qualityBonus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.qualityBonus: content.qualityBonus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[qualityBonus];
    END;

    IF OBJECT_ID(N'[dbo].[questAdventuringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questAdventuringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questAdventuringTypes: content.questAdventuringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questAdventuringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypes: content.questBoardTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypesToIconSearches: content.questBoardTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypesToPrefabSearches: content.questBoardTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[questCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questCategoryTypes: content.questCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questCraftingTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questCraftingTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questCraftingTypes: content.questCraftingTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questCraftingTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questDifficultyRanges]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questDifficultyRanges]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questDifficultyRanges: content.questDifficultyRanges already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questDifficultyRanges];
    END;

    IF OBJECT_ID(N'[dbo].[questGatheringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questGatheringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questGatheringTypes: content.questGatheringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questGatheringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questMainTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questMainTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questMainTiers: content.questMainTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questMainTiers];
    END;

    IF OBJECT_ID(N'[dbo].[questObjectiveTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questObjectiveTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questObjectiveTypes: content.questObjectiveTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questObjectiveTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questRankMainTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRankMainTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRankMainTypes: content.questRankMainTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRankMainTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRanks: content.questRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRanks];
    END;

    IF OBJECT_ID(N'[dbo].[questRankTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRankTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRankTypes: content.questRankTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRankTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questStatus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questStatus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questStatus: content.questStatus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questStatus];
    END;

    IF OBJECT_ID(N'[dbo].[questTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiers: content.questTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiers];
    END;

    IF OBJECT_ID(N'[dbo].[questTiersRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiersRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiersRanks: content.questTiersRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiersRanks];
    END;

    IF OBJECT_ID(N'[dbo].[questTiersRanksRewards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiersRanksRewards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiersRanksRewards: content.questTiersRanksRewards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiersRanksRewards];
    END;

    IF OBJECT_ID(N'[dbo].[questTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTypes: content.questTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTypes];
    END;

    IF OBJECT_ID(N'[dbo].[recipeTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[recipeTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.recipeTypesToIconSearches: content.recipeTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[recipeTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[requiredAttributes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[requiredAttributes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.requiredAttributes: content.requiredAttributes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[requiredAttributes];
    END;

    IF OBJECT_ID(N'[dbo].[requirementTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[requirementTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.requirementTypes: content.requirementTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[requirementTypes];
    END;

    IF OBJECT_ID(N'[dbo].[resistanceTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[resistanceTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.resistanceTypes: content.resistanceTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[resistanceTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ruinStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ruinStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ruinStructureTypes: content.ruinStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ruinStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ruinStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ruinStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ruinStructureTypesToPrefabSearches: content.ruinStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ruinStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilities: content.scriptableAbilities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilitiesLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilitiesLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilitiesLevels: content.scriptableAbilitiesLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilitiesLevels];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilitiesLevelsActivationCosts]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilitiesLevelsActivationCosts]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilitiesLevelsActivationCosts: content.scriptableAbilitiesLevelsActivationCosts already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilitiesLevelsActivationCosts];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAchievements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAchievements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAchievements: content.scriptableAchievements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAchievements];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAmmunition]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAmmunition]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAmmunition: content.scriptableAmmunition already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAmmunition];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAnimals]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAnimals]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAnimals: content.scriptableAnimals already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAnimals];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableArmor]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableArmor]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableArmor: content.scriptableArmor already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableArmor];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableArmorTypeModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableArmorTypeModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableArmorTypeModifiers: content.scriptableArmorTypeModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableArmorTypeModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableBags]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableBags]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableBags: content.scriptableBags already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableBags];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableConsumables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableConsumables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableConsumables: content.scriptableConsumables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableConsumables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainers: content.scriptableContainers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainersSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainersSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainersSpawnable: content.scriptableContainersSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainersSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainersVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainersVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainersVariations: content.scriptableContainersVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainersVariations];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEnemyHumanoids]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEnemyHumanoids]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEnemyHumanoids: content.scriptableEnemyHumanoids already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEnemyHumanoids];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntities: content.scriptableEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesAttacks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesAttacks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesAttacks: content.scriptableEntitiesAttacks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesAttacks];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesSpawnable: content.scriptableEntitiesSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesVariations: content.scriptableEntitiesVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesVariations];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEquipment]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEquipment]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEquipment: content.scriptableEquipment already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEquipment];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEquipmentRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEquipmentRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEquipmentRequirements: content.scriptableEquipmentRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEquipmentRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherables: content.scriptableGatherables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherablesSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherablesSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherablesSpawnable: content.scriptableGatherablesSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherablesSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherablesVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherablesVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherablesVariations: content.scriptableGatherablesVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherablesVariations];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGearSets]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGearSets]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGearSets: content.scriptableGearSets already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGearSets];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGeneralItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGeneralItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGeneralItems: content.scriptableGeneralItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGeneralItems];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableIcons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableIcons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableIcons: content.scriptableIcons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableIcons];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableInteractables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableInteractables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableInteractables: content.scriptableInteractables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableInteractables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItemEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItemEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItemEffects: content.scriptableItemEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItemEffects];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItemRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItemRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItemRarities: content.scriptableItemRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItemRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItems: content.scriptableItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItems];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableJewelry]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableJewelry]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableJewelry: content.scriptableJewelry already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableJewelry];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLevelModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLevelModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLevelModifiers: content.scriptableLevelModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLevelModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableDrops]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableDrops]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableDrops: content.scriptableLootTableDrops already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableDrops];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableQuantities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableQuantities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableQuantities: content.scriptableLootTableQuantities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableQuantities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableRarities: content.scriptableLootTableRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTables: content.scriptableLootTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTablesToLootTable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTablesToLootTable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTablesToLootTable: content.scriptableLootTablesToLootTable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTablesToLootTable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMaterialModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMaterialModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMaterialModifiers: content.scriptableMaterialModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMaterialModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMaterials]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMaterials]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMaterials: content.scriptableMaterials already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMaterials];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMilestones]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMilestones]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMilestones: content.scriptableMilestones already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMilestones];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMissions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMissions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMissions: content.scriptableMissions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMissions];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMonsters]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMonsters]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMonsters: content.scriptableMonsters already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMonsters];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableNPCS]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableNPCS]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableNPCS: content.scriptableNPCS already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableNPCS];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectLevels: content.scriptableObjectLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectLevels];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectRarities: content.scriptableObjectRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjects: content.scriptableObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjects];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectSpawnables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectSpawnables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectSpawnables: content.scriptableObjectSpawnables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectSpawnables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectTypes: content.scriptableObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptablePrefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptablePrefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptablePrefabs: content.scriptablePrefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptablePrefabs];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQualities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQualities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQualities: content.scriptableQualities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQualities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQualityModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQualityModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQualityModifiers: content.scriptableQualityModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQualityModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestBoards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestBoards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestBoards: content.scriptableQuestBoards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestBoards];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestExclusions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestExclusions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestExclusions: content.scriptableQuestExclusions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestExclusions];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestGivers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestGivers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestGivers: content.scriptableQuestGivers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestGivers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestlineQuestOrder]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestlineQuestOrder]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestlineQuestOrder: content.scriptableQuestlineQuestOrder already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestlineQuestOrder];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestlines]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestlines]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestlines: content.scriptableQuestlines already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestlines];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestObjectives]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestObjectives]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestObjectives: content.scriptableQuestObjectives already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestObjectives];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuests]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuests]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuests: content.scriptableQuests already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuests];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRarities: content.scriptableRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRarityModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRarityModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRarityModifiers: content.scriptableRarityModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRarityModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRecipeIngredients]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRecipeIngredients]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRecipeIngredients: content.scriptableRecipeIngredients already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRecipeIngredients];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRecipes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRecipes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRecipes: content.scriptableRecipes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRecipes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRequirements: content.scriptableRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSkills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSkills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSkills: content.scriptableSkills already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSkills];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSkillsGatheringBonus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSkillsGatheringBonus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSkillsGatheringBonus: content.scriptableSkillsGatheringBonus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSkillsGatheringBonus];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSpawnTableOptions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSpawnTableOptions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSpawnTableOptions: content.scriptableSpawnTableOptions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSpawnTableOptions];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSpawnTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSpawnTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSpawnTables: content.scriptableSpawnTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSpawnTables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructures]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructures]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructures: content.scriptableStructures already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructures];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresDungeons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresDungeons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresDungeons: content.scriptableStructuresDungeons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresDungeons];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresEnemyHumanoids]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresEnemyHumanoids]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresEnemyHumanoids: content.scriptableStructuresEnemyHumanoids already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresEnemyHumanoids];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresLevels: content.scriptableStructuresLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresLevels];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresRuins]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresRuins]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresRuins: content.scriptableStructuresRuins already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresRuins];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresUpgradeCosts]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresUpgradeCosts]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresUpgradeCosts: content.scriptableStructuresUpgradeCosts already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresUpgradeCosts];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresUpgradeDetails]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresUpgradeDetails]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresUpgradeDetails: content.scriptableStructuresUpgradeDetails already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresUpgradeDetails];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresVillage]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresVillage]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresVillage: content.scriptableStructuresVillage already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresVillage];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresVillageDefenses]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresVillageDefenses]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresVillageDefenses: content.scriptableStructuresVillageDefenses already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresVillageDefenses];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTitles]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTitles]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTitles: content.scriptableTitles already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTitles];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotals]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotals]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotals: content.scriptableTotals already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotals];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsCollect]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsCollect]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsCollect: content.scriptableTotalsCollect already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsCollect];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsConsume]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsConsume]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsConsume: content.scriptableTotalsConsume already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsConsume];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsCraft]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsCraft]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsCraft: content.scriptableTotalsCraft already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsCraft];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsGather]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsGather]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsGather: content.scriptableTotalsGather already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsGather];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsKill]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsKill]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsKill: content.scriptableTotalsKill already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsKill];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableVendorItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableVendorItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableVendorItems: content.scriptableVendorItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableVendorItems];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableVendors]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableVendors]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableVendors: content.scriptableVendors already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableVendors];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableWeapons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableWeapons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableWeapons: content.scriptableWeapons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableWeapons];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableWorldObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableWorldObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableWorldObjects: content.scriptableWorldObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableWorldObjects];
    END;

    IF OBJECT_ID(N'[dbo].[skillCategories]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillCategories]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillCategories: content.skillCategories already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillCategories];
    END;

    IF OBJECT_ID(N'[dbo].[skillCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillCategoryTypes: content.skillCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillDifficultyTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillDifficultyTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillDifficultyTiers: content.skillDifficultyTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillDifficultyTiers];
    END;

    IF OBJECT_ID(N'[dbo].[skillRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillRanks: content.skillRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillRanks];
    END;

    IF OBJECT_ID(N'[dbo].[skillTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTiers: content.skillTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTiers];
    END;

    IF OBJECT_ID(N'[dbo].[skillTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTypes: content.skillTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTypesToIconSearches: content.skillTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[socialTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[socialTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.socialTypes: content.socialTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[socialTypes];
    END;

    IF OBJECT_ID(N'[dbo].[spawnablesToLootTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spawnablesToLootTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnablesToLootTables: content.spawnablesToLootTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spawnablesToLootTables];
    END;

    IF OBJECT_ID(N'[dbo].[spawnablesToPrefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spawnablesToPrefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnablesToPrefabs: content.spawnablesToPrefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spawnablesToPrefabs];
    END;

    IF OBJECT_ID(N'[dbo].[specialEventTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[specialEventTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.specialEventTypes: content.specialEventTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[specialEventTypes];
    END;

    IF OBJECT_ID(N'[dbo].[spellTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spellTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spellTiers: content.spellTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spellTiers];
    END;

    IF OBJECT_ID(N'[dbo].[statBaseTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statBaseTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statBaseTypes: content.statBaseTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statBaseTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statCalculatedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statCalculatedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statCalculatedTypes: content.statCalculatedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statCalculatedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statEffectAmountTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statEffectAmountTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statEffectAmountTypes: content.statEffectAmountTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statEffectAmountTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statEffects: content.statEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statEffects];
    END;

    IF OBJECT_ID(N'[dbo].[statMultiplierTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statMultiplierTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statMultiplierTypes: content.statMultiplierTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statMultiplierTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statNames]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statNames]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statNames: content.statNames already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statNames];
    END;

    IF OBJECT_ID(N'[dbo].[stats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[stats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.stats: content.stats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[stats];
    END;

    IF OBJECT_ID(N'[dbo].[statsBaseLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsBaseLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsBaseLevels: content.statsBaseLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsBaseLevels];
    END;

    IF OBJECT_ID(N'[dbo].[statsBaseTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsBaseTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsBaseTiers: content.statsBaseTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsBaseTiers];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeAnimal: content.statsMultiplierClassificationTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeEnemyHumanoid: content.statsMultiplierClassificationTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeMonster: content.statsMultiplierClassificationTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeNpc: content.statsMultiplierClassificationTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierDifficultyType]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierDifficultyType]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierDifficultyType: content.statsMultiplierDifficultyType already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierDifficultyType];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierEntities: content.statsMultiplierEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierEntities];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierImbuedType]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierImbuedType]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierImbuedType: content.statsMultiplierImbuedType already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierImbuedType];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeAnimal: content.statsMultiplierMainTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeEnemyHumanoid: content.statsMultiplierMainTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeMonster: content.statsMultiplierMainTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeNpc: content.statsMultiplierMainTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeAnimal: content.statsMultiplierSubTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeEnemyHumanoid: content.statsMultiplierSubTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeMonster: content.statsMultiplierSubTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeNpc: content.statsMultiplierSubTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[statTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statTypes: content.statTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statTypes];
    END;

    IF OBJECT_ID(N'[dbo].[structureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[structureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.structureTypes: content.structureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[structureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[targetRestrictionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[targetRestrictionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.targetRestrictionTypes: content.targetRestrictionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[targetRestrictionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[totalTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[totalTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.totalTypes: content.totalTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[totalTypes];
    END;

    IF OBJECT_ID(N'[dbo].[typeLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[typeLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.typeLevels: content.typeLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[typeLevels];
    END;

    IF OBJECT_ID(N'[dbo].[unlockEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[unlockEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.unlockEffects: content.unlockEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[unlockEffects];
    END;

    IF OBJECT_ID(N'[dbo].[unlockEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[unlockEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.unlockEffectTypes: content.unlockEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[unlockEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[villageDefenseTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageDefenseTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageDefenseTypes: content.villageDefenseTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageDefenseTypes];
    END;

    IF OBJECT_ID(N'[dbo].[villageDefenseTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageDefenseTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageDefenseTypesToPrefabSearches: content.villageDefenseTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageDefenseTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[villageStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageStructureTypes: content.villageStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[villageStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageStructureTypesToPrefabSearches: content.villageStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[weaponsBase]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponsBase]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponsBase: content.weaponsBase already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponsBase];
    END;

    IF OBJECT_ID(N'[dbo].[weaponSlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponSlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponSlotTypes: content.weaponSlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponSlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[weaponsPositions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponsPositions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponsPositions: content.weaponsPositions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponsPositions];
    END;

    IF OBJECT_ID(N'[dbo].[weaponTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypes: content.weaponTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypes];
    END;

    IF OBJECT_ID(N'[dbo].[weaponTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypesToIconSearches: content.weaponTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[weaponTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypesToPrefabSearches: content.weaponTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[worldObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[worldObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.worldObjectTypes: content.worldObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[worldObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[characters]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[characters]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.characters: runtime.characters already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[characters];
    END;

    IF OBJECT_ID(N'[dbo].[charactersAbilities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersAbilities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersAbilities: runtime.charactersAbilities already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersAbilities];
    END;

    IF OBJECT_ID(N'[dbo].[charactersAchievements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersAchievements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersAchievements: runtime.charactersAchievements already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersAchievements];
    END;

    IF OBJECT_ID(N'[dbo].[charactersBuyBacks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersBuyBacks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersBuyBacks: runtime.charactersBuyBacks already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersBuyBacks];
    END;

    IF OBJECT_ID(N'[dbo].[charactersMail]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersMail]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersMail: runtime.charactersMail already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersMail];
    END;

    IF OBJECT_ID(N'[dbo].[charactersMailAttachments]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersMailAttachments]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersMailAttachments: runtime.charactersMailAttachments already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersMailAttachments];
    END;

    IF OBJECT_ID(N'[dbo].[charactersMissions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersMissions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersMissions: runtime.charactersMissions already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersMissions];
    END;

    IF OBJECT_ID(N'[dbo].[charactersQuests]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersQuests]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersQuests: runtime.charactersQuests already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersQuests];
    END;

    IF OBJECT_ID(N'[dbo].[charactersQuestsObjectives]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersQuestsObjectives]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersQuestsObjectives: runtime.charactersQuestsObjectives already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersQuestsObjectives];
    END;

    IF OBJECT_ID(N'[dbo].[charactersRecipes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersRecipes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersRecipes: runtime.charactersRecipes already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersRecipes];
    END;

    IF OBJECT_ID(N'[dbo].[charactersSkills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersSkills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersSkills: runtime.charactersSkills already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersSkills];
    END;

    IF OBJECT_ID(N'[dbo].[charactersSocial]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersSocial]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersSocial: runtime.charactersSocial already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersSocial];
    END;

    IF OBJECT_ID(N'[dbo].[charactersStats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersStats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersStats: runtime.charactersStats already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersStats];
    END;

    IF OBJECT_ID(N'[dbo].[charactersStatsStaging]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersStatsStaging]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersStatsStaging: runtime.charactersStatsStaging already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersStatsStaging];
    END;

    IF OBJECT_ID(N'[dbo].[charactersStatusEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersStatusEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersStatusEffects: runtime.charactersStatusEffects already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersStatusEffects];
    END;

    IF OBJECT_ID(N'[dbo].[charactersTitles]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[charactersTitles]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.charactersTitles: runtime.charactersTitles already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[charactersTitles];
    END;

    IF OBJECT_ID(N'[dbo].[instancedAmmunition]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedAmmunition]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedAmmunition: runtime.instancedAmmunition already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedAmmunition];
    END;

    IF OBJECT_ID(N'[dbo].[instancedArmor]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedArmor]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedArmor: runtime.instancedArmor already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedArmor];
    END;

    IF OBJECT_ID(N'[dbo].[instancedBags]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedBags]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedBags: runtime.instancedBags already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedBags];
    END;

    IF OBJECT_ID(N'[dbo].[instancedConsumables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedConsumables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedConsumables: runtime.instancedConsumables already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedConsumables];
    END;

    IF OBJECT_ID(N'[dbo].[instancedEquipment]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedEquipment]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedEquipment: runtime.instancedEquipment already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedEquipment];
    END;

    IF OBJECT_ID(N'[dbo].[instancedGeneralItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedGeneralItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedGeneralItems: runtime.instancedGeneralItems already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedGeneralItems];
    END;

    IF OBJECT_ID(N'[dbo].[instancedItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedItems: runtime.instancedItems already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedItems];
    END;

    IF OBJECT_ID(N'[dbo].[instancedItemsIngredients]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedItemsIngredients]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedItemsIngredients: runtime.instancedItemsIngredients already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedItemsIngredients];
    END;

    IF OBJECT_ID(N'[dbo].[instancedMaterials]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedMaterials]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedMaterials: runtime.instancedMaterials already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedMaterials];
    END;

    IF OBJECT_ID(N'[dbo].[instancedMissions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedMissions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedMissions: runtime.instancedMissions already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedMissions];
    END;

    IF OBJECT_ID(N'[dbo].[instancedWeapons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[instancedWeapons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.instancedWeapons: runtime.instancedWeapons already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[instancedWeapons];
    END;

    IF OBJECT_ID(N'[dbo].[questsGenerated]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[questsGenerated]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questsGenerated: runtime.questsGenerated already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[questsGenerated];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedAnimals]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedAnimals]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedAnimals: runtime.spawnedAnimals already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedAnimals];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedContainers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedContainers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedContainers: runtime.spawnedContainers already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedContainers];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedEnemyHumanoids]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedEnemyHumanoids]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedEnemyHumanoids: runtime.spawnedEnemyHumanoids already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedEnemyHumanoids];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedEntities: runtime.spawnedEntities already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedEntities];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedGatherables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedGatherables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedGatherables: runtime.spawnedGatherables already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedGatherables];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedInteractables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedInteractables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedInteractables: runtime.spawnedInteractables already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedInteractables];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedMonsters]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedMonsters]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedMonsters: runtime.spawnedMonsters already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedMonsters];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedNPCs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedNPCs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedNPCs: runtime.spawnedNPCs already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedNPCs];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedVendorInventory]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedVendorInventory]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedVendorInventory: runtime.spawnedVendorInventory already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedVendorInventory];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedVendors]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedVendors]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedVendors: runtime.spawnedVendors already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedVendors];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedWorldObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedWorldObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedWorldObjects: runtime.spawnedWorldObjects already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedWorldObjects];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedWorldObjectsBags]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedWorldObjectsBags]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedWorldObjectsBags: runtime.spawnedWorldObjectsBags already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedWorldObjectsBags];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedWorldObjectsCurrency]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedWorldObjectsCurrency]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedWorldObjectsCurrency: runtime.spawnedWorldObjectsCurrency already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedWorldObjectsCurrency];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedWorldObjectsEquipment]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedWorldObjectsEquipment]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedWorldObjectsEquipment: runtime.spawnedWorldObjectsEquipment already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedWorldObjectsEquipment];
    END;

    IF OBJECT_ID(N'[dbo].[spawnedWorldObjectsInventory]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnedWorldObjectsInventory]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnedWorldObjectsInventory: runtime.spawnedWorldObjectsInventory already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnedWorldObjectsInventory];
    END;

    IF OBJECT_ID(N'[dbo].[spawnerLocations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[runtime].[spawnerLocations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnerLocations: runtime.spawnerLocations already exists.', 1;
        ALTER SCHEMA [runtime] TRANSFER [dbo].[spawnerLocations];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterCollected]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterCollected]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterCollected: history.historyCharacterCollected already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterCollected];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterCombat]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterCombat]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterCombat: history.historyCharacterCombat already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterCombat];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterCrafted]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterCrafted]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterCrafted: history.historyCharacterCrafted already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterCrafted];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterDeaths]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterDeaths]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterDeaths: history.historyCharacterDeaths already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterDeaths];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterGathered]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterGathered]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterGathered: history.historyCharacterGathered already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterGathered];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterKills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterKills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterKills: history.historyCharacterKills already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterKills];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterLoot]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterLoot]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterLoot: history.historyCharacterLoot already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterLoot];
    END;

    IF OBJECT_ID(N'[dbo].[historyCharacterQuests]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCharacterQuests]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCharacterQuests: history.historyCharacterQuests already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCharacterQuests];
    END;

    IF OBJECT_ID(N'[dbo].[historyCurrencyTransactions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[history].[historyCurrencyTransactions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyCurrencyTransactions: history.historyCurrencyTransactions already exists.', 1;
        ALTER SCHEMA [history] TRANSFER [dbo].[historyCurrencyTransactions];
    END;

    IF OBJECT_ID(N'[dbo].[playersAccounts]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[identity].[playersAccounts]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.playersAccounts: identity.playersAccounts already exists.', 1;
        ALTER SCHEMA [identity] TRANSFER [dbo].[playersAccounts];
    END;

    IF OBJECT_ID(N'[dbo].[_columnTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_columnTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._columnTypes: ops._columnTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_columnTypes];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsColumnsDataTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsColumnsDataTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsColumnsDataTables: ops._configDetailsColumnsDataTables already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsColumnsDataTables];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsControls]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsControls]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsControls: ops._configDetailsControls already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsControls];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsDefaultOverrides]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsDefaultOverrides]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsDefaultOverrides: ops._configDetailsDefaultOverrides already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsDefaultOverrides];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsGameObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsGameObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsGameObjects: ops._configDetailsGameObjects already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsGameObjects];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsGameObjectsAssociated]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsGameObjectsAssociated]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsGameObjectsAssociated: ops._configDetailsGameObjectsAssociated already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsGameObjectsAssociated];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsNamingOverrides]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsNamingOverrides]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsNamingOverrides: ops._configDetailsNamingOverrides already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsNamingOverrides];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsSearchKeys]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsSearchKeys]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsSearchKeys: ops._configDetailsSearchKeys already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsSearchKeys];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsSearchKeysAssociated]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsSearchKeysAssociated]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsSearchKeysAssociated: ops._configDetailsSearchKeysAssociated already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsSearchKeysAssociated];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsTablesConfig]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsTablesConfig]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsTablesConfig: ops._configDetailsTablesConfig already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsTablesConfig];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsTablesData]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsTablesData]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsTablesData: ops._configDetailsTablesData already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsTablesData];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsTypeLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsTypeLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsTypeLevels: ops._configDetailsTypeLevels already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsTypeLevels];
    END;

    IF OBJECT_ID(N'[dbo].[_configDetailsVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configDetailsVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configDetailsVariations: ops._configDetailsVariations already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configDetailsVariations];
    END;

    IF OBJECT_ID(N'[dbo].[_configFilterTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configFilterTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configFilterTypes: ops._configFilterTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configFilterTypes];
    END;

    IF OBJECT_ID(N'[dbo].[_configGameObjectExtraPanels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configGameObjectExtraPanels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configGameObjectExtraPanels: ops._configGameObjectExtraPanels already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configGameObjectExtraPanels];
    END;

    IF OBJECT_ID(N'[dbo].[_configGameObjectGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configGameObjectGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configGameObjectGroups: ops._configGameObjectGroups already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configGameObjectGroups];
    END;

    IF OBJECT_ID(N'[dbo].[_configGameObjectsTablesUsedBy]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configGameObjectsTablesUsedBy]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configGameObjectsTablesUsedBy: ops._configGameObjectsTablesUsedBy already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configGameObjectsTablesUsedBy];
    END;

    IF OBJECT_ID(N'[dbo].[_configGlobalObjectTypesGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configGlobalObjectTypesGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configGlobalObjectTypesGroups: ops._configGlobalObjectTypesGroups already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configGlobalObjectTypesGroups];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesColumnTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesColumnTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesColumnTypes: ops._configNamesColumnTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesColumnTypes];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesControls]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesControls]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesControls: ops._configNamesControls already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesControls];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesDataLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesDataLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesDataLevels: ops._configNamesDataLevels already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesDataLevels];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesDataRows]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesDataRows]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesDataRows: ops._configNamesDataRows already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesDataRows];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesDataTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesDataTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesDataTables: ops._configNamesDataTables already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesDataTables];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesDefaultValues]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesDefaultValues]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesDefaultValues: ops._configNamesDefaultValues already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesDefaultValues];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesGridViews]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesGridViews]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesGridViews: ops._configNamesGridViews already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesGridViews];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesListViewRows]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesListViewRows]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesListViewRows: ops._configNamesListViewRows already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesListViewRows];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesListViews]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesListViews]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesListViews: ops._configNamesListViews already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesListViews];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesPanels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesPanels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesPanels: ops._configNamesPanels already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesPanels];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesProperties]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesProperties]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesProperties: ops._configNamesProperties already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesProperties];
    END;

    IF OBJECT_ID(N'[dbo].[_configNamesTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configNamesTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configNamesTables: ops._configNamesTables already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configNamesTables];
    END;

    IF OBJECT_ID(N'[dbo].[_configSortFields]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configSortFields]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configSortFields: ops._configSortFields already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configSortFields];
    END;

    IF OBJECT_ID(N'[dbo].[_configSqlTableGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configSqlTableGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configSqlTableGroups: ops._configSqlTableGroups already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configSqlTableGroups];
    END;

    IF OBJECT_ID(N'[dbo].[_configTotalsAssociatedVerbs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configTotalsAssociatedVerbs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configTotalsAssociatedVerbs: ops._configTotalsAssociatedVerbs already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configTotalsAssociatedVerbs];
    END;

    IF OBJECT_ID(N'[dbo].[_configTypesToTableNames]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configTypesToTableNames]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configTypesToTableNames: ops._configTypesToTableNames already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configTypesToTableNames];
    END;

    IF OBJECT_ID(N'[dbo].[_configUnitTest]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_configUnitTest]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._configUnitTest: ops._configUnitTest already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_configUnitTest];
    END;

    IF OBJECT_ID(N'[dbo].[_controlTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_controlTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._controlTypes: ops._controlTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_controlTypes];
    END;

    IF OBJECT_ID(N'[dbo].[_tableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_tableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._tableTypes: ops._tableTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_tableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[_typesList]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_typesList]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._typesList: ops._typesList already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_typesList];
    END;

    IF OBJECT_ID(N'[dbo].[_updateTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[_updateTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo._updateTypes: ops._updateTypes already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[_updateTypes];
    END;

    IF OBJECT_ID(N'[dbo].[ab]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[ab]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ab: ops.ab already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[ab];
    END;

    IF OBJECT_ID(N'[dbo].[DB_Errors]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[DB_Errors]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.DB_Errors: ops.DB_Errors already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[DB_Errors];
    END;

    IF OBJECT_ID(N'[dbo].[historyBatchProcessing]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[historyBatchProcessing]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.historyBatchProcessing: ops.historyBatchProcessing already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[historyBatchProcessing];
    END;

    IF OBJECT_ID(N'[dbo].[Internal_FK_Definition_Storage]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[Internal_FK_Definition_Storage]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.Internal_FK_Definition_Storage: ops.Internal_FK_Definition_Storage already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[Internal_FK_Definition_Storage];
    END;

    IF OBJECT_ID(N'[dbo].[lastUpdatedTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[lastUpdatedTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lastUpdatedTables: ops.lastUpdatedTables already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[lastUpdatedTables];
    END;

    IF OBJECT_ID(N'[dbo].[Table_1]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[Table_1]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.Table_1: ops.Table_1 already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[Table_1];
    END;

    IF OBJECT_ID(N'[dbo].[test]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[test]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.test: ops.test already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[test];
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;

