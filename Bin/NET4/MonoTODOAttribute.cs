using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System {
    public class MonoTODOAttribute:System.Attribute {
        public string _desc;
        public MonoTODOAttribute() { 
        }
        public MonoTODOAttribute(string desc) {
            _desc = desc;
        }
    }
}
