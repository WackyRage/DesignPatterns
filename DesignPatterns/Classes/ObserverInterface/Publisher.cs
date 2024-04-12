using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal interface Publisher
    {
        protected void subscribe(Subscriber S);
        protected void unsubscribe(Subscriber S);
        protected void notifySubscriber();
    }
}
