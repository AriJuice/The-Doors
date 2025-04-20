using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace The_Doors
{
    internal class Player
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public string Name { get; set; }
        public int DoorsCompleted { get; set; }
        public bool ChestPlateEquipped { get; set; }
        public bool SwordEquipped { get; set; }


        public Player(int health, int damage, int defence, string name, int doorsCompleted, bool chestPlateEquipped = false, bool swordEquipped = false)
        {
            Health = health;
            Damage = damage;
            Defence = defence;
            Name = name;
            DoorsCompleted = doorsCompleted;
            ChestPlateEquipped = chestPlateEquipped;
            SwordEquipped = swordEquipped;
        }

        public static string GetName()
        {
            ConsoleSupport.SpareLine(2);
            Console.WriteLine("What will your name be?");
            Console.Write("-> ");
            string name = Console.ReadLine();

            name = name.ToLower();
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public static void PrintStats(int health, int damage, int defence)
        {

            ConsoleSupport.SpareLine(1);
            Console.WriteLine("Your current statistics are: ");
            ConsoleSupport.SpareLine(1);
            Console.WriteLine($"Health -> {health}");
            Console.WriteLine($"Damage -> {damage}");
            Console.WriteLine($"Defence -> {defence}");
        }

        public static void Battle(Player player)
        {
            Random random = new Random();
            int enemyHealth = random.Next(80, player.Health + 10);

            Console.WriteLine("You have come across a enemy!!!");
            Console.WriteLine("You defence value has been added onto your health..");

            player.Health += player.Defence;

            while (player.Health != 0 && enemyHealth != 0)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Player.PrintStats(player.Health, player.Damage, player.Defence);
                int damageDelt = 0;

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("___________________");
                }
                Console.WriteLine("Randomizing turn...");
                ConsoleSupport.SpareLine(1);

                int turn = random.Next(1, 3);
                if (turn == 1) 
                {
                    Console.WriteLine("It's your turn...");
                    ConsoleSupport.SpareLine(2);

                    damageDelt = random.Next(20, player.Damage);
                    enemyHealth -= damageDelt;

                    Console.WriteLine($"You have delt {damageDelt} damage to the enemy!");
                    if (enemyHealth < 0)
                    {
                        enemyHealth = 0;
                    }
                }
                else
                {
                    Console.WriteLine("It's the enemy's turn...");
                    ConsoleSupport.SpareLine(2);
                    damageDelt = random.Next(20, player.Damage);
                    player.Health -= damageDelt;
                    Console.WriteLine($"The enemy has delt {damageDelt} damage to you!");
                    if (player.Health < 0)
                    {
                        player.Health = 0;
                    }
                }
            }

            if (enemyHealth == 0)
            {
                Console.WriteLine("Nice job! You defeated them!");
                 player.Health = 100;
            }
            else
            {
                Console.WriteLine("You lost... Better luck next time!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
