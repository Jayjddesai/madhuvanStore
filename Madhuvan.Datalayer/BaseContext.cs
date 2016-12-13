using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Madhuvan.Datalayer;

namespace Madhuvan.Datalayer
{
    public static class BaseContext
    {
        public static MadhuvanMVCEntities GetDbContext()
        {
            MadhuvanMVCEntities context = new MadhuvanMVCEntities();

            // Sets the command timeout for all the commands
            ObjectContext objectContext = (context as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = int.MaxValue;
            return context;
        }
    }
}
