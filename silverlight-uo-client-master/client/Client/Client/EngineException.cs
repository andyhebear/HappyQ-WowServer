using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class EngineException : Exception
    {
        public EngineException(Exception e) : base("An error ocurred, please see the inner expcetion for details", e) { }
    }
}
