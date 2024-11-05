using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Citizen : Person
    {
        
        public override char Symbol => 'M';

        
        public Citizen()
        {
            
            Inventory.Add("Nycklar");
            Inventory.Add("Pengar");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Klocka");
        }

        
        public override string CollidesWith(Person person, Random rnd)
        {
            
            if (person is Thief && Inventory.Count > 0)
            {
               
                int index = rnd.Next(Inventory.Count);
                person.Inventory.Add(Inventory[index]);              
                Inventory.RemoveAt(index);
                return Message.Robbery;
            }

            
            return null;
        }
    }
}








