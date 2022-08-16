using Core.Testing.Fixtures;
using EshopDb.Common;
using Microsoft.SqlServer.Dac;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace EshopDb.Dapper.IntegrationTests.Fixtures
{
    [CollectionDefinition("DbContext")]
    public class DatabaseCollection : ICollectionFixture<EshopDbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class EshopDbFixture : LocalDatabaseFixture
    {
        private static readonly string SystemName = "EshopDb";
#if DEBUG
        private static Configuration BuildConfiguration => Configuration.Debug;
#else
        private static Configuration BuildConfiguration => Configuration.Release;
#endif

        public DatabaseContextOption DbContext { get; private set; }

        /// <summary>
        /// InMemoryDatabase vs Database
        /// </summary>
        private string RelativeDacPackPath => $@"{SystemName}.Database\bin\{BuildConfiguration}\{SystemName}.Database.dacpac";

        public EshopDbFixture()
                : base(SystemName)

        {
            DbContext = new DatabaseContextOption();
        }

        protected override async Task InitializeDatabaseAsync()
        {
            DbContext.ConnectionString = ConnectionString;
            var dacPackFilePath = GetDacPackPath();

            if (!IsDbExists && !string.IsNullOrEmpty(dacPackFilePath))
            {
                var directory = Path.GetDirectoryName(dacPackFilePath);
                var dacpacPaths = Directory.EnumerateFiles(directory, "*.dacpac");

                var instance = new DacServices(string.Format(ConnectionString, "master"));
                instance.Message += (object sender, DacMessageEventArgs eventArgs) => Console.WriteLine(eventArgs.Message.Message);

                foreach (var dacPackPath in dacpacPaths)
                {
                    if (dacPackPath.EndsWith("master.dacpac")) continue;

                    using (var dacPac = DacPackage.Load(dacPackPath))
                        instance.Deploy(dacPac, _dbName, upgradeExisting: true);
                }
            }

            await RunSeedAsync();
        }

        public string GetDacPackPath()
        {
            var applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var databaseProjectDirectory = RelativeDacPackPath.Split(Path.DirectorySeparatorChar)[0];
            var rootDirectory = TraverseUpAndStopAtRootOf(applicationDirectory, databaseProjectDirectory);

            string path = string.Empty;
            if (rootDirectory != null && RelativeDacPackPath != null)
            {
                path = Path.GetFullPath(Path.Combine(rootDirectory.FullName, RelativeDacPackPath));
            }

            if (!File.Exists(path))
            {
                path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{SystemName}.Database.dacpac"));
            }

            if (!File.Exists(path))
            {
                throw new InvalidDataException($"DACPAC file not found! '{path}'");
            }

            return path;
        }

        public static DirectoryInfo TraverseUpAndStopAtRootOf(string currentDirectory, string searchPattern)
        {
            var directory = new DirectoryInfo(currentDirectory);
            while (directory != null && !directory.GetDirectories(searchPattern).Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

        public async Task RunSeedAsync()
        {
            var relativeSeedPaths = new string[] {
            };

            foreach (var relativeSeedPath in relativeSeedPaths)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeSeedPath);
                await ExecuteScriptAsync(path);
            }
        }

        public async Task ExecuteScriptAsync(string path)
        {
            string script = File.ReadAllText(path);

            // split script on GO command
            var commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                foreach (string commandString in commandStrings)
                {
                    if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                    {
                        await ExecuteDbCommandAsync(connection, commandString);
                    }
                }
            }

        }

        private enum Configuration
        {
            Debug,
            Release
        }
    }
}
