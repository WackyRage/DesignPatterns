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
    }
}
