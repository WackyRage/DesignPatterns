using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace DesignPatterns
{
    internal class JSONObject
    {
        static readonly JsonSerializerOptions O = new() { IncludeFields = true };
        public string ObjectType { get; set; }
        public object Object { get; set; }

        [JsonConstructor]
        public JSONObject(object Object)
        {
            this.ObjectType = Object.GetType().FullName;
            this.Object = Object;
        }

        public static string ObjectToJSON(object obj)
        {
            JSONObject JO = new(obj);
            string jsonString = JsonSerializer.Serialize(JO, typeof(JSONObject), O);
            return jsonString;
        }

        public static string ListToJSON<T>(List<T> list)
        {
            List<JSONObject> LJO = new();
            foreach (T obj in list)
            {
                LJO.Add(new JSONObject(obj));
            }
            string jsonString = JsonSerializer.Serialize(LJO, typeof(List<JSONObject>), O);
            return jsonString;
        }

        public static object JSONToObject(string jsonString)
        {
            JSONObject JO = (JSONObject)JsonSerializer.Deserialize(jsonString, typeof(JSONObject));
            JsonElement JE = (JsonElement)JO.Object;
            object obj = JsonSerializer.Deserialize(JE.GetRawText(), Type.GetType(JO.ObjectType));
            
            return obj;
        }

        public static List<T> JSONToList<T>(string jsonString)
        {
            List<JSONObject> LJO = (List<JSONObject>)JsonSerializer.Deserialize(jsonString, typeof(List<JSONObject>));
            List<T> returnList = new();
            foreach (JSONObject JObject in LJO)
            {
                JsonElement JE = (JsonElement)JObject.Object;
                T temp = (T)JsonSerializer.Deserialize(JE.GetRawText(), Type.GetType(JObject.ObjectType));
                returnList.Add(temp);
            }
            return returnList;
        }

        public static void WriteJSONToFile(List<string> jsonStrings, string FileName)
        {
            /*
            var directory = new DirectoryInfo(null ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            string path = directory.FullName;
            */
            string path = //@"E:\Github Desktop\Repositories\Design Patterns\DesignPatterns";
                          @"D:\Users\frank\source\repos\DesignPatterns";
            path = Path.Combine(path, "SaveData", FileName);
            if(!File.Exists(path))
            {
                File.Create(path).Close();
            }
            string jsonString = JSONObject.ListToJSON(jsonStrings);
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.Write(jsonString);
            }
        }

        public static List<string> ReadJSONFile(string FileName)
        {
            /*
            var directory = new DirectoryInfo(null ?? Directory.GetCurrentDirectory());
            Debug.WriteLine(directory.FullName);
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            string path = directory.FullName;
            */

            string path = //@"E:\Github Desktop\Repositories\Design Patterns\DesignPatterns";
                          @"D:\Users\frank\source\repos\DesignPatterns";
            string jsonString = "";
            using (StreamReader sr = new StreamReader(Path.Combine(path, "SaveData", FileName)))
            {
                jsonString = sr.ReadToEnd();
            }
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            return list;
        }
    }
}
