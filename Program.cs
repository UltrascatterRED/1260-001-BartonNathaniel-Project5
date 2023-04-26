using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool[] testExits = new bool[] { true, true, true, false };
            //int[] testPos = new int[] { 0, 0 };
            //Room test = new Room(testExits, true, false, testPos);
            //Room test2 = new Room();
            //test.DisplayRoom();

            Dungeon dungeon = new Dungeon(4, 10);
            //Console.WriteLine("Constructor success!");
            dungeon.DisplayMap();

            //prevents output console from instantly closing
            Console.ReadLine();
        }
    }
}