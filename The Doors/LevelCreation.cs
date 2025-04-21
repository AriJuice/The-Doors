using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Doors
{
    internal class LevelCreation
    {
        public int LevelNum { get; set; }
        
        public LevelCreation(int level)
        {
            LevelNum = level;
        }
        public static List<Door> GetDoorList()
        {
            List<DoorResult> doorResults = new List<DoorResult>()
            {
                DoorResult.FreePass,
                DoorResult.Enemy,
                DoorResult.Chest
            };

            ConsoleSupport.Shuffle(doorResults);

            List<Door> DoorList = new List<Door>()
            {
                new Door()
                {
                    Id = 1,
                    IsOpened = false,
                    DoorResult = doorResults[0]
                },
                new Door()
                {
                    Id = 2,
                    IsOpened = false,
                    DoorResult = doorResults[1]
                },
                new Door()
                {
                    Id = 3,
                    IsOpened = false,
                    DoorResult = doorResults[2]
                },
            };
            return DoorList;
        }
        public static Player StartLevel(Player player, List<Door> DoorList)
        {
            ConsoleSupport.SpareLine(2);
            Console.WriteLine($"Welcome to level {player.DoorsCompleted + 1}");

            ConsoleSupport.SpareLine(2);
            Player.PrintStats(player.Health, player.Damage, player.Defence);
            ConsoleSupport.SpareLine(1);

            List<int> ChosenDoors = new List<int>();

            while (DoorList.Count > 0)
            {
                ConsoleSupport.SpareLine(3);

                string door_Choice = Door.GetDoorChoice(DoorList);

                bool transWorked = int.TryParse(door_Choice, out int doorChoice);
                if (transWorked != true)
                {
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (doorChoice > 0 && doorChoice < 4 && !ChosenDoors.Contains(doorChoice))
                    {
                        ChosenDoors.Add(doorChoice);

                        var door = DoorList.Where(door => door.Id == doorChoice).FirstOrDefault();

                        switch (door.DoorResult)
                        {
                            case DoorResult.FreePass:

                                Console.WriteLine("Free pass");
                                player.DoorsCompleted = player.DoorsCompleted + 1;
                                
                                return player;


                            case DoorResult.Enemy:

                                DoorList.Remove(door);

                                Player.Battle(player);
                                continue;


                            case DoorResult.Chest:

                                var chestDoor = DoorList.Where(door => door.Id == doorChoice).ToList();

                                foreach (var i in chestDoor)
                                {
                                    DoorList.Remove(i);
                                }

                                ConsoleSupport.SpareLine(2);
                                Console.WriteLine("Behind the door you found a chest!");
                                Thread.Sleep(1000);
                                List<string> ChestLootChoices = new List<string>();
                                ChestLootChoices = Loot.ChestLoot();

                                if (ChestLootChoices[0] == "upgraded armor")
                                {
                                    Loot.FindChestPlate(player);
                                    continue;
                                }
                                else if (ChestLootChoices[0] == "upgraded sword")
                                {
                                    Loot.FindSword(player);
                                    continue;
                                }
                                continue;
                        }
                    }
                }
            }
            return player;
        }
    }
}
