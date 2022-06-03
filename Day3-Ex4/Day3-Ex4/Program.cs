using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3_Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            var customers = Console.ReadLine().Split(";");
            var products = Console.ReadLine().Split(";");
            try
            {
                foreach(string customer in customers)
                {
                    var customerInfo = customer.Split("=");
                    Person newPerson = new Person(customerInfo[0], int.Parse(customerInfo[1]));
                    personList.Add(newPerson);
                }

                foreach(string product in products)
                {
                    if (product != string.Empty)
                    {
                        var productInfo = product.Split("=");
                        Product newProduct = new Product(productInfo[0], int.Parse(productInfo[1]));
                        productList.Add(newProduct);
                    }
                }

                string cmdResult = "";

                string inputCmd = Console.ReadLine();

                while (inputCmd != "END")
                {

                    var buyCmd = inputCmd.Split();
                    var personBuy = from person in personList
                                    where person.Name == buyCmd[0]
                                    select person;
                    var itemBuy = from product in productList
                                  where product.Name == buyCmd[1]
                                  select product;
                    if (personBuy.First().Money >= itemBuy.First().Cost)
                    {
                        personBuy.First().Money = personBuy.First().Money - itemBuy.First().Cost;
                        personBuy.First().BagOfProducts.Add(itemBuy.First());
                        if(cmdResult != "")
                        {
                            cmdResult = cmdResult + "\n" + $"{personBuy.First().Name} bough {itemBuy.First().Name}";
                        }else
                        {
                            cmdResult = cmdResult + $"{personBuy.First().Name} bough {itemBuy.First().Name}";
                        }
                        
                    }
                    else
                    {
                        if (cmdResult != "")
                        {
                            cmdResult = cmdResult + "\n" + $"{personBuy.First().Name} can't afford {itemBuy.First().Name}";
                        }else
                        {
                            cmdResult = cmdResult + $"{personBuy.First().Name} can't afford {itemBuy.First().Name}";
                        }
                            
                    }

                    inputCmd = Console.ReadLine();

                }

                Console.WriteLine(cmdResult);

                foreach (var person in personList)
                {
                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        string productString = "";
                        foreach(Product product in person.BagOfProducts){
                            if (productString != "")
                            {
                                productString = productString + $", {product.Name}"; 
                            }
                            else
                            {
                                 productString = productString + $"{product.Name}"; 
                            }
                        }
                        Console.WriteLine($"{person.Name} - {productString}");
                    }
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
           
            }

        }
    }
}
