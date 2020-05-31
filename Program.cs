using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPractice
{
    public class Program
    {
        public static void Main() {
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            Dictionary<string, int> millionaireList = new Dictionary<string, int>();
            millionaireList.Clear();
            foreach (Customer customer in customers)
            {
                if(customer.Bank == "WF" && customer.Balance >= 1_000_000)
                {
                    if(!millionaireList.ContainsKey("WF"))
                    {
                        millionaireList.Add("WF", 1);
                    } else
                    {
                        millionaireList["WF"] += 1;
                    }
                } else if(customer.Bank == "BOA" && customer.Balance >= 1_000_000)
                {
                    if(!millionaireList.ContainsKey("BOA"))
                    {
                        millionaireList.Add("BOA", 1);
                    } else
                    {
                        millionaireList["BOA"] += 1;
                    }
                } else if(customer.Bank == "FTB" && customer.Balance >= 1_000_000)
                {
                    if(!millionaireList.ContainsKey("FTB"))
                    {
                        millionaireList.Add("FTB", 1);
                    } else
                    {
                        millionaireList["FTB"] += 1;
                    }
                } else if(customer.Bank == "CITI" && customer.Balance >= 1_000_000)
                {
                    if(!millionaireList.ContainsKey("CITI"))
                    {
                        millionaireList.Add("CITI", 1);
                    } else
                    {
                        millionaireList["CITI"] += 1;
                    }
                }
            };
            foreach (KeyValuePair<string, int> item in millionaireList)
            {
                Console.WriteLine($"Bank: {item.Key}, Millionaires: {item.Value}");
            }
            Console.WriteLine("-------------");

            List<ReportItem> millionaireReport = new List<ReportItem>();
            foreach (Customer customer in customers)
            {
                Bank customerBank = banks.First(b => b.Symbol == customer.Bank);
                if(customer.Balance >= 1_000_000)
                {
                    millionaireReport.Add(new ReportItem(){CustomerName = customer.Name, BankName = customerBank.Name});
                }
            }            
            millionaireReport.Sort((x, y) => string.Compare(x.LastName, y.LastName));

            foreach (ReportItem item in millionaireReport)
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }

        }
    }
}
