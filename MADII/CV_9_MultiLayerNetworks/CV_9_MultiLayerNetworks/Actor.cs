using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_9_MultiLayerNetworks
{
    public class Actor
    {
        public string Name { get; }


        public Actor(string name)
        {
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Actor);
        }

        protected bool Equals(Actor other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
