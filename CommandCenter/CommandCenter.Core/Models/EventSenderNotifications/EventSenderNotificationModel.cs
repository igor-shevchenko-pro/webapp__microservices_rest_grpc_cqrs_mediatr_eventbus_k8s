using CommandCenter.Core.Enums;
using Newtonsoft.Json;
using System;

namespace CommandCenter.Core.Models.EventSenderNotifications
{
    public class EventSenderNotificationModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; } = default!;

        [JsonProperty("created")] 
        public DateTime Created { get; set; }


        [JsonProperty("notificationType")]
        public NotificationType NotificationType { get; set; }

        [JsonProperty("notificationStatus")]
        public NotificationStatus NotificationStatus { get; set; }

        [JsonProperty("notificationDataType")]
        public NotificationDataType NotificationDataType { get; set; }


        [JsonProperty("fromUserId")] 
        public string? FromUserId { get; set; } = default!;

        [JsonProperty("toUserId")] 
        public string? ToUserId { get; set; } = default!;


        [JsonProperty("data")]
        public string Data { get; set; } = default!;
    }
}
