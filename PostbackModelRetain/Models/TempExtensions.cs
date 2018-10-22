using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostbackModelRetain.Models
{
    public static class TempExtensions
    {
        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            if (!tempData.ContainsKey(key)) return default(T);
            string value = tempData[key] as string;
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);

        }

        public static void Save<T>(this ITempDataDictionary tempdata,string key, T value) where T:class
        {
            tempdata[key] = JsonConvert.SerializeObject(value);
            
        }
    }
}
