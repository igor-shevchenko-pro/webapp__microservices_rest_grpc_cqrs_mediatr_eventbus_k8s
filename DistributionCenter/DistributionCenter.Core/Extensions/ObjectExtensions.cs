using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace DistributionCenter.Core.Extensions
{
    [SuppressMessage("Minor Code Smell", "S4225:Extension methods should not extend \"object\"", Justification = "<Pending>")]
    public static class ObjectExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object?> expando = new ExpandoObject();
            foreach (PropertyDescriptor? property in TypeDescriptor.GetProperties(value.GetType()))
            {
                if(property == null) 
                {
                    continue;
                }

                expando.Add(property.Name, property.GetValue(value));

            }
            return expando;
        }

        public static void CopyPropertiesFrom(this object destination, object source)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceItem in sourceProperties)
            {
                foreach (var destinationItem in destinationProperties)
                {
                    if (sourceItem.Name == destinationItem.Name && sourceItem.PropertyType == destinationItem.PropertyType)
                    {
                        if(Constants.BASE_PROPERTIES_TO_SKIP_WHEN_COPY.Contains(destinationItem.Name))
                        {
                            continue;
                        }

                        destinationItem.SetValue(destination, sourceItem.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}
