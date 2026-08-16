# Hybrid Entity Framework access

`ElysiumDatabase.Schema.sqlproj` owns the database schema. EF Core migrations and
`Database.EnsureCreated` must not be used in this project.

The first EF slice maps `dbo.playersAccounts`. `PlayerAccountStore` provides
no-tracking queries, immediate account creation (so SQL Server can return the
identity), and coalesced deferred login/admin updates. The existing DataTables
and dictionaries remain the hot game-server read cache.

Both access paths use the same connection string. Pass it to
`DataTableStoredProcs` or set it outside source control for the current process:

```powershell
$env:ELYSIUM_DB_CONNECTION = '<connection string>'
```

Call `PlayerAccountStore.QueueLoginUpdate` or `QueueAdminUpdate` during gameplay.
`DataTableStoredProcs.ProcessSqlUpdates` flushes those changes together with the
existing deferred DataTable writes.
