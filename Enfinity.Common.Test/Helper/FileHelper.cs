﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class FileHelper
    {
        public static string GetDataFile(string product, string module, string subFolder, string filename)
        {
            var fullFilePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, 1)
                                            + @":\Enfinity.Online\Enfinity.Web.Test\Enfinity." + product + ".Test.UI"

                + @"\Models\" + module + @"\" + subFolder + @"\" + filename + @".json";

            return GetFile(fullFilePath);            
        }

        public static string GetFile(string filename)
        {
            string result;
            if (!File.Exists(filename))
            {
                throw new Exception($"Invalid path or file:{filename} does not exists");
            }
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    result = streamReader.ReadToEnd();
                }
                //streamReader.Dispose();
                //fileStream.Dispose();
            }
            return result;
        }
    }
}