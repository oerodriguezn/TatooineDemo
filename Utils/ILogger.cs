﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    interface ILogger
    {
        void Log(string Message, Exception ex = null);
    }
}
