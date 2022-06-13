namespace CommandCenter.Core.Enums
{
    public enum NotificationType
    {
        // Base
        ModelAdd = 100,
        ModelDelete = 101,
        ModelUpdate = 102,
        ModelChangeStatus = 103,

        // User-communications
        UserOnline = 200,
        UserOffline = 201,
        UserMessage = 202,        

        // ToDoTask
        ChangeProgressStatus = 300,
    }
}
