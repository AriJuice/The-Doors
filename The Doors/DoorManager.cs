using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Doors
{
    public enum DoorResult
    {
        FreePass = 0, 
        Enemy = 1,
        Chest = 2
    }

    public class Door
    {
        public int Id { get; set; }
        public bool IsOpened { get; set; }
        public DoorResult DoorResult { get; set; }

        public static string GetDoorChoice(List<Door> DoorList)
        {
            for (var i = 0; i < DoorList.Count; i++)
            {
                Console.WriteLine($"Door {DoorList[i].Id}");
            }

            Console.Write("-> ");
            string doorChoice = Console.ReadLine();

            return doorChoice;
        }
    };
    

    

        
}
