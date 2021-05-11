/*https://stackoverflow.com/questions/41367602/upload-files-and-json-in-asp-net-core-web-api*/

using System;

namespace beGreen.Library.Attributes

{
    public interface IJsonAttribute
    {
        object TryConvert(string modelValue, Type targertType, out bool success);
    }
}
