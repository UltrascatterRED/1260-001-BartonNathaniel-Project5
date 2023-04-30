using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_001_BartonNathaniel_Project5
{
    internal class Dungeon
    {
        private int[] Size = new int[2];
        private Room[] Rooms;

        private Random rand = new Random();

        public Room GetPlayerRoom()
        {
            foreach (Room room in Rooms)
            {
                if (room.GetPlayerPresent()) { return room; }
            }
            throw new Exception("[x] Player was not present in any room.");
        }
        public int GetPlayerRoomIndex()
        {
            for(int i = 0; i < Rooms.Length; i++)
            {
                if (Rooms[i].GetPlayerPresent())
                {
                    return i;
                }
            }
            throw new Exception("[x] Player must be present in exactly one room");
        }
        public int GetPlayerMapHeight()
        {
            int visitedRooms = 0;
            foreach(Room room in Rooms)
            {
                if (room.GetVisited())
                {
                    visitedRooms++;
                }
            }
            return (visitedRooms / Size[0] + 1) * 3;
        }
        public int GetFullMapHeight()
        {
            return Size[1] * 3;
        }
        public Dungeon()
        {
            //rooms will always generate in same pattern
            Size = new int[] {3, 3};
            Rooms = new Room[Size[0] * Size[1]];
            PopulateRoomList();
        }
        public Dungeon(int sizeX, int sizeY)
        {
            Size = new int[] { sizeX, sizeY };
            Rooms = new Room[Size[0] * Size[1]];
            PopulateRoomList();
        }
        private void PopulateRoomList()
        {
            for (int i = 0; i < Rooms.Length; i++)
            {
                //<debug>
                //Console.WriteLine("Room " + i);
                //</debug>
                int[] position = { i % Size[0], i / Size[0] };
                if (i == 0) //if this room is the entrance room
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, false, false, position);
                    Rooms[i].Visit();
                }
                else if (i == Rooms.Length - 1) //if this room is the exit room
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[0] == 0 && position[1] == Size[1] - 1) //if this room is the southwest corner
                {
                    bool[] exits = { false, true, true, false };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[0] == Size[0] - 1 && position[1] == 0) //if this room is the northeast corner
                {
                    bool[] exits = { true, false, false, true };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[0] == 0) //if this room is a west edge
                {
                    bool[] exits = { false, true, true, true };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[0] == Size[0] - 1) //if this room is an east edge
                {
                    bool[] exits = { true, true, false, true };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[1] == 0) //if this room is a north edge
                {
                    bool[] exits = { true, false, true, true };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else if (position[1] == Size[1] - 1) //if this room is a south edge
                {
                    bool[] exits = { true, true, true, false };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
                else //remaining rooms are all interior rooms
                {
                    bool[] exits = { true, true, true, true };
                    Rooms[i] = new Room(exits, DetermineHasMonster(), false, position);
                }
            }
            DetermineHasWeapon(2);
        }
        private bool DetermineHasMonster()
        {
            
            if(rand.Next(10000) < 5000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DetermineHasWeapon(int numAllowed)
        {
            for(int i = numAllowed; i > 0; i--)
            {
                Room receivingRoom;
                do
                {
                    receivingRoom = Rooms[(rand.Next(10000, 10000 * Rooms.Length + 1) / 10000) - 1];
                } while (receivingRoom.GetHasWeapon());

                receivingRoom.SetHasWeapon(true);
                if(rand.Next(10000) < 5000)
                {
                    receivingRoom.SetWeapon(new Weapon("sword", "A nice, sharp, conventional edged weapon. Polpular among adventurers.", 4, 0));
                }
                else
                {
                    receivingRoom.SetWeapon(new Weapon("stick", "A dimunitive branch, used as a weapon only in desperation.", 2, 0));
                }
            }
        }
        public void MovePlayer(int directionIndex)
        {
            int currentRoomIndex = GetPlayerRoomIndex();
            Room currentRoom = Rooms[currentRoomIndex];
            
            if(directionIndex < 0 || directionIndex > 3)
            {
                throw new ArgumentOutOfRangeException("Direction Index cannot be negative or exceed 3.");
            }
            switch(directionIndex)
            {
                case 0:
                    try
                    {
                        if (currentRoom.HasWestExit())
                        {
                            currentRoom.Leave();
                            Rooms[currentRoomIndex - 1].Visit();
                        }
                        else
                        {
                            GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                        }
                    }
                    catch
                    {
                        GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                    }
                    break;
                case 1:
                    try
                    {
                        if (currentRoom.HasNorthExit())
                        {
                            currentRoom.Leave();
                            Rooms[
                                ((currentRoom.GetPosY() - 1) * Size[0]) + currentRoom.GetPosX()
                                ].Visit();
                        }
                        else
                        {
                            GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                        }
                    }
                    catch
                    {
                        GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                    }
                    break;
                case 2:
                    try
                    {
                        if (currentRoomIndex == Rooms.Length - 1)
                        {
                            //Console.SetCursorPosition(0, GlobalAttributes.PlayerDungeon.GetPlayerMapHeight() + 1);
                            //<debug>
                            Console.SetCursorPosition(0, GlobalUtils.PlayerDungeon.GetFullMapHeight() + 1);
                            //</debug>
                            GlobalUtils.DisplayGameMessage
                                (
                                "*****************************************\n" +
                                "| Victory! You have exited the dungeon! |\n" +
                                "*****************************************"
                                );
                            int victoryMenuChoice = GlobalUtils.DisplayVictoryMenu();
                            GlobalUtils.ExecuteGameOverMenu( victoryMenuChoice );
                            GlobalUtils.PlayerInGame = false;
                            GlobalUtils.PlayerContinue = false;
                        }
                        else if (currentRoom.HasEastExit())
                        {
                            currentRoom.Leave();
                            Rooms[currentRoomIndex + 1].Visit();
                        }
                        else
                        {
                            GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                        }
                    }
                    catch
                    {
                        GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                    }
                    break;
                case 3:
                    try
                    {
                        currentRoom.Leave();
                        Rooms[
                            ((currentRoom.GetPosY() + 1) * Size[0]) + currentRoom.GetPosX()
                            ].Visit();
                    }
                    catch
                    {
                        GlobalUtils.DisplayGameMessage("You cannot walk that way.");
                    }
                    break;
            }
        }
        public void DisplayPlayerMap()
        {
            Console.Clear();
            foreach(Room room in Rooms) 
            {
                //only displays rooms the player has visited
                if (room.GetVisited()) 
                {
                    room.DisplayRoom();
                }
            }
        }
        public void DisplayFullMap()
        {
            Console.Clear();
            foreach (Room room in Rooms)
            {
                room.DisplayRoom();
            }
        }
        
    }
}
