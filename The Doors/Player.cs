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

        public Player(int health, int damage,int defence, string name)
        {
            Health = health;
            Damage = damage;
            Defence = defence;
            Name = name;
        }

        public static string CreateName()
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
    }
}
