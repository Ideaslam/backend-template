using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Model.Attributes
{
    public class MapToAttribute:Attribute
    {
        public MapToAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
