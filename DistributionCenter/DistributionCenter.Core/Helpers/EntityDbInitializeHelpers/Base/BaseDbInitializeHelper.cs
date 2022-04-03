using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace DistributionCenter.Core.Helpers.EntityDbInitializeHelpers.Base
{
    public class BaseDbInitializeHelper
    {
        private static readonly BaseDbInitializeHelper _instance = new BaseDbInitializeHelper();
        public static BaseDbInitializeHelper Current => _instance;

        private BaseDbInitializeHelper()
        {
        }

        public PlatformDataDbInitializeHelper Platforms => PlatformDataDbInitializeHelper.Current;
        public ServerDataDbInitializeHelper Servers => ServerDataDbInitializeHelper.Current;

        public IEnumerable<T> GetItems<T>() 
            where T : class, IBaseEntity
        {
            if (typeof(T).Name == nameof(Platform)) 
            {
                return (IEnumerable<T>)Platforms.FullCollection;
            }
            if (typeof(T).Name == nameof(Server))
            {
                return (IEnumerable<T>)Servers.FullCollection;
            }

            return new List<T>();
        }
    }
}
