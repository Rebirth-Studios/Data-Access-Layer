# Database schemas

The table model is divided by lifecycle and ownership rather than by feature name alone.

| Schema | Tables | Purpose | Current assignment rule |
| --- | ---: | --- | --- |
| `content` | 352 | Relatively static game definitions, lookup data, and scriptable content | All tables not assigned to another domain |
| `runtime` | 44 | Mutable live game and player state | `characters*`, `instanced*`, `spawned*`, `spawner*`, and `questsGenerated` |
| `history` | 9 | Append-oriented audit and gameplay history | `history*`, except the operational `historyBatchProcessing` table |
| `identity` | 1 | Account and external identity data | `playersAccounts` |
| `ops` | 46 | Import, staging, diagnostics, maintenance, and internal tables | Leading `_` names plus `ab`, `DB_Errors`, `historyBatchProcessing`, `Internal_FK_Definition_Storage`, `lastUpdatedTables`, `Table_1`, and `test` |
| `api` | 0 | Future stable application-facing procedures and views | Created now; intentionally empty during the compatibility phase |
| `dbo` | 0 tables | Shared functions, views, procedures, and temporary compatibility surface | Modules remain here until callers and permissions are inventoried |

The physical folders under each schema are the table inventory and source of truth. The same assignment rules are implemented in `ElysiumDatabase/Configuration/DatabaseSchemas.cs` so legacy DataTable calls can qualify a table name without changing every caller at once.

## Deployment sequence for an existing database

1. Back up the database and rehearse the complete operation on a disposable copy.
2. Build the DACPAC and confirm the SQL project has no errors.
3. Run `Scripts/Migrations/001_MoveTablesToDomainSchemas.sql` as a separate, one-time operation. Its transaction either transfers all eligible `dbo` tables or rolls back.
4. Generate a new SqlPackage deployment script against the transferred database. Review it for table drops, data-loss warnings, permission changes, and the 34 definitions currently excluded from the model.
5. Publish only after that script is approved, then smoke-test stored procedures, DataTable reads/writes, and the EF player-account mapping.

Do not put the transfer migration in the SQL project's pre-deployment script. The deployment plan is calculated before pre-deployment SQL executes, so those transfers would occur too late to change an already generated drop/create plan.

## Compatibility boundary

Stored procedures, views, and functions keep their existing `dbo` names in this pass, while their table references are schema-qualified. Moving those modules to `api` is a later compatibility change because it affects every caller and database permission. The `api` schema exists now so that migration can happen incrementally.
