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
            DefaultCollection.Add(new Platform() { Name = "Doro", Version = "1.0.1", FileSize = 11.7 });
            DefaultCollection.Add(new Platform() { Name = "Sata", Version = "10.4", FileSize = 125.4 });
            DefaultCollection.Add(new Platform() { Name = "Maxis", Version = "4.7.3", FileSize = 32.0 });
        }

        private List<Platform> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
