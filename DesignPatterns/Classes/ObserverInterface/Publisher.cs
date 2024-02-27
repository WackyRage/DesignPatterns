using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal interface Publisher
    {
        public void Subscribe();
        public void Unsubscribe();
        public void NotifySubscriber();
    }
}
