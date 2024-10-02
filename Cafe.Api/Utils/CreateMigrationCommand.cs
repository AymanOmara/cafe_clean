using System;
using System.Diagnostics;

namespace Cafe.Api.Utils
{
    public class CreateMigrationCommand
    {
        public static void CreateMigration(string migrationName)
        {
            //var processCreateMigration = new Process
            //{
            //    StartInfo = new ProcessStartInfo
            //    {
            //        FileName = "dotnet",
            //        Arguments = $"dotnet ef migrations add ${migrationName} --project Cafe.Infrastructure --startup-project Cafe.Api --output-dir Migrations",
            //        RedirectStandardOutput = true,
            //        UseShellExecute = false,
            //        CreateNoWindow = true
            //    }
            //};
            //processCreateMigration.Start();
            //processCreateMigration.WaitForExit();
        }
    }
}