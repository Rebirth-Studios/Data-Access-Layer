# TODO

This file tracks open questions and work discovered while introducing the SQL
project, .NET 10, the PR pipeline, and the incremental EF Core/DataTables hybrid.
It intentionally contains no credentials.

## Decisions needed

- [ ] Decide the authentication model for player accounts.
  - The current `dbo.playersAccounts` table contains Steam identity and login
    metadata, but no username, password, email, or salt columns.
  - Should Steam be the only identity provider, or should credentials live in a
    separate identity service/table?
- [ ] Decide what the existing `PlayerAccount_GetPassword` and
  `PlayerAccount_Create(userName, password)` APIs should become.
  - `PlayerAccount_GetPassword` currently accepts a password but does not verify
    it.
  - The cache is keyed by `steamName`, while the API calls that value `userName`.
  - Account creation currently generates a Steam ID and writes an empty Steam
    name while separately indexing the row by the supplied username.
- [x] Use the logical database domains `content`, `runtime`, `history`,
  `identity`, and `ops`.
  - Proposed data schemas: `content`, `runtime`, `history`, `identity`, and `ops`.
  - Optional `api` schema for stable application-facing procedures and views.
  - Keep `dbo` for shared objects and temporary compatibility during migration.
- [x] Model all table-domain moves together in the SQL project. The live
  database migration remains gated on a disposable-database rehearsal and
  deployment-script review.
- [ ] Decide which access layer owns writes for each migrated table.
  A table must not be written by both EF and the DataTable batch writer without
  explicit coordination.
- [ ] Decide how production supplies `ELYSIUM_DB_CONNECTION` or an equivalent
  secret: process environment, service secret store, container secret, or host
  configuration. Do not restore a connection string to source control.
- [ ] Decide whether SQL project/EF work should move to a dedicated branch such
  as `feature/sqlproj-ef-hybrid`. The current branch also contains the earlier
  database-connection refactor and legacy-output cleanup commit.

## Security and correctness — highest priority

- [ ] Rotate the SQL credential that was previously embedded in tracked source.
  Removing it from the working tree does not remove it from Git history.
- [ ] Replace or redesign `PlayerAccount_GetPassword`; it currently returns a
  successful account response based on a name lookup without validating the
  supplied password.
- [ ] Define how Steam IDs are validated and normalized before account creation.
- [ ] Handle nullable `playersAccounts.isAdmin` safely. Current DataTable code can
  cast a database `NULL` directly to `bool`.
- [ ] Review account/login logging to ensure passwords, tokens, connection
  strings, and other secrets are never logged.
- [ ] Review the repeated profiling pattern where a `Stopwatch` can remain null
  when profiling is disabled but is read unconditionally afterward.
- [ ] Replace `System.Data.SqlClient` 4.8.5 in `ImportGoogleSheets`; the build
  reports a known high-severity vulnerability. Prefer `Microsoft.Data.SqlClient`.

## SQL project baseline

- [ ] Do not enable automatic DACPAC publishing yet. The current buildable model
  deliberately excludes 34 legacy definitions that fail SQL validation.
- [ ] Compare the generated DACPAC with a disposable copy of `Elysium_DEV` and
  review the deployment script before the first publish.
- [ ] Establish environment-specific publish profiles without credentials.
- [ ] Review extracted database settings before treating them as desired state:
  compatibility level 150, SQL160 provider, `AUTO_CLOSE`, ANSI settings, query
  store settings, recovery target, page verification, and collation.
- [ ] Decide whether database principals such as `Security/Elysium.sql` belong in
  the project or should be provisioned separately per environment.
- [ ] Remove the temporary `SQL71502` suppression after ambiguous references are
  qualified. A diagnostic build found 182 `SQL71502` warnings.
- [x] Correct the remaining case-only reference mismatches. The SQL project now
  builds without SQL71558 warnings.
- [ ] Add a schema-drift check to CI once the baseline is complete.
- [ ] Add a reviewed rollback/recovery procedure for DACPAC deployments.

### Definitions excluded from the DACPAC model

These files remain source controlled. Repair, replace, or explicitly retire each
one before including it in the compiled model:

- [ ] `dbo/Functions/getAdditionalSkillRequiredContainer.sql`
- [ ] `dbo/Functions/getAdditionalSkillRequiredGatherable.sql`
- [ ] `dbo/Functions/getLootTableName.sql`
- [ ] `dbo/Functions/getMaxRarityIdAmmunition.sql`
- [ ] `dbo/Functions/getMaxRarityIdBag.sql`
- [ ] `dbo/Functions/getMaxRarityIdConsumable.sql`
- [ ] `dbo/Functions/getMaxRarityIdEquipment.sql`
- [ ] `dbo/Functions/getMaxRarityIdGeneralItem.sql`
- [ ] `dbo/Functions/getMaxRarityIdMaterial.sql`
- [ ] `dbo/Functions/getMinRarityIdAmmunition.sql`
- [ ] `dbo/Functions/getMinRarityIdBag.sql`
- [ ] `dbo/Functions/getMinRarityIdConsumable.sql`
- [ ] `dbo/Functions/getMinRarityIdEquipment.sql`
- [ ] `dbo/Functions/getMinRarityIdGeneralItem.sql`
- [ ] `dbo/Functions/getMinRarityIdMaterial.sql`
- [ ] `dbo/Functions/getSkillMinLevelId.sql`
- [ ] `dbo/Functions/getStatExperience.sql`
- [ ] `dbo/Functions/getTypeNameEntity.sql`
- [ ] `dbo/Functions/getWorldObjectClassificationTypeName.sql`
- [ ] `dbo/StoredProcedures/enumCraftingQuestTypes.sql`
- [ ] `dbo/StoredProcedures/RestoreConfigDetailsColumnsDataTables.sql`
- [ ] `dbo/StoredProcedures/SaveConfigDetailsColumnsDataTables.sql`
- [ ] `dbo/StoredProcedures/spDamageTypes_GetList.sql`
- [ ] `dbo/StoredProcedures/spEffectAmountTypes_GetList.sql`
- [ ] `dbo/StoredProcedures/spEffectTypes_GetList.sql`
- [ ] `dbo/StoredProcedures/spEntityStats.sql`
- [ ] `dbo/StoredProcedures/spGlobal_StatsGetList.sql`
- [ ] `dbo/StoredProcedures/spPlayerAccount_Create.sql`
- [ ] `dbo/StoredProcedures/spPlayerAccount_Create2.sql`
- [ ] `dbo/StoredProcedures/spPlayerAccount_ResetPassword.sql`
- [ ] `dbo/StoredProcedures/spPlayerAccount_ReturnPassword.sql`
- [ ] `dbo/StoredProcedures/spQuest_GetTiersRanks.sql`
- [ ] `dbo/StoredProcedures/spQuestTypes_GetList.sql`
- [ ] `Security/Elysium.sql`

### Known unresolved-reference themes

- [ ] Qualify aliases in functions such as
  `getAdditionalSkillRequiredContainer`,
  `getAdditionalSkillRequiredGatherable`, `getLootTableName`, and
  `getTypeNameEntity`.
- [ ] Resolve references to columns that no longer exist, including the
  min/max rarity columns, `entityStats.statTotal`,
  `skillRanks.skillRankId`, and several legacy enum/type-name columns.
- [ ] Reconcile player-account procedures with the current Steam-based table.
- [ ] Reconcile procedures that reference deleted or renamed tables such as
  `_configDetailsColumnsDataTables`.
- [ ] Qualify unqualified columns in multi-table procedures instead of relying
  on SQL Server's runtime name resolution.

## Schema/domain organization

- [ ] Extend the completed 452-table inventory to assign every view, function,
  procedure, and type to `content`, `runtime`, `history`, `identity`, `ops`,
  `api`, or shared infrastructure.
- [x] Reorganize all table definitions into their physical domain schemas:
  `content` (352), `runtime` (44), `history` (9), `identity` (1), and `ops` (46).
- [ ] Mirror those domains in EF entity/configuration namespaces.
- [x] Schema-qualify DataTable selects, metadata lookup, inserts, identity
  inserts, and updates before moving tables out of `dbo`.
- [ ] Inventory every stored procedure, view, foreign key, application query,
  permission, import job, and report affected by each physical schema move.
- [ ] Add integration tests before physical moves.
- [x] Add a transactional, one-time `ALTER SCHEMA ... TRANSFER` migration so a
  schema move is not deployed as destructive drop-and-create work.
- [ ] Rehearse `Scripts/Migrations/001_MoveTablesToDomainSchemas.sql` and the
  subsequent DACPAC deployment on a disposable copy of `Elysium_DEV`.
- [ ] Decide which compatible `dbo` procedures/views should move to `api`, then
  inventory and update every caller and permission before moving them.
- [ ] Define roles and permissions per schema before moving objects.
- [ ] Migrate one bounded domain at a time and retain compatibility only where
  required.

## EF Core/DataTables hybrid

- [ ] Run the new player-account EF mapping against a disposable or development
  database. Compilation is verified; live model/database operations have not yet
  been smoke tested.
- [ ] Add tests for the `playersAccounts` EF mapping, no-tracking queries,
  immediate identity creation, deferred-update coalescing, failure requeue, and
  cancellation.
- [ ] Wire the EF player-account store into a real server workflow after the
  authentication questions above are resolved.
- [ ] Define cache synchronization rules for every EF write:
  - update the DataTable/dictionaries immediately, or
  - invalidate/reload the affected cache entry.
- [ ] Prevent duplicate writes when a cached row is both modified in a DataTable
  and queued through EF.
- [ ] Add graceful-shutdown flushing for pending EF and DataTable writes.
- [ ] Decide retry, poison-write, dead-letter, and alerting behavior after a
  deferred write repeatedly fails.
- [ ] Add queue depth, flush duration, failure count, and database latency
  metrics.
- [ ] Consider making the update/flush lifecycle fully asynchronous instead of
  synchronously waiting on `FlushPendingWritesAsync`.
- [ ] Decide the next EF vertical slice after player accounts. A small reference
  data area or character metadata is safer than inventory/world-state writes.
- [ ] Continue using the SQL project—not EF migrations—as the schema authority.
- [ ] Do not scaffold all 452 tables until domain boundaries and naming
  conventions are agreed upon.

## Testing and CI

- [ ] Add at least one test project; the PR pipeline currently finds none.
- [ ] Add a disposable SQL Server integration-test job that publishes the DACPAC
  and runs EF/DataTable smoke tests.
- [ ] Test the production-like deferred-write cadence and shutdown behavior.
- [ ] Add migration/deployment-script review as a PR artifact.
- [ ] Decide whether SQL warnings should eventually fail CI after the baseline is
  cleaned.
- [ ] Verify the PR workflow from a pushed branch, not only through local builds.

## Repository and tooling cleanup

- [ ] Add or correct `.gitignore` rules for `bin`, `obj`, Rider user files,
  generated DACPAC output, and other build artifacts.
- [ ] Remove remaining tracked build artifacts in a focused cleanup commit.
- [ ] Separate unrelated dirty-worktree changes into reviewable commits; do not
  bulk-stage the current workspace.
- [ ] Commit the SQL project, .NET 10 upgrade, PR workflow, secure connection
  configuration, and EF slice in coherent commits after reviewing this list.
- [ ] Decide whether to remove the redundant SDK directory at
  `C:/Users/logan/.dotnet10`; it was left untouched because deletion requires an
  explicit decision.
- [ ] Confirm new terminals and Rider inherit the configured user-level .NET and
  SqlPackage paths.

## Current verification snapshot

- [x] Repository targets .NET 10 and builds with the installed .NET 10 SDK.
- [x] SqlPackage 170.4.83 is available globally and through the local tool
  manifest.
- [x] The SQL project contains 987 extracted schema object files plus six domain
  schema definitions and produces a DACPAC from the buildable model.
- [x] All 452 table definitions use domain schemas, and the data-preserving
  one-time transfer script covers the same 452 tables.
- [x] EF Core SQL Server 10.0.10 is restored, and the SQL project builds with
  zero SQL warnings and zero errors.
- [x] The complete staged solution snapshot builds with zero errors (legacy
  .NET/NuGet warnings remain and are tracked below).
- [x] The active database-access and Google Sheets import source no longer
  embeds or logs a connection string.
- [ ] Existing solution warnings remain, including the vulnerable legacy SQL
  client package and nullable/unreachable-code warnings outside the EF slice.
