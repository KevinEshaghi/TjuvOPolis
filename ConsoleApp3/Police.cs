using System;
using System.Collections.Generic;
using TjuvOPolis;

namespace TjuvOchPolis
{
    internal class Police : Person
    {
        
        public override char Symbol => 'P';

        public override string CollidesWith(Person person, Random rnd)
        {
            
            if (person is Thief  && person.Inventory.Count > 0)
            {
                
                Inventory.AddRange(person.Inventory);              
                person.Inventory.Clear();              
                return Message.Arrest;
            }

            // Om ingen kollision sker, returnera null
            return null;
        }
    }
}

