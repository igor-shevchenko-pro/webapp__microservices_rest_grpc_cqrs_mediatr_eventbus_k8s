using CommandCenter.Core.Entities;
using CommandCenter.Core.Enums;
using System.Collections.Generic;

namespace CommandCenter.Core.Helpers.EntityDbInitializeHelpers
{
    public class ProtocolDataDbInitializeHelper
    {
        private static readonly ProtocolDataDbInitializeHelper _instance = new ProtocolDataDbInitializeHelper();
        public static ProtocolDataDbInitializeHelper Current => _instance;

        public List<Protocol> DefaultCollection { get; private set; } = new List<Protocol>();
        public List<Protocol> FullCollection { get; private set; } = new List<Protocol>();

        private ProtocolDataDbInitializeHelper()
        {
            Initialize();
            FullCollection.AddRange(InitializeEnglish());
        }

        private void Initialize()
        {
            DefaultCollection.Add(new Protocol() 
            { 
                Name = "LMP", 
                Description = "Link Management Protocol. Used for control of the radio link between two devices, highe, dmv, querying device abilities and power control. Implemented on the controller.", 
                Type = ProtocolType.Bluetooth 
            });
            DefaultCollection.Add(new Protocol() 
            { 
                Name = "TCP", 
                Description = "Transmission Control Protocol. TCP is connection-oriented, and a connection between client and server is established before data can be sent.", 
                Type = ProtocolType.IP 
            });
            DefaultCollection.Add(new Protocol() 
            { 
                Name = "HTTP", 
                Description = "Hypertext Transfer Protocol is an application layer protocol in the Internet protocol suite model for distributed, collaborative, hypermedia information systems.", 
                Type = ProtocolType.Web 
            });
        }

        private List<Protocol> InitializeEnglish()
        {
            return DefaultCollection;
        }
    }
}
