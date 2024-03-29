﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Exceptions
{
    public class ProcessNotStartException : Exception
    {
        private const string txt = "did not start";
        public ProcessNotStartException() : base($"Process {txt}") { }

        public ProcessNotStartException(in string msg) : base($"{msg} {txt}") { }

        public ProcessNotStartException(in string msg, Exception inner) : base($"{msg} {txt}", inner) { }
    }
}
