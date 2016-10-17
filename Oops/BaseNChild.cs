using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops
{
    public class Base
    {
        public string Name;
        public int NameLength;

        public virtual void InitName()
        {
            Name = "Om";
        }
        public Base()
        {
            InitName();
            NameLength = Name.Length;
        }

        
    }

    public class Child:Base
    {
        public override void InitName()
        {
            Name = null;
        }
    }
}
