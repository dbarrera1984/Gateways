using System.Data.Entity;

namespace Musala.GatewayMgmt.Repositories.Ef
{
    /// <summary>
    /// Used to initialize the GatewayMgmtContext.
    /// </summary>
    public static class GatewayMgmtContextInitializer
    {
        /// <summary>
        /// Sets the IDatabaseInitializer for the application.
        /// </summary>
        /// <param name="dropDatabaseIfModelChanges">When true, uses the MyDropCreateDatabaseIfModelChanges to recreate the database when necessary.
        /// Otherwise, database initialization is disabled by passing null to the SetInitializer method.
        /// </param>
        public static void Init(bool dropDatabaseIfModelChanges)
        {
            if (dropDatabaseIfModelChanges)
            {
                Database.SetInitializer(new MyDropCreateDatabaseIfModelChanges());
                using (var db = new GatewayMgmtContext())
                {
                    db.Database.Initialize(false);
                }
            }
            else
            {
                Database.SetInitializer<GatewayMgmtContext>(null);
            }
        }
    }
}
