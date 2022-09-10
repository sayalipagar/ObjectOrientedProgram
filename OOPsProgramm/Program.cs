using OOPsProgramm.InventoryManagement;

namespace OOPsProgramm
{
    internal class Program
    {
        const string INVENTORY_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\InventoryManagement\Inventory.json";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect Programm\n 1.Json Inventory Data Mangement");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Inventory inventory = new Inventory();
                        inventory.ReadJsonFile(INVENTORY_DATA_FILE_PATH);
                        break;
                }
            }
        }
    }
}