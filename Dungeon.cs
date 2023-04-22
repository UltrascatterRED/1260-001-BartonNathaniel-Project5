using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Dungeon
    {
        private int[] Grid = new int[2];
        private List<Room> Rooms;

        public Dungeon()
        {
            //implement random generation of exit room
            //rooms will always generate in same pattern (except for exit room, random vertical location)
            Grid = new int[] {3, 3};
            Rooms = new List<Room>(Grid[0] * Grid[1]);
            for(int i = 1; i <= Rooms.Capacity; i++)
            {
                int[] position = { (i % Grid[0])-1, i / Grid[0] };
                if (i == 0)
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i == Rooms.Capacity) 
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if ((i-1) % Grid.GetLength(0) == 0)
                {
                    bool[] exits = { false, true, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if(i % Grid.GetLength(0) == 0)
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
        public Dungeon(int sizeX, int sizeY)
        {
            Grid = new int[] { sizeX, sizeY };
            Rooms = new List<Room>(Grid[0] * Grid[1]);
            for (int i = 1; i <= Rooms.Capacity; i++)
            {
                int[] position = { (i % Grid[0]) - 1, i / Grid[0] };
                if (i == 0)
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i == Rooms.Capacity)
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if ((i - 1) % Grid.GetLength(0) == 0)
                {
                    bool[] exits = { false, true, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                }
                else if (i % Grid.GetLength(0) == 0)
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
        public string DisplayMap()
        {
            StringBuilder bldr = new StringBuilder();
            foreach(Room room in Rooms) 
            { 

            }
            return bldr.ToString();
        }
    }
}
