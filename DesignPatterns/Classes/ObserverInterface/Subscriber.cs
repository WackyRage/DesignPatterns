﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal interface Subscriber
    {
        public void update(int value, string armyName, string playerName);
    }
}
