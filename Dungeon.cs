using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Dungeon
    {
        private int[] Size = new int[2];
        private Room[] Rooms;

        public Dungeon()
        {
            //implement random generation of exit room
            //rooms will always generate in same pattern (except for exit room, random vertical location)
            Size = new int[] {3, 3};
            Rooms = new Room[Size[0] * Size[1]];
            for(int i = 0; i < Rooms.Length; i++)
            {
                //<debug>
                Console.WriteLine("Room " + i);
                //</debug>
                int[] position = { i % Size[0], i / Size[0] };
                if (i == 0)
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i == Rooms.Length-1) 
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (position[0] == 0)
                {
                    bool[] exits = { false, true, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (position[0] == Size[1]-1)
                {
                    bool[] exits = { true, true, false, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else
                {
                    bool[] exits = { true, true, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
            }
        }
        public Dungeon(int sizeX, int sizeY)
        {
            Size = new int[] { sizeX, sizeY };
            Rooms = new Room[Size[0] * Size[1]];
            for (int i = 1; i <= Rooms.Length; i++)
            {
                int[] position = { (i % Size[0]), i / Size[0] };
                if (i == 0)
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i == Rooms.Length)
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if ((i - 1) % Size.GetLength(0) == 0)
                {
                    bool[] exits = { false, true, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i % Size.GetLength(0) == 0)
                {
                    bool[] exits = { true, true, false, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else
                {
                    bool[] exits = { false, false, false, false };
                    Rooms[i] = new Room();
                }
            }
        }
        public void DisplayMap()
        {
            foreach(Room room in Rooms) 
            {
                Console.Write(room.MapString());
            }
        }
    }
}
