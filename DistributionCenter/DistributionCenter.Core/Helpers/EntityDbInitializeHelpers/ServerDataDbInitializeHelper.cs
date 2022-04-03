using DistributionCenter.Core.Entities;
using DistributionCenter.Core.Entities.Enums;
using System.Collections.Generic;

namespace DistributionCenter.Core.Helpers.EntityDbInitializeHelpers
{
    public class ServerDataDbInitializeHelper
    {
        private static readonly ServerDataDbInitializeHelper _instance = new ServerDataDbInitializeHelper();
        public static ServerDataDbInitializeHelper Current => _instance;

        public List<Server> DefaultCollection { get; private set; } = new List<Server>();
        public List<Server> FullCollection { get; private set; } = new List<Server>();

        private ServerDataDbInitializeHelper()
        {
            Initialize();
            FullCollection.AddRange(InitializeEnglish());
        }

        private void Initialize()
        {
            DefaultCollection.Add(new Server() { Name = "web_server_name" , Type = ServerType.Web });
            DefaultCollection.Add(new Server() { Name = "mail_server_name", Type = ServerType.Mail });
            DefaultCollection.Add(new Server() { Name = "db_server_name", Type = ServerType.DataBase });
        }

        private List<Server> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
