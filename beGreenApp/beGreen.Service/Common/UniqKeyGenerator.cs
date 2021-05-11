using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beGreen.Services.Common
{
    public static class UniqKeyGenerator
    {
        public static string Generate()
        {
            string key = string.Empty;

            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(16)
                .ToList().ForEach(e => builder.Append(e));
            
            key = builder.ToString();

            return $"{Guid.NewGuid().ToString()} - {key}";
        }
    }
}
