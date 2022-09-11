using Newtonsoft.Json;
using OOPsProgramm.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsProgramm.InventoryManagementSystem
{
    internal class InventoryFactory
    {
        InventoryManagement inventory = new InventoryManagement();
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.inventory = JsonConvert.DeserializeObject<InventoryManagement>(json);
                //Display(this.inventory.RiceList, "RiceList");
                //Display(this.inventory.WheatList, "WheatList");
                //Display(this.inventory.PulseList, "PulseList");
            }
        }
        public void AddInventory(string inventoryName, InventoryDetails details)
        {
            if (inventoryName == "RiceList")
            {
                this.inventory.RiceList.Add(details);
                Display(this.inventory.RiceList, "RiceList");

            }
            if (inventoryName == "WheatList")
            {
                this.inventory.WheatList.Add(details);
                Display(this.inventory.WheatList, "WheatList");
            }
            if (inventoryName == "PulseList")
            {
                this.inventory.PulseList.Add(details);
                Display(this.inventory.PulseList, "PulseList");
            }
        }
        public void DeleteInventory(string inventoryName, string inventoryDetailsName)
        {
            if (inventoryName == "RiceList")
            {
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        this.inventory.RiceList.Remove(data);
                        Display(this.inventory.RiceList, "RiceList");
                        return;
                    }
                }
            }
            if (inventoryName == "WheatList")
            {
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        this.inventory.WheatList.Remove(data);
                        Display(this.inventory.WheatList, "WheatList");
                        return;
                    }
                }
            }
            if (inventoryName == "PulseList")
            {
                foreach (var data in this.inventory.PulseList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        this.inventory.PulseList.Remove(data);
                        Display(this.inventory.PulseList, "PulseList");
                        return;
                    }
                }
            }
        }
        public void EditInventory(string inventoryName, string inventoryDetailsName)
        {
            Console.WriteLine("Enter any one of List- Rice Or Pulse Or Wheat which you want to edit of that  Inventory");
            string RiceList = Console.ReadLine();

            if (inventoryName == "RiceList")
            {
                Console.WriteLine("Enter the Rice name you want to Edit");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        Console.WriteLine("To Edit RiceList Enter 1. Weight 2.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                        Display(this.inventory.RiceList, "RiceList");
                    }
                }
            }
            if (inventoryName == "WheatList")
            {
                Console.WriteLine("Enter the Wheat name you want to Edit");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        Console.WriteLine("To Edit WheatList Enter 1. Weight 2.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                        Display(this.inventory.WheatList, "WheatList");
                    }
                   
                }
            }
            if (inventoryName == "PulseList")
            {
                Console.WriteLine("Enter the Pulse name you want to Edit");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.PulseList)
                {
                    if (data.Name == inventoryDetailsName)
                    {
                        Console.WriteLine("To Edit PulseList Enter 1. Weight 2.Price ");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose valid option");
                                break;
                        }
                        Display(this.inventory.PulseList, "PulseList");
                    }

                }
            }
        }
        public void WriteToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.inventory);
            File.WriteAllText(filePath, json);
        }
        public void Display(List<InventoryDetails> list, string inventoryName)
        {
            Console.WriteLine("Inventory is :" + inventoryName);
            Console.WriteLine("Name" + "\t" + "Weight" + "\t" + "Price");
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + "\t" + data.Weight + "\t" + data.Price);
            }
        }
    }
}
