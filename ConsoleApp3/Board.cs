using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Board
    {
        public Board(int SizeX, int SizeY, int NrOfThieves, int NrOfPolice, int NrOfCitizens, Random Rnd)
        {
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.NrOfThieves = NrOfThieves;
            this.NrOfPolice = NrOfPolice;
            this.NrOfCitizens = NrOfCitizens;
            this.Rnd = Rnd;
            People = new List<Person>();
            Messages = new List<string>();

            ResetBoard();
        }

        public int SizeX { get; }
        public int SizeY { get; }
        public int NrOfThieves { get; }
        public int NrOfPolice { get; }
        public int NrOfCitizens { get; private set; }
        public Random Rnd { get; }
        protected List<Person> People { get; set; }

        public List<string> Messages { get; set; }

        public int Arrest { get; private set; }
        public int Robberies { get; private set; }

        public void ResetBoard()
        {
            People.Clear();
            CreatePersons<Thief>(NrOfThieves);
            CreatePersons<Citizen>(NrOfCitizens);
            CreatePersons<Police>(NrOfPolice);
        }

        private void CreatePersons<T>(object nrOfCitizens)
        {
            throw new NotImplementedException();
        }

        protected void CreatePersons<T>(int count) where T : Person, new()
        {
            for (int i = 0; i < count; i++)
            {
                var pos = GetRandomXY();
                var direction = GetRandomDirection();
                var person = new T();
                person.X = pos.Item1;
                person.Y = pos.Item2;
                person.DirectionX = direction.Item1;
                person.DirectionY = direction.Item2;
                People.Add(person);
            }
        }

        protected Tuple<int, int> GetRandomXY()
        {
            return new Tuple<int, int>(Rnd.Next(SizeX), Rnd.Next(SizeY));
        }

        protected Tuple<int, int> GetRandomDirection()
        {
            var direction = Rnd.Next(0, 8);
            switch (direction)
            {
                case 0: return new Tuple<int, int>(0, -1);
                case 1: return new Tuple<int, int>(1, -1);
                case 2: return new Tuple<int, int>(1, 0);
                case 3: return new Tuple<int, int>(1, 1);
                case 4: return new Tuple<int, int>(0, 1);
                case 5: return new Tuple<int, int>(-1, 1);
                case 6: return new Tuple<int, int>(-1, 0);
                case 7: return new Tuple<int, int>(-1, -1);
                default: return new Tuple<int, int>(0, 0);
            }
        }

        public void Update()
        {
            for (int i = 0; i < People.Count; i++)
            {
                var person = People[i];
                person.X += person.DirectionX;
                person.Y += person.DirectionY;

                person.X = person.X < 0 ? SizeX - 1 : person.X;
                person.Y = person.Y < 0 ? SizeY - 1 : person.Y;
                person.X = person.X > SizeX ? 0 : person.X;
                person.Y = person.Y > SizeY ? 0 : person.Y;

                for (int j = 0; j < People.Count; j++)
                {
                    if (i != j && person.X == People[j].X && person.Y == People[j].Y)
                    {
                        var msg = person.CollidesWith(People[j], Rnd);
                        if (msg != null)
                        {
                            if (msg == Message.Robbery)
                                Robberies++;
                            if (msg == Message.Arrest)
                                Arrest++;

                            Messages.Add(msg);
                        }
                    }
                }
            }
        }

        
        public void Clear()
        {
            Messages.Clear();
            foreach (var person in People)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(" ");
            }
        }

        
        public void Draw()
        {
            foreach (var person in People)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(person.Symbol);
            }
        }
    }
}


