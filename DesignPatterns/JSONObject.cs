using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public JSONObject(object Object, String ObjectType)
        {
            this.ObjectType = ObjectType;
            this.Object = Object;
        }

        public static string ObjectToJSON(object obj)
        {
            JSONObject JO = new(obj);
            string jsonString = JsonSerializer.Serialize(JO, typeof(JSONObject), O);
            return jsonString;
        }

        public static string ObjectToJSON(object obj, String type)
        {
            JSONObject JO = new(obj, type);
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
            string jsonString = JSONObject.ObjectToJSON(LJO, list.GetType().FullName);
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
            JSONObject JO = (JSONObject)JsonSerializer.Deserialize(jsonString, typeof(JSONObject));
            JsonElement JE = (JsonElement)JO.Object;
            List<JSONObject> LJO = (List<JSONObject>)JsonSerializer.Deserialize(JE.GetRawText(), typeof(List<JSONObject>));
            List<T> returnList = (List<T>)Activator.CreateInstance(Type.GetType(JO.ObjectType));
            foreach (JSONObject JObject in LJO)
            {
                JsonElement JE2 = (JsonElement)JObject.Object;
                T temp = (T)JsonSerializer.Deserialize(JE2.GetRawText(), Type.GetType(JObject.ObjectType));
                returnList.Add(temp);
            }
            return returnList;
        }
    }
}
