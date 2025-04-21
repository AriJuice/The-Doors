namespace The_Doors
{
    internal class MainProgram
    {
        static void Main()
        {
            // Welcome message Below:
            Console.WriteLine(" __        __   _                            _          ____                       \r\n \\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___   |  _ \\  ___   ___  _ __ ___ \r\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  | | | |/ _ \\ / _ \\| '__/ __|\r\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | (_) | (_) | |  \\__ \\\r\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  |____/ \\___/ \\___/|_|  |___/");

            ConsoleSupport.SpareLine(1);
            string name = Player.GetName();
            int health = 100;
            int damage = 20;
            int defence = 10;

            Console.WriteLine("Welcome " + name);

            Player player = new Player(health, damage, defence, name, 0);

            while (player.DoorsCompleted < 5)
            {
                ConsoleSupport.SpareLine(2);
                var DoorList = LevelCreation.GetDoorList();
                player = LevelCreation.StartLevel(player, DoorList);
            }
            Console.WriteLine("Wow... I really did not expect you to make it... Good job.. I guess..."); 
        }
    }
}
