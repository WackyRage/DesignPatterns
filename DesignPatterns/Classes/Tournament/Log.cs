using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Log
    {
        private string Message;
        private DateTime Date;
        private bool Resolved;

        public Log(string M, DateTime D, bool R)
        {
            Message = M;
            Date = D;
            Resolved = R;
        }

        public void SetMessage(string M)
        {
            Message = M;
        }

        public void SetDate(DateTime D)
        {
            Date = D;
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

        public string GetMessage()
        {
            return Message;
        }

        public DateTime GetDate() 
        { 
            return Date; 
        }

        public bool GetResolved()
        {
            return Resolved;
        }

    }
}
