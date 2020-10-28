using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class Orders
    {

        public Dictionary<string, List<Orders>> OrderDictionary { get; set; }
    }
}
