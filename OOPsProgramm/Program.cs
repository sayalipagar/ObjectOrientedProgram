using OOPsProgramm.InventoryManagement;
using OOPsProgramm.InventoryManagementSystem;
using OOPsProgramm.StockAccountManagement;
using OOPsProgramm.StockManagement;

namespace OOPsProgramm
{
    internal class Program
    {
        const string INVENTORY_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\InventoryManagement\Inventory.json";
        const string INVENTORYDETAILS_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\InventoryManagementSystem\InventoryDetails.json";
        const string STOCK_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\StockAccountManagement\Stock.json";
        const string STOCKINFO_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\StockManagement\Stock.json";
        const string COMPANYDETAILS_DATA_FILE_PATH = @"D:\DotNetPrograms\ObjectOrientedProgram\OOPsProgramm\StockManagement\CompanyStock.json";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect Programm\n 1.Json Inventory Data Mangement\n 2.Inventory Management System\n 3.Stock\n 4.StockManagement");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Inventory inventory = new Inventory();
                        inventory.ReadJsonFile(INVENTORY_DATA_FILE_PATH);
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("\nSelect Programm\n 1. ADD\n 2.Delete\n 3.Edit");
                            int option1 = Convert.ToInt32(Console.ReadLine());
                            switch (option1)
                            {
                                case 1:
                                    InventoryFactory inventoryFactory = new InventoryFactory();
                                    inventoryFactory.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                                    InventoryDetails details = new InventoryDetails()
                                    {
                                        Name = "Kolam",
                                        Weight = 150,
                                        Price = 20
                                    };
                                    inventoryFactory.AddInventory("RiceList", details);
                                    inventoryFactory.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                                    break;
                                case 2:
                                    InventoryFactory inventoryFactory1 = new InventoryFactory();
                                    inventoryFactory1.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                                    InventoryDetails detail = new InventoryDetails()
                                    {
                                        Name = "xyz",
                                        Weight = 10,
                                        Price = 20
                                    };

                                    inventoryFactory1.DeleteInventory("RiceList", "xyz");
                                    inventoryFactory1.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                                    break;
                                default:
                                    break;
                                case 3:
                                    InventoryFactory inventoryFactory2 = new InventoryFactory();
                                    inventoryFactory2.ReadJsonFile(INVENTORYDETAILS_DATA_FILE_PATH);
                                    InventoryDetails details1 = new InventoryDetails()
                                    {
                                        Name = "c",
                                        Weight = 10,
                                        Price = 20
                                    };
                                    inventoryFactory2.EditInventory("PulseList", "c");
                                    inventoryFactory2.WriteToJson(INVENTORYDETAILS_DATA_FILE_PATH);
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Stock stock = new Stock();
                        stock.ReadJsonFile(STOCK_DATA_FILE_PATH);
                        break;
                    case 4:
                        while (true)
                        {
                            Console.WriteLine("\nSelect Programm\n 1.BuyShare\n 2.SaleShare");
                            int option1 = Convert.ToInt32(Console.ReadLine());
                            switch (option1)
                            {
                                case 1:
                                    StockManage management = new StockManage();
                                    management.ReadJsonFileStockDetails(STOCKINFO_DATA_FILE_PATH);
                                    management.ReadJsonFileCompany(COMPANYDETAILS_DATA_FILE_PATH);

                                    Company company = new Company()
                                    {
                                        Symbol = "Amazon",
                                        NoOfShares = 5,
                                        PricePerShare = 50,
                                    };
                                    management.BuyComapanyShares(company);
                                    management.WriteToJsonStockDetails(STOCKINFO_DATA_FILE_PATH);
                                    management.WriteToJsonCompany(COMPANYDETAILS_DATA_FILE_PATH);
                                    break;
                                case 2:
                                    StockManage management1 = new StockManage();
                                    management1.ReadJsonFileStockDetails(STOCKINFO_DATA_FILE_PATH);
                                    management1.ReadJsonFileCompany(COMPANYDETAILS_DATA_FILE_PATH);
                                    StockDetails stockDetails = new StockDetails()
                                    {
                                        Name = "Amazon",
                                        NoOfShares = 5,
                                        PricePerShare = 50,
                                    };
                                    management1.SaleComapanyShares(stockDetails);
                                    management1.WriteToJsonStockDetails(STOCKINFO_DATA_FILE_PATH);
                                    management1.WriteToJsonCompany(COMPANYDETAILS_DATA_FILE_PATH);
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}