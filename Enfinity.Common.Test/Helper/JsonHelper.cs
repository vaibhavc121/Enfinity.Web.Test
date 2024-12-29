using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Bson;

namespace Enfinity.Common.Test
{
    public static class JsonHelper
    {
        public static List<T> ConvertJsonListDataModel<T>(string fileData, string section)
        {
            //string json = File.ReadAllText(filePath);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(fileData);
            return jsonData.ContainsKey(section) ? jsonData[section] : new List<T>();
        }        
        public static T ConvertJsonDataModel<T>(string fileData)
        {            
            var jsonData = JsonConvert.DeserializeObject<T>(fileData);
            return jsonData;
        }
    }
}
