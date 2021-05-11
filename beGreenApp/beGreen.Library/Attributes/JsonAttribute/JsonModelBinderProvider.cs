using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace beGreen.Library.Attributes.JsonAttribute
{
    public class JsonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType)
            {
                string propName = context.Metadata.PropertyName;
                System.Reflection.PropertyInfo propInfo = context.Metadata.ContainerType?.GetProperty(propName);
                if (propName == null || propInfo == null)
                {
                    return null;
                }

                // Look for FromJson attributes
                object attribute = propInfo.GetCustomAttributes(typeof(FromJsonAttribute), false).FirstOrDefault();
                if (attribute != null)
                {
                    return new JsonModelBinder(context.Metadata.ModelType, attribute as IJsonAttribute);
                }
            }
            return null;
        }
    }
}
