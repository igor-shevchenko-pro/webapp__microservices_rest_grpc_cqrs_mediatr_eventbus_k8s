using CommandCenter.Core.Entities;
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
            DefaultCollection.Add(new Framework() 
            { 
                Name = "Entity Framework", 
                Version = "8.5.14", 
                Description = "Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with many databases, including SQL Database (on-premises and Azure), SQLite, MySQL, PostgreSQL, and Azure Cosmos DB."
            });
            DefaultCollection.Add(new Framework() 
            { 
                Name = "Laravel", 
                Version = "10.3.5", 
                Description = "Laravel is a web application framework with expressive, elegant syntax. We’ve already laid the foundation — freeing you to create without sweating the small things."
            });
            DefaultCollection.Add(new Framework() 
            { 
                Name = "TensorFlow", 
                Version = "9.4.1", 
                Description = "TensorFlow is an end-to-end open source platform for machine learning. It has a comprehensive, flexible ecosystem of tools, libraries and community resources that lets researchers push the state-of-the-art in ML and developers easily build and deploy ML powered applications." 
            });
        }

        private List<Framework> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
