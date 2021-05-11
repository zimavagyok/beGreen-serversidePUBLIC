using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beGreen.WebApplication.extensions
{
    /// <summary>
    /// Maps the appSettings.json to a specific T object in DI
    /// use
    /// serviceCollection.AddSingleton<T>((_) => Configuration.GetObjectFromConfigSection<T>("_json section name"));
    /// </summary>
    public static class AppSettings
    {
        public static T GetObjectFromConfigSection<T>(this IConfiguration configurationRoot, string configSection) where T : new()
        {
            T result = new T();

            foreach (var propInfo in typeof(T).GetProperties())
            {
                var propertyType = propInfo.PropertyType;
                if (propInfo?.CanWrite ?? false)
                {
                    var value = Convert.ChangeType(configurationRoot.GetValue<string>($"{configSection}:{propInfo.Name}"), propInfo.PropertyType);
                    propInfo.SetValue(result, value, null);
                }
            }

            return result;
        }
    }
}
