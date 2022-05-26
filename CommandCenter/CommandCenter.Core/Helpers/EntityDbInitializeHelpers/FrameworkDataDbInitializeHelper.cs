using CommandCenter.Core.Entities;
using System;
using System.Collections.Generic;

namespace CommandCenter.Core.Helpers.EntityDbInitializeHelpers
{
    public class FrameworkDataDbInitializeHelper
    {
        private static readonly FrameworkDataDbInitializeHelper _instance = new FrameworkDataDbInitializeHelper();
        public static FrameworkDataDbInitializeHelper Current => _instance;

        public List<Framework> DefaultCollection { get; private set; } = new List<Framework>();
        public List<Framework> FullCollection { get; private set; } = new List<Framework>();

        private FrameworkDataDbInitializeHelper()
        {
            Initialize();
            FullCollection.AddRange(InitializeEnglish());
        }

        private void Initialize()
        {
            DefaultCollection.Add(new Framework() { Name = "Entity Framework", Version = "8.5.14", ReleaseDate = new DateTime(2021, 10, 01) });
            DefaultCollection.Add(new Framework() { Name = "Laravel", Version = "10.3.5", ReleaseDate = new DateTime(2015, 05, 25) });
            DefaultCollection.Add(new Framework() { Name = "TensorFlow", Version = "9.4.1", ReleaseDate = new DateTime(2018, 12, 12) });
        }

        private List<Framework> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
