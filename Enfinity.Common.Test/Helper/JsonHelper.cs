using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class JsonHelper
    {
        public static List<T> LoadJsonData<T>(string fileData, string section)
        {
            //string json = File.ReadAllText(filePath);
            var jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(fileData);
            return jsonData.ContainsKey(section) ? jsonData[section] : new List<T>();
        }
    }
}
