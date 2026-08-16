-- One-time, data-preserving migration for the pasted list of dbo tables.
--
-- Run this before publishing the DACPAC against an existing database if these tables
-- still physically live under dbo. The script skips tables that are no longer in dbo,
-- and throws if both dbo.<table> and target_schema.<table> exist.
--
-- Tables listed: 263 (content: 262, ops: 1).

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

    IF OBJECT_ID(N'[dbo].[scriptableEquipmentRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEquipmentRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEquipmentRequirements: content.scriptableEquipmentRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEquipmentRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypesToPrefabSearches: content.gatherableClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresDungeons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresDungeons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresDungeons: content.scriptableStructuresDungeons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresDungeons];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQualities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQualities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQualities: content.scriptableQualities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQualities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainersSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainersSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainersSpawnable: content.scriptableContainersSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainersSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsCollect]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsCollect]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsCollect: content.scriptableTotalsCollect already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsCollect];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeAnimal: content.statsMultiplierSubTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[missionCraftingTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionCraftingTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionCraftingTypes: content.missionCraftingTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionCraftingTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTypesToIconSearches: content.skillTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableJewelry]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableJewelry]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableJewelry: content.scriptableJewelry already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableJewelry];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypesToIconSearches: content.gatherableClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTables: content.scriptableLootTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTables];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeEnemyHumanoid: content.statsMultiplierSubTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[interactableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[interactableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.interactableTypes: content.interactableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[interactableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[missionAdventuringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionAdventuringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionAdventuringTypes: content.missionAdventuringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionAdventuringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableConsumables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableConsumables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableConsumables: content.scriptableConsumables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableConsumables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresEnemyHumanoids]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresEnemyHumanoids]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresEnemyHumanoids: content.scriptableStructuresEnemyHumanoids already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresEnemyHumanoids];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRarities: content.scriptableRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMonsters]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMonsters]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMonsters: content.scriptableMonsters already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMonsters];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeMonster: content.statsMultiplierSubTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypesToPrefabSearches: content.generalItemClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierSubTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierSubTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierSubTypeNpc: content.statsMultiplierSubTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierSubTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[missionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionTypes: content.missionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[itemSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[itemSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.itemSubTypes: content.itemSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[itemSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherablesSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherablesSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherablesSpawnable: content.scriptableGatherablesSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherablesSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypesToIconSearches: content.generalItemClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[spawnablesToLootTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spawnablesToLootTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnablesToLootTables: content.spawnablesToLootTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spawnablesToLootTables];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherablesVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherablesVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherablesVariations: content.scriptableGatherablesVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherablesVariations];
    END;

    IF OBJECT_ID(N'[dbo].[missionCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionCategoryTypes: content.missionCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypesToPrefabSearches: content.materialClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[jewelrySlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelrySlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelrySlotTypes: content.jewelrySlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelrySlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillCategoryTypes: content.skillCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresRuins]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresRuins]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresRuins: content.scriptableStructuresRuins already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresRuins];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItemRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItemRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItemRarities: content.scriptableItemRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItemRarities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTablesToLootTable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTablesToLootTable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTablesToLootTable: content.scriptableLootTablesToLootTable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTablesToLootTable];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypesToIconSearches: content.materialClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[statsBaseTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsBaseTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsBaseTiers: content.statsBaseTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsBaseTiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsConsume]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsConsume]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsConsume: content.scriptableTotalsConsume already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsConsume];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypes: content.jewelryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableTypes: content.gatherableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresUpgradeCosts]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresUpgradeCosts]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresUpgradeCosts: content.scriptableStructuresUpgradeCosts already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresUpgradeCosts];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableDrops]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableDrops]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableDrops: content.scriptableLootTableDrops already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableDrops];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilities: content.scriptableAbilities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilities];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypesToIconSearches: content.monsterClassificationTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[statBaseTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statBaseTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statBaseTypes: content.statBaseTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statBaseTypes];
    END;

    IF OBJECT_ID(N'[dbo].[lootTableClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTableClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTableClassificationTypes: content.lootTableClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTableClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTiers: content.skillTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTiers];
    END;

    IF OBJECT_ID(N'[dbo].[statCalculatedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statCalculatedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statCalculatedTypes: content.statCalculatedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statCalculatedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAchievements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAchievements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAchievements: content.scriptableAchievements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAchievements];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypesToPrefabSearches: content.monsterClassificationTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableBags]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableBags]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableBags: content.scriptableBags already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableBags];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMilestones]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMilestones]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMilestones: content.scriptableMilestones already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMilestones];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableIcons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableIcons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableIcons: content.scriptableIcons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableIcons];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresUpgradeDetails]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresUpgradeDetails]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresUpgradeDetails: content.scriptableStructuresUpgradeDetails already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresUpgradeDetails];
    END;

    IF OBJECT_ID(N'[dbo].[spellTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spellTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spellTiers: content.spellTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spellTiers];
    END;

    IF OBJECT_ID(N'[dbo].[lootTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTypes: content.lootTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTypes];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirements: content.levelRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableQuantities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableQuantities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableQuantities: content.scriptableLootTableQuantities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableQuantities];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMaterialModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMaterialModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMaterialModifiers: content.scriptableMaterialModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMaterialModifiers];
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

    IF OBJECT_ID(N'[dbo].[weaponTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypesToPrefabSearches: content.weaponTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptablePrefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptablePrefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptablePrefabs: content.scriptablePrefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptablePrefabs];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableSubTypes: content.gatherableSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[recipeTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[recipeTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.recipeTypesToIconSearches: content.recipeTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[recipeTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMissions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMissions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMissions: content.scriptableMissions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMissions];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirementsAbilities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirementsAbilities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirementsAbilities: content.levelRequirementsAbilities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirementsAbilities];
    END;

    IF OBJECT_ID(N'[dbo].[statEffectAmountTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statEffectAmountTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statEffectAmountTypes: content.statEffectAmountTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statEffectAmountTypes];
    END;

    IF OBJECT_ID(N'[dbo].[killTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[killTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.killTypes: content.killTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[killTypes];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableClassificationTypes: content.gatherableClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresVillage]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresVillage]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresVillage: content.scriptableStructuresVillage already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresVillage];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLootTableRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLootTableRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLootTableRarities: content.scriptableLootTableRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLootTableRarities];
    END;

    IF OBJECT_ID(N'[dbo].[weaponTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypesToIconSearches: content.weaponTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[levelRequirementsSkills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[levelRequirementsSkills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.levelRequirementsSkills: content.levelRequirementsSkills already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[levelRequirementsSkills];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesVariations: content.scriptableEntitiesVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesVariations];
    END;

    IF OBJECT_ID(N'[dbo].[statTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statTypes: content.statTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questDifficultyRanges]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questDifficultyRanges]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questDifficultyRanges: content.questDifficultyRanges already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questDifficultyRanges];
    END;

    IF OBJECT_ID(N'[dbo].[villageStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageStructureTypesToPrefabSearches: content.villageStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjects: content.globalObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjects];
    END;

    IF OBJECT_ID(N'[dbo].[structureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[structureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.structureTypes: content.structureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[structureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[test]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[ops].[test]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.test: ops.test already exists.', 1;
        ALTER SCHEMA [ops] TRANSFER [dbo].[test];
    END;

    IF OBJECT_ID(N'[dbo].[effectGroupsLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[effectGroupsLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.effectGroupsLevels: content.effectGroupsLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[effectGroupsLevels];
    END;

    IF OBJECT_ID(N'[dbo].[stats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[stats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.stats: content.stats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[stats];
    END;

    IF OBJECT_ID(N'[dbo].[lootTableTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[lootTableTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.lootTableTypes: content.lootTableTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[lootTableTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresVillageDefenses]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresVillageDefenses]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresVillageDefenses: content.scriptableStructuresVillageDefenses already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresVillageDefenses];
    END;

    IF OBJECT_ID(N'[dbo].[totalTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[totalTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.totalTypes: content.totalTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[totalTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItems: content.scriptableItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItems];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilitiesLevelsActivationCosts]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilitiesLevelsActivationCosts]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilitiesLevelsActivationCosts: content.scriptableAbilitiesLevelsActivationCosts already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilitiesLevelsActivationCosts];
    END;

    IF OBJECT_ID(N'[dbo].[villageDefenseTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageDefenseTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageDefenseTypesToPrefabSearches: content.villageDefenseTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageDefenseTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableMaterials]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableMaterials]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableMaterials: content.scriptableMaterials already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableMaterials];
    END;

    IF OBJECT_ID(N'[dbo].[villageStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageStructureTypes: content.villageStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypesToIconSearches: content.questBoardTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[villageDefenseTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[villageDefenseTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.villageDefenseTypes: content.villageDefenseTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[villageDefenseTypes];
    END;

    IF OBJECT_ID(N'[dbo].[itemTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[itemTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.itemTypes: content.itemTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[itemTypes];
    END;

    IF OBJECT_ID(N'[dbo].[weaponsBase]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponsBase]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponsBase: content.weaponsBase already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponsBase];
    END;

    IF OBJECT_ID(N'[dbo].[missionStatus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionStatus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionStatus: content.missionStatus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionStatus];
    END;

    IF OBJECT_ID(N'[dbo].[specialEventTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[specialEventTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.specialEventTypes: content.specialEventTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[specialEventTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsCraft]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsCraft]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsCraft: content.scriptableTotalsCraft already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsCraft];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableWeapons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableWeapons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableWeapons: content.scriptableWeapons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableWeapons];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypesToPrefabSearches: content.questBoardTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[prefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabSearches: content.prefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[weaponSlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponSlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponSlotTypes: content.weaponSlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponSlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableItemEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableItemEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableItemEffects: content.scriptableItemEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableItemEffects];
    END;

    IF OBJECT_ID(N'[dbo].[skillTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillTypes: content.skillTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillTypes];
    END;

    IF OBJECT_ID(N'[dbo].[socialTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[socialTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.socialTypes: content.socialTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[socialTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questBoardTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questBoardTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questBoardTypes: content.questBoardTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questBoardTypes];
    END;

    IF OBJECT_ID(N'[dbo].[weaponsPositions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponsPositions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponsPositions: content.weaponsPositions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponsPositions];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQualityModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQualityModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQualityModifiers: content.scriptableQualityModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQualityModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[npcTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcTypesToIconSearches: content.npcTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[globalStatuses]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalStatuses]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalStatuses: content.globalStatuses already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalStatuses];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestBoards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestBoards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestBoards: content.scriptableQuestBoards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestBoards];
    END;

    IF OBJECT_ID(N'[dbo].[spawnablesToPrefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[spawnablesToPrefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.spawnablesToPrefabs: content.spawnablesToPrefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[spawnablesToPrefabs];
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

    IF OBJECT_ID(N'[dbo].[missionRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionRanks: content.missionRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionRanks];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsGather]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsGather]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsGather: content.scriptableTotalsGather already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsGather];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierImbuedType]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierImbuedType]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierImbuedType: content.statsMultiplierImbuedType already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierImbuedType];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierEntities: content.statsMultiplierEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierEntities];
    END;

    IF OBJECT_ID(N'[dbo].[worldObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[worldObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.worldObjectTypes: content.worldObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[worldObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestExclusions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestExclusions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestExclusions: content.scriptableQuestExclusions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestExclusions];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEnemyHumanoids]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEnemyHumanoids]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEnemyHumanoids: content.scriptableEnemyHumanoids already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEnemyHumanoids];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectSpawnables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectSpawnables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectSpawnables: content.scriptableObjectSpawnables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectSpawnables];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypesToIconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypesToIconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypesToIconSearches: content.jewelryTypesToIconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypesToIconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectLevels: content.scriptableObjectLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectLevels];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentSlotTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentSlotTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentSlotTypes: content.equipmentSlotTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentSlotTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestlines]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestlines]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestlines: content.scriptableQuestlines already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestlines];
    END;

    IF OBJECT_ID(N'[dbo].[jewelryTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[jewelryTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.jewelryTypesToPrefabSearches: content.jewelryTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[jewelryTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[entityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityTypes: content.entityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[interactableTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[interactableTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.interactableTypesToPrefabSearches: content.interactableTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[interactableTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[genderTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[genderTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.genderTypes: content.genderTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[genderTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestObjectives]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestObjectives]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestObjectives: content.scriptableQuestObjectives already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestObjectives];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentMaterialModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentMaterialModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentMaterialModifiers: content.equipmentMaterialModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentMaterialModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[missionObjectives]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionObjectives]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionObjectives: content.missionObjectives already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionObjectives];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAbilitiesLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAbilitiesLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAbilitiesLevels: content.scriptableAbilitiesLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAbilitiesLevels];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuests]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuests]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuests: content.scriptableQuests already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuests];
    END;

    IF OBJECT_ID(N'[dbo].[questRankTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRankTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRankTypes: content.questRankTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRankTypes];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentRequirementGroups]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentRequirementGroups]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentRequirementGroups: content.equipmentRequirementGroups already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentRequirementGroups];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotalsKill]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotalsKill]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotalsKill: content.scriptableTotalsKill already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotalsKill];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestlineQuestOrder]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestlineQuestOrder]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestlineQuestOrder: content.scriptableQuestlineQuestOrder already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestlineQuestOrder];
    END;

    IF OBJECT_ID(N'[dbo].[entityImbuedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityImbuedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityImbuedTypes: content.entityImbuedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityImbuedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[qualityBonus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[qualityBonus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.qualityBonus: content.qualityBonus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[qualityBonus];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRarityModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRarityModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRarityModifiers: content.scriptableRarityModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRarityModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[questCategoryTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questCategoryTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questCategoryTypes: content.questCategoryTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questCategoryTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questMainTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questMainTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questMainTiers: content.questMainTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questMainTiers];
    END;

    IF OBJECT_ID(N'[dbo].[globalTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalTiers: content.globalTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalTiers];
    END;

    IF OBJECT_ID(N'[dbo].[entityCombatTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityCombatTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityCombatTypes: content.entityCombatTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityCombatTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRecipeIngredients]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRecipeIngredients]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRecipeIngredients: content.scriptableRecipeIngredients already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRecipeIngredients];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEquipment]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEquipment]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEquipment: content.scriptableEquipment already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEquipment];
    END;

    IF OBJECT_ID(N'[dbo].[missionObjectivesEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionObjectivesEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionObjectivesEntities: content.missionObjectivesEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionObjectivesEntities];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableQuantityTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableQuantityTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableQuantityTypes: content.gatherableQuantityTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableQuantityTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsBaseLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsBaseLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsBaseLevels: content.statsBaseLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsBaseLevels];
    END;

    IF OBJECT_ID(N'[dbo].[skillRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillRanks: content.skillRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillRanks];
    END;

    IF OBJECT_ID(N'[dbo].[entityDifficultyTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityDifficultyTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityDifficultyTypes: content.entityDifficultyTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityDifficultyTypes];
    END;

    IF OBJECT_ID(N'[dbo].[entityStats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[entityStats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.entityStats: content.entityStats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[entityStats];
    END;

    IF OBJECT_ID(N'[dbo].[questObjectiveTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questObjectiveTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questObjectiveTypes: content.questObjectiveTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questObjectiveTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiers: content.questTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiers];
    END;

    IF OBJECT_ID(N'[dbo].[missionGatheringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionGatheringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionGatheringTypes: content.missionGatheringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionGatheringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillDifficultyTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillDifficultyTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillDifficultyTiers: content.skillDifficultyTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillDifficultyTiers];
    END;

    IF OBJECT_ID(N'[dbo].[gatheringQuestTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatheringQuestTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatheringQuestTypes: content.gatheringQuestTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatheringQuestTypes];
    END;

    IF OBJECT_ID(N'[dbo].[targetRestrictionTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[targetRestrictionTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.targetRestrictionTypes: content.targetRestrictionTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[targetRestrictionTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSpawnTableOptions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSpawnTableOptions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSpawnTableOptions: content.scriptableSpawnTableOptions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSpawnTableOptions];
    END;

    IF OBJECT_ID(N'[dbo].[ruinStructureTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ruinStructureTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ruinStructureTypes: content.ruinStructureTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ruinStructureTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceLevels: content.experienceLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceLevels];
    END;

    IF OBJECT_ID(N'[dbo].[gatherTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherTypes: content.gatherTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRequirements]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRequirements]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRequirements: content.scriptableRequirements already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRequirements];
    END;

    IF OBJECT_ID(N'[dbo].[questTiersRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiersRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiersRanks: content.questTiersRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiersRanks];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSpawnTables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSpawnTables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSpawnTables: content.scriptableSpawnTables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSpawnTables];
    END;

    IF OBJECT_ID(N'[dbo].[requirementTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[requirementTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.requirementTypes: content.requirementTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[requirementTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGatherables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGatherables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGatherables: content.scriptableGatherables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGatherables];
    END;

    IF OBJECT_ID(N'[dbo].[questTiersRanksRewards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTiersRanksRewards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTiersRanksRewards: content.questTiersRanksRewards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTiersRanksRewards];
    END;

    IF OBJECT_ID(N'[dbo].[requiredAttributes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[requiredAttributes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.requiredAttributes: content.requiredAttributes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[requiredAttributes];
    END;

    IF OBJECT_ID(N'[dbo].[weaponTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[weaponTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.weaponTypes: content.weaponTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[weaponTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEffects: content.experienceEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEffects];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSkillsGatheringBonus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSkillsGatheringBonus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSkillsGatheringBonus: content.scriptableSkillsGatheringBonus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSkillsGatheringBonus];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTotals]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTotals]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTotals: content.scriptableTotals already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTotals];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGeneralItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGeneralItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGeneralItems: content.scriptableGeneralItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGeneralItems];
    END;

    IF OBJECT_ID(N'[dbo].[iconTypesToSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[iconTypesToSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.iconTypesToSearches: content.iconTypesToSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[iconTypesToSearches];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAnimals]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAnimals]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAnimals: content.scriptableAnimals already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAnimals];
    END;

    IF OBJECT_ID(N'[dbo].[prefabTypesToSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabTypesToSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabTypesToSearches: content.prefabTypesToSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabTypesToSearches];
    END;

    IF OBJECT_ID(N'[dbo].[globalRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalRanks: content.globalRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalRanks];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableVendorItems]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableVendorItems]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableVendorItems: content.scriptableVendorItems already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableVendorItems];
    END;

    IF OBJECT_ID(N'[dbo].[globalStats]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalStats]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalStats: content.globalStats already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalStats];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainersVariations]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainersVariations]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainersVariations: content.scriptableContainersVariations already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainersVariations];
    END;

    IF OBJECT_ID(N'[dbo].[ruinStructureTypesToPrefabSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[ruinStructureTypesToPrefabSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.ruinStructureTypesToPrefabSearches: content.ruinStructureTypesToPrefabSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[ruinStructureTypesToPrefabSearches];
    END;

    IF OBJECT_ID(N'[dbo].[missionRewards]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionRewards]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionRewards: content.missionRewards already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionRewards];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesAttacks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesAttacks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesAttacks: content.scriptableEntitiesAttacks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesAttacks];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableImbuedTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableImbuedTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableImbuedTypes: content.gatherableImbuedTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableImbuedTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableWorldObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableWorldObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableWorldObjects: content.scriptableWorldObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableWorldObjects];
    END;

    IF OBJECT_ID(N'[dbo].[modifierTypesLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[modifierTypesLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.modifierTypesLevels: content.modifierTypesLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[modifierTypesLevels];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableArmor]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableArmor]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableArmor: content.scriptableArmor already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableArmor];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableLevelModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableLevelModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableLevelModifiers: content.scriptableLevelModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableLevelModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[iconSearches]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[iconSearches]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.iconSearches: content.iconSearches already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[iconSearches];
    END;

    IF OBJECT_ID(N'[dbo].[prefabs]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[prefabs]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.prefabs: content.prefabs already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[prefabs];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableVendors]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableVendors]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableVendors: content.scriptableVendors already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableVendors];
    END;

    IF OBJECT_ID(N'[dbo].[gatherableLocationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gatherableLocationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gatherableLocationTypes: content.gatherableLocationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gatherableLocationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[enemyHumanoidTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[enemyHumanoidTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.enemyHumanoidTypes: content.enemyHumanoidTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[enemyHumanoidTypes];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemTypes: content.generalItemTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemTypes];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentBase]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentBase]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentBase: content.equipmentBase already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentBase];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableArmorTypeModifiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableArmorTypeModifiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableArmorTypeModifiers: content.scriptableArmorTypeModifiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableArmorTypeModifiers];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEffectTypes: content.experienceEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[multiplierMaxHealth]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[multiplierMaxHealth]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.multiplierMaxHealth: content.multiplierMaxHealth already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[multiplierMaxHealth];
    END;

    IF OBJECT_ID(N'[dbo].[modifierTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[modifierTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.modifierTypes: content.modifierTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[modifierTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeNpc: content.statsMultiplierClassificationTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructuresLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructuresLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructuresLevels: content.scriptableStructuresLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructuresLevels];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemSubTypes: content.generalItemSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[multiplierLevelDifferential]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[multiplierLevelDifferential]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.multiplierLevelDifferential: content.multiplierLevelDifferential already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[multiplierLevelDifferential];
    END;

    IF OBJECT_ID(N'[dbo].[generalItemClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[generalItemClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.generalItemClassificationTypes: content.generalItemClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[generalItemClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[monsterTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterTypes: content.monsterTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableInteractables]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableInteractables]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableInteractables: content.scriptableInteractables already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableInteractables];
    END;

    IF OBJECT_ID(N'[dbo].[Icons]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[Icons]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.Icons: content.Icons already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[Icons];
    END;

    IF OBJECT_ID(N'[dbo].[unlockEffectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[unlockEffectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.unlockEffectTypes: content.unlockEffectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[unlockEffectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialTypes: content.materialTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialTypes];
    END;

    IF OBJECT_ID(N'[dbo].[skillCategories]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[skillCategories]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.skillCategories: content.skillCategories already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[skillCategories];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeAnimal: content.statsMultiplierMainTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[questStatus]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questStatus]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questStatus: content.questStatus already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questStatus];
    END;

    IF OBJECT_ID(N'[dbo].[gameObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[gameObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.gameObjectTypes: content.gameObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[gameObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialSubTypes: content.materialSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeAnimal]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeAnimal]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeAnimal: content.statsMultiplierClassificationTypeAnimal already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeAnimal];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableRecipes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableRecipes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableRecipes: content.scriptableRecipes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableRecipes];
    END;

    IF OBJECT_ID(N'[dbo].[monsterSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterSubTypes: content.monsterSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[unlockEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[unlockEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.unlockEffects: content.unlockEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[unlockEffects];
    END;

    IF OBJECT_ID(N'[dbo].[questGatheringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questGatheringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questGatheringTypes: content.questGatheringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questGatheringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeEnemyHumanoid: content.statsMultiplierClassificationTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableContainers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableContainers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableContainers: content.scriptableContainers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableContainers];
    END;

    IF OBJECT_ID(N'[dbo].[questRanks]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRanks]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRanks: content.questRanks already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRanks];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeEnemyHumanoid]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeEnemyHumanoid]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeEnemyHumanoid: content.statsMultiplierMainTypeEnemyHumanoid already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeEnemyHumanoid];
    END;

    IF OBJECT_ID(N'[dbo].[questCraftingTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questCraftingTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questCraftingTypes: content.questCraftingTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questCraftingTypes];
    END;

    IF OBJECT_ID(N'[dbo].[materialClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[materialClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.materialClassificationTypes: content.materialClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[materialClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntities: content.scriptableEntities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntities];
    END;

    IF OBJECT_ID(N'[dbo].[monsterClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[monsterClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.monsterClassificationTypes: content.monsterClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[monsterClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[npcClassificationTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcClassificationTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcClassificationTypes: content.npcClassificationTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcClassificationTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeMonster: content.statsMultiplierMainTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[missionTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionTiers: content.missionTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionTiers];
    END;

    IF OBJECT_ID(N'[dbo].[globalFactions]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalFactions]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalFactions: content.globalFactions already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalFactions];
    END;

    IF OBJECT_ID(N'[dbo].[statEffects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statEffects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statEffects: content.statEffects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statEffects];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierDifficultyType]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierDifficultyType]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierDifficultyType: content.statsMultiplierDifficultyType already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierDifficultyType];
    END;

    IF OBJECT_ID(N'[dbo].[experienceEventTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceEventTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceEventTypes: content.experienceEventTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceEventTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questAdventuringTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questAdventuringTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questAdventuringTypes: content.questAdventuringTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questAdventuringTypes];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierMainTypeNpc]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierMainTypeNpc]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierMainTypeNpc: content.statsMultiplierMainTypeNpc already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierMainTypeNpc];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableSkills]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableSkills]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableSkills: content.scriptableSkills already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableSkills];
    END;

    IF OBJECT_ID(N'[dbo].[typeLevels]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[typeLevels]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.typeLevels: content.typeLevels already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[typeLevels];
    END;

    IF OBJECT_ID(N'[dbo].[missionMainTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[missionMainTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.missionMainTiers: content.missionMainTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[missionMainTiers];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectRarities]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectRarities]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectRarities: content.scriptableObjectRarities already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectRarities];
    END;

    IF OBJECT_ID(N'[dbo].[statsMultiplierClassificationTypeMonster]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[statsMultiplierClassificationTypeMonster]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.statsMultiplierClassificationTypeMonster: content.statsMultiplierClassificationTypeMonster already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[statsMultiplierClassificationTypeMonster];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjectSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjectSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjectSubTypes: content.globalObjectSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjectSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[experienceTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[experienceTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.experienceTypes: content.experienceTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[experienceTypes];
    END;

    IF OBJECT_ID(N'[dbo].[questTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questTypes: content.questTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questTypes];
    END;

    IF OBJECT_ID(N'[dbo].[equipmentTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[equipmentTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.equipmentTypes: content.equipmentTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[equipmentTypes];
    END;

    IF OBJECT_ID(N'[dbo].[npcTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcTypes: content.npcTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableQuestGivers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableQuestGivers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableQuestGivers: content.scriptableQuestGivers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableQuestGivers];
    END;

    IF OBJECT_ID(N'[dbo].[globalSubTiers]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalSubTiers]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalSubTiers: content.globalSubTiers already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalSubTiers];
    END;

    IF OBJECT_ID(N'[dbo].[questRankMainTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[questRankMainTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.questRankMainTypes: content.questRankMainTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[questRankMainTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableNPCS]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableNPCS]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableNPCS: content.scriptableNPCS already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableNPCS];
    END;

    IF OBJECT_ID(N'[dbo].[npcSubTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[npcSubTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.npcSubTypes: content.npcSubTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[npcSubTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjects]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjects]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjects: content.scriptableObjects already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjects];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableEntitiesSpawnable]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableEntitiesSpawnable]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableEntitiesSpawnable: content.scriptableEntitiesSpawnable already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableEntitiesSpawnable];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableGearSets]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableGearSets]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableGearSets: content.scriptableGearSets already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableGearSets];
    END;

    IF OBJECT_ID(N'[dbo].[globalObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[globalObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.globalObjectTypes: content.globalObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[globalObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[resistanceTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[resistanceTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.resistanceTypes: content.resistanceTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[resistanceTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableStructures]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableStructures]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableStructures: content.scriptableStructures already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableStructures];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableAmmunition]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableAmmunition]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableAmmunition: content.scriptableAmmunition already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableAmmunition];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableObjectTypes]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableObjectTypes]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableObjectTypes: content.scriptableObjectTypes already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableObjectTypes];
    END;

    IF OBJECT_ID(N'[dbo].[scriptableTitles]', N'U') IS NOT NULL
    BEGIN
        IF OBJECT_ID(N'[content].[scriptableTitles]', N'U') IS NOT NULL
            THROW 51000, N'Cannot transfer dbo.scriptableTitles: content.scriptableTitles already exists.', 1;
        ALTER SCHEMA [content] TRANSFER [dbo].[scriptableTitles];
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
