using CommandCenter.Core.Entities;
using CommandCenter.Core.Interfaces.Entities.Base;
using System.Collections.Generic;

namespace CommandCenter.Core.Helpers.EntityDbInitializeHelpers.Base
{
    public class BaseDbInitializeHelper
    {
        private static readonly BaseDbInitializeHelper _instance = new BaseDbInitializeHelper();
        public static BaseDbInitializeHelper Current => _instance;

        private BaseDbInitializeHelper()
        {
        }

        public FrameworkDataDbInitializeHelper Frameworks => FrameworkDataDbInitializeHelper.Current;
        public ProtocolDataDbInitializeHelper Protocols => ProtocolDataDbInitializeHelper.Current;

        public IEnumerable<T> GetItems<T>()
            where T : class, IBaseEntity
        {
            if (typeof(T).Name == nameof(Framework))
            {
                return (IEnumerable<T>)Frameworks.FullCollection;
            }
            if (typeof(T).Name == nameof(Protocol))
            {
                return (IEnumerable<T>)Protocols.FullCollection;
            }

            return new List<T>();
        }
    }
}
