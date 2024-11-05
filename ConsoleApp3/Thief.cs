using System;
using System.Collections.Generic;
using TjuvOPolis;

namespace TjuvOPolis
{
    internal class Thief : Person
    {
        
        public override char Symbol => 'T';

        
        public override string CollidesWith(Person person, Random rnd)
        {
            
            if (person is Citizen  && person.Inventory.Count > 0)
            {
                int index = rnd.Next(person.Inventory.Count);
                Inventory.Add(person.Inventory[index]);              
                person.Inventory.RemoveAt(index);           
                return Message.Robbery;
            }
            if (person is Police && Inventory.Count > 0)
            {
                person.Inventory.AddRange(Inventory);
                Inventory.Clear();
                return Message.Arrest;
            }


            return null;
        }
    }
}

