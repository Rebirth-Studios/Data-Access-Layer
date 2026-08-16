# Elysium database schema

This SDK-style SQL project is the source-controlled definition of the SQL Server schema. Building it produces `bin/<Configuration>/ElysiumDatabase.Schema.dacpac`.

## Object layout

Place each declarative database object in its own file, grouped by schema and object type. Tables are physically assigned to domain schemas; application-facing modules remain in `dbo` for compatibility during this migration:

```text
content/
runtime/
history/
identity/
ops/
  Tables/
dbo/
  Tables/
  Views/
  Stored Procedures/
  Functions/
  Types/
Schemas/
Scripts/
  Migrations/
  Pre-Deployment.sql
  Post-Deployment.sql
```

See [SCHEMAS.md](SCHEMAS.md) for the domain rules and deployment sequence.

The existing database should be extracted with SqlPackage and compared with the live database before this project is allowed to publish. Do not reconstruct the production schema from the C# `DataTable` definitions: they do not contain all keys, constraints, indexes, defaults, or stored-procedure bodies.

## Commands

```powershell
dotnet build .\ElysiumDatabase.Schema.sqlproj
```

Restore the repository-local Microsoft.SqlPackage tool, then extract the existing schema into a temporary directory with a connection string supplied outside source control:

```powershell
dotnet tool restore
dotnet tool run sqlpackage /Action:Extract /TargetFile:existing-schema.dacpac /SourceConnectionString:"<connection string>"
```

Never commit connection strings, publish profiles containing credentials, or extracted production data.

## Existing database migration

The project model moves all 452 tables out of `dbo`. Do **not** publish this DACPAC directly over an existing populated database: without an explicit transfer step, the schema comparison can treat the changes as drops and creates.

Use `Scripts/Migrations/001_MoveTablesToDomainSchemas.sql` as a reviewed, one-time migration on a disposable copy first. It performs `ALTER SCHEMA ... TRANSFER` inside a transaction, preserving table data and object identity. Run it as a separate operation before generating the DACPAC deployment plan, and then inspect that plan before publishing. It is intentionally excluded from `Pre-Deployment.sql` because DacFx calculates the deployment plan before a pre-deployment script runs.

No live database is changed by building this project.

## Imported-schema validation

The initial `Elysium_DEV` extraction contains 34 legacy functions, stored procedures, and security definitions with unresolved or ambiguous references. Those files remain source controlled as explicit `None` items, but are excluded from the DACPAC model until repaired. The project temporarily suppresses `SQL71502` warnings for the remaining ambiguous references. Remove the suppression incrementally as unqualified column names are corrected.
