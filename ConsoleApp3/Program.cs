using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(100, 20, 10, 10, 20,  new Random());
            Console.CursorVisible = false;

            while (true)
            {
                board.Clear();
                board.Update();
                board.Draw();

                
                Console.SetCursorPosition(0, 26);
                Console.WriteLine($"Antal rånade medborgare: {board.Robberies} ");
                Console.WriteLine($"Antal gripna tjuvar: {board.Arrest}");

                
                foreach (var item in board.Messages)
                {
                    Console.WriteLine(item);
                }

                
                if (board.Messages.Count == 0)
                {
                    Thread.Sleep(200); 
                }
                else
                {
                    Thread.Sleep(2000); 
                }

                
                Console.Clear();
            }
        }
    }
}



