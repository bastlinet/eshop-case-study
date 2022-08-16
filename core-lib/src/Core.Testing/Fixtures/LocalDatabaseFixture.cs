using Respawn;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.Testing.Fixtures
{
    public abstract class LocalDatabaseFixture : IAsyncLifetime
    {
        public virtual string BaseConnectionString => @"Data Source=(localdb)\MSSQLLocalDB; Integrated Security=True;";

        protected readonly string _dbName;

        private readonly Checkpoint _emptyDatabaseCheckpoint;

        public string ConnectionString { get; }

        public bool IsDbExists { get; set; }

        public LocalDatabaseFixture(string dbName)
        {
#if DEBUG
            _dbName = dbName + "-" + "TEST";
#else
            _dbName = dbName + "-" + System.Guid.NewGuid().ToString();
#endif
            _emptyDatabaseCheckpoint = new Checkpoint
            {
                // Reseed identity columns
                WithReseed = true,
                TablesToIgnore = new Respawn.Graph.Table[]
                {

                },
            };

            var builder = new SqlConnectionStringBuilder(BaseConnectionString)
            {
                InitialCatalog = _dbName
            };

            ConnectionString = builder.ToString();
        }

        public async Task InitializeAsync()
        {
            using (var connection = new SqlConnection(BaseConnectionString))
            {
                await connection.OpenAsync();
                IsDbExists = (bool)await ExecuteDbCommandWithObjectAsync(connection, $"select (case when EXISTS(SELECT * FROM sys.databases WHERE name = '{_dbName}') then cast(1 as bit) else cast(0 as bit) end)");
                if (IsDbExists)
                {
                    await ExecuteDbCommandAsync(connection, $"USE [{_dbName}]");
                }
            }

            await InitializeDatabaseAsync();

            using (var connection = new SqlConnection(BaseConnectionString))
            {
                await connection.OpenAsync();
                await ExecuteDbCommandAsync(connection, $"USE [{_dbName}]");
            }
        }

        public async Task DisposeAsync()
        {
#if DEBUG
            await Task.CompletedTask;
#else

            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                await ExecuteDbCommandAsync(connection, $"EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{_dbName}'");
                await ExecuteDbCommandAsync(connection, "USE [master]");
                await ExecuteDbCommandAsync(connection, $"ALTER DATABASE [{_dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                await ExecuteDbCommandAsync(connection, "USE [master]");
                await ExecuteDbCommandAsync(connection, $"DROP DATABASE [{_dbName}]");
            }
#endif
        }

        public async Task ResetDatabaseAsync()
        {
            await _emptyDatabaseCheckpoint.Reset(ConnectionString);
        }

        protected abstract Task InitializeDatabaseAsync();

        protected async Task ExecuteDbCommandAsync(SqlConnection connection, string commandText)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = commandText;
                await cmd.ExecuteNonQueryAsync();
            }
        }

        protected async Task<object> ExecuteDbCommandWithObjectAsync(SqlConnection connection, string commandText)
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = commandText;
                return await cmd.ExecuteScalarAsync();
            }
        }
    }
}
