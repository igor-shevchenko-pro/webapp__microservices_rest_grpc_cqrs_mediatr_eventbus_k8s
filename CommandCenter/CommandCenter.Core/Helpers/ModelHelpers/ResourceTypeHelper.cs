using CommandCenter.Core.Enums;
using CommandCenter.Core.Interfaces.Helpers;
using System;

namespace CommandCenter.Core.Helpers.ModelHelpers
{
    public class ResourceTypeHelper : IResourceTypeHelper
    {
        public ResourceType GetResourceType<T>(T model)
        {
            string typeName = model.GetType().Name.Replace("GetResource", "");

            if (Enum.TryParse(typeName, out ResourceType type))
            {
                return type;
            }
            else
            {
                // TODO - need to customise exception
                throw new Exception();
            }
        }

        public ResourceType GetResourceType<T>()
        {
            string typeName = typeof(T).Name.Replace("GetResource", "");

            if (Enum.TryParse(typeName, out ResourceType type))
            {
                return type;
            }
            else
            {
                // TODO - need to customise exception
                throw new Exception();
            }
        }
    }
}
