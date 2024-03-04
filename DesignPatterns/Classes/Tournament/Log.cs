using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Log
    {
        public string Message { get; set; }
        public DateTime Date {  get; set; }
        public bool Resolved {  get; set; }

        public Log(string Message, DateTime Date, bool Resolved)
        {
            this.Message = Message;
            this.Date = Date;
            this.Resolved = Resolved;
        }

        public void ChangeResolved()
        {
            if (Resolved)
            {
                Resolved = false;
            } else
            {
                Resolved = true;
            }
        }

        public string ToJSON()
        {
            string Date = JSONObject.ObjectToJSON(this.Date);
            string Resolved = JSONObject.ObjectToJSON(this.Resolved);
            List<string> list = new() { Message, Date, Resolved };

            string jsonString = JSONObject.ListToJSON(list);
            return jsonString; 
        }

        public static Log FromJSON(string jsonString)
        {
            List<string> list = JSONObject.JSONToList<string>(jsonString);
            string Message = list[0];
            DateTime Date = (DateTime)JSONObject.JSONToObject(list[1]);
            bool Resolved = (bool)JSONObject.JSONToObject(list[2]);
            Log Log = new(Message, Date, Resolved);
            return Log;
        }
    }
}
