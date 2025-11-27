// ITConfig

namespace ITConfig
{
    #region Using Directives
    using System;
    using System.IO;
    using WixToolset.Dtf.WindowsInstaller;
    #endregion

    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Must specify the BeltTestPackage path and the Company name");

                return -1;
            }

            var originalMsiPath = Path.GetFullPath(args[0]);
            var tempMSIPath     = Path.GetTempFileName();
            var companyName     = args[1];

            // Output MST path
            var outputMstPath = Path.ChangeExtension(originalMsiPath, ".mst");

            // Open the MSI database and update the 'CUSTOMER' property
            // Connect to the original MSI, copy it to a temp file, and modify that.
            using (var db = new Database(originalMsiPath, tempMSIPath))
            {
                // Queries are case-sensitive. 'Property' != 'PROPERTY'.
                // Use db.ExecuteQuery(query) to run a SELECT query and get a value back
                const string selectQuery   = "SELECT Value from Property where Property = 'CUSTOMER'";
                var          customerValue = db.ExecuteScalar(selectQuery);
                Console.WriteLine($"Current CUSTOMER value: {customerValue}. Updating to {companyName}");

                var query = $"UPDATE Property SET Value='{companyName}' WHERE Property='CUSTOMER'";

                // Use db.Execute(query) to run an UPDATE/DELETE query
                db.Execute(query);

                // Save changes
                db.Commit();
            }

            // Create the transform
            using (var originalDb = new Database(originalMsiPath))
            {
                using (var updatedDb = new Database(tempMSIPath))
                {
                    updatedDb.GenerateTransform(originalDb, outputMstPath);
                    updatedDb.CreateTransformSummaryInfo(
                        originalDb,
                        outputMstPath,
                        TransformErrors.None,                                                         // Ignore transform errors
                        TransformValidations.UpgradeCode | TransformValidations.NewEqualBaseVersion); // Ensure that the UpgradeCode and Version are the same
                }
            }

            return 0;
        }
    }
}