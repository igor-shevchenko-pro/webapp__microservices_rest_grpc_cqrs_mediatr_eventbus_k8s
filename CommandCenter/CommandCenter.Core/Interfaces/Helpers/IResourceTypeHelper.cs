using CommandCenter.Core.Enums;

namespace CommandCenter.Core.Interfaces.Helpers
{
    public interface IResourceTypeHelper
    {
        ResourceType GetResourceType<T>(T model);
        ResourceType GetResourceType<T>();
    }
}
