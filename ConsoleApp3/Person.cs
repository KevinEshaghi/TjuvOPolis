using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal abstract class Person
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
        
        public virtual char Symbol  { get; set; }
        public abstract string CollidesWith(Person person, Random rnd);
        public List<string> Inventory { get; set; } = new List<string>();


    }
}
