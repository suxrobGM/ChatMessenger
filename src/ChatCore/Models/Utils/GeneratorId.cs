using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatCore.Models.Utils
{
    public static class GeneratorId
    {
        public static string Generate(string prefix)
        {
            return $"{prefix}_{DateTime.Now.ToString("yyyyMMddHHmmssffffff")}";
        }

        public static string Generate()
        {
            return $"{DateTime.Now.ToString("yyyyMMddHHmmssffffff")}";
        }
    }
}
