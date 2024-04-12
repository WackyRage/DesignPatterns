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
    // Class to act as the default object to save in the Json string
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

        // Method to convert any object to a JSONString
        public static string ObjectToJSON(object obj)
        {
            JSONObject JO = new(obj);
            string jsonString = JsonSerializer.Serialize(JO, typeof(JSONObject), O);
            return jsonString;
        }

        // Method to convert any list to a JSONString
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

        // Method to convert a JSONString back into a generic Object
        public static object JSONToObject(string jsonString)
        {
            JSONObject JO = (JSONObject)JsonSerializer.Deserialize(jsonString, typeof(JSONObject));
            JsonElement JE = (JsonElement)JO.Object;
            object obj = JsonSerializer.Deserialize(JE.GetRawText(), Type.GetType(JO.ObjectType));
            
            return obj;
        }

        // Method to convert a JSONString into a List of the Type T
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

        // Method to save a List of JSONStrings to a File
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
            string path = @"E:\Github Desktop\Repositories\Design Patterns\DesignPatterns\SaveData";
                          //@"D:\Users\frank\source\repos\DesignPatterns\SaveData";
                          //@".\SaveData";
            path = Path.Combine(path, FileName);
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

        // Method to read a JSONFile
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

            string path = @"E:\Github Desktop\Repositories\Design Patterns\DesignPatterns\SaveData";
                          //@"D:\Users\frank\source\repos\DesignPatterns\SaveData";
                          //@".\SaveData";
            string jsonString = "";
            using (StreamReader sr = new StreamReader(Path.Combine(path, FileName)))
            {
                jsonString = sr.ReadToEnd();
            }
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            return list;
        }
    }
}
