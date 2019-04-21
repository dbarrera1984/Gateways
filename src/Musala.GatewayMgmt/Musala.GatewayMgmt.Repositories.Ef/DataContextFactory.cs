using Musala.Infrastructure.DataContextStorage;

namespace Musala.GatewayMgmt.Repositories.Ef
{
    /// <summary>
    /// Manages instances of the GatewayMgmtContext and stores them in an appropriate storage container.
    /// </summary>
    public static class DataContextFactory
    {
        /// <summary>
        /// Clears out the current GatewayMgmtContext.
        /// </summary>
        public static void Clear()
        {
            var dataContextStorageContainer = DataContextStorageFactory<GatewayMgmtContext>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        /// <summary>
        /// Retrieves an instance of GatewayMgmtContext from the appropriate storage container or
        /// creates a new instance and stores that in a container.
        /// </summary>
        /// <returns>An instance of GatewayMgmtContext.</returns>
        public static GatewayMgmtContext GetDataContext()
        {
            var dataContextStorageContainer = DataContextStorageFactory<GatewayMgmtContext>.CreateStorageContainer();
            var dataContext = dataContextStorageContainer.GetDataContext();
            if (dataContext == null)
            {
                dataContext = new GatewayMgmtContext();
                dataContextStorageContainer.Store(dataContext);
            }
            return dataContext;
        }
    }
}
