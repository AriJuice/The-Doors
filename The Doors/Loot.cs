using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace The_Doors
{
    internal class Loot
    {

        public static List<string> ChestLoot()
        {
            List<string> ChestLootChoices = new List<string>();
            ChestLootChoices.Clear();
            ChestLootChoices.Add("upgraded armor");
            ChestLootChoices.Add("upgraded sword");

            ChestLootChoices.Shuffle();
            return ChestLootChoices;
        }

        public static string GetChestPlateName()
        {
            List<string> ChestPlates = new List<string>
            {
                "Lionguard Warplate",
                "Crimson Aegis of Kingsfall",
                "Voidiron Shell",
                "Twilight Embermail",
                "Glacierbound Aegis",
                "Hellforged Cuirass",
                "Ironroot Defender",
                "Stormbound Carapace",
                "Dragonscale Aegis",
                "Cuirass of the Hollow King",
                "Carapace of Eternal Silence",
                "Tombwarden Cuirass",
                "Obsidian Vowguard",
                "Bastion of the Lost Legion",
                "Blackthorn Cuirass",
                "Bloodrune Shell",
                "Voidreaper's Embrace"
            };

            var random = new Random();
            int index = random.Next(ChestPlates.Count);
            return ChestPlates[index];
        }

        public static string GetSwordName()
        {
            List<string> SwordNames = new List<string>
            {
                "Shadowfang",
                "Dawnpiercer",
                "Emberwrath",
                "Frostbane",
                "Whisperfang",
                "Valkyrie's Edge",
                "Bloodreaver",
                "Celestial Fang",
                "Ashen Vow",
                "Stormcleaver",
                "Wyrmtooth",
                "Oathcarver",
                "Starbreaker",
                "Soulrender",
                "Glimmershard",
                "Ironhowl",
                "The Dreadbrand",
                "Eclipsefang",
                "Nightbloom",
                "Voidtalon"
            };
            var random = new Random();
            int index = random.Next(SwordNames.Count);
            return SwordNames[index];
        }

        public static void FindChestPlate(Player player)
        {
            Random random = new Random();
            int secondValue = (player.DoorsCompleted + 1) * 10;
            int defenseValue = random.Next(10, secondValue);

            Console.WriteLine($"Inside the chest you found a {Loot.GetChestPlateName()} " +
                              $"chest plate with a defense value of {defenseValue}");
            while (true)
            {
                Console.WriteLine("Do you want to equip it? (Y/N)");
                Console.Write("->");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        if (player.ChestPlateEquipped)
                        {
                            Console.WriteLine("You have already equipped a chest plate.\n" +
                                              "Remember when you equip something, Its permanent");

                            Console.WriteLine("You defence value has stayed the same");
                            break;
                        }
                        else
                        {
                            player.ChestPlateEquipped = true;
                            Console.WriteLine($"Your defence value has increased by " + defenseValue);
                            player.Defence = player.Defence + defenseValue;
                            ConsoleSupport.SpareLine(2);
                            Player.PrintStats(player.Health, player.Damage, player.Defence);
                            break;
                        }

                    case "n":
                        Console.WriteLine("You defence value has stayed the same");
                        break;

                    default:
                        continue;
                }
                break;
            }
        }

        public static void FindSword(Player player)
        {
            Random random = new Random();
            int attackValue = random.Next(10, (player.DoorsCompleted) + 1 * 10);

            Console.WriteLine($"Inside the chest you found a {Loot.GetSwordName()} " +
                              $"sword with a attack value of {attackValue}");
            while (true)
            {
                Console.WriteLine("Do you want to equip it? (Y/N)");
                Console.Write("->");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        if (player.SwordEquipped)
                        {
                            Console.WriteLine("You have already equipped a sword.\n" +
                                              "Remember when you equip something, Its permanent");

                            Console.WriteLine("Your attack value has stayed the same");
                            break;
                        }
                        else
                        {
                            player.SwordEquipped = true;
                            Console.WriteLine($"Your attack value has increased by " + attackValue);
                            player.Damage = player.Damage + attackValue;
                            ConsoleSupport.SpareLine(2);
                            Player.PrintStats(player.Health, player.Damage, player.Defence);
                            break;
                        }

                    case "n":
                        Console.WriteLine("You attack value has stayed the same");
                        break;

                    default:
                        continue;
                }
                break;
            }
            
        }
    }
}
    
