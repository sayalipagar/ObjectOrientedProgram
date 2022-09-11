using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsProgramm.StockAccountManagement
{
    internal class Stock
    {
        List<StockPortfolio> stocks = new List<StockPortfolio>();
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.stocks = JsonConvert.DeserializeObject<List<StockPortfolio>>(json);
                Console.WriteLine("StockName:" + "\t" + "NoOfShare:" + "\t" + "SharePrice" + "\t" + "TotalValue");
                foreach (var data in stocks)
                {
                    Console.WriteLine(data.StockName + "\t\t" + data.NoOfShare + "\t\t" + data.SharePrice + "\t\t" + data.NoOfShare * data.SharePrice);
                }
            }
        }
    }
}
