namespace The_Doors
{
    internal class MainProgram
    {
        static void Main()
        {
            // Welcome message Below:
            Console.WriteLine(" __        __   _                            _          ____                       \r\n \\ \\      / /__| | ___ ___  _ __ ___   ___  | |_ ___   |  _ \\  ___   ___  _ __ ___ \r\n  \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  | | | |/ _ \\ / _ \\| '__/ __|\r\n   \\ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | (_) | (_) | |  \\__ \\\r\n    \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  |____/ \\___/ \\___/|_|  |___/");

            ConsoleSupport.SpareLine(1);
            string name = Player.CreateName();
            int health = 100;
            int damage = 20;
            int defence = 10;

            Player player = new Player(health, damage, defence, name);
        }
    }
}
