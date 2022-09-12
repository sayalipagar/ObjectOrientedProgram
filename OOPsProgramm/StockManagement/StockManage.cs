using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsProgramm.StockManagement
{
    internal class StockManage
    {
        List<StockDetails> stocks = new List<StockDetails>();
        List<Company> companyList = new List<Company>();
        public void ReadJsonFileStockDetails(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.stocks = JsonConvert.DeserializeObject<List<StockDetails>>(json);
                Console.WriteLine("StockName" + "\t\t" + "NoOfShare" + "\t" + "PricePerShare");
                foreach (var data in stocks)
                {
                    Console.WriteLine(data.Name + "\t\t" + data.NoOfShares + "\t\t" + data.PricePerShare);
                }
            }
        }
        public void ReadJsonFileCompany(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.companyList = JsonConvert.DeserializeObject<List<Company>>(json);
                Console.WriteLine("StockName:" + "\t\t" + "NoOfShare:" + "\t" + "PricePerShare");
                foreach (var data in companyList)
                {
                    Console.WriteLine(data.Symbol + "\t\t" + data.NoOfShares + "\t\t" + data.PricePerShare);
                }
            }
        }
        public void BuyComapanyShares(Company company)
        {
            bool flag = false;
            foreach (var companyDetails in companyList)
            {
                if (companyDetails.Symbol == company.Symbol)
                {
                    companyDetails.NoOfShares -= company.NoOfShares;
                }
            }

            foreach (var stockDetails in stocks)
            {
                if (stockDetails.Name == company.Symbol)
                {
                    stockDetails.NoOfShares += company.NoOfShares;
                    flag = true;
                }
            }
            if (!flag)
            {
                StockDetails stock = new StockDetails();
                stock.Name = company.Symbol;
                stock.NoOfShares = company.NoOfShares;
                stock.PricePerShare = company.PricePerShare;
                stocks.Add(stock);
            }
        }
        public void SaleComapanyShares(StockDetails stock)
        {
            bool flag = false;
            foreach (var StockDetails in stocks)
            {
                if (StockDetails.Name == stock.Name)
                {
                    StockDetails.NoOfShares -= stock.NoOfShares;
                }
            }
            foreach (var companyDetails in companyList)
            {
                if (companyDetails.Symbol == stock.Name)
                {
                    companyDetails.NoOfShares += stock.NoOfShares;
                    flag = true;
                }
            }
            if (!flag)
            {
                Company company = new Company();
                company.Symbol = stock.Name;
                company.NoOfShares = stock.NoOfShares;
                company.PricePerShare = stock.PricePerShare;
                companyList.Add(company);
            }
        }
        public void WriteToJsonStockDetails(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.stocks);
            File.WriteAllText(filePath, json);
        }
        public void WriteToJsonCompany(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.companyList);
            File.WriteAllText(filePath, json);
        }
    }
}
