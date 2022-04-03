using DistributionCenter.Core.Entities;
using System.Collections.Generic;

namespace DistributionCenter.Core.Helpers.EntityDbInitializeHelpers
{
    public class PlatformDataDbInitializeHelper
    {
        private static readonly PlatformDataDbInitializeHelper _instance = new PlatformDataDbInitializeHelper();
        public static PlatformDataDbInitializeHelper Current => _instance;

        public List<Platform> DefaultCollection { get; private set; } = new List<Platform>();
        public List<Platform> FullCollection { get; private set; } = new List<Platform>();

        private PlatformDataDbInitializeHelper()
        {
            Initialize();
            FullCollection.AddRange(InitializeEnglish());
        }

        private void Initialize()
        {
            DefaultCollection.Add(new Platform() { Name = ".Net", Publisher = "Microsoft", Cost = "Free" });
            DefaultCollection.Add(new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" });
            DefaultCollection.Add(new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
        }

        private List<Platform> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
