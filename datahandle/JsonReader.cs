using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;

namespace SeleniumFramework.datatest
{
    internal class JsonReader
    {
        [Obsolete]
        public static object[] GetJsonDataSet()
        {
            var jsonFilePath = ConfigurationSettings.AppSettings["DataPath"];

            var json = File.ReadAllText(jsonFilePath);

            var jsonDictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(json);

            var data = (ArrayList) jsonDictionary["Data"];

            var dataSet = data.ToArray();

            var returnData = new object[dataSet.Length];

            var i = 0;

            foreach (var item in data)
            {
                var a = (Dictionary<string, object>) item;
                returnData[i] = new[] {a["Key"], a["Expected"]};
                i++;
            }

            return returnData;
        }
    }
}